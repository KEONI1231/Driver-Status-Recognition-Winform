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
using System.Text.Json.Nodes;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iText.StyledXmlParser.Jsoup.Select;
using System.Diagnostics;

namespace Semi_Auto_Labeling
{
    

    public partial class Form1 : Form
    {

        int imageRatio = 2;
        List<string> dataSetImgNameList = new List<string>(); //이미지를 불러오고 이미지의 이름을 저장할 list
        List<string> dataSetImgFilePath = new List<string>(); //이미지 경로를 저장할 파일 패스 list

        List<string> dataSetJsonNameList = new List<string>(); //이미지를 불러오고 이미지의 이름을 저장할 list
        List<string> dataSetJsonFilePath = new List<string>(); //이미지 경로를 저장할 파일 패스 list

        //레이블링 표시유무
        Boolean eyeClosedLabel = false;

        //status 출력 상태 표시 변수
        List<String> abnormalBehaviorList = new List<string>();
        Boolean statusEyeClosed = false;
        Boolean statusDrowsiness = false;
        Boolean statusForwardLooking = false;
        Boolean statusTurnHead  = false;
        Boolean statusConvertibility = false;

        string fileContent;
        public Form1()
        {
          
            InitializeComponent();
            Log.Text = "";
           
        


            driver_status_text.Text = "";
            abnormalBehaviorList.Add("정상");
            abnormalBehaviorList.Add("화장하는 중 (비정상)");
            abnormalBehaviorList.Add("핸드폰 하는 중 (비정상)");
            abnormalBehaviorList.Add("조는 중 (비정상)");

            String status_text = "• 눈 감김 : " + statusEyeClosed + "\n\n• 졸음 : " + statusDrowsiness +
                "\n\n• " + "전방미주시 : " + statusForwardLooking + "\n\n• 고개 돌림 : " + statusTurnHead +
                "\n\n• 운전전환가능상태 : " + statusConvertibility + "\n\n• 이상행동 : " + abnormalBehaviorList[0];
            
            driver_status_text.Text = status_text;   
        }
        int captured_i;

        private void imageOpen_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // 초기 디렉토리 설정
            folderBrowserDialog.SelectedPath = "C:\\";

            // Dialog 열기
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // 선택한 폴더의 경로를 가져옴
                string folderPath = folderBrowserDialog.SelectedPath;

                // 해당 폴더와 하위 폴더의 모든 파일을 가져옴
                string[] allFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

                // 파일 목록을 처리


                foreach (string file in allFiles)
                {
                    // 이미지 파일 처리
                    if (Path.GetExtension(file).ToLower() == ".png" || Path.GetExtension(file).ToLower() == ".jpg" || Path.GetExtension(file).ToLower() == ".jpeg")
                    {
                        dataSetImgFilePath.Add(file);
                        dataSetImgNameList.Add(Path.GetFileName(file));
                        dataSetImgFilePath.Sort();
                        dataSetImgNameList.Sort();
                        // 여기에 이미지 파일 처리 코드를 추가하세요.
                    }
                    // JSON 파일 처리
                    else if (Path.GetExtension(file).ToLower() == ".json")
                    {
                        // 여기에 JSON 파일 처리 코드를 추가하세요.
                        dataSetJsonFilePath.Add(file);
                        dataSetJsonNameList.Add(Path.GetFileName(file));
                        dataSetJsonFilePath.Sort();
                        dataSetJsonFilePath.Sort();
                    }
                }
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
                    captured_i = i;

                    btn.Click += (sender1, e1) => btn_Click(sender, e, captured_i); // 람다식을 이용하여 클로저를 전달

                    fl_panel.Controls.Add(picture_box);
                    fl_panel.Controls.Add(btn);
                    flowLayoutPanel1.Controls.Add(fl_panel);
                }
            }
        }

        List<Point> labelPoints = new List<Point>();
        int beforeXCoordinate = 0;
        int beforeYCoordinate = 0;
        int selectedPointIndex = -1;
   

        private void btn_Click(object sender, EventArgs e, int i)
        { 
            pictureBox1.Image = Image.FromFile(dataSetImgFilePath[i]);
            fileContent = "";
            fileContent = File.ReadAllText(dataSetJsonFilePath[i]);
            JsonTextBox.Text = fileContent;
            int x;
            int y;

            labelPoints.Clear();
            try
            {
                string output = "";
                // JSON 파일 읽기
                using (StreamReader streamReader = new StreamReader(dataSetJsonFilePath[i]))
                {
                    string jsonString = streamReader.ReadToEnd();
                    // JSON 문자열 파싱
                    var jsonDoc = JsonDocument.Parse(jsonString);
                    // JSON 객체에서 원하는 데이터 가져오기
                    for (int idx = 0; idx < 478; ++idx)
                    {
                        
                        var value = jsonDoc.RootElement.GetProperty("face_labels").GetProperty("" + idx);

                        labelPoints.Add(new Point(value[0].GetInt32()*imageRatio, value[1].GetInt32() * imageRatio));
                        output += (idx + 1) + "번째 : " + value[0] + ", " + value[1] + " name: " + dataSetJsonNameList[i] + " \n";
                    }
                }
                pictureBox1.Paint += PictureBox1_Paint;


                string folderPath = "JsonFiles";
                string filePath = Path.Combine(folderPath, "json" + i + ".txt");
                System.IO.File.WriteAllText(filePath, output, Encoding.Default);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show(ex.Message, "");
            }

            pictureBox1.Invalidate();
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // 그래픽 객체 가져오기
            Graphics g = e.Graphics;

            // 펜 설정
            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                // JSON에서 불러온 좌표를 사용하여 원 그리기
                for(int i = 0; i<labelPoints.Count; i++)
                {
                    int radius = 4;
                    g.FillEllipse(brush, labelPoints[i].X - radius, labelPoints[i].Y - radius, radius * 2, radius * 2);
                  
                }

            }
            pictureBox1.MouseDown += PictureBox1_MouseDown;

            pictureBox1.MouseMove += PictureBox1_MouseMove;


            // (sender1, e1) => btn_Click(sender, e, captured_i); // 람다식을 이용하여 클로저를 전달
            pictureBox1.MouseUp += PictureBox1_MouseUp;


        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int radius = 5;
            for (int i = 0; i < labelPoints.Count; i++)
            {
                if (Math.Abs(e.X - labelPoints[i].X) <= radius && Math.Abs(e.Y - labelPoints[i].Y) <= radius)
                {
                    beforeXCoordinate = labelPoints[i].X;
                    beforeYCoordinate = labelPoints[i].Y;
                    selectedPointIndex = i;
                    break;
                }
            }
        }
 
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedPointIndex != -1 && e.Button == MouseButtons.Left)
            {
                labelPoints[selectedPointIndex] = new Point(e.X, e.Y);
                pictureBox1.Invalidate();
            }
        }
        
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedPointIndex != -1)
            {
                Log.Text += "\n[ " + selectedPointIndex + " ]" + "\n-> 변경 전 좌표(x, y) : (" + beforeXCoordinate / imageRatio + ", " + beforeYCoordinate / imageRatio + ") " +
                    "\n-> 변경 후 좌표(x, y) : (" + labelPoints[selectedPointIndex].X / imageRatio + ", " + labelPoints[selectedPointIndex].Y / imageRatio + ") \n";

                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }
            selectedPointIndex = -1;
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            string inputFilePath = dataSetJsonFilePath[captured_i];
            string outputFilePath = dataSetJsonFilePath[captured_i];
            jsonUpdateOutput(inputFilePath, outputFilePath);
        }
        private void jsonUpdateOutput(string inputFilePath, string outputFilePath)
        {
            // 기존 JSON 파일을 읽어 들입니다.
            string jsonString = File.ReadAllText(inputFilePath);
            var jsonDoc = JsonDocument.Parse(jsonString);

            // 기존 JSON 객체를 Dictionary 형태로 변환합니다.
            var jsonObject = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

            // 기존 JSON 객체에 옮겨진 좌표를 업데이트합니다.
            var updatedFaceLabels = labelPoints.Select((point, index) => new
            {
                Index = index,
                X = point.X / 2,
                Y = point.Y / 2
            }).ToDictionary(item => item.Index.ToString(), item => new[] { item.X, item.Y });

            JsonElement updatedFaceLabelsJsonElement;
            using (var jsonDocUpdate = JsonDocument.Parse(JsonSerializer.Serialize(updatedFaceLabels)))
            {
                updatedFaceLabelsJsonElement = jsonDocUpdate.RootElement.Clone();
            }
            jsonObject["face_labels"] = updatedFaceLabelsJsonElement;

            // 업데이트된 JSON 객체를 문자열로 변환합니다.
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // 이 옵션을 사용하여 JSON 문자열의 가독성을 높입니다.
            };
            jsonString = JsonSerializer.Serialize(jsonObject, options);

            // JSON 문자열을 파일에 저장합니다.
            File.WriteAllText(outputFilePath, jsonString);
            
            MessageBox.Show("저장 완료");

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
            //눈 감김 레이블 체크박스
            Log.Text = eyeClosedCheckBox.CheckState.ToString();
           
        }
        private void drowsnissCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //졸음 레이블 체크박스
            Log.Text = drowsnissCheckBox.CheckState.ToString();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //전방 미주시 레이블 체크박스
            Log.Text = eyeGazeCheckBox.CheckState.ToString();
        }

        private void headDirectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //고개 돌림 레이블 체크박스
            Log.Text = headDirectionCheckBox.CheckState.ToString();
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            //운전전환가능상태 체크박스
            Log.Text = ConvertibilityCheckBox.CheckState.ToString();
        }
        private void abnormalBehaviorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //운전자 이상행동 레이블 체크박스
            Log.Text = abnormalBehaviorCheckBox.CheckState.ToString();
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            //얼굴 특징점 랜드마크 키포인트
            Log.Text = faceLandmarkCheckBox.CheckState.ToString();
        }
        private void poseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //자세 특징점 랜드마크 키포인트
            Log.Text = poseCheckBox.CheckState.ToString();
        }
        private void eyeLandmarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //눈동자 특징점 랜드마크 키포인트
            Log.Text = eyeLandmarkCheckBox.CheckState.ToString();
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


        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }



}
