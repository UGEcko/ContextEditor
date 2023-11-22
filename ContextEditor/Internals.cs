using System;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ContextEditor
{
    partial class MainWindow
    {
        public void log(string log)
        {
            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] | Editor: {log}");
        }

        public bool VerifyParams()
        {
            string directory = main_directoryTextbox.Text.Trim();
            string iconDir = main_iconDirectoryTextbox.Text.Trim();

            if (File.Exists(directory) && !string.IsNullOrWhiteSpace(main_nameTextbox.Text))
            {
                log("Valid name and directory");
                main_addButton.Enabled = true;

                if (main_iconDirectoryCheckbox.Checked)
                {
                    if (File.Exists(iconDir) && main_iconDirectoryTextbox.Text.EndsWith(".ico"))
                    {
                        return true;
                    }
                    else
                    {
                        log("Invalid icon directory or not a .ico file");
                        main_addButton.Enabled = false;
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                log("Invalid name or directory " + iconDir);
                MessageBox.Show("Invalid name or directory " + iconDir);
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
                return $"Name: {Name}";
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
                using (var shellKey = Registry.ClassesRoot.OpenSubKey("Directory\\Background\\shell", true))
                {
                    if (shellKey != null)
                    {
                        using (var newKey = shellKey.CreateSubKey(name)?.CreateSubKey("command"))
                        {
                            if (newKey != null)
                            {
                                newKey.SetValue("", dir);
                                Console.WriteLine("Created key: " + newKey.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Failed to create registry key.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to open shell registry key.");
                    }
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
                using (var shellKey = Registry.ClassesRoot.OpenSubKey("Directory\\Background\\shell", true))
                {
                    if (shellKey != null)
                    {
                        using (var newKey = shellKey.CreateSubKey(name)?.CreateSubKey("command"))
                        {
                            if (newKey != null)
                            {
                                newKey.SetValue("", dir);
                                newKey.SetValue("Icon", iconPath);
                                Console.WriteLine("Created key: " + newKey.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Failed to create registry key.");
                                MessageBox.Show("Failed to create registry key.");
                                
                            }
                        }

                        using (var existingKey = shellKey.OpenSubKey(name, true))
                        {
                            if (existingKey != null)
                            {
                                existingKey.SetValue("Icon", iconPath);
                                Console.WriteLine("Updated key: " + existingKey.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Failed to open existing registry key.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to open shell registry key.");
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist: " + dir);
                MessageBox.Show("File does not exist: " + dir);
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
                    MessageBox.Show($"Context not found: {name}");
                    Console.WriteLine($"Context menu not found: {name}");
                }
            }
        }

        public static List<string> GetExistingKeys()
        {
            List<string> existingKeys = new List<string>();

            using (var key = Registry.ClassesRoot.OpenSubKey("Directory\\Background\\shell", true))
            {
                if (key != null)
                {
                    existingKeys.AddRange(key.GetSubKeyNames());
                }
                else
                {
                    MessageBox.Show("Failed to open registry key. 'GetExistingKeys'");
                    Console.WriteLine("Failed to open registry key.");
                }
            }

            return existingKeys;
        }

        public static List<string> GetExistingDirectories() // Gets the directory of each one.
            {
                List<string> existingDirs = new List<string>();
                using (var shellKey = Registry.ClassesRoot.OpenSubKey("Directory\\Background\\shell", true))
                {
                    if (shellKey != null)
                    {
                        foreach (var keyName in shellKey.GetSubKeyNames())
                        {
                            using (var key = shellKey.OpenSubKey(keyName)?.OpenSubKey("command"))
                            {
                                if (key != null)
                                {
                                    string directory = key.GetValue("") as string;
                                    if (!string.IsNullOrEmpty(directory))
                                    {
                                        existingDirs.Add(directory);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                    MessageBox.Show("Failed to open registry key. 'GetExistingDirectories'");
                    Console.WriteLine("Failed to open registry key.");
                    return existingDirs;
                    }
                return existingDirs;
                }
            }
        public static string arrToString(string[] array)
        {
            string logString = string.Join(", ", array);

            return logString;
        }

        public void updateListBox(bool full) // Refreshes the list box, best for accurate index between the existingkeys array and GetExisting() ykyk
        {
            main_listbox.Items.Clear();
            if (full == true)
            {
                List<string> existingKeys = GetExistingKeys();
                List<string> existingDirectories = GetExistingDirectories();

                // Iterate back and forth between keys and directories
                IEnumerator<string> keysEnumerator = existingKeys.GetEnumerator();
                IEnumerator<string> dirsEnumerator = existingDirectories.GetEnumerator();

                while (keysEnumerator.MoveNext() && dirsEnumerator.MoveNext())
                {
                    // Create listItem and add to main_listbox
                    listItem item = new listItem();
                    item.Name = keysEnumerator.Current;
                    item.Directory = dirsEnumerator.Current;
                    main_listbox.Items.Add(item.getFullText());
                }
            }
            else
            {
                List<string> existingKeys = GetExistingKeys();
                IEnumerator<string> keysEnumerator = existingKeys.GetEnumerator();

                while (keysEnumerator.MoveNext())
                {
                    // Create listItem and add to main_listbox
                    listItem item = new listItem();
                    item.Name = keysEnumerator.Current;
                    main_listbox.Items.Add(item);
                }
            }
            log("Updated listbox");
        }


    }

    
}
