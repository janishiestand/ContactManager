using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.Repositories;
using EFDataAccessLibrary.Interfaces;
using EFDataAccessLibrary.DataAccess;

namespace ContactManagerApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        string? connectionString = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<ContactContext>(options => options.UseMySql(connectionString, serverVersion));

        #region Repositories
        builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddTransient<IContactRepository, ContactRepository>();
        #endregion

        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}

