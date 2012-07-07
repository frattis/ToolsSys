using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace RDev.ToolsSys.DataAccess.Nhibernate.Conventions
{
    public class EnumConvention : IUserTypeConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum ||
                                 (x.Property.PropertyType.IsGenericType &&
                                  x.Property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                                  x.Property.PropertyType.GetGenericArguments()[0].IsEnum)
                );
        }

        public void Apply(IPropertyInstance target)
        {
            target.CustomType(target.Property.PropertyType);
        }
    }
}