using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thomas.Business.Models;

namespace Thomas.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Contato)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasMany(f => f.Chamados)
                .WithOne(c => c.Fornecedor)
                .HasForeignKey(c => c.FornecedorId);

            builder.ToTable("Fornecedores");

        }
    }
}
