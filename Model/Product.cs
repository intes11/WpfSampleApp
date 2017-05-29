using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public double Cost { get; set; }

        [DataMember]
        public double Price { get; set; }

        public Product()
        { }

        public Product(int id, string name, string category, double cost, double price)
        {
            Id = id;
            Name = name;
            Category = category;
            Cost = cost;
            Price = price;
        }
    }
}
