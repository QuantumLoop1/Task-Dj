using Task_Dj;

namespace DomainModel
{
    public interface IDjInMemoryRepository
    {
        IEnumerable<DJ> DJs { get; }
        IEnumerable<Track> Tracks { get; }
    }
}