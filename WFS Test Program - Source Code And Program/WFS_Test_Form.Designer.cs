namespace WFS_Test_Program
{
    partial class WFS_Test_Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.fontSizeReplaceBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pickSpecificFontBtn = new System.Windows.Forms.Button();
            this.fontToReplaceTB = new System.Windows.Forms.TextBox();
            this.replaceSpecificFontBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pickFontFamilyBtn = new System.Windows.Forms.Button();
            this.fontFamilyToReplaceTB = new System.Windows.Forms.TextBox();
            this.replaceFontFamilyBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxFontSizeReplaceUD = new System.Windows.Forms.NumericUpDown();
            this.minFontSizeReplaceUD = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.replaceFontsSizeBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeReplaceBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxFontSizeReplaceUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minFontSizeReplaceUD)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.fontSizeReplaceBox);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.replaceFontsSizeBtn);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(377, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 500);
            this.panel1.TabIndex = 0;
            // 
            // fontSizeReplaceBox
            // 
            this.fontSizeReplaceBox.DecimalPlaces = 2;
            this.fontSizeReplaceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSizeReplaceBox.Location = new System.Drawing.Point(122, 62);
            this.fontSizeReplaceBox.Name = "fontSizeReplaceBox";
            this.fontSizeReplaceBox.Size = new System.Drawing.Size(137, 26);
            this.fontSizeReplaceBox.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pickSpecificFontBtn);
            this.groupBox3.Controls.Add(this.fontToReplaceTB);
            this.groupBox3.Controls.Add(this.replaceSpecificFontBtn);
            this.groupBox3.Location = new System.Drawing.Point(16, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 101);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Font";
            // 
            // pickSpecificFontBtn
            // 
            this.pickSpecificFontBtn.Location = new System.Drawing.Point(6, 48);
            this.pickSpecificFontBtn.Name = "pickSpecificFontBtn";
            this.pickSpecificFontBtn.Size = new System.Drawing.Size(58, 43);
            this.pickSpecificFontBtn.TabIndex = 13;
            this.pickSpecificFontBtn.Text = "Pick Font";
            this.pickSpecificFontBtn.UseVisualStyleBackColor = true;
            this.pickSpecificFontBtn.Click += new System.EventHandler(this.pickSpecificFontBtn_Click);
            // 
            // fontToReplaceTB
            // 
            this.fontToReplaceTB.Location = new System.Drawing.Point(70, 48);
            this.fontToReplaceTB.Multiline = true;
            this.fontToReplaceTB.Name = "fontToReplaceTB";
            this.fontToReplaceTB.ReadOnly = true;
            this.fontToReplaceTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fontToReplaceTB.Size = new System.Drawing.Size(167, 43);
            this.fontToReplaceTB.TabIndex = 12;
            // 
            // replaceSpecificFontBtn
            // 
            this.replaceSpecificFontBtn.Location = new System.Drawing.Point(6, 19);
            this.replaceSpecificFontBtn.Name = "replaceSpecificFontBtn";
            this.replaceSpecificFontBtn.Size = new System.Drawing.Size(231, 23);
            this.replaceSpecificFontBtn.TabIndex = 11;
            this.replaceSpecificFontBtn.Text = "Replace Specific Font";
            this.replaceSpecificFontBtn.UseVisualStyleBackColor = true;
            this.replaceSpecificFontBtn.Click += new System.EventHandler(this.replaceSpecificFontBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pickFontFamilyBtn);
            this.groupBox2.Controls.Add(this.fontFamilyToReplaceTB);
            this.groupBox2.Controls.Add(this.replaceFontFamilyBtn);
            this.groupBox2.Location = new System.Drawing.Point(16, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 80);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Font Family";
            // 
            // pickFontFamilyBtn
            // 
            this.pickFontFamilyBtn.Location = new System.Drawing.Point(6, 48);
            this.pickFontFamilyBtn.Name = "pickFontFamilyBtn";
            this.pickFontFamilyBtn.Size = new System.Drawing.Size(116, 20);
            this.pickFontFamilyBtn.TabIndex = 15;
            this.pickFontFamilyBtn.Text = "Pick Font Family";
            this.pickFontFamilyBtn.UseVisualStyleBackColor = true;
            this.pickFontFamilyBtn.Click += new System.EventHandler(this.pickFontFamilyBtn_Click);
            // 
            // fontFamilyToReplaceTB
            // 
            this.fontFamilyToReplaceTB.Location = new System.Drawing.Point(128, 48);
            this.fontFamilyToReplaceTB.Name = "fontFamilyToReplaceTB";
            this.fontFamilyToReplaceTB.ReadOnly = true;
            this.fontFamilyToReplaceTB.Size = new System.Drawing.Size(109, 20);
            this.fontFamilyToReplaceTB.TabIndex = 14;
            // 
            // replaceFontFamilyBtn
            // 
            this.replaceFontFamilyBtn.Location = new System.Drawing.Point(6, 19);
            this.replaceFontFamilyBtn.Name = "replaceFontFamilyBtn";
            this.replaceFontFamilyBtn.Size = new System.Drawing.Size(231, 23);
            this.replaceFontFamilyBtn.TabIndex = 5;
            this.replaceFontFamilyBtn.Text = "Replace Fonts from Font Family:";
            this.replaceFontFamilyBtn.UseVisualStyleBackColor = true;
            this.replaceFontFamilyBtn.Click += new System.EventHandler(this.replaceFontFamilyBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxFontSizeReplaceUD);
            this.groupBox1.Controls.Add(this.minFontSizeReplaceUD);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 93);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size Range";
            // 
            // maxFontSizeReplaceUD
            // 
            this.maxFontSizeReplaceUD.DecimalPlaces = 2;
            this.maxFontSizeReplaceUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxFontSizeReplaceUD.Location = new System.Drawing.Point(153, 61);
            this.maxFontSizeReplaceUD.Name = "maxFontSizeReplaceUD";
            this.maxFontSizeReplaceUD.Size = new System.Drawing.Size(83, 22);
            this.maxFontSizeReplaceUD.TabIndex = 8;
            // 
            // minFontSizeReplaceUD
            // 
            this.minFontSizeReplaceUD.DecimalPlaces = 2;
            this.minFontSizeReplaceUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minFontSizeReplaceUD.Location = new System.Drawing.Point(16, 61);
            this.minFontSizeReplaceUD.Name = "minFontSizeReplaceUD";
            this.minFontSizeReplaceUD.Size = new System.Drawing.Size(83, 22);
            this.minFontSizeReplaceUD.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(231, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Replace Fonts between sizes:";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.replaceFontsWithinSizeRangeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Minimum Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maximum Size:";
            // 
            // replaceFontsSizeBtn
            // 
            this.replaceFontsSizeBtn.Location = new System.Drawing.Point(16, 58);
            this.replaceFontsSizeBtn.Name = "replaceFontsSizeBtn";
            this.replaceFontsSizeBtn.Size = new System.Drawing.Size(99, 35);
            this.replaceFontsSizeBtn.TabIndex = 2;
            this.replaceFontsSizeBtn.Text = "Replace Fonts that are size:";
            this.replaceFontsSizeBtn.UseVisualStyleBackColor = true;
            this.replaceFontsSizeBtn.Click += new System.EventHandler(this.replaceFontsSizeBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(243, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Apply Universal Font";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.setUniversalFontBtn);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Location = new System.Drawing.Point(16, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Undo Font Changes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.undoFontChangesBtn);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(12, 39);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(359, 500);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Test Replacement Options on Controls Here";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(84, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 80);
            this.label6.TabIndex = 6;
            this.label6.Text = "Arial Size 21.75";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(170, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "Calibri Size 12";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(51, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(233, 88);
            this.label8.TabIndex = 4;
            this.label8.Text = "Microsoft Sans Serif Size 20.25";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(664, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replacementFontToolStripMenuItem,
            this.programToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // replacementFontToolStripMenuItem
            // 
            this.replacementFontToolStripMenuItem.Name = "replacementFontToolStripMenuItem";
            this.replacementFontToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.replacementFontToolStripMenuItem.Text = "Replacement Font";
            this.replacementFontToolStripMenuItem.Click += new System.EventHandler(this.replacementFontToolStripMenuItem_Click);
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.programToolStripMenuItem.Text = "Program";
            this.programToolStripMenuItem.Click += new System.EventHandler(this.programToolStripMenuItem_Click);
            // 
            // WFS_Test_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 551);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WFS_Test_Form";
            this.Text = "Windows Font Swapper Test Program";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeReplaceBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxFontSizeReplaceUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minFontSizeReplaceUD)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button replaceFontsSizeBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button replaceFontFamilyBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button replaceSpecificFontBtn;
        private System.Windows.Forms.Button pickSpecificFontBtn;
        private System.Windows.Forms.TextBox fontToReplaceTB;
        private System.Windows.Forms.Button pickFontFamilyBtn;
        private System.Windows.Forms.TextBox fontFamilyToReplaceTB;
        private System.Windows.Forms.NumericUpDown fontSizeReplaceBox;
        private System.Windows.Forms.NumericUpDown maxFontSizeReplaceUD;
        private System.Windows.Forms.NumericUpDown minFontSizeReplaceUD;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
    }
}

