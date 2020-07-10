using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace NetworkDebugTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.localLabel = new System.Windows.Forms.Label();
            this.localIPText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.localPortText = new System.Windows.Forms.TextBox();
            this.buttonOpenLocal = new System.Windows.Forms.Button();
            this.buttonCloseLocal = new System.Windows.Forms.Button();
            this.localPanel = new System.Windows.Forms.Panel();
            this.textBoxReceive = new System.Windows.Forms.TextBox();
            this.checkBoxSend = new System.Windows.Forms.CheckBox();
            this.checkBoxDisplay = new System.Windows.Forms.CheckBox();
            this.localSendButton = new System.Windows.Forms.Button();
            this.localSendText = new System.Windows.Forms.TextBox();
            this.serverIPLabel = new System.Windows.Forms.Label();
            this.serverPortLabel = new System.Windows.Forms.Label();
            this.serverIPText = new System.Windows.Forms.TextBox();
            this.serverPortText = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveLocalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTxtMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBinMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.listRemoteIP = new System.Windows.Forms.ListBox();
            this.localPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // localLabel
            // 
            this.localLabel.AutoSize = true;
            this.localLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.localLabel.Location = new System.Drawing.Point(51, 93);
            this.localLabel.Name = "localLabel";
            this.localLabel.Size = new System.Drawing.Size(111, 19);
            this.localLabel.TabIndex = 0;
            this.localLabel.Text = "本地IP地址";
            // 
            // localIPText
            // 
            this.localIPText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.localIPText.Location = new System.Drawing.Point(34, 115);
            this.localIPText.Name = "localIPText";
            this.localIPText.Size = new System.Drawing.Size(139, 26);
            this.localIPText.TabIndex = 1;
            this.localIPText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.localIPText.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(62, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "本地端口";
            // 
            // localPortText
            // 
            this.localPortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.localPortText.Location = new System.Drawing.Point(34, 184);
            this.localPortText.Name = "localPortText";
            this.localPortText.Size = new System.Drawing.Size(139, 26);
            this.localPortText.TabIndex = 3;
            this.localPortText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonOpenLocal
            // 
            this.buttonOpenLocal.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpenLocal.Location = new System.Drawing.Point(12, 236);
            this.buttonOpenLocal.Name = "buttonOpenLocal";
            this.buttonOpenLocal.Size = new System.Drawing.Size(75, 31);
            this.buttonOpenLocal.TabIndex = 4;
            this.buttonOpenLocal.Text = "打开";
            this.buttonOpenLocal.UseVisualStyleBackColor = true;
            this.buttonOpenLocal.Click += new System.EventHandler(this.ButtonOpenLocal_Click);
            // 
            // buttonCloseLocal
            // 
            this.buttonCloseLocal.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCloseLocal.Location = new System.Drawing.Point(128, 236);
            this.buttonCloseLocal.Name = "buttonCloseLocal";
            this.buttonCloseLocal.Size = new System.Drawing.Size(75, 31);
            this.buttonCloseLocal.TabIndex = 5;
            this.buttonCloseLocal.Text = "断开";
            this.buttonCloseLocal.UseVisualStyleBackColor = true;
            this.buttonCloseLocal.Click += new System.EventHandler(this.ButtonCloseLocal_Click);
            // 
            // localPanel
            // 
            this.localPanel.Controls.Add(this.textBoxReceive);
            this.localPanel.Controls.Add(this.checkBoxSend);
            this.localPanel.Controls.Add(this.checkBoxDisplay);
            this.localPanel.Controls.Add(this.localSendButton);
            this.localPanel.Controls.Add(this.localSendText);
            this.localPanel.Location = new System.Drawing.Point(209, 85);
            this.localPanel.Name = "localPanel";
            this.localPanel.Size = new System.Drawing.Size(710, 432);
            this.localPanel.TabIndex = 6;
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxReceive.Location = new System.Drawing.Point(0, 0);
            this.textBoxReceive.Multiline = true;
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxReceive.Size = new System.Drawing.Size(590, 370);
            this.textBoxReceive.TabIndex = 17;
            this.textBoxReceive.TextChanged += new System.EventHandler(this.textBoxReceive_TextChanged);
            // 
            // checkBoxSend
            // 
            this.checkBoxSend.AutoSize = true;
            this.checkBoxSend.Location = new System.Drawing.Point(612, 161);
            this.checkBoxSend.Name = "checkBoxSend";
            this.checkBoxSend.Size = new System.Drawing.Size(96, 16);
            this.checkBoxSend.TabIndex = 16;
            this.checkBoxSend.Text = "十六进制发送";
            this.checkBoxSend.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisplay
            // 
            this.checkBoxDisplay.AutoSize = true;
            this.checkBoxDisplay.Location = new System.Drawing.Point(612, 101);
            this.checkBoxDisplay.Name = "checkBoxDisplay";
            this.checkBoxDisplay.Size = new System.Drawing.Size(96, 16);
            this.checkBoxDisplay.TabIndex = 15;
            this.checkBoxDisplay.Text = "十六进制显示";
            this.checkBoxDisplay.UseVisualStyleBackColor = true;
            // 
            // localSendButton
            // 
            this.localSendButton.Location = new System.Drawing.Point(515, 376);
            this.localSendButton.Name = "localSendButton";
            this.localSendButton.Size = new System.Drawing.Size(75, 53);
            this.localSendButton.TabIndex = 3;
            this.localSendButton.Text = "发送";
            this.localSendButton.UseVisualStyleBackColor = true;
            this.localSendButton.Click += new System.EventHandler(this.LocalSendButton_Click);
            // 
            // localSendText
            // 
            this.localSendText.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.localSendText.Location = new System.Drawing.Point(0, 376);
            this.localSendText.Multiline = true;
            this.localSendText.Name = "localSendText";
            this.localSendText.Size = new System.Drawing.Size(509, 53);
            this.localSendText.TabIndex = 2;
            // 
            // serverIPLabel
            // 
            this.serverIPLabel.AutoSize = true;
            this.serverIPLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverIPLabel.Location = new System.Drawing.Point(51, 374);
            this.serverIPLabel.Name = "serverIPLabel";
            this.serverIPLabel.Size = new System.Drawing.Size(111, 19);
            this.serverIPLabel.TabIndex = 7;
            this.serverIPLabel.Text = "远程IP地址";
            // 
            // serverPortLabel
            // 
            this.serverPortLabel.AutoSize = true;
            this.serverPortLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverPortLabel.Location = new System.Drawing.Point(62, 456);
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(89, 19);
            this.serverPortLabel.TabIndex = 8;
            this.serverPortLabel.Text = "远程端口";
            // 
            // serverIPText
            // 
            this.serverIPText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverIPText.Location = new System.Drawing.Point(34, 396);
            this.serverIPText.Name = "serverIPText";
            this.serverIPText.Size = new System.Drawing.Size(139, 26);
            this.serverIPText.TabIndex = 0;
            this.serverIPText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serverPortText
            // 
            this.serverPortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverPortText.Location = new System.Drawing.Point(34, 478);
            this.serverPortText.Name = "serverPortText";
            this.serverPortText.Size = new System.Drawing.Size(139, 26);
            this.serverPortText.TabIndex = 12;
            this.serverPortText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLocalMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1299, 33);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveLocalMenu
            // 
            this.saveLocalMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTxtMenu,
            this.saveBinMenu});
            this.saveLocalMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveLocalMenu.Name = "saveLocalMenu";
            this.saveLocalMenu.Size = new System.Drawing.Size(100, 29);
            this.saveLocalMenu.Text = "保存本地";
            // 
            // saveTxtMenu
            // 
            this.saveTxtMenu.Name = "saveTxtMenu";
            this.saveTxtMenu.Size = new System.Drawing.Size(236, 30);
            this.saveTxtMenu.Text = "保存为文本";
            this.saveTxtMenu.Click += new System.EventHandler(this.SaveTxtMenu_Click);
            // 
            // saveBinMenu
            // 
            this.saveBinMenu.Name = "saveBinMenu";
            this.saveBinMenu.Size = new System.Drawing.Size(236, 30);
            this.saveBinMenu.Text = "保存为二进制文件";
            this.saveBinMenu.Click += new System.EventHandler(this.SaveBinMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1021, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "远程IP列表";
            // 
            // listRemoteIP
            // 
            this.listRemoteIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listRemoteIP.FormattingEnabled = true;
            this.listRemoteIP.ItemHeight = 16;
            this.listRemoteIP.Items.AddRange(new object[] {
            "所有"});
            this.listRemoteIP.Location = new System.Drawing.Point(923, 105);
            this.listRemoteIP.Name = "listRemoteIP";
            this.listRemoteIP.Size = new System.Drawing.Size(346, 404);
            this.listRemoteIP.TabIndex = 16;
            this.listRemoteIP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListRemoteIP_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 646);
            this.Controls.Add(this.listRemoteIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverPortText);
            this.Controls.Add(this.serverIPText);
            this.Controls.Add(this.serverPortLabel);
            this.Controls.Add(this.serverIPLabel);
            this.Controls.Add(this.localPanel);
            this.Controls.Add(this.buttonCloseLocal);
            this.Controls.Add(this.buttonOpenLocal);
            this.Controls.Add(this.localPortText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.localIPText);
            this.Controls.Add(this.localLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "基于UDP协议的网络调试工具";
            this.Load += new System.EventHandler(this.Form_Load);
            this.localPanel.ResumeLayout(false);
            this.localPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        



        #endregion

        private System.Windows.Forms.Label localLabel;
        public System.Windows.Forms.TextBox localIPText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox localPortText;
        private System.Windows.Forms.Button buttonOpenLocal;
        private System.Windows.Forms.Button buttonCloseLocal;
        private System.Windows.Forms.Panel localPanel;
        private System.Windows.Forms.Label serverIPLabel;
        private System.Windows.Forms.Label serverPortLabel;
        private System.Windows.Forms.TextBox serverIPText;
        private System.Windows.Forms.TextBox serverPortText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveLocalMenu;
        private System.Windows.Forms.Button localSendButton;
        private System.Windows.Forms.TextBox localSendText;
        private System.Windows.Forms.CheckBox checkBoxSend;
        private System.Windows.Forms.CheckBox checkBoxDisplay;
        private System.Windows.Forms.ToolStripMenuItem saveTxtMenu;
        private System.Windows.Forms.ToolStripMenuItem saveBinMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxReceive;
        private System.Windows.Forms.ListBox listRemoteIP;
    }
}

