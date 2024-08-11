using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryphon.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade_Estado_EstadoId",
                table: "Cidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Cidade_CidadeId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Enderecos_EnderecoId",
                table: "Processos");

            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Status_StatusId",
                table: "Processos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estado",
                table: "Estado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade");

            migrationBuilder.RenameTable(
                name: "Estado",
                newName: "Estados");

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
                name: "IX_Processos_StatusId",
                table: "Processos",
                newName: "IX_Processos_StatusId1");

            migrationBuilder.RenameIndex(
                name: "IX_Processos_EnderecoId",
                table: "Processos",
                newName: "IX_Processos_EnderecoId1");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Cidades",
                newName: "EstadoId1");

            migrationBuilder.RenameIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidades",
                newName: "IX_Cidades_EstadoId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estados",
                table: "Estados",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PK_Estados",
                table: "Estados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidades",
                table: "Cidades");

            migrationBuilder.RenameTable(
                name: "Estados",
                newName: "Estado");

            migrationBuilder.RenameTable(
                name: "Cidades",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "StatusId1",
                table: "Processos",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "EnderecoId1",
                table: "Processos",
                newName: "EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Processos_StatusId1",
                table: "Processos",
                newName: "IX_Processos_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Processos_EnderecoId1",
                table: "Processos",
                newName: "IX_Processos_EnderecoId");

            migrationBuilder.RenameColumn(
                name: "EstadoId1",
                table: "Cidade",
                newName: "EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cidades_EstadoId1",
                table: "Cidade",
                newName: "IX_Cidade_EstadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estado",
                table: "Estado",
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
                name: "FK_Enderecos_Cidade_CidadeId",
                table: "Enderecos",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Enderecos_EnderecoId",
                table: "Processos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Status_StatusId",
                table: "Processos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
