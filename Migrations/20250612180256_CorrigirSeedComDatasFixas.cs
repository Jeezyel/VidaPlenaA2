using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HOSPISIM.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirSeedComDatasFixas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000067"), "Cardiologia" },
                    { new Guid("00000000-0000-0000-0000-000000000077"), "Gastroenterologia" },
                    { new Guid("00000000-0000-0000-0000-000000000083"), "Cardiologia" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Ortopedia" },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "Endocrinologia" },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "Cardiologia" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Clínica Geral" },
                    { new Guid("40000000-0000-0000-0000-000000000003"), "Dermatologia" },
                    { new Guid("55555555-0000-0000-0000-666666666666"), "Cardiologia" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Neurologia" }
                });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "CPF", "DataNascimento", "Email", "EnderecoCompleto", "EstadoCivil", "NomeCompleto", "NumeroCartaoSUS", "PossuiPlanoSaude", "Sexo", "Telefone", "TipoSanguineo" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000065"), "789.123.456-00", new DateTime(1988, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana.lima@example.com", "Rua dos Andradas, 789, Curitiba - PR", "Viúva", "Ana Beatriz Lima", "456789123456789", true, "Feminino", "(41) 99988-1122", "B-" },
                    { new Guid("00000000-0000-0000-0000-000000000075"), "987.654.321-99", new DateTime(1975, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.p.souza@example.com", "Rua Alvorada, 150, São Paulo - SP", "Divorciado", "João Pedro Souza", "321987654321987", true, "Masculino", "(11) 91123-4567", "O+" },
                    { new Guid("00000000-0000-0000-0000-000000000081"), "123.321.456-77", new DateTime(1982, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "leticia.ferreira@example.com", "Rua das Laranjeiras, 222, Curitiba - PR", "Viúva", "Letícia Ramos Ferreira", "556644332211009", true, "Feminino", "(41) 99876-1122", "B-" },
                    { new Guid("10000000-0000-0000-0000-000000000001"), "213.546.789-55", new DateTime(1977, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "bruno.dias@example.com", "Rua das Palmeiras, 999, São Paulo - SP", "Divorciado", "Bruno Henrique Dias", "112233445566778", false, "Masculino", "(11) 98877-6655", "AB+" },
                    { new Guid("11110000-0000-0000-0000-222222222222"), "123.456.789-01", new DateTime(1985, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana.rocha@example.com", "Rua das Flores, 789, São Paulo - SP", "Solteira", "Ana Beatriz Rocha", "123456789123456", true, "Feminino", "(11) 91234-5678", "O-" },
                    { new Guid("11111111-1111-1111-1111-111111111111"), "123.456.789-00", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.santos@example.com", "Rua das Flores, 123, São Paulo - SP", "Solteira", "Maria dos Santos", "123456789012345", true, "Feminino", "(11) 98765-4321", "O+" },
                    { new Guid("20000000-0000-0000-0000-000000000001"), "876.543.210-09", new DateTime(1982, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "luciana.ferreira@example.com", "Rua Sete de Setembro, 100, Curitiba - PR", "Viúva", "Luciana Marques Ferreira", "778899001122334", true, "Feminino", "(41) 98564-1122", "O-" },
                    { new Guid("30000000-0000-0000-0000-000000000001"), "234.567.890-10", new DateTime(1975, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "henrique.santos@example.com", "Rua da Paz, 789, Fortaleza - CE", "Divorciado", "Henrique Tavares dos Santos", "445566778899000", true, "Masculino", "(85) 99888-1122", "AB+" },
                    { new Guid("40000000-0000-0000-0000-000000000001"), "321.123.456-78", new DateTime(1985, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "luciana.rocha@example.com", "SHN Quadra 5, Bloco C, Brasília - DF", "Solteira", "Luciana Mendes Rocha", "889900112233445", true, "Feminino", "(61) 99123-4567", "O-" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "321.654.987-00", new DateTime(1990, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos.silva@example.com", "Avenida Central, 456, Rio de Janeiro - RJ", "Casado", "Carlos Silva", "987654321098765", false, "Masculino", "(21) 99876-5432", "A+" }
                });

            migrationBuilder.InsertData(
                table: "ProfissionaisSaude",
                columns: new[] { "Id", "Ativo", "CPF", "CargaHorariaSemanal", "DataAdmissao", "Email", "EspecialidadeId", "NomeCompleto", "RegistroConselho", "Telefone", "TipoRegistro", "Turno" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000068"), true, "654.321.987-00", 36, new DateTime(2016, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcelo.farias@example.com", new Guid("00000000-0000-0000-0000-000000000067"), "Dr. Marcelo Farias", "CRM789456", "(51) 91234-5678", "CRM", "Integral" },
                    { new Guid("00000000-0000-0000-0000-000000000078"), true, "321.987.654-11", 40, new DateTime(2019, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "camila.andrade@example.com", new Guid("00000000-0000-0000-0000-000000000077"), "Dra. Camila Andrade", "CRM123789", "(21) 93456-7890", "CRM", "Manhã" },
                    { new Guid("00000000-0000-0000-0000-000000000084"), true, "789.456.123-33", 20, new DateTime(2016, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcelo.tavares@example.com", new Guid("00000000-0000-0000-0000-000000000083"), "Dr. Marcelo Tavares", "CRM998877", "(61) 98765-4321", "CRM", "Noite" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), true, "654.987.321-00", 44, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "renan.oliveira@example.com", new Guid("10000000-0000-0000-0000-000000000003"), "Dr. Renan Oliveira", "CRM443322", "(11) 97654-3210", "CRM", "Integral" },
                    { new Guid("20000000-0000-0000-0000-000000000004"), true, "321.654.987-11", 36, new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "camila.prado@example.com", new Guid("20000000-0000-0000-0000-000000000003"), "Dra. Camila Prado", "CRM998877", "(41) 97777-1234", "CRM", "Manhã" },
                    { new Guid("30000000-0000-0000-0000-000000000004"), true, "567.123.890-22", 40, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.nogueira@example.com", new Guid("30000000-0000-0000-0000-000000000003"), "Dr. João Marcelo Nogueira", "CRM112233", "(85) 99666-4455", "CRM", "Integral" },
                    { new Guid("40000000-0000-0000-0000-000000000004"), true, "654.321.987-00", 24, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "fernanda.albuquerque@example.com", new Guid("40000000-0000-0000-0000-000000000003"), "Dra. Fernanda Albuquerque", "CRM998877", "(61) 99887-6655", "CRM", "Manhã" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), true, "987.654.321-00", 40, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.oliveira@example.com", new Guid("33333333-3333-3333-3333-333333333333"), "Dr. João Oliveira", "CRM123456", "(11) 91234-5678", "CRM", "Manhã" },
                    { new Guid("77777777-0000-0000-0000-888888888888"), true, "987.654.321-00", 40, new DateTime(2016, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcos.pereira@example.com", new Guid("55555555-0000-0000-0000-666666666666"), "Dr. Marcos Pereira", "CRM987654", "(21) 92345-6789", "CRM", "Manhã" },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), true, "456.789.123-00", 30, new DateTime(2018, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "helena.costa@example.com", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Dra. Helena Costa", "CRM654321", "(31) 92345-6789", "CRM", "Tarde" }
                });

            migrationBuilder.InsertData(
                table: "Prontuarios",
                columns: new[] { "Id", "DataAbertura", "NumeroProntuario", "ObservacoesGerais", "PacienteId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000066"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR789456", "Paciente com histórico de arritmia cardíaca.", new Guid("00000000-0000-0000-0000-000000000065") },
                    { new Guid("00000000-0000-0000-0000-000000000076"), new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR123987", "Paciente apresenta episódios frequentes de refluxo gástrico.", new Guid("00000000-0000-0000-0000-000000000075") },
                    { new Guid("00000000-0000-0000-0000-000000000082"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR789123", "Histórico de hipertensão e episódios de taquicardia.", new Guid("00000000-0000-0000-0000-000000000081") },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR123999", "Fratura recente no tornozelo direito. Histórico de osteoporose.", new Guid("10000000-0000-0000-0000-000000000001") },
                    { new Guid("20000000-0000-0000-0000-000000000002"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR789456", "Diabetes tipo 2 diagnosticado em 2020.", new Guid("20000000-0000-0000-0000-000000000001") },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR123456", "Paciente com histórico de hipertensão.", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR2023123", "Histórico de hipertensão e sedentarismo.", new Guid("30000000-0000-0000-0000-000000000001") },
                    { new Guid("33333333-0000-0000-0000-444444444444"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR987654", "Paciente com histórico de hipertensão.", new Guid("11110000-0000-0000-0000-222222222222") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR2024123", "Paciente com histórico de dermatite atópica.", new Guid("40000000-0000-0000-0000-000000000001") },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR654321", "Paciente com histórico de enxaqueca crônica.", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") }
                });

            migrationBuilder.InsertData(
                table: "Atendimentos",
                columns: new[] { "Id", "DataHora", "Local", "PacienteId", "ProfissionalId", "ProntuarioId", "Status", "Tipo" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000069"), new DateTime(2025, 1, 18, 9, 45, 0, 0, DateTimeKind.Unspecified), "Ambulatório Cardiologia", new Guid("00000000-0000-0000-0000-000000000065"), new Guid("00000000-0000-0000-0000-000000000068"), new Guid("00000000-0000-0000-0000-000000000066"), "Em andamento", "Retorno" },
                    { new Guid("00000000-0000-0000-0000-000000000079"), new DateTime(2025, 2, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "Clínica de Especialidades, Sala 7", new Guid("00000000-0000-0000-0000-000000000075"), new Guid("00000000-0000-0000-0000-000000000078"), new Guid("00000000-0000-0000-0000-000000000076"), "Finalizado", "Consulta" },
                    { new Guid("00000000-0000-0000-0000-000000000085"), new DateTime(2025, 3, 15, 19, 45, 0, 0, DateTimeKind.Unspecified), "Pronto Atendimento 24h - Cardiologia", new Guid("00000000-0000-0000-0000-000000000081"), new Guid("00000000-0000-0000-0000-000000000084"), new Guid("00000000-0000-0000-0000-000000000082"), "Encaminhado", "Emergência" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2025, 4, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), "Ambulatório Ortopedia - Sala 12", new Guid("10000000-0000-0000-0000-000000000001"), new Guid("10000000-0000-0000-0000-000000000004"), new Guid("10000000-0000-0000-0000-000000000002"), "Realizado", "Consulta Pós-Cirúrgica" },
                    { new Guid("20000000-0000-0000-0000-000000000005"), new DateTime(2025, 5, 15, 8, 45, 0, 0, DateTimeKind.Unspecified), "Consultório Endocrinologia - Sala 02", new Guid("20000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000002"), "Realizado", "Consulta de Rotina" },
                    { new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2025, 3, 10, 9, 15, 0, 0, DateTimeKind.Unspecified), "Clínica Cardiológica - Sala 1", new Guid("30000000-0000-0000-0000-000000000001"), new Guid("30000000-0000-0000-0000-000000000004"), new Guid("30000000-0000-0000-0000-000000000002"), "Realizado", "Consulta de Especialidade" },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new DateTime(2025, 5, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), "Ambulatório - Sala 4", new Guid("40000000-0000-0000-0000-000000000001"), new Guid("40000000-0000-0000-0000-000000000004"), new Guid("40000000-0000-0000-0000-000000000002"), "Realizado", "Consulta Dermatológica" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 6, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Sala 01", new Guid("11111111-1111-1111-1111-111111111111"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("22222222-2222-2222-2222-222222222222"), "Realizado", "Consulta" },
                    { new Guid("99999999-0000-0000-0000-000000000000"), new DateTime(2024, 12, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Consultório 12", new Guid("11111111-1111-1111-1111-111111111111"), new Guid("77777777-0000-0000-0000-888888888888"), new Guid("33333333-0000-0000-0000-444444444444"), "Concluído", "Exame" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2024, 11, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), "Consultório 03", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Agendado", "Consulta" }
                });

            migrationBuilder.InsertData(
                table: "Exames",
                columns: new[] { "Id", "AtendimentoId", "DataRealizacao", "DataSolicitacao", "Resultado", "Tipo" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000006b"), new Guid("00000000-0000-0000-0000-000000000069"), new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Presença de arritmia leve", "Eletrocardiograma" },
                    { new Guid("00000000-0000-0000-0000-00000000007b"), new Guid("00000000-0000-0000-0000-000000000079"), new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Presença de esofagite grau A", "Endoscopia Digestiva" },
                    { new Guid("00000000-0000-0000-0000-000000000087"), new Guid("00000000-0000-0000-0000-000000000085"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taquicardia sinusal detectada", "Eletrocardiograma" },
                    { new Guid("10000000-0000-0000-0000-000000000007"), new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consolidação óssea adequada.", "Raio-X do Tornozelo" },
                    { new Guid("11111111-2222-3333-4444-555566667777"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sem alterações significativas", "Ressonância Magnética" },
                    { new Guid("20000000-0000-0000-0000-000000000007"), new Guid("20000000-0000-0000-0000-000000000005"), new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "6.9% - dentro da meta para controle glicêmico.", "Hemoglobina Glicada" },
                    { new Guid("30000000-0000-0000-0000-000000000007"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ritmo sinusal, sem anormalidades detectadas", "Eletrocardiograma" },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new Guid("40000000-0000-0000-0000-000000000005"), new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compatível com eczema crônico", "Biópsia de pele" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 6, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), "Dentro dos parâmetros normais", "Hemograma" },
                    { new Guid("bbbbbbbb-0000-0000-0000-000000000000"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alterações leves no fígado", "Ultrassonografia" }
                });

            migrationBuilder.InsertData(
                table: "Internacoes",
                columns: new[] { "Id", "AtendimentoId", "DataEntrada", "Leito", "MotivoInternacao", "ObservacoesClinicas", "PacienteId", "PlanoSaudeUtilizado", "PrevisaoAlta", "Quarto", "Setor", "StatusInternacao" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000006c"), new Guid("00000000-0000-0000-0000-000000000069"), new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "22C", "Avaliação cardíaca intensiva", "Paciente sob cuidados cardíacos contínuos.", new Guid("00000000-0000-0000-0000-000000000065"), "Amil", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "204", "Cardiologia", "Em observação" },
                    { new Guid("00000000-0000-0000-0000-00000000007c"), new Guid("00000000-0000-0000-0000-000000000079"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "12B", "Exames e acompanhamento de distúrbios gastrointestinais", "Paciente sob dieta controlada e monitoramento.", new Guid("00000000-0000-0000-0000-000000000075"), "Bradesco Saúde", new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "310", "Gastroenterologia", "Concluída" },
                    { new Guid("00000000-0000-0000-0000-000000000088"), new Guid("00000000-0000-0000-0000-000000000085"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "08C", "Controle e estabilização de quadro cardíaco", "Paciente com bom prognóstico após estabilização.", new Guid("00000000-0000-0000-0000-000000000081"), "Unimed", new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "205", "Cardiologia", "Alta concedida" },
                    { new Guid("10000000-0000-0000-0000-000000000008"), new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "04B", "Cirurgia de reconstrução óssea do tornozelo", "Paciente respondeu bem à cirurgia e iniciou fisioterapia.", new Guid("10000000-0000-0000-0000-000000000001"), "SUS", new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "107", "Ortopedia", "Alta concedida" },
                    { new Guid("20000000-0000-0000-0000-000000000008"), new Guid("20000000-0000-0000-0000-000000000005"), new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "12C", "Descompensação glicêmica aguda", "Paciente respondeu bem à insulinoterapia.", new Guid("20000000-0000-0000-0000-000000000001"), "Amil Saúde", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "204", "Clínica Médica", "Alta concedida" },
                    { new Guid("27777777-0000-0000-0000-111111111111"), new Guid("99999999-0000-0000-0000-000000000000"), new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "10B", "Infecção respiratória", "Paciente em tratamento com antibióticos.", new Guid("11110000-0000-0000-0000-222222222222"), "Unimed", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "205", "Clinico", "Concluído" },
                    { new Guid("30000000-0000-0000-0000-000000000008"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "06B", "Pico hipertensivo com cefaleia intensa", "Paciente estabilizado após controle da pressão arterial.", new Guid("30000000-0000-0000-0000-000000000001"), "Bradesco Saúde", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "110", "Cardiologia", "Alta concedida" },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new Guid("40000000-0000-0000-0000-000000000005"), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12C", "Infecção secundária em lesão dermatológica", "Lesões extensas com sinais de infecção bacteriana.", new Guid("40000000-0000-0000-0000-000000000001"), "Unimed", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "207", "Clínica Médica", "Alta concedida" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "12B", "Pneumonia", "Paciente responde bem ao tratamento.", new Guid("11111111-1111-1111-1111-111111111111"), "Unimed", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "301", "Clínico", "Ativo" },
                    { new Guid("88888888-9999-aaaa-bbbb-ccccdddddddd"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "05A", "Crise convulsiva", "Paciente em observação contínua.", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Particular", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "102", "Neurologia", "Ativo" }
                });

            migrationBuilder.InsertData(
                table: "Prescricoes",
                columns: new[] { "Id", "AtendimentoId", "DataFim", "DataInicio", "Dosagem", "Frequencia", "Medicamento", "Observacoes", "ProfissionalId", "ReacoesAdversas", "StatusPrescricao", "ViaAdministracao" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000006a"), new Guid("00000000-0000-0000-0000-000000000069"), null, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "50mg", "1x ao dia", "Losartana", "Manter monitoramento da pressão arterial", new Guid("00000000-0000-0000-0000-000000000068"), null, "Ativa", "Oral" },
                    { new Guid("00000000-0000-0000-0000-00000000007a"), new Guid("00000000-0000-0000-0000-000000000079"), null, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "20mg", "Antes do café da manhã", "Omeprazol", "Reavaliar após 30 dias de uso contínuo", new Guid("00000000-0000-0000-0000-000000000078"), null, "Finalizada", "Oral" },
                    { new Guid("00000000-0000-0000-0000-000000000086"), new Guid("00000000-0000-0000-0000-000000000085"), null, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "50mg", "1 vez ao dia", "Atenolol", "Reavaliar em 7 dias com novo eletrocardiograma", new Guid("00000000-0000-0000-0000-000000000084"), null, "Em uso", "Oral" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), new Guid("10000000-0000-0000-0000-000000000005"), null, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "1g", "8/8h", "Dipirona Sódica", "Suspender após 7 dias, se não houver dor.", new Guid("10000000-0000-0000-0000-000000000004"), null, "Encerrada", "Oral" },
                    { new Guid("20000000-0000-0000-0000-000000000006"), new Guid("20000000-0000-0000-0000-000000000005"), null, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "850mg", "2x ao dia", "Metformina", "Tomar após as principais refeições", new Guid("20000000-0000-0000-0000-000000000004"), null, "Em uso", "Oral" },
                    { new Guid("30000000-0000-0000-0000-000000000006"), new Guid("30000000-0000-0000-0000-000000000005"), null, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "50mg", "1x ao dia", "Losartana", "Preferencialmente pela manhã", new Guid("30000000-0000-0000-0000-000000000004"), null, "Em uso", "Oral" },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new Guid("40000000-0000-0000-0000-000000000005"), null, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "1%", "2x ao dia", "Pomada de Hidrocortisona", "Aplicar nas áreas afetadas após limpeza da pele", new Guid("40000000-0000-0000-0000-000000000004"), null, "Em uso", "Tópica" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("55555555-5555-5555-5555-555555555555"), null, new DateTime(2024, 6, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "500mg", "8/8h", "Paracetamol", "Tomar após as refeições", new Guid("44444444-4444-4444-4444-444444444444"), null, "Ativa", "Oral" },
                    { new Guid("aaaaaaaa-0000-0000-0000-000000000000"), new Guid("99999999-0000-0000-0000-000000000000"), null, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "50mg", "12/12h", "Losartana", "Tomar após o almoço", new Guid("77777777-0000-0000-0000-888888888888"), null, "Pendente", "Oral" },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), null, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "400mg", "12/12h", "Ibuprofeno", "Tomar em caso de dor intensa", new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), null, "Pendente", "Oral" }
                });

            migrationBuilder.InsertData(
                table: "AltasHospitalares",
                columns: new[] { "Id", "CondicaoPaciente", "Data", "InstrucoesPosAlta", "InternacaoId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000006d"), "Estável com necessidade de acompanhamento", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consultar cardiologista mensalmente e manter dieta hipossódica.", new Guid("00000000-0000-0000-0000-00000000006c") },
                    { new Guid("00000000-0000-0000-0000-00000000007d"), "Boa, com controle da sintomatologia", new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evitar alimentos ácidos e condimentados; manter uso de medicação conforme prescrito.", new Guid("00000000-0000-0000-0000-00000000007c") },
                    { new Guid("00000000-0000-0000-0000-000000000089"), "Estável, com pressão arterial controlada", new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evitar esforços físicos por 15 dias, manter consulta de retorno em 1 semana.", new Guid("00000000-0000-0000-0000-000000000088") },
                    { new Guid("10000000-0000-0000-0000-000000000009"), "Estável, com acompanhamento ambulatorial indicado", new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realizar sessões de fisioterapia, evitar carga no membro afetado.", new Guid("10000000-0000-0000-0000-000000000008") },
                    { new Guid("20000000-0000-0000-0000-000000000009"), "Estável com orientações para ajuste terapêutico domiciliar", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Continuar monitoramento domiciliar da glicose e retorno em 30 dias.", new Guid("20000000-0000-0000-0000-000000000008") },
                    { new Guid("30000000-0000-0000-0000-000000000009"), "Pressão controlada, orientação para reavaliação periódica", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aderir à medicação, controlar dieta e praticar atividades físicas leves.", new Guid("30000000-0000-0000-0000-000000000008") },
                    { new Guid("37777777-0000-0000-0000-222222222222"), "Estável", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retornar para consulta de acompanhamento em 15 dias.", new Guid("27777777-0000-0000-0000-111111111111") },
                    { new Guid("40000000-0000-0000-0000-000000000009"), "Melhora significativa", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manter tratamento dermatológico e retorno em 15 dias.", new Guid("40000000-0000-0000-0000-000000000008") },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Estável", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manter repouso por 7 dias e tomar antibióticos conforme prescrição.", new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("eeeeeeee-ffff-1111-2222-333344445555"), "Recuperado", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evitar atividades estressantes e seguir acompanhamento ambulatorial.", new Guid("88888888-9999-aaaa-bbbb-ccccdddddddd") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AltasHospitalares",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000006d"));

            migrationBuilder.DeleteData(
                table: "AltasHospitalares",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000007d"));

            migrationBuilder.DeleteData(
                table: "AltasHospitalares",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"));

            migrationBuilder.DeleteData(
                table: "AltasHospitalares",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "AltasHospitalares",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "AltasHospitalares",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "AltasHospitalares",
                keyColumn: "Id",
                keyValue: new Guid("37777777-0000-0000-0000-222222222222"));

            migrationBuilder.DeleteData(
                table: "AltasHospitalares",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "AltasHospitalares",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "AltasHospitalares",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-ffff-1111-2222-333344445555"));

            migrationBuilder.DeleteData(
                table: "Exames",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000006b"));

            migrationBuilder.DeleteData(
                table: "Exames",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000007b"));

            migrationBuilder.DeleteData(
                table: "Exames",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"));

            migrationBuilder.DeleteData(
                table: "Exames",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Exames",
                keyColumn: "Id",
                keyValue: new Guid("11111111-2222-3333-4444-555566667777"));

            migrationBuilder.DeleteData(
                table: "Exames",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Exames",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Exames",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Exames",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Exames",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000006a"));

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000007a"));

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"));

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Prescricoes",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "Internacoes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000006c"));

            migrationBuilder.DeleteData(
                table: "Internacoes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000007c"));

            migrationBuilder.DeleteData(
                table: "Internacoes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"));

            migrationBuilder.DeleteData(
                table: "Internacoes",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Internacoes",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Internacoes",
                keyColumn: "Id",
                keyValue: new Guid("27777777-0000-0000-0000-111111111111"));

            migrationBuilder.DeleteData(
                table: "Internacoes",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Internacoes",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Internacoes",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Internacoes",
                keyColumn: "Id",
                keyValue: new Guid("88888888-9999-aaaa-bbbb-ccccdddddddd"));

            migrationBuilder.DeleteData(
                table: "Atendimentos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"));

            migrationBuilder.DeleteData(
                table: "Atendimentos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"));

            migrationBuilder.DeleteData(
                table: "Atendimentos",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"));

            migrationBuilder.DeleteData(
                table: "Atendimentos",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Atendimentos",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Atendimentos",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Atendimentos",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Atendimentos",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Atendimentos",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Atendimentos",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "ProfissionaisSaude",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"));

            migrationBuilder.DeleteData(
                table: "ProfissionaisSaude",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"));

            migrationBuilder.DeleteData(
                table: "ProfissionaisSaude",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"));

            migrationBuilder.DeleteData(
                table: "ProfissionaisSaude",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "ProfissionaisSaude",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "ProfissionaisSaude",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "ProfissionaisSaude",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "ProfissionaisSaude",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "ProfissionaisSaude",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-888888888888"));

            migrationBuilder.DeleteData(
                table: "ProfissionaisSaude",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"));

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"));

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"));

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-444444444444"));

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("55555555-0000-0000-0000-666666666666"));

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"));

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"));

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"));

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: new Guid("11110000-0000-0000-0000-222222222222"));

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));
        }
    }
}
