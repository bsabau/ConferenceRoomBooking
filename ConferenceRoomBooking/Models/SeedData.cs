using System;
using System.Linq;
using ConferenceRoomBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConferenceRoomBooking.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ConferenceRoomBookingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ConferenceRoomBookingContext>>()))
            {
                // Look for any Users.
                if  (!context.User.Any())
                {
                    context.User.AddRange(
                        new User
                        {
                            Email = "bogdan.sabau@gmail.com",
                            FirstName = "Bogdan",
                            LastName = "Sabau",
                            IsAdmin = true
                        },

                        new User
                        {
                            Email = "stefan.voda@gmail.com",
                            FirstName = "Stefan",
                            LastName = "Voda",
                            IsAdmin = false
                        },

                        new User
                        {
                            Email = "gheorghe.doja@gmail.com",
                            FirstName = "Gheorghe",
                            LastName = "Doja",
                            IsAdmin = true
                        }
                    );

                    context.SaveChanges();
                }

                // Look for any Rooms.
                if (!context.Room.Any())
                {
                    context.Room.AddRange(
                        new Room
                        {
                            Name = "Atlas",
                            Capacity = 5,
                            Description = "The only one with a big screen"
                        },

                        new Room
                        {
                            Name = "Jupiter",
                            Capacity = 25,
                            Description = "For big presentations only"
                        },

                        new Room
                        {
                            Name = "Ceres",
                            Capacity = 10
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}