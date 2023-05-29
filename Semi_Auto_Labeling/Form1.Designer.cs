﻿namespace Semi_Auto_Labeling
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Log = new System.Windows.Forms.RichTextBox();
            this.ImageOpen = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.eyeClosedCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.drowsnissCheckBox = new System.Windows.Forms.CheckBox();
            this.eyeGazeCheckBox = new System.Windows.Forms.CheckBox();
            this.headDirectionCheckBox = new System.Windows.Forms.CheckBox();
            this.ConvertibilityCheckBox = new System.Windows.Forms.CheckBox();
            this.abnormalBehaviorCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.faceLandmarkCheckBox = new System.Windows.Forms.CheckBox();
            this.poseCheckBox = new System.Windows.Forms.CheckBox();
            this.eyeLandmarkCheckBox = new System.Windows.Forms.CheckBox();
            this.mouthLandmarkCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.DrowsinessTextBox = new System.Windows.Forms.TextBox();
            this.modifyEyeClosedCB = new System.Windows.Forms.CheckBox();
            this.modifyYawnCB = new System.Windows.Forms.CheckBox();
            this.modifyDropHeadCB = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.lookForwardValueTextBox = new System.Windows.Forms.TextBox();
            this.modifyGazeForwardCB = new System.Windows.Forms.CheckBox();
            this.modifyFaceForwardCB = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sideViewSwitch = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Log.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Log.Location = new System.Drawing.Point(713, 788);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(776, 165);
            this.Log.TabIndex = 6;
            this.Log.Text = " ";
            this.Log.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            // 
            // ImageOpen
            // 
            this.ImageOpen.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ImageOpen.FlatAppearance.BorderSize = 2;
            this.ImageOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ImageOpen.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ImageOpen.Location = new System.Drawing.Point(12, 12);
            this.ImageOpen.Name = "ImageOpen";
            this.ImageOpen.Size = new System.Drawing.Size(80, 23);
            this.ImageOpen.TabIndex = 7;
            this.ImageOpen.Text = "Image";
            this.ImageOpen.UseVisualStyleBackColor = true;
            this.ImageOpen.Click += new System.EventHandler(this.imageOpen_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 38);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(292, 915);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(316, 763);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "레이블";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(575, 763);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "키 포인트";
            // 
            // eyeClosedCheckBox
            // 
            this.eyeClosedCheckBox.AutoSize = true;
            this.eyeClosedCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.eyeClosedCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.eyeClosedCheckBox.Location = new System.Drawing.Point(3, 3);
            this.eyeClosedCheckBox.Name = "eyeClosedCheckBox";
            this.eyeClosedCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.eyeClosedCheckBox.Size = new System.Drawing.Size(76, 21);
            this.eyeClosedCheckBox.TabIndex = 17;
            this.eyeClosedCheckBox.Text = "눈 감김";
            this.eyeClosedCheckBox.UseVisualStyleBackColor = true;
            this.eyeClosedCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel2.Controls.Add(this.eyeClosedCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.drowsnissCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.eyeGazeCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.headDirectionCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.ConvertibilityCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.abnormalBehaviorCheckBox);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(316, 788);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(247, 165);
            this.flowLayoutPanel2.TabIndex = 18;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // drowsnissCheckBox
            // 
            this.drowsnissCheckBox.AutoSize = true;
            this.drowsnissCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drowsnissCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.drowsnissCheckBox.Location = new System.Drawing.Point(3, 30);
            this.drowsnissCheckBox.Name = "drowsnissCheckBox";
            this.drowsnissCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.drowsnissCheckBox.Size = new System.Drawing.Size(58, 21);
            this.drowsnissCheckBox.TabIndex = 18;
            this.drowsnissCheckBox.Text = "졸음";
            this.drowsnissCheckBox.UseVisualStyleBackColor = true;
            this.drowsnissCheckBox.CheckedChanged += new System.EventHandler(this.drowsnissCheckBox_CheckedChanged);
            // 
            // eyeGazeCheckBox
            // 
            this.eyeGazeCheckBox.AutoSize = true;
            this.eyeGazeCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.eyeGazeCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.eyeGazeCheckBox.Location = new System.Drawing.Point(3, 57);
            this.eyeGazeCheckBox.Name = "eyeGazeCheckBox";
            this.eyeGazeCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.eyeGazeCheckBox.Size = new System.Drawing.Size(102, 21);
            this.eyeGazeCheckBox.TabIndex = 19;
            this.eyeGazeCheckBox.Text = "전방 미주시";
            this.eyeGazeCheckBox.UseVisualStyleBackColor = true;
            this.eyeGazeCheckBox.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // headDirectionCheckBox
            // 
            this.headDirectionCheckBox.AutoSize = true;
            this.headDirectionCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.headDirectionCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.headDirectionCheckBox.Location = new System.Drawing.Point(3, 84);
            this.headDirectionCheckBox.Name = "headDirectionCheckBox";
            this.headDirectionCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.headDirectionCheckBox.Size = new System.Drawing.Size(89, 21);
            this.headDirectionCheckBox.TabIndex = 20;
            this.headDirectionCheckBox.Text = "고개 돌림";
            this.headDirectionCheckBox.UseVisualStyleBackColor = true;
            this.headDirectionCheckBox.CheckedChanged += new System.EventHandler(this.headDirectionCheckBox_CheckedChanged);
            // 
            // ConvertibilityCheckBox
            // 
            this.ConvertibilityCheckBox.AutoSize = true;
            this.ConvertibilityCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ConvertibilityCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ConvertibilityCheckBox.Location = new System.Drawing.Point(3, 111);
            this.ConvertibilityCheckBox.Name = "ConvertibilityCheckBox";
            this.ConvertibilityCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ConvertibilityCheckBox.Size = new System.Drawing.Size(136, 21);
            this.ConvertibilityCheckBox.TabIndex = 21;
            this.ConvertibilityCheckBox.Text = "운전전환가능상태";
            this.ConvertibilityCheckBox.UseVisualStyleBackColor = true;
            this.ConvertibilityCheckBox.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // abnormalBehaviorCheckBox
            // 
            this.abnormalBehaviorCheckBox.AutoSize = true;
            this.abnormalBehaviorCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.abnormalBehaviorCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.abnormalBehaviorCheckBox.Location = new System.Drawing.Point(145, 3);
            this.abnormalBehaviorCheckBox.Name = "abnormalBehaviorCheckBox";
            this.abnormalBehaviorCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.abnormalBehaviorCheckBox.Size = new System.Drawing.Size(84, 21);
            this.abnormalBehaviorCheckBox.TabIndex = 23;
            this.abnormalBehaviorCheckBox.Text = "이상행동";
            this.abnormalBehaviorCheckBox.UseVisualStyleBackColor = true;
            this.abnormalBehaviorCheckBox.CheckedChanged += new System.EventHandler(this.abnormalBehaviorCheckBox_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel3.Controls.Add(this.faceLandmarkCheckBox);
            this.flowLayoutPanel3.Controls.Add(this.poseCheckBox);
            this.flowLayoutPanel3.Controls.Add(this.eyeLandmarkCheckBox);
            this.flowLayoutPanel3.Controls.Add(this.mouthLandmarkCheckBox);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(574, 788);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(123, 165);
            this.flowLayoutPanel3.TabIndex = 24;
            // 
            // faceLandmarkCheckBox
            // 
            this.faceLandmarkCheckBox.AutoSize = true;
            this.faceLandmarkCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.faceLandmarkCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.faceLandmarkCheckBox.Location = new System.Drawing.Point(3, 3);
            this.faceLandmarkCheckBox.Name = "faceLandmarkCheckBox";
            this.faceLandmarkCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.faceLandmarkCheckBox.Size = new System.Drawing.Size(102, 21);
            this.faceLandmarkCheckBox.TabIndex = 17;
            this.faceLandmarkCheckBox.Text = "얼굴 특징점";
            this.faceLandmarkCheckBox.UseVisualStyleBackColor = true;
            this.faceLandmarkCheckBox.CheckedChanged += new System.EventHandler(this.faceLandmarkCheckBox_CheckedChanged);
            // 
            // poseCheckBox
            // 
            this.poseCheckBox.AutoSize = true;
            this.poseCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.poseCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.poseCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.poseCheckBox.Location = new System.Drawing.Point(3, 30);
            this.poseCheckBox.Name = "poseCheckBox";
            this.poseCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.poseCheckBox.Size = new System.Drawing.Size(102, 21);
            this.poseCheckBox.TabIndex = 18;
            this.poseCheckBox.Text = "자세 특징점";
            this.poseCheckBox.UseVisualStyleBackColor = false;
            this.poseCheckBox.CheckedChanged += new System.EventHandler(this.poseCheckBox_CheckedChanged);
            // 
            // eyeLandmarkCheckBox
            // 
            this.eyeLandmarkCheckBox.AutoSize = true;
            this.eyeLandmarkCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.eyeLandmarkCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.eyeLandmarkCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.eyeLandmarkCheckBox.Location = new System.Drawing.Point(3, 57);
            this.eyeLandmarkCheckBox.Name = "eyeLandmarkCheckBox";
            this.eyeLandmarkCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.eyeLandmarkCheckBox.Size = new System.Drawing.Size(115, 21);
            this.eyeLandmarkCheckBox.TabIndex = 19;
            this.eyeLandmarkCheckBox.Text = "눈동자 특징점";
            this.eyeLandmarkCheckBox.UseVisualStyleBackColor = false;
            this.eyeLandmarkCheckBox.CheckedChanged += new System.EventHandler(this.eyeLandmarkCheckBox_CheckedChanged);
            // 
            // mouthLandmarkCheckBox
            // 
            this.mouthLandmarkCheckBox.AutoSize = true;
            this.mouthLandmarkCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.mouthLandmarkCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mouthLandmarkCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mouthLandmarkCheckBox.Location = new System.Drawing.Point(3, 84);
            this.mouthLandmarkCheckBox.Name = "mouthLandmarkCheckBox";
            this.mouthLandmarkCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.mouthLandmarkCheckBox.Size = new System.Drawing.Size(102, 21);
            this.mouthLandmarkCheckBox.TabIndex = 20;
            this.mouthLandmarkCheckBox.Text = "입술 특징점";
            this.mouthLandmarkCheckBox.UseVisualStyleBackColor = false;
            this.mouthLandmarkCheckBox.CheckedChanged += new System.EventHandler(this.mouthLandmarkCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(1705, 788);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "Json 확인";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(1705, 818);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "불러오기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(713, 763);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 22);
            this.label4.TabIndex = 27;
            this.label4.Text = "로그";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(316, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 22);
            this.label5.TabIndex = 29;
            this.label5.Text = "이미지";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(1619, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 22);
            this.label6.TabIndex = 30;
            this.label6.Text = "수정";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.AllowDrop = true;
            this.saveBtn.Location = new System.Drawing.Point(1705, 930);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(80, 23);
            this.saveBtn.TabIndex = 31;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel7);
            this.flowLayoutPanel4.Controls.Add(this.modifyEyeClosedCB);
            this.flowLayoutPanel4.Controls.Add(this.modifyYawnCB);
            this.flowLayoutPanel4.Controls.Add(this.modifyDropHeadCB);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(1619, 61);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(215, 206);
            this.flowLayoutPanel4.TabIndex = 24;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel7.Controls.Add(this.label7);
            this.flowLayoutPanel7.Controls.Add(this.DrowsinessTextBox);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(205, 35);
            this.flowLayoutPanel7.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "졸음";
            // 
            // DrowsinessTextBox
            // 
            this.DrowsinessTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.DrowsinessTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrowsinessTextBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DrowsinessTextBox.ForeColor = System.Drawing.Color.White;
            this.DrowsinessTextBox.Location = new System.Drawing.Point(89, 0);
            this.DrowsinessTextBox.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.DrowsinessTextBox.MaxLength = 100;
            this.DrowsinessTextBox.Name = "DrowsinessTextBox";
            this.DrowsinessTextBox.Size = new System.Drawing.Size(116, 25);
            this.DrowsinessTextBox.TabIndex = 20;
            this.DrowsinessTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // modifyEyeClosedCB
            // 
            this.modifyEyeClosedCB.AutoSize = true;
            this.modifyEyeClosedCB.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modifyEyeClosedCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.modifyEyeClosedCB.Location = new System.Drawing.Point(3, 44);
            this.modifyEyeClosedCB.Name = "modifyEyeClosedCB";
            this.modifyEyeClosedCB.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.modifyEyeClosedCB.Size = new System.Drawing.Size(76, 21);
            this.modifyEyeClosedCB.TabIndex = 17;
            this.modifyEyeClosedCB.Text = "눈 감김";
            this.modifyEyeClosedCB.UseVisualStyleBackColor = true;
            // 
            // modifyYawnCB
            // 
            this.modifyYawnCB.AutoSize = true;
            this.modifyYawnCB.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modifyYawnCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.modifyYawnCB.Location = new System.Drawing.Point(3, 71);
            this.modifyYawnCB.Name = "modifyYawnCB";
            this.modifyYawnCB.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.modifyYawnCB.Size = new System.Drawing.Size(58, 21);
            this.modifyYawnCB.TabIndex = 18;
            this.modifyYawnCB.Text = "하품";
            this.modifyYawnCB.UseVisualStyleBackColor = true;
            // 
            // modifyDropHeadCB
            // 
            this.modifyDropHeadCB.AutoSize = true;
            this.modifyDropHeadCB.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modifyDropHeadCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.modifyDropHeadCB.Location = new System.Drawing.Point(3, 98);
            this.modifyDropHeadCB.Name = "modifyDropHeadCB";
            this.modifyDropHeadCB.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.modifyDropHeadCB.Size = new System.Drawing.Size(89, 21);
            this.modifyDropHeadCB.TabIndex = 19;
            this.modifyDropHeadCB.Text = "고개 떨굼";
            this.modifyDropHeadCB.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel8);
            this.flowLayoutPanel5.Controls.Add(this.modifyGazeForwardCB);
            this.flowLayoutPanel5.Controls.Add(this.modifyFaceForwardCB);
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(1619, 304);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(215, 206);
            this.flowLayoutPanel5.TabIndex = 25;
            this.flowLayoutPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel5_Paint);
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel8.Controls.Add(this.label8);
            this.flowLayoutPanel8.Controls.Add(this.lookForwardValueTextBox);
            this.flowLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(210, 35);
            this.flowLayoutPanel8.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "전방미주시";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // lookForwardValueTextBox
            // 
            this.lookForwardValueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lookForwardValueTextBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lookForwardValueTextBox.ForeColor = System.Drawing.Color.White;
            this.lookForwardValueTextBox.Location = new System.Drawing.Point(84, 0);
            this.lookForwardValueTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.lookForwardValueTextBox.Name = "lookForwardValueTextBox";
            this.lookForwardValueTextBox.Size = new System.Drawing.Size(116, 25);
            this.lookForwardValueTextBox.TabIndex = 20;
            this.lookForwardValueTextBox.TextChanged += new System.EventHandler(this.lookForwardValueTextBox_TextChanged);
            // 
            // modifyGazeForwardCB
            // 
            this.modifyGazeForwardCB.AutoSize = true;
            this.modifyGazeForwardCB.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modifyGazeForwardCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.modifyGazeForwardCB.Location = new System.Drawing.Point(3, 44);
            this.modifyGazeForwardCB.Name = "modifyGazeForwardCB";
            this.modifyGazeForwardCB.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.modifyGazeForwardCB.Size = new System.Drawing.Size(125, 21);
            this.modifyGazeForwardCB.TabIndex = 20;
            this.modifyGazeForwardCB.Text = "전방 주시(시선)";
            this.modifyGazeForwardCB.UseVisualStyleBackColor = true;
            // 
            // modifyFaceForwardCB
            // 
            this.modifyFaceForwardCB.AutoSize = true;
            this.modifyFaceForwardCB.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modifyFaceForwardCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.modifyFaceForwardCB.Location = new System.Drawing.Point(3, 71);
            this.modifyFaceForwardCB.Name = "modifyFaceForwardCB";
            this.modifyFaceForwardCB.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.modifyFaceForwardCB.Size = new System.Drawing.Size(125, 21);
            this.modifyFaceForwardCB.TabIndex = 21;
            this.modifyFaceForwardCB.Text = "전방 주시(얼굴)";
            this.modifyFaceForwardCB.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel9);
            this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel10);
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(1619, 552);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(215, 206);
            this.flowLayoutPanel6.TabIndex = 26;
            this.flowLayoutPanel6.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel6_Paint);
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel9.Controls.Add(this.label9);
            this.flowLayoutPanel9.Controls.Add(this.textBox1);
            this.flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(210, 58);
            this.flowLayoutPanel9.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "이상행동여부";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.textBox1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 25);
            this.textBox1.TabIndex = 20;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flowLayoutPanel10.Controls.Add(this.label10);
            this.flowLayoutPanel10.Controls.Add(this.textBox2);
            this.flowLayoutPanel10.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel10.Location = new System.Drawing.Point(3, 67);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(210, 50);
            this.flowLayoutPanel10.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "운전전환가능상태";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.textBox2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(0, 20);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(116, 25);
            this.textBox2.TabIndex = 20;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(316, 36);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pictureBox1.Size = new System.Drawing.Size(1280, 720);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sideViewSwitch
            // 
            this.sideViewSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.sideViewSwitch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sideViewSwitch.Location = new System.Drawing.Point(1516, 787);
            this.sideViewSwitch.Name = "sideViewSwitch";
            this.sideViewSwitch.Size = new System.Drawing.Size(80, 23);
            this.sideViewSwitch.TabIndex = 33;
            this.sideViewSwitch.Text = "사이드 뷰";
            this.sideViewSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sideViewSwitch.UseVisualStyleBackColor = true;
            this.sideViewSwitch.CheckedChanged += new System.EventHandler(this.sideViewSwitch_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1884, 999);
            this.Controls.Add(this.sideViewSwitch);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.flowLayoutPanel6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ImageOpen);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1900, 1050);
            this.MinimumSize = new System.Drawing.Size(1900, 1038);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox Log;
        private System.Windows.Forms.Button ImageOpen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox eyeClosedCheckBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox drowsnissCheckBox;
        private System.Windows.Forms.CheckBox eyeGazeCheckBox;
        private System.Windows.Forms.CheckBox headDirectionCheckBox;
        private System.Windows.Forms.CheckBox ConvertibilityCheckBox;
        private System.Windows.Forms.CheckBox abnormalBehaviorCheckBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.CheckBox faceLandmarkCheckBox;
        private System.Windows.Forms.CheckBox poseCheckBox;
        private System.Windows.Forms.CheckBox eyeLandmarkCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.CheckBox modifyEyeClosedCB;
        private System.Windows.Forms.CheckBox modifyYawnCB;
        private System.Windows.Forms.CheckBox modifyDropHeadCB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.CheckBox modifyGazeForwardCB;
        private System.Windows.Forms.CheckBox modifyFaceForwardCB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox mouthLandmarkCheckBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DrowsinessTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lookForwardValueTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox sideViewSwitch;
    }
}

