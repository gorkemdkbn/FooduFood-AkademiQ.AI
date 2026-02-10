using FooduFood_AkademiQ.AI.Entities.Common;

namespace FooduFood_AkademiQ.AI.Entities
{
    public class BlogComment : BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BlogId { get; set; }
    }
}
