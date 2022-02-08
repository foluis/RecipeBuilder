using Microsoft.EntityFrameworkCore;
using RecipeBuilder.Entities.DTOs;

namespace RecipeBuilder.API.Context
{
    public partial class RecipeBuilderContext : DbContext
    {
        public RecipeBuilderContext()
        {
        }

        public RecipeBuilderContext(DbContextOptions<RecipeBuilderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblClient> TblClients { get; set; } = null!;
        public virtual DbSet<TblIngredient> TblIngredients { get; set; } = null!;
        public virtual DbSet<TblIngredientType> TblIngredientTypes { get; set; } = null!;
        public virtual DbSet<TblRecipe> TblRecipes { get; set; } = null!;
        public virtual DbSet<TblRecipeIngredient> TblRecipeIngredients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=RecipeBuilder;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblClient>(entity =>
            {
                entity.ToTable("tblClient");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("tblClient_HISTORY", "dbo");
        ttb
            .HasPeriodStart("SysStart")
            .HasColumnName("SysStart");
        ttb
            .HasPeriodEnd("SysEnd")
            .HasColumnName("SysEnd");
    }
));

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblIngredient>(entity =>
            {
                entity.ToTable("tblIngredient");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("tblIngredient_HISTORY", "dbo");
        ttb
            .HasPeriodStart("SysStart")
            .HasColumnName("SysStart");
        ttb
            .HasPeriodEnd("SysEnd")
            .HasColumnName("SysEnd");
    }
));

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TblIngredients)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIngredient_tblIngredientType");
            });

            modelBuilder.Entity<TblIngredientType>(entity =>
            {
                entity.ToTable("tblIngredientType");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("tblIngredientType_HISTORY", "dbo");
        ttb
            .HasPeriodStart("SysStart")
            .HasColumnName("SysStart");
        ttb
            .HasPeriodEnd("SysEnd")
            .HasColumnName("SysEnd");
    }
));

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRecipe>(entity =>
            {
                entity.ToTable("tblRecipe");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("tblRecipe_HISTORY", "dbo");
        ttb
            .HasPeriodStart("SysStart")
            .HasColumnName("SysStart");
        ttb
            .HasPeriodEnd("SysEnd")
            .HasColumnName("SysEnd");
    }
));

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRecipeIngredient>(entity =>
            {
                entity.ToTable("tblRecipeIngredients");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("tblRecipeIngredients_HISTORY", "dbo");
        ttb
            .HasPeriodStart("SysStart")
            .HasColumnName("SysStart");
        ttb
            .HasPeriodEnd("SysEnd")
            .HasColumnName("SysEnd");
    }
));

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.TblRecipeIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRecipeIngredients_tblIngredient");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.TblRecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRecipeIngredients_tblRecipe");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}