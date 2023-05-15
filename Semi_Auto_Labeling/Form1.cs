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
        int vidioState = 1; // 0일때 정면, 1일때 사이드

        int imageRatio = 2;
        int currentImg = 0;
        List<string> dataSetImgNameList = new List<string>(); //이미지를 불러오고 이미지의 이름을 저장할 list
        List<string> dataSetImgFilePath = new List<string>(); //이미지 경로를 저장할 파일 패스 list

        List<string> dataSetSideImgNameList = new List<string>(); //이미지를 불러오고 이미지의 이름을 저장할 list
        List<string> dataSetSideImgFilePath = new List<string>(); //이미지 경로를 저장할 파일 패스 list

        string dataSetJsonNameList; //이미지를 불러오고 이미지의 이름을 저장할 list
        string dataSetJsonFilePath; //이미지 경로를 저장할 파일 패스 list
        List<int> leftEyeLandmarkList = new List<int>() { 362, 382, 381, 380, 374, 373, 390, 249, 263, 466, 388, 387, 386, 385, 384, 398, 473 };
        List<int> rightEyeLandmarkList = new List<int>() { 33, 7, 163, 144, 145, 153, 154, 155, 133, 173, 157, 158, 159, 160, 161, 246, 468 };
        List<int> leftMouthLandmarkList = new List<int>() { 78, 13, 14 };
        List<int> rightMouthLandmarkList = new List<int>() { 308, 13, 14 };
        List<int> faceFormLandmarkList = new List<int>() { 33, 263, 1, 61, 291, 199 };
        List<int> faceEdgeLandmarkList = new List<int>() {  10, 109, 67, 103, 54,21, 162, 127, 234, 93, 132, 58, 172, 136, 150, 149, 176, 148, 152, 377,
            400, 378, 379, 365, 397, 288, 361, 323, 454, 356, 389, 251, 284, 332, 297, 338};
        List<int> mouthEdgeLandmarkList = new List<int>() {0, 37, 39, 40, 185, 57, 146, 91, 181, 84, 17, 314, 405,321, 375, 287, 409, 270, 269, 267 };

        List<int> poseLandmarkList = new List<int>() {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,-1 };
        
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
          
        }
        int captured_i;
        int side_captured_i;

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

                        if (file.ToString().Contains("side"))
                        {
                            dataSetSideImgFilePath.Add(file);
                            dataSetSideImgNameList.Add(Path.GetFileName(file));
                        }
                        else
                        {
                            dataSetImgFilePath.Add(file);
                            dataSetImgNameList.Add(Path.GetFileName(file));
                        }

                        dataSetImgFilePath.Sort();
                        dataSetImgNameList.Sort();

                        
                        // 여기에 이미지 파일 처리 코드를 추가하세요.
                    }
                    // JSON 파일 처리
                    else if (Path.GetExtension(file).ToLower() == ".json")
                    {
                        // 여기에 JSON 파일 처리 코드를 추가하세요.
                        dataSetJsonFilePath = file;
                        dataSetJsonNameList = Path.GetFileName(file);
                        
                    }
                }
                for (int i = 0; i < dataSetImgFilePath.Count; i++)
                {
                    FlowLayoutPanel fl_panel = new FlowLayoutPanel();
                    fl_panel.Size = new Size(265, 280);
                    fl_panel.FlowDirection = FlowDirection.TopDown; // Top to Bottom 설정
                    fl_panel.BackColor = Color.White;
                    fl_panel.BorderStyle = BorderStyle.FixedSingle;
                    PictureBox picture_box = new PictureBox();
                    fl_panel.BackColor = Color.FromArgb(45, 45, 45);
                    picture_box.SizeMode = PictureBoxSizeMode.Zoom;
                    picture_box.Size = new Size(260, 200);
                    picture_box.Image = Image.FromFile(dataSetImgFilePath[i]);
                    System.Windows.Forms.Button landmarkModifyBtn = new System.Windows.Forms.Button();

                    landmarkModifyBtn.Text = "landmark 수정";
                    landmarkModifyBtn.ForeColor = Color.FromArgb(250, 250, 250);
                    landmarkModifyBtn.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
                    landmarkModifyBtn.Size = new Size(120, 30);
                    landmarkModifyBtn.Name = String.Format("_Button_{0}", flowLayoutPanel1.Controls.Count);
                    captured_i = i;

                    landmarkModifyBtn.Click += (sender1, e1) => btn_Click(sender, e, captured_i); // 람다식을 이용하여 클로저를 전달
                    Log.Text += landmarkModifyBtn.Location.X.ToString() + " : "+landmarkModifyBtn.Location.Y.ToString();
                   
                    fl_panel.Controls.Add(picture_box);
                    fl_panel.Controls.Add(landmarkModifyBtn);
                  
                    flowLayoutPanel1.Controls.Add(fl_panel);
                }
            }
        }

        private void SideViewBtn_Click(object sender, EventArgs e)
        {
            if (vidioState == 1)
            {
                pictureBox1.Invalidate();
                faceLandmarkCheckBox.Enabled = true;
                pictureBox1.Image = null;
                pictureBox1.Image = Image.FromFile(dataSetSideImgFilePath[captured_i]);
                faceLandmarkCheckBox.Checked = false;
                faceLandmarkCheckBox.Enabled = false;
                vidioState = 0;
            }
            else if (vidioState == 0)
            {
                pictureBox1.Invalidate();
                pictureBox1.Image = null;
                pictureBox1.Image = Image.FromFile(dataSetImgFilePath[captured_i]);
                vidioState = 1;

            }
            
            //PaintEventArgs e2;

            

        }

        List<Point> totalLabelPoints = new List<Point>();
        List<Point> controlLabelPoints = new List<Point>();
        List<Point> faceLabelPoints = new List<Point>();
        List<Point> poseLabelPoints = new List<Point>();
        List<Point> eyeLabelPoints = new List<Point>();
        List<Point> mouthLabelPoints = new List<Point>();
        List<Point> ClearPoint = new List<Point>();
        int beforeXCoordinate = 0;
        int beforeYCoordinate = 0;
        int selectedPointIndex = -1;

       
        private void btn_Click(object sender, EventArgs e, int i)
        {
            pictureBox1.Image = Image.FromFile(dataSetImgFilePath[i]);
            fileContent = "";
            fileContent = File.ReadAllText(dataSetJsonFilePath);
            int x;
            int y;
            totalLabelPoints.Clear();
            faceLabelPoints.Clear();
            eyeLabelPoints.Clear();
            poseLabelPoints.Clear();
            mouthLabelPoints.Clear();
            try
            {
                // string output = "";
                // JSON 파일 읽기
                using (StreamReader streamReader = new StreamReader(dataSetJsonFilePath))
                {
                    string jsonString = streamReader.ReadToEnd();
                    // JSON 문자열 파싱
                    var jsonDoc = JsonDocument.Parse(jsonString);
                    //Console.WriteLine($"faceLandmarkCheckBox.Checked: {jsonDoc.GetType()}");
                    // JSON 객체에서 원하는 데이터 가져오기
                    
                    GetJsonDataPoint(eyeLabelPoints, leftEyeLandmarkList,i , 0);
                    GetJsonDataPoint(eyeLabelPoints, rightEyeLandmarkList, i, 0);
                    
                    GetJsonDataPoint(mouthLabelPoints, leftMouthLandmarkList,i, 0);
                    GetJsonDataPoint(mouthLabelPoints, rightMouthLandmarkList, i, 0);

                    GetJsonDataPoint(faceLabelPoints, faceFormLandmarkList, i, 0);
                    GetJsonDataPoint(faceLabelPoints, faceEdgeLandmarkList, i, 0);

                    GetJsonDataPoint(mouthLabelPoints, mouthEdgeLandmarkList, i, 0);

                    GetJsonDataPoint(poseLabelPoints, poseLandmarkList, i, 1);
                }
                pictureBox1.Paint += PictureBox1_Paint;
                string folderPath = "JsonFiles";
                string filePath = Path.Combine(folderPath, "json" + i + ".txt");
                // System.IO.File.WriteAllText(filePath, output, Encoding.Default);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show(ex.Message, "");
            }
            pictureBox1.Invalidate();
        }
        private void GetJsonDataPoint(List<Point> labelPoint, List<int> labelPointList, int i, int discri)
        {
            using (StreamReader streamReader = new StreamReader(dataSetJsonFilePath))
            {
                string jsonString = streamReader.ReadToEnd();
                // JSON 문자열 파싱
                var jsonDoc = JsonDocument.Parse(jsonString);
                //   Log.Text = "here2";



                if (discri == 1)
                {
                    for (int idx = 0; idx < labelPointList.Count- 1; ++idx)
                    {
                        var value = jsonDoc.RootElement.GetProperty("pose_labels").GetProperty("" + labelPointList[idx]);
                        labelPoint.Add(new Point(value[0].GetInt32() * imageRatio, value[1].GetInt32() * imageRatio));
                    }
                }
                else if (discri == 0)
                {
                    //Log.Text = "here1";
                    for (int idx = 0; idx < labelPointList.Count; ++idx)
                    {
                        var value = jsonDoc.RootElement.GetProperty("face_labels").GetProperty("" + labelPointList[idx]);
                        labelPoint.Add(new Point(value[0].GetInt32() * imageRatio, value[1].GetInt32() * imageRatio));
                    }
                    // controlLabelPoints.Add(new Point(value[0].GetInt32() * imageRatio, value[1].GetInt32() * imageRatio));
                }
                   
                        
                    
                
             }
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            totalLabelPoints.Clear(); // totalLabelPoints 초기화

            if(vidioState == 1)
            {
                drawPoint(e, ClearPoint);
                Log.Text = "test";
            }
            if (faceLandmarkCheckBox.Checked)
            {
                drawPoint(e, faceLabelPoints);
                pictureBox1.MouseDown += (sender1, e1) => PictureBox1_MouseDown(sender, e1, faceLabelPoints); // 람다식을 이용하여 클로저를 전달
                pictureBox1.MouseMove += (sender1, e1) => PictureBox1_MouseMove(sender, e1, faceLabelPoints);
                pictureBox1.MouseUp += (sender1, e1) => PictureBox1_MouseUp(sender, e1, faceLabelPoints);
            }
            if (eyeLandmarkCheckBox.Checked)
            {
                drawPoint(e, eyeLabelPoints);
                pictureBox1.MouseDown += (sender1, e1) => PictureBox1_MouseDown(sender, e1, eyeLabelPoints); // 람다식을 이용하여 클로저를 전달
                pictureBox1.MouseMove += (sender1, e1) => PictureBox1_MouseMove(sender, e1, eyeLabelPoints);
                pictureBox1.MouseUp += (sender1, e1) => PictureBox1_MouseUp(sender, e1, eyeLabelPoints);
            }
            if(mouthLandmarkCheckBox.Checked)
            {
                drawPoint(e, mouthLabelPoints);
                pictureBox1.MouseDown += (sender1, e1) => PictureBox1_MouseDown(sender, e1, mouthLabelPoints); // 람다식을 이용하여 클로저를 전달
                pictureBox1.MouseMove += (sender1, e1) => PictureBox1_MouseMove(sender, e1, mouthLabelPoints);
                pictureBox1.MouseUp += (sender1, e1) => PictureBox1_MouseUp(sender, e1, mouthLabelPoints);
            }
            if (poseCheckBox.Checked)
            {
                drawPoint(e, poseLabelPoints);
            }
        }
        private void PictureBox1_MouseDown(object sender,MouseEventArgs e, List<Point> labelPoints)
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

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e, List<Point> labelPoints)
        {
            if (selectedPointIndex != -1 && e.Button == MouseButtons.Left)
            {
                labelPoints[selectedPointIndex] = new Point(e.X, e.Y);
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e, List<Point> labelPoints)
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

            totalLabelPoints.Clear();
            for (int i = 0; i < faceLabelPoints.Count; i++)
            {
                totalLabelPoints.Add(faceLabelPoints[i]);
            }
            for (int i = 0; i < eyeLabelPoints.Count; i++)
            {
                totalLabelPoints.Add(eyeLabelPoints[i]);
            }
            for (int i = 0; i < mouthLabelPoints.Count; i++)
            {
                totalLabelPoints.Add(mouthLabelPoints[i]);
            }
            for (int i = 0; i < poseLabelPoints.Count; i++)
            {
                totalLabelPoints.Add(poseLabelPoints[i]);
            }
            string inputFilePath = dataSetJsonFilePath;
            string outputFilePath = dataSetJsonFilePath;
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
            var updatedFaceLabels = totalLabelPoints.Select((point, index) => new
            {
                Index = index,
                X = (double)point.X / 2,
                Y = (double)point.Y / 2
            }).ToDictionary(item => item.Index.ToString(), item => new[] { item.X, item.Y });

            // 수정사항: JsonElement를 직접 사용하는 대신 Dictionary 형태로 변환한 후, 다시 JsonElement로 변환하여 문제를 해결합니다.
            var faceLabelsDictionary = JsonSerializer.Deserialize<Dictionary<string, double[]>>(jsonObject["face_labels"].GetRawText());
            foreach (var item in updatedFaceLabels)
            {
                faceLabelsDictionary[item.Key] = item.Value;
            }
            jsonObject["face_labels"] = JsonDocument.Parse(JsonSerializer.Serialize(faceLabelsDictionary)).RootElement;

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


        private void button1_Click_1(object sender, EventArgs e)
        {
            Form form2 = new Form();
            System.Windows.Forms.TextBox SearchTextBox = new System.Windows.Forms.TextBox();
            System.Windows.Forms.Button SearchTextbtn = new System.Windows.Forms.Button();

            RichTextBox json_text_box = new RichTextBox();

            form2.Size = new Size(600, 995);
            form2.BackColor = Color.FromArgb(30, 30, 30); 

            SearchTextbtn.Size = new Size(80, 23);
            SearchTextbtn.Text = "검색";
            SearchTextbtn.Location = new Point(170, 0);
            SearchTextbtn.BackColor = Color.FromArgb(250, 250, 250);

            SearchTextBox.Size = new Size(161, 26);
            SearchTextBox.BackColor = Color.FromArgb(45, 45, 45);
            SearchTextBox.ForeColor = Color.FromArgb(250, 250, 250);
            SearchTextBox.Font = new Font("맑은 고딕", 12, FontStyle.Bold);

            json_text_box.Size = new Size(570, 900);
            json_text_box.Location = new Point(0, 40);
            json_text_box.BackColor = Color.FromArgb(45, 45, 45);
            json_text_box.ForeColor = Color.FromArgb(250, 250, 250);
            json_text_box.Text = fileContent;
            json_text_box.ReadOnly = true;


            form2.Controls.Add(json_text_box);
            form2.Controls.Add(SearchTextBox);
            form2.Controls.Add(SearchTextbtn);

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
            pictureBox1.Invalidate();
            Log.Text = faceLandmarkCheckBox.CheckState.ToString();
        }
     
        private void label4_Click(object sender, EventArgs e)
        {    }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        { }
        private void label6_Click(object sender, EventArgs e)
        {  }
        private void label7_Click(object sender, EventArgs e)
        {  }
        private void label5_Click(object sender, EventArgs e)
        { }
        private void Form1_Load(object sender, EventArgs e)
        { }
        private void pictureBox2_Click(object sender, EventArgs e)
        { }
        private void pictureBox1_Click(object sender, EventArgs e)
        { }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        { }
        private void richTextBox3_TextChanged(object sender, EventArgs e)
        { }
        private void richTextBox4_TextChanged(object sender, EventArgs e)
        { }
        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        { }
        private void label3_Click(object sender, EventArgs e)
        { }
        private void groupBox1_Enter(object sender, EventArgs e)
        { }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        { }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        { }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        { }
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        { }
        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        { }
        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        { }
        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        { }


        private void drawPoint(PaintEventArgs e, List<Point> labelPoint)
        {
            Graphics g = e.Graphics;


            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                // JSON에서 불러온 좌표를 사용하여 원 그리기
                for (int i = 0; i < labelPoint.Count; i++)
                {
                    int radius = 4;
                    g.FillEllipse(brush, labelPoint[i].X - radius, labelPoint[i].Y - radius, radius * 2, radius * 2);
                }
            }
        }




        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        private void faceLandmarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"faceLandmarkCheckBox.Checked: {faceLandmarkCheckBox.Checked}");
            pictureBox1.Invalidate();
        }
        private void poseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"posemarkCheckBox.Checked: {poseCheckBox.Checked}");
            pictureBox1.Invalidate();
        }
        private void eyeLandmarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"eyeLandmarkCheckBox.Checked: {eyeLandmarkCheckBox.Checked}");
            pictureBox1.Invalidate();
        }
        private void mouthLandmarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"mouthLandmarkCheckBox.Checked: {mouthLandmarkCheckBox.Checked}");
            pictureBox1.Invalidate();
        }

        


        //여기 수정
        /*private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            int start = 0;
            List<int> index = new List<int>();
            if (string.IsNullOrEmpty(searchText))
            {
                return;
            }
            List<int> searchLine = new List<int>();
            while ((start = json_text_box.Text.IndexOf(searchText, start, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                index.Add(start);
                start += searchText.Length;
            }

            if (index.Count >= 0)
            {
                MessageBox.Show($"검색어 '{searchText}'를 찾았습니다. 총 {index.Count}개의 결과가 있습니다.");
                foreach (int index1 in index)
                {
                    json_text_box.SelectionStart = index1;
                    json_text_box.SelectionLength = searchText.Length;
                    json_text_box.SelectionBackColor = Color.LightBlue;
                    json_text_box.Select(index1, searchText.Length);
                    json_text_box.ScrollToCaret();
                }
            }
            else
            {
                index.Clear();
                MessageBox.Show("검색어를 찾을 수 없습니다.");
            }
        }*/


    }
}
