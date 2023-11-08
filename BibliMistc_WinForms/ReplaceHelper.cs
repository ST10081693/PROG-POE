using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BibliMistc_WinForms
{
    internal class ReplaceHelper
    {

        //----------------------------------Method responsible for playing the music when the user sort the books in time-----------------------------------//

        public static void PlayWinningMusic()
        {
            Form1.player.Stop();
            var winningMusicPlayer = new SoundPlayer(Properties.Resources.win);
            winningMusicPlayer.Play();

            var timer = new System.Timers.Timer
            {
                Interval = 3000
            };
            timer.Elapsed += (s, e) =>
            {
                Form1.player.PlayLooping();
                timer.Stop();
            };
            timer.Start();
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------------------Method responsible for playing the music when the user fails to organize the books in time-------------------------//

        public static void PlayFailureMusic()
        {
            Form1.player.Stop();
            var failureMusicPlayer = new SoundPlayer(Properties.Resources.fail);
            failureMusicPlayer.Play();

            var timer = new System.Timers.Timer
            {
                Interval = 5000
            };
            timer.Elapsed += (s, e) =>
            {
                Form1.player.PlayLooping();
                timer.Stop();
            };
            timer.Start();
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//
    }
}
