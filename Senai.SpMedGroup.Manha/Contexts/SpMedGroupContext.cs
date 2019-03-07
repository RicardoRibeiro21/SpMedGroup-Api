using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.SpMedGroup.Manha.Domains
{
    public partial class SpMedGroupContext : DbContext
    {
        public SpMedGroupContext()
        {
        }

        public SpMedGroupContext(DbContextOptions<SpMedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Consultas> Consultas { get; set; }
        public virtual DbSet<Especializacoes> Especializacoes { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Prontuarios> Prontuarios { get; set; }
        public virtual DbSet<StatusConsulta> StatusConsulta { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'dbo.Especialidades$'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; initial catalog = SPMEDGROUP;user id = sa; pwd = 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.ToTable("CLINICA");

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__CLINICA__AA57D6B4689786C4")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__CLINICA__E2AB1FF43D366D25")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("LOGRADOURO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasColumnName("RAZAO_SOCIAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultas>(entity =>
            {
                entity.ToTable("CONSULTAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CrmMedico)
                    .IsRequired()
                    .HasColumnName("CRM_MEDICO")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DataConsulta)
                    .HasColumnName("DATA_CONSULTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdProntuario).HasColumnName("ID_PRONTUARIO");

                entity.Property(e => e.Resultado)
                    .HasColumnName("RESULTADO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StatusConsulta).HasColumnName("STATUS_CONSULTA");

                entity.HasOne(d => d.CrmMedicoNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.CrmMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONSULTAS__CRM_M__55009F39");

                entity.HasOne(d => d.IdProntuarioNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.IdProntuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONSULTAS__ID_PR__56E8E7AB");

                entity.HasOne(d => d.StatusConsultaNavigation)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.StatusConsulta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONSULTAS__STATU__55F4C372");
            });

            modelBuilder.Entity<Especializacoes>(entity =>
            {
                entity.ToTable("ESPECIALIZACOES");

                entity.HasIndex(e => e.Especializacao)
                    .HasName("UQ__ESPECIAL__98D750546B8A3405")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Especializacao)
                    .IsRequired()
                    .HasColumnName("ESPECIALIZACAO")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.HasKey(e => e.Crm);

                entity.ToTable("MEDICOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__MEDICOS__161CF72497771D49")
                    .IsUnique();

                entity.Property(e => e.Crm)
                    .HasColumnName("CRM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdClinica).HasColumnName("ID_CLINICA");

                entity.Property(e => e.IdEspecializacao).HasColumnName("ID_ESPECIALIZACAO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MEDICOS__ID_CLIN__2EDAF651");

                entity.HasOne(d => d.IdEspecializacaoNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecializacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MEDICOS__ID_ESPE__2DE6D218");
            });

            modelBuilder.Entity<Prontuarios>(entity =>
            {
                entity.ToTable("PRONTUARIOS");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__PRONTUAR__C1F897316DBA1A72")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("UQ__PRONTUAR__91136B911E7FB586")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__PRONTUAR__321537C87FE547D9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Prontuarios)
                    .HasForeignKey<Prontuarios>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRONTUARI__ID_US__5224328E");
            });

            modelBuilder.Entity<StatusConsulta>(entity =>
            {
                entity.ToTable("STATUS_CONSULTA");

                entity.HasIndex(e => e.Situacao)
                    .HasName("UQ__STATUS_C__4E84C4A25965B935")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Situacao)
                    .IsRequired()
                    .HasColumnName("SITUACAO")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TIPO_USUARIO");

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__TIPO_USU__B6FCAAA283E52A7C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF7241D55EFCB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIOS__ID_TIP__46B27FE2");
            });
        }
    }
}
