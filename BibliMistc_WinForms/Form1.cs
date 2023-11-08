using System;
using System.Media;
using System.Windows.Forms;

namespace BibliMistc_WinForms
{

    /*
    Name: Rui Manuel
    Student number: ST10081693
    Assignment: PROG Part 1
    */

    /*The code in this project was extracted from chatgpt as well as the following video: 'https://youtu.be/qXkVEIXmwjw?si=IuuW_KHo0ABuJjjQ'*/
    public partial class Form1 : Form
    {
        //Sound player created to play the music.
        public static SoundPlayer player;


        //-------------------------------------Constructor that will located, load and play the music in a loop.-------------------------------------------//

        public Form1()
        {
            InitializeComponent();

                player = new SoundPlayer(Properties.Resources.firstmusic);
                player.Load();  
                player.PlayLooping();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//


        //---------------------------------Method that will be responsible for the star button click at the beginning----------------------------------------//

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menuwind menuwind = new Menuwind();
            menuwind.Show();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//
    }
}
