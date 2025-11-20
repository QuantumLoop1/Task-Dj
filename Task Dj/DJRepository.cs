using Microsoft.Extensions.Options;
using System.Net;
using DomainModel;

namespace Task_Dj
{
    public class DJRepository : IDJService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DJRepository> _logger;
        private readonly IOptions<DJSettings> _settings;
        private readonly IDjInMemoryRepository _repository;

    public DJRepository(HttpClient httpClient, ILogger<DJRepository> logger, IOptions<DJSettings> settings, IDjInMemoryRepository repository)
    {
            _httpClient = httpClient;
            _logger = logger;
            _settings = settings;
            _repository = repository;
    }

        public void AddDJ(DJ dj)
        {
         var addJs = _repository.DJs.ToList();
         addJs.Add(dj);
        _logger.LogInformation("New Dj Add: {Dj}", addJs);
        }

        public IEnumerable<DJ> GetAllDJs()
        {
        var result = _repository.DJs.ToList();
        _logger.LogInformation("DJ count: {Count}", result.Count);
        _logger.LogInformation(
        " Max allowed: {Max}, Caching: {Cache}",
        _settings.Value.MaxTracksPerRequest,
          _settings.Value.EnableCaching);
            return result;
        }

        public DJ GetDJById(int id)
        {
        var result = _repository.DJs.FirstOrDefault(x => x.Id == id);
        _logger.LogInformation("First DJ: {DJName}", result.Name);
        return result;
        }

        public IEnumerable<Track> GetTracksByDJId(int djId)
        {
        var result = _repository.Tracks.Where(x => x.DJId == djId);
        return result;
        }
    }
}
