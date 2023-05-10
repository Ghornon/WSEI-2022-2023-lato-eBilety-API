using eBilety.Data.Enums;
using eBilety.Data.Static;
using eBilety.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace eBilety.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Data seeds

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Multikino",
                            Logo = "https://miastodzieci.pl/wp-content/uploads/2016/07/multikino-logo-p%C5%82askie.jpg",
                            Description = "Sieć kin Multikino: premiery i maratony filmowe. Sprawdź aktualny repertuar i kup bilet on-line!"
                        },
                        new Cinema()
                        {
                            Name = "Cinema City",
                            Logo = "https://www.cinema-city.pl/mrest/logos/v1/10103/logo.svg",
                            Description = "DOŚWIADCZENIE KINOWE PRZEKRACZAJĄCE GRANICE WYOBRAŹNI. Ten moment kiedy przenosisz się do innej epoki lub galaktyki. Przebłysk akustycznej przezroczystości dźwięku, która powoduje przyspieszone bicie serca. Chwila w której zapominasz o otaczającym Cię świecie. Gdy zaczynasz się śmiać, a chwilę potem śmieje się cała sala."
                        },
                        new Cinema()
                        {
                            Name = "Helios",
                            Logo = "https://www.helios.pl/img/logo.helios_ua.png",
                            Description = "Kino Konesera; Kino Kobiet; Maratony filmowe; Helios dla dzieci; Kultura Dostępna; Helios na scenie; Grupy. Oferta dla firm; Helios dla szkoły; Akademia Filmowa; Kino na Temat; Kino na Temat Jr; Kino."
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3D",
                            Logo = "https://cinema3d.pl/images/logo-green.svg",
                            Description = "Sieć kin Cinema 3D: premiery i maratony filmowe."
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Mila Kunis",
                            Bio = "Milena Markiwna Kunis urodziła się 14 sierpnia 1983 roku w Czerniowcach w ZSRR (obecnie Ukraina). Jej matka, Elwira, jest nauczycielką fizyki, zaś ojciec, Mark, inżynierem pracującym jako kierowca taksówki.",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/811vCRSr9s2MFwCIOo1jWHltu3R.jpg"

                        },
                        new Actor()
                        {
                            FullName = "Jason Statham",
                            Bio = "Jason Statham (urodzony 26 lat). Juli 1967) jest angielskim aktorem i artystą walki, znanym z ról w filmach kryminalnych Guya Ritchiego: Lock, Stock and Two Smoking Barrels; Revolver; and Snatch. ",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/lldeQ91GwIVff43JBrpdbAAeYWj.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Liam Neeson",
                            Bio = "Zanim został aktorem zarabiał na życie jako bokser i kierowca ciężarówki. W 1976 roku przyłączył się do Lyric Players' Theater w Belfaście. Po przeprowadzce do Dublina rozpoczął współpracę z Abbey Theater.",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/bboldwqSC6tdw2iL6631c98l2Mn.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Matt Damon",
                            Bio = "Gdy miał niecałe dwa lata, jego ojciec opuścił rodzinę. W wieku 16 lat wystąpił w reklamówce, ale na prawdziwą popularność musiał jednak jeszcze zaczekać.",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/At3JgvaNeEN4Z4ESKlhhes85Xo3.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Margot Robbie",
                            Bio = "Urodzona 2 lipca 1990 r w Dalby, Queensland (Australia). Jej matka Sarie Kessler zajmuje fizjoterapią, a jej ojcem jest Doug Robbie, ma również dwóch braci i jedną siostrę.",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/euDPyqLnuwaWMHajcU3oZ9uZezR.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "James Cameron",
                            Bio = "James Cameron was born in Kapuskasing, Ontario, Canada, on August 16, 1954",
                            Avatar = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/9NAZnTjBQ9WcXAQEzZpKy4vdQto.jpg"

                        },
                        new Producer()
                        {
                            FullName = "Christopher McQuarrie",
                            Bio = "Christopher McQuarrie is an American screenwriter, producer and director. ",
                            Avatar = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/82W339V8turXUdaCajqOyekxhmD.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Steve Kloves",
                            Bio = "Steve Kloves, born in Austin, Texas, grew up in Sunnyvale, California, where he graduated from Fremont High School.",
                            Avatar = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/tkkE99QkVM1ofplEIIHoS709jVk.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Art Marcum",
                            Bio = "Biografia",
                            Avatar = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/yX4gYCclvjBzGFKPVB8cp4eKksH.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Joe Stillman",
                            Bio = "oseph Stillman is a television and movie writer, producer and director.",
                            Avatar = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/7OItqsvl8ewVlJHBky3mz6uauOd.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Avatar: Istota wody",
                            Description = "Avatar: Istota wody będzie po raz kolejny podążać za Jake'em Sully'em Sama Worthingtona dwanaście lat po odkryciu Pandory i dołączeniu do Na'vi. ",
                            Price = 21.90,
                            ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/Ajs7ZyNjGMHIiATMygxMkOFeTko.jpg",
                            StartDate = DateTime.Now.AddDays(-20),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 3,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.SciFi
                        },
                        new Movie()
                        {
                            Name = "Titanic",
                            Description = "Jake i Rose (Leonardo DiCaprio i Kate Winslet), para młodych kochanków, poznają i zakochują się podczas dziewiczego rejsu \"niezatapialnego\" transatlantyku Titanic. ",
                            Price = 15.00,
                            ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/9xjZS2rlVxm8SFx8kPC3aIGCOYQ.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Dramat
                        },
                        new Movie()
                        {
                            Name = "Harry Potter i Kamień Filozoficzny",
                            Description = "Harry Potter dowiaduje się, w dniu swoich 11-tych urodzin, że jest osieroconym dzieckiem dwojga potężnych czarodziejów i sam posiada magiczne zdolności.",
                            Price = 19.99,
                            ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/wNRk1vec98vfAQa2YdZOt7h0DGe.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Przygodowy
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Dokumnetlany
                        },
                        new Movie()
                        {
                            Name = "Shrek Forever ",
                            Description = "Czym zajmują się ogry, kiedy już rozprawią się ze straszliwym smokiem, poślubią piękną królewnę i ocalą królestwo teścia? Shrek został pantoflarzem",
                            Price = 23.50,
                            ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/mAn7hsIH0HgVVQOylvldl1HzySE.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Komedia
                        },
                        new Movie()
                        {
                            Name = "Szybcy i Wściekli 7",
                            Description = "Tej prędkości, tej wściekłości nigdy dość! Dominic Toretto (Vin Diesel), Brian O'Conner (Paul Walker), Letty Ortiz (Michelle Rodriguez) i inni szybcy i wściekli wracają na ekrany kin.",
                            Price = 30.00,
                            ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/gLykdhxIgWRHN39ur2YBC4FHYaC.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Akcja
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.ActorsMovies.Any())
                {
                    context.ActorsMovies.AddRange(new List<ActorMovie>()
                    {
                        new ActorMovie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new ActorMovie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new ActorMovie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new ActorMovie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new ActorMovie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new ActorMovie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new ActorMovie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new ActorMovie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new ActorMovie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new ActorMovie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new ActorMovie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new ActorMovie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new ActorMovie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new ActorMovie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new ActorMovie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new ActorMovie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new ActorMovie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin Admin",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@1234!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "jan.kowalski@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Jan Kowalski",
                        UserName = "jan-kowalski",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Janek@1234!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
