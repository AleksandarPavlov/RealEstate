
namespace RealEstate.Infrastructure.Persistance.Entities
{
    public class PropertyImage
    {
        public long Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public long PropertyId { get; set; }
        public Property? Property { get; set; }
        public PropertyImage(
            string url
        )
        {
            Url = url;
        }
    }
}
