using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TmCGPTD
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form1 : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            FileToolStripMenuItem = new ToolStripMenuItem();
            ExpotChatLogToolStripMenuItem = new ToolStripMenuItem();
            ExportEditorLogToolStripMenuItem = new ToolStripMenuItem();
            ImportChatLogToolStripMenuItem = new ToolStripMenuItem();
            ImportEditorLogToolStripMenuItem = new ToolStripMenuItem();
            ToolStripSeparator4 = new ToolStripSeparator();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            PhrasePresetsToolStripMenuItem = new ToolStripMenuItem();
            SavePresetToolStripMenuItem = new ToolStripMenuItem();
            ClearPresetsToolStripMenuItem = new ToolStripMenuItem();
            ToolStripSeparator1 = new ToolStripSeparator();
            LanguageToolStripMenuItem = new ToolStripMenuItem();
            SettingToolStripMenuItem = new ToolStripMenuItem();
            EditorLogAutoSaveToolStripMenuItem = new ToolStripMenuItem();
            ToolStripSeparator5 = new ToolStripSeparator();
            APIOptionToolStripMenuItem = new ToolStripMenuItem();
            ToolStripSeparator3 = new ToolStripSeparator();
            InputAreaFontToolStripMenuItem = new ToolStripMenuItem();
            PreviewAreaFontToolStripMenuItem = new ToolStripMenuItem();
            ChatLogFontToolStripMenuItem = new ToolStripMenuItem();
            WindowToolStripMenuItem = new ToolStripMenuItem();
            InputToolStripMenuItem = new ToolStripMenuItem();
            PreviewWindowToolStripMenuItem = new ToolStripMenuItem();
            ChatLogToolStripMenuItem = new ToolStripMenuItem();
            ChatListToolStripMenuItem = new ToolStripMenuItem();
            PhraseToolStripMenuItem = new ToolStripMenuItem();
            webChatToolStripMenuItem = new ToolStripMenuItem();
            ToolStripSeparator2 = new ToolStripSeparator();
            LayoutResetToolStripMenuItem = new ToolStripMenuItem();
            HelpToolStripMenuItem = new ToolStripMenuItem();
            KeyboardSHortcutsToolStripMenuItem = new ToolStripMenuItem();
            MenuStrip1 = new MenuStrip();
            importWebChatLogToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            MenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DockPanel1
            // 
            DockPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DockPanel1.DefaultFloatWindowSize = new Size(500, 500);
            DockPanel1.DockBackColor = Color.FromArgb(32, 32, 32);
            DockPanel1.DockBottomPortion = 180D;
            DockPanel1.Location = new Point(14, 40);
            DockPanel1.Margin = new Padding(0);
            DockPanel1.Name = "DockPanel1";
            DockPanel1.Size = new Size(1810, 1238);
            DockPanel1.TabIndex = 999;
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importWebChatLogToolStripMenuItem, toolStripSeparator6, ExpotChatLogToolStripMenuItem, ExportEditorLogToolStripMenuItem, ImportChatLogToolStripMenuItem, ImportEditorLogToolStripMenuItem, ToolStripSeparator4, ExitToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(62, 34);
            FileToolStripMenuItem.Text = "File";
            // 
            // ExpotChatLogToolStripMenuItem
            // 
            ExpotChatLogToolStripMenuItem.Name = "ExpotChatLogToolStripMenuItem";
            ExpotChatLogToolStripMenuItem.Size = new Size(325, 38);
            ExpotChatLogToolStripMenuItem.Text = "Expot Chat Log";
            ExpotChatLogToolStripMenuItem.Click += ExpotChatLogToolStripMenuItem_ClickAsync;
            // 
            // ExportEditorLogToolStripMenuItem
            // 
            ExportEditorLogToolStripMenuItem.Name = "ExportEditorLogToolStripMenuItem";
            ExportEditorLogToolStripMenuItem.Size = new Size(325, 38);
            ExportEditorLogToolStripMenuItem.Text = "Export Editor Log";
            ExportEditorLogToolStripMenuItem.Click += ExportEditorLogToolStripMenuItem_Click;
            // 
            // ImportChatLogToolStripMenuItem
            // 
            ImportChatLogToolStripMenuItem.Name = "ImportChatLogToolStripMenuItem";
            ImportChatLogToolStripMenuItem.Size = new Size(325, 38);
            ImportChatLogToolStripMenuItem.Text = "Import Chat Log";
            ImportChatLogToolStripMenuItem.Click += ImportChatLogToolStripMenuItem_Click;
            // 
            // ImportEditorLogToolStripMenuItem
            // 
            ImportEditorLogToolStripMenuItem.Name = "ImportEditorLogToolStripMenuItem";
            ImportEditorLogToolStripMenuItem.Size = new Size(325, 38);
            ImportEditorLogToolStripMenuItem.Text = "Import Editor Log";
            ImportEditorLogToolStripMenuItem.Click += ImportEditorLogToolStripMenuItem_Click;
            // 
            // ToolStripSeparator4
            // 
            ToolStripSeparator4.Name = "ToolStripSeparator4";
            ToolStripSeparator4.Size = new Size(322, 6);
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(325, 38);
            ExitToolStripMenuItem.Text = "Exit";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // PhrasePresetsToolStripMenuItem
            // 
            PhrasePresetsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SavePresetToolStripMenuItem, ClearPresetsToolStripMenuItem, ToolStripSeparator1 });
            PhrasePresetsToolStripMenuItem.Name = "PhrasePresetsToolStripMenuItem";
            PhrasePresetsToolStripMenuItem.Size = new Size(168, 34);
            PhrasePresetsToolStripMenuItem.Text = "Phrase Presets";
            // 
            // SavePresetToolStripMenuItem
            // 
            SavePresetToolStripMenuItem.Name = "SavePresetToolStripMenuItem";
            SavePresetToolStripMenuItem.Size = new Size(241, 38);
            SavePresetToolStripMenuItem.Text = "Save Presets";
            SavePresetToolStripMenuItem.Click += SavePresetToolStripMenuItem_Click;
            // 
            // ClearPresetsToolStripMenuItem
            // 
            ClearPresetsToolStripMenuItem.Name = "ClearPresetsToolStripMenuItem";
            ClearPresetsToolStripMenuItem.Size = new Size(241, 38);
            ClearPresetsToolStripMenuItem.Text = "Clear Presets";
            ClearPresetsToolStripMenuItem.Click += ClearPresetsToolStripMenuItem_Click;
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Size = new Size(238, 6);
            // 
            // LanguageToolStripMenuItem
            // 
            LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            LanguageToolStripMenuItem.Size = new Size(215, 34);
            LanguageToolStripMenuItem.Text = "Syntax Highlighting";
            // 
            // SettingToolStripMenuItem
            // 
            SettingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { EditorLogAutoSaveToolStripMenuItem, ToolStripSeparator5, APIOptionToolStripMenuItem, ToolStripSeparator3, InputAreaFontToolStripMenuItem, PreviewAreaFontToolStripMenuItem, ChatLogFontToolStripMenuItem });
            SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            SettingToolStripMenuItem.Size = new Size(97, 34);
            SettingToolStripMenuItem.Text = "Setting";
            // 
            // EditorLogAutoSaveToolStripMenuItem
            // 
            EditorLogAutoSaveToolStripMenuItem.Checked = true;
            EditorLogAutoSaveToolStripMenuItem.CheckState = CheckState.Checked;
            EditorLogAutoSaveToolStripMenuItem.Name = "EditorLogAutoSaveToolStripMenuItem";
            EditorLogAutoSaveToolStripMenuItem.Size = new Size(322, 38);
            EditorLogAutoSaveToolStripMenuItem.Text = "Editor Log Auto-Save";
            EditorLogAutoSaveToolStripMenuItem.Click += EditorLogAutoSaveToolStripMenuItem_Click;
            // 
            // ToolStripSeparator5
            // 
            ToolStripSeparator5.Name = "ToolStripSeparator5";
            ToolStripSeparator5.Size = new Size(319, 6);
            // 
            // APIOptionToolStripMenuItem
            // 
            APIOptionToolStripMenuItem.Name = "APIOptionToolStripMenuItem";
            APIOptionToolStripMenuItem.Size = new Size(322, 38);
            APIOptionToolStripMenuItem.Text = "API Option";
            APIOptionToolStripMenuItem.Click += APIOptionToolStripMenuItem_Click;
            // 
            // ToolStripSeparator3
            // 
            ToolStripSeparator3.Name = "ToolStripSeparator3";
            ToolStripSeparator3.Size = new Size(319, 6);
            // 
            // InputAreaFontToolStripMenuItem
            // 
            InputAreaFontToolStripMenuItem.Name = "InputAreaFontToolStripMenuItem";
            InputAreaFontToolStripMenuItem.Size = new Size(322, 38);
            InputAreaFontToolStripMenuItem.Text = "Editor Font";
            InputAreaFontToolStripMenuItem.Click += InputAreaFontToolStripMenuItem_Click;
            // 
            // PreviewAreaFontToolStripMenuItem
            // 
            PreviewAreaFontToolStripMenuItem.Name = "PreviewAreaFontToolStripMenuItem";
            PreviewAreaFontToolStripMenuItem.Size = new Size(322, 38);
            PreviewAreaFontToolStripMenuItem.Text = "Preview Font";
            PreviewAreaFontToolStripMenuItem.Click += PreviewAreaFontToolStripMenuItem_Click;
            // 
            // ChatLogFontToolStripMenuItem
            // 
            ChatLogFontToolStripMenuItem.Name = "ChatLogFontToolStripMenuItem";
            ChatLogFontToolStripMenuItem.Size = new Size(322, 38);
            ChatLogFontToolStripMenuItem.Text = "Chat Font";
            ChatLogFontToolStripMenuItem.Click += ChatLogFontToolStripMenuItem_Click;
            // 
            // WindowToolStripMenuItem
            // 
            WindowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { InputToolStripMenuItem, PreviewWindowToolStripMenuItem, ChatLogToolStripMenuItem, ChatListToolStripMenuItem, PhraseToolStripMenuItem, webChatToolStripMenuItem, ToolStripSeparator2, LayoutResetToolStripMenuItem });
            WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            WindowToolStripMenuItem.Size = new Size(109, 34);
            WindowToolStripMenuItem.Text = "Window";
            // 
            // InputToolStripMenuItem
            // 
            InputToolStripMenuItem.Name = "InputToolStripMenuItem";
            InputToolStripMenuItem.Size = new Size(255, 38);
            InputToolStripMenuItem.Text = "Editor";
            InputToolStripMenuItem.Click += InputToolStripMenuItem_Click;
            // 
            // PreviewWindowToolStripMenuItem
            // 
            PreviewWindowToolStripMenuItem.Name = "PreviewWindowToolStripMenuItem";
            PreviewWindowToolStripMenuItem.Size = new Size(255, 38);
            PreviewWindowToolStripMenuItem.Text = "Preview";
            PreviewWindowToolStripMenuItem.Click += PreviewWindowToolStripMenuItem_Click;
            // 
            // ChatLogToolStripMenuItem
            // 
            ChatLogToolStripMenuItem.Name = "ChatLogToolStripMenuItem";
            ChatLogToolStripMenuItem.Size = new Size(255, 38);
            ChatLogToolStripMenuItem.Text = "Chat";
            ChatLogToolStripMenuItem.Click += ChatLogToolStripMenuItem_Click;
            // 
            // ChatListToolStripMenuItem
            // 
            ChatListToolStripMenuItem.Name = "ChatListToolStripMenuItem";
            ChatListToolStripMenuItem.Size = new Size(255, 38);
            ChatListToolStripMenuItem.Text = "Chat List";
            ChatListToolStripMenuItem.Click += ChatListToolStripMenuItem_Click;
            // 
            // PhraseToolStripMenuItem
            // 
            PhraseToolStripMenuItem.Name = "PhraseToolStripMenuItem";
            PhraseToolStripMenuItem.Size = new Size(255, 38);
            PhraseToolStripMenuItem.Text = "Phrase Presets";
            PhraseToolStripMenuItem.Click += PhrasetToolStripMenuItem_Click;
            // 
            // webChatToolStripMenuItem
            // 
            webChatToolStripMenuItem.Name = "webChatToolStripMenuItem";
            webChatToolStripMenuItem.Size = new Size(255, 38);
            webChatToolStripMenuItem.Text = "Web Chat";
            webChatToolStripMenuItem.Click += webChatToolStripMenuItem_Click;
            // 
            // ToolStripSeparator2
            // 
            ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripSeparator2.Size = new Size(252, 6);
            // 
            // LayoutResetToolStripMenuItem
            // 
            LayoutResetToolStripMenuItem.Name = "LayoutResetToolStripMenuItem";
            LayoutResetToolStripMenuItem.Size = new Size(255, 38);
            LayoutResetToolStripMenuItem.Text = "Reset Layout";
            LayoutResetToolStripMenuItem.Click += LayoutResetToolStripMenuItem_Click;
            // 
            // HelpToolStripMenuItem
            // 
            HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { KeyboardSHortcutsToolStripMenuItem });
            HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            HelpToolStripMenuItem.Size = new Size(75, 34);
            HelpToolStripMenuItem.Text = "Help";
            // 
            // KeyboardSHortcutsToolStripMenuItem
            // 
            KeyboardSHortcutsToolStripMenuItem.Name = "KeyboardSHortcutsToolStripMenuItem";
            KeyboardSHortcutsToolStripMenuItem.Size = new Size(297, 38);
            KeyboardSHortcutsToolStripMenuItem.Text = "Keyboard Shortcut";
            KeyboardSHortcutsToolStripMenuItem.Click += KeyboardSHortcutsToolStripMenuItem_Click;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            MenuStrip1.ImageScalingSize = new Size(24, 24);
            MenuStrip1.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, PhrasePresetsToolStripMenuItem, LanguageToolStripMenuItem, SettingToolStripMenuItem, WindowToolStripMenuItem, HelpToolStripMenuItem });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Padding = new Padding(9, 3, 0, 3);
            MenuStrip1.Size = new Size(1836, 40);
            MenuStrip1.TabIndex = 75;
            MenuStrip1.Text = "MenuStrip1";
            // 
            // importWebChatLogToolStripMenuItem
            // 
            importWebChatLogToolStripMenuItem.Name = "importWebChatLogToolStripMenuItem";
            importWebChatLogToolStripMenuItem.Size = new Size(325, 38);
            importWebChatLogToolStripMenuItem.Text = "Import Web Chat Log";
            importWebChatLogToolStripMenuItem.Click += importWebChatLogToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(322, 6);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1836, 1292);
            Controls.Add(DockPanel1);
            Controls.Add(MenuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = MenuStrip1;
            Margin = new Padding(4);
            MinimumSize = new Size(1849, 1157);
            Name = "Form1";
            Text = "TmCGPT Debugger";
            FormClosing += MainForm_FormClosing;
            Load += Form1_Load;
            Shown += Form1_Shown;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        internal WeifenLuo.WinFormsUI.Docking.DockPanel DockPanel1;
        internal ToolStripMenuItem FileToolStripMenuItem;
        internal ToolStripMenuItem ExpotChatLogToolStripMenuItem;
        internal ToolStripMenuItem ExitToolStripMenuItem;
        internal ToolStripMenuItem PhrasePresetsToolStripMenuItem;
        internal ToolStripMenuItem SavePresetToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator1;
        internal ToolStripMenuItem LanguageToolStripMenuItem;
        internal ToolStripMenuItem SettingToolStripMenuItem;
        internal ToolStripMenuItem InputAreaFontToolStripMenuItem;
        internal ToolStripMenuItem PreviewAreaFontToolStripMenuItem;
        internal ToolStripMenuItem ChatLogFontToolStripMenuItem;
        internal ToolStripMenuItem WindowToolStripMenuItem;
        internal ToolStripMenuItem InputToolStripMenuItem;
        internal ToolStripMenuItem PreviewWindowToolStripMenuItem;
        internal ToolStripMenuItem ChatLogToolStripMenuItem;
        internal ToolStripMenuItem ChatListToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator2;
        internal ToolStripMenuItem LayoutResetToolStripMenuItem;
        internal ToolStripMenuItem HelpToolStripMenuItem;
        internal ToolStripMenuItem KeyboardSHortcutsToolStripMenuItem;
        internal MenuStrip MenuStrip1;
        internal ToolStripMenuItem PhraseToolStripMenuItem;
        internal ToolStripMenuItem APIOptionToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator3;
        internal ToolStripMenuItem ExportEditorLogToolStripMenuItem;
        internal ToolStripMenuItem ImportChatLogToolStripMenuItem;
        internal ToolStripMenuItem ImportEditorLogToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator4;
        internal ToolStripMenuItem ClearPresetsToolStripMenuItem;
        internal ToolStripMenuItem EditorLogAutoSaveToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator5;
        private ToolStripMenuItem webChatToolStripMenuItem;
        private ToolStripMenuItem importWebChatLogToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
    }
}