using Domain.Validation;

namespace Domain.Entities
{
    public sealed class Product : Base
    {

        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }
        public int CategoryId { get; set; } //**
        public Category? Category { get; set; } //**

        public Product(int id, string? name, string? description, decimal price, int stock, string? image)
        {
            DomainExceptionValidation.When(Id <= 0, "Id must be greater than 0");
            ValidateDomain(name, description, price, stock, image);
            Id = id;
        }

        public Product(string? name, string? description, decimal price, int stock, string? image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public void Update(string? name, string? description, decimal price, int stock, string? image, int catetegoryId)
        {
            DomainExceptionValidation.When(catetegoryId <= 0, "Id must be greater than 0");
            CategoryId = catetegoryId;
            ValidateDomain(name, description, price, stock, image);
        }


        private void ValidateDomain(string? name, string? description, decimal price, int stock, string? image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name) && name.Length < 2,
                "Invalid name. Name is Required and must be greater than 2 caracters");

            DomainExceptionValidation.When(description.Length < 5 && string.IsNullOrEmpty(description),
                "Invalid description. Description is Required and must be greater than 5 caracters.");

            DomainExceptionValidation.When(price == null && price < 0,
                "price cannot be null and cannot be 0 ");

            DomainExceptionValidation.When(stock == null && stock < 0,
                "stock cannot be null and cannot be 0 ");

            DomainExceptionValidation.When(image.Length < 5 && string.IsNullOrEmpty(image),
                "Invalid image. image is Required and must be greater than 5 caracters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}

//** navigation property does not belong to the domain model so it wont be set as private as the domain properties