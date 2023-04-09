using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;
using System.Drawing;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iText.StyledXmlParser.Jsoup.Select;
using System.Diagnostics;

namespace Semi_Auto_Labeling
{
    

    public partial class Form1 : Form
    {

       
        List<string> dataSetImgNameList = new List<string>(); //이미지를 불러오고 이미지의 이름을 저장할 list
        List<string> dataSetImgFilePath = new List<string>(); //이미지 경로를 저장할 파일 패스 list

        List<string> dataSetJsonNameList = new List<string>(); //이미지를 불러오고 이미지의 이름을 저장할 list
        List<string> dataSetJsonFilePath = new List<string>(); //이미지 경로를 저장할 파일 패스 list


        List<String> statusDriverList = new List<string>();
        
        Boolean statusEyeClosed = false;
        Boolean statusDrowsiness = false;
        Boolean statusForwardLooking = false;
        Boolean statusTurnHead  = false;
        Boolean statusConvertibility = false;

        string fileContent;
        public Form1()
        {
          
            InitializeComponent();

            driver_status_text.Text = "";
            statusDriverList.Add("정상");
            statusDriverList.Add("화장하는 중 (비정상)");
            statusDriverList.Add("핸드폰 하는 중 (비정상)");
            statusDriverList.Add("조는 중 (비정상)");

            String status_text = "• 눈 감김 : " + statusEyeClosed + "\n\n• 졸음 : " + statusDrowsiness +
                "\n\n• " + "전방미주시 : " + statusForwardLooking + "\n\n• 고개 돌림 : " + statusTurnHead +
                "\n\n• 운전전환가능상태 : " + statusConvertibility + "\n\n• 이상행동 : " + statusDriverList[0];
            
            driver_status_text.Text = status_text;   
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // 초기 디렉토리 설정
            openFileDialog1.InitialDirectory = "C:\\";

            // 파일 필터 설정
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            // 다중 선택 가능하도록 설정
            openFileDialog1.Multiselect = true;

            // Dialog 열기
            DialogResult result = openFileDialog1.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    dataSetImgFilePath.Add(file);
                    dataSetImgNameList.Add(Path.GetFileName(file));
                }
                // 첫 번째 이미지 파일 경로 출력
               
                // PictureBox에 이미지 표시
                for (int i = 0; i < dataSetImgFilePath.Count; i++)
                {
                    FlowLayoutPanel fl_panel = new FlowLayoutPanel();
                   
                    fl_panel.Size = new Size(265, 250);
                    fl_panel.FlowDirection = FlowDirection.TopDown; // Top to Bottom 설정
                    fl_panel.BackColor = Color.White;
                    fl_panel.BorderStyle = BorderStyle.FixedSingle;
                    PictureBox picture_box = new PictureBox();
                    fl_panel.BackColor = Color.FromArgb(45, 45, 45);
                    picture_box.SizeMode = PictureBoxSizeMode.Zoom;
                    picture_box.Size = new Size(260, 200);
                    picture_box.Image = Image.FromFile(dataSetImgFilePath[i]);

                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
                    btn.Text = "landmark 수정";
                    btn.ForeColor = Color.FromArgb(250, 250, 250);
                    btn.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
                    btn.Size = new Size(120, 30);
                    btn.Name = String.Format("_Button_{0}", flowLayoutPanel1.Controls.Count);
                    int captured_i = i;
                    btn.Click += (sender1, e1) => btn_Click(sender, e, captured_i); // 람다식을 이용하여 클로저를 전달

                    fl_panel.Controls.Add(picture_box);
                    fl_panel.Controls.Add(btn);
                    flowLayoutPanel1.Controls.Add(fl_panel);

                   
                }

            }
        }
        private void btn_Click(object sender, EventArgs e, int i)
        {
            pictureBox1.Image = Image.FromFile(dataSetImgFilePath[i]);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JSON Files|*.json";
            openFileDialog1.Title = "Select a JSON File";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filePathText = openFileDialog1.FileName;
                fileContent = File.ReadAllText(filePathText);
                JsonTextBox.Text = fileContent;
                foreach (string filePath in openFileDialog1.FileNames) //json 파일 여러개 가지고 오기
                {
                    dataSetJsonFilePath.Add(filePath);
                    dataSetJsonNameList.Add(Path.GetFileName(filePath));
                    try
                    { 
                        // JSON 파일 읽기
                        using (StreamReader streamReader = new StreamReader(filePath))
                        {
                            Log.Text = filePath;
                            string jsonString = streamReader.ReadToEnd();

                            // JSON 문자열 파싱
                            var jsonDoc = JsonDocument.Parse(jsonString);

                            // JSON 객체에서 원하는 데이터 가져오기
                           // var value = jsonDoc.RootElement.GetProperty("metadata").GetProperty("description").GetString();
                           
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                /*
                string testJsonName = "";
                for (int i = 0; i < dataSetJsonNameList.Count; i++)
                {
                    testJsonName += (i + ". " + dataSetJsonNameList[i]);
                       
                }
                Log.Text = testJsonName;
                */
            }
            // 검색 버튼 클릭 이벤트 추가
            SearchButton.Click += SearchButton_Click;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            int start = 0;
            List<int> index = new List<int>();
            if (string.IsNullOrEmpty(searchText))
            {
                return;
            }
            List<int> searchLine = new List<int>();
            while ((start = JsonTextBox.Text.IndexOf(searchText, start, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                index.Add(start);
                start += searchText.Length;
            }

            if (index.Count >= 0)
            {
                MessageBox.Show($"검색어 '{searchText}'를 찾았습니다. 총 {index.Count}개의 결과가 있습니다.");
                foreach (int index1 in index)
                {
                    JsonTextBox.SelectionStart = index1;
                    JsonTextBox.SelectionLength = searchText.Length;
                    JsonTextBox.SelectionBackColor = Color.LightBlue;
                    JsonTextBox.Select(index1, searchText.Length);
                    JsonTextBox.ScrollToCaret();
                }
            }
            else
            {
                index.Clear();
                MessageBox.Show("검색어를 찾을 수 없습니다.");
            }
        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form form2 = new Form();
            RichTextBox json_text_box = new RichTextBox();

            form2.Size = new Size(600, 995);
            json_text_box.Size = new Size(570, 900);
            json_text_box.BackColor = Color.FromArgb(45, 45, 45);
            json_text_box.ForeColor = Color.FromArgb(250, 250, 250);
            json_text_box.Text = fileContent;
            json_text_box.ReadOnly = true;
            form2.Controls.Add(json_text_box);
            json_text_box.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
            form2.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/KEONI1231/Driver-Status-Recognition-Winform");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/KEONI1231/Driver-Status-Recognition-Winform");
        }

       
    }



}
