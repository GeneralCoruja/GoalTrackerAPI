namespace TestAPI.Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using System;

    class AppDbContext(DbContextOptions<AppDbContext> options) :
        IdentityDbContext<MyUser>(options)
    {
    }
}
