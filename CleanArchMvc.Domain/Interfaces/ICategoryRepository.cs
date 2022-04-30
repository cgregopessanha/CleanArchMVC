using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    //A implementação dessa interface será implementada na classe concreta na camada de Infra
    //AS Operações serão Assíncronas usando o TASK;
    public interface ICategoryRepository
    {
        /// <summary>
        /// CONTRATO DA INTERFACE QUE DEVERÁ SER IMPLEMENTADO NA CLASSE CONCRETA!
        /// </summary>
        /// <returns></returns>
        /// 

        //Obter uma lista com todas as categorias;
        Task <IEnumerable<Category>> GetCategories();

        //Obter uma Categoria pelo Id;
        Task<Category> GetById(int? id);

        //Criar uma Categoria;
        Task<Category> Create(Category category);

        //Atualizar uma Categoria;
        Task<Category> Update(Category category);

        //Remover uma Categoria;
        Task<Category> Remove(Category category);
    }
}
