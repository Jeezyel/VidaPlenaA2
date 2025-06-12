using HOSPISIM.Entities;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Persistence
{
    public class VidaPlenaDbContext : DbContext
    {
        public VidaPlenaDbContext(DbContextOptions<VidaPlenaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Prontuario> Prontuarios { get; set; }
        public DbSet<ProfissionalSaude> ProfissionaisSaude { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Prescricao> Prescricoes { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Internacao> Internacoes { get; set; }
        public DbSet<AltaHospitalar> AltasHospitalares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Paciente 1:N Prontuario
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.Prontuarios)
                .WithOne(pr => pr.Paciente)
                .HasForeignKey(pr => pr.PacienteId)
                .OnDelete(DeleteBehavior.Restrict); // ou ClientSetNull

            // Prontuario 1:N Atendimento
            modelBuilder.Entity<Prontuario>()
                .HasMany(pr => pr.Atendimentos)
                .WithOne(a => a.Prontuario)
                .HasForeignKey(a => a.ProntuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Profissional 1:N Atendimento
            modelBuilder.Entity<ProfissionalSaude>()
                .HasMany(p => p.Atendimentos)
                .WithOne(a => a.Profissional)
                .HasForeignKey(a => a.ProfissionalId)
                .OnDelete(DeleteBehavior.Restrict);

            // Atendimento 1:N Prescricao
            modelBuilder.Entity<Atendimento>()
                .HasMany(a => a.Prescricoes)
                .WithOne(pr => pr.Atendimento)
                .HasForeignKey(pr => pr.AtendimentoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Atendimento 1:N Exame
            modelBuilder.Entity<Atendimento>()
                .HasMany(a => a.Exames)
                .WithOne(e => e.Atendimento)
                .HasForeignKey(e => e.AtendimentoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Atendimento 0..1:1 Internacao
            modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.Internacao)
                .WithOne(i => i.Atendimento)
                .HasForeignKey<Internacao>(i => i.AtendimentoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Internacao 0..1:1 AltaHospitalar
            modelBuilder.Entity<Internacao>()
                .HasOne(i => i.AltaHospitalar)
                .WithOne(a => a.Internacao)
                .HasForeignKey<AltaHospitalar>(a => a.InternacaoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Profissional N:1 Especialidade
            modelBuilder.Entity<ProfissionalSaude>()
                .HasOne(p => p.Especialidade)
                .WithMany(e => e.Profissionais)
                .HasForeignKey(p => p.EspecialidadeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Exemplo de propriedade
            modelBuilder.Entity<Paciente>()
                .Property(p => p.Email)
                .IsRequired(false);



            //POVOANDO O BANCO DE DADOS

            // entrada 1
            var pacienteId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var prontuarioId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var especialidadeId = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var profissionalId = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var atendimentoId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var prescricaoId = Guid.Parse("66666666-6666-6666-6666-666666666666");
            var exameId = Guid.Parse("77777777-7777-7777-7777-777777777777");
            var internacaoId = Guid.Parse("88888888-8888-8888-8888-888888888888");
            var altaId = Guid.Parse("99999999-9999-9999-9999-999999999999");

            modelBuilder.Entity<Paciente>().HasData(new Paciente
            {
                Id = pacienteId,
                NomeCompleto = "Maria dos Santos",
                CPF = "123.456.789-00",
                DataNascimento = new DateTime(1985, 5, 10),
                Sexo = "Feminino",
                TipoSanguineo = "O+",
                Telefone = "(11) 98765-4321",
                Email = "maria.santos@example.com",
                EnderecoCompleto = "Rua das Flores, 123, São Paulo - SP",
                NumeroCartaoSUS = "123456789012345",
                EstadoCivil = "Solteira",
                PossuiPlanoSaude = true
            });

            modelBuilder.Entity<Especialidade>().HasData(new Especialidade
            {
                Id = especialidadeId,
                Nome = "Clínica Geral"
            });

            modelBuilder.Entity<ProfissionalSaude>().HasData(new ProfissionalSaude
            {
                Id = profissionalId,
                NomeCompleto = "Dr. João Oliveira",
                CPF = "987.654.321-00",
                Email = "joao.oliveira@example.com",
                Telefone = "(11) 91234-5678",
                RegistroConselho = "CRM123456",
                TipoRegistro = "CRM",
                EspecialidadeId = especialidadeId,
                DataAdmissao = new DateTime(2020, 1, 15),
                CargaHorariaSemanal = 40,
                Turno = "Manhã",
                Ativo = true
            });

            modelBuilder.Entity<Prontuario>().HasData(new Prontuario
            {
                Id = prontuarioId,
                NumeroProntuario = "PR123456",
                DataAbertura = new DateTime(2024, 1, 1),
                ObservacoesGerais = "Paciente com histórico de hipertensão.",
                PacienteId = pacienteId
            });

            modelBuilder.Entity<Atendimento>().HasData(new Atendimento
            {
                Id = atendimentoId,
                DataHora = new DateTime(2024, 6, 1, 14, 30, 0),
                Tipo = "Consulta",
                Status = "Realizado",
                Local = "Sala 01",
                PacienteId = pacienteId,
                ProfissionalId = profissionalId,
                ProntuarioId = prontuarioId
            });

            modelBuilder.Entity<Prescricao>().HasData(new Prescricao
            {
                Id = prescricaoId,
                AtendimentoId = atendimentoId,
                ProfissionalId = profissionalId,
                Medicamento = "Paracetamol",
                Dosagem = "500mg",
                Frequencia = "8/8h",
                ViaAdministracao = "Oral",
                DataInicio = new DateTime(2024, 6, 1, 14, 30, 0),
                StatusPrescricao = "Ativa",
                Observacoes = "Tomar após as refeições"
            });

            modelBuilder.Entity<Exame>().HasData(new Exame
            {
                Id = exameId,
                Tipo = "Hemograma",
                DataSolicitacao = new DateTime(2025, 5, 30, 14, 30, 0),
                DataRealizacao = new DateTime(2025, 6, 1, 14, 30, 0),
                Resultado = "Dentro dos parâmetros normais",
                AtendimentoId = atendimentoId
            });

            modelBuilder.Entity<Internacao>().HasData(new Internacao
            {
                Id = internacaoId,
                PacienteId = pacienteId,
                AtendimentoId = atendimentoId,
                DataEntrada = new DateTime(2025, 5, 27),
                PrevisaoAlta = new DateTime(2025, 5, 30),
                MotivoInternacao = "Pneumonia",
                Leito = "12B",
                Quarto = "301",
                Setor = "Clínico",
                PlanoSaudeUtilizado = "Unimed",
                ObservacoesClinicas = "Paciente responde bem ao tratamento.",
                StatusInternacao = "Ativo"
            });

            modelBuilder.Entity<AltaHospitalar>().HasData(new AltaHospitalar
            {
                Id = altaId,
                InternacaoId = internacaoId,
                Data = new DateTime(2025, 6, 1),
                CondicaoPaciente = "Estável",
                InstrucoesPosAlta = "Manter repouso por 7 dias e tomar antibióticos conforme prescrição."
            });

            // entrada 2 

            var pacienteId2 = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var prontuarioId2 = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
            var especialidadeId2 = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
            var profissionalId2 = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
            var atendimentoId2 = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");
            var prescricaoId2 = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");
            var exameId2 = Guid.Parse("11111111-2222-3333-4444-555566667777");
            var internacaoId2 = Guid.Parse("88888888-9999-aaaa-bbbb-ccccdddddddd");
            var altaId2 = Guid.Parse("eeeeeeee-ffff-1111-2222-333344445555");

            modelBuilder.Entity<Paciente>().HasData(new Paciente
            {
                Id = pacienteId2,
                NomeCompleto = "Carlos Silva",
                CPF = "321.654.987-00",
                DataNascimento = new DateTime(1990, 9, 15),
                Sexo = "Masculino",
                TipoSanguineo = "A+",
                Telefone = "(21) 99876-5432",
                Email = "carlos.silva@example.com",
                EnderecoCompleto = "Avenida Central, 456, Rio de Janeiro - RJ",
                NumeroCartaoSUS = "987654321098765",
                EstadoCivil = "Casado",
                PossuiPlanoSaude = false
            });

            modelBuilder.Entity<Especialidade>().HasData(new Especialidade
            {
                Id = especialidadeId2,
                Nome = "Neurologia"
            });

            modelBuilder.Entity<ProfissionalSaude>().HasData(new ProfissionalSaude
            {
                Id = profissionalId2,
                NomeCompleto = "Dra. Helena Costa",
                CPF = "456.789.123-00",
                Email = "helena.costa@example.com",
                Telefone = "(31) 92345-6789",
                RegistroConselho = "CRM654321",
                TipoRegistro = "CRM",
                EspecialidadeId = especialidadeId2,
                DataAdmissao = new DateTime(2018, 3, 10),
                CargaHorariaSemanal = 30,
                Turno = "Tarde",
                Ativo = true
            });

            modelBuilder.Entity<Prontuario>().HasData(new Prontuario
            {
                Id = prontuarioId2,
                NumeroProntuario = "PR654321",
                DataAbertura = new DateTime(2023, 6, 5),
                ObservacoesGerais = "Paciente com histórico de enxaqueca crônica.",
                PacienteId = pacienteId2
            });

            modelBuilder.Entity<Atendimento>().HasData(new Atendimento
            {
                Id = atendimentoId2,
                DataHora = new DateTime(2024, 11, 20, 14, 30, 0),
                Tipo = "Consulta",
                Status = "Agendado",
                Local = "Consultório 03",
                PacienteId = pacienteId2,
                ProfissionalId = profissionalId2,
                ProntuarioId = prontuarioId2
            });

            modelBuilder.Entity<Prescricao>().HasData(new Prescricao
            {
                Id = prescricaoId2,
                AtendimentoId = atendimentoId2,
                ProfissionalId = profissionalId2,
                Medicamento = "Ibuprofeno",
                Dosagem = "400mg",
                Frequencia = "12/12h",
                ViaAdministracao = "Oral",
                DataInicio = new DateTime(2024, 11, 20),
                StatusPrescricao = "Pendente",
                Observacoes = "Tomar em caso de dor intensa"
            });

            modelBuilder.Entity<Exame>().HasData(new Exame
            {
                Id = exameId2,
                Tipo = "Ressonância Magnética",
                DataSolicitacao = new DateTime(2024, 11, 19),
                DataRealizacao = new DateTime(2024, 11, 21),
                Resultado = "Sem alterações significativas",
                AtendimentoId = atendimentoId2
            });

            modelBuilder.Entity<Internacao>().HasData(new Internacao
            {
                Id = internacaoId2,
                PacienteId = pacienteId2,
                AtendimentoId = atendimentoId2,
                DataEntrada = new DateTime(2024, 10, 10),
                PrevisaoAlta = new DateTime(2024, 10, 17),
                MotivoInternacao = "Crise convulsiva",
                Leito = "05A",
                Quarto = "102",
                Setor = "Neurologia",
                PlanoSaudeUtilizado = "Particular",
                ObservacoesClinicas = "Paciente em observação contínua.",
                StatusInternacao = "Ativo"
            });

            modelBuilder.Entity<AltaHospitalar>().HasData(new AltaHospitalar
            {
                Id = altaId2,
                InternacaoId = internacaoId2,
                Data = new DateTime(2024, 10, 17),
                CondicaoPaciente = "Recuperado",
                InstrucoesPosAlta = "Evitar atividades estressantes e seguir acompanhamento ambulatorial."
            });

            // 3

            var pacienteId3 = Guid.Parse("00000000-0000-0000-0000-000000000065");
            var prontuarioId3 = Guid.Parse("00000000-0000-0000-0000-000000000066");
            var especialidadeId3 = Guid.Parse("00000000-0000-0000-0000-000000000067");
            var profissionalId3 = Guid.Parse("00000000-0000-0000-0000-000000000068");
            var atendimentoId3 = Guid.Parse("00000000-0000-0000-0000-000000000069");
            var prescricaoId3 = Guid.Parse("00000000-0000-0000-0000-00000000006a");
            var exameId3 = Guid.Parse("00000000-0000-0000-0000-00000000006b");
            var internacaoId3 = Guid.Parse("00000000-0000-0000-0000-00000000006c");
            var altaId3 = Guid.Parse("00000000-0000-0000-0000-00000000006d");

            modelBuilder.Entity<Paciente>().HasData(new Paciente
            {
                Id = pacienteId3,
                NomeCompleto = "Ana Beatriz Lima",
                CPF = "789.123.456-00",
                DataNascimento = new DateTime(1988, 12, 3),
                Sexo = "Feminino",
                TipoSanguineo = "B-",
                Telefone = "(41) 99988-1122",
                Email = "ana.lima@example.com",
                EnderecoCompleto = "Rua dos Andradas, 789, Curitiba - PR",
                NumeroCartaoSUS = "456789123456789",
                EstadoCivil = "Viúva",
                PossuiPlanoSaude = true
            });

            modelBuilder.Entity<Especialidade>().HasData(new Especialidade
            {
                Id = especialidadeId3,
                Nome = "Cardiologia"
            });

            modelBuilder.Entity<ProfissionalSaude>().HasData(new ProfissionalSaude
            {
                Id = profissionalId3,
                NomeCompleto = "Dr. Marcelo Farias",
                CPF = "654.321.987-00",
                Email = "marcelo.farias@example.com",
                Telefone = "(51) 91234-5678",
                RegistroConselho = "CRM789456",
                TipoRegistro = "CRM",
                EspecialidadeId = especialidadeId3,
                DataAdmissao = new DateTime(2016, 8, 22),
                CargaHorariaSemanal = 36,
                Turno = "Integral",
                Ativo = true
            });

            modelBuilder.Entity<Prontuario>().HasData(new Prontuario
            {
                Id = prontuarioId3,
                NumeroProntuario = "PR789456",
                DataAbertura = new DateTime(2024, 3, 14),
                ObservacoesGerais = "Paciente com histórico de arritmia cardíaca.",
                PacienteId = pacienteId3
            });

            modelBuilder.Entity<Atendimento>().HasData(new Atendimento
            {
                Id = atendimentoId3,
                DataHora = new DateTime(2025, 1, 18, 9, 45, 0),
                Tipo = "Retorno",
                Status = "Em andamento",
                Local = "Ambulatório Cardiologia",
                PacienteId = pacienteId3,
                ProfissionalId = profissionalId3,
                ProntuarioId = prontuarioId3
            });

            modelBuilder.Entity<Prescricao>().HasData(new Prescricao
            {
                Id = prescricaoId3,
                AtendimentoId = atendimentoId3,
                ProfissionalId = profissionalId3,
                Medicamento = "Losartana",
                Dosagem = "50mg",
                Frequencia = "1x ao dia",
                ViaAdministracao = "Oral",
                DataInicio = new DateTime(2025, 1, 18),
                StatusPrescricao = "Ativa",
                Observacoes = "Manter monitoramento da pressão arterial"
            });

            modelBuilder.Entity<Exame>().HasData(new Exame
            {
                Id = exameId3,
                Tipo = "Eletrocardiograma",
                DataSolicitacao = new DateTime(2025, 1, 17),
                DataRealizacao = new DateTime(2025, 1, 18),
                Resultado = "Presença de arritmia leve",
                AtendimentoId = atendimentoId3
            });

            modelBuilder.Entity<Internacao>().HasData(new Internacao
            {
                Id = internacaoId3,
                PacienteId = pacienteId3,
                AtendimentoId = atendimentoId3,
                DataEntrada = new DateTime(2025, 1, 10),
                PrevisaoAlta = new DateTime(2025, 1, 20),
                MotivoInternacao = "Avaliação cardíaca intensiva",
                Leito = "22C",
                Quarto = "204",
                Setor = "Cardiologia",
                PlanoSaudeUtilizado = "Amil",
                ObservacoesClinicas = "Paciente sob cuidados cardíacos contínuos.",
                StatusInternacao = "Em observação"
            });

            modelBuilder.Entity<AltaHospitalar>().HasData(new AltaHospitalar
            {
                Id = altaId3,
                InternacaoId = internacaoId3,
                Data = new DateTime(2025, 1, 20),
                CondicaoPaciente = "Estável com necessidade de acompanhamento",
                InstrucoesPosAlta = "Consultar cardiologista mensalmente e manter dieta hipossódica."
            });

            // 4

            var pacienteId4 = Guid.Parse("00000000-0000-0000-0000-000000000075");
            var prontuarioId4 = Guid.Parse("00000000-0000-0000-0000-000000000076");
            var especialidadeId4 = Guid.Parse("00000000-0000-0000-0000-000000000077");
            var profissionalId4 = Guid.Parse("00000000-0000-0000-0000-000000000078");
            var atendimentoId4 = Guid.Parse("00000000-0000-0000-0000-000000000079");
            var prescricaoId4 = Guid.Parse("00000000-0000-0000-0000-00000000007a");
            var exameId4 = Guid.Parse("00000000-0000-0000-0000-00000000007b");
            var internacaoId4 = Guid.Parse("00000000-0000-0000-0000-00000000007c");
            var altaId4 = Guid.Parse("00000000-0000-0000-0000-00000000007d");

            modelBuilder.Entity<Paciente>().HasData(new Paciente
            {
                Id = pacienteId4,
                NomeCompleto = "João Pedro Souza",
                CPF = "987.654.321-99",
                DataNascimento = new DateTime(1975, 5, 22),
                Sexo = "Masculino",
                TipoSanguineo = "O+",
                Telefone = "(11) 91123-4567",
                Email = "joao.p.souza@example.com",
                EnderecoCompleto = "Rua Alvorada, 150, São Paulo - SP",
                NumeroCartaoSUS = "321987654321987",
                EstadoCivil = "Divorciado",
                PossuiPlanoSaude = true
            });

            modelBuilder.Entity<Especialidade>().HasData(new Especialidade
            {
                Id = especialidadeId4,
                Nome = "Gastroenterologia"
            });

            modelBuilder.Entity<ProfissionalSaude>().HasData(new ProfissionalSaude
            {
                Id = profissionalId4,
                NomeCompleto = "Dra. Camila Andrade",
                CPF = "321.987.654-11",
                Email = "camila.andrade@example.com",
                Telefone = "(21) 93456-7890",
                RegistroConselho = "CRM123789",
                TipoRegistro = "CRM",
                EspecialidadeId = especialidadeId4,
                DataAdmissao = new DateTime(2019, 4, 15),
                CargaHorariaSemanal = 40,
                Turno = "Manhã",
                Ativo = true
            });

            modelBuilder.Entity<Prontuario>().HasData(new Prontuario
            {
                Id = prontuarioId4,
                NumeroProntuario = "PR123987",
                DataAbertura = new DateTime(2024, 7, 5),
                ObservacoesGerais = "Paciente apresenta episódios frequentes de refluxo gástrico.",
                PacienteId = pacienteId4
            });

            modelBuilder.Entity<Atendimento>().HasData(new Atendimento
            {
                Id = atendimentoId4,
                DataHora = new DateTime(2025, 2, 10, 8, 0, 0),
                Tipo = "Consulta",
                Status = "Finalizado",
                Local = "Clínica de Especialidades, Sala 7",
                PacienteId = pacienteId4,
                ProfissionalId = profissionalId4,
                ProntuarioId = prontuarioId4
            });

            modelBuilder.Entity<Prescricao>().HasData(new Prescricao
            {
                Id = prescricaoId4,
                AtendimentoId = atendimentoId4,
                ProfissionalId = profissionalId4,
                Medicamento = "Omeprazol",
                Dosagem = "20mg",
                Frequencia = "Antes do café da manhã",
                ViaAdministracao = "Oral",
                DataInicio = new DateTime(2025, 2, 10),
                StatusPrescricao = "Finalizada",
                Observacoes = "Reavaliar após 30 dias de uso contínuo"
            });

            modelBuilder.Entity<Exame>().HasData(new Exame
            {
                Id = exameId4,
                Tipo = "Endoscopia Digestiva",
                DataSolicitacao = new DateTime(2025, 2, 9),
                DataRealizacao = new DateTime(2025, 2, 12),
                Resultado = "Presença de esofagite grau A",
                AtendimentoId = atendimentoId4
            });

            modelBuilder.Entity<Internacao>().HasData(new Internacao
            {
                Id = internacaoId4,
                PacienteId = pacienteId4,
                AtendimentoId = atendimentoId4,
                DataEntrada = new DateTime(2025, 2, 5),
                PrevisaoAlta = new DateTime(2025, 2, 13),
                MotivoInternacao = "Exames e acompanhamento de distúrbios gastrointestinais",
                Leito = "12B",
                Quarto = "310",
                Setor = "Gastroenterologia",
                PlanoSaudeUtilizado = "Bradesco Saúde",
                ObservacoesClinicas = "Paciente sob dieta controlada e monitoramento.",
                StatusInternacao = "Concluída"
            });

            modelBuilder.Entity<AltaHospitalar>().HasData(new AltaHospitalar
            {
                Id = altaId4,
                InternacaoId = internacaoId4,
                Data = new DateTime(2025, 2, 13),
                CondicaoPaciente = "Boa, com controle da sintomatologia",
                InstrucoesPosAlta = "Evitar alimentos ácidos e condimentados; manter uso de medicação conforme prescrito."
            });

            // 5

            var pacienteId5 = Guid.Parse("00000000-0000-0000-0000-000000000081");
            var prontuarioId5 = Guid.Parse("00000000-0000-0000-0000-000000000082");
            var especialidadeId5 = Guid.Parse("00000000-0000-0000-0000-000000000083");
            var profissionalId5 = Guid.Parse("00000000-0000-0000-0000-000000000084");
            var atendimentoId5 = Guid.Parse("00000000-0000-0000-0000-000000000085");
            var prescricaoId5 = Guid.Parse("00000000-0000-0000-0000-000000000086");
            var exameId5 = Guid.Parse("00000000-0000-0000-0000-000000000087");
            var internacaoId5 = Guid.Parse("00000000-0000-0000-0000-000000000088");
            var altaId5 = Guid.Parse("00000000-0000-0000-0000-000000000089");

            modelBuilder.Entity<Paciente>().HasData(new Paciente
            {
                Id = pacienteId5,
                NomeCompleto = "Letícia Ramos Ferreira",
                CPF = "123.321.456-77",
                DataNascimento = new DateTime(1982, 3, 8),
                Sexo = "Feminino",
                TipoSanguineo = "B-",
                Telefone = "(41) 99876-1122",
                Email = "leticia.ferreira@example.com",
                EnderecoCompleto = "Rua das Laranjeiras, 222, Curitiba - PR",
                NumeroCartaoSUS = "556644332211009",
                EstadoCivil = "Viúva",
                PossuiPlanoSaude = true
            });

            modelBuilder.Entity<Especialidade>().HasData(new Especialidade
            {
                Id = especialidadeId5,
                Nome = "Cardiologia"
            });

            modelBuilder.Entity<ProfissionalSaude>().HasData(new ProfissionalSaude
            {
                Id = profissionalId5,
                NomeCompleto = "Dr. Marcelo Tavares",
                CPF = "789.456.123-33",
                Email = "marcelo.tavares@example.com",
                Telefone = "(61) 98765-4321",
                RegistroConselho = "CRM998877",
                TipoRegistro = "CRM",
                EspecialidadeId = especialidadeId5,
                DataAdmissao = new DateTime(2016, 10, 1),
                CargaHorariaSemanal = 20,
                Turno = "Noite",
                Ativo = true
            });

            modelBuilder.Entity<Prontuario>().HasData(new Prontuario
            {
                Id = prontuarioId5,
                NumeroProntuario = "PR789123",
                DataAbertura = new DateTime(2024, 12, 1),
                ObservacoesGerais = "Histórico de hipertensão e episódios de taquicardia.",
                PacienteId = pacienteId5
            });

            modelBuilder.Entity<Atendimento>().HasData(new Atendimento
            {
                Id = atendimentoId5,
                DataHora = new DateTime(2025, 3, 15, 19, 45, 0),
                Tipo = "Emergência",
                Status = "Encaminhado",
                Local = "Pronto Atendimento 24h - Cardiologia",
                PacienteId = pacienteId5,
                ProfissionalId = profissionalId5,
                ProntuarioId = prontuarioId5
            });

            modelBuilder.Entity<Prescricao>().HasData(new Prescricao
            {
                Id = prescricaoId5,
                AtendimentoId = atendimentoId5,
                ProfissionalId = profissionalId5,
                Medicamento = "Atenolol",
                Dosagem = "50mg",
                Frequencia = "1 vez ao dia",
                ViaAdministracao = "Oral",
                DataInicio = new DateTime(2025, 3, 15),
                StatusPrescricao = "Em uso",
                Observacoes = "Reavaliar em 7 dias com novo eletrocardiograma"
            });

            modelBuilder.Entity<Exame>().HasData(new Exame
            {
                Id = exameId5,
                Tipo = "Eletrocardiograma",
                DataSolicitacao = new DateTime(2025, 3, 15),
                DataRealizacao = new DateTime(2025, 3, 15),
                Resultado = "Taquicardia sinusal detectada",
                AtendimentoId = atendimentoId5
            });

            modelBuilder.Entity<Internacao>().HasData(new Internacao
            {
                Id = internacaoId5,
                PacienteId = pacienteId5,
                AtendimentoId = atendimentoId5,
                DataEntrada = new DateTime(2025, 3, 15),
                PrevisaoAlta = new DateTime(2025, 3, 18),
                MotivoInternacao = "Controle e estabilização de quadro cardíaco",
                Leito = "08C",
                Quarto = "205",
                Setor = "Cardiologia",
                PlanoSaudeUtilizado = "Unimed",
                ObservacoesClinicas = "Paciente com bom prognóstico após estabilização.",
                StatusInternacao = "Alta concedida"
            });

            modelBuilder.Entity<AltaHospitalar>().HasData(new AltaHospitalar
            {
                Id = altaId5,
                InternacaoId = internacaoId5,
                Data = new DateTime(2025, 3, 18),
                CondicaoPaciente = "Estável, com pressão arterial controlada",
                InstrucoesPosAlta = "Evitar esforços físicos por 15 dias, manter consulta de retorno em 1 semana."
            });

            // 6

            var pacienteId6 = Guid.Parse("10000000-0000-0000-0000-000000000001");
            var prontuarioId6 = Guid.Parse("10000000-0000-0000-0000-000000000002");
            var especialidadeId6 = Guid.Parse("10000000-0000-0000-0000-000000000003");
            var profissionalId6 = Guid.Parse("10000000-0000-0000-0000-000000000004");
            var atendimentoId6 = Guid.Parse("10000000-0000-0000-0000-000000000005");
            var prescricaoId6 = Guid.Parse("10000000-0000-0000-0000-000000000006");
            var exameId6 = Guid.Parse("10000000-0000-0000-0000-000000000007");
            var internacaoId6 = Guid.Parse("10000000-0000-0000-0000-000000000008");
            var altaId6 = Guid.Parse("10000000-0000-0000-0000-000000000009");

            modelBuilder.Entity<Paciente>().HasData(new Paciente
            {
                Id = pacienteId6,
                NomeCompleto = "Bruno Henrique Dias",
                CPF = "213.546.789-55",
                DataNascimento = new DateTime(1977, 6, 20),
                Sexo = "Masculino",
                TipoSanguineo = "AB+",
                Telefone = "(11) 98877-6655",
                Email = "bruno.dias@example.com",
                EnderecoCompleto = "Rua das Palmeiras, 999, São Paulo - SP",
                NumeroCartaoSUS = "112233445566778",
                EstadoCivil = "Divorciado",
                PossuiPlanoSaude = false
            });

            modelBuilder.Entity<Especialidade>().HasData(new Especialidade
            {
                Id = especialidadeId6,
                Nome = "Ortopedia"
            });

            modelBuilder.Entity<ProfissionalSaude>().HasData(new ProfissionalSaude
            {
                Id = profissionalId6,
                NomeCompleto = "Dr. Renan Oliveira",
                CPF = "654.987.321-00",
                Email = "renan.oliveira@example.com",
                Telefone = "(11) 97654-3210",
                RegistroConselho = "CRM443322",
                TipoRegistro = "CRM",
                EspecialidadeId = especialidadeId6,
                DataAdmissao = new DateTime(2020, 5, 10),
                CargaHorariaSemanal = 44,
                Turno = "Integral",
                Ativo = true
            });

            modelBuilder.Entity<Prontuario>().HasData(new Prontuario
            {
                Id = prontuarioId6,
                NumeroProntuario = "PR123999",
                DataAbertura = new DateTime(2023, 2, 14),
                ObservacoesGerais = "Fratura recente no tornozelo direito. Histórico de osteoporose.",
                PacienteId = pacienteId6
            });

            modelBuilder.Entity<Atendimento>().HasData(new Atendimento
            {
                Id = atendimentoId6,
                DataHora = new DateTime(2025, 4, 2, 9, 0, 0),
                Tipo = "Consulta Pós-Cirúrgica",
                Status = "Realizado",
                Local = "Ambulatório Ortopedia - Sala 12",
                PacienteId = pacienteId6,
                ProfissionalId = profissionalId6,
                ProntuarioId = prontuarioId6
            });

            modelBuilder.Entity<Prescricao>().HasData(new Prescricao
            {
                Id = prescricaoId6,
                AtendimentoId = atendimentoId6,
                ProfissionalId = profissionalId6,
                Medicamento = "Dipirona Sódica",
                Dosagem = "1g",
                Frequencia = "8/8h",
                ViaAdministracao = "Oral",
                DataInicio = new DateTime(2025, 4, 2),
                StatusPrescricao = "Encerrada",
                Observacoes = "Suspender após 7 dias, se não houver dor."
            });

            modelBuilder.Entity<Exame>().HasData(new Exame
            {
                Id = exameId6,
                Tipo = "Raio-X do Tornozelo",
                DataSolicitacao = new DateTime(2025, 4, 2),
                DataRealizacao = new DateTime(2025, 4, 3),
                Resultado = "Consolidação óssea adequada.",
                AtendimentoId = atendimentoId6
            });

            modelBuilder.Entity<Internacao>().HasData(new Internacao
            {
                Id = internacaoId6,
                PacienteId = pacienteId6,
                AtendimentoId = atendimentoId6,
                DataEntrada = new DateTime(2025, 3, 25),
                PrevisaoAlta = new DateTime(2025, 3, 30),
                MotivoInternacao = "Cirurgia de reconstrução óssea do tornozelo",
                Leito = "04B",
                Quarto = "107",
                Setor = "Ortopedia",
                PlanoSaudeUtilizado = "SUS",
                ObservacoesClinicas = "Paciente respondeu bem à cirurgia e iniciou fisioterapia.",
                StatusInternacao = "Alta concedida"
            });

            modelBuilder.Entity<AltaHospitalar>().HasData(new AltaHospitalar
            {
                Id = altaId6,
                InternacaoId = internacaoId6,
                Data = new DateTime(2025, 3, 30),
                CondicaoPaciente = "Estável, com acompanhamento ambulatorial indicado",
                InstrucoesPosAlta = "Realizar sessões de fisioterapia, evitar carga no membro afetado."
            });

            // 7 

            var pacienteId7 = Guid.Parse("20000000-0000-0000-0000-000000000001");
            var prontuarioId7 = Guid.Parse("20000000-0000-0000-0000-000000000002");
            var especialidadeId7 = Guid.Parse("20000000-0000-0000-0000-000000000003");
            var profissionalId7 = Guid.Parse("20000000-0000-0000-0000-000000000004");
            var atendimentoId7 = Guid.Parse("20000000-0000-0000-0000-000000000005");
            var prescricaoId7 = Guid.Parse("20000000-0000-0000-0000-000000000006");
            var exameId7 = Guid.Parse("20000000-0000-0000-0000-000000000007");
            var internacaoId7 = Guid.Parse("20000000-0000-0000-0000-000000000008");
            var altaId7 = Guid.Parse("20000000-0000-0000-0000-000000000009");

            modelBuilder.Entity<Paciente>().HasData(new Paciente
            {
                Id = pacienteId7,
                NomeCompleto = "Luciana Marques Ferreira",
                CPF = "876.543.210-09",
                DataNascimento = new DateTime(1982, 3, 5),
                Sexo = "Feminino",
                TipoSanguineo = "O-",
                Telefone = "(41) 98564-1122",
                Email = "luciana.ferreira@example.com",
                EnderecoCompleto = "Rua Sete de Setembro, 100, Curitiba - PR",
                NumeroCartaoSUS = "778899001122334",
                EstadoCivil = "Viúva",
                PossuiPlanoSaude = true
            });

            modelBuilder.Entity<Especialidade>().HasData(new Especialidade
            {
                Id = especialidadeId7,
                Nome = "Endocrinologia"
            });

            modelBuilder.Entity<ProfissionalSaude>().HasData(new ProfissionalSaude
            {
                Id = profissionalId7,
                NomeCompleto = "Dra. Camila Prado",
                CPF = "321.654.987-11",
                Email = "camila.prado@example.com",
                Telefone = "(41) 97777-1234",
                RegistroConselho = "CRM998877",
                TipoRegistro = "CRM",
                EspecialidadeId = especialidadeId7,
                DataAdmissao = new DateTime(2019, 9, 3),
                CargaHorariaSemanal = 36,
                Turno = "Manhã",
                Ativo = true
            });

            modelBuilder.Entity<Prontuario>().HasData(new Prontuario
            {
                Id = prontuarioId7,
                NumeroProntuario = "PR789456",
                DataAbertura = new DateTime(2022, 12, 10),
                ObservacoesGerais = "Diabetes tipo 2 diagnosticado em 2020.",
                PacienteId = pacienteId7
            });

            modelBuilder.Entity<Atendimento>().HasData(new Atendimento
            {
                Id = atendimentoId7,
                DataHora = new DateTime(2025, 5, 15, 8, 45, 0),
                Tipo = "Consulta de Rotina",
                Status = "Realizado",
                Local = "Consultório Endocrinologia - Sala 02",
                PacienteId = pacienteId7,
                ProfissionalId = profissionalId7,
                ProntuarioId = prontuarioId7
            });

            modelBuilder.Entity<Prescricao>().HasData(new Prescricao
            {
                Id = prescricaoId7,
                AtendimentoId = atendimentoId7,
                ProfissionalId = profissionalId7,
                Medicamento = "Metformina",
                Dosagem = "850mg",
                Frequencia = "2x ao dia",
                ViaAdministracao = "Oral",
                DataInicio = new DateTime(2025, 5, 15),
                StatusPrescricao = "Em uso",
                Observacoes = "Tomar após as principais refeições"
            });

            modelBuilder.Entity<Exame>().HasData(new Exame
            {
                Id = exameId7,
                Tipo = "Hemoglobina Glicada",
                DataSolicitacao = new DateTime(2025, 5, 15),
                DataRealizacao = new DateTime(2025, 5, 17),
                Resultado = "6.9% - dentro da meta para controle glicêmico.",
                AtendimentoId = atendimentoId7
            });

            modelBuilder.Entity<Internacao>().HasData(new Internacao
            {
                Id = internacaoId7,
                PacienteId = pacienteId7,
                AtendimentoId = atendimentoId7,
                DataEntrada = new DateTime(2025, 4, 28),
                PrevisaoAlta = new DateTime(2025, 5, 3),
                MotivoInternacao = "Descompensação glicêmica aguda",
                Leito = "12C",
                Quarto = "204",
                Setor = "Clínica Médica",
                PlanoSaudeUtilizado = "Amil Saúde",
                ObservacoesClinicas = "Paciente respondeu bem à insulinoterapia.",
                StatusInternacao = "Alta concedida"
            });

            modelBuilder.Entity<AltaHospitalar>().HasData(new AltaHospitalar
            {
                Id = altaId7,
                InternacaoId = internacaoId7,
                Data = new DateTime(2025, 5, 3),
                CondicaoPaciente = "Estável com orientações para ajuste terapêutico domiciliar",
                InstrucoesPosAlta = "Continuar monitoramento domiciliar da glicose e retorno em 30 dias."
            });

            // 8 

            var pacienteId8 = Guid.Parse("30000000-0000-0000-0000-000000000001");
            var prontuarioId8 = Guid.Parse("30000000-0000-0000-0000-000000000002");
            var especialidadeId8 = Guid.Parse("30000000-0000-0000-0000-000000000003");
            var profissionalId8 = Guid.Parse("30000000-0000-0000-0000-000000000004");
            var atendimentoId8 = Guid.Parse("30000000-0000-0000-0000-000000000005");
            var prescricaoId8 = Guid.Parse("30000000-0000-0000-0000-000000000006");
            var exameId8 = Guid.Parse("30000000-0000-0000-0000-000000000007");
            var internacaoId8 = Guid.Parse("30000000-0000-0000-0000-000000000008");
            var altaId8 = Guid.Parse("30000000-0000-0000-0000-000000000009");

            modelBuilder.Entity<Paciente>().HasData(new Paciente
            {
                Id = pacienteId8,
                NomeCompleto = "Henrique Tavares dos Santos",
                CPF = "234.567.890-10",
                DataNascimento = new DateTime(1975, 11, 3),
                Sexo = "Masculino",
                TipoSanguineo = "AB+",
                Telefone = "(85) 99888-1122",
                Email = "henrique.santos@example.com",
                EnderecoCompleto = "Rua da Paz, 789, Fortaleza - CE",
                NumeroCartaoSUS = "445566778899000",
                EstadoCivil = "Divorciado",
                PossuiPlanoSaude = true
            });

            modelBuilder.Entity<Especialidade>().HasData(new Especialidade
            {
                Id = especialidadeId8,
                Nome = "Cardiologia"
            });

            modelBuilder.Entity<ProfissionalSaude>().HasData(new ProfissionalSaude
            {
                Id = profissionalId8,
                NomeCompleto = "Dr. João Marcelo Nogueira",
                CPF = "567.123.890-22",
                Email = "joao.nogueira@example.com",
                Telefone = "(85) 99666-4455",
                RegistroConselho = "CRM112233",
                TipoRegistro = "CRM",
                EspecialidadeId = especialidadeId8,
                DataAdmissao = new DateTime(2021, 6, 15),
                CargaHorariaSemanal = 40,
                Turno = "Integral",
                Ativo = true
            });

            modelBuilder.Entity<Prontuario>().HasData(new Prontuario
            {
                Id = prontuarioId8,
                NumeroProntuario = "PR2023123",
                DataAbertura = new DateTime(2023, 3, 1),
                ObservacoesGerais = "Histórico de hipertensão e sedentarismo.",
                PacienteId = pacienteId8
            });

            modelBuilder.Entity<Atendimento>().HasData(new Atendimento
            {
                Id = atendimentoId8,
                DataHora = new DateTime(2025, 3, 10, 9, 15, 0),
                Tipo = "Consulta de Especialidade",
                Status = "Realizado",
                Local = "Clínica Cardiológica - Sala 1",
                PacienteId = pacienteId8,
                ProfissionalId = profissionalId8,
                ProntuarioId = prontuarioId8
            });

            modelBuilder.Entity<Prescricao>().HasData(new Prescricao
            {
                Id = prescricaoId8,
                AtendimentoId = atendimentoId8,
                ProfissionalId = profissionalId8,
                Medicamento = "Losartana",
                Dosagem = "50mg",
                Frequencia = "1x ao dia",
                ViaAdministracao = "Oral",
                DataInicio = new DateTime(2025, 3, 10),
                StatusPrescricao = "Em uso",
                Observacoes = "Preferencialmente pela manhã"
            });

            modelBuilder.Entity<Exame>().HasData(new Exame
            {
                Id = exameId8,
                Tipo = "Eletrocardiograma",
                DataSolicitacao = new DateTime(2025, 3, 10),
                DataRealizacao = new DateTime(2025, 3, 11),
                Resultado = "Ritmo sinusal, sem anormalidades detectadas",
                AtendimentoId = atendimentoId8
            });

            modelBuilder.Entity<Internacao>().HasData(new Internacao
            {
                Id = internacaoId8,
                PacienteId = pacienteId8,
                AtendimentoId = atendimentoId8,
                DataEntrada = new DateTime(2025, 2, 25),
                PrevisaoAlta = new DateTime(2025, 2, 28),
                MotivoInternacao = "Pico hipertensivo com cefaleia intensa",
                Leito = "06B",
                Quarto = "110",
                Setor = "Cardiologia",
                PlanoSaudeUtilizado = "Bradesco Saúde",
                ObservacoesClinicas = "Paciente estabilizado após controle da pressão arterial.",
                StatusInternacao = "Alta concedida"
            });

            modelBuilder.Entity<AltaHospitalar>().HasData(new AltaHospitalar
            {
                Id = altaId8,
                InternacaoId = internacaoId8,
                Data = new DateTime(2025, 2, 28),
                CondicaoPaciente = "Pressão controlada, orientação para reavaliação periódica",
                InstrucoesPosAlta = "Aderir à medicação, controlar dieta e praticar atividades físicas leves."
            });

            // 9 
            var pacienteId9 = Guid.Parse("40000000-0000-0000-0000-000000000001");
            var prontuarioId9 = Guid.Parse("40000000-0000-0000-0000-000000000002");
            var especialidadeId9 = Guid.Parse("40000000-0000-0000-0000-000000000003");
            var profissionalId9 = Guid.Parse("40000000-0000-0000-0000-000000000004");
            var atendimentoId9 = Guid.Parse("40000000-0000-0000-0000-000000000005");
            var prescricaoId9 = Guid.Parse("40000000-0000-0000-0000-000000000006");
            var exameId9 = Guid.Parse("40000000-0000-0000-0000-000000000007");
            var internacaoId9 = Guid.Parse("40000000-0000-0000-0000-000000000008");
            var altaId9 = Guid.Parse("40000000-0000-0000-0000-000000000009");

            modelBuilder.Entity<Paciente>().HasData(new Paciente
            {
                Id = pacienteId9,
                NomeCompleto = "Luciana Mendes Rocha",
                CPF = "321.123.456-78",
                DataNascimento = new DateTime(1985, 6, 22),
                Sexo = "Feminino",
                TipoSanguineo = "O-",
                Telefone = "(61) 99123-4567",
                Email = "luciana.rocha@example.com",
                EnderecoCompleto = "SHN Quadra 5, Bloco C, Brasília - DF",
                NumeroCartaoSUS = "889900112233445",
                EstadoCivil = "Solteira",
                PossuiPlanoSaude = true
            });

            modelBuilder.Entity<Especialidade>().HasData(new Especialidade
            {
                Id = especialidadeId9,
                Nome = "Dermatologia"
            });

            modelBuilder.Entity<ProfissionalSaude>().HasData(new ProfissionalSaude
            {
                Id = profissionalId9,
                NomeCompleto = "Dra. Fernanda Albuquerque",
                CPF = "654.321.987-00",
                Email = "fernanda.albuquerque@example.com",
                Telefone = "(61) 99887-6655",
                RegistroConselho = "CRM998877",
                TipoRegistro = "CRM",
                EspecialidadeId = especialidadeId9,
                DataAdmissao = new DateTime(2022, 1, 20),
                CargaHorariaSemanal = 24,
                Turno = "Manhã",
                Ativo = true
            });

            modelBuilder.Entity<Prontuario>().HasData(new Prontuario
            {
                Id = prontuarioId9,
                NumeroProntuario = "PR2024123",
                DataAbertura = new DateTime(2024, 8, 18),
                ObservacoesGerais = "Paciente com histórico de dermatite atópica.",
                PacienteId = pacienteId9
            });

            modelBuilder.Entity<Atendimento>().HasData(new Atendimento
            {
                Id = atendimentoId9,
                DataHora = new DateTime(2025, 5, 5, 10, 0, 0),
                Tipo = "Consulta Dermatológica",
                Status = "Realizado",
                Local = "Ambulatório - Sala 4",
                PacienteId = pacienteId9,
                ProfissionalId = profissionalId9,
                ProntuarioId = prontuarioId9
            });

            modelBuilder.Entity<Prescricao>().HasData(new Prescricao
            {
                Id = prescricaoId9,
                AtendimentoId = atendimentoId9,
                ProfissionalId = profissionalId9,
                Medicamento = "Pomada de Hidrocortisona",
                Dosagem = "1%",
                Frequencia = "2x ao dia",
                ViaAdministracao = "Tópica",
                DataInicio = new DateTime(2025, 5, 5),
                StatusPrescricao = "Em uso",
                Observacoes = "Aplicar nas áreas afetadas após limpeza da pele"
            });

            modelBuilder.Entity<Exame>().HasData(new Exame
            {
                Id = exameId9,
                Tipo = "Biópsia de pele",
                DataSolicitacao = new DateTime(2025, 5, 5),
                DataRealizacao = new DateTime(2025, 5, 8),
                Resultado = "Compatível com eczema crônico",
                AtendimentoId = atendimentoId9
            });

            modelBuilder.Entity<Internacao>().HasData(new Internacao
            {
                Id = internacaoId9,
                PacienteId = pacienteId9,
                AtendimentoId = atendimentoId9,
                DataEntrada = new DateTime(2025, 5, 1),
                PrevisaoAlta = new DateTime(2025, 5, 3),
                MotivoInternacao = "Infecção secundária em lesão dermatológica",
                Leito = "12C",
                Quarto = "207",
                Setor = "Clínica Médica",
                PlanoSaudeUtilizado = "Unimed",
                ObservacoesClinicas = "Lesões extensas com sinais de infecção bacteriana.",
                StatusInternacao = "Alta concedida"
            });

            modelBuilder.Entity<AltaHospitalar>().HasData(new AltaHospitalar
            {
                Id = altaId9,
                InternacaoId = internacaoId9,
                Data = new DateTime(2025, 5, 3),
                CondicaoPaciente = "Melhora significativa",
                InstrucoesPosAlta = "Manter tratamento dermatológico e retorno em 15 dias."
            });

            // 10 
            var pacienteId10 = Guid.Parse("11110000-0000-0000-0000-222222222222");
            var prontuarioId10 = Guid.Parse("33333333-0000-0000-0000-444444444444");
            var especialidadeId10 = Guid.Parse("55555555-0000-0000-0000-666666666666");
            var profissionalId10 = Guid.Parse("77777777-0000-0000-0000-888888888888");
            var atendimentoId10 = Guid.Parse("99999999-0000-0000-0000-000000000000");
            var prescricaoId10 = Guid.Parse("aaaaaaaa-0000-0000-0000-000000000000");
            var exameId10 = Guid.Parse("bbbbbbbb-0000-0000-0000-000000000000");
            var internacaoId10 = Guid.Parse("27777777-0000-0000-0000-111111111111");
            var altaId10 = Guid.Parse("37777777-0000-0000-0000-222222222222");


            modelBuilder.Entity<Paciente>().HasData(new Paciente
            {
                Id = pacienteId10,
                NomeCompleto = "Ana Beatriz Rocha",
                CPF = "123.456.789-01",
                DataNascimento = new DateTime(1985, 12, 10),
                Sexo = "Feminino",
                TipoSanguineo = "O-",
                Telefone = "(11) 91234-5678",
                Email = "ana.rocha@example.com",
                EnderecoCompleto = "Rua das Flores, 789, São Paulo - SP",
                NumeroCartaoSUS = "123456789123456",
                EstadoCivil = "Solteira",
                PossuiPlanoSaude = true
            });

            modelBuilder.Entity<Especialidade>().HasData(new Especialidade
            {
                Id = especialidadeId10,
                Nome = "Cardiologia"
            });

            modelBuilder.Entity<ProfissionalSaude>().HasData(new ProfissionalSaude
            {
                Id = profissionalId10,
                NomeCompleto = "Dr. Marcos Pereira",
                CPF = "987.654.321-00",
                Email = "marcos.pereira@example.com",
                Telefone = "(21) 92345-6789",
                RegistroConselho = "CRM987654",
                TipoRegistro = "CRM",
                EspecialidadeId = especialidadeId10,
                DataAdmissao = new DateTime(2016, 4, 5),
                CargaHorariaSemanal = 40,
                Turno = "Manhã",
                Ativo = true
            });

            modelBuilder.Entity<Prontuario>().HasData(new Prontuario
            {
                Id = prontuarioId10,
                NumeroProntuario = "PR987654",
                DataAbertura = new DateTime(2023, 8, 15),
                ObservacoesGerais = "Paciente com histórico de hipertensão.",
                PacienteId = pacienteId10
            });

            modelBuilder.Entity<Atendimento>().HasData(new Atendimento
            {
                Id = atendimentoId10,
                DataHora = new DateTime(2024, 12, 5, 9, 0, 0),
                Tipo = "Exame",
                Status = "Concluído",
                Local = "Consultório 12",
                PacienteId = pacienteId,
                ProfissionalId = profissionalId10,
                ProntuarioId = prontuarioId10
            });

            modelBuilder.Entity<Prescricao>().HasData(new Prescricao
            {
                Id = prescricaoId10,
                AtendimentoId = atendimentoId10,
                ProfissionalId = profissionalId10,
                Medicamento = "Losartana",
                Dosagem = "50mg",
                Frequencia = "12/12h",
                ViaAdministracao = "Oral",
                DataInicio = new DateTime(2024, 12, 5),
                StatusPrescricao = "Pendente",
                Observacoes = "Tomar após o almoço"
            });

            modelBuilder.Entity<Exame>().HasData(new Exame
            {
                Id = exameId10,
                Tipo = "Ultrassonografia",
                DataSolicitacao = new DateTime(2024, 12, 4),
                DataRealizacao = new DateTime(2024, 12, 6),
                Resultado = "Alterações leves no fígado",
                AtendimentoId = atendimentoId
            });

            modelBuilder.Entity<Internacao>().HasData(new Internacao
            {
                Id = internacaoId10,
                PacienteId = pacienteId10,
                AtendimentoId = atendimentoId10,
                DataEntrada = new DateTime(2024, 11, 1),
                PrevisaoAlta = new DateTime(2024, 11, 5),
                MotivoInternacao = "Infecção respiratória",
                Leito = "10B",
                Quarto = "205",
                Setor = "Clinico",
                PlanoSaudeUtilizado = "Unimed",
                ObservacoesClinicas = "Paciente em tratamento com antibióticos.",
                StatusInternacao = "Concluído"
            });

            modelBuilder.Entity<AltaHospitalar>().HasData(new AltaHospitalar
            {
                Id = altaId10,
                InternacaoId = internacaoId10,
                Data = new DateTime(2024, 11, 5),
                CondicaoPaciente = "Estável",
                InstrucoesPosAlta = "Retornar para consulta de acompanhamento em 15 dias."
            });


        }

    }
}
