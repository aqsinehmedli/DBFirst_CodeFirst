using System;
using System.Collections.Generic;
using DBFirst_CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBFirst_CodeFirst.Context;

public partial class Library1Context : DbContext
{
    public Library1Context()
    {
    }

    public Library1Context(DbContextOptions<Library1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookType> BookTypes { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentBook> StudentBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-0MV3INK;Initial Catalog = Library1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC072635C43C");

            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07D5C5CA97");

            entity.Property(e => e.Name).HasMaxLength(20);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Books__AuthorId__4D94879B");

            entity.HasOne(d => d.BookType).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookTypeId)
                .HasConstraintName("FK__Books__BookTypeI__4E88ABD4");
        });

        modelBuilder.Entity<BookType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookType__3214EC077865436F");

            entity.ToTable("BookType");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EndDate).HasMaxLength(20);
            entity.Property(e => e.StartDate).HasMaxLength(20);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07BE03116E");

            entity.Property(e => e.Birthday).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<StudentBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentB__3214EC073BE964BB");

            entity.ToTable("StudentBook");

            entity.HasOne(d => d.Book).WithMany(p => p.StudentBooks)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__StudentBo__BookI__52593CB8");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentBooks)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentBo__Stude__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
