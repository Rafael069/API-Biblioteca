using Biblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Persistence.Configurations
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            // Configurar chave primária para Emprestimo
            builder
                .HasKey(e => e.Id);


            // Configurar relacionamento entre Livro e Emprestimo
            builder
                .HasOne(e => e.Livro)
                .WithMany(l => l.Emprestimos)
                .HasForeignKey(e => e.LivroId)
                .OnDelete(DeleteBehavior.Restrict); // Configurar comportamento de deleção


            // Configurar relacionamento entre Usuario e Emprestimo
            builder
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Emprestimos)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); // Configurar comportamento de deleção
        }
    }
}
