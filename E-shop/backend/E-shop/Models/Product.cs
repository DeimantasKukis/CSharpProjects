using System;

namespace E_shop.Models
{
    public class Product
    {
        public Product(string productName, string id, string productDescription, double startPrice, double discount, string photo)
        {
            ProductName = productName;
            Id = id;
            ProductDescription = productDescription;
            StartPrice = startPrice;
            Discount = discount;
            FinalPrice = startPrice - discount;
            Photo = photo;
        }

        public string ProductName { get; }
        public String Id { get; }
        public string ProductDescription { get; }
        public double StartPrice { get; }
        public double Discount { get; }
        public double FinalPrice { get; }
        public string Photo { get; }

        public string GetInformation()
        {
            return $"{Id} {ProductName} {ProductDescription} {StartPrice} {FinalPrice} {Photo}";
        }
    }
}
