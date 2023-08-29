namespace Proiect
{
    partial class Form1Binding
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
            this.btnPopuleaza = new System.Windows.Forms.Button();
            this.lbClienti = new System.Windows.Forms.ListBox();
            this.dgvClienti = new System.Windows.Forms.DataGridView();
            this.btnAfisareDGV = new System.Windows.Forms.Button();
            this.btnAfiseaza = new System.Windows.Forms.Button();
            this.tbClienti = new System.Windows.Forms.TextBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienti)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPopuleaza
            // 
            this.btnPopuleaza.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnPopuleaza.Location = new System.Drawing.Point(36, 33);
            this.btnPopuleaza.Name = "btnPopuleaza";
            this.btnPopuleaza.Size = new System.Drawing.Size(228, 30);
            this.btnPopuleaza.TabIndex = 0;
            this.btnPopuleaza.Text = "Populeaza";
            this.btnPopuleaza.UseVisualStyleBackColor = false;
            this.btnPopuleaza.Click += new System.EventHandler(this.btnPopuleaza_Click);
            // 
            // lbClienti
            // 
            this.lbClienti.BackColor = System.Drawing.SystemColors.Info;
            this.lbClienti.FormattingEnabled = true;
            this.lbClienti.ItemHeight = 16;
            this.lbClienti.Location = new System.Drawing.Point(36, 69);
            this.lbClienti.Name = "lbClienti";
            this.lbClienti.Size = new System.Drawing.Size(354, 228);
            this.lbClienti.TabIndex = 1;
            // 
            // dgvClienti
            // 
            this.dgvClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClienti.Location = new System.Drawing.Point(429, 69);
            this.dgvClienti.Name = "dgvClienti";
            this.dgvClienti.RowHeadersWidth = 51;
            this.dgvClienti.RowTemplate.Height = 24;
            this.dgvClienti.Size = new System.Drawing.Size(328, 228);
            this.dgvClienti.TabIndex = 2;
            // 
            // btnAfisareDGV
            // 
            this.btnAfisareDGV.BackColor = System.Drawing.Color.LightGreen;
            this.btnAfisareDGV.Location = new System.Drawing.Point(429, 349);
            this.btnAfisareDGV.Name = "btnAfisareDGV";
            this.btnAfisareDGV.Size = new System.Drawing.Size(122, 33);
            this.btnAfisareDGV.TabIndex = 3;
            this.btnAfisareDGV.Text = "Afisare date dgv";
            this.btnAfisareDGV.UseVisualStyleBackColor = false;
            this.btnAfisareDGV.Click += new System.EventHandler(this.btnAfisareDGV_Click);
            // 
            // btnAfiseaza
            // 
            this.btnAfiseaza.BackColor = System.Drawing.Color.LightGreen;
            this.btnAfiseaza.Location = new System.Drawing.Point(678, 349);
            this.btnAfiseaza.Name = "btnAfiseaza";
            this.btnAfiseaza.Size = new System.Drawing.Size(79, 33);
            this.btnAfiseaza.TabIndex = 4;
            this.btnAfiseaza.Text = "Afiseaza";
            this.btnAfiseaza.UseVisualStyleBackColor = false;
            this.btnAfiseaza.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbClienti
            // 
            this.tbClienti.BackColor = System.Drawing.Color.MistyRose;
            this.tbClienti.Location = new System.Drawing.Point(36, 324);
            this.tbClienti.Multiline = true;
            this.tbClienti.Name = "tbClienti";
            this.tbClienti.Size = new System.Drawing.Size(354, 58);
            this.tbClienti.TabIndex = 5;
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnPrev.Location = new System.Drawing.Point(36, 404);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(61, 34);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.Tag = "Prev";
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnNext.Location = new System.Drawing.Point(126, 404);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(65, 34);
            this.btnNext.TabIndex = 7;
            this.btnNext.Tag = "Next";
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Form1Binding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.tbClienti);
            this.Controls.Add(this.btnAfiseaza);
            this.Controls.Add(this.btnAfisareDGV);
            this.Controls.Add(this.dgvClienti);
            this.Controls.Add(this.lbClienti);
            this.Controls.Add(this.btnPopuleaza);
            this.Name = "Form1Binding";
            this.Text = "Form1Binding";
            this.Load += new System.EventHandler(this.Form1Binding_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPopuleaza;
        private System.Windows.Forms.ListBox lbClienti;
        private System.Windows.Forms.DataGridView dgvClienti;
        private System.Windows.Forms.Button btnAfisareDGV;
        private System.Windows.Forms.Button btnAfiseaza;
        private System.Windows.Forms.TextBox tbClienti;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
    }
}