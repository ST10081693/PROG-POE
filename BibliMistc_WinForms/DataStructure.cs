using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibliMistc_WinForms
{

    //-------------------------------------------------------------Tree Node class----------------------------------------------------------------------//
    internal class TreeNode
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public List<TreeNode> Children { get; set; } = new List<TreeNode>();
        public TreeNode Parent { get; set; }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------//



    //------------------------------------------DataStructure class reading the file and loading the tree-----------------------------------------------//

    internal class DataStructure
    {
        public TreeNode Root { get; private set; }

        public DataStructure(XDocument xmlDoc)
        {
            Root = new TreeNode { Description = "DeweyDecimalClassification" };

            foreach (var category in xmlDoc.Descendants("Category"))
            {
                var categoryNode = new TreeNode
                {
                    Number = category.Attribute("Number").Value,
                    Description = category.Attribute("Description").Value
                };

                foreach (var subcategory in category.Elements("Subcategory"))
                {
                    var subcategoryNode = new TreeNode
                    {
                        Number = subcategory.Attribute("Number").Value,
                        Description = subcategory.Attribute("Description").Value,
                        Parent = categoryNode  // Set the parent to the categoryNode
                    };

                    foreach (var entry in subcategory.Elements("Entry"))
                    {
                        var entryNode = new TreeNode
                        {
                            Number = entry.Attribute("Number").Value,
                            Description = entry.Attribute("Description").Value,
                            Parent = subcategoryNode  // Set the parent
                        };
                        subcategoryNode.Children.Add(entryNode);
                    }

                    categoryNode.Children.Add(subcategoryNode);
                }
                Root.Children.Add(categoryNode);
            }
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------//
}
