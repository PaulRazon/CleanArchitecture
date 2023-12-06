
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(streamerDbContext context, ILogger<StreamerDbContextSeed> logger) {
            if (!context.Streamers!.Any()) {
                context.Streamers!.AddRange(GetPreConfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos elementos al db{context}",typeof(streamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreConfiguredStreamer()
        {
            return new List<Streamer>()
            {
                new Streamer
                {
                    CreatedBy ="Paul",
                    Nombre ="HBO PLUS",
                    Url="https://HBO.com"
                },
                new Streamer
                {
                    CreatedBy = "Paul",
                    Nombre = "HBO VIP",
                    Url = "https://HBO.com"
                }

            };

        }
    }
}
