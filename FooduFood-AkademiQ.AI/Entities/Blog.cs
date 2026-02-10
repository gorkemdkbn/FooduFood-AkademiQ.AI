using FooduFood_AkademiQ.AI.Entities.Common;

namespace FooduFood_AkademiQ.AI.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string BlogDetails { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Tags { get; set; }
    }
}
