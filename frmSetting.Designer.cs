namespace sync_Kafka
{
    partial class frmSetting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCatalog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTopicETC1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHost1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTopicETC2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHost2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTimeMTC = new System.Windows.Forms.NumericUpDown();
            this.txtTimeETC = new System.Windows.Forms.NumericUpDown();
            this.CbRunAuto = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPathImgPlate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPathImg = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbKafka1 = new System.Windows.Forms.RadioButton();
            this.rbKafka2 = new System.Windows.Forms.RadioButton();
            this.txtTopicMTC1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTopicMTC2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeMTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeETC)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCatalog);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sql server";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(107, 96);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(212, 20);
            this.txtPass.TabIndex = 1;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(107, 70);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(212, 20);
            this.txtUser.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "User";
            // 
            // txtCatalog
            // 
            this.txtCatalog.Location = new System.Drawing.Point(107, 44);
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(212, 20);
            this.txtCatalog.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Catalog";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(107, 18);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(212, 20);
            this.txtServer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTopicMTC1);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtTopicETC1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtHost1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 99);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kafka server1";
            // 
            // txtTopicETC1
            // 
            this.txtTopicETC1.Location = new System.Drawing.Point(107, 44);
            this.txtTopicETC1.Name = "txtTopicETC1";
            this.txtTopicETC1.Size = new System.Drawing.Size(212, 20);
            this.txtTopicETC1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Topic ETC";
            // 
            // txtHost1
            // 
            this.txtHost1.Location = new System.Drawing.Point(107, 18);
            this.txtHost1.Name = "txtHost1";
            this.txtHost1.Size = new System.Drawing.Size(212, 20);
            this.txtHost1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Host";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTopicMTC2);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtTopicETC2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtHost2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(359, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 99);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kafka server2";
            // 
            // txtTopicETC2
            // 
            this.txtTopicETC2.Location = new System.Drawing.Point(107, 44);
            this.txtTopicETC2.Name = "txtTopicETC2";
            this.txtTopicETC2.Size = new System.Drawing.Size(212, 20);
            this.txtTopicETC2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Topic ETC";
            // 
            // txtHost2
            // 
            this.txtHost2.Location = new System.Drawing.Point(107, 18);
            this.txtHost2.Name = "txtHost2";
            this.txtHost2.Size = new System.Drawing.Size(212, 20);
            this.txtHost2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Host";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTimeMTC);
            this.groupBox4.Controls.Add(this.txtTimeETC);
            this.groupBox4.Controls.Add(this.CbRunAuto);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtPathImgPlate);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtPathImg);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(359, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(340, 158);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // txtTimeMTC
            // 
            this.txtTimeMTC.Location = new System.Drawing.Point(103, 97);
            this.txtTimeMTC.Name = "txtTimeMTC";
            this.txtTimeMTC.Size = new System.Drawing.Size(144, 20);
            this.txtTimeMTC.TabIndex = 2;
            // 
            // txtTimeETC
            // 
            this.txtTimeETC.Location = new System.Drawing.Point(103, 71);
            this.txtTimeETC.Name = "txtTimeETC";
            this.txtTimeETC.Size = new System.Drawing.Size(144, 20);
            this.txtTimeETC.TabIndex = 2;
            // 
            // CbRunAuto
            // 
            this.CbRunAuto.AutoSize = true;
            this.CbRunAuto.Location = new System.Drawing.Point(105, 127);
            this.CbRunAuto.Name = "CbRunAuto";
            this.CbRunAuto.Size = new System.Drawing.Size(70, 17);
            this.CbRunAuto.TabIndex = 3;
            this.CbRunAuto.Text = "Run auto";
            this.CbRunAuto.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(270, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "(Minute)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(270, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "(Minute)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 128);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Loading from";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Time Send MTC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Time Send ETC";
            // 
            // txtPathImgPlate
            // 
            this.txtPathImgPlate.Location = new System.Drawing.Point(103, 44);
            this.txtPathImgPlate.Name = "txtPathImgPlate";
            this.txtPathImgPlate.Size = new System.Drawing.Size(212, 20);
            this.txtPathImgPlate.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Path Image Plate";
            // 
            // txtPathImg
            // 
            this.txtPathImg.Location = new System.Drawing.Point(103, 18);
            this.txtPathImg.Name = "txtPathImg";
            this.txtPathImg.Size = new System.Drawing.Size(212, 20);
            this.txtPathImg.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Path Image";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(477, 354);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(599, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbKafka1
            // 
            this.rbKafka1.AutoSize = true;
            this.rbKafka1.Location = new System.Drawing.Point(175, 307);
            this.rbKafka1.Name = "rbKafka1";
            this.rbKafka1.Size = new System.Drawing.Size(120, 17);
            this.rbKafka1.TabIndex = 2;
            this.rbKafka1.TabStop = true;
            this.rbKafka1.Text = "Run default Server1";
            this.rbKafka1.UseVisualStyleBackColor = true;
            // 
            // rbKafka2
            // 
            this.rbKafka2.AutoSize = true;
            this.rbKafka2.Location = new System.Drawing.Point(521, 307);
            this.rbKafka2.Name = "rbKafka2";
            this.rbKafka2.Size = new System.Drawing.Size(118, 17);
            this.rbKafka2.TabIndex = 2;
            this.rbKafka2.TabStop = true;
            this.rbKafka2.Text = "Run default server2";
            this.rbKafka2.UseVisualStyleBackColor = true;
            // 
            // txtTopicMTC1
            // 
            this.txtTopicMTC1.Location = new System.Drawing.Point(107, 70);
            this.txtTopicMTC1.Name = "txtTopicMTC1";
            this.txtTopicMTC1.Size = new System.Drawing.Size(212, 20);
            this.txtTopicMTC1.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Topic MTC";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Topic MTC";
            // 
            // txtTopicMTC2
            // 
            this.txtTopicMTC2.Location = new System.Drawing.Point(107, 70);
            this.txtTopicMTC2.Name = "txtTopicMTC2";
            this.txtTopicMTC2.Size = new System.Drawing.Size(212, 20);
            this.txtTopicMTC2.TabIndex = 1;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 407);
            this.Controls.Add(this.rbKafka2);
            this.Controls.Add(this.rbKafka1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSetting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeMTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeETC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCatalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTopicETC1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHost1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTopicETC2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHost2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPathImgPlate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPathImg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox CbRunAuto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown txtTimeMTC;
        private System.Windows.Forms.NumericUpDown txtTimeETC;
        private System.Windows.Forms.RadioButton rbKafka1;
        private System.Windows.Forms.RadioButton rbKafka2;
        private System.Windows.Forms.TextBox txtTopicMTC1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTopicMTC2;
        private System.Windows.Forms.Label label17;
    }
}