using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;

namespace RDev.ToolsSys.DataAccess.Help
{
    class SqlParaDominio
    {

        public static void RetonarValor(SqlDataReader oSqlDataReader, object pthis)
        {
            Type type = pthis.GetType();

            for (int i = 0; i < oSqlDataReader.VisibleFieldCount; i++)
            {
                string nomeDaColuna = "_" + oSqlDataReader.GetName(i);

                FieldInfo field = type.GetField(nomeDaColuna, 
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);

                if (field != null)
                {
                    object value = oSqlDataReader.GetValue(i);

                    if (value != DBNull.Value)
                        field.SetValue(pthis, Convert.ChangeType(value, field.FieldType));
                    else
                        field.SetValue(pthis, ObtemValorNuloParaTipo(field.FieldType));
                }
            }
        }

        private static object ObtemValorNuloParaTipo(Type type)
        {
            string tipoComoString = type.Name.ToLower();

            switch (tipoComoString)
            {
                case "float":
                    return -1.0f;
                case "double":
                    return -1.0;
                case "decimal":
                    return -1.0M;
                case "byte":
                    return default(byte);
                case "datetime":
                    return new DateTime(1900, 1, 1);
                case "string":
                    return string.Empty;
                case "int16":
                    return (short)-1;
                case "int32":
                    return -1;
                case "int64":
                    return -1L;
                default:
                    return null;
            }
        }
    }
}
