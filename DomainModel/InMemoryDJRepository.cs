using System.Collections.Generic;
using System.Linq;
using Task_Dj;

namespace DomainModel
{
    public class InMemoryDJRepository
    {
        private readonly List<DJ> _djs;
        private readonly List<Track> _tracks;

        public InMemoryDJRepository()
        {
            _djs = new List<DJ>
            {
                new DJ { Id = 1, Name = "Armin van Buuren", Genre = "Trance", Rating = 9 },
                new DJ { Id = 2, Name = "David Guetta", Genre = "House", Rating = 5 },
                new DJ { Id = 3, Name = "Carl Cox", Genre = "Techno", Rating = 10 },
                new DJ { Id = 4, Name = "Tiesto", Genre = "EDM", Rating = 8 },
                new DJ { Id = 5, Name = "Hardwell", Genre = "Big Room", Rating = 8 },
                new DJ { Id = 6, Name = "Deadmau5", Genre = "Progressive House", Rating = 7 },
            };

            _tracks = new List<Track>
            {
                new Track { Id = 1, Title = "In and Out of Love", DJId = 1, Duration = 260 },
                new Track { Id = 2, Title = "Blah Blah Blah", DJId = 1, Duration = 215 },
                new Track { Id = 3, Title = "Titanium", DJId = 2, Duration = 250 },
                new Track { Id = 4, Title = "Play Hard", DJId = 2, Duration = 240 },
                new Track { Id = 5, Title = "Inferno", DJId = 3, Duration = 290 },
                new Track { Id = 6, Title = "Time for House Music", DJId = 3, Duration = 280 },
                new Track { Id = 7, Title = "Adagio for Strings", DJId = 4, Duration = 265 },
                new Track { Id = 8, Title = "The Business", DJId = 4, Duration = 210 },
                new Track { Id = 9, Title = "Spaceman", DJId = 5, Duration = 240 },
                new Track { Id = 10, Title = "Apollo", DJId = 5, Duration = 245 },
                new Track { Id = 11, Title = "Ghosts 'n' Stuff", DJId = 6, Duration = 240 },
                new Track { Id = 12, Title = "Strobe", DJId = 6, Duration = 600 }
            };
        }

        public IEnumerable<DJ> DJs => _djs;

        public IEnumerable<Track> Tracks => _tracks;
    }
}
