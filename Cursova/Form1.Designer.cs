namespace Cursova
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.button2 = new System.Windows.Forms.Button();
            this.countOfAirplane = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.stewardessCount = new System.Windows.Forms.Label();
            this.serviceTableCount = new System.Windows.Forms.Label();
            this.countFirstClassServiceTable = new System.Windows.Forms.Label();
            this.countSecondClassServiceTable = new System.Windows.Forms.Label();
            this.totalHumanQeue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.avgSellTime = new System.Windows.Forms.Label();
            this.chooseTypeServiceDesk = new System.Windows.Forms.ComboBox();
            this.addServiceDesk = new System.Windows.Forms.Button();
            this.addStewardess = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.avgTimeRegister = new System.Windows.Forms.Label();
            this.maxTimeSell = new System.Windows.Forms.Label();
            this.maxTimeReg = new System.Windows.Forms.Label();
            this.skippedHuman = new System.Windows.Forms.Label();
            this.totalFlyingPassanger = new System.Windows.Forms.Label();
            this.totalSellTicket = new System.Windows.Forms.Label();
            this.stopAirplaneGenerate = new System.Windows.Forms.Button();
            this.addHumanToQeue = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.totalRegisterPassanger = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Виліт літаку";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // countOfAirplane
            // 
            this.countOfAirplane.Location = new System.Drawing.Point(173, 9);
            this.countOfAirplane.Name = "countOfAirplane";
            this.countOfAirplane.Size = new System.Drawing.Size(103, 19);
            this.countOfAirplane.TabIndex = 2;
            this.countOfAirplane.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кількість літаків в аєропорту";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Кількість стюардес:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Кількість стійок:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(173, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Стійки першого класу:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(173, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Стійки другого класу:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Загальна кількість людей в черзі:\r\n";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(438, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(312, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "Статистика:\r\n";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // stewardessCount
            // 
            this.stewardessCount.Location = new System.Drawing.Point(120, 32);
            this.stewardessCount.Name = "stewardessCount";
            this.stewardessCount.Size = new System.Drawing.Size(103, 19);
            this.stewardessCount.TabIndex = 10;
            this.stewardessCount.Text = "0";
            // 
            // serviceTableCount
            // 
            this.serviceTableCount.Location = new System.Drawing.Point(100, 64);
            this.serviceTableCount.Name = "serviceTableCount";
            this.serviceTableCount.Size = new System.Drawing.Size(67, 19);
            this.serviceTableCount.TabIndex = 11;
            this.serviceTableCount.Text = "0";
            // 
            // countFirstClassServiceTable
            // 
            this.countFirstClassServiceTable.Location = new System.Drawing.Point(300, 64);
            this.countFirstClassServiceTable.Name = "countFirstClassServiceTable";
            this.countFirstClassServiceTable.Size = new System.Drawing.Size(67, 19);
            this.countFirstClassServiceTable.TabIndex = 12;
            this.countFirstClassServiceTable.Text = "0";
            // 
            // countSecondClassServiceTable
            // 
            this.countSecondClassServiceTable.Location = new System.Drawing.Point(300, 87);
            this.countSecondClassServiceTable.Name = "countSecondClassServiceTable";
            this.countSecondClassServiceTable.Size = new System.Drawing.Size(67, 19);
            this.countSecondClassServiceTable.TabIndex = 13;
            this.countSecondClassServiceTable.Text = "0";
            // 
            // totalHumanQeue
            // 
            this.totalHumanQeue.Location = new System.Drawing.Point(192, 124);
            this.totalHumanQeue.Name = "totalHumanQeue";
            this.totalHumanQeue.Size = new System.Drawing.Size(67, 19);
            this.totalHumanQeue.TabIndex = 14;
            this.totalHumanQeue.Text = "0";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(438, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(239, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Всього продано квитків:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(438, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Всього доставлено пасажирів:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(438, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(239, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "Середній час продажу квитку:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(438, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(239, 19);
            this.label11.TabIndex = 18;
            this.label11.Text = "Середній час реєстрації пасажирів:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(438, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(239, 19);
            this.label13.TabIndex = 20;
            this.label13.Text = "Максимальний час реєстрації пасажирів:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(438, 177);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(239, 19);
            this.label14.TabIndex = 19;
            this.label14.Text = "Максимальний час продажу квитку:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // avgSellTime
            // 
            this.avgSellTime.Location = new System.Drawing.Point(683, 123);
            this.avgSellTime.Name = "avgSellTime";
            this.avgSellTime.Size = new System.Drawing.Size(67, 19);
            this.avgSellTime.TabIndex = 23;
            this.avgSellTime.Text = "0";
            // 
            // chooseTypeServiceDesk
            // 
            this.chooseTypeServiceDesk.FormattingEnabled = true;
            this.chooseTypeServiceDesk.Items.AddRange(new object[] {"First", "Second"});
            this.chooseTypeServiceDesk.Location = new System.Drawing.Point(12, 153);
            this.chooseTypeServiceDesk.Name = "chooseTypeServiceDesk";
            this.chooseTypeServiceDesk.Size = new System.Drawing.Size(133, 21);
            this.chooseTypeServiceDesk.TabIndex = 24;
            // 
            // addServiceDesk
            // 
            this.addServiceDesk.Location = new System.Drawing.Point(151, 151);
            this.addServiceDesk.Name = "addServiceDesk";
            this.addServiceDesk.Size = new System.Drawing.Size(102, 23);
            this.addServiceDesk.TabIndex = 25;
            this.addServiceDesk.Text = "Додати стійку";
            this.addServiceDesk.UseVisualStyleBackColor = true;
            this.addServiceDesk.Click += new System.EventHandler(this.addServiceDesk_Click);
            // 
            // addStewardess
            // 
            this.addStewardess.Location = new System.Drawing.Point(15, 386);
            this.addStewardess.Name = "addStewardess";
            this.addStewardess.Size = new System.Drawing.Size(238, 23);
            this.addStewardess.TabIndex = 26;
            this.addStewardess.Text = "Додати стюардесу що очікує вільної стійки";
            this.addStewardess.UseVisualStyleBackColor = true;
            this.addStewardess.Click += new System.EventHandler(this.addStewardess_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(438, 224);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(239, 19);
            this.label15.TabIndex = 27;
            this.label15.Text = "Люди, що пішли на вокзал:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // avgTimeRegister
            // 
            this.avgTimeRegister.Location = new System.Drawing.Point(683, 142);
            this.avgTimeRegister.Name = "avgTimeRegister";
            this.avgTimeRegister.Size = new System.Drawing.Size(67, 19);
            this.avgTimeRegister.TabIndex = 28;
            this.avgTimeRegister.Text = "0";
            // 
            // maxTimeSell
            // 
            this.maxTimeSell.Location = new System.Drawing.Point(683, 177);
            this.maxTimeSell.Name = "maxTimeSell";
            this.maxTimeSell.Size = new System.Drawing.Size(67, 19);
            this.maxTimeSell.TabIndex = 29;
            this.maxTimeSell.Text = "0";
            // 
            // maxTimeReg
            // 
            this.maxTimeReg.Location = new System.Drawing.Point(683, 194);
            this.maxTimeReg.Name = "maxTimeReg";
            this.maxTimeReg.Size = new System.Drawing.Size(67, 19);
            this.maxTimeReg.TabIndex = 30;
            this.maxTimeReg.Text = "0";
            // 
            // skippedHuman
            // 
            this.skippedHuman.Location = new System.Drawing.Point(683, 224);
            this.skippedHuman.Name = "skippedHuman";
            this.skippedHuman.Size = new System.Drawing.Size(67, 19);
            this.skippedHuman.TabIndex = 31;
            this.skippedHuman.Text = "0";
            // 
            // totalFlyingPassanger
            // 
            this.totalFlyingPassanger.Location = new System.Drawing.Point(683, 51);
            this.totalFlyingPassanger.Name = "totalFlyingPassanger";
            this.totalFlyingPassanger.Size = new System.Drawing.Size(67, 19);
            this.totalFlyingPassanger.TabIndex = 32;
            this.totalFlyingPassanger.Text = "0";
            // 
            // totalSellTicket
            // 
            this.totalSellTicket.Location = new System.Drawing.Point(683, 28);
            this.totalSellTicket.Name = "totalSellTicket";
            this.totalSellTicket.Size = new System.Drawing.Size(67, 19);
            this.totalSellTicket.TabIndex = 33;
            this.totalSellTicket.Text = "0";
            this.totalSellTicket.TextChanged += new System.EventHandler(this.totalSellTicket_TextChanged);
            // 
            // stopAirplaneGenerate
            // 
            this.stopAirplaneGenerate.Location = new System.Drawing.Point(12, 302);
            this.stopAirplaneGenerate.Name = "stopAirplaneGenerate";
            this.stopAirplaneGenerate.Size = new System.Drawing.Size(241, 23);
            this.stopAirplaneGenerate.TabIndex = 34;
            this.stopAirplaneGenerate.Text = "Зупинити генерацію літаків";
            this.stopAirplaneGenerate.UseVisualStyleBackColor = true;
            this.stopAirplaneGenerate.Click += new System.EventHandler(this.stopAirplaneGenerate_Click);
            // 
            // addHumanToQeue
            // 
            this.addHumanToQeue.Location = new System.Drawing.Point(12, 348);
            this.addHumanToQeue.Name = "addHumanToQeue";
            this.addHumanToQeue.Size = new System.Drawing.Size(155, 23);
            this.addHumanToQeue.TabIndex = 35;
            this.addHumanToQeue.Text = "Додати людину до черги";
            this.addHumanToQeue.UseVisualStyleBackColor = true;
            this.addHumanToQeue.Click += new System.EventHandler(this.addHumanToQeue_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(438, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(239, 19);
            this.label16.TabIndex = 36;
            this.label16.Text = "Всього зареєстровано пасажирів:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // totalRegisterPassanger
            // 
            this.totalRegisterPassanger.Location = new System.Drawing.Point(683, 70);
            this.totalRegisterPassanger.Name = "totalRegisterPassanger";
            this.totalRegisterPassanger.Size = new System.Drawing.Size(67, 19);
            this.totalRegisterPassanger.TabIndex = 37;
            this.totalRegisterPassanger.Text = "0";
            // this.totalRegisterPassanger.Click += new System.EventHandler(this.totalRegisterPassanger_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Зупинити генерацію людей в черги";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(241, 23);
            this.button3.TabIndex = 39;
            this.button3.Text = "Запустити генерацію людей в черги";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 273);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(241, 23);
            this.button4.TabIndex = 40;
            this.button4.Text = "Запустити генерацію літаків";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(610, 386);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(140, 49);
            this.start.TabIndex = 41;
            this.start.Text = "StartService";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 450);
            this.Controls.Add(this.start);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.totalRegisterPassanger);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.addHumanToQeue);
            this.Controls.Add(this.stopAirplaneGenerate);
            this.Controls.Add(this.totalSellTicket);
            this.Controls.Add(this.totalFlyingPassanger);
            this.Controls.Add(this.skippedHuman);
            this.Controls.Add(this.maxTimeReg);
            this.Controls.Add(this.maxTimeSell);
            this.Controls.Add(this.avgTimeRegister);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.addStewardess);
            this.Controls.Add(this.addServiceDesk);
            this.Controls.Add(this.chooseTypeServiceDesk);
            this.Controls.Add(this.avgSellTime);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.totalHumanQeue);
            this.Controls.Add(this.countSecondClassServiceTable);
            this.Controls.Add(this.countFirstClassServiceTable);
            this.Controls.Add(this.serviceTableCount);
            this.Controls.Add(this.stewardessCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.countOfAirplane);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button start;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.Label totalRegisterPassanger;

        private System.Windows.Forms.Button addHumanToQeue;

        private System.Windows.Forms.Label totalHumanQeue;

        private System.Windows.Forms.Button stopAirplaneGenerate;

        private System.Windows.Forms.Label avgTimeRegister;
        private System.Windows.Forms.Label maxTimeSell;
        private System.Windows.Forms.Label maxTimeReg;
        private System.Windows.Forms.Label skippedHuman;
        private System.Windows.Forms.Label totalFlyingPassanger;
        private System.Windows.Forms.Label totalSellTicket;

        private System.Windows.Forms.Button addStewardess;

        private System.Windows.Forms.ComboBox chooseTypeServiceDesk;
        private System.Windows.Forms.Button addServiceDesk;

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;

        private System.Windows.Forms.Label totalTicketSell;
        private System.Windows.Forms.Label totalPassangerFlying;
        private System.Windows.Forms.Label avgSellTime;
        private System.Windows.Forms.Label abgServiceTime;
        private System.Windows.Forms.Label maxServiceTime;

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;

        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.Label stewardessCount;
        private System.Windows.Forms.Label serviceTableCount;
        private System.Windows.Forms.Label countFirstClassServiceTable;
        private System.Windows.Forms.Label countSecondClassServiceTable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label countOfAirplane;

        private System.Windows.Forms.Button button2;

        #endregion
    }
}