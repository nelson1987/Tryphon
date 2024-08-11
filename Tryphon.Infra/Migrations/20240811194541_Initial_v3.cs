using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryphon.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_EstadoId1",
                table: "Cidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Cidades_CidadeId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Enderecos_EnderecoId1",
                table: "Processos");

            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Status_StatusId1",
                table: "Processos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processos",
                table: "Processos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estados",
                table: "Estados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidades",
                table: "Cidades");

            migrationBuilder.RenameTable(
                name: "Processos",
                newName: "Processo");

            migrationBuilder.RenameTable(
                name: "Estados",
                newName: "Estado");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "Cidades",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "StatusId1",
                table: "Processo",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "EnderecoId1",
                table: "Processo",
                newName: "EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Processos_StatusId1",
                table: "Processo",
                newName: "IX_Processo_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Processos_EnderecoId1",
                table: "Processo",
                newName: "IX_Processo_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_CidadeId",
                table: "Endereco",
                newName: "IX_Endereco_CidadeId");

            migrationBuilder.RenameColumn(
                name: "EstadoId1",
                table: "Cidade",
                newName: "EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cidades_EstadoId1",
                table: "Cidade",
                newName: "IX_Cidade_EstadoId");

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Status",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Processo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processo",
                table: "Processo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estado",
                table: "Estado",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade_Estado_EstadoId",
                table: "Cidade",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cidade_CidadeId",
                table: "Endereco",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Endereco_EnderecoId",
                table: "Processo",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Status_StatusId",
                table: "Processo",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade_Estado_EstadoId",
                table: "Cidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cidade_CidadeId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Endereco_EnderecoId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Status_StatusId",
                table: "Processo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processo",
                table: "Processo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estado",
                table: "Estado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade");

            migrationBuilder.RenameTable(
                name: "Processo",
                newName: "Processos");

            migrationBuilder.RenameTable(
                name: "Estado",
                newName: "Estados");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Cidade",
                newName: "Cidades");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Processos",
                newName: "StatusId1");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Processos",
                newName: "EnderecoId1");

            migrationBuilder.RenameIndex(
                name: "IX_Processo_StatusId",
                table: "Processos",
                newName: "IX_Processos_StatusId1");

            migrationBuilder.RenameIndex(
                name: "IX_Processo_EnderecoId",
                table: "Processos",
                newName: "IX_Processos_EnderecoId1");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_CidadeId",
                table: "Enderecos",
                newName: "IX_Enderecos_CidadeId");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Cidades",
                newName: "EstadoId1");

            migrationBuilder.RenameIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidades",
                newName: "IX_Cidades_EstadoId1");

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Processos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processos",
                table: "Processos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estados",
                table: "Estados",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cidades",
                table: "Cidades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_EstadoId1",
                table: "Cidades",
                column: "EstadoId1",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Cidades_CidadeId",
                table: "Enderecos",
                column: "CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Enderecos_EnderecoId1",
                table: "Processos",
                column: "EnderecoId1",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Status_StatusId1",
                table: "Processos",
                column: "StatusId1",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
