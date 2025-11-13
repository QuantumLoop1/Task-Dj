using DomainModel;

namespace Task_Dj
{
    public interface IDJRepository
    {
        IEnumerable<DJ> GetAllDJs();
        DJ GetDJById(int id);
        IEnumerable<Track> GetTracksByDJId(int djId);
        void AddDJ(DJ dj);
    }
}