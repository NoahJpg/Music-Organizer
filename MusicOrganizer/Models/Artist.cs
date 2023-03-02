using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string ArtistName { get; set; }
    public int Id { get; }
    private static List<Artist> _instances = new List<Artist> { };

    public Artist(string artistName)
    {
      ArtistName = artistName;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }

  }
}