using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N32_T4
{
    public abstract class MusicService
    {
        public virtual void SwitchNext()
        { }
        public virtual void SwitchPrevious() 
        { }
        public virtual void DisplayCurrentSong()
        { }
        public abstract void Add(Music music);
    }
}
