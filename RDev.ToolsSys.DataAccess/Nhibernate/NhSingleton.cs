using System;
using System.Runtime.Remoting.Messaging;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using RDev.ToolsSys.DataAccess.Nhibernate.Conventions;
using RDev.ToolsSys.DataAccess.Nhibernate.Mapping;

namespace RDev.ToolsSys.DataAccess.Nhibernate
{
    /// <summary>
    /// Handles creation and management of sessions and transactions.  It is a singleton because 
    /// building the initial session factory is very expensive. Inspiration for this class came 
    /// from Chapter 8 of Hibernate in Action by Bauer and King.  Although it is a sealed singleton
    /// you can use TypeMock (http://www.typemock.com) for more flexible testing.
    /// </summary>
    public sealed class NhSingleton
    {
        #region Thread-safe, lazy Singleton

        /// <summary>
        /// Gets an instance via a thread-safe, lazy singleton.
        /// </summary>
        /// <remarks>
        /// See http://www.yoda.arachsys.com/csharp/singleton.html for more details about its implementation.
        /// </remarks>
        public static NhSingleton Instance
        {
            get
            {
                return Nested.NhSingleton;
            }
        }

        /// <summary>
        /// Prevents a default instance of the NhSingleton class from being created.
        /// Initializes the NHibernate session factory upon instantiation.
        /// </summary>
        private NhSingleton()
        {
            this.InitSessionFactory();
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            private Nested()
            {
            }

            internal static readonly NhSingleton NhSingleton = new NhSingleton();
        }

        #endregion

        private void InitSessionFactory()
        {
            FluentConfiguration cfg = Fluently.Configure()
                        .Mappings
                        (m => m.FluentMappings.AddFromAssemblyOf<PessoaMap>()
                            .Conventions.Setup(GetConventions()))
                            .Database(MsSqlConfiguration.MsSql2008
                            .IsolationLevel("ReadCommitted")
                            .ConnectionString(c => c.FromConnectionStringWithKey("ConnectionString"))
                //.ShowSql()
                        );

#if DEBUG
            cfg.Database(MsSqlConfiguration.MsSql2008.ShowSql());
#endif

            this.sessionFactory = cfg.BuildSessionFactory();
        }


        // !! MUITO CUIDADO !! - RECRIA BANCO DE DADOS !!
        ////////private static void BuildSchema(FluentConfiguration configuration)
        ////////{
        ////////    var sessionSource = new SessionSource(configuration);
        ////////    var session = sessionSource.CreateSession();
        ////////    sessionSource.BuildSchema(session);
        ////////}

        //////// ESSE BELEZA
        private void BuildSchemaToFile(Configuration cfg, string pathFileName)
        {
            SchemaExport exp = new SchemaExport(cfg);
            exp.SetOutputFile(pathFileName);
            exp.Create(true, false);
        }

        private static Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                c.Add<CascadeConvention>();
                c.Add<EnumConvention>();
            };
        }

        /// <summary>
        /// Allows you to register an interceptor on a new session.  This may not be called if there is already
        /// an open session attached to the HttpContext.  If you have an interceptor to be used, modify
        /// the HttpModule to call this before calling BeginTransaction().
        /// </summary>
        public static void RegisterInterceptor(IInterceptor interceptor)
        {
            ISession session = ContextSession;

            if (session != null && session.IsOpen)
            {
                throw new CacheException(new System.Resources.ResourceManager(typeof(NhSingleton)).GetString("RegisterInterceptor_CacheException"));
            }

            OpenSession(interceptor);
        }

        /// <summary>
        /// Gets a session (without an interceptor). This method is not called directly; instead,
        /// it gets invoked from other public methods.
        /// </summary>
        /// <returns></returns>
        public static ISession OpenSession()
        {
            return OpenSession(null);
        }

        public static IStatelessSession OpenStatelessSession()
        {
            return Instance.sessionFactory.OpenStatelessSession();
        }

        /// <summary>
        /// Gets a session with or without an interceptor. This method is not called directly; instead,
        /// it gets invoked from other public methods.
        /// </summary>
        /// <remarks>
        /// Throws <see cref="HibernateException"/> if a reference to a session could not be retrieved.
        /// </remarks>
        private static ISession OpenSession(IInterceptor interceptor)
        {
            ISession session = ContextSession;

            if (session == null)
            {
                if (interceptor != null)
                {
                    session = Instance.sessionFactory.OpenSession(interceptor);
                }
                else
                {
                    session = Instance.sessionFactory.OpenSession();
                }

                ContextSession = session;
            }

            if (session == null)
            {
                throw new HibernateException("Session was null");
            }

            return session;
        }

        /// <summary>
        /// Flushes anything left in the session, committing changes as long as no <see cref="NHibernate.AssertionFailure">NHibernate.AssertionFailure's</see> are thrown.
        /// </summary>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static void FlushSession()
        {
            ISession session = ContextSession;

            if (session != null && session.IsOpen)
            {
                // Due to a bug in Hibernate (see http://forum.hibernate.org/viewtopic.php?p=2293664#2293664) make sure Flush() is wrapped in a transaction
                if (!HasOpenTransaction())
                {
                    BeginTransaction();
                }

                try
                {
                    session.Flush();
                }
                catch (AssertionFailure af)
                {
                    if (af.Message == "null id in entry (don't flush the Session after an exception occurs)")
                    {
                        System.Diagnostics.Trace.TraceError("NHibernate.AssertionFailure: " + af.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
                CommitTransaction();
            }

            ContextSession = null;
        }

        /// <summary>
        /// Flushes anything left in the session and closes the connection.
        /// </summary>
        public static void CloseSession()
        {
            ISession session = ContextSession;

            if (session != null && session.IsOpen)
            {
                FlushSession();
                session.Close();
            }

            ContextSession = null;
        }

        /// <summary>
        /// Begin an ITransaction (if one is not already active)
        /// </summary>
        public static void BeginTransaction()
        {
            ITransaction transaction = ContextTransaction;

            if (transaction == null)
            {
                transaction = OpenSession().BeginTransaction();
                ContextTransaction = transaction;
            }
        }

        /// <summary>
        /// Begin an ITransaction (if one is not already active)
        /// </summary>
        /// <param name="isolationLevel"></param>
        public static void BeginTransaction(System.Data.IsolationLevel isolationLevel)
        {
            ITransaction transaction = ContextTransaction;

            if (transaction == null)
            {
                transaction = OpenSession().BeginTransaction(isolationLevel);
                ContextTransaction = transaction;
            }
        }

        /// <summary>
        /// Commit transaction, if a transaction is currently open. Automatic rollback if commit fails.
        /// </summary>
        public static void CommitTransaction()
        {
            ITransaction transaction = ContextTransaction;

            try
            {
                if (HasOpenTransaction())
                {
                    try
                    {
                        transaction.Commit();
                    }
                    catch (AssertionFailure af)
                    {
                        if (af.Message == "null id in entry (don't flush the Session after an exception occurs)")
                        {
                            System.Diagnostics.Trace.TraceError("NHibernate.AssertionFailure: " + af.Message);
                        }
                        else
                        {
                            throw;
                        }
                    }
                    ContextTransaction = null;
                }
            }
            catch (HibernateException)
            {
                RollbackTransaction();
                throw;
            }
        }

        /// <summary>
        /// Checks for an open <see cref="ITransaction"/>.
        /// </summary>
        /// <returns></returns>
        public static bool HasOpenTransaction()
        {
            ITransaction transaction = ContextTransaction;

            return transaction != null && transaction.IsActive && !transaction.WasCommitted && !transaction.WasRolledBack;
        }

        /// <summary>
        /// Rollback transaction, closing the <see cref="ContextSession"/> if successful.
        /// </summary>
        public static void RollbackTransaction()
        {
            ITransaction transaction = ContextTransaction;

            try
            {
                if (HasOpenTransaction())
                {
                    transaction.Rollback();
                }

                ContextTransaction = null;
            }
            finally
            {
                if (ContextSession != null)
                {
                    ContextSession.Close();
                    ContextSession = null;
                }
            }
        }

        /// <summary>
        /// If within a web context, this uses <see cref="HttpContext" /> instead of the WinForms 
        /// specific <see cref="CallContext" />.  Discussion concerning this found at 
        /// http://forum.springframework.net/showthread.php?t=572.
        /// </summary>
        private static ITransaction ContextTransaction
        {
            // this should be here, but it starts a chain of having to mark this ALL over. So we're ignoring it here.
            // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, SkipVerification = true)]
            get
            {
                return (ITransaction)CallContext.GetData(TRANSACTION_KEY);
            }
            // this should be here, but it starts a chain of having to mark this ALL over. So we're ignoring it here.
            // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, SkipVerification = true)]
            set
            {
                CallContext.SetData(TRANSACTION_KEY, value);
            }
        }

        /// <summary>
        /// If within a web context, this uses <see cref="HttpContext" /> instead of the WinForms 
        /// specific <see cref="CallContext" />.  Discussion concerning this found at 
        /// http://forum.springframework.net/showthread.php?t=572.
        /// </summary>
        private static ISession ContextSession
        {
            // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, SkipVerification = true)]  // this should be here, but it starts a chain of having to mark this ALL over. So we're ignoring it here.
            get
            {
                return (ISession)CallContext.GetData(SESSION_KEY);
            }
            // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, SkipVerification = true)]  // this should be here, but it starts a chain of having to mark this ALL over. So we're ignoring it here.
            set
            {
                CallContext.SetData(SESSION_KEY, value);
            }
        }

        private const string TRANSACTION_KEY = "CONTEXT_TRANSACTION";
        private const string SESSION_KEY = "CONTEXT_SESSION";
        private ISessionFactory sessionFactory;
    }
}
