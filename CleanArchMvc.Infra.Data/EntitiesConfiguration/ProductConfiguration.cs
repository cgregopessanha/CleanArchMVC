using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Usando recursos da Fluent API:

            //Essas configurações se dão pelo fato do EF sempre gerar um tipo de dado string como nvarchar(max) e permitindo nulo
            //O tipo de dado decimal, por padrão no EF, será uma coluna do tipo decimal(18,2);

            builder.HasKey(t => t.Id);

            //Todas as Propriedades do tipo string (Definindo tamanho Máximo):
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

            //Propriedade do Decimal (Definido presição):
            builder.Property(p => p.Price).HasPrecision(10, 2);

            //Configurando o relacionamento Um para Muitos (Uma Categoria pode ter muitos Produtos):
            builder.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId);

        }
    }
}
