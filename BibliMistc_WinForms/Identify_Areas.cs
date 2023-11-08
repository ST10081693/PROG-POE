using BibliMistc_WinForms.Identifyclasses;
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
    /*
     The code from this project was taken from CHATGPT.
     */
    public partial class Identify_Areas : Form
    {        
        //----------------------------------------Initialised variable for random values, a boolean and the dictionary--------------------------------------//

        private Random rnd = new Random();
        private bool isMatchingDescriptionToCallNumber = true;
        Dictionary<string, string> callNumberToArea = new Dictionary<string, string> {{ "_000", "General works" }, { "_100", "Philosophy and psychology" }, 
            { "_200", "Religion" },{ "_300", "Social sciences" }, { "_400", "Language" }, { "_500", "Natural sciences and mathematics" },
            { "_600", "Technology" }, { "_700", "Arts and recreation" }, { "_800", "Literature" }, { "_900", "History and geography" }
        };

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //--------------------------------------------------------------Class constructor-------------------------------------------------------------------//

        public Identify_Areas()
        {
            InitializeComponent();
            AssignCallNumbersToPanels();
            GenerateButtons(7);  // Generate 7 buttons
            flowLayoutPanel1.AllowDrop = true;
            flowLayoutPanel1.DragEnter += flowLayoutPanel1_DragEnter;
            flowLayoutPanel1.DragDrop += flowLayoutPanel1_DragDrop;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //---------------------------------------------Method tha will load some of the things that were set------------------------------------------------//

        private void Identify_Areas_Load(object sender, EventArgs e)
        {
            // Set up the DragEnter and DragDrop events for each panel
            panel1.DragEnter += panel_DragEnter;
            panel1.DragDrop += panel_DragDrop;
            panel2.DragEnter += panel_DragEnter;
            panel2.DragDrop += panel_DragDrop;
            panel3.DragEnter += panel_DragEnter;
            panel3.DragDrop += panel_DragDrop;
            panel4.DragEnter += panel_DragEnter;
            panel4.DragDrop += panel_DragDrop;

            // Allow drop for each panel
            panel1.AllowDrop = true;
            panel2.AllowDrop = true;
            panel3.AllowDrop = true;
            panel4.AllowDrop = true;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------------------------Method that will assign descriptions to call numbers and vice-versa------------------------------------------//

        private void AssignCallNumbersToPanels()
        {
            // Shuffle the call numbers
            var shuffledCallNumbers = callNumberToArea.Keys.OrderBy(x => rnd.Next()).ToList();

            if (isMatchingDescriptionToCallNumber)
            {
                // Set call numbers as background images
                panel1.BackgroundImage = Properties.Resources.ResourceManager.GetObject(shuffledCallNumbers[0]) as Image;
                panel1.BackgroundImageLayout = ImageLayout.Stretch;
                panel2.BackgroundImage = Properties.Resources.ResourceManager.GetObject(shuffledCallNumbers[1]) as Image;
                panel2.BackgroundImageLayout = ImageLayout.Stretch;
                panel3.BackgroundImage = Properties.Resources.ResourceManager.GetObject(shuffledCallNumbers[2]) as Image;
                panel3.BackgroundImageLayout = ImageLayout.Stretch;
                panel4.BackgroundImage = Properties.Resources.ResourceManager.GetObject(shuffledCallNumbers[3]) as Image;
                panel4.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                // Set descriptions as background images
                panel1.BackgroundImage = Properties.Resources.ResourceManager.GetObject(callNumberToArea[shuffledCallNumbers[0]].Replace(" ", "_")) as Image;
                panel1.BackgroundImageLayout = ImageLayout.Stretch;
                panel2.BackgroundImage = Properties.Resources.ResourceManager.GetObject(callNumberToArea[shuffledCallNumbers[1]].Replace(" ", "_")) as Image;
                panel2.BackgroundImageLayout = ImageLayout.Stretch;
                panel3.BackgroundImage = Properties.Resources.ResourceManager.GetObject(callNumberToArea[shuffledCallNumbers[2]].Replace(" ", "_")) as Image;
                panel3.BackgroundImageLayout = ImageLayout.Stretch;
                panel4.BackgroundImage = Properties.Resources.ResourceManager.GetObject(callNumberToArea[shuffledCallNumbers[3]].Replace(" ", "_")) as Image;
                panel4.BackgroundImageLayout = ImageLayout.Stretch;
            }
            panel1.BackgroundImage.Tag = shuffledCallNumbers[0];
            panel2.BackgroundImage.Tag = shuffledCallNumbers[1];
            panel3.BackgroundImage.Tag = shuffledCallNumbers[2];
            panel4.BackgroundImage.Tag = shuffledCallNumbers[3];
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //---------------------------------------------Method that will generate buttons in the flowlayout panel--------------------------------------------//

        private void GenerateButtons(int numberOfButtons)
        {

            if (isMatchingDescriptionToCallNumber)
            {
                // Get the correct descriptions based on the call numbers assigned to the panels
                List<string> correctDescriptions = new List<string>
        {
            callNumberToArea[panel1.BackgroundImage.Tag.ToString()],
            callNumberToArea[panel2.BackgroundImage.Tag.ToString()],
            callNumberToArea[panel3.BackgroundImage.Tag.ToString()],
            callNumberToArea[panel4.BackgroundImage.Tag.ToString()]
        };

                // Get distractor descriptions
                var allDescriptions = callNumberToArea.Values.ToList();
                var distractorDescriptions = allDescriptions.Except(correctDescriptions).OrderBy(x => rnd.Next()).Take(3).ToList();

                // Combine correct and distractor descriptions, then shuffle
                var combinedDescriptions = correctDescriptions.Concat(distractorDescriptions).OrderBy(x => rnd.Next()).ToList();

                // Generate buttons based on the combined descriptions
                for (int i = 0; i < numberOfButtons; i++)
                {

                    Button button = new Button();
                    button.BackColor = Color.Transparent;
                    button.Width = 130;
                    button.Text = combinedDescriptions[i];
                    button.MouseDown += button_MouseDown;
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
            else
            {
                // Get the correct call numbers from the panels
                List<string> correctCallNumbers = new List<string>
        {
            panel1.BackgroundImage.Tag.ToString(),
            panel2.BackgroundImage.Tag.ToString(),
            panel3.BackgroundImage.Tag.ToString(),
            panel4.BackgroundImage.Tag.ToString()
        };

                // Get distractor call numbers
                var allCallNumbers = callNumberToArea.Keys.ToList();
                var distractorCallNumbers = allCallNumbers.Except(correctCallNumbers).OrderBy(x => rnd.Next()).Take(3).ToList();

                // Combine correct and distractor call numbers, then shuffle
                var combinedCallNumbers = correctCallNumbers.Concat(distractorCallNumbers).OrderBy(x => rnd.Next()).ToList();

                // Generate buttons based on the combined call numbers
                for (int i = 0; i < numberOfButtons; i++)
                {
                    Button button = new Button();
                    button.BackColor = Color.Transparent;
                    button.Width = 130;
                    button.Text = combinedCallNumbers[i].Replace("_", ""); // Remove underscore for display
                    button.MouseDown += button_MouseDown;
                    flowLayoutPanel1.Controls.Add(button);
                }
            }

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //--------------------------------------------------Method to help the movement of the button-------------------------------------------------------//

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            Button bt = (sender as Button);
            bt.DoDragDrop(sender, DragDropEffects.Move);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------------------Method that will help the drag of the buttons on the panels---------------------------------------------//

        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Button)) != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //--------------------------------Method that will enable the drop of a button in panel that already has a button-----------------------------------//

        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            Button newButton = ((Button)e.Data.GetData(typeof(Button)));
            Panel targetPanel = (Panel)sender;

            // Check if the target panel already has a button
            if (targetPanel.Controls.Count > 0)
            {
                Button oldButton = (Button)targetPanel.Controls[0];

                // Remove the old button from the target panel
                targetPanel.Controls.Remove(oldButton);

                // Reset the Dock property of the old button
                oldButton.Dock = DockStyle.None;

                // Optionally, you can also reset the size of the old button if needed
                // oldButton.Size = new Size(100, 30);  // Set a fixed size for the button

                // Add the old button back to the flowLayoutPanel1
                flowLayoutPanel1.Controls.Add(oldButton);

                // Set the new button's parent to the target panel
                newButton.Parent = targetPanel;
                newButton.Dock = DockStyle.Fill;
                newButton.BringToFront();
            }
            else
            {
                // If the target panel doesn't have a button, just set the new button's parent to the target panel
                newButton.Parent = targetPanel;
                newButton.Dock = DockStyle.Fill;
                newButton.BringToFront();
            }
            newButton.MouseDown += buttonInPanel_MouseDown;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------------------------------------Method that will handle the help messagebox------------------------------------------------------//

        private void Help_Click(object sender, EventArgs e)
        {
            LabelUpdater.Help();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //---------------------------------------------------Method that will check if the answer-----------------------------------------------------------//

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if any panel is empty
            Panel[] panels = { panel1, panel2, panel3, panel4 };
            foreach (var panel in panels)
            {
                if (panel.Controls.Count == 0)
                {
                    MessageBox.Show("Please ensure all panels have an area selected before submitting.", "Incomplete Answer", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Check if the answers are correct
            if (IsAnswerCorrect(panel1) && IsAnswerCorrect(panel2) && IsAnswerCorrect(panel3) && IsAnswerCorrect(panel4))
            {
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    progressBar1.Value += 1;
                    LabelUpdater.UpdateLevelLabel(progressBar1, label1);
                }
                else if (progressBar1.Value == 10)
                {
                    MessageBox.Show("Congratulations! You've reached the maximum points! You can still continue playing.");
                }
                NextQuestion();
            }
            else
            {
                MessageBox.Show("Sorry, your answer is incorrect. Please try again.", "Incorrect Answer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------------------------------------Method that will check if the answer is correct--------------------------------------------------//
        private bool IsAnswerCorrect(Panel panel)
        {
            if (panel.Controls.Count == 0)
                return false; // No button in the panel

            Button btn = panel.Controls[0] as Button;
            string callNumber = panel.BackgroundImage.Tag.ToString();
            if (isMatchingDescriptionToCallNumber)
            {
                // Check if the description on the button matches the call number's associated description
                return callNumberToArea[callNumber] == btn.Text;
            }
            else
            {
                return callNumber.Replace("_", "") == btn.Text;
            }

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //---------------------------------------------Method that will change the question for the use----------------------------------------------------//

        private void NextQuestion()
        {
            // Toggle the flag
            isMatchingDescriptionToCallNumber = !isMatchingDescriptionToCallNumber;


            // Clear existing buttons and panels
            flowLayoutPanel1.Controls.Clear();
            foreach (Panel panel in new List<Panel> { panel1, panel2, panel3, panel4 })
            {
                panel.Controls.Clear();
                panel.BackgroundImage = null;
            }

            // Generate new questions
            AssignCallNumbersToPanels();
            GenerateButtons(7);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //---------------------------------------------------------Main menu button Method------------------------------------------------------------------//

        private void button3_Click(object sender, EventArgs e)
        {
            Menuwind menuwind = new Menuwind();
            menuwind.Show();
            this.Close();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //----------------------------------------Method for that will help the move from panel to flowlayoutpanel-------------------------------------------//

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Button)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //--------------------------------------Method for that will help buttons being dropped into the layoutpanel----------------------------------------//

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            Button btn = e.Data.GetData(typeof(Button)) as Button;
            if (btn != null)
            {
                Panel parentPanel = btn.Parent as Panel;
                if (parentPanel != null)
                {
                    parentPanel.Controls.Remove(btn); // Remove button from the panel
                }
                flowLayoutPanel1.Controls.Add(btn); // Add button back to the FlowLayoutPanel
                btn.Dock = DockStyle.None; // Reset the Dock property of the button
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------------------------------Method that helps the initiation of the drag and drop--------------------------------------------------//
        private void buttonInPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.DoDragDrop(btn, DragDropEffects.Move);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//

    }
}