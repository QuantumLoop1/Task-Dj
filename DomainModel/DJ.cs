using System.Collections;

namespace Task_Dj
{
    public class DJ
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
