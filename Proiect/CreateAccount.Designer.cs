namespace Proiect
{
    partial class CreateAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUsernameCreate = new System.Windows.Forms.TextBox();
            this.tbEmailCreate = new System.Windows.Forms.TextBox();
            this.tbPasswordCreate = new System.Windows.Forms.TextBox();
            this.tbRepeatPasswordCreate = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSendValidation = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCodPrimit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVerifica = new System.Windows.Forms.Button();
            this.btnMeniu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Repeat  password:";
            // 
            // tbUsernameCreate
            // 
            this.tbUsernameCreate.Location = new System.Drawing.Point(265, 147);
            this.tbUsernameCreate.Name = "tbUsernameCreate";
            this.tbUsernameCreate.Size = new System.Drawing.Size(100, 22);
            this.tbUsernameCreate.TabIndex = 5;
            // 
            // tbEmailCreate
            // 
            this.tbEmailCreate.Location = new System.Drawing.Point(265, 198);
            this.tbEmailCreate.Name = "tbEmailCreate";
            this.tbEmailCreate.Size = new System.Drawing.Size(100, 22);
            this.tbEmailCreate.TabIndex = 6;
            // 
            // tbPasswordCreate
            // 
            this.tbPasswordCreate.Location = new System.Drawing.Point(265, 248);
            this.tbPasswordCreate.Name = "tbPasswordCreate";
            this.tbPasswordCreate.Size = new System.Drawing.Size(100, 22);
            this.tbPasswordCreate.TabIndex = 7;
            this.tbPasswordCreate.UseSystemPasswordChar = true;
            // 
            // tbRepeatPasswordCreate
            // 
            this.tbRepeatPasswordCreate.Location = new System.Drawing.Point(265, 302);
            this.tbRepeatPasswordCreate.Name = "tbRepeatPasswordCreate";
            this.tbRepeatPasswordCreate.Size = new System.Drawing.Size(100, 22);
            this.tbRepeatPasswordCreate.TabIndex = 8;
            this.tbRepeatPasswordCreate.UseSystemPasswordChar = true;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnCreate.Location = new System.Drawing.Point(294, 352);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(154, 68);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSendValidation
            // 
            this.btnSendValidation.BackColor = System.Drawing.SystemColors.Info;
            this.btnSendValidation.Location = new System.Drawing.Point(392, 187);
            this.btnSendValidation.Name = "btnSendValidation";
            this.btnSendValidation.Size = new System.Drawing.Size(89, 45);
            this.btnSendValidation.TabIndex = 10;
            this.btnSendValidation.Text = "Send Validation";
            this.btnSendValidation.UseVisualStyleBackColor = false;
            this.btnSendValidation.Click += new System.EventHandler(this.btnSendValidation_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(614, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Validare email";
            // 
            // tbCodPrimit
            // 
            this.tbCodPrimit.Location = new System.Drawing.Point(667, 251);
            this.tbCodPrimit.Name = "tbCodPrimit";
            this.tbCodPrimit.Size = new System.Drawing.Size(100, 22);
            this.tbCodPrimit.TabIndex = 12;
            this.tbCodPrimit.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(522, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Introdu codul primit:";
            // 
            // btnVerifica
            // 
            this.btnVerifica.BackColor = System.Drawing.Color.LawnGreen;
            this.btnVerifica.Location = new System.Drawing.Point(626, 289);
            this.btnVerifica.Name = "btnVerifica";
            this.btnVerifica.Size = new System.Drawing.Size(72, 29);
            this.btnVerifica.TabIndex = 14;
            this.btnVerifica.Text = "Verifica";
            this.btnVerifica.UseVisualStyleBackColor = false;
            this.btnVerifica.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMeniu
            // 
            this.btnMeniu.BackColor = System.Drawing.SystemColors.Info;
            this.btnMeniu.Location = new System.Drawing.Point(681, 385);
            this.btnMeniu.Name = "btnMeniu";
            this.btnMeniu.Size = new System.Drawing.Size(86, 53);
            this.btnMeniu.TabIndex = 15;
            this.btnMeniu.Text = "Meniu";
            this.btnMeniu.UseVisualStyleBackColor = false;
            this.btnMeniu.Click += new System.EventHandler(this.btnMeniu_Click);
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMeniu);
            this.Controls.Add(this.btnVerifica);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbCodPrimit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSendValidation);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbRepeatPasswordCreate);
            this.Controls.Add(this.tbPasswordCreate);
            this.Controls.Add(this.tbEmailCreate);
            this.Controls.Add(this.tbUsernameCreate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateAccount";
            this.Text = "CreateAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUsernameCreate;
        private System.Windows.Forms.TextBox tbEmailCreate;
        private System.Windows.Forms.TextBox tbPasswordCreate;
        private System.Windows.Forms.TextBox tbRepeatPasswordCreate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSendValidation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCodPrimit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVerifica;
        private System.Windows.Forms.Button btnMeniu;
    }
}