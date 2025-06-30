using Microsoft.EntityFrameworkCore;

namespace VideoGameApi.Data
{
    public class VideoGameDBContext(DbContextOptions<VideoGameDBContext> options)
        : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "The Legend of Zelda: Breath of the Wild",
                    Platform = "Nintendo Switch",
                    Developer = "Nintendo EPD",
                    Publisher = "Nintendo"
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "God of War Ragnarok",
                    Platform = "PlayStation 5",
                    Developer = "Santa Monica Studio",
                    Publisher = "Sony Interactive Entertainment"
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "Halo Infinite",
                    Platform = "Xbox Series X",
                    Developer = "343 Industries",
                    Publisher = "Xbox Game Studios"
                },
                new VideoGame
                {
                    Id = 4,
                    Title = "Elden Ring",
                    Platform = "PC",
                    Developer = "FromSoftware",
                    Publisher = "Bandai Namco Entertainment"
                },
                new VideoGame
                {
                    Id = 5,
                    Title = "Grand Theft Auto V",
                    Platform = "PlayStation 4",
                    Developer = "Rockstar North",
                    Publisher = "Rockstar Games"
                }
            );
        }
    }
}
