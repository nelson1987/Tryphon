using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tryphon.Domain.Entities;

namespace Tryphon.Infra.Mappings;

public class StatusMapping : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable(nameof(Status));

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Sigla)
            .IsRequired(false);
    }
}

public class ProcessoMapping : IEntityTypeConfiguration<Processo>
{
    public void Configure(EntityTypeBuilder<Processo> builder)
    {
        builder.ToTable(nameof(Processo));

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Codigo)
            .IsRequired(false);

        builder
            .HasOne(x => x.Endereco)
            .WithMany(x => x.Processos);
        //.HasForeignKey(x => x.Endereco.Id);

        builder
            .HasOne(x => x.Status)
            .WithMany(x => x.Processos);
        //.HasForeignKey(x => x.Status.Id);
    }
}

public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable(nameof(Endereco));

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Logradouro)
            .IsRequired();

        builder
            .HasOne(x => x.Cidade)
            .WithMany(x => x.Enderecos);
        //.HasForeignKey(x => x.Cidade.Id)
        //.OnDelete(DeleteBehavior.Restrict);
    }
}

public class CidadeMapping : IEntityTypeConfiguration<Cidade>
{
    public void Configure(EntityTypeBuilder<Cidade> builder)
    {
        builder.ToTable(nameof(Cidade));

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Nome)
            .IsRequired();

        builder
            .HasOne(x => x.Estado)
            .WithMany(x => x.Cidades);
        //.HasForeignKey(x => x.Estado.Id)
        //.OnDelete(DeleteBehavior.Restrict);
    }
}

public class EstadoMapping : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable(nameof(Estado));

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Sigla)
            .IsRequired();
    }
}