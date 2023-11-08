using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BibliMistc_WinForms.Identifyclasses
{
    internal class LabelUpdater
    {

        public static void UpdateLevelLabel(ProgressBar progressBar, Label label)
        {
            int points = progressBar.Value;

            if (points <= 2)
            {
                label.Text = "Amateur";
            }
            else if (points <= 4)
            {
                label.Text = "Novice Stacker";
            }
            else if (points <= 6)
            {
                label.Text = "Shelf Specialist";
            }
            else if (points <= 8)
            {
                label.Text = "Catalog Curator";
            }
            else if (points <= 9)
            {
                label.Text = "Keeper of Tomes";
            }
            else if (points == 10)
            {
                label.Text = "Master Librarian";
            }
        }

        public static void Help() {

            MessageBox.Show("The Dewey Decimal Classification (DDC) goes as follows:" +
                "\n\n000 – General Works" +
                "\n100 – Philosophy and Psychology" +
                "\n200 – Religion" +
                "\n300 – Social sciences" +
                "\n400 – Languages" +
                "\n500 – Natural Sciences and mathematics" +
                "\n600 – Technology" +
                "\n700 – Arts and recreation" +
                "\n800 – Literature" +
                "\n900 – History and geography", "Help");

        }
    }


}
