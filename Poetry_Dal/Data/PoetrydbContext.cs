using Microsoft.EntityFrameworkCore;
using Models;


namespace Data;

public class PoetrydbContext : DbContext
{

    public PoetrydbContext()
    {
    }

    public PoetrydbContext(DbContextOptions<PoetrydbContext> options) : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Verse> Verses { get; set; }
    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Request> Requests { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
