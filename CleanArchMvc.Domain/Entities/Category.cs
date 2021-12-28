using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
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

        public int Id { get; private set; }

        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }
    }
}
