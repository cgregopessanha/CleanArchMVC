using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    //Classe Sealed não pode ser herdada
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        //Contrutor
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        //Contrutor
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value!");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        //Atualizando produto
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        //Validando o Domain;
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            //Validação do name
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name. Name is Required!");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name. Too Short! Name Must have 3 Characters at least!");

            //validação da description
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid Description. Description is Required!");
            DomainExceptionValidation.When(description.Length < 5, "Invalid Description. Too Short! Description Must have 5 Characters at least!");

            //validação do price
            DomainExceptionValidation.When(price < 0, "Invalid Price Value.");

            //validação do stock
            DomainExceptionValidation.When(stock < 0, "Invalid Stock Value.");

            //validação da image
            DomainExceptionValidation.When(image?.Length > 250, "Invalid Image Name. Too Long! Maximum have 250 Characters!");
            //O operador ? null condicional => image?.Length vaiavaliar o valor de image e se ele for null o resultado será null,
            //caso contrário, ele avalia a expressão image?.Length > 250
        }

        //Propriedades de Navegação:
        //Chave estrangeira
        public int CategoryId { get; set; }
        //Associação:
        public Category Category { get; set; }
    }
}
