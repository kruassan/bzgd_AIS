namespace bzgd_AIS.Model.GlobalControls
{
    partial class InitalizeConfigurationWindow
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
			this.SaveConfiguration = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ServerIP = new System.Windows.Forms.TextBox();
			this.ServerPort = new System.Windows.Forms.TextBox();
			this.HideIntoTrayChB = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// SaveConfiguration
			// 
			this.SaveConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SaveConfiguration.Location = new System.Drawing.Point(71, 152);
			this.SaveConfiguration.Name = "SaveConfiguration";
			this.SaveConfiguration.Size = new System.Drawing.Size(250, 50);
			this.SaveConfiguration.TabIndex = 0;
			this.SaveConfiguration.Text = "Сохранить";
			this.SaveConfiguration.UseVisualStyleBackColor = true;
			this.SaveConfiguration.Click += new System.EventHandler(this.SaveConfiguration_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "IP сервера";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(8, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Порт сервера";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(12, 118);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Сворачивание в трей";
			// 
			// ServerIP
			// 
			this.ServerIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ServerIP.Location = new System.Drawing.Point(113, 19);
			this.ServerIP.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
			this.ServerIP.Name = "ServerIP";
			this.ServerIP.Size = new System.Drawing.Size(259, 24);
			this.ServerIP.TabIndex = 5;
			// 
			// ServerPort
			// 
			this.ServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ServerPort.Location = new System.Drawing.Point(113, 66);
			this.ServerPort.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
			this.ServerPort.Name = "ServerPort";
			this.ServerPort.Size = new System.Drawing.Size(259, 24);
			this.ServerPort.TabIndex = 6;
			// 
			// HideIntoTrayChB
			// 
			this.HideIntoTrayChB.AutoSize = true;
			this.HideIntoTrayChB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.HideIntoTrayChB.Location = new System.Drawing.Point(168, 120);
			this.HideIntoTrayChB.Name = "HideIntoTrayChB";
			this.HideIntoTrayChB.Size = new System.Drawing.Size(15, 14);
			this.HideIntoTrayChB.TabIndex = 7;
			this.HideIntoTrayChB.UseVisualStyleBackColor = true;
			// 
			// InitalizeConfigurationWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(384, 211);
			this.Controls.Add(this.HideIntoTrayChB);
			this.Controls.Add(this.ServerPort);
			this.Controls.Add(this.ServerIP);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SaveConfiguration);
			this.MaximumSize = new System.Drawing.Size(400, 250);
			this.MinimumSize = new System.Drawing.Size(400, 250);
			this.Name = "InitalizeConfigurationWindow";
			this.Text = "InitalizeConfigurationWindow";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveConfiguration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ServerIP;
        private System.Windows.Forms.TextBox ServerPort;
        private System.Windows.Forms.CheckBox HideIntoTrayChB;
    }
}