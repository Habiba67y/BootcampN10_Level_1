var mp = new MusicPlayer();
mp.tracks.Add(new Track()
{
    name = "Why'd you only call me when you're high",
    author = "Artic Monkeys",
});
mp.tracks.Add(new Track()
{
    name = "Here",
    author = "Alessia Cara",
});
mp.tracks.Add(new Track()
{
    name = "Say it right",
    author = "Nelly Furtado",
});
mp.currentTrack= mp.tracks[0];
while (true)
{
    Console.Write("\nChoose a command:\n\nNext - n\nPrevious - p\nPause - pause\nPlay - play\nExit - e\n\n=> ");
    var choise = Console.ReadLine();
    if ("play".Equals(choise, StringComparison.OrdinalIgnoreCase))
    {
        mp.Play(mp.currentTrack);
    }
    else if ("pause".Equals(choise, StringComparison.OrdinalIgnoreCase))
    {
        mp.Pause(mp.currentTrack);
    }
    else if (choise == "n")
    {
        mp.Next(mp.tracks);
    }
    else if(choise == "p")
    {
        mp.Previous(mp.tracks);
    }
    else if(choise == "e")
    {
        break;
    }
    else
    {
        Console.WriteLine("Wrong command");
    }
}
public class MusicPlayer
{
    public List<Track> tracks = new List<Track>();
    public Track currentTrack = new Track();
    public void Next(List<Track> tracks)
    {
        var index = tracks.IndexOf(currentTrack);
        if ( index < tracks.Count-1)
        {
            Console.WriteLine($"Playing {index + 2}-track:\n{tracks[index+1].author} - {tracks[index+1].name}");
            currentTrack = tracks[index + 1];
        }
        else
        {
            Console.WriteLine($"End of tracks, playing 1-track:\n{tracks[0].author} - {tracks[0].name}");
            currentTrack = tracks[0];
        }
    }
    public void Previous(List<Track> tracks)
    {
        var index = tracks.IndexOf(currentTrack);
        if (index > 0)
        {
            Console.WriteLine($"Playing {index}-track:\n{tracks[index - 1].author} - {tracks[index - 1].name}");
            currentTrack = tracks[index - 1];
        }
        else
        {
            Console.WriteLine($"Beginning of tracks, playing {tracks.Count}-track:\n{tracks[tracks.Count - 1].author} - {tracks[tracks.Count - 1].name}");
            currentTrack = tracks[tracks.Count-1];
        }
    }
    public void Pause(Track track)
    {
        Console.WriteLine($"Paused {track.author} - {track.name}");
    }
    public void Play(Track track)
    {
        Console.WriteLine($"Playing {track.author} - {track.name}");
    }
}
public class Track
{
    public string name { get; set; }
    public string author { get; set; }
}