namespace Fitness_Managment
{
    partial class FormOstad
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.ColumnTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxOnvan = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(514, 158);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 119);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 66;
            this.pictureBox2.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label21.Location = new System.Drawing.Point(538, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 20);
            this.label21.TabIndex = 67;
            this.label21.Text = "عکس کاور";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button4.Location = new System.Drawing.Point(514, 125);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 27);
            this.button4.TabIndex = 65;
            this.button4.Text = "انتخاب عکس";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label20.Location = new System.Drawing.Point(634, 2);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(19, 20);
            this.label20.TabIndex = 64;
            this.label20.Text = "نام";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(486, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(167, 20);
            this.textBoxName.TabIndex = 63;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AllowUserToOrderColumns = true;
            this.dataGridView4.AllowUserToResizeColumns = false;
            this.dataGridView4.AllowUserToResizeRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTID,
            this.ColumnName,
            this.ColumnImg,
            this.ColumnDesc});
            this.dataGridView4.Location = new System.Drawing.Point(3, 18);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView4.Size = new System.Drawing.Size(444, 240);
            this.dataGridView4.TabIndex = 59;
            // 
            // ColumnTID
            // 
            this.ColumnTID.HeaderText = "TID";
            this.ColumnTID.Name = "ColumnTID";
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnImg
            // 
            this.ColumnImg.HeaderText = "Img";
            this.ColumnImg.Name = "ColumnImg";
            // 
            // ColumnDesc
            // 
            this.ColumnDesc.HeaderText = "Desc";
            this.ColumnDesc.Name = "ColumnDesc";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button11.Location = new System.Drawing.Point(497, 305);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(135, 51);
            this.button11.TabIndex = 69;
            this.button11.Text = "اضافه کردن استاد";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.dataGridView4);
            this.groupBox5.Font = new System.Drawing.Font("B Nazanin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox5.Location = new System.Drawing.Point(12, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(456, 376);
            this.groupBox5.TabIndex = 68;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "اساتید ثبت شده";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label30.Location = new System.Drawing.Point(123, 276);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(180, 20);
            this.label30.TabIndex = 63;
            this.label30.Text = "از جدول را انتخاب کنید و دکمه زیر را بزنید";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button9.Enabled = false;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button9.Location = new System.Drawing.Point(114, 337);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(201, 33);
            this.button9.TabIndex = 62;
            this.button9.Text = "آپدیت کردن این اطلاعات";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button10.Location = new System.Drawing.Point(114, 299);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(201, 33);
            this.button10.TabIndex = 61;
            this.button10.Text = "رفتن به حالت آپدیت و ادیت";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label29.Location = new System.Drawing.Point(160, 259);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 20);
            this.label29.TabIndex = 60;
            this.label29.Text = "برای آپدیت یک سطر ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(622, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "عنوان";
            // 
            // textBoxOnvan
            // 
            this.textBoxOnvan.Location = new System.Drawing.Point(486, 69);
            this.textBoxOnvan.Name = "textBoxOnvan";
            this.textBoxOnvan.Size = new System.Drawing.Size(167, 20);
            this.textBoxOnvan.TabIndex = 70;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("B Nazanin", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label19.Location = new System.Drawing.Point(9, 147);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(653, 95);
            this.label19.TabIndex = 64;
            this.label19.Text = "در حال گرفتن اطلاعات از سرور";
            // 
            // FormOstad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkViolet;
            this.ClientSize = new System.Drawing.Size(666, 385);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOnvan);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.groupBox5);
            this.Name = "FormOstad";
            this.Text = "FormOstad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOstad_FormClosed);
            this.Load += new System.EventHandler(this.FormOstad_Load);
            this.Enter += new System.EventHandler(this.FormOstad_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxOnvan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDesc;
        private System.Windows.Forms.Label label19;
    }
}