namespace simulationTask2
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
            this.tbPurchase = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbScrap = new System.Windows.Forms.TextBox();
            this.tbPurchased = new System.Windows.Forms.TextBox();
            this.tbDayDemand = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDayProb = new System.Windows.Forms.TextBox();
            this.tbNumDay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BShow = new System.Windows.Forms.Button();
            this.BDayInfo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbGoodDemandProb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbFairDemandProb = new System.Windows.Forms.TextBox();
            this.tbPoorDemandProb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbPurchase
            // 
            this.tbPurchase.Location = new System.Drawing.Point(132, 54);
            this.tbPurchase.Name = "tbPurchase";
            this.tbPurchase.Size = new System.Drawing.Size(100, 20);
            this.tbPurchase.TabIndex = 0;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(401, 54);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(100, 20);
            this.tbPrice.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "purchase price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "selling price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "scrap value";
            // 
            // tbScrap
            // 
            this.tbScrap.Location = new System.Drawing.Point(132, 116);
            this.tbScrap.Name = "tbScrap";
            this.tbScrap.Size = new System.Drawing.Size(100, 20);
            this.tbScrap.TabIndex = 5;
            // 
            // tbPurchased
            // 
            this.tbPurchased.Location = new System.Drawing.Point(401, 116);
            this.tbPurchased.Name = "tbPurchased";
            this.tbPurchased.Size = new System.Drawing.Size(100, 20);
            this.tbPurchased.TabIndex = 6;
            // 
            // tbDayDemand
            // 
            this.tbDayDemand.Location = new System.Drawing.Point(132, 244);
            this.tbDayDemand.Name = "tbDayDemand";
            this.tbDayDemand.Size = new System.Drawing.Size(100, 20);
            this.tbDayDemand.TabIndex = 8;
            this.tbDayDemand.TextChanged += new System.EventHandler(this.tbDayDemand_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "papers purchased";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "day type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "day demand";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "day probability";
            // 
            // tbDayProb
            // 
            this.tbDayProb.Location = new System.Drawing.Point(401, 183);
            this.tbDayProb.Name = "tbDayProb";
            this.tbDayProb.Size = new System.Drawing.Size(100, 20);
            this.tbDayProb.TabIndex = 13;
            // 
            // tbNumDay
            // 
            this.tbNumDay.Location = new System.Drawing.Point(132, 367);
            this.tbNumDay.Name = "tbNumDay";
            this.tbNumDay.Size = new System.Drawing.Size(100, 20);
            this.tbNumDay.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "number of days";
            // 
            // BShow
            // 
            this.BShow.Location = new System.Drawing.Point(320, 356);
            this.BShow.Name = "BShow";
            this.BShow.Size = new System.Drawing.Size(137, 31);
            this.BShow.TabIndex = 16;
            this.BShow.Text = "Show";
            this.BShow.UseVisualStyleBackColor = true;
            this.BShow.Click += new System.EventHandler(this.BShow_Click);
            // 
            // BDayInfo
            // 
            this.BDayInfo.Location = new System.Drawing.Point(604, 307);
            this.BDayInfo.Name = "BDayInfo";
            this.BDayInfo.Size = new System.Drawing.Size(143, 31);
            this.BDayInfo.TabIndex = 17;
            this.BDayInfo.Text = "Enter Demand Infomation\r\n";
            this.BDayInfo.UseVisualStyleBackColor = true;
            this.BDayInfo.Click += new System.EventHandler(this.BDayInfo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 27);
            this.button1.TabIndex = 19;
            this.button1.Text = "Enter Day Probability";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Good ";
            // 
            // tbGoodDemandProb
            // 
            this.tbGoodDemandProb.Location = new System.Drawing.Point(65, 318);
            this.tbGoodDemandProb.Name = "tbGoodDemandProb";
            this.tbGoodDemandProb.Size = new System.Drawing.Size(100, 20);
            this.tbGoodDemandProb.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Fair ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(398, 325);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Poor ";
            // 
            // tbFairDemandProb
            // 
            this.tbFairDemandProb.Location = new System.Drawing.Point(263, 318);
            this.tbFairDemandProb.Name = "tbFairDemandProb";
            this.tbFairDemandProb.Size = new System.Drawing.Size(100, 20);
            this.tbFairDemandProb.TabIndex = 26;
            // 
            // tbPoorDemandProb
            // 
            this.tbPoorDemandProb.Location = new System.Drawing.Point(436, 318);
            this.tbPoorDemandProb.Name = "tbPoorDemandProb";
            this.tbPoorDemandProb.Size = new System.Drawing.Size(100, 20);
            this.tbPoorDemandProb.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 286);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Demand Probability For:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Good",
            "Fair",
            "Poor"});
            this.comboBox1.Location = new System.Drawing.Point(132, 181);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 29;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 404);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbPoorDemandProb);
            this.Controls.Add(this.tbFairDemandProb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbGoodDemandProb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BDayInfo);
            this.Controls.Add(this.BShow);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbNumDay);
            this.Controls.Add(this.tbDayProb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDayDemand);
            this.Controls.Add(this.tbPurchased);
            this.Controls.Add(this.tbScrap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbPurchase);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPurchase;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbScrap;
        private System.Windows.Forms.TextBox tbPurchased;
        private System.Windows.Forms.TextBox tbDayDemand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDayProb;
        private System.Windows.Forms.TextBox tbNumDay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BShow;
        private System.Windows.Forms.Button BDayInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbGoodDemandProb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbFairDemandProb;
        private System.Windows.Forms.TextBox tbPoorDemandProb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

