namespace TCheatForm
{
	partial class MainForm
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
			this.tablicaWebBrowser = new System.Windows.Forms.WebBrowser();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.labelScreenShotTimer = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labelIterationNumber = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.labelKeys = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.labelDiagnosticsMsg = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tablicaWebBrowser
			// 
			this.tablicaWebBrowser.Location = new System.Drawing.Point(12, 12);
			this.tablicaWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.tablicaWebBrowser.Name = "tablicaWebBrowser";
			this.tablicaWebBrowser.Size = new System.Drawing.Size(1700, 1500);
			this.tablicaWebBrowser.TabIndex = 0;
			this.tablicaWebBrowser.Url = new System.Uri("http://nuta.tablica.pl", System.UriKind.Absolute);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(12, 12);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 1;
			this.buttonStart.Text = "Start (F11)";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(93, 12);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 2;
			this.buttonStop.Text = "Stop (F12)";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(189, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Screenshot timer:";
			// 
			// labelScreenShotTimer
			// 
			this.labelScreenShotTimer.AutoSize = true;
			this.labelScreenShotTimer.Location = new System.Drawing.Point(284, 17);
			this.labelScreenShotTimer.Name = "labelScreenShotTimer";
			this.labelScreenShotTimer.Size = new System.Drawing.Size(40, 13);
			this.labelScreenShotTimer.TabIndex = 4;
			this.labelScreenShotTimer.Text = "On/Off";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(415, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Iteration number:";
			// 
			// labelIterationNumber
			// 
			this.labelIterationNumber.AutoSize = true;
			this.labelIterationNumber.Location = new System.Drawing.Point(507, 17);
			this.labelIterationNumber.Name = "labelIterationNumber";
			this.labelIterationNumber.Size = new System.Drawing.Size(43, 13);
			this.labelIterationNumber.TabIndex = 8;
			this.labelIterationNumber.Text = "000000";
			this.labelIterationNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(330, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Keys:";
			// 
			// labelKeys
			// 
			this.labelKeys.AutoSize = true;
			this.labelKeys.Location = new System.Drawing.Point(369, 17);
			this.labelKeys.Name = "labelKeys";
			this.labelKeys.Size = new System.Drawing.Size(40, 13);
			this.labelKeys.TabIndex = 10;
			this.labelKeys.Text = "On/Off";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(567, 17);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(115, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Diagnostics messages:";
			// 
			// labelDiagnosticsMsg
			// 
			this.labelDiagnosticsMsg.AutoSize = true;
			this.labelDiagnosticsMsg.Location = new System.Drawing.Point(688, 17);
			this.labelDiagnosticsMsg.Name = "labelDiagnosticsMsg";
			this.labelDiagnosticsMsg.Size = new System.Drawing.Size(53, 13);
			this.labelDiagnosticsMsg.TabIndex = 12;
			this.labelDiagnosticsMsg.Text = "+ empty +";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1334, 696);
			this.Controls.Add(this.labelDiagnosticsMsg);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.labelKeys);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.labelIterationNumber);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.labelScreenShotTimer);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.tablicaWebBrowser);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tablica Cheater";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.WebBrowser tablicaWebBrowser;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelScreenShotTimer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelIterationNumber;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelKeys;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelDiagnosticsMsg;
	}
}

