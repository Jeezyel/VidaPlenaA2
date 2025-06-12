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
        }

    }
}
