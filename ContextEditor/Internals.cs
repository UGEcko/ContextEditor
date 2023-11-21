using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Microsoft.Win32;

namespace ContextEditor
{
    partial class MainWindow
    {
        public void log(string log)
        {
            Console.WriteLine($"[{DateTime.Now.ToShortDateString()}] | Editor: {log}");
        }

        public bool verifyParams()
        {
            if (File.Exists(main_directoryTextbox.Text) == true && main_nameTextbox.Text != "")
            {
                log("Valid name and directory");
                main_addButton.Enabled = true;
                
                if(main_iconDirectoryCheckbox.Checked = true && File.Exists(main_iconDirectoryTextbox.Text) && main_iconDirectoryTextbox.Text.EndsWith(".ico"))
                {
                    return true;
                } else if(main_iconDirectoryCheckbox.Checked == false)
                {
                    return true;
                } else
                {
                    main_addButton.Enabled = false;
                    return false;
                }
            }
            else
            {
                log("Invalid name or directory");
                main_addButton.Enabled = false;
                return false;
            }
        }

        public class listItem
        {
            public string Name { get; set; }
            public string Directory { get; set; }

            public override string ToString()
            {
                return Name;
            }
            public string getFullText()
            {
                return $"Name: {Name} / Directory: {Directory}";
            }
        }


        public static void AddKey(string name, string dir)
        {
            if (File.Exists(dir))
            {
                using (var key = Registry.ClassesRoot.OpenSubKey("Directory\\Background\\shell", true)?.CreateSubKey(name)?.CreateSubKey("command"))
                {
                    key?.SetValue("", dir);
                    Console.WriteLine(key != null ? "Created key: " + key.ToString() : "Failed to create registry key.");
                }
            }
            else
            {
                Console.WriteLine("File does not exist: " + dir);
            }
        }
        public static void AddKey(string name, string dir, string iconPath)
        {
            if (File.Exists(dir))
            {
                using (var key = Registry.ClassesRoot.OpenSubKey("Directory\\Background\\shell", true)?.CreateSubKey(name)?.CreateSubKey("command"))
                {
                    key?.SetValue("", dir);
                    key?.SetValue("Icon", iconPath); // Add the icon path
                    Console.WriteLine(key != null ? "Created key: " + key.ToString() : "Failed to create registry key.");
                }
            }
            else
            {
                Console.WriteLine("File does not exist: " + dir);
            }
        }
        public static void RemoveKey(string name)
        {
            using (var key = Registry.ClassesRoot.OpenSubKey($"Directory\\Background\\shell\\{name}", true))
            {
                if (key != null)
                {
                    key.DeleteSubKeyTree("command", false);
                    Registry.ClassesRoot.DeleteSubKeyTree($"Directory\\Background\\shell\\{name}", false);
                    Console.WriteLine($"Removed context menu: {name}");
                }
                else
                {
                    Console.WriteLine($"Context menu not found: {name}");
                }
            }
        }

        public static string[] GetExistingKeys()
        {
            using (var key = Registry.ClassesRoot.OpenSubKey("Directory\\Background\\shell", true))
            {
                if (key != null)
                {
                    string[] existingKeys = key.GetSubKeyNames();
                    return existingKeys;
                }
                else
                {
                    Console.WriteLine("Failed to open registry key.");
                    return new string[0]; // In case of an error, return empty array
                }
            }
        }
        public static string arrToString(string[] array)
        {
            string logString = string.Join(", ", array);

            return logString;
        }

        public void updateListBox() // Just a checker
        {
            main_listbox.Items.Clear();
            foreach (string key in GetExistingKeys()) // Register existing keys into the listbox
            {
                listItem item = new listItem();
                item.Name = key;
                main_listbox.Items.Add(item);
            }
        }
        

    }

    
}
