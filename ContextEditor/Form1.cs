using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace ContextEditor
{

    public partial class MainWindow : Form
    {
        //Keep track of whats getting added/deleted.

        public RegistryKey registryRoot = Registry.ClassesRoot.OpenSubKey($"Directory\\Background\\shell\\", true);
        public string raw_name;
        public string raw_directory;

        public string savedName;
        public string savedDir;

        public object selectedItem;

        // Keep track of existing context menu items
        public string[] existingKeys = GetExistingKeys();

        public MainWindow()
        {
            InitializeComponent();
            foreach(string key in GetExistingKeys()) // Register existing keys into the listbox
            {
                listItem item = new listItem();
                item.Name = key;
                main_listbox.Items.Add(item);
            }
            log($"Existing keys: '{arrToString(GetExistingKeys())}', {GetExistingKeys().Length} items"); // log!
        }

        private void main_nameTextbox_TextChanged(object sender, EventArgs e)
        {
            raw_name = main_nameTextbox.Text;
            verifyParams();
        }

        private void main_directoryTextbox_TextChanged(object sender, EventArgs e)
        {
            raw_directory = main_directoryTextbox.Text;
            if(File.Exists(raw_directory))
            {
                main_directoryTextbox.ForeColor = Color.Green;
            } else
            {
                main_directoryTextbox.ForeColor = Color.Red;
            }
            verifyParams();
        }
        private void main_iconDirectoryTextbox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(main_iconDirectoryTextbox.Text) && main_iconDirectoryTextbox.Text.EndsWith(".ico"))
            {
                main_iconDirectoryTextbox.ForeColor = Color.Green;
            } else
            {
                main_iconDirectoryTextbox.ForeColor = Color.Red;
            }
            verifyParams();
        }

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
                if(main_iconDirectoryCheckbox.Checked == true)
                {
                    AddKey(savedName, savedDir, main_iconDirectoryTextbox.Text);
                } else
                {
                    AddKey(savedName, savedDir);
                }
                
                log($"Existing keys: '{arrToString(GetExistingKeys())}', {GetExistingKeys().Length} items");
                updateListBox();
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
                log($"Existing keys: '{arrToString(GetExistingKeys())}', {GetExistingKeys().Length} items");
                updateListBox();
            } catch(Exception ex)
            {
                log($"Error during remove process: {ex.Message}");
                MessageBox.Show($"Error during remove process: ${ex.Message}");
            }

        }

        private void main_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = main_listbox.SelectedItem;
            main_removeButton.Enabled = true;
            log("Selected " + selectedItem);
        }

        private void main_iconDirectoryCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(main_iconDirectoryCheckbox.Checked == true)
            {
                main_iconDirectoryTextbox.Enabled = true;
            } else
            {
                main_iconDirectoryTextbox.Enabled = false;
            }
        }

        private void main_browseIconButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "Icon Files|*.ico";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    main_iconDirectoryTextbox.Text = openFileDialog.FileName;
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
                }
            }
        }
    }
}
