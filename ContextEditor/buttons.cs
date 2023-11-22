using System;
using System.Windows.Forms;

namespace ContextEditor
{
    partial class MainWindow
    {
        private void main_addButton_Click(object sender, EventArgs e)
        {
            try
            {
                listItem item = new listItem();
                item.Name = main_nameTextbox.Text;
                item.Directory = main_directoryTextbox.Text;
                savedName = main_nameTextbox.Text;
                savedDir = main_directoryTextbox.Text;
                main_listbox.Items.Add(item.getFullText());
                if (main_iconDirectoryCheckbox.Checked == true)
                {
                    AddKey(savedName, savedDir, main_iconDirectoryTextbox.Text);
                }
                else
                {
                    AddKey(savedName, savedDir);
                }
                log($"Removed {item.Name}");
                if (main_showDirectoryCheck.Checked == true)
                {
                    updateListBox(true);
                }
                else
                {
                    updateListBox(false);
                }
            }
            catch (Exception ex)
            {
                log($"Error during add process: {ex.Message}");
                MessageBox.Show($"Error during add process: {ex.Message}");
            }
        }
        private void main_removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string item = selectedItem.ToString();
                int itemIndex = main_listbox.SelectedIndex;
                main_listbox.Items.Remove(selectedItem);
                main_removeButton.Enabled = false;
                RemoveKey(GetExistingKeys()[itemIndex]); // Use selectedIndex and arrayindex to find the correct item and delete it!
                log($"Removed {item}");
                if(main_showDirectoryCheck.Checked == true)
                {
                    updateListBox(true);
                } else
                {
                    updateListBox(false);
                }
            }
            catch (Exception ex)
            {
                log($"Error during remove process: {ex.Message}");
                MessageBox.Show($"Error during remove process: ${ex.Message}");
            }

        }
        private void main_browseIconButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "Icon Files (*.ico)|*.ico";


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    main_iconDirectoryTextbox.Text = openFileDialog.FileName;
                    log($"Browser set icon directory to {openFileDialog.FileName}");
                }
            }
        }

        private void main_browseDirectoryButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    main_directoryTextbox.Text = openFileDialog.FileName;
                    log($"Browser set program directory to {openFileDialog.FileName}");
                }
            }
        }
    }
}
