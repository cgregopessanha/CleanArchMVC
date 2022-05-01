using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    /// <summary>
    /// IMPLEMENTAÇÃO DO REPOSITÓRIO CONCRETO DE CATEGORIAS
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        //Representando o contexto da Categoria para poder ser usada nas operações;
        ApplicationDbContext _categoryContext;

        //Construtor com Injeção de Dependência;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;  
        }

        public async Task<Category> Create(Category category)
        {
            //Adicionando Uma Categoria no contexto;
            _categoryContext.Add(category);

            //Persistindo as informações no BANCO;
            await _categoryContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> GetById(int? id)
        {
            //Busca na Tabela Categories através do Id;
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            //Retorna Uma lista de Categorias;
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> Remove(Category category)
        {
            //Removo a categoria do contexto;
            _categoryContext.Remove(category);

            //Persisto no BANCO
            await _categoryContext.SaveChangesAsync();
            
            //Retorno da categoria
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            //Atualiza a categoria no contexto;
            _categoryContext.Update(category);

            //Persiste no BANCO;
            await _categoryContext.SaveChangesAsync();

            //retorna a categoria;
            return category;
        }
    }
}
