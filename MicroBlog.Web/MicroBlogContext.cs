using MicroBlog.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MicroBlog.Web;

public class MicroBlogContext(DbContextOptions<MicroBlogContext> options)
    : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Post> Post { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}