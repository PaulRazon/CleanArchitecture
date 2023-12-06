using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection.Metadata.Ecma335;

streamerDbContext dbContext = new();
await MultipleEntitiesQuery();
//await AddNewDirectorWithVideo();
//await AddNewActorWithVideo();
//await AddNewStreamerWithVideoId();
//await TrackingAndNotTracking();
//await QueryLinq();
//await Querymethods();
//await QueryFilter();
//await AddNewRecords();

//QueryStreaming();

//Consulta con where

Console.WriteLine($"Presione cualquier tecla para terminar el programa");
Console.ReadKey();
//
async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext!.Videos!.Include(q => q.Actores)
    //    .FirstOrDefaultAsync(q=>q.Id==1);

    // var actor = await dbContext!.Actores!.Select(q => q.Nombre).ToListAsync();
    var videoWithDirector = await dbContext!.Videos!
        .Where(p=>p.Director !=null)
         .Include(q => q.Director)
         .Select(q =>
            new {
                Director_Nombre_Completo = $"{q.Director.Nombre} - {q.Director.Apellido}",
                Movie = q.Nombre
            }

          ).ToListAsync();

    foreach (var pelicula in videoWithDirector) {
        Console.WriteLine($"{pelicula.Movie} - {pelicula.Director_Nombre_Completo}");
    }
}
//
async Task AddNewDirectorWithVideo() 
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Baster1",
        videoId = 1
    };
    await dbContext.AddAsync( director );
    await dbContext.SaveChangesAsync();
}
//
async Task AddNewActorWithVideo() {
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "pit"

    };
    await dbContext!.AddAsync(actor);
    await dbContext!.SaveChangesAsync();
    var videosActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await dbContext!.AddAsync(videosActor);
    await dbContext!.SaveChangesAsync();
}
//
async Task AddNewStreamerWithVideoId()
{
    var hungerGames = new Video
    {
        Nombre = "Batman Forever",
        StreamerId = 4 
    };
    await dbContext!.AddAsync(hungerGames);
    await dbContext!.SaveChangesAsync();
}
//
async Task AddNewStreamerWithVideo()
{

    var pantaya = new Streamer
    {
        Nombre = "Pantaya"
    };

    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantaya
    };
    await dbContext!.AddAsync( hungerGames );
    await dbContext!.SaveChangesAsync();
}
//
async Task TrackingAndNotTracking() {
    var streamerWithTraking = await dbContext!.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWithNoTraking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);
    streamerWithTraking.Nombre = "Netflix Super";
    streamerWithNoTraking.Nombre = "Amazon Plus";

    await dbContext!.SaveChangesAsync();


}
//
async Task QueryLinq() {
    Console.WriteLine($"Ingrese el servicio de streaming");
    var streamingNombre = Console.ReadLine();
    var streamers = await (from i in dbContext.Streamers
                           where EF.Functions.Like(i.Nombre,$"{streamingNombre}")
                           select i).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id}- {streamer.Nombre}");
    }
}
//
async Task Querymethods() {
    var streamer = dbContext!.Streamers!;
    //ejemplo1
    var firstAsync =await streamer.Where(y => y.Nombre.Contains("a")).FirstAsync();
    //ejemplo2
    var firstOrDefaultAsync = await streamer.Where(y => y.Nombre.Contains("a")).FirstOrDefaultAsync();
    //ejemplo3
    var fisrtOrDefault_v2 = await streamer.FirstOrDefaultAsync(y=>y.Nombre.Contains("a"));
    //ejemplo4
    var singleAsync = await streamer.Where(y=>y.Id==1).SingleAsync();
    //ejemplo 5
    var singleOrDefaultAsync = await streamer.Where(y => y.Id == 1).SingleOrDefaultAsync();

    var resultado = await streamer.FindAsync(1);
}
async Task QueryFilter()
{
    Console.WriteLine($"Ingrese una compañia de Streaming");
    var streamingNombre = Console.ReadLine();
    var streamers = await dbContext.Streamers!.Where(x => x.Nombre.Equals(streamingNombre)).ToListAsync();
    foreach (var streamer in streamers) { 
        Console.WriteLine($"{streamer.Id}- {streamer.Nombre}");
    }

    //var streamerPartialResult = await dbContext!.Streamers!.Where(x => x.Nombre.Contains(streamingNombre)).ToListAsync();
    var streamerPartialResult = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x.Nombre,$"%{streamingNombre}%")).ToListAsync();
    foreach (var streamer in streamerPartialResult) {
        Console.WriteLine($"{streamer.Id}- {streamer.Nombre}");
    }
}
void QueryStreaming ()
{ 
    var streamers = dbContext!.Streamers!.ToList();
    foreach (var streamer in streamers) { 
        Console.WriteLine($"{streamer.Id}- {streamer.Nombre}");
    }

}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "https://www.disney.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    var movies = new List<Video>{
    new Video{
        Nombre = "Mickey Mouse",
        StreamerId = streamer.Id,
    },
    new Video{
        Nombre = "Cenicienta",
        StreamerId = streamer.Id,
    },
    new Video{
        Nombre = "1001 dalmatas",
        StreamerId = streamer.Id,
    },
    new Video{
        Nombre = "Tarzan",
        StreamerId = streamer.Id,
    }
};

    await dbContext.AddRangeAsync(movies); //añade un rango de datos
    await dbContext.SaveChangesAsync();

}

