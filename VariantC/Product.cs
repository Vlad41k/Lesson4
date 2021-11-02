using System;


namespace VariantC
{
    class Product
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
        public Product (string title, string description, double price)
        {
            Title = title;
            Description = description;
            Price = price;
        }
        public override string ToString() => $"{Title}, {Description}, цена: {Price}$";
    }
}
