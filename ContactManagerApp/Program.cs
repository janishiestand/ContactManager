﻿using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.Repositories;
using EFDataAccessLibrary.Interfaces;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using System.Text.Json;
using System.Threading;
using Microsoft.Extensions.Hosting;

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

        builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddTransient<IContactRepository, ContactRepository>();

        builder.Services.AddRazorPages();
        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var _db = scope.ServiceProvider.GetRequiredService<IContactRepository>();

            if (_db.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("sampledata.json");
                var contacts = JsonSerializer.Deserialize<List<Contact>>(file);
                _db.AddRangeAsync(contacts, CancellationToken.None).GetAwaiter().GetResult();
                _db.SaveChangesAsync(CancellationToken.None).GetAwaiter().GetResult();
                return;
            }
        }
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

