using System.Runtime.InteropServices;
using CinemaDB.Domain.Constants;
using CinemaDB.Domain.Entities;
using CinemaDB.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CinemaDB.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        // Default data
        // Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }

        if (!_context.Actors.Any())
        {
            var actors = new List<Actor>()
            {
                new Actor(){Name="Robert De Niro", Birthdate = new DateTime(1943, 8, 17)},
                new Actor(){Name="Leonard DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                new Actor(){Name="Jamie Foxx", Birthdate = new DateTime(1997, 12, 13)},
            };
            _context.Actors.AddRange(actors);
            await _context.SaveChangesAsync();
        }

        if (!_context.Movies.Any())
        {
            var movies = new List<Movie>()
            {
                new Movie(){Name="Killers of The Flower Moon", DirectorId=1, ReleaseDate=new DateTime(2023,10,19)},
                new Movie(){Name="Goodfellas", DirectorId = 1, ReleaseDate = new DateTime(1990, 9, 19)},
                new Movie(){Name="Django Unchained", DirectorId = 2, ReleaseDate = new DateTime(2013, 1, 16)},
                new Movie(){Name="The Godfather", DirectorId = 2, ReleaseDate = new DateTime(1973, 7, 26)},
            };
            _context.Movies.AddRange(movies);
            await _context.SaveChangesAsync();
        }

        if (!_context.Directors.Any())
        {
            var directors = new List<Director>()
            {
                new Director(){Name="Martin Scorsese", Birthdate = new DateTime(1942, 17, 11)},
                new Director(){Name="Quentin Tarantino", Birthdate = new DateTime(1963, 3, 27)},
            };
            _context.Directors.AddRange(directors);
            await _context.SaveChangesAsync();
        }

        //if (!_context.ActorMovie.Any())
        //{
        //    var actormovie = new List<ActorMovie>()
        //    {
        //        new ActorMovie(){ActorId=2, MovieId=1},
        //        new ActorMovie(){ActorId=2, MovieId=2},
        //        new ActorMovie(){ActorId=3, MovieId=1},
        //        new ActorMovie(){ActorId=4, MovieId=3},
        //        new ActorMovie(){ActorId=4, MovieId=3},
        //    };
        //    _context.ActorMovie.AddRange(actormovie);
        //    await _context.SaveChangesAsync();
        //}

    }
}
