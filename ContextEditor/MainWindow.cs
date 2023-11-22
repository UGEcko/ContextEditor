using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;

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
        public int selectedItemIndex;

        // Keep track of existing context menu items

        public MainWindow()
        {
            InitializeComponent();
            updateListBox(false);

            log(arrToString(GetExistingKeys().ToArray()));
        }

        // CHANGED STUFF

        private void main_nameTextbox_TextChanged(object sender, EventArgs e)
        {
            raw_name = main_nameTextbox.Text;
            VerifyParams();
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
            VerifyParams();
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
        }

        private void main_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = main_listbox.SelectedItem;
            selectedItemIndex = main_listbox.SelectedIndex;
            main_directoryTextbox.Text = GetExistingDirectories()[selectedItemIndex];
            main_nameTextbox.Text = GetExistingKeys()[selectedItemIndex];
            main_removeButton.Enabled = true;
        }

        private void main_iconDirectoryCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(main_iconDirectoryCheckbox.Checked == true)
            {
                main_iconDirectoryTextbox.Enabled = true;
                main_browseIconButton.Enabled = true;
            } else
            {
                main_iconDirectoryTextbox.Enabled = false;
                main_browseIconButton.Enabled = false;
            }
        }

        private void main_showDirectoryCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (main_showDirectoryCheck.Checked == true)
            {
                updateListBox(true);
            }
            else
            {
                updateListBox(false);
            }
        }

    }
}
