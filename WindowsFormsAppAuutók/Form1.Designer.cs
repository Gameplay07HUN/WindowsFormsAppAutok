namespace WindowsFormsAppAuutók
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelRendszam = new System.Windows.Forms.Label();
            this.labelEvjarat = new System.Windows.Forms.Label();
            this.labelSzin = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxRendszam = new System.Windows.Forms.TextBox();
            this.numericUpDownEvJarat = new System.Windows.Forms.NumericUpDown();
            this.textBoxSzin = new System.Windows.Forms.TextBox();
            this.buttonUjAuto = new System.Windows.Forms.Button();
            this.buttonModositas = new System.Windows.Forms.Button();
            this.buttonTorles = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEvJarat)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 450);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelId);
            this.groupBox1.Controls.Add(this.labelRendszam);
            this.groupBox1.Controls.Add(this.labelEvjarat);
            this.groupBox1.Controls.Add(this.textBoxSzin);
            this.groupBox1.Controls.Add(this.labelSzin);
            this.groupBox1.Controls.Add(this.numericUpDownEvJarat);
            this.groupBox1.Controls.Add(this.textBoxId);
            this.groupBox1.Controls.Add(this.textBoxRendszam);
            this.groupBox1.Location = new System.Drawing.Point(126, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 450);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiválaszott autó adatai";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(50, 56);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 2;
            this.labelId.Text = "Id";
            // 
            // labelRendszam
            // 
            this.labelRendszam.AutoSize = true;
            this.labelRendszam.Location = new System.Drawing.Point(14, 96);
            this.labelRendszam.Name = "labelRendszam";
            this.labelRendszam.Size = new System.Drawing.Size(52, 13);
            this.labelRendszam.TabIndex = 3;
            this.labelRendszam.Text = "rendszám";
            // 
            // labelEvjarat
            // 
            this.labelEvjarat.AutoSize = true;
            this.labelEvjarat.Location = new System.Drawing.Point(27, 129);
            this.labelEvjarat.Name = "labelEvjarat";
            this.labelEvjarat.Size = new System.Drawing.Size(39, 13);
            this.labelEvjarat.TabIndex = 4;
            this.labelEvjarat.Text = "évjárat";
            // 
            // labelSzin
            // 
            this.labelSzin.AutoSize = true;
            this.labelSzin.Location = new System.Drawing.Point(39, 162);
            this.labelSzin.Name = "labelSzin";
            this.labelSzin.Size = new System.Drawing.Size(27, 13);
            this.labelSzin.TabIndex = 5;
            this.labelSzin.Text = "szín";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(72, 56);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 20);
            this.textBoxId.TabIndex = 6;
            // 
            // textBoxRendszam
            // 
            this.textBoxRendszam.Location = new System.Drawing.Point(72, 93);
            this.textBoxRendszam.Name = "textBoxRendszam";
            this.textBoxRendszam.Size = new System.Drawing.Size(100, 20);
            this.textBoxRendszam.TabIndex = 7;
            // 
            // numericUpDownEvJarat
            // 
            this.numericUpDownEvJarat.Location = new System.Drawing.Point(72, 129);
            this.numericUpDownEvJarat.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownEvJarat.Name = "numericUpDownEvJarat";
            this.numericUpDownEvJarat.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownEvJarat.TabIndex = 8;
            // 
            // textBoxSzin
            // 
            this.textBoxSzin.Location = new System.Drawing.Point(72, 162);
            this.textBoxSzin.Name = "textBoxSzin";
            this.textBoxSzin.Size = new System.Drawing.Size(100, 20);
            this.textBoxSzin.TabIndex = 9;
            // 
            // buttonUjAuto
            // 
            this.buttonUjAuto.Location = new System.Drawing.Point(137, 205);
            this.buttonUjAuto.Name = "buttonUjAuto";
            this.buttonUjAuto.Size = new System.Drawing.Size(197, 48);
            this.buttonUjAuto.TabIndex = 10;
            this.buttonUjAuto.Text = "Új autó";
            this.buttonUjAuto.UseVisualStyleBackColor = true;
            this.buttonUjAuto.Click += new System.EventHandler(this.buttonUjAuto_Click);
            // 
            // buttonModositas
            // 
            this.buttonModositas.Location = new System.Drawing.Point(137, 259);
            this.buttonModositas.Name = "buttonModositas";
            this.buttonModositas.Size = new System.Drawing.Size(197, 48);
            this.buttonModositas.TabIndex = 11;
            this.buttonModositas.Text = "Modosítás";
            this.buttonModositas.UseVisualStyleBackColor = true;
            // 
            // buttonTorles
            // 
            this.buttonTorles.Location = new System.Drawing.Point(137, 313);
            this.buttonTorles.Name = "buttonTorles";
            this.buttonTorles.Size = new System.Drawing.Size(197, 48);
            this.buttonTorles.TabIndex = 12;
            this.buttonTorles.Text = "Törlés";
            this.buttonTorles.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 450);
            this.Controls.Add(this.buttonTorles);
            this.Controls.Add(this.buttonModositas);
            this.Controls.Add(this.buttonUjAuto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Autók nyivántartása";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEvJarat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelRendszam;
        private System.Windows.Forms.Label labelEvjarat;
        private System.Windows.Forms.Label labelSzin;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxRendszam;
        private System.Windows.Forms.NumericUpDown numericUpDownEvJarat;
        private System.Windows.Forms.TextBox textBoxSzin;
        private System.Windows.Forms.Button buttonUjAuto;
        private System.Windows.Forms.Button buttonModositas;
        private System.Windows.Forms.Button buttonTorles;
    }
}

