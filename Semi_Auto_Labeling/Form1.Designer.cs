namespace Semi_Auto_Labeling
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.JsonTextBox = new System.Windows.Forms.RichTextBox();
            this.SearchTextBox = new System.Windows.Forms.RichTextBox();
            this.SearchButton = new System.Windows.Forms.Button();
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
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.driver_status_text = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(292, 909);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(310, 38);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pictureBox1.Size = new System.Drawing.Size(1280, 720);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // JsonTextBox
            // 
            this.JsonTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.JsonTextBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.JsonTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.JsonTextBox.Location = new System.Drawing.Point(1595, 421);
            this.JsonTextBox.Name = "JsonTextBox";
            this.JsonTextBox.ReadOnly = true;
            this.JsonTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.JsonTextBox.Size = new System.Drawing.Size(177, 295);
            this.JsonTextBox.TabIndex = 4;
            this.JsonTextBox.Text = " ";
            this.JsonTextBox.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.SearchTextBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SearchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.SearchTextBox.Location = new System.Drawing.Point(1509, 779);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(161, 26);
            this.SearchTextBox.TabIndex = 10;
            this.SearchTextBox.Text = "검색";
            this.SearchTextBox.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged_1);
            // 
            // SearchButton
            // 
            this.SearchButton.AllowDrop = true;
            this.SearchButton.Location = new System.Drawing.Point(1693, 779);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(80, 23);
            this.SearchButton.TabIndex = 11;
            this.SearchButton.Text = "검색";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(311, 763);
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
            this.eyeClosedCheckBox.Size = new System.Drawing.Size(71, 21);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(311, 788);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(247, 165);
            this.flowLayoutPanel2.TabIndex = 18;
            // 
            // drowsnissCheckBox
            // 
            this.drowsnissCheckBox.AutoSize = true;
            this.drowsnissCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drowsnissCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.drowsnissCheckBox.Location = new System.Drawing.Point(3, 30);
            this.drowsnissCheckBox.Name = "drowsnissCheckBox";
            this.drowsnissCheckBox.Size = new System.Drawing.Size(53, 21);
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
            this.eyeGazeCheckBox.Size = new System.Drawing.Size(97, 21);
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
            this.headDirectionCheckBox.Size = new System.Drawing.Size(84, 21);
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
            this.ConvertibilityCheckBox.Size = new System.Drawing.Size(131, 21);
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
            this.abnormalBehaviorCheckBox.Location = new System.Drawing.Point(140, 3);
            this.abnormalBehaviorCheckBox.Name = "abnormalBehaviorCheckBox";
            this.abnormalBehaviorCheckBox.Size = new System.Drawing.Size(79, 21);
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
            this.faceLandmarkCheckBox.Size = new System.Drawing.Size(97, 21);
            this.faceLandmarkCheckBox.TabIndex = 17;
            this.faceLandmarkCheckBox.Text = "얼굴 특징점";
            this.faceLandmarkCheckBox.UseVisualStyleBackColor = true;
            this.faceLandmarkCheckBox.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // poseCheckBox
            // 
            this.poseCheckBox.AutoSize = true;
            this.poseCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.poseCheckBox.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.poseCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.poseCheckBox.Location = new System.Drawing.Point(3, 30);
            this.poseCheckBox.Name = "poseCheckBox";
            this.poseCheckBox.Size = new System.Drawing.Size(97, 21);
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
            this.eyeLandmarkCheckBox.Size = new System.Drawing.Size(110, 21);
            this.eyeLandmarkCheckBox.TabIndex = 19;
            this.eyeLandmarkCheckBox.Text = "눈동자 특징점";
            this.eyeLandmarkCheckBox.UseVisualStyleBackColor = false;
            this.eyeLandmarkCheckBox.CheckedChanged += new System.EventHandler(this.eyeLandmarkCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(1595, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "Json";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(1692, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "확대";
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
            // driver_status_text
            // 
            this.driver_status_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.driver_status_text.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.driver_status_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.driver_status_text.Location = new System.Drawing.Point(1595, 38);
            this.driver_status_text.Name = "driver_status_text";
            this.driver_status_text.Size = new System.Drawing.Size(177, 338);
            this.driver_status_text.TabIndex = 28;
            this.driver_status_text.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(310, 13);
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
            this.label6.Location = new System.Drawing.Point(1595, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 22);
            this.label6.TabIndex = 30;
            this.label6.Text = "운전자 상태";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1516, 925);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.driver_status_text);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ImageOpen);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.JsonTextBox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1800, 995);
            this.MinimumSize = new System.Drawing.Size(1510, 902);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox Log;
        private System.Windows.Forms.Button ImageOpen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RichTextBox JsonTextBox;
        private System.Windows.Forms.RichTextBox SearchTextBox;
        private System.Windows.Forms.Button SearchButton;
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox driver_status_text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

