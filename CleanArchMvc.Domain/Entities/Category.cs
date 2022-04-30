using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    //Classe Sealed não pode ser herdada
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        //Construtor
        public Category(string name)
        {
            ValidateDomain(name);
        }

        //Construtor
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID!");
            Id = id;
            ValidateDomain(name);
        }

        //Atualiza a propriedade Name:
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        //Associação
        public ICollection<Product> Products { get; set; }
    
        //Método para validar a propriedade NAME:
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name. Name is Required!");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name. Too Short! Name Must have 3 Characters at least!");
            Name = name;
        }
    }
}
