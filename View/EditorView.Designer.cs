namespace Lab2_SimpleTextEditor
{
    partial class EditorView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorView));
            this.TextField = new System.Windows.Forms.TextBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitOption = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetFontFamilyOption = new System.Windows.Forms.ToolStripMenuItem();
            this.SetFontColorOption = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundColorOption = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutOption = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextField
            // 
            this.TextField.AcceptsTab = true;
            this.TextField.BackColor = System.Drawing.Color.White;
            this.TextField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextField.Location = new System.Drawing.Point(0, 24);
            this.TextField.Margin = new System.Windows.Forms.Padding(0);
            this.TextField.Multiline = true;
            this.TextField.Name = "TextField";
            this.TextField.Size = new System.Drawing.Size(800, 426);
            this.TextField.TabIndex = 0;
            this.TextField.WordWrap = false;
            this.TextField.TextChanged += new System.EventHandler(this.TextField_TextChanged);
            // 
            // MenuStrip
            // 
            this.MenuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ViewToolStripMenuItem,
            this.AboutOption});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(0);
            this.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip.Stretch = false;
            this.MenuStrip.TabIndex = 1;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateFileOption,
            this.OpenFileOption,
            this.SaveFileOption,
            this.SaveAsFileOption,
            this.toolStripSeparator1,
            this.ExitOption});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // CreateFileOption
            // 
            this.CreateFileOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CreateFileOption.Name = "CreateFileOption";
            this.CreateFileOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.CreateFileOption.Size = new System.Drawing.Size(249, 22);
            this.CreateFileOption.Text = "Создать";
            this.CreateFileOption.Click += new System.EventHandler(this.CreateFileOption_Click);
            // 
            // OpenFileOption
            // 
            this.OpenFileOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenFileOption.Name = "OpenFileOption";
            this.OpenFileOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFileOption.Size = new System.Drawing.Size(249, 22);
            this.OpenFileOption.Text = "Открыть";
            this.OpenFileOption.Click += new System.EventHandler(this.OpenFileOption_Click);
            // 
            // SaveFileOption
            // 
            this.SaveFileOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveFileOption.Name = "SaveFileOption";
            this.SaveFileOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFileOption.Size = new System.Drawing.Size(249, 22);
            this.SaveFileOption.Text = "Сохранить";
            this.SaveFileOption.Click += new System.EventHandler(this.SaveFileOption_Click);
            // 
            // SaveAsFileOption
            // 
            this.SaveAsFileOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveAsFileOption.Name = "SaveAsFileOption";
            this.SaveAsFileOption.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsFileOption.Size = new System.Drawing.Size(249, 22);
            this.SaveAsFileOption.Text = "Сохранить как...";
            this.SaveAsFileOption.Click += new System.EventHandler(this.SaveFileOption_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // ExitOption
            // 
            this.ExitOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExitOption.Name = "ExitOption";
            this.ExitOption.Size = new System.Drawing.Size(249, 22);
            this.ExitOption.Text = "Выход";
            this.ExitOption.Click += new System.EventHandler(this.ExitOption_Click);
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.CheckOnClick = true;
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetFontFamilyOption,
            this.SetFontColorOption,
            this.BackgroundColorOption});
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(39, 24);
            this.ViewToolStripMenuItem.Text = "Вид";
            // 
            // SetFontFamilyOption
            // 
            this.SetFontFamilyOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SetFontFamilyOption.Name = "SetFontFamilyOption";
            this.SetFontFamilyOption.Size = new System.Drawing.Size(137, 22);
            this.SetFontFamilyOption.Text = "Шрифт";
            this.SetFontFamilyOption.Click += new System.EventHandler(this.SetFontFamilyOption_Click);
            // 
            // SetFontColorOption
            // 
            this.SetFontColorOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SetFontColorOption.Name = "SetFontColorOption";
            this.SetFontColorOption.Size = new System.Drawing.Size(137, 22);
            this.SetFontColorOption.Text = "Цвет текста";
            this.SetFontColorOption.Click += new System.EventHandler(this.SetFontColorOption_Click);
            // 
            // BackgroundColorOption
            // 
            this.BackgroundColorOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BackgroundColorOption.Name = "BackgroundColorOption";
            this.BackgroundColorOption.Size = new System.Drawing.Size(137, 22);
            this.BackgroundColorOption.Text = "Цвет фона";
            this.BackgroundColorOption.Click += new System.EventHandler(this.BackgroundColorOption_Click);
            // 
            // AboutOption
            // 
            this.AboutOption.Name = "AboutOption";
            this.AboutOption.Size = new System.Drawing.Size(94, 24);
            this.AboutOption.Text = "О программе";
            this.AboutOption.Click += new System.EventHandler(this.AboutOption_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // EditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TextField);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "EditorView";
            this.Text = "Безымянный";
            this.Load += new System.EventHandler(this.EditorView_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextField;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutOption;
        private System.Windows.Forms.ToolStripMenuItem CreateFileOption;
        private System.Windows.Forms.ToolStripMenuItem OpenFileOption;
        private System.Windows.Forms.ToolStripMenuItem SaveFileOption;
        private System.Windows.Forms.ToolStripMenuItem ExitOption;
        private System.Windows.Forms.ToolStripMenuItem SetFontFamilyOption;
        private System.Windows.Forms.ToolStripMenuItem SetFontColorOption;
        private System.Windows.Forms.ToolStripMenuItem BackgroundColorOption;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.ToolStripMenuItem SaveAsFileOption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

