using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BibliMistc_WinForms
{
    public partial class Find_CallN : Form
    {
        //Declared variables that will be used throught the application. 
        private DataStructure dataTree;
        private TreeNode selectedEntry;
        private List<TreeNode> thirdLevelEntries;
        private int? currentIndex = null;
        private Random rand = new Random();



        //-----------------------------------------------------------Class Constructor---------------------------------------------------------------------//

        public Find_CallN()
        {
            InitializeComponent();
            LoadTreeData();
            thirdLevelEntries = GetAllEntries(dataTree.Root).ToList();
            PopulateQuiz();
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Start();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------------------------Method that will load the file into the tree -----------------------------------------------------//

        private void LoadTreeData()
        {
            var xmlDoc = XDocument.Parse(Properties.Resources.DeweyF);
            dataTree = new DataStructure(xmlDoc);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //----------------------------------Method responsible for setting the text of the label and populating the combobox-------------------------------//

        private void PopulateQuiz()
        {
            if (thirdLevelEntries.Count == 0)
            {
                MessageBox.Show("No third-level entries found in the tree.");
                return;
            }

            // If currentIndex is not set, select a random entry to start
            if (!currentIndex.HasValue)
            {
                currentIndex = rand.Next(thirdLevelEntries.Count);
            }
            else
            {
                // Move to the next entry, wrapping around if necessary
                currentIndex = (currentIndex.Value + 1) % thirdLevelEntries.Count;
            }

            selectedEntry = thirdLevelEntries[currentIndex.Value];
            // Use the current index to get the next entry
            QuizNumber.Text = selectedEntry.Description;

            // Populate the ComboBox with top-level options (Category nodes)
            var topLevelEntries = dataTree.Root.Children;
            var correctTopLevel = selectedEntry.Parent.Parent; // This gets the Category node for the selected entry
            var incorrectTopLevels = topLevelEntries.Except(new List<TreeNode> { correctTopLevel }).ToList();
            var shuffledIncorrectTopLevels = incorrectTopLevels.OrderBy(x => rand.Next()).Take(3).ToList();
            var combinedTopLevels = shuffledIncorrectTopLevels.Concat(new List<TreeNode> { correctTopLevel });
            var sortedTopLevels = combinedTopLevels.OrderBy(entry => int.Parse(entry.Number)).ToList();

            DescriptionsCB.Items.Clear();
            foreach (var entry in sortedTopLevels)
            {
                DescriptionsCB.Items.Add($"{entry.Number} – {entry.Description}");
            }

            currentIndex = (currentIndex + 1) % thirdLevelEntries.Count;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------------------------Method that will get the entries from the tree----------------------------------------------------//

        private IEnumerable<TreeNode> GetAllEntries(TreeNode node)
        {
            foreach (var child in node.Children)
            {
                if (child.Children.Count == 0)
                {
                    yield return child;
                }
                else
                {
                    foreach (var grandchild in GetAllEntries(child))
                    {
                        yield return grandchild;
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //--------------------------------------------Method responsible for handling the "check answer" click----------------------------------------------//

        private void Check_Answer_Click(object sender, EventArgs e)
        {
            if (DescriptionsCB.SelectedItem == null)
            {
                MessageBox.Show("Please select an option from the dropdown.");
                return;
            }

            var selectedTopLevel = DescriptionsCB.SelectedItem.ToString().Split('–')[0].Trim();
            var correctTopLevel = selectedEntry.Parent.Parent.Number;

            if (selectedTopLevel == correctTopLevel)
            {
                MessageBox.Show("Your answer is correct!");
                progressBar1.Value = Math.Min(progressBar1.Value + 10, progressBar1.Maximum);
            }
            else
            {
                MessageBox.Show($"Wrong answer! You should have chosen {correctTopLevel}.");
                progressBar1.Value = Math.Max(progressBar1.Value - 10, 0);
            }

            DescriptionsCB.Text = "Select a description here!";
            PopulateQuiz();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //---------------------------------------------Method responsible for handling the "Main Menu" click------------------------------------------------//

        private void MainMenu_Click(object sender, EventArgs e)
        {
            Menuwind menuwind = new Menuwind();
            menuwind.Show();
            this.Close();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------------------------Method responsible progress bar which is a timer--------------------------------------------------//

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = Math.Max(progressBar1.Value - 1, 0);
            if (progressBar1.Value == 0)
            {
                gameTimer.Stop();
                MessageBox.Show("Time's up!");
                Menuwind menuwind = new Menuwind();
                menuwind.Show();
                this.Close();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//

    }
}