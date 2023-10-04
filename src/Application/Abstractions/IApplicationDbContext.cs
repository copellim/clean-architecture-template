﻿using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<Product> Products { get; }
}
