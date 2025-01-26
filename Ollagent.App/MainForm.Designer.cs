namespace Ollagent.App
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            tabControl = new TabControl();
            logsPage = new TabPage();
            logsRichTextBox = new RichTextBox();
            chatPage = new TabPage();
            chatSplitContainer = new SplitContainer();
            chatRichTextBox = new RichTextBox();
            sendChatTableLayoutPanel = new TableLayoutPanel();
            sendChatRichTextBox = new RichTextBox();
            sendChatButton = new Button();
            settingsTab = new TabPage();
            settingsTableLayoutPanel = new TableLayoutPanel();
            logTimer = new System.Windows.Forms.Timer(components);
            statusStrip = new ToolStrip();
            nameStripStatusLabel = new ToolStripLabel();
            loadingStripProgressBar = new ToolStripProgressBar();
            loadingStripSeparator = new ToolStripSeparator();
            statusStripStatusLabel = new ToolStripStatusLabel();
            modelStripLabel = new ToolStripLabel();
            statusStripSeparator = new ToolStripSeparator();
            notifyIcon = new NotifyIcon(components);
            screenshotTimer = new System.Windows.Forms.Timer(components);
            menuStrip.SuspendLayout();
            tabControl.SuspendLayout();
            logsPage.SuspendLayout();
            chatPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chatSplitContainer).BeginInit();
            chatSplitContainer.Panel1.SuspendLayout();
            chatSplitContainer.Panel2.SuspendLayout();
            chatSplitContainer.SuspendLayout();
            sendChatTableLayoutPanel.SuspendLayout();
            settingsTab.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1693, 38);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(62, 34);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(149, 38);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(75, 34);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(175, 38);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(logsPage);
            tabControl.Controls.Add(chatPage);
            tabControl.Controls.Add(settingsTab);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 38);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1693, 803);
            tabControl.TabIndex = 3;
            // 
            // logsPage
            // 
            logsPage.Controls.Add(logsRichTextBox);
            logsPage.Location = new Point(4, 39);
            logsPage.Name = "logsPage";
            logsPage.Padding = new Padding(3);
            logsPage.Size = new Size(1685, 760);
            logsPage.TabIndex = 0;
            logsPage.Text = "Logs";
            logsPage.UseVisualStyleBackColor = true;
            // 
            // logsRichTextBox
            // 
            logsRichTextBox.Dock = DockStyle.Fill;
            logsRichTextBox.Location = new Point(3, 3);
            logsRichTextBox.Name = "logsRichTextBox";
            logsRichTextBox.ReadOnly = true;
            logsRichTextBox.Size = new Size(1679, 754);
            logsRichTextBox.TabIndex = 0;
            logsRichTextBox.Text = "";
            // 
            // chatPage
            // 
            chatPage.Controls.Add(chatSplitContainer);
            chatPage.Location = new Point(4, 39);
            chatPage.Name = "chatPage";
            chatPage.Padding = new Padding(3);
            chatPage.Size = new Size(1685, 760);
            chatPage.TabIndex = 1;
            chatPage.Text = "ChatWithoutImages";
            chatPage.UseVisualStyleBackColor = true;
            // 
            // chatSplitContainer
            // 
            chatSplitContainer.Dock = DockStyle.Fill;
            chatSplitContainer.Location = new Point(3, 3);
            chatSplitContainer.Name = "chatSplitContainer";
            chatSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // chatSplitContainer.Panel1
            // 
            chatSplitContainer.Panel1.Controls.Add(chatRichTextBox);
            chatSplitContainer.Panel1.RightToLeft = RightToLeft.No;
            // 
            // chatSplitContainer.Panel2
            // 
            chatSplitContainer.Panel2.Controls.Add(sendChatTableLayoutPanel);
            chatSplitContainer.Panel2.RightToLeft = RightToLeft.No;
            chatSplitContainer.RightToLeft = RightToLeft.No;
            chatSplitContainer.Size = new Size(1679, 754);
            chatSplitContainer.SplitterDistance = 647;
            chatSplitContainer.TabIndex = 0;
            // 
            // chatRichTextBox
            // 
            chatRichTextBox.Dock = DockStyle.Fill;
            chatRichTextBox.Location = new Point(0, 0);
            chatRichTextBox.Name = "chatRichTextBox";
            chatRichTextBox.ReadOnly = true;
            chatRichTextBox.Size = new Size(1679, 647);
            chatRichTextBox.TabIndex = 0;
            chatRichTextBox.Text = "";
            // 
            // sendChatTableLayoutPanel
            // 
            sendChatTableLayoutPanel.ColumnCount = 2;
            sendChatTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            sendChatTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            sendChatTableLayoutPanel.Controls.Add(sendChatRichTextBox, 0, 0);
            sendChatTableLayoutPanel.Controls.Add(sendChatButton, 1, 0);
            sendChatTableLayoutPanel.Dock = DockStyle.Fill;
            sendChatTableLayoutPanel.Location = new Point(0, 0);
            sendChatTableLayoutPanel.Name = "sendChatTableLayoutPanel";
            sendChatTableLayoutPanel.RowCount = 1;
            sendChatTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            sendChatTableLayoutPanel.Size = new Size(1679, 103);
            sendChatTableLayoutPanel.TabIndex = 0;
            // 
            // sendChatRichTextBox
            // 
            sendChatRichTextBox.Dock = DockStyle.Fill;
            sendChatRichTextBox.Location = new Point(3, 3);
            sendChatRichTextBox.Name = "sendChatRichTextBox";
            sendChatRichTextBox.Size = new Size(1505, 97);
            sendChatRichTextBox.TabIndex = 0;
            sendChatRichTextBox.Text = "";
            sendChatRichTextBox.KeyPress += sendChatRichTextBox_KeyPress;
            // 
            // sendChatButton
            // 
            sendChatButton.Dock = DockStyle.Fill;
            sendChatButton.Location = new Point(1514, 3);
            sendChatButton.Name = "sendChatButton";
            sendChatButton.Size = new Size(162, 97);
            sendChatButton.TabIndex = 1;
            sendChatButton.Text = "Send";
            sendChatButton.UseVisualStyleBackColor = true;
            sendChatButton.Click += sendChatButton_Click;
            // 
            // settingsTab
            // 
            settingsTab.Controls.Add(settingsTableLayoutPanel);
            settingsTab.Location = new Point(4, 39);
            settingsTab.Name = "settingsTab";
            settingsTab.Padding = new Padding(3);
            settingsTab.Size = new Size(1685, 760);
            settingsTab.TabIndex = 2;
            settingsTab.Text = "Settings";
            settingsTab.UseVisualStyleBackColor = true;
            // 
            // settingsTableLayoutPanel
            // 
            settingsTableLayoutPanel.ColumnCount = 2;
            settingsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            settingsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            settingsTableLayoutPanel.Dock = DockStyle.Fill;
            settingsTableLayoutPanel.Location = new Point(3, 3);
            settingsTableLayoutPanel.Name = "settingsTableLayoutPanel";
            settingsTableLayoutPanel.RowCount = 2;
            settingsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            settingsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            settingsTableLayoutPanel.Size = new Size(1679, 754);
            settingsTableLayoutPanel.TabIndex = 0;
            // 
            // logTimer
            // 
            logTimer.Enabled = true;
            logTimer.Interval = 1000;
            logTimer.Tick += logTimer_Tick;
            // 
            // statusStrip
            // 
            statusStrip.Dock = DockStyle.Bottom;
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { nameStripStatusLabel, loadingStripProgressBar, loadingStripSeparator, statusStripStatusLabel, modelStripLabel, statusStripSeparator });
            statusStrip.Location = new Point(0, 841);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1693, 35);
            statusStrip.TabIndex = 4;
            statusStrip.Text = "toolStrip1";
            // 
            // nameStripStatusLabel
            // 
            nameStripStatusLabel.Name = "nameStripStatusLabel";
            nameStripStatusLabel.Size = new Size(95, 30);
            nameStripStatusLabel.Text = "Ollagent";
            // 
            // loadingStripProgressBar
            // 
            loadingStripProgressBar.Name = "loadingStripProgressBar";
            loadingStripProgressBar.Overflow = ToolStripItemOverflow.Never;
            loadingStripProgressBar.Size = new Size(200, 30);
            loadingStripProgressBar.Style = ProgressBarStyle.Continuous;
            // 
            // loadingStripSeparator
            // 
            loadingStripSeparator.Name = "loadingStripSeparator";
            loadingStripSeparator.Size = new Size(6, 35);
            // 
            // statusStripStatusLabel
            // 
            statusStripStatusLabel.Name = "statusStripStatusLabel";
            statusStripStatusLabel.Overflow = ToolStripItemOverflow.Never;
            statusStripStatusLabel.Size = new Size(0, 28);
            // 
            // modelStripLabel
            // 
            modelStripLabel.Alignment = ToolStripItemAlignment.Right;
            modelStripLabel.Name = "modelStripLabel";
            modelStripLabel.Size = new Size(111, 30);
            modelStripLabel.Text = "No Model";
            // 
            // statusStripSeparator
            // 
            statusStripSeparator.Alignment = ToolStripItemAlignment.Right;
            statusStripSeparator.Name = "statusStripSeparator";
            statusStripSeparator.Size = new Size(6, 35);
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Ollagent";
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            // 
            // screenshotTimer
            // 
            screenshotTimer.Enabled = true;
            screenshotTimer.Interval = 30000;
            screenshotTimer.Tick += screenshotTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1693, 876);
            Controls.Add(tabControl);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(800, 600);
            Name = "MainForm";
            Text = "Ollagent";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            tabControl.ResumeLayout(false);
            logsPage.ResumeLayout(false);
            chatPage.ResumeLayout(false);
            chatSplitContainer.Panel1.ResumeLayout(false);
            chatSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chatSplitContainer).EndInit();
            chatSplitContainer.ResumeLayout(false);
            sendChatTableLayoutPanel.ResumeLayout(false);
            settingsTab.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TabControl tabControl;
        private TabPage logsPage;
        private TabPage chatPage;
        private RichTextBox logsRichTextBox;
        private SplitContainer chatSplitContainer;
        private RichTextBox chatRichTextBox;
        private TableLayoutPanel sendChatTableLayoutPanel;
        private RichTextBox sendChatRichTextBox;
        private Button sendChatButton;
        private System.Windows.Forms.Timer logTimer;
        private TabPage settingsTab;
        private TableLayoutPanel settingsTableLayoutPanel;
        private ToolStrip statusStrip;
        private ToolStripLabel nameStripStatusLabel;
        private ToolStripProgressBar loadingStripProgressBar;
        private ToolStripSeparator loadingStripSeparator;
        private ToolStripStatusLabel statusStripStatusLabel;
        private ToolStripLabel modelStripLabel;
        private ToolStripSeparator statusStripSeparator;
        private NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer screenshotTimer;
    }
}
