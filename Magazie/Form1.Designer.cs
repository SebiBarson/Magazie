namespace Magazie
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afisareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugareProdusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arhivareMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valoareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cladirea1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perPersoanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alteComenziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schimbareParolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergereMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stocToolStripMenuItem,
            this.consumToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.alteComenziToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // stocToolStripMenuItem
            // 
            this.stocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afisareToolStripMenuItem,
            this.adaugareProdusToolStripMenuItem,
            this.arhivareMaterialToolStripMenuItem,
            this.valoareToolStripMenuItem});
            this.stocToolStripMenuItem.Name = "stocToolStripMenuItem";
            this.stocToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.stocToolStripMenuItem.Text = "Stoc";
            // 
            // afisareToolStripMenuItem
            // 
            this.afisareToolStripMenuItem.Name = "afisareToolStripMenuItem";
            this.afisareToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.afisareToolStripMenuItem.Text = "Afișare";
            this.afisareToolStripMenuItem.Click += new System.EventHandler(this.afisareToolStripMenuItem_Click);
            // 
            // adaugareProdusToolStripMenuItem
            // 
            this.adaugareProdusToolStripMenuItem.Name = "adaugareProdusToolStripMenuItem";
            this.adaugareProdusToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.adaugareProdusToolStripMenuItem.Text = "Adăugare material";
            this.adaugareProdusToolStripMenuItem.Click += new System.EventHandler(this.adaugareProdusToolStripMenuItem_Click);
            // 
            // arhivareMaterialToolStripMenuItem
            // 
            this.arhivareMaterialToolStripMenuItem.Name = "arhivareMaterialToolStripMenuItem";
            this.arhivareMaterialToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.arhivareMaterialToolStripMenuItem.Text = "Arhivare material";
            this.arhivareMaterialToolStripMenuItem.Click += new System.EventHandler(this.arhivareMaterialToolStripMenuItem_Click);
            // 
            // valoareToolStripMenuItem
            // 
            this.valoareToolStripMenuItem.Name = "valoareToolStripMenuItem";
            this.valoareToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.valoareToolStripMenuItem.Text = "Valoare totală";
            this.valoareToolStripMenuItem.Click += new System.EventHandler(this.valoareToolStripMenuItem_Click);
            // 
            // consumToolStripMenuItem
            // 
            this.consumToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cladirea1ToolStripMenuItem,
            this.totalToolStripMenuItem,
            this.perMaterialToolStripMenuItem,
            this.perPersoanaToolStripMenuItem});
            this.consumToolStripMenuItem.Name = "consumToolStripMenuItem";
            this.consumToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.consumToolStripMenuItem.Text = "Consum";
            // 
            // cladirea1ToolStripMenuItem
            // 
            this.cladirea1ToolStripMenuItem.Name = "cladirea1ToolStripMenuItem";
            this.cladirea1ToolStripMenuItem.Size = new System.Drawing.Size(200, 30);
            this.cladirea1ToolStripMenuItem.Text = "Per cladire";
            this.cladirea1ToolStripMenuItem.Click += new System.EventHandler(this.cladirea1ToolStripMenuItem_Click);
            // 
            // totalToolStripMenuItem
            // 
            this.totalToolStripMenuItem.Name = "totalToolStripMenuItem";
            this.totalToolStripMenuItem.Size = new System.Drawing.Size(200, 30);
            this.totalToolStripMenuItem.Text = "Per persoană";
            this.totalToolStripMenuItem.Click += new System.EventHandler(this.totalToolStripMenuItem_Click);
            // 
            // perMaterialToolStripMenuItem
            // 
            this.perMaterialToolStripMenuItem.Name = "perMaterialToolStripMenuItem";
            this.perMaterialToolStripMenuItem.Size = new System.Drawing.Size(200, 30);
            this.perMaterialToolStripMenuItem.Text = "Per material";
            this.perMaterialToolStripMenuItem.Click += new System.EventHandler(this.perMaterialToolStripMenuItem_Click);
            // 
            // perPersoanaToolStripMenuItem
            // 
            this.perPersoanaToolStripMenuItem.Name = "perPersoanaToolStripMenuItem";
            this.perPersoanaToolStripMenuItem.Size = new System.Drawing.Size(200, 30);
            this.perPersoanaToolStripMenuItem.Text = "Total";
            this.perPersoanaToolStripMenuItem.Click += new System.EventHandler(this.perPersoanaToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(196, 29);
            this.exportToolStripMenuItem.Text = "Distribuire Material";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // alteComenziToolStripMenuItem
            // 
            this.alteComenziToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schimbareParolaToolStripMenuItem,
            this.stergereMaterialToolStripMenuItem});
            this.alteComenziToolStripMenuItem.Name = "alteComenziToolStripMenuItem";
            this.alteComenziToolStripMenuItem.Size = new System.Drawing.Size(138, 29);
            this.alteComenziToolStripMenuItem.Text = "Alte comenzi";
            this.alteComenziToolStripMenuItem.Click += new System.EventHandler(this.alteComenziToolStripMenuItem_Click);
            // 
            // schimbareParolaToolStripMenuItem
            // 
            this.schimbareParolaToolStripMenuItem.Name = "schimbareParolaToolStripMenuItem";
            this.schimbareParolaToolStripMenuItem.Size = new System.Drawing.Size(239, 30);
            this.schimbareParolaToolStripMenuItem.Text = "Schimbare parolă";
            this.schimbareParolaToolStripMenuItem.Click += new System.EventHandler(this.schimbareParolaToolStripMenuItem_Click_1);
            // 
            // stergereMaterialToolStripMenuItem
            // 
            this.stergereMaterialToolStripMenuItem.Name = "stergereMaterialToolStripMenuItem";
            this.stergereMaterialToolStripMenuItem.Size = new System.Drawing.Size(239, 30);
            this.stergereMaterialToolStripMenuItem.Text = "Ștergere material";
            this.stergereMaterialToolStripMenuItem.Click += new System.EventHandler(this.stergereMaterialToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(520, 232);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Location = new System.Drawing.Point(12, 274);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(520, 130);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(12, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(520, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ieșire";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 469);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Magazie";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afisareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugareProdusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valoareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cladirea1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perPersoanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStripMenuItem totalToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem perMaterialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arhivareMaterialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alteComenziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schimbareParolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergereMaterialToolStripMenuItem;
    }
}

