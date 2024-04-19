/*
 * Created by SharpDevelop.
 * User: rm20212930048
 * Date: 17/08/2022
 * Time: 11:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace minecraftGame
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Timer contagem;
		public System.Windows.Forms.Timer all;
		public System.Windows.Forms.Label labelPaused;
		private System.Windows.Forms.Timer pausedTimer;
		public System.Windows.Forms.Button reiniciarBtn;
		public System.Windows.Forms.Button sairBtn;
		private System.Windows.Forms.Button startBtn;
		private System.Windows.Forms.Button creditsBtn;
		private System.Windows.Forms.Button backBtn;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.contagem = new System.Windows.Forms.Timer(this.components);
			this.all = new System.Windows.Forms.Timer(this.components);
			this.labelPaused = new System.Windows.Forms.Label();
			this.pausedTimer = new System.Windows.Forms.Timer(this.components);
			this.reiniciarBtn = new System.Windows.Forms.Button();
			this.sairBtn = new System.Windows.Forms.Button();
			this.startBtn = new System.Windows.Forms.Button();
			this.creditsBtn = new System.Windows.Forms.Button();
			this.backBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// contagem
			// 
			this.contagem.Interval = 1000;
			this.contagem.Tick += new System.EventHandler(this.ContagemTick);
			// 
			// all
			// 
			this.all.Interval = 5;
			this.all.Tick += new System.EventHandler(this.AllTick);
			// 
			// labelPaused
			// 
			this.labelPaused.BackColor = System.Drawing.Color.Transparent;
			this.labelPaused.Font = new System.Drawing.Font("Arial Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPaused.ForeColor = System.Drawing.Color.Red;
			this.labelPaused.Location = new System.Drawing.Point(18, 7);
			this.labelPaused.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPaused.Name = "labelPaused";
			this.labelPaused.Size = new System.Drawing.Size(412, 97);
			this.labelPaused.TabIndex = 0;
			this.labelPaused.Text = "PAUSED";
			this.labelPaused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelPaused.Visible = false;
			// 
			// pausedTimer
			// 
			this.pausedTimer.Interval = 500;
			this.pausedTimer.Tick += new System.EventHandler(this.PausedTimerTick);
			// 
			// reiniciarBtn
			// 
			this.reiniciarBtn.BackColor = System.Drawing.Color.Red;
			this.reiniciarBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reiniciarBtn.BackgroundImage")));
			this.reiniciarBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.reiniciarBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.reiniciarBtn.Enabled = false;
			this.reiniciarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.reiniciarBtn.Font = new System.Drawing.Font("Arial Black", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.reiniciarBtn.ForeColor = System.Drawing.Color.White;
			this.reiniciarBtn.Location = new System.Drawing.Point(18, 106);
			this.reiniciarBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.reiniciarBtn.Name = "reiniciarBtn";
			this.reiniciarBtn.Size = new System.Drawing.Size(256, 55);
			this.reiniciarBtn.TabIndex = 1;
			this.reiniciarBtn.UseVisualStyleBackColor = false;
			this.reiniciarBtn.Visible = false;
			this.reiniciarBtn.Click += new System.EventHandler(this.Restart);
			// 
			// sairBtn
			// 
			this.sairBtn.BackColor = System.Drawing.Color.DarkCyan;
			this.sairBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sairBtn.BackgroundImage")));
			this.sairBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.sairBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.sairBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sairBtn.Font = new System.Drawing.Font("Arial Black", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sairBtn.ForeColor = System.Drawing.Color.White;
			this.sairBtn.Location = new System.Drawing.Point(18, 167);
			this.sairBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.sairBtn.Name = "sairBtn";
			this.sairBtn.Size = new System.Drawing.Size(256, 55);
			this.sairBtn.TabIndex = 3;
			this.sairBtn.UseVisualStyleBackColor = false;
			this.sairBtn.Click += new System.EventHandler(this.Quit);
			// 
			// startBtn
			// 
			this.startBtn.BackColor = System.Drawing.Color.MediumTurquoise;
			this.startBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startBtn.BackgroundImage")));
			this.startBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.startBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.startBtn.Font = new System.Drawing.Font("Arial Black", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startBtn.ForeColor = System.Drawing.Color.White;
			this.startBtn.Location = new System.Drawing.Point(18, 227);
			this.startBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(256, 55);
			this.startBtn.TabIndex = 4;
			this.startBtn.UseVisualStyleBackColor = false;
			this.startBtn.Click += new System.EventHandler(this.ButtonClick);
			// 
			// creditsBtn
			// 
			this.creditsBtn.BackColor = System.Drawing.Color.LightSeaGreen;
			this.creditsBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("creditsBtn.BackgroundImage")));
			this.creditsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.creditsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.creditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.creditsBtn.Font = new System.Drawing.Font("Arial Black", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.creditsBtn.ForeColor = System.Drawing.Color.White;
			this.creditsBtn.Location = new System.Drawing.Point(18, 286);
			this.creditsBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.creditsBtn.Name = "creditsBtn";
			this.creditsBtn.Size = new System.Drawing.Size(256, 55);
			this.creditsBtn.TabIndex = 5;
			this.creditsBtn.UseVisualStyleBackColor = false;
			this.creditsBtn.Click += new System.EventHandler(this.Credits);
			// 
			// backBtn
			// 
			this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.backBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backBtn.BackgroundImage")));
			this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.backBtn.Font = new System.Drawing.Font("Arial Black", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.backBtn.ForeColor = System.Drawing.Color.White;
			this.backBtn.Location = new System.Drawing.Point(18, 345);
			this.backBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.backBtn.Name = "backBtn";
			this.backBtn.Size = new System.Drawing.Size(256, 55);
			this.backBtn.TabIndex = 6;
			this.backBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.backBtn.UseVisualStyleBackColor = false;
			this.backBtn.Visible = false;
			this.backBtn.Click += new System.EventHandler(this.Back);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(962, 419);
			this.Controls.Add(this.backBtn);
			this.Controls.Add(this.creditsBtn);
			this.Controls.Add(this.startBtn);
			this.Controls.Add(this.sairBtn);
			this.Controls.Add(this.reiniciarBtn);
			this.Controls.Add(this.labelPaused);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Minecraft 2.0";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
			this.ResumeLayout(false);

		}
	}
}

//Código de Alicia Reis Marcolino e Fabrício Prudente Ferreira