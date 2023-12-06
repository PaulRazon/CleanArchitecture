
using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockVideoRepository
    {
        public static void AddVideoRepository(streamerDbContext streamerDbContextFake) {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var videos = fixture.CreateMany<Video>().ToList();

            videos.Add(fixture.Build<Video>().With(tr => tr.CreatedBy, "Paul").Create());
            //base de datos en memoria
          
            streamerDbContextFake.Videos!.AddRange(videos);
            streamerDbContextFake.SaveChanges();
            //
            
        }
    }
}
