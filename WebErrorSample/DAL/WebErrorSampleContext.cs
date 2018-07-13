namespace WebErrorSample.DAL
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WebErrorSampleContext : DbContext
    {
        public DbSet<ParentEntity> Parents { get; set; }

        public DbSet<ChildEntity> Children { get; set; }

        public DbSet<ToyEntity> Toys { get; set; }

        public DbSet<ToyCategoryEntity> ToyCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var parents = new List<ParentEntity>();
            for (int i = 1; i < 6; i++)
            {
                parents.Add(new ParentEntity { ParentEntityId = i, ParentName = $"Parent {i}" });
            }

            var toyCategories = new List<ToyCategoryEntity>();
            for (int i = 1; i < 6; i++)
            {
                toyCategories.Add(new ToyCategoryEntity { CategoryName = $"Category {i}", ToyCategoryEntityId = i });
            }

            var children = new List<ChildEntity>();
            var childCount = 1;

            var toys = new List<ToyEntity>();
            var toyCount = 1;
            foreach (var p in parents)
            {
                for (int i = 1; i < 6; i++)
                {
                    children.Add(new ChildEntity { ChildEntityId = childCount, ChildName = $"Child {childCount}", ParentEntityId = p.ParentEntityId });
                    toys.Add(new ToyEntity { ToyCategoryEntityId = i, ToyEntityId = toyCount, ToyName = $"Toy {toyCount}", ChildEntityId = childCount });

                    childCount++;
                    toyCount++;
                }
            }

            modelBuilder.Entity<ParentEntity>().HasData(parents.ToArray());
            modelBuilder.Entity<ChildEntity>().HasData(children.ToArray());
            modelBuilder.Entity<ToyEntity>().HasData(toys.ToArray());
            modelBuilder.Entity<ToyCategoryEntity>().HasData(toyCategories.ToArray());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebErrorSample;Trusted_Connection=True;");
        }
    }

    public class ParentEntity
    {
        public int ParentEntityId { get; set; }

        public string ParentName { get; set; }

        public virtual ICollection<ChildEntity> Children { get; set; }
    }

    public class ChildEntity
    {
        public int ChildEntityId { get; set; }

        public int ParentEntityId { get; set; }

        public string ChildName { get; set; }

        public virtual ParentEntity Parent { get; set; }

        public virtual ToyEntity Toy { get; set; }
    }

    public class ToyEntity
    {
        public int ToyEntityId { get; set; }

        public int ChildEntityId { get; set; }

        public int ToyCategoryEntityId { get; set; }

        public string ToyName { get; set; }

        public virtual ChildEntity Child { get; set; }

        public virtual ToyCategoryEntity Category { get; set; }
    }

    public class ToyCategoryEntity
    {
        public int ToyCategoryEntityId { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<ToyEntity> Toys { get; set; }
    }

}