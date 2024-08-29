using Domain.Validation;

namespace Domain.Entities
{
    public sealed class Category : Base
    {
        public string? Name { get; private set; }
        public ICollection<Product>? Products { get; set; }//**

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id <= 0, "Id must be greater than 0");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is Required");

            DomainExceptionValidation.When(name.Length <= 2, "Name too short, minimum 2 caracters.");

            Name = name;
        }


    }
}

//** navigation property does not belong to the domain model so it wont be set as private as the domain properties