using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Product> Products => Set<Product>();
}
