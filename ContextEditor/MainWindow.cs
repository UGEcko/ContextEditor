﻿using System;
using System.Drawing;
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




        // CHANGED STUFF

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

        
    }
}
