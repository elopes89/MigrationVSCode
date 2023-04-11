using AulaCrud.Models;
using Microsoft.EntityFrameworkCore;
namespace AulaCrud.Context;


public class MovieContext : DbContext
{

    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {

    }

    public DbSet<Movie>? Movies { get; set; }
}