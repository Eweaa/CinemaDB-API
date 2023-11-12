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

    public async Task TrySeedAsync2() { await Task.CompletedTask; }
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
        }

        //if (!_context.Actors.Any())
        //{
        //    var actors = new List<Actor>()
        //    {
        //        new Actor(){Name="Robert De Niro", Birthdate = new DateTime(1943, 08, 17, 0, 0, 0)},
        //        new Actor(){Name="Leonard DiCaprio", Birthdate = new DateTime(1974, 11, 11, 0, 0, 0)},
        //        new Actor(){Name="Jamie Foxx", Birthdate = new DateTime(1997, 12, 13, 0 , 0, 0)},
        //    };
        //    _context.Actors.AddRange(actors);
        //}

        //if (!_context.Movies.Any())
        //{
        //    var movies = new List<Movie>()
        //    {
        //        new Movie(){Name="Killers of The Flower Moon", DirectorId=1, ReleaseDate = new DateTime(2023, 10, 19, 0, 0, 0)},
        //        new Movie(){Name="Goodfellas", DirectorId = 1, ReleaseDate = new DateTime(1990, 09, 19, 0, 0, 0)},
        //        new Movie(){Name="Django Unchained", DirectorId = 2, ReleaseDate = new DateTime(2013, 01, 16, 0, 0, 0)},
        //        new Movie(){Name="The Godfather", DirectorId = 2, ReleaseDate = new DateTime(1973, 07, 26, 0, 0 ,0)},
        //    };
        //    _context.Movies.AddRange(movies);
        //}

        //if (!_context.Directors.Any())
        //{
        //    var directors = new List<Director>()
        //    {
        //        new Director(){Name="Martin Scorsese", Birthdate = new DateTime(1942, 11, 17, 0, 0, 0)},
        //        new Director(){Name="Quentin Tarantino", Birthdate = new DateTime(1963, 03, 27, 0, 0, 0)},
        //    };
        //    _context.Directors.AddRange(directors);
        //}

        //if (!_context.ActorMovies.Any())
        //{
        //    var actormovie = new List<ActorMovie>()
        //    {
        //        new ActorMovie(){ActorId=2, MovieId=1},
        //        new ActorMovie(){ActorId=2, MovieId=2},
        //        new ActorMovie(){ActorId=3, MovieId=1},
        //        new ActorMovie(){ActorId=4, MovieId=3},
        //        new ActorMovie(){ActorId=4, MovieId=3},
        //    };
        //    _context.ActorMovies.AddRange(actormovie);
        //}

        //if (!_context.TvSeries.Any())
        //{
        //    var TvSerieses = new List<TvSeries>()
        //    {
        //        new TvSeries(){Name="Succession", ReleaseDate = new DateTime(2018, 08, 08, 0, 0, 0) ,},
        //        new TvSeries(){Name="The Sopranos", ReleaseDate = new DateTime(1999, 08, 08, 0, 0, 0)},
        //    };
        //    _context.TvSeries.AddRange(TvSerieses);
        //}

        //if (!_context.Seasons.Any())
        //{
        //    var Seasons = new List<Season>()
        //    {
        //        new Season(){ Name = "S1", ReleaseDate = new DateTime(2018, 08, 08, 0, 0, 0)},
        //        new Season(){ Name = "S2", ReleaseDate = new DateTime(2019, 08, 08, 0, 0, 0)},
        //        new Season(){ Name = "S3", ReleaseDate = new DateTime(2021, 08, 08, 0, 0, 0)},
        //        new Season(){ Name = "S4", ReleaseDate = new DateTime(2023, 08, 08, 0, 0, 0)},
        //    };
        //    _context.Seasons.AddRange(Seasons);
        //}

        //if (!_context.Episodes.Any())
        //{
        //    var Episodes = new List<Episode>()
        //    {
        //        new Episode(){Name="Celebration", },
        //        new Episode(){Name="Shit Show at the Fuck Factory", },
        //        new Episode(){Name="The Summer Palace", },
        //        new Episode(){Name="Vaulter", },
        //        new Episode(){Name="Secession", },
        //        new Episode(){Name="Mass in Time of War", },
        //        new Episode(){Name="The Munsters", },
        //        new Episode(){Name="Rehearsal", },
        //    };
        //    _context.Episodes.AddRange(Episodes);
        //}

        _context.SaveChanges();
    }
}
