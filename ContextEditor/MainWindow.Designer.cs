
namespace ContextEditor
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.main_Label = new System.Windows.Forms.Label();
            this.main_nameTextbox = new System.Windows.Forms.TextBox();
            this.main_directoryTextbox = new System.Windows.Forms.TextBox();
            this.main_ProgramLabel = new System.Windows.Forms.Label();
            this.main_nameLabel = new System.Windows.Forms.Label();
            this.main_addButton = new System.Windows.Forms.Button();
            this.main_removeButton = new System.Windows.Forms.Button();
            this.main_listbox = new System.Windows.Forms.ListBox();
            this.main_iconDirectoryTextbox = new System.Windows.Forms.TextBox();
            this.main_iconDirectoryCheckbox = new System.Windows.Forms.CheckBox();
            this.main_browseIconButton = new System.Windows.Forms.Button();
            this.main_browseDirectoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // main_Label
            // 
            this.main_Label.AutoSize = true;
            this.main_Label.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_Label.Location = new System.Drawing.Point(12, 15);
            this.main_Label.Name = "main_Label";
            this.main_Label.Size = new System.Drawing.Size(98, 19);
            this.main_Label.TabIndex = 4;
            this.main_Label.Text = "Context Editor";
            // 
            // main_nameTextbox
            // 
            this.main_nameTextbox.Location = new System.Drawing.Point(16, 85);
            this.main_nameTextbox.Name = "main_nameTextbox";
            this.main_nameTextbox.Size = new System.Drawing.Size(179, 20);
            this.main_nameTextbox.TabIndex = 6;
            this.main_nameTextbox.TextChanged += new System.EventHandler(this.main_nameTextbox_TextChanged);
            // 
            // main_directoryTextbox
            // 
            this.main_directoryTextbox.Location = new System.Drawing.Point(72, 142);
            this.main_directoryTextbox.Name = "main_directoryTextbox";
            this.main_directoryTextbox.Size = new System.Drawing.Size(123, 20);
            this.main_directoryTextbox.TabIndex = 8;
            this.main_directoryTextbox.TextChanged += new System.EventHandler(this.main_directoryTextbox_TextChanged);
            // 
            // main_ProgramLabel
            // 
            this.main_ProgramLabel.AutoSize = true;
            this.main_ProgramLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_ProgramLabel.Location = new System.Drawing.Point(20, 120);
            this.main_ProgramLabel.Name = "main_ProgramLabel";
            this.main_ProgramLabel.Size = new System.Drawing.Size(121, 19);
            this.main_ProgramLabel.TabIndex = 9;
            this.main_ProgramLabel.Text = "Program directory";
            // 
            // main_nameLabel
            // 
            this.main_nameLabel.AutoSize = true;
            this.main_nameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_nameLabel.Location = new System.Drawing.Point(20, 63);
            this.main_nameLabel.Name = "main_nameLabel";
            this.main_nameLabel.Size = new System.Drawing.Size(46, 19);
            this.main_nameLabel.TabIndex = 10;
            this.main_nameLabel.Text = "Name";
            // 
            // main_addButton
            // 
            this.main_addButton.Enabled = false;
            this.main_addButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_addButton.Location = new System.Drawing.Point(16, 221);
            this.main_addButton.Name = "main_addButton";
            this.main_addButton.Size = new System.Drawing.Size(179, 30);
            this.main_addButton.TabIndex = 11;
            this.main_addButton.Text = "Add";
            this.main_addButton.UseVisualStyleBackColor = true;
            this.main_addButton.Click += new System.EventHandler(this.main_addButton_Click);
            // 
            // main_removeButton
            // 
            this.main_removeButton.Enabled = false;
            this.main_removeButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_removeButton.Location = new System.Drawing.Point(201, 279);
            this.main_removeButton.Name = "main_removeButton";
            this.main_removeButton.Size = new System.Drawing.Size(346, 30);
            this.main_removeButton.TabIndex = 12;
            this.main_removeButton.Text = "Remove";
            this.main_removeButton.UseVisualStyleBackColor = true;
            this.main_removeButton.Click += new System.EventHandler(this.main_removeButton_Click);
            // 
            // main_listbox
            // 
            this.main_listbox.FormattingEnabled = true;
            this.main_listbox.Location = new System.Drawing.Point(201, 15);
            this.main_listbox.Name = "main_listbox";
            this.main_listbox.Size = new System.Drawing.Size(346, 264);
            this.main_listbox.TabIndex = 13;
            this.main_listbox.SelectedIndexChanged += new System.EventHandler(this.main_listbox_SelectedIndexChanged);
            // 
            // main_iconDirectoryTextbox
            // 
            this.main_iconDirectoryTextbox.Location = new System.Drawing.Point(72, 195);
            this.main_iconDirectoryTextbox.Name = "main_iconDirectoryTextbox";
            this.main_iconDirectoryTextbox.Size = new System.Drawing.Size(123, 20);
            this.main_iconDirectoryTextbox.TabIndex = 15;
            this.main_iconDirectoryTextbox.TextChanged += new System.EventHandler(this.main_iconDirectoryTextbox_TextChanged);
            // 
            // main_iconDirectoryCheckbox
            // 
            this.main_iconDirectoryCheckbox.AutoSize = true;
            this.main_iconDirectoryCheckbox.Location = new System.Drawing.Point(24, 168);
            this.main_iconDirectoryCheckbox.Name = "main_iconDirectoryCheckbox";
            this.main_iconDirectoryCheckbox.Size = new System.Drawing.Size(47, 17);
            this.main_iconDirectoryCheckbox.TabIndex = 16;
            this.main_iconDirectoryCheckbox.Text = "Icon";
            this.main_iconDirectoryCheckbox.UseVisualStyleBackColor = true;
            this.main_iconDirectoryCheckbox.CheckedChanged += new System.EventHandler(this.main_iconDirectoryCheckbox_CheckedChanged);
            // 
            // main_browseIconButton
            // 
            this.main_browseIconButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.main_browseIconButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_browseIconButton.Location = new System.Drawing.Point(24, 195);
            this.main_browseIconButton.Name = "main_browseIconButton";
            this.main_browseIconButton.Size = new System.Drawing.Size(42, 20);
            this.main_browseIconButton.TabIndex = 17;
            this.main_browseIconButton.Text = "...";
            this.main_browseIconButton.UseVisualStyleBackColor = true;
            this.main_browseIconButton.Click += new System.EventHandler(this.main_browseIconButton_Click);
            // 
            // main_browseDirectoryButton
            // 
            this.main_browseDirectoryButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.main_browseDirectoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_browseDirectoryButton.Location = new System.Drawing.Point(24, 142);
            this.main_browseDirectoryButton.Name = "main_browseDirectoryButton";
            this.main_browseDirectoryButton.Size = new System.Drawing.Size(42, 20);
            this.main_browseDirectoryButton.TabIndex = 18;
            this.main_browseDirectoryButton.Text = "...";
            this.main_browseDirectoryButton.UseVisualStyleBackColor = true;
            this.main_browseDirectoryButton.Click += new System.EventHandler(this.main_browseDirectoryButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 321);
            this.Controls.Add(this.main_browseDirectoryButton);
            this.Controls.Add(this.main_browseIconButton);
            this.Controls.Add(this.main_iconDirectoryCheckbox);
            this.Controls.Add(this.main_iconDirectoryTextbox);
            this.Controls.Add(this.main_listbox);
            this.Controls.Add(this.main_removeButton);
            this.Controls.Add(this.main_addButton);
            this.Controls.Add(this.main_nameLabel);
            this.Controls.Add(this.main_ProgramLabel);
            this.Controls.Add(this.main_directoryTextbox);
            this.Controls.Add(this.main_nameTextbox);
            this.Controls.Add(this.main_Label);
            this.MaximumSize = new System.Drawing.Size(575, 360);
            this.MinimumSize = new System.Drawing.Size(575, 360);
            this.Name = "MainWindow";
            this.Text = "Context Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label main_Label;
        private System.Windows.Forms.TextBox main_nameTextbox;
        private System.Windows.Forms.TextBox main_directoryTextbox;
        private System.Windows.Forms.Label main_ProgramLabel;
        private System.Windows.Forms.Label main_nameLabel;
        private System.Windows.Forms.Button main_addButton;
        private System.Windows.Forms.Button main_removeButton;
        private System.Windows.Forms.ListBox main_listbox;
        private System.Windows.Forms.TextBox main_iconDirectoryTextbox;
        private System.Windows.Forms.CheckBox main_iconDirectoryCheckbox;
        private System.Windows.Forms.Button main_browseIconButton;
        private System.Windows.Forms.Button main_browseDirectoryButton;
    }
}

