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

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Semi_Auto_Labeling
{
    public partial class Form1 : Form
    {

        List<string> DataSetImgNameList = new List<string>(); //이미지를 불러오고 이미지의 이름을 저장할 list
        List<string> DataSetImgFilePath = new List<string>(); //이미지 경로를 저장할 파일 패스 list
        string fileContent;
        public Form1()
        {
            InitializeComponent();
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
                    DataSetImgFilePath.Add(file);
                    DataSetImgNameList.Add(Path.GetFileName(file));
                }
                // 첫 번째 이미지 파일 경로 출력

                // PictureBox에 이미지 표시
                for (int i = 0; i < DataSetImgFilePath.Count; i++)
                {
                    FlowLayoutPanel fl_panel = new FlowLayoutPanel();
                    fl_panel.Size = new Size(265, 250);
                    fl_panel.FlowDirection = FlowDirection.TopDown; // Top to Bottom 설정
                    fl_panel.BackColor = Color.White;
                    fl_panel.BorderStyle = BorderStyle.FixedSingle;
                    PictureBox picture_box = new PictureBox();
                    picture_box.SizeMode = PictureBoxSizeMode.Zoom;
                    picture_box.Size = new Size(260, 200);
                    picture_box.Image = Image.FromFile(DataSetImgFilePath[i]);

                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
                    btn.Text = "landmark 수정";
                    btn.Size = new Size(120, 30);
                    btn.Name = String.Format("_Button_{0}", flowLayoutPanel1.Controls.Count);
                    int captured_i = i;
                    btn.Click += (sender1, e1) => btn_Click(sender, e, captured_i); // 람다식을 이용하여 클로저를 전달

                    fl_panel.Controls.Add(picture_box);
                    fl_panel.Controls.Add(btn);
                    flowLayoutPanel1.Controls.Add(fl_panel);

                    richTextBox1.AppendText((i + 1) + " : " + DataSetImgNameList[i] + "\n");
                }

            }
        }
        private void btn_Click(object sender, EventArgs e, int i)
        {
            pictureBox1.Image = Image.FromFile(DataSetImgFilePath[i]);
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

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filePathText = openFileDialog1.FileName;
                 fileContent = File.ReadAllText(filePathText);
                JsonTextBox.Text = fileContent;
                foreach (string filePath in openFileDialog1.FileNames) //json 파일 여러개 가지고 오기
                {
                    try
                    {
                        // JSON 파일 읽기
                        using (StreamReader streamReader = new StreamReader(filePath))
                        {
                            string jsonString = streamReader.ReadToEnd();

                            // JSON 문자열 파싱
                            var jsonDoc = JsonDocument.Parse(jsonString);

                            // JSON 객체에서 원하는 데이터 가져오기
                            var value = jsonDoc.RootElement.GetProperty("metadata").GetProperty("description").GetString();
                            richTextBox1.Text =  value.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }


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
                    JsonTextBox.SelectionBackColor = Color.Yellow;
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

            form2.Size = new Size(600, 500);
            json_text_box.Size = new Size(500, 400);
            json_text_box.Text = fileContent;
            richTextBox1.ReadOnly = true;
            form2.Controls.Add(json_text_box);
            form2.Show();
        }
    }



}
