using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValiteDateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValiteDateDomain(name, description, price, stock, image);

            DomainExceptionValidation.When(id > 0, "Invalid Id value.");

            Id = id;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValiteDateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValiteDateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, too short, minimum 3 characteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid descripition. Description is required.");

            DomainExceptionValidation.When(description.Length < 0,
                "Invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.When(price < 0,
                "Invalid price value.");

            DomainExceptionValidation.When(stock < 0,
                "Invalid price value.");

            DomainExceptionValidation.When(image.Length > 250,
                "Invalid image, name, too long maximum 250 characteres.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
