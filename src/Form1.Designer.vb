<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        DockPanel1 = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        FileToolStripMenuItem = New ToolStripMenuItem()
        ExpotChatLogToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        PhrasePresetsToolStripMenuItem = New ToolStripMenuItem()
        SavePresetToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        LanguageToolStripMenuItem = New ToolStripMenuItem()
        SettingToolStripMenuItem = New ToolStripMenuItem()
        APIOptionToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        InputAreaFontToolStripMenuItem = New ToolStripMenuItem()
        PreviewAreaFontToolStripMenuItem = New ToolStripMenuItem()
        ChatLogFontToolStripMenuItem = New ToolStripMenuItem()
        WindowToolStripMenuItem = New ToolStripMenuItem()
        InputToolStripMenuItem = New ToolStripMenuItem()
        PreviewWindowToolStripMenuItem = New ToolStripMenuItem()
        ChatLogToolStripMenuItem = New ToolStripMenuItem()
        ChatListToolStripMenuItem = New ToolStripMenuItem()
        PhraseToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        LayoutResetToolStripMenuItem = New ToolStripMenuItem()
        HelpToolStripMenuItem = New ToolStripMenuItem()
        KeyboardSHortcutsToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1 = New MenuStrip()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DockPanel1
        ' 
        DockPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DockPanel1.DefaultFloatWindowSize = New Size(500, 500)
        DockPanel1.DockBackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        DockPanel1.DockBottomPortion = 180R
        DockPanel1.Location = New Point(9, 27)
        DockPanel1.Margin = New Padding(0)
        DockPanel1.Name = "DockPanel1"
        DockPanel1.Size = New Size(1207, 825)
        DockPanel1.TabIndex = 74
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ExpotChatLogToolStripMenuItem, ExitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(44, 24)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' ExpotChatLogToolStripMenuItem
        ' 
        ExpotChatLogToolStripMenuItem.Name = "ExpotChatLogToolStripMenuItem"
        ExpotChatLogToolStripMenuItem.Size = New Size(179, 24)
        ExpotChatLogToolStripMenuItem.Text = "Expot Chat Log"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(179, 24)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' PhrasePresetsToolStripMenuItem
        ' 
        PhrasePresetsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {SavePresetToolStripMenuItem, ToolStripSeparator1})
        PhrasePresetsToolStripMenuItem.Name = "PhrasePresetsToolStripMenuItem"
        PhrasePresetsToolStripMenuItem.Size = New Size(114, 24)
        PhrasePresetsToolStripMenuItem.Text = "Phrase Presets"
        ' 
        ' SavePresetToolStripMenuItem
        ' 
        SavePresetToolStripMenuItem.Name = "SavePresetToolStripMenuItem"
        SavePresetToolStripMenuItem.Size = New Size(159, 24)
        SavePresetToolStripMenuItem.Text = "Save Presets"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(156, 6)
        ' 
        ' LanguageToolStripMenuItem
        ' 
        LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem"
        LanguageToolStripMenuItem.Size = New Size(151, 24)
        LanguageToolStripMenuItem.Text = "Syntax Highlighting"
        ' 
        ' SettingToolStripMenuItem
        ' 
        SettingToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {APIOptionToolStripMenuItem, ToolStripSeparator3, InputAreaFontToolStripMenuItem, PreviewAreaFontToolStripMenuItem, ChatLogFontToolStripMenuItem})
        SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        SettingToolStripMenuItem.Size = New Size(68, 24)
        SettingToolStripMenuItem.Text = "Setting"
        ' 
        ' APIOptionToolStripMenuItem
        ' 
        APIOptionToolStripMenuItem.Name = "APIOptionToolStripMenuItem"
        APIOptionToolStripMenuItem.Size = New Size(162, 24)
        APIOptionToolStripMenuItem.Text = "API Option"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(159, 6)
        ' 
        ' InputAreaFontToolStripMenuItem
        ' 
        InputAreaFontToolStripMenuItem.Name = "InputAreaFontToolStripMenuItem"
        InputAreaFontToolStripMenuItem.Size = New Size(162, 24)
        InputAreaFontToolStripMenuItem.Text = "Editor Font"
        ' 
        ' PreviewAreaFontToolStripMenuItem
        ' 
        PreviewAreaFontToolStripMenuItem.Name = "PreviewAreaFontToolStripMenuItem"
        PreviewAreaFontToolStripMenuItem.Size = New Size(162, 24)
        PreviewAreaFontToolStripMenuItem.Text = "Preview Font"
        ' 
        ' ChatLogFontToolStripMenuItem
        ' 
        ChatLogFontToolStripMenuItem.Name = "ChatLogFontToolStripMenuItem"
        ChatLogFontToolStripMenuItem.Size = New Size(162, 24)
        ChatLogFontToolStripMenuItem.Text = "Chat Font"
        ' 
        ' WindowToolStripMenuItem
        ' 
        WindowToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {InputToolStripMenuItem, PreviewWindowToolStripMenuItem, ChatLogToolStripMenuItem, ChatListToolStripMenuItem, PhraseToolStripMenuItem, ToolStripSeparator2, LayoutResetToolStripMenuItem})
        WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        WindowToolStripMenuItem.Size = New Size(76, 24)
        WindowToolStripMenuItem.Text = "Window"
        ' 
        ' InputToolStripMenuItem
        ' 
        InputToolStripMenuItem.Name = "InputToolStripMenuItem"
        InputToolStripMenuItem.Size = New Size(171, 24)
        InputToolStripMenuItem.Text = "Editor"
        ' 
        ' PreviewWindowToolStripMenuItem
        ' 
        PreviewWindowToolStripMenuItem.Name = "PreviewWindowToolStripMenuItem"
        PreviewWindowToolStripMenuItem.Size = New Size(171, 24)
        PreviewWindowToolStripMenuItem.Text = "Preview"
        ' 
        ' ChatLogToolStripMenuItem
        ' 
        ChatLogToolStripMenuItem.Name = "ChatLogToolStripMenuItem"
        ChatLogToolStripMenuItem.Size = New Size(171, 24)
        ChatLogToolStripMenuItem.Text = "Chat"
        ' 
        ' ChatListToolStripMenuItem
        ' 
        ChatListToolStripMenuItem.Name = "ChatListToolStripMenuItem"
        ChatListToolStripMenuItem.Size = New Size(171, 24)
        ChatListToolStripMenuItem.Text = "Chat List"
        ' 
        ' PhraseToolStripMenuItem
        ' 
        PhraseToolStripMenuItem.Name = "PhraseToolStripMenuItem"
        PhraseToolStripMenuItem.Size = New Size(171, 24)
        PhraseToolStripMenuItem.Text = "Phrase Presets"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(168, 6)
        ' 
        ' LayoutResetToolStripMenuItem
        ' 
        LayoutResetToolStripMenuItem.Name = "LayoutResetToolStripMenuItem"
        LayoutResetToolStripMenuItem.Size = New Size(171, 24)
        LayoutResetToolStripMenuItem.Text = "Reset Layout"
        ' 
        ' HelpToolStripMenuItem
        ' 
        HelpToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {KeyboardSHortcutsToolStripMenuItem})
        HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        HelpToolStripMenuItem.Size = New Size(53, 24)
        HelpToolStripMenuItem.Text = "Help"
        ' 
        ' KeyboardSHortcutsToolStripMenuItem
        ' 
        KeyboardSHortcutsToolStripMenuItem.Name = "KeyboardSHortcutsToolStripMenuItem"
        KeyboardSHortcutsToolStripMenuItem.Size = New Size(207, 24)
        KeyboardSHortcutsToolStripMenuItem.Text = "Keyboard Shortcuts"
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point)
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, PhrasePresetsToolStripMenuItem, LanguageToolStripMenuItem, SettingToolStripMenuItem, WindowToolStripMenuItem, HelpToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1224, 28)
        MenuStrip1.TabIndex = 75
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = SystemColors.Control
        ClientSize = New Size(1224, 861)
        Controls.Add(DockPanel1)
        Controls.Add(MenuStrip1)
        KeyPreview = True
        MainMenuStrip = MenuStrip1
        MinimumSize = New Size(1240, 790)
        Name = "Form1"
        Text = "TmCGPT Debugger"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents DockPanel1 As WeifenLuo.WinFormsUI.Docking.DockPanel
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpotChatLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PhrasePresetsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SavePresetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents LanguageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InputAreaFontToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreviewAreaFontToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChatLogFontToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InputToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreviewWindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChatLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChatListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents LayoutResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeyboardSHortcutsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PhraseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents APIOptionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
End Class