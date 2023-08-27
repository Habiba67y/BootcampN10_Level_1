using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N32_T4
{
    public class OptimizedMusicService : MusicService
    {
        public List<Music> musics = new List<Music>();
        public Music CurrentMusic { get; set; }
        //public OptimizedMusicService(Music music)
        //{
        //    CurrentMusic = music;
        //}
        private void SwitchToFirst()
        {
            CurrentMusic = musics[0];
        }
        private void SwitchToLast()
        {
            CurrentMusic = musics[musics.Count() - 1];
        }
        private bool IsCurrentTheLastOne()
        {
            if (CurrentMusic.Equals(musics[musics.Count() - 1]))
                return true;
            return false;
        }
        private bool IsCurrentTheFirstOne()
        {
            if (CurrentMusic.Equals(musics[0]))
                return true;
            return false;
        }
        public override void SwitchNext()
        {
            if(IsCurrentTheLastOne())
                SwitchToFirst();
            else
                CurrentMusic = musics[musics.IndexOf(CurrentMusic) + 1];
        }
        public override void SwitchPrevious()
        {
            if (IsCurrentTheFirstOne())
                SwitchToLast();
            else
                CurrentMusic = musics[musics.IndexOf(CurrentMusic) - 1];
        }
        public override void DisplayCurrentSong()
        {
            Console.WriteLine("Currently playing {{MusicName}} - {{SingerName}}".Replace("{{MusicName}}", CurrentMusic.Name)
                .Replace("{{SingerName}}", CurrentMusic.SingerName));
        }
        public override void Add(Music music)
        {
            var e = false;
            foreach (var item in musics)
            {
                if (item.Equals(music))
                    e = true;
            }
            if (!e)
                musics.Add(music);
        }

    }
}
