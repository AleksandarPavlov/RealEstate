
using RealEstate.Domain.Property.ValueObjects;

namespace RealEstate.Domain.Property
{
    public partial class Property
    {
        public long Id { get; private set; }
        public PropertyName Name { get; private set; }

        private Property(long id, PropertyName name)
        {
            Id = id;
            Name = name;
        }
    }
}
