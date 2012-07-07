using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace RDev.ToolsSys.DataAccess.Nhibernate.Conventions
{
    public class CascadeConvention : IReferenceConvention, IHasManyConvention, IHasManyToManyConvention
    {
        public void Apply(IOneToOneInstance instance)
        {

        }

        public void Apply(IManyToOneInstance instance)
        {

        }

        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Cascade.All();
            //instance.Inverse();
        }

        public void Apply(IManyToManyCollectionInstance instance)
        {

        }
    }
}