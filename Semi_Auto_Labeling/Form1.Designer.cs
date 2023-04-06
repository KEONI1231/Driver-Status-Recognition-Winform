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
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.ImageOpen = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.JsonOpen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.JsonTextBox = new System.Windows.Forms.RichTextBox();
            this.SearchTextBox = new System.Windows.Forms.RichTextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(322, 721);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(556, 226);
            this.richTextBox3.TabIndex = 5;
            this.richTextBox3.Text = " ";
            this.richTextBox3.TextChanged += new System.EventHandler(this.richTextBox3_TextChanged);
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(1509, 307);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(264, 409);
            this.richTextBox4.TabIndex = 6;
            this.richTextBox4.Text = " ";
            this.richTextBox4.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            // 
            // ImageOpen
            // 
            this.ImageOpen.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ImageOpen.FlatAppearance.BorderSize = 2;
            this.ImageOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ImageOpen.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ImageOpen.Location = new System.Drawing.Point(12, 12);
            this.ImageOpen.Name = "ImageOpen";
            this.ImageOpen.Size = new System.Drawing.Size(111, 23);
            this.ImageOpen.TabIndex = 7;
            this.ImageOpen.Text = "Image";
            this.ImageOpen.UseVisualStyleBackColor = true;
            this.ImageOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1509, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(264, 263);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // JsonOpen
            // 
            this.JsonOpen.FlatAppearance.BorderSize = 2;
            this.JsonOpen.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.JsonOpen.Location = new System.Drawing.Point(141, 12);
            this.JsonOpen.Name = "JsonOpen";
            this.JsonOpen.Size = new System.Drawing.Size(111, 23);
            this.JsonOpen.TabIndex = 9;
            this.JsonOpen.Text = "Json";
            this.JsonOpen.UseVisualStyleBackColor = true;
            this.JsonOpen.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(322, 38);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pictureBox1.Size = new System.Drawing.Size(1178, 678);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // JsonTextBox
            // 
            this.JsonTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.JsonTextBox.Location = new System.Drawing.Point(884, 721);
            this.JsonTextBox.Name = "JsonTextBox";
            this.JsonTextBox.ReadOnly = true;
            this.JsonTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.JsonTextBox.Size = new System.Drawing.Size(619, 226);
            this.JsonTextBox.TabIndex = 4;
            this.JsonTextBox.Text = " ";
            this.JsonTextBox.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(1509, 721);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(161, 39);
            this.SearchTextBox.TabIndex = 10;
            this.SearchTextBox.Text = "검색";
            this.SearchTextBox.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged_1);
            // 
            // SearchButton
            // 
            this.SearchButton.AllowDrop = true;
            this.SearchButton.Location = new System.Drawing.Point(1676, 722);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(96, 38);
            this.SearchButton.TabIndex = 11;
            this.SearchButton.Text = "검색";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1784, 956);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.JsonOpen);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ImageOpen);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.JsonTextBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(1800, 995);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Button ImageOpen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button JsonOpen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox JsonTextBox;
        private System.Windows.Forms.RichTextBox SearchTextBox;
        private System.Windows.Forms.Button SearchButton;
    }
}

