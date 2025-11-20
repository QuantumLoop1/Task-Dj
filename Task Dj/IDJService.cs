using DomainModel;

namespace Task_Dj
{
    public interface IDJService
    {
        IEnumerable<DJ> GetAllDJs();
        DJ GetDJById(int id);
        IEnumerable<Track> GetTracksByDJId(int djId);
        void AddDJ(DJ dj);
    }
}