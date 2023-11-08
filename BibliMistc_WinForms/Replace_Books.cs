using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace BibliMistc_WinForms
{
    public partial class Replace_Books : Form
    {
        //Some initialized variables that will be used later.
        private List<string> callNumbers = new List<string>();
        private Random random = new Random();
        private Dictionary<string, Color> callNumberColors = new Dictionary<string, Color>();
        private int seconds = 0;

        public Replace_Books()
        {
            InitializeComponent();
            flowLayoutPanel1.Padding = new Padding(0, 50, 0, 0); //Ajusting the height of the books in the shelf.
            flowLayoutPanel1.AllowDrop = true;//Allowing the functionality drop.
            //Code that will enable the books to be dragged and dropped by the user.
            flowLayoutPanel1.DragEnter += flowLayoutPanel1_DragEnter;
            flowLayoutPanel1.DragDrop += flowLayoutPanel1_DragDrop;
        }


        //---------------------------------------Method that will be activated when the 'generate books' button is clicked-----------------------------------//

        private void generatebooks_Click(object sender, EventArgs e)
        {
            GenerateCallNumbers();
            DisplayCallNumbers();
            this.flowLayoutPanel1.AllowDrop = true;
            this.seconds = 50;
            this.counttime.Start(); //This code starts the timer.
            this.timeleft.ForeColor = Color.White; //This code will display the time left in white.
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //---------------------Method that will be responsible for clearing previous call numbers and colors and generate new ones-------------------------//

        private void GenerateCallNumbers()
        {
            this.callNumbers.Clear();
            this.callNumberColors.Clear();

            for (var i = 0; i < 10; i++)
            {
                var numberPart = Math.Round(this.random.NextDouble() * 999.99, 2);
                var letterPart = (char)this.random.Next(65, 91); // A-Z
                var callNumber = $"{numberPart:000.00} {letterPart}{letterPart}{letterPart}";
                this.callNumbers.Add(callNumber);

                Color itemColor;
                do
                {
                    itemColor = Color.FromArgb(
                        this.random.Next(156, 256),
                        this.random.Next(156, 256),
                        this.random.Next(156, 256));
                }
                while (itemColor.GetBrightness() < 0.5);

                this.callNumberColors[callNumber] = itemColor;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------This method will be responsible for displaying the books in the shelf with their respective properties-------------------------//

        private void DisplayCallNumbers()
        {
            this.flowLayoutPanel1.Controls.Clear();
            foreach (var callNumber in this.callNumbers)
            {
                var button = new Button
                {
                    Text = callNumber,
                    BackColor = this.callNumberColors[callNumber],
                    Width = 42,
                    Height = 200,
                    Margin = new Padding(3)
                };
                button.MouseDown += button_MouseDown;
                this.flowLayoutPanel1.Controls.Add(button);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //--------------------------------This initiates the process of drag and drop, is is used when a book is pressed------------------------------------//

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                this.flowLayoutPanel1.DoDragDrop(button, DragDropEffects.Move);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //----------------------------------------------This code will help with the "move" of the buttons--------------------------------------------------//

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Button)) != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //----------------------------------------This method is responsible for changing the index of the dragged button.----------------------------------//

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            var button = e.Data.GetData(typeof(Button)) as Button;
            var dropLocation = this.flowLayoutPanel1.PointToClient(new Point(e.X, e.Y));
            var itemUnderCursor = this.flowLayoutPanel1.GetChildAtPoint(dropLocation);

            if (button != null && itemUnderCursor != null)
            {
                var indexOfItemUnderCursor = this.flowLayoutPanel1.Controls.GetChildIndex(itemUnderCursor, false);
                this.flowLayoutPanel1.Controls.SetChildIndex(button, indexOfItemUnderCursor);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------------------Method used to decrease the time and also handle the events when the time is over----------------------------------//

        private void counttime_Tick(object sender, EventArgs e)
        {
            this.timeleft.Text = this.seconds--.ToString();
            if (this.seconds < 0)
            {
                this.counttime.Stop();
                this.timeleft.Text = "Time is over";
                this.timeleft.ForeColor = Color.Red;

                this.flowLayoutPanel1.AllowDrop = false;
                ReplaceHelper.PlayFailureMusic();
                MessageBox.Show("Time is up! If you would like to try again press 'generate books'.", "Time Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------------------------Method responsible for the sort event.------------------------------------------------------------//

        private void sort_Click(object sender, EventArgs e)
        {
            if (IsCorrectOrder())
            {
                this.counttime.Stop();
                ReplaceHelper.PlayWinningMusic();
                MessageBox.Show("Congratulations! You've sorted the books correctly.");
                var menuwind = new Menuwind();
                menuwind.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The books are not in the correct order. Try again.");
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //---------------------------------------------Method that checks if the books are in order.-------------------------------------------------------//

        private bool IsCorrectOrder()
        {
            for (var i = 0; i < this.callNumbers.Count - 1; i++)
            {
                var currentButton = this.flowLayoutPanel1.Controls[i] as Button;
                var nextButton = this.flowLayoutPanel1.Controls[i + 1] as Button;

                if (currentButton == null || nextButton == null)
                {
                    return false;
                }

                var currentCallNumber = currentButton.Text;
                var nextCallNumber = nextButton.Text;
                var currentParts = currentCallNumber.Split(' ');
                var nextParts = nextCallNumber.Split(' ');

                if (!double.TryParse(currentParts[0], out var currentNumberPart) ||
                    !double.TryParse(nextParts[0], out var nextNumberPart))
                {
                    return false;
                }

                var currentLetterPart = currentParts[1];
                var nextLetterPart = nextParts[1];

                if (currentNumberPart > nextNumberPart ||
                   (currentNumberPart == nextNumberPart && string.Compare(currentLetterPart, nextLetterPart) > 0))
                {
                    return false;
                }
            }
            return true;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------//

 

        //-----------------------------------------------Method that handles the main menu button click.----------------------------------------------------//

        private void menu_Click(object sender, EventArgs e)
        {
            var menuwind = new Menuwind();
            menuwind.Show();
            this.Close();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//
    }
}