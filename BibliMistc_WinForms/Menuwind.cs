using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliMistc_WinForms
{
    public partial class Menuwind : Form
    {
        //Constructor with disabled buttons that will be used at a later stage.
        public Menuwind()
        {
            InitializeComponent();
        }


        //------------------------------------------------Method responsible for the Replace Books click.-------------------------------------------------//


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Replace_Books replace_Books = new Replace_Books();
            replace_Books.Show();
            MessageBox.Show("Your task is to sort the books according to the Dewey Decimal Classification (DDC) system. Here is how it works:" +
                "\n\n\n1. Each book has a call number based on the DDC system." +
                "\n\n2. The call number starts with a number ranging from 000 to 999, which classifies the book into one of the main DDC classes." +
                "\n\n3. Following the number, there are three letters which further categorize the book." +
                "\n\n4. Your goal is to arrange the books in ascending order of their call numbers, starting with the lowest number and ending with the highest." +
                "\n\n5. Drag and drop the books to move them around." +
                "\n\n6. You have a limited time to sort the books correctly. Keep an eye on the timer!" +
                "\n\n7. Once you think you have sorted the books correctly, click the 'Sort' button to check your solution." +
                "\n\n Good luck! Press 'Generate books' to start", "How to Play");

        }


        //------------------------------------------------------------------------------------------------------------------------------------------------//


        //------------------------------------------------Method responsible for the Identify Areas click.-------------------------------------------------//

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Identify_Areas identify_Areas = new Identify_Areas();
            identify_Areas.Show();
            MessageBox.Show("Welcome to the Identify Areas! Here is how it works:" +
                    "\n\n\n1. You will see call numbers on your left and descriptions on your right (or viceversa)." +
                    "\n\n2. Drag and drop the corresponding description from the buttons onto the correct panel." +
                    "\n\n3. If you believe you have misplaced a button, you can just drag and drop it back to the right." +
                    "\n\n4. Once you think you've matched all descriptions correctly, click the 'check answers' button to check your answers." +
                    "\n\n5. If your answer is correct the progress bar will fill a bit and the questions will alternate, if the answer is incorrect the app will notify you." +
                    "\n\n6. If you're stuck, click the 'Help' button for a hint." +
                    " Good luck and have fun learning!",
                    "How to Play", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //-----------------------------------------------Method responsible for the Find call numbers click.----------------------------------------------//

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Find_CallN find_Call = new Find_CallN();
            find_Call.Show();
            MessageBox.Show("Welcome to the Identify Areas! Here is how it works:" +
                    "\n\n\n1. When the quiz starts, a Dewey Decimal call number will be displayed." +
                    "\n\n2. Your task is to match this call number with the correct top-level category." +
                    "\n\n3. Select the correct category from the dropdown menu and click 'Check Answer'." +
                    "\n\n4. If you're correct, you'll gain points and move on to the next call number." +
                    "\n\n5. If you're incorrect, you'll lose points and have another try." +
                    "\n\n6. The game is timed, so try to answer as quickly as you can!" +
                    " Good luck and have fun learning!",
                    "How to Play", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//
    }
}
