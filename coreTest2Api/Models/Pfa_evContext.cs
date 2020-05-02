using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coreTest2Api.Models
{
    public partial class Pfa_evContext : DbContext
    {
        public Pfa_evContext()
        {
        }

        public Pfa_evContext(DbContextOptions<Pfa_evContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Absence> Absence { get; set; }
        public virtual DbSet<Administrateur> Administrateur { get; set; }
        public virtual DbSet<AnneeScolaire> AnneeScolaire { get; set; }
        public virtual DbSet<Classe> Classe { get; set; }
        public virtual DbSet<DetailSeance> DetailSeance { get; set; }
        public virtual DbSet<Enseignant> Enseignant { get; set; }
        public virtual DbSet<Etudiant> Etudiant { get; set; }
        public virtual DbSet<Filiere> Filiere { get; set; }
        public virtual DbSet<Horaire> Horaire { get; set; }
        public virtual DbSet<Matiere> Matiere { get; set; }
        public virtual DbSet<Seance> Seance { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("server=MIC;database=Pfa_ev;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absence>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdEtu)
                    .HasColumnName("Id_Etu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdSeance)
                    .HasColumnName("Id_Seance")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEtuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEtu)
                    .HasConstraintName("FK__Absence__Id_Etu__2C3393D0");

                entity.HasOne(d => d.IdSeanceNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSeance)
                    .HasConstraintName("FK__Absence__Id_Sean__2D27B809");
            });

            modelBuilder.Entity<Administrateur>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Adresse)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cin)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cnss)
                    .HasColumnName("CNSS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateEmb)
                    .HasColumnName("Date_emb")
                    .HasColumnType("date");

                entity.Property(e => e.DateNais)
                    .HasColumnName("Date_nais")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.MotdePasse)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AnneeScolaire>(entity =>
            {
                entity.ToTable("Annee_Scolaire");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Annee)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdAnnee)
                    .HasColumnName("Id_Annee")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdEtu)
                    .HasColumnName("Id_Etu")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdFiliere)
                    .HasColumnName("Id_Filiere")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Libelle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAnneeNavigation)
                    .WithMany(p => p.Classe)
                    .HasForeignKey(d => d.IdAnnee)
                    .HasConstraintName("FK__Classe__Id_Annee__239E4DCF");

                entity.HasOne(d => d.IdEtuNavigation)
                    .WithMany(p => p.Classe)
                    .HasForeignKey(d => d.IdEtu)
                    .HasConstraintName("FK__Classe__Id_Etu__1920BF5C");

                entity.HasOne(d => d.IdFiliereNavigation)
                    .WithMany(p => p.Classe)
                    .HasForeignKey(d => d.IdFiliere)
                    .HasConstraintName("FK__Classe__Id_Filie__1CF15040");
            });

            modelBuilder.Entity<DetailSeance>(entity =>
            {
                entity.ToTable("Detail_Seance");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdEns)
                    .HasColumnName("Id_Ens")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdSeance)
                    .HasColumnName("Id_Seance")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sujet)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnsNavigation)
                    .WithMany(p => p.DetailSeance)
                    .HasForeignKey(d => d.IdEns)
                    .HasConstraintName("FK__Detail_Se__Id_En__300424B4");

                entity.HasOne(d => d.IdSeanceNavigation)
                    .WithMany(p => p.DetailSeance)
                    .HasForeignKey(d => d.IdSeance)
                    .HasConstraintName("FK__Detail_Se__Id_Se__30F848ED");
            });

            modelBuilder.Entity<Enseignant>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Adresse)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cin)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cnss)
                    .HasColumnName("CNSS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateEmb)
                    .HasColumnName("Date_emb")
                    .HasColumnType("date");

                entity.Property(e => e.DateNais)
                    .HasColumnName("Date_nais")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.MotdePasse)
                   .HasMaxLength(100)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Adresse)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cin)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cne)
                    .HasColumnName("CNE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateNais)
                    .HasColumnName("Date_nais")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdFiliere)
                    .HasColumnName("Id_Filiere")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFiliereNavigation)
                    .WithMany(p => p.Etudiant)
                    .HasForeignKey(d => d.IdFiliere)
                    .HasConstraintName("FK__Etudiant__Id_Fil__1BFD2C07");
                entity.Property(e => e.MotdePasse)
                   .HasMaxLength(100)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<Filiere>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Libelle)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Horaire>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Matiere>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdEns)
                    .HasColumnName("Id_Ens")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdFiliere)
                    .HasColumnName("Id_Filiere")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomMatiere)
                    .HasColumnName("Nom_Matiere")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnsNavigation)
                    .WithMany(p => p.Matiere)
                    .HasForeignKey(d => d.IdEns)
                    .HasConstraintName("FK__Matiere__Id_Ens__33D4B598");

                entity.HasOne(d => d.IdFiliereNavigation)
                    .WithMany(p => p.Matiere)
                    .HasForeignKey(d => d.IdFiliere)
                    .HasConstraintName("FK__Matiere__Id_Fili__34C8D9D1");
            });

            modelBuilder.Entity<Seance>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("_Date")
                    .HasColumnType("date");

                entity.Property(e => e.IdClasse)
                    .HasColumnName("Id_Classe")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdHoraire)
                    .HasColumnName("Id_Horaire")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Seance)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Seance__Id_Class__286302EC");

                entity.HasOne(d => d.IdHoraireNavigation)
                    .WithMany(p => p.Seance)
                    .HasForeignKey(d => d.IdHoraire)
                    .HasConstraintName("FK__Seance__Id_Horai__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        //public object checkemail(string email)
        //{
        //    var obj=new object();
        //    foreach(var admin in this.Administrateur)
        //    {
        //        if (admin.Email == email)
        //            obj = admin;
        //    }
        //    foreach(var admin in this.Etudiant)
        //    {
        //        if (admin.Email == email)
        //            obj = admin;
        //    }
        //    foreach(var admin in this.Enseignant)
        //    {
        //        if (admin.Email == email)
        //            obj = admin;
        //    }
        //    return obj;
        //}
    }
}
