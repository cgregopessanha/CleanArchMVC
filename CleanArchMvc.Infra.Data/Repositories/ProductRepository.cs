
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            //Adicionando um Produto no contexto
            _productContext.Products.Add(product);

            //Persistindo na banco;
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            //Obtendo  um produto pelo seu Id;
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            //Eager Load
            //Carregamento do produto pelo seu id, incluindo sua categoria relacionada onde seu id é igual ao id que veio como argumento;
            return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            //Removo um produto do contexto;
            _productContext.Remove(product);

            //Persisto no banco;
            await _productContext.SaveChangesAsync();

            //retorno do produto
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            //Atualizo um produto do contexto;
            _productContext.Update(product);

            //Persisto no banco;
            await _productContext.SaveChangesAsync();

            //retorno do produto
            return product;
        }
    }
}
