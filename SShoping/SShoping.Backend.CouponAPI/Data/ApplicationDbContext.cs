using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SShoping.Backend.CouponAPI.Models;

namespace SShoping.Backend.CouponAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}
    
    public DbSet<Coupon> Coupons { get; set; }
}