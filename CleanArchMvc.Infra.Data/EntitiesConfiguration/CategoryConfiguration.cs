using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Usando recursos da Fluent API:

            //Essas configurações se dão pelo fato do EF sempre gerar um tipo de dado string como nvarchar(max) e permitindo nulo
            //O tipo de dado decimal, por padrão no EF, será uma coluna do tipo decimal(18,2);

            //Aqui estou dizendo que esta propriedade será a chave primária da tabela;
            builder.HasKey(t => t.Id);

            //Aqui eu estou dizendo que a propriedade Nome terá um máximo de 100 caracteres e será not null;
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            //Inclusão de Algumas categorias:
            builder.HasData
                (
                    new Category(1, "Material Escolar"),
                    new Category(2, "Eletrônicos"),
                    new Category(3, "Acessórios")
                );

        }
    }
}
