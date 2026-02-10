using FooduFood_AkademiQ.AI.Entities.Common;

namespace FooduFood_AkademiQ.AI.Entities
{
    public class Admin : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
    }
}
