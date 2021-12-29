using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public Category(string name)
        {
           ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name. Name is required.");
            DomainExceptionValidation.When(name.Length<3, "Name must be at least 3 letters.");

            Name = name;
        }

        public Category(int id, string name)
        {
            ValidateDomain(name);
            DomainExceptionValidation.When(id<0, "Invalid Id. Must be at least 1.");

            Id = id;
            Name = name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }        

        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }
    }
}
