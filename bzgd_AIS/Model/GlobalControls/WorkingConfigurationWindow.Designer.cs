namespace bzgd_AIS.Model.GlobalControls
{
    partial class WorkingConfigurationWindow
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
			this.HideIntoTrayChB = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SaveConfiguration = new System.Windows.Forms.Button();
			this.AutoLoadChB = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// HideIntoTrayChB
			// 
			this.HideIntoTrayChB.AutoSize = true;
			this.HideIntoTrayChB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.HideIntoTrayChB.Location = new System.Drawing.Point(168, 11);
			this.HideIntoTrayChB.Name = "HideIntoTrayChB";
			this.HideIntoTrayChB.Size = new System.Drawing.Size(15, 14);
			this.HideIntoTrayChB.TabIndex = 16;
			this.HideIntoTrayChB.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 16);
			this.label3.TabIndex = 12;
			this.label3.Text = "Сворачивание в трей";
			// 
			// SaveConfiguration
			// 
			this.SaveConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SaveConfiguration.Location = new System.Drawing.Point(12, 71);
			this.SaveConfiguration.Name = "SaveConfiguration";
			this.SaveConfiguration.Size = new System.Drawing.Size(250, 50);
			this.SaveConfiguration.TabIndex = 9;
			this.SaveConfiguration.Text = "Сохранить";
			this.SaveConfiguration.UseVisualStyleBackColor = true;
			this.SaveConfiguration.Click += new System.EventHandler(this.SaveConfiguration_Click);
			// 
			// AutoLoadChB
			// 
			this.AutoLoadChB.AutoSize = true;
			this.AutoLoadChB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AutoLoadChB.Location = new System.Drawing.Point(222, 41);
			this.AutoLoadChB.Name = "AutoLoadChB";
			this.AutoLoadChB.Size = new System.Drawing.Size(15, 14);
			this.AutoLoadChB.TabIndex = 18;
			this.AutoLoadChB.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(204, 16);
			this.label1.TabIndex = 17;
			this.label1.Text = "Автозапуск вместе с Windows";
			// 
			// WorkingConfigurationWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(284, 132);
			this.Controls.Add(this.AutoLoadChB);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.HideIntoTrayChB);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SaveConfiguration);
			this.Name = "WorkingConfigurationWindow";
			this.Text = "Конфигурация программы";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox HideIntoTrayChB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveConfiguration;
		private System.Windows.Forms.CheckBox AutoLoadChB;
		private System.Windows.Forms.Label label1;
	}
}