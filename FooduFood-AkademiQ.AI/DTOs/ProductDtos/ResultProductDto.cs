using FooduFood_AkademiQ.AI.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FooduFood_AkademiQ.AI.DTOs.ProductDtos
{
    public class ResultProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Weight { get; set; }
        public string Dimensions { get; set; }
        public float PriceHalf { get; set; }
        public float PriceFull { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsPopular { get; set; }
        public string CategoryName { get; set; }
        public List<string> Ingredients { get; set; }



        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        

        public List<ProductReview> Reviews { get; set; }
    }
}
