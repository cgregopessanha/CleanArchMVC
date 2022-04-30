using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    //A implementação dessa interface será implementada na classe concreta na camada de Infra
    //AS Operações serão Assíncronas usando o TASK;
    public interface IProductRepository
    {
        //Obter uma lista com todos os Produtos;
        Task<IEnumerable<Product>> GetProductsAsync();

        //Obter uma Categoria pelo Id;
        Task<Product> GetByIdAsync(int? id);
        
        //Retorna os Produtos pelo Id de uma categoria;
        Task<Product> GetProductCategoryAsync(int? id);

        //Criar um Produto;
        Task<Product> CreateAsync(Product product);

        //Atualizar um Produto;
        Task<Product> UpdateAsync(Product product);

        //Remover um Produto;
        Task<Product> RemoveAsync(Product product);
    }
}
