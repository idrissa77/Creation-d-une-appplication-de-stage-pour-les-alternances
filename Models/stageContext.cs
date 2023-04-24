using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace stages.Models
{
    public partial class stageContext : DbContext
    {
        public stageContext()
        {
        }

        public stageContext(DbContextOptions<stageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Convention> Conventions { get; set; } = null!;
        public virtual DbSet<Date> Dates { get; set; } = null!;
        public virtual DbSet<Enseignant> Enseignants { get; set; } = null!;
        public virtual DbSet<Entreprise> Entreprises { get; set; } = null!;
        public virtual DbSet<Etudiant> Etudiants { get; set; } = null!;
        public virtual DbSet<Propositionsstage> Propositionsstages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=stage;user=root;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.6.17-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => new { e.Noproposition, e.Idfetudiant, e.Datecontact })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("contacts");

                entity.HasIndex(e => e.Datecontact, "FK_CONTACTS");

                entity.HasIndex(e => e.Idfetudiant, "FK_CONTACTS3");

                entity.Property(e => e.Noproposition)
                    .HasColumnType("int(11)")
                    .HasColumnName("NOPROPOSITION");

                entity.Property(e => e.Idfetudiant)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDFETUDIANT");

                entity.Property(e => e.Datecontact).HasColumnName("DATECONTACT");

                entity.HasOne(d => d.DatecontactNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.Datecontact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONTACTS");

                entity.HasOne(d => d.IdfetudiantNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.Idfetudiant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONTACTS3");

                entity.HasOne(d => d.NopropositionNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.Noproposition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONTACTS2");
            });

            modelBuilder.Entity<Convention>(entity =>
            {
                entity.HasKey(e => e.Noconvention)
                    .HasName("PRIMARY");

                entity.ToTable("conventions");

                entity.HasIndex(e => e.Noproposition, "FK_CORRESPOND_A3");

                entity.HasIndex(e => e.ProNoproposition, "FK_CORRESPOND_A4");

                entity.HasIndex(e => e.Idfenseignant, "FK_ENCADRE");

                entity.HasIndex(e => e.EtuIdfetudiant, "FK_SIGNE");

                entity.HasIndex(e => e.Idfetudiant, "FK_SIGNE2");

                entity.Property(e => e.Noconvention)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("NOCONVENTION");

                entity.Property(e => e.Datedebut).HasColumnName("DATEDEBUT");

                entity.Property(e => e.Datesignature).HasColumnName("DATESIGNATURE");

                entity.Property(e => e.EtuIdfetudiant)
                    .HasColumnType("int(11)")
                    .HasColumnName("ETU_IDFETUDIANT");

                entity.Property(e => e.Idfenseignant)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDFENSEIGNANT");

                entity.Property(e => e.Idfetudiant)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDFETUDIANT");

                entity.Property(e => e.Noproposition)
                    .HasColumnType("int(11)")
                    .HasColumnName("NOPROPOSITION");

                entity.Property(e => e.ProNoproposition)
                    .HasColumnType("int(11)")
                    .HasColumnName("PRO_NOPROPOSITION");

                entity.Property(e => e.Salaire)
                    .HasPrecision(7, 3)
                    .HasColumnName("SALAIRE");

                entity.Property(e => e.Sujetmemoire)
                    .HasMaxLength(50)
                    .HasColumnName("SUJETMEMOIRE");

                entity.HasOne(d => d.EtuIdfetudiantNavigation)
                    .WithMany(p => p.ConventionEtuIdfetudiantNavigations)
                    .HasForeignKey(d => d.EtuIdfetudiant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SIGNE");

                entity.HasOne(d => d.IdfenseignantNavigation)
                    .WithMany(p => p.Conventions)
                    .HasForeignKey(d => d.Idfenseignant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENCADRE");

                entity.HasOne(d => d.IdfetudiantNavigation)
                    .WithMany(p => p.ConventionIdfetudiantNavigations)
                    .HasForeignKey(d => d.Idfetudiant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SIGNE2");

                entity.HasOne(d => d.NopropositionNavigation)
                    .WithMany(p => p.ConventionNopropositionNavigations)
                    .HasForeignKey(d => d.Noproposition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CORRESPOND_A3");

                entity.HasOne(d => d.ProNopropositionNavigation)
                    .WithMany(p => p.ConventionProNopropositionNavigations)
                    .HasForeignKey(d => d.ProNoproposition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CORRESPOND_A4");
            });

            modelBuilder.Entity<Date>(entity =>
            {
                entity.HasKey(e => e.Datecontact)
                    .HasName("PRIMARY");

                entity.ToTable("dates");

                entity.Property(e => e.Datecontact).HasColumnName("DATECONTACT");
            });

            modelBuilder.Entity<Enseignant>(entity =>
            {
                entity.HasKey(e => e.Idfenseignant)
                    .HasName("PRIMARY");

                entity.ToTable("enseignants");

                entity.Property(e => e.Idfenseignant)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("IDFENSEIGNANT");

                entity.Property(e => e.Datevisite).HasColumnName("DATEVISITE");

                entity.Property(e => e.Nomenseignant)
                    .HasMaxLength(50)
                    .HasColumnName("NOMENSEIGNANT");

                entity.Property(e => e.Prenomenseignant)
                    .HasMaxLength(50)
                    .HasColumnName("PRENOMENSEIGNANT");
            });

            modelBuilder.Entity<Entreprise>(entity =>
            {
                entity.HasKey(e => e.Noentreprise)
                    .HasName("PRIMARY");

                entity.ToTable("entreprises");

                entity.HasIndex(e => e.Idfenseignant, "FK_DERNIERE_VISITE");

                entity.Property(e => e.Noentreprise)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("NOENTREPRISE");

                entity.Property(e => e.Addresse)
                    .HasMaxLength(100)
                    .HasColumnName("ADDRESSE");

                entity.Property(e => e.Idfenseignant)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDFENSEIGNANT");

                entity.Property(e => e.Nomentreprise)
                    .HasMaxLength(50)
                    .HasColumnName("NOMENTREPRISE");

                entity.HasOne(d => d.IdfenseignantNavigation)
                    .WithMany(p => p.Entreprises)
                    .HasForeignKey(d => d.Idfenseignant)
                    .HasConstraintName("FK_DERNIERE_VISITE");
            });

            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.HasKey(e => e.Idfetudiant)
                    .HasName("PRIMARY");

                entity.ToTable("etudiants");

                entity.HasIndex(e => e.Noconvention, "FK_SIGNE3");

                entity.HasIndex(e => e.ConNoconvention, "FK_SIGNE4");

                entity.Property(e => e.Idfetudiant)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("IDFETUDIANT");

                entity.Property(e => e.ConNoconvention)
                    .HasColumnType("int(11)")
                    .HasColumnName("CON_NOCONVENTION");

                entity.Property(e => e.Noconvention)
                    .HasColumnType("int(11)")
                    .HasColumnName("NOCONVENTION");

                entity.Property(e => e.Nometudiant)
                    .HasMaxLength(50)
                    .HasColumnName("NOMETUDIANT");

                entity.Property(e => e.Prenometudiant)
                    .HasMaxLength(50)
                    .HasColumnName("PRENOMETUDIANT");

                entity.HasOne(d => d.ConNoconventionNavigation)
                    .WithMany(p => p.EtudiantConNoconventionNavigations)
                    .HasForeignKey(d => d.ConNoconvention)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SIGNE4");

                entity.HasOne(d => d.NoconventionNavigation)
                    .WithMany(p => p.EtudiantNoconventionNavigations)
                    .HasForeignKey(d => d.Noconvention)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SIGNE3");
            });

            modelBuilder.Entity<Propositionsstage>(entity =>
            {
                entity.HasKey(e => e.Noproposition)
                    .HasName("PRIMARY");

                entity.ToTable("propositionsstage");

                entity.HasIndex(e => e.ConNoconvention, "FK_CORRESPOND_A");

                entity.HasIndex(e => e.Noconvention, "FK_CORRESPOND_A2");

                entity.HasIndex(e => e.Noentreprise, "FK_PROPOSE");

                entity.Property(e => e.Noproposition)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("NOPROPOSITION");

                entity.Property(e => e.ConNoconvention)
                    .HasColumnType("int(11)")
                    .HasColumnName("CON_NOCONVENTION");

                entity.Property(e => e.Dateproposition).HasColumnName("DATEPROPOSITION");

                entity.Property(e => e.Duree).HasColumnName("DUREE");

                entity.Property(e => e.Noconvention)
                    .HasColumnType("int(11)")
                    .HasColumnName("NOCONVENTION");

                entity.Property(e => e.Noentreprise)
                    .HasColumnType("int(11)")
                    .HasColumnName("NOENTREPRISE");

                entity.Property(e => e.Remuneration)
                    .HasPrecision(7, 3)
                    .HasColumnName("REMUNERATION");

                entity.Property(e => e.Sujetpropose)
                    .HasMaxLength(50)
                    .HasColumnName("SUJETPROPOSE");

                entity.HasOne(d => d.ConNoconventionNavigation)
                    .WithMany(p => p.PropositionsstageConNoconventionNavigations)
                    .HasForeignKey(d => d.ConNoconvention)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CORRESPOND_A");

                entity.HasOne(d => d.NoconventionNavigation)
                    .WithMany(p => p.PropositionsstageNoconventionNavigations)
                    .HasForeignKey(d => d.Noconvention)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CORRESPOND_A2");

                entity.HasOne(d => d.NoentrepriseNavigation)
                    .WithMany(p => p.Propositionsstages)
                    .HasForeignKey(d => d.Noentreprise)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROPOSE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
