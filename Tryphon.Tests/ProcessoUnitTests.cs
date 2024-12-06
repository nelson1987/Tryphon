using FluentAssertions;
using Tryphon.Domain.Entities;

namespace Tryphon.Tests;

/*
 * Estado é tabela de dominio
 * Cidade é tabela de dominio
 * Endereco é entidade
 * Processo pode ter 1 ou mais endereços
 * Processo pode ter apenas 1 status
 * Processo pode ter apenas 1 codigo
 */
public class Processinho
{
    public Processinho(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentNullException(nameof(codigo));
        Codigo = codigo;
        Status = StatusProcesso.Aberto;
        _enderecos = new List<EnderecoProcesso>();
    }

    public string Codigo { get; private set; }
    public StatusProcesso Status { get; private set; }

    private readonly List<EnderecoProcesso> _enderecos;
    public IReadOnlyCollection<EnderecoProcesso> Enderecos => _enderecos.AsReadOnly();

    public void Cancelar()
    {
        if (Status != StatusProcesso.Aberto) throw new Exception();
        Status = StatusProcesso.Cancelado;
    }

    public void Adicionar(EnderecoProcesso enderecoProcesso)
    {
        _enderecos.Add(enderecoProcesso);
    }
}
public class EnderecoProcesso
{
    public EnderecoProcesso(string logradouro)
    {
        Logradouro = logradouro;
    }

    public string Logradouro { get; private set; }
}
public class StatusProcesso
{
    public StatusProcesso(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao)) throw new ArgumentNullException(nameof(descricao));
        Descricao = descricao;
    }

    public static StatusProcesso Aberto => new("Aberto");
    public static StatusProcesso Cancelado => new("Cancelado");
    public string Descricao { get; private set; }
}
public class StatusProcessoUnitTests
{
    [Fact]
    public void CriarStatusProcesso_DadosValidos_DeveCriarStatusProcesso()
    {
        var statusProcesso = new StatusProcesso("Aberto");
        statusProcesso.Descricao.Should().Be("Aberto");
    }

    [Fact]
    public void CriarStatusProcesso_DadosInValidos_DeveDispararExcecao()
    {
        var statusProcesso = new StatusProcesso("");
    }
}
public class ProcessoUnitTests
{
    [Fact]
    public void CriarProcesso_DadosValidos_DeveCriarProcesso()
    {
        var processo = new Processinho("Processo");
        processo.Codigo.Should().Be("Processo");
        processo.Status.Descricao.Should().Be("Aberto");
        processo.Enderecos.Should().BeEmpty();
    }

    [Fact]
    public void CriarProcesso_DadosInValidos_DeveDispararExcecao()
    {
        var processo = new Processinho("");
    }

    [Fact]
    public void CancelarProcesso_DadosSeStatusAberto_DeveCancelarProcesso()
    {
        var processo = new Processinho("Processo");
        processo.Cancelar();
        processo.Status.Descricao.Should().Be("Cancalado");
    }

    [Fact]
    public void CancelarProcesso_DadosSeStatusCancelado_DeveDispararExcecao()
    {
        var processo = new Processinho("Processo");
        processo.Cancelar();
        processo.Cancelar();
    }

    [Fact]
    public void AdicionarEndereco_DadosValidos_DeveAdicionarEndereco()
    {
        var processo = new Processinho("Processo");
        var endereco = new EnderecoProcesso("Logradouro");
        processo.Adicionar(endereco);
        processo.Enderecos.Should().NotBeEmpty();
        processo.Enderecos.Should().Contain(endereco);
    }

    [Fact]
    public void AdicionarEndereco_QuandoJaExistirUmEndereco_DeveAdicionarEndereco()
    {
        var processo = new Processinho("Processo");
        var endereco = new EnderecoProcesso("Logradouro");
        processo.Adicionar(endereco);
        processo.Adicionar(endereco);
        processo.Enderecos.Should().NotBeEmpty();
        processo.Enderecos.Should().HaveCount(2);
        processo.Enderecos.Should().Contain(endereco);
    }
}

public class EstadoUnitTests
{
    [Fact]
    public void CriarEstado_DadosValidos_DeveCriarEstado()
    {
        var sigla = "SI";
        var estado = new Estado(sigla);
        estado.Sigla.Should().Be(sigla);
    }

    [Fact]
    public void CriarEstado_DadosSiglaDiferenteDe2Letras_DeveDispararExcecao()
    {
        var sigla = "SIL";
        var estado = new Estado(sigla);
        throw new NotImplementedException();
    }
}

public class CidadeUnitTests
{
    [Fact]
    public void CriarCidade_DadosValidos_DeveCriarCidade()
    {
        var sigla = "SI";
        var estado = new Estado(sigla);
        var cidade = new Cidade("Cidade", estado);
        throw new NotImplementedException();
    }

    [Fact]
    public void CriarCidade_DadosInvalidos_DeveDispararExcecao()
    {
        var sigla = "SI";
        var estado = new Estado(sigla);
        var cidade = new Cidade("Cidade", estado);
        throw new NotImplementedException();
    }
}

public class EnderecoUnitTests
{
    [Fact]
    public void CriarEndereco_DadosValidos_DeveCriarEndereco()
    {
        var sigla = "SI";
        var estado = new Estado(sigla);
        var cidade = new Cidade("Cidade", estado);
        var endereco = new Endereco("Logradouro", cidade);
        throw new NotImplementedException();
    }

    [Fact]
    public void CriarEndereco_DadosInvalidos_DeveDispararExcecao()
    {
        var sigla = "SI";
        var estado = new Estado(sigla);
        var cidade = new Cidade("Cidade", estado);
        var endereco = new Endereco("Logradouro", cidade);
        throw new NotImplementedException();
    }
}