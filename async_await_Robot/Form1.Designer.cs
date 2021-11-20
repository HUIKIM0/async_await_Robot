
namespace async_await_Robot
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pRobot = new System.Windows.Forms.Panel();
            this.pDoor2 = new System.Windows.Forms.Panel();
            this.pDoor1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxDelay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAsynchronous = new System.Windows.Forms.Button();
            this.btnSynchronous = new System.Windows.Forms.Button();
            this.btnGraphics = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRobotRotate = new System.Windows.Forms.Button();
            this.btnArmRetract = new System.Windows.Forms.Button();
            this.btnArmExtend = new System.Windows.Forms.Button();
            this.btnD2Close = new System.Windows.Forms.Button();
            this.btnD2Open = new System.Windows.Forms.Button();
            this.btnD1Close = new System.Windows.Forms.Button();
            this.btnD1Open = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lboxLog = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pRobot);
            this.groupBox1.Controls.Add(this.pDoor2);
            this.groupBox1.Controls.Add(this.pDoor1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display";
            // 
            // pRobot
            // 
            this.pRobot.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pRobot.Location = new System.Drawing.Point(60, 24);
            this.pRobot.Name = "pRobot";
            this.pRobot.Size = new System.Drawing.Size(189, 190);
            this.pRobot.TabIndex = 2;
            // 
            // pDoor2
            // 
            this.pDoor2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pDoor2.Location = new System.Drawing.Point(255, 24);
            this.pDoor2.Name = "pDoor2";
            this.pDoor2.Size = new System.Drawing.Size(47, 190);
            this.pDoor2.TabIndex = 1;
            // 
            // pDoor1
            // 
            this.pDoor1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pDoor1.Location = new System.Drawing.Point(7, 24);
            this.pDoor1.Name = "pDoor1";
            this.pDoor1.Size = new System.Drawing.Size(47, 190);
            this.pDoor1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tboxDelay);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnAsynchronous);
            this.groupBox2.Controls.Add(this.btnSynchronous);
            this.groupBox2.Controls.Add(this.btnGraphics);
            this.groupBox2.Location = new System.Drawing.Point(327, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "전체 동작";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "m/s";
            // 
            // tboxDelay
            // 
            this.tboxDelay.Location = new System.Drawing.Point(87, 68);
            this.tboxDelay.Name = "tboxDelay";
            this.tboxDelay.Size = new System.Drawing.Size(57, 25);
            this.tboxDelay.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "동작 Delay";
            // 
            // btnAsynchronous
            // 
            this.btnAsynchronous.Location = new System.Drawing.Point(6, 159);
            this.btnAsynchronous.Name = "btnAsynchronous";
            this.btnAsynchronous.Size = new System.Drawing.Size(171, 55);
            this.btnAsynchronous.TabIndex = 2;
            this.btnAsynchronous.Text = "비동기 동작 진행";
            this.btnAsynchronous.UseVisualStyleBackColor = true;
            this.btnAsynchronous.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSynchronous
            // 
            this.btnSynchronous.Location = new System.Drawing.Point(6, 98);
            this.btnSynchronous.Name = "btnSynchronous";
            this.btnSynchronous.Size = new System.Drawing.Size(171, 55);
            this.btnSynchronous.TabIndex = 1;
            this.btnSynchronous.Text = "동기 동작 진행";
            this.btnSynchronous.UseVisualStyleBackColor = true;
            this.btnSynchronous.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnGraphics
            // 
            this.btnGraphics.Location = new System.Drawing.Point(7, 25);
            this.btnGraphics.Name = "btnGraphics";
            this.btnGraphics.Size = new System.Drawing.Size(171, 36);
            this.btnGraphics.TabIndex = 0;
            this.btnGraphics.Text = "초기 화면 표시";
            this.btnGraphics.UseVisualStyleBackColor = true;
            this.btnGraphics.Click += new System.EventHandler(this.btn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRobotRotate);
            this.groupBox3.Controls.Add(this.btnArmRetract);
            this.groupBox3.Controls.Add(this.btnArmExtend);
            this.groupBox3.Controls.Add(this.btnD2Close);
            this.groupBox3.Controls.Add(this.btnD2Open);
            this.groupBox3.Controls.Add(this.btnD1Close);
            this.groupBox3.Controls.Add(this.btnD1Open);
            this.groupBox3.Location = new System.Drawing.Point(517, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 220);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "단위 동작";
            // 
            // btnRobotRotate
            // 
            this.btnRobotRotate.Location = new System.Drawing.Point(6, 183);
            this.btnRobotRotate.Name = "btnRobotRotate";
            this.btnRobotRotate.Size = new System.Drawing.Size(296, 31);
            this.btnRobotRotate.TabIndex = 12;
            this.btnRobotRotate.Text = "Robot Rotate";
            this.btnRobotRotate.UseVisualStyleBackColor = true;
            this.btnRobotRotate.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnArmRetract
            // 
            this.btnArmRetract.Location = new System.Drawing.Point(6, 146);
            this.btnArmRetract.Name = "btnArmRetract";
            this.btnArmRetract.Size = new System.Drawing.Size(296, 31);
            this.btnArmRetract.TabIndex = 11;
            this.btnArmRetract.Text = "Robot Arm Retract";
            this.btnArmRetract.UseVisualStyleBackColor = true;
            this.btnArmRetract.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnArmExtend
            // 
            this.btnArmExtend.Location = new System.Drawing.Point(6, 109);
            this.btnArmExtend.Name = "btnArmExtend";
            this.btnArmExtend.Size = new System.Drawing.Size(296, 31);
            this.btnArmExtend.TabIndex = 10;
            this.btnArmExtend.Text = "Robot Arm Extend";
            this.btnArmExtend.UseVisualStyleBackColor = true;
            this.btnArmExtend.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnD2Close
            // 
            this.btnD2Close.Location = new System.Drawing.Point(158, 67);
            this.btnD2Close.Name = "btnD2Close";
            this.btnD2Close.Size = new System.Drawing.Size(144, 36);
            this.btnD2Close.TabIndex = 9;
            this.btnD2Close.Text = "Door2 Close";
            this.btnD2Close.UseVisualStyleBackColor = true;
            this.btnD2Close.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnD2Open
            // 
            this.btnD2Open.Location = new System.Drawing.Point(6, 67);
            this.btnD2Open.Name = "btnD2Open";
            this.btnD2Open.Size = new System.Drawing.Size(144, 36);
            this.btnD2Open.TabIndex = 8;
            this.btnD2Open.Text = "Door2 Open";
            this.btnD2Open.UseVisualStyleBackColor = true;
            this.btnD2Open.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnD1Close
            // 
            this.btnD1Close.Location = new System.Drawing.Point(158, 25);
            this.btnD1Close.Name = "btnD1Close";
            this.btnD1Close.Size = new System.Drawing.Size(144, 36);
            this.btnD1Close.TabIndex = 7;
            this.btnD1Close.Text = "Door1 Close";
            this.btnD1Close.UseVisualStyleBackColor = true;
            this.btnD1Close.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnD1Open
            // 
            this.btnD1Open.Location = new System.Drawing.Point(6, 25);
            this.btnD1Open.Name = "btnD1Open";
            this.btnD1Open.Size = new System.Drawing.Size(144, 36);
            this.btnD1Open.TabIndex = 6;
            this.btnD1Open.Text = "Door1 Open";
            this.btnD1Open.UseVisualStyleBackColor = true;
            this.btnD1Open.Click += new System.EventHandler(this.btn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lboxLog);
            this.groupBox4.Location = new System.Drawing.Point(13, 239);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(812, 343);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "log View";
            // 
            // lboxLog
            // 
            this.lboxLog.FormattingEnabled = true;
            this.lboxLog.ItemHeight = 15;
            this.lboxLog.Location = new System.Drawing.Point(7, 25);
            this.lboxLog.Name = "lboxLog";
            this.lboxLog.Size = new System.Drawing.Size(799, 304);
            this.lboxLog.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(839, 594);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lboxLog;
        private System.Windows.Forms.Panel pRobot;
        private System.Windows.Forms.Panel pDoor2;
        private System.Windows.Forms.Panel pDoor1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAsynchronous;
        private System.Windows.Forms.Button btnSynchronous;
        private System.Windows.Forms.Button btnGraphics;
        private System.Windows.Forms.Button btnRobotRotate;
        private System.Windows.Forms.Button btnArmRetract;
        private System.Windows.Forms.Button btnArmExtend;
        private System.Windows.Forms.Button btnD2Close;
        private System.Windows.Forms.Button btnD2Open;
        private System.Windows.Forms.Button btnD1Close;
        private System.Windows.Forms.Button btnD1Open;
    }
}

