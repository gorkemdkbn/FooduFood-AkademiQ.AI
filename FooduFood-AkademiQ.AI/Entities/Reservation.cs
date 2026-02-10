using FooduFood_AkademiQ.AI.Entities.Common;

namespace FooduFood_AkademiQ.AI.Entities
{
    public class Reservation:BaseEntity
    {
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string NumberOfPeople { get; set; }
        public DateTime ReservationAt { get; set; }
        public bool? Status { get; set; }

    }
}
