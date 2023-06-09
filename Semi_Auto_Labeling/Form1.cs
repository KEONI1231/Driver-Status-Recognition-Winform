﻿using System;
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
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iText.StyledXmlParser.Jsoup.Select;
using System.Diagnostics;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using System.Text.RegularExpressions;
using System.Linq;
namespace Semi_Auto_Labeling
{
    public partial class Form1 : Form
    {
        static int MAX_LABELING_COUNT = 478;

        int imageRatio = 2;
        List<string> dataSetImgNameList = new List<string>(); //이미지를 불러오고 이미지의 이름을 저장할 list
        List<string> dataSetImgFilePath = new List<string>(); //이미지 경로를 저장할 파일 패스 list

        List<string> dataSetSideImgNameList = new List<string>(); //이미지를 불러오고 이미지의 이름을 저장할 list
        List<string> dataSetSideImgFilePath = new List<string>(); //이미지 경로를 저장할 파일 패스 list

        string dataSetJsonNameList; //이미지를 불러오고 이미지의 이름을 저장할 list
        string dataSetJsonFilePath; //이미지 경로를 저장할 파일 패스 list
        List<int> leftEyeLandmarkList = new List<int>() { 362, 382, 381, 380, 374, 373, 390, 249, 263, 466, 388, 387, 386, 385, 384, 398, 473 };
        List<int> rightEyeLandmarkList = new List<int>() { 33, 7, 163, 144, 145, 153, 154, 155, 133, 173, 157, 158, 159, 160, 161, 246, 468 };
        List<int> leftMouthLandmarkList = new List<int>() { 78 };
        List<int> rightMouthLandmarkList = new List<int>() { 308 };
        List<int> faceFormLandmarkList = new List<int>() { 226, 446, 1, 61, 291, 199 };
        List<int> faceEdgeLandmarkList = new List<int>() { 10, 109, 67, 103, 54, 21, 162, 127, 234, 93, 132, 58, 172, 136, 150, 149, 176, 148, 152, 377,
            400, 378, 379, 365, 397, 288, 361, 323, 454, 356, 389, 251, 284, 332, 297, 338};
        List<int> mouthEdgeLandmarkList = new List<int>() { 13, 14, 0, 37, 39, 40, 185, 57, 146, 91, 181, 84, 17, 314, 405, 321, 375, 287, 409, 270, 269, 267 };

        List<int> poseLandmarkList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, -2 };

        //레이블링 표시유무
        int maxImageCount = 0;
        string fileContent;
        public Form1()
        {

            InitializeComponent();

            poseCheckBox.Enabled = false;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            Log.Text = "";
            DriableCB.Text = "운전전환가능\n상태(확률)";
            LookForwardCB.Text = "전방미주시\n(확률)";
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        int caputed_index;
        private async void imageOpen_Click(object sender, EventArgs e)
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
                progressBar1.Minimum = 0;
                progressBar1.Maximum = allFiles.Length;
                progressBar1.Value = 0;
                List<Task> tasks = new List<Task>();
                await Task.Run(async () =>
                {
                    foreach (string file in allFiles)
                    {
                        // 이미지 파일 처리
                        if (Path.GetExtension(file).ToLower() == ".png" || Path.GetExtension(file).ToLower() == ".jpg" || Path.GetExtension(file).ToLower() == ".jpeg")
                        {
                            if (file.ToString().Contains("side"))
                            {
                                lock (dataSetSideImgFilePath)
                                {
                                    dataSetSideImgFilePath.Add(file);
                                    dataSetSideImgFilePath.Sort((a, b) => {
                                        int aNumber = ExtractNumberFromFilePath(a);
                                        int bNumber = ExtractNumberFromFilePath(b);

                                        return aNumber.CompareTo(bNumber);
                                    });
                                }
                                lock (dataSetSideImgNameList)
                                {
                                    dataSetSideImgNameList.Add(Path.GetFileName(file));
                                }
                            }
                            else
                            {
                                lock (dataSetImgFilePath)
                                {
                                    dataSetImgFilePath.Add(file);
                                    dataSetImgFilePath.Sort((a, b) => {
                                        int aNumber = ExtractNumberFromFilePath(a);
                                        int bNumber = ExtractNumberFromFilePath(b);
                                        return aNumber.CompareTo(bNumber);
                                    });
                                }
                                lock (dataSetImgNameList)
                                {
                                    dataSetImgNameList.Add(Path.GetFileName(file));
                                    dataSetImgNameList.Sort((a, b) =>
                                    {
                                        int aNumber = ExtractNumber(a);
                                        int bNumber = ExtractNumber(b);

                                        return aNumber.CompareTo(bNumber);
                                    });
                                }
                            }
                        }
                        // JSON 파일 처리
                        else if (Path.GetExtension(file).ToLower() == ".json")
                        {
                            // 여기에 JSON 파일 처리 코드를 추가하세요.
                            dataSetJsonFilePath = file;
                            dataSetJsonNameList = Path.GetFileName(file);
                        }
                        progressBar1.Invoke((MethodInvoker)delegate
                        {
                            progressBar1.Value++;
                            Log.Text = " > 이미지 불러오는 중..." + "\n > 진행률 : " + Math.Round(((double)(progressBar1.Value) / progressBar1.Maximum) * 100, 2).ToString() + "%";
                        });
                        await Task.Delay(10);
                    }
                });
                await Task.WhenAll(tasks);
                maxImageCount = dataSetImgNameList.Count;
                for (int i = 0; i < dataSetImgFilePath.Count; i++)
                {
                    controlLabelPoints.Add(new List<Point>());
                    faceLabelPoints.Add(new List<Point>());
                    poseLabelPoints.Add(new List<Point>());
                    eyeLabelPoints.Add(new List<Point>());
                    mouthLabelPoints.Add(new List<Point>());

                    FlowLayoutPanel fl_panel = new FlowLayoutPanel();
                    fl_panel.Size = new Size(265, 280);
                    fl_panel.FlowDirection = FlowDirection.TopDown; // Top to Bottom 설정
                    fl_panel.BackColor = Color.White;
                    fl_panel.BorderStyle = BorderStyle.FixedSingle;
                    PictureBox picture_box = new PictureBox();
                    fl_panel.BackColor = Color.FromArgb(45, 45, 45);
                    picture_box.SizeMode = PictureBoxSizeMode.Zoom;
                    picture_box.Size = new Size(260, 200);
                    //picture_box.Image = Image.FromFile(dataSetImgFilePath[i]);
                    using (Image img = Image.FromFile(dataSetImgFilePath[i]))
                    {
                        picture_box.Image = new Bitmap(img);
                    }
                    int captured_i = i;
                    System.Windows.Forms.Button landmarkModifyBtn = new System.Windows.Forms.Button();
                    System.Windows.Forms.TextBox FileNameTextBox = new System.Windows.Forms.TextBox();
                    FileNameTextBox.Text = "파일 명 : " + "Front" + dataSetImgNameList[captured_i].ToString() + ".png";
                    FileNameTextBox.ForeColor = Color.FromArgb(250, 250, 250);
                    FileNameTextBox.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
                    FileNameTextBox.BackColor = Color.FromArgb(30, 30, 30);
                    FileNameTextBox.Size = new Size(200, 30);
                    landmarkModifyBtn.Text = "landmark 수정";
                    landmarkModifyBtn.ForeColor = Color.FromArgb(250, 250, 250);
                    landmarkModifyBtn.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
                    landmarkModifyBtn.Size = new Size(120, 30);
                    landmarkModifyBtn.Name = String.Format("_Button_{0}", flowLayoutPanel1.Controls.Count);
                    landmarkModifyBtn.Click += (sender1, e1) => btn_Click(sender, e, captured_i); // 람다식을 이용하여 클로저를 전달
                    fl_panel.Controls.Add(FileNameTextBox);
                    fl_panel.Controls.Add(picture_box);
                    fl_panel.Controls.Add(landmarkModifyBtn);
                    flowLayoutPanel1.Controls.Add(fl_panel);
                }
                Task[] getJsonTasks = new Task[8];
                for (int index = 0; index < maxImageCount; index++)
                {
                    try
                    {
                        // JSON 파일 읽기
                        using (StreamReader streamReader = new StreamReader(dataSetJsonFilePath))
                        {
                            string jsonString = streamReader.ReadToEnd();
                            // JSON 문자열 파싱
                            var jsonDoc = JsonDocument.Parse(jsonString);

                            // JSON 객체에서 원하는 데이터 가져오기
                            getJsonTasks[0] = Task.Run(() => GetJsonDataPoint(eyeLabelPoints, leftEyeLandmarkList, index, 0));
                            getJsonTasks[1] = Task.Run(() => GetJsonDataPoint(eyeLabelPoints, rightEyeLandmarkList, index, 0));
                            getJsonTasks[2] = Task.Run(() => GetJsonDataPoint(mouthLabelPoints, leftMouthLandmarkList, index, 0));
                            getJsonTasks[3] = Task.Run(() => GetJsonDataPoint(mouthLabelPoints, rightMouthLandmarkList, index, 0));
                            getJsonTasks[4] = Task.Run(() => GetJsonDataPoint(faceLabelPoints, faceFormLandmarkList, index, 0));
                            getJsonTasks[5] = Task.Run(() => GetJsonDataPoint(faceLabelPoints, faceEdgeLandmarkList, index, 0));
                            getJsonTasks[6] = Task.Run(() => GetJsonDataPoint(mouthLabelPoints, mouthEdgeLandmarkList, index, 0));
                            getJsonTasks[7] = Task.Run(() => GetJsonDataPoint(poseLabelPoints, poseLandmarkList, index, 1));

                            Task.WaitAll(getJsonTasks);
                            /* Log.Text = " > 제이슨 데이터 처리중...\n > 진행률 " + Math.Round(((double)(index+1) / maxImageCount) * 100, 2).ToString() + "%\n" ;
                             Log.SelectionStart = Log.Text.Length;
                             Log.ScrollToCaret();*/
                            Log.Text = " > 제이슨 데이터 처리중...\n > 진행률 " + Math.Round(((double)(index + 1) / maxImageCount) * 100, 2).ToString() + "%\n";
                            Log.SelectionStart = Log.Text.Length;
                            Log.ScrollToCaret();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Source}\n");
                        Console.WriteLine($"Error: {ex.Message}");
                        Console.WriteLine($"Source: {ex.Source}");
                        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                        }
                        MessageBox.Show($"Error: {ex.Message}\nSource: {ex.Source}\nStack Trace: {ex.StackTrace}", "");
                        MessageBox.Show(ex.Message, "");
                    }

                    /*Log.Text = " > 제이슨 데이터 처리중...\n > 진행률 " + Math.Round(((double)(index) / progressBar1.Maximum) * 100, 2).ToString() + "%"; ;
                    Log.SelectionStart = Log.Text.Length;
                    Log.ScrollToCaret();*/
                }
            }

            MessageBox.Show("불러오기 성공");
            progressBar1.Value = 0;
        }
        
        static int ExtractNumber(string fileName)
        {
            string numericPart = new string(fileName.Where(char.IsDigit).ToArray());
            return int.Parse(numericPart);
        }
        static int ExtractNumberFromFilePath(string filePath)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
            string numericPart = new string(fileName.Where(char.IsDigit).ToArray());
            return int.Parse(numericPart);
        }
        private void sideViewSwitch_CheckedChanged(object sender, EventArgs e, int i)
        {
            //Console.WriteLine("side_index = " + i);

            if (sideViewSwitch.Checked)
            {
                currentSelectDataLog.Text = " > 현재 작업 중인 파일 : " + "Side Image" + dataSetImgNameList[i].ToString() + "\n";
                pictureBox1.Invalidate();
                faceLandmarkCheckBox.Enabled = true;
                //pictureBox1.Image = null;
                pictureBox1.Image = Image.FromFile(dataSetSideImgFilePath[i]);

                faceLandmarkCheckBox.Checked = false;
                faceLandmarkCheckBox.Enabled = false;

                eyeLandmarkCheckBox.Checked = false;
                eyeLandmarkCheckBox.Enabled = false;

                mouthLandmarkCheckBox.Checked = false;
                mouthLandmarkCheckBox.Enabled = false;

                //poseCheckBox.Checked = true;
                poseCheckBox.Enabled = true;


            }
            else
            {
                pictureBox1.Invalidate();
                // pictureBox1.Image = null;
                pictureBox1.Image = Image.FromFile(dataSetImgFilePath[i]);

                //faceLandmarkCheckBox.Checked = true;
                faceLandmarkCheckBox.Enabled = true;

                //eyeLandmarkCheckBox.Checked = true;
                eyeLandmarkCheckBox.Enabled = true;

                //mouthLandmarkCheckBox.Checked = true;
                mouthLandmarkCheckBox.Enabled = true;

                poseCheckBox.Checked = false;
                poseCheckBox.Enabled = false;

            }
        }
        List<bool> statusEyeClosedList = new List<bool>();
        List<bool> statusDropheadList = new List<bool>();
        List<bool> statusGazeForwardList = new List<bool>();
        List<bool> statusFaceForwardList = new List<bool>();
        List<bool> statusYawnList = new List<bool>();
        List<int> drowsinessValueList = new List<int>();
        List<int> lookForwardValueList = new List<int>();
        List<int> abnormalCationValueList = new List<int>();
        List<int> driableStateValueList = new List<int>();



        List<List<Point>> controlLabelPoints = new List<List<Point>>();
        List<List<Point>> faceLabelPoints = new List<List<Point>>();
        List<List<Point>> poseLabelPoints = new List<List<Point>>();
        List<List<Point>> eyeLabelPoints = new List<List<Point>>();
        List<List<Point>> mouthLabelPoints = new List<List<Point>>();


        private bool isSideViewSwitchEventRegistered = false;

        private void btn_Click(object sender, EventArgs e, int i)
        {
           // caputed_index = i;

            //Console.WriteLine("front_index = " + caputed_index);
            sideViewSwitch.Checked = false;
            faceLandmarkCheckBox.Checked = false;
            //faceLandmarkCheckBox.Enabled = false;

            eyeLandmarkCheckBox.Checked = false;
            //eyeLandmarkCheckBox.Enabled = false;

            mouthLandmarkCheckBox.Checked = false;
            //mouthLandmarkCheckBox.Enabled = false;

            poseCheckBox.Checked = false;
            //poseCheckBox.Enabled = true;

            //Console.WriteLine(caputed_index);
            pictureBox1.Image = Image.FromFile(dataSetImgFilePath[i]);
            fileContent = "";
            fileContent = File.ReadAllText(dataSetJsonFilePath);
            int x;
            int y;

            pictureBox1.Paint += PictureBox1_Paint;
            string folderPath = "JsonFiles";
            string filePath = Path.Combine(folderPath, "json" + i + ".txt");
            pictureBox1.Invalidate();

            currentSelectDataLog.Text = " > 현재 작업 중인 파일 : " + "Front Image" + i.ToString() + "\n";

            sideViewSwitch.CheckedChanged += (sender1, e1) => sideViewSwitch_CheckedChanged(sender, e, i);

            pictureBox1.Invalidate();

            /* statusEyeClosedList.Add(statusEyeClosed);
             statusDropheadList.Add(statusDrophead);
             statusGazeForwardList.Add(statusGazeForward);
             statusFaceForwardList.Add(statusFaceForward);
             statusYawnList.Add(statusYawn);*/

            //drowsinessValueList.Add(drowsinessValue);
            //lookForwardValueList.Add(lookForwardValue);
            //abnormalCationValueList.Add(abnormalCationValue);
            //driableStateValueList.Add(driableStateValue);

            DrowsinessTextBox.Leave -= DrowsinessTextBox_Leave; // 먼저 이벤트 핸들러를 제거합니다.
            DrowsinessTextBox.Leave += DrowsinessTextBox_Leave; // 다시 이벤트 핸들러를 추가합니다.

            lookForwardValueTextBox.Leave -= lookForwardValueTextBox_Leave;
            lookForwardValueTextBox.Leave += lookForwardValueTextBox_Leave;

            textBox1.Leave -= textBox1_Leave;
            textBox1.Leave += textBox1_Leave;

            textBox2.Leave -= textBox2_Leave;
            textBox2.Leave += textBox2_Leave;

            //DrowsinessTextBox.KeyPress += (sender1, e1) => DrowsinessTextBox_KeyPress(sender, e);



            // modifyEyeClosedCB.Checked = statusEyeClosedList[i];
            //   modifyDropHeadCB.Checked = statusDropheadList[i];
            // modifyFaceForwardCB.Checked = statusFaceForwardList[i];
            modifyEyeClosedCB.CheckedChanged += (sender1, e1) => modifyEyeClosedCB_CheckedChanged(sender, e);
            modifyYawnCB.CheckedChanged += (sender1, e1) => modifyYawnCB_CheckedChanged(sender, e);
            modifyDropHeadCB.CheckedChanged += (sender1, e1) => modifyDropHeadCB_CheckedChanged(sender, e);
            modifyGazeForwardCB.CheckedChanged += (sender1, e1) => modifyGazeForwardCB_CheckedChanged(sender, e);
            modifyFaceForwardCB.CheckedChanged += (sender1, e1) => modifyFaceForwardCB_CheckedChanged(sender, e);

       
            

            caputed_index = i;

            
            DrowsinessTextBox.Text = drowsinessValueList[i].ToString();
            lookForwardValueTextBox.Text = lookForwardValueList[i].ToString();

            textBox1.Text = abnormalCationValueList[i].ToString();
            textBox2.Text = driableStateValueList[i].ToString();

            modifyEyeClosedCB.Checked = statusEyeClosedList[i];
            modifyDropHeadCB.Checked = statusDropheadList[i];
            modifyFaceForwardCB.Checked = statusFaceForwardList[i];
            modifyGazeForwardCB.Checked = statusGazeForwardList[i];
            modifyYawnCB.Checked = statusYawnList[i];
           // Console.WriteLine(statusEyeClosedList[i] + " : " + modifyEyeClosedCB);

        }

        private void GetJsonDataPoint(List<List<Point>> labelPoint, List<int> labelPointList, int i, int discri)
        {
            using (StreamReader streamReader = new StreamReader(dataSetJsonFilePath))
            {
                string jsonString = streamReader.ReadToEnd();
                // JSON 문자열 파싱
                var jsonDoc = JsonDocument.Parse(jsonString);

                // Access the desired frame
                var frame = jsonDoc.RootElement.GetProperty("frame").GetProperty(i.ToString());
                if (discri == 1)
                {
                    if (frame.TryGetProperty("pose_labels", out var pose_labels) && pose_labels.EnumerateObject().Any())
                    {
                        List<Point> poseLabelPointsFrame = new List<Point>();
                        for (int idx = 0; idx < labelPointList.Count - 1; ++idx)
                        {
                            var value = pose_labels.GetProperty(labelPointList[idx].ToString());
                            poseLabelPointsFrame.Add(new Point(value[0].GetInt32() * imageRatio, value[1].GetInt32() * imageRatio));
                        }
                        for (int index = 0; index < poseLabelPointsFrame.Count; index++)
                        {
                            labelPoint[i].Add(poseLabelPointsFrame[index]);
                        }

                        
                    }
                    var drowsinessStatus = frame.GetProperty("driver status").GetProperty("DROWSINESS");
                    bool statusEyeClosed = drowsinessStatus.GetProperty("EYE OPENED").GetBoolean();
                    bool statusYawn = drowsinessStatus.GetProperty("YAWN").GetBoolean();
                    bool statusDrophead = drowsinessStatus.GetProperty("DROP HEAD").GetBoolean();
                    int drowsinessValue = drowsinessStatus.GetProperty("DROWSINESS VALUE").GetInt32();
                    var lookForwardStatus = frame.GetProperty("driver status").GetProperty("LOOK FORWARD");
                    bool statusGazeForward = lookForwardStatus.GetProperty("GAZE FORWARD").GetBoolean();
                    bool statusFaceForward = lookForwardStatus.GetProperty("FACE FORWARD").GetBoolean();
                    int lookForwardValue = lookForwardStatus.GetProperty("LOOK FORWARD VALUE").GetInt32();
                    //Log.Text = lookForwardValue.ToString();
                    var abnormalCation = frame.GetProperty("driver status").GetProperty("ABNORMAL CATION");
                    int abnormalCationValue = abnormalCation.GetProperty("ABNORMAL CATION VALUE").GetInt32();
                    int driableStateValue = abnormalCation.GetProperty("DRIABLE STATE VALUE").GetInt32();
                    
                    statusEyeClosedList.Add(statusEyeClosed);
                    statusDropheadList.Add(statusDrophead);
                    statusGazeForwardList.Add(statusGazeForward);
                    statusFaceForwardList.Add(statusFaceForward);
                    statusYawnList.Add(statusYawn);
                    drowsinessValueList.Add(drowsinessValue);
                    lookForwardValueList.Add(lookForwardValue);
                    abnormalCationValueList.Add(abnormalCationValue);
                    driableStateValueList.Add(driableStateValue);
                   
                }
                if (discri == 0)
                {
                    if (frame.TryGetProperty("face_labels", out var face_labels) && face_labels.EnumerateObject().Any())
                    {
                        List<Point> faceLabelPointsFrame = new List<Point>();
                        for (int idx = 0; idx < labelPointList.Count; ++idx)
                        {
                            var value = face_labels.GetProperty(labelPointList[idx].ToString());
                            faceLabelPointsFrame.Add(new Point(value[0].GetInt32() * imageRatio, value[1].GetInt32() * imageRatio));
                        }
                        for (int index = 0; index < faceLabelPointsFrame.Count; index++)
                        {
                            labelPoint[i].Add(faceLabelPointsFrame[index]);
                        }
                    }
                    
                }

                
            }
        }

        private void faceLandmarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Log.Text += " ▷ 얼굴 특징점 표시 \n     → " + faceLandmarkCheckBox.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
            pictureBox1.Invalidate();
        }

        private void eyeLandmarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Log.Text += " ▷ 눈동자 특징점 레이블 표시 \n     → " + eyeLandmarkCheckBox.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
            pictureBox1.Invalidate();
        }

        private void mouthLandmarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Log.Text += " ▷ 입술 레이블 표시 \n     → " + mouthLandmarkCheckBox.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
            pictureBox1.Invalidate();
        }

        private void poseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Log.Text += " ▷ 자세 특징점 표시 \n     → " + poseCheckBox.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
            pictureBox1.Invalidate();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //totalLabelPoints.Clear(); // totalLabelPoints 초기화
            controlLabelPoints.Clear();
            //Console.WriteLine("error : " + caputed_index.ToString());
            if (faceLandmarkCheckBox.Checked)
            {
                drawPoint(e, faceLabelPoints[caputed_index]);
            }
            if (eyeLandmarkCheckBox.Checked)
            {
                drawPoint(e, eyeLabelPoints[caputed_index]);

            }
            if (mouthLandmarkCheckBox.Checked)
            {
                drawPoint(e, mouthLabelPoints[caputed_index]);
            }
            if (poseCheckBox.Checked)
            {
                drawLinePoint(e, poseLabelPoints[caputed_index]);
            }
        }
        private List<Point> selectedList = null;
        private int selectedIndex = -1;
        private Point? originalPoint = null;

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            selectedList = null;
            selectedIndex = -1;
            originalPoint = null;
            int radiusSquared = 5 * 5;  // 반경을 제곱하여 거리를 비교
                                        // 모든 포인트를 검사하고 클릭 위치가 반경 내에 있는 포인트를 선택
            foreach (var pointList in new[] { faceLabelPoints[caputed_index], eyeLabelPoints[caputed_index], mouthLabelPoints[caputed_index], poseLabelPoints[caputed_index] })
            {
                for (int i = 0; i < pointList.Count; i++)
                {
                    var point = pointList[i];
                    int distSquared = (point.X - e.X) * (point.X - e.X) + (point.Y - e.Y) * (point.Y - e.Y);
                    if (distSquared <= radiusSquared)
                    {
                        selectedList = pointList;
                        selectedIndex = i;
                        originalPoint = new Point(point.X, point.Y);
                        return;  // 가장 먼저 찾은 포인트를 선택하고 루프 종료
                    }
                }
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedList != null && selectedIndex != -1 && e.Button == MouseButtons.Left)
            {
                // 선택된 포인트를 마우스 위치로 이동
                selectedList[selectedIndex] = e.Location;
                pictureBox1.Invalidate();  // PictureBox를 다시 그림
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedList != null && selectedIndex != -1 && originalPoint.HasValue)
            {
                // Log the move
                Log.Text += $" ↔ Moved point from ({originalPoint.Value.X}, {originalPoint.Value.Y}) to ({e.X}, {e.Y})\n\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
                // Clear the selected point
                selectedList = null;
                selectedIndex = -1;
                originalPoint = null;
            }
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {

            /*Console.WriteLine("뭔지 진짜 "+maxImageCount);
            Console.WriteLine("뭔지 진짜2 " + MAX_LABELING_COUNT);*/
            Point[,] totalLabelPoints = new Point[maxImageCount, MAX_LABELING_COUNT];
            Point[,] totalPoseLabelPoints = new Point[maxImageCount, poseLandmarkList.Count - 1];

            bool[] eyeClosedCbState = new bool[maxImageCount];
            bool[] yawnCbState = new bool[maxImageCount];
            bool[] dropHeadCbState = new bool[maxImageCount];

            bool[] gazeForwardCbState = new bool[maxImageCount];
            bool[] faceForwardCbState = new bool[maxImageCount];

            int[] setDrowsinessValue = new int[maxImageCount];
            int[] setLookForwardValueJson = new int[maxImageCount];
            int[] setTextBox1 = new int[maxImageCount];
            int[] setTextBox2 = new int[maxImageCount];

            string inputFilePath = dataSetJsonFilePath;

            string outputFilePath = dataSetJsonFilePath;

            for (int i = 0; i < maxImageCount; i++)
            {
                for (int l = 0; l < MAX_LABELING_COUNT; l++)
                {
                    totalLabelPoints[i, l] = new Point();
                }
            }
            //초기화 끝

            // modifyEyeClosedCB.Checked = statusEyeClosedList[i];
            //   modifyDropHeadCB.Checked = statusDropheadList[i];
            // modifyFaceForwardCB.Checked = statusFaceForwardList[i];
            for (int index = 0; index < dataSetSideImgFilePath.Count; index++)
            {
                //if(eyeClosedCheckBox.Checked) 
                eyeClosedCbState[index] = statusEyeClosedList[index];
                //if(yawnCB.Checked) 
                yawnCbState[index] = statusYawnList[index];
                //if(DropHeadCB.Checked)
                dropHeadCbState[index] = statusDropheadList[index];
                //if(gazeFowardCB.Checked)
                gazeForwardCbState[index] = statusGazeForwardList[index];
                //if(FaceForwardCB.Checked)
                faceForwardCbState[index] = statusFaceForwardList[index];


                setDrowsinessValue[index] = drowsinessValueList[index];
                //if(LookForwardCB.Checked)
                setLookForwardValueJson[index] = lookForwardValueList[index];
                //if(abnormalBehaviorCheckBox.Checked)
                setTextBox1[index] = abnormalCationValueList[index];
                //if(DriableCB.Checked) 
                setTextBox2[index] = driableStateValueList[index];

                //DrowsinessTextBox.Text = drowsinessValueList[i].ToString();
                //lookForwardValueTextBox.Text = lookForwardValueList[i].ToString();

                //textBox1.Text = abnormalCationValueList[i].ToString();
                //textBox2.Text = driableStateValueList[i].ToString();



                //if(drowsinessCB.Checked)

                
                int j = 0;

                if (eyeLabelPoints[index].Count != 0)
                {
                    for (int i = 0; i < (leftEyeLandmarkList.Count + rightEyeLandmarkList.Count); i++)
                    {
                        if (i < leftEyeLandmarkList.Count)
                        {
                            totalLabelPoints[index, leftEyeLandmarkList[i]] = eyeLabelPoints[index][i];
                        }
                        else
                        {
                            totalLabelPoints[index, rightEyeLandmarkList[j]] = eyeLabelPoints[index][i];
                            j++;
                        }
                    }
                }
                if (faceLabelPoints[index].Count != 0)
                {
                    int k = 0;
                    for (int i = 0; i < leftMouthLandmarkList.Count + rightMouthLandmarkList.Count; i++)
                    {
                        if (i < leftMouthLandmarkList.Count)
                            totalLabelPoints[index, leftMouthLandmarkList[i]] = faceLabelPoints[index][i];
                        else
                        {
                            totalLabelPoints[index, rightMouthLandmarkList[k]] = faceLabelPoints[index][i];
                            k++;
                        }
                    }
                }
                if (faceLabelPoints[index].Count != 0)
                {
                    int l = 0;
                    for (int i = 0; i < faceFormLandmarkList.Count; i++)
                    {
                        totalLabelPoints[index, faceFormLandmarkList[i]] = faceLabelPoints[index][l];
                        l++;
                    }
                    for (int i = 0; i < faceEdgeLandmarkList.Count; i++)
                    {
                        totalLabelPoints[index, faceEdgeLandmarkList[i]] = faceLabelPoints[index][l];
                        l++;
                    }
                }
                if (mouthLabelPoints[index].Count != 0)
                {
                    int x = 0;
                    for (int i = 0; i < mouthEdgeLandmarkList.Count; i++)
                    {
                        totalLabelPoints[index, mouthEdgeLandmarkList[i]] = mouthLabelPoints[index][x];
                        x++;
                    }

                    totalLabelPoints[index, 78] = mouthLabelPoints[index][x];
                    x++;
                    totalLabelPoints[index, 308] = mouthLabelPoints[index][x];
                }
                if (poseLabelPoints[index].Count != 0)
                {
                    for (int i = 0; i < poseLandmarkList.Count - 1; i++)
                    {
                        totalPoseLabelPoints[index, i] = poseLabelPoints[index][i];
                    }
                }
            }
            jsonUpdateOutput(inputFilePath, outputFilePath, totalLabelPoints, totalPoseLabelPoints, eyeClosedCbState, yawnCbState, dropHeadCbState, gazeForwardCbState,
               faceForwardCbState, setDrowsinessValue, setLookForwardValueJson, setTextBox1, setTextBox2);
        }
        private void jsonUpdateOutput(string inputFilePath, string outputFilePath, Point[,] totalLabelPoints, Point[,] totalPoseLabelPoints
            , bool[] eyeClosedCbState, bool[] yawnCbState, bool[] dropHeadCbState,
            bool[] gazeForwardCbState, bool[] faceForwardCbState, int[] setDrowsinessValue
            , int[] setLookForwardValueJson, int[] setTextBox1, int[] setTextBox2)
        {
            JObject mainObject = new JObject();
            JObject frameObject = new JObject();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maxImageCount;
            for (int index = 0; index < maxImageCount; index++)
            {
                JObject driverStatusObject = new JObject();

                if (eyeClosedCheckBox.Checked || yawnCB.Checked || DropHeadCB.Checked || drowsinessCB.Checked)
                {
                    JObject drowsinessObject = new JObject();
                    if (eyeClosedCheckBox.Checked)
                        drowsinessObject.Add("EYE OPENED", eyeClosedCbState[index]);
                    if (yawnCB.Checked)
                        drowsinessObject.Add("YAWN", yawnCbState[index]);
                    if (DropHeadCB.Checked)
                        drowsinessObject.Add("DROP HEAD", dropHeadCbState[index]);
                    if (drowsinessCB.Checked)
                        drowsinessObject.Add("DROWSINESS VALUE", setDrowsinessValue[index]);

                    driverStatusObject.Add("DROWSINESS", drowsinessObject);
                }

                if (gazeFowardCB.Checked || FaceForwardCB.Checked || setLookForwardValueJson[index] != 0)
                {
                    JObject lookForwardObject = new JObject();
                    if (gazeFowardCB.Checked)
                        lookForwardObject.Add("GAZE FORWARD", gazeForwardCbState[index]);
                    if (FaceForwardCB.Checked)
                        lookForwardObject.Add("FACE FORWARD", faceForwardCbState[index]);
                    if (setLookForwardValueJson[index] != 0)
                        lookForwardObject.Add("LOOK FORWARD VALUE", setLookForwardValueJson[index]);

                    driverStatusObject.Add("LOOK FORWARD", lookForwardObject);
                }

                if (abnormalBehaviorCheckBox.Checked || DriableCB.Checked)
                {
                    JObject abnormalCationObject = new JObject();
                    if (abnormalBehaviorCheckBox.Checked)
                        abnormalCationObject.Add("ABNORMAL CATION VALUE", setTextBox1[index]);
                    if (DriableCB.Checked)
                        abnormalCationObject.Add("DRIABLE STATE VALUE", setTextBox2[index]);

                    driverStatusObject.Add("ABNORMAL CATION", abnormalCationObject);
                }

                JObject frameItemObject = new JObject();
                frameItemObject.Add("driver status", driverStatusObject);

                JObject faceLabelsObject = new JObject();
                for (int i = 0; i < MAX_LABELING_COUNT; i++)
                {
                    var point = totalLabelPoints[index, i];
                    int roundedX = (int)Math.Round((double)point.X / 2); // Add rounding after division by 2
                    int roundedY = (int)Math.Round((double)point.Y / 2); // Add rounding after division by 2
                    faceLabelsObject.Add(i.ToString(), new JArray(roundedX, roundedY));
                }
                frameItemObject.Add("face_labels", faceLabelsObject);

                JObject poseLabelsObject = new JObject();
                for (int i = 0; i < poseLandmarkList.Count - 1; i++)
                {
                    var point = totalPoseLabelPoints[index, i];
                    int roundedX = (int)Math.Round((double)point.X / 2); // Add rounding after division by 2
                    int roundedY = (int)Math.Round((double)point.Y / 2); // Add rounding after division by 2
                    poseLabelsObject.Add(i.ToString(), new JArray(roundedX, roundedY));
                }
                frameItemObject.Add("pose_labels", poseLabelsObject);

                frameObject.Add(index.ToString(), frameItemObject);

                progressBar1.Value++;
            }

            JObject frameWrapperObject = new JObject();
            frameWrapperObject.Add("frame", frameObject);

            mainObject.Merge(frameWrapperObject, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Replace
            });

            // Write to outputFilePath
            System.IO.File.WriteAllText(outputFilePath, mainObject.ToString());

            MessageBox.Show("저장 완료");
            progressBar1.Value = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form form2 = new Form();
            System.Windows.Forms.TextBox SearchTextBox = new System.Windows.Forms.TextBox();
            System.Windows.Forms.Button SearchTextbtn = new System.Windows.Forms.Button();

            RichTextBox json_text_box = new RichTextBox();

            form2.Size = new Size(600, 995);
            form2.BackColor = Color.FromArgb(30, 30, 30);

            bool allKeywordsFound = false; // 검색어를 모두 찾았는지 여부를 나타내는 변수

            SearchTextbtn.Size = new Size(80, 23);
            SearchTextbtn.Text = "검색";
            SearchTextbtn.Location = new Point(170, 0);
            SearchTextbtn.BackColor = Color.FromArgb(250, 250, 250);

            int currentIndex = 0; // 현재 검색 중인 위치를 나타내는 변수

            SearchTextbtn.Click += (s, ev) =>
            {
                string searchKeyword = SearchTextBox.Text.Trim();

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    json_text_box.SelectionStart = currentIndex;
                    json_text_box.SelectionLength = json_text_box.TextLength - currentIndex;
                    json_text_box.SelectionBackColor = json_text_box.BackColor;
                    json_text_box.SelectionColor = json_text_box.ForeColor;

                    int index = json_text_box.Find(searchKeyword, currentIndex, json_text_box.TextLength, RichTextBoxFinds.None);
                    if (index != -1)
                    {
                        json_text_box.SelectionStart = index;
                        json_text_box.SelectionLength = searchKeyword.Length;
                        json_text_box.SelectionBackColor = Color.Yellow;
                        json_text_box.SelectionColor = Color.Black;
                        json_text_box.ScrollToCaret();
                        json_text_box.Focus();

                        currentIndex = index + searchKeyword.Length;
                        allKeywordsFound = false;
                    }
                    else
                    {
                        MessageBox.Show("검색어를 찾을 수 없습니다.");
                        currentIndex = 0;
                        allKeywordsFound = true;
                    }
                }
            };

            form2.FormClosing += (s, ev) =>
            {
                // 폼이 닫힐 때 노란색 포커스 해제
                if (allKeywordsFound)
                {
                    json_text_box.SelectionStart = 0;
                    json_text_box.SelectionLength = 0;
                    json_text_box.SelectionBackColor = json_text_box.BackColor;
                    json_text_box.SelectionColor = json_text_box.ForeColor;
                }
            };

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
            Log.Text += "▷ 저장 레이블(눈 감김 여부) \n     → " + eyeClosedCheckBox.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();

        }
        private void drowsnissCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //졸음 레이블 체크박스

            Log.Text += " ▷ 저장 레이블(하품 여부) \n     → " + yawnCB.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //전방 미주시 레이블 체크박스
            Log.Text += " ▷ 저장 레이블(고개 떨굼 여부) \n     → " + DropHeadCB.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }

        private void headDirectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //전방 주시
            Log.Text += " ▷ 저장 레이블(시선 전방 주시 여부   \n     → " + gazeFowardCB.CheckState.ToString() +"\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            //운전전환가능상태 체크박스
            Log.Text += " ▷ 저장 레이블(얼굴 전방 주시 여부) \n     → " + FaceForwardCB.CheckState.ToString() +"\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }
        private void abnormalBehaviorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //운전자 이상행동 레이블 체크박스
            Log.Text += " ▷ 저장 레이블(이상행동 확률 여부) \n     → " + abnormalBehaviorCheckBox.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }
        private void drowsinessCB_CheckedChanged(object sender, EventArgs e)
        {
            Log.Text += " ▷ 저장 레이블(졸음 확률 여부) \n     → " + drowsinessCB.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }
        private void LookForwardCB_CheckedChanged(object sender, EventArgs e)
        {
            Log.Text += " ▷ 저장 레이블(전방미주시 확률 여부) \n     → " + LookForwardCB.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }

        private void DriableCB_CheckedChanged(object sender, EventArgs e)
        {
            Log.Text += " ▷ 저장 레이블(운전전환가능상태 확률 여부) \n     → " + DriableCB.CheckState.ToString() + "\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            //얼굴 특징점 랜드마크 키포인트
            pictureBox1.Invalidate();
            //Log.Text = faceLandmarkCheckBox.CheckState.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        { }
        private void label6_Click(object sender, EventArgs e)
        { }
        private void label7_Click(object sender, EventArgs e)
        { }
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
            if (labelPoint.Count != 0)
            {
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
        }
        private void drawLinePoint(PaintEventArgs e, List<Point> labelPoint)
        {
            Graphics g = e.Graphics;

            if (labelPoint.Count != 0)
            {
                using (Pen pen = new Pen(Color.Green, 3))
                {
                    g.DrawLine(pen, labelPoint[8], labelPoint[6]);
                    g.DrawLine(pen, labelPoint[6], labelPoint[5]);
                    g.DrawLine(pen, labelPoint[5], labelPoint[4]);
                    g.DrawLine(pen, labelPoint[4], labelPoint[0]);
                    g.DrawLine(pen, labelPoint[0], labelPoint[1]);
                    g.DrawLine(pen, labelPoint[1], labelPoint[2]);
                    g.DrawLine(pen, labelPoint[2], labelPoint[3]);
                    g.DrawLine(pen, labelPoint[3], labelPoint[7]);

                    g.DrawLine(pen, labelPoint[10], labelPoint[9]);

                    g.DrawLine(pen, labelPoint[11], labelPoint[13]);
                    g.DrawLine(pen, labelPoint[13], labelPoint[15]);
                    g.DrawLine(pen, labelPoint[15], labelPoint[21]);
                    g.DrawLine(pen, labelPoint[15], labelPoint[17]);
                    g.DrawLine(pen, labelPoint[15], labelPoint[19]);
                    g.DrawLine(pen, labelPoint[19], labelPoint[17]);

                    g.DrawLine(pen, labelPoint[11], labelPoint[12]);
                    g.DrawLine(pen, labelPoint[12], labelPoint[14]);
                    g.DrawLine(pen, labelPoint[14], labelPoint[16]);

                    g.DrawLine(pen, labelPoint[16], labelPoint[22]);
                    g.DrawLine(pen, labelPoint[16], labelPoint[18]);
                    g.DrawLine(pen, labelPoint[16], labelPoint[20]);
                    g.DrawLine(pen, labelPoint[18], labelPoint[20]);

                    g.DrawLine(pen, labelPoint[12], labelPoint[24]);
                    g.DrawLine(pen, labelPoint[11], labelPoint[23]);

                    g.DrawLine(pen, labelPoint[24], labelPoint[26]);
                    g.DrawLine(pen, labelPoint[26], labelPoint[28]);
                    g.DrawLine(pen, labelPoint[28], labelPoint[32]);
                    g.DrawLine(pen, labelPoint[28], labelPoint[30]);
                    g.DrawLine(pen, labelPoint[32], labelPoint[30]);

                    g.DrawLine(pen, labelPoint[24], labelPoint[23]);
                    g.DrawLine(pen, labelPoint[23], labelPoint[25]);
                    g.DrawLine(pen, labelPoint[25], labelPoint[27]);

                    g.DrawLine(pen, labelPoint[27], labelPoint[31]);
                    g.DrawLine(pen, labelPoint[29], labelPoint[31]);
                    g.DrawLine(pen, labelPoint[27], labelPoint[29]);

                }
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    int radius = 4;
                    for (int i = 0; i < 33; i++)
                    {
                        g.FillEllipse(brush, labelPoint[i].X - radius, labelPoint[i].Y - radius, radius * 2, radius * 2);
                    }
                }
            }
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
          
        private void modifyEyeClosedCB_CheckedChanged(object sender, EventArgs e)
        {
            statusEyeClosedList[caputed_index] = modifyEyeClosedCB.Checked;
            modifyEyeClosedCB.Checked = statusEyeClosedList[caputed_index];
        }

        private void modifyYawnCB_CheckedChanged(object sender, EventArgs e)
        {
            statusYawnList[caputed_index] = modifyYawnCB.Checked;
            modifyYawnCB.Checked = statusYawnList[caputed_index];
        }

        private void modifyDropHeadCB_CheckedChanged(object sender, EventArgs e)
        {
            statusDropheadList[caputed_index] = modifyDropHeadCB.Checked;
            modifyDropHeadCB.Checked = statusDropheadList[caputed_index];
        }

        private void modifyGazeForwardCB_CheckedChanged(object sender, EventArgs e)
        {
             statusGazeForwardList[caputed_index] = modifyGazeForwardCB.Checked;
            modifyGazeForwardCB.Checked = statusGazeForwardList[caputed_index];
        }

        private void modifyFaceForwardCB_CheckedChanged(object sender, EventArgs e)
        {
            statusFaceForwardList[caputed_index] = modifyFaceForwardCB.Checked;
            modifyFaceForwardCB.Checked = statusFaceForwardList[caputed_index];
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void sideViewSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Log.Text += " ● 사이드 뷰 전환 : " + sideViewSwitch.CheckState.ToString() + "\n\n";
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }


        private void modifyEyeClosedCB_CheckedChanged_1(object sender, EventArgs e)
        {
            
            if (modifyEyeClosedCB.CheckState == CheckState.Checked)
            {
                Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(눈 뜸 여부)\n " + "\tUnchecked" + " → " + "Checked\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }
            else 
            {
                Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(눈 뜸 여부)\n " + "\tChecked" + " → " + "Unchecked\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }
        }

        private void modifyYawnCB_CheckedChanged_1(object sender, EventArgs e)
        {
            if (modifyYawnCB.CheckState == CheckState.Checked)
            {
                Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(하품 여부)\n " + "\tUnchecked" + " → " + "Checked\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }
            else
            {
                Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(하품 여부)\n " + "\tChecked" + " → " + "Unchecked\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }
        }

        private void modifyDropHeadCB_CheckedChanged_1(object sender, EventArgs e)
        {
            if (modifyDropHeadCB.CheckState == CheckState.Checked)
            {
                Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(고개떨굼 여부)\n " + "\tUnchecked" + " → " + "Checked\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }
            else
            {
                Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(고개떨굼 여부)\n " + "\tChecked" + " → " + "Unchecked\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }

        }

        private void modifyGazeForwardCB_CheckedChanged_1(object sender, EventArgs e)
        {
            if (modifyGazeForwardCB.CheckState == CheckState.Checked)
            {
                Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(시선 전방 주시 여부)\n " + "\tUnchecked" + " → " + "Checked\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }
            else
            {
                Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(시선 전방 주시 여부)\n " + "\tChecked" + " → " + "Unchecked\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }
        }

        private void modifyFaceForwardCB_CheckedChanged_1(object sender, EventArgs e)
        {
            if (modifyFaceForwardCB.CheckState == CheckState.Checked)
            {
                Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(얼굴 전방 주시 여부)\n " + "\tUnchecked" + " → " + "Checked\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }
            else
            {
                Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(얼굴 전방 주시 여부)\n " + "\tChecked" + " → " + "Unchecked\n";
                Log.SelectionStart = Log.Text.Length;
                Log.ScrollToCaret();
            }
        }


        private void DrowsinessTextBox_TextChanged(object sender, EventArgs e)
        {
            Regex regexNumber = new Regex(@"^[0-9]*$");
            if (!regexNumber.IsMatch(DrowsinessTextBox.Text) && !string.IsNullOrEmpty(DrowsinessTextBox.Text))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                DrowsinessTextBox.Text = "";
            }
            else
            {
                if (!string.IsNullOrEmpty(DrowsinessTextBox.Text))
                {
                    drowsinessValueList[caputed_index] = Int32.Parse(DrowsinessTextBox.Text);
                }
            }
        }
        private void DrowsinessTextBox_Leave(object sender, EventArgs e)
        {
            // 입력값을 검증합니다.
            Regex regexNumber = new Regex(@"^[0-9]*$");
            if (!regexNumber.IsMatch(DrowsinessTextBox.Text))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                DrowsinessTextBox.Text = "0";
            }
            else
            {
                // 입력값이 올바른 경우, 입력 완료 메시지를 표시하고 값을 리스트에 저장합니다.
                if (!string.IsNullOrEmpty(DrowsinessTextBox.Text))
                {
                    Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(졸음확률) : " + drowsinessValueList[caputed_index].ToString() + "(%) → ";
                    drowsinessValueList[caputed_index] = Int32.Parse(DrowsinessTextBox.Text);
                    Log.Text += drowsinessValueList[caputed_index].ToString()+ "(%)\n";
                    Log.SelectionStart = Log.Text.Length;
                    Log.ScrollToCaret();
                }
            }
        }
        private void lookForwardValueTextBox_Leave(object sender, EventArgs e)
        {
            // 입력값을 검증합니다.
            Regex regexNumber = new Regex(@"^[0-9]*$");
            if (!regexNumber.IsMatch(lookForwardValueTextBox.Text))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                lookForwardValueTextBox.Text = "0";
            }
            else
            {
                // 입력값이 올바른 경우, 입력 완료 메시지를 표시하고 값을 리스트에 저장합니다.
                if (!string.IsNullOrEmpty(lookForwardValueTextBox.Text))
                {
                    Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(전방미주시 확률) : " + lookForwardValueList[caputed_index].ToString() + "(%) → ";
                    lookForwardValueList[caputed_index] = Int32.Parse(lookForwardValueTextBox.Text);
                    Log.Text += lookForwardValueList[caputed_index].ToString() + "(%)\n";
                    Log.SelectionStart = Log.Text.Length;
                    Log.ScrollToCaret();

                    
                }
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            // 입력값을 검증합니다.
            Regex regexNumber = new Regex(@"^[0-9]*$");
            if (!regexNumber.IsMatch(textBox1.Text))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                textBox1.Text = "0";
            }
            else
            {
                // 입력값이 올바른 경우, 입력 완료 메시지를 표시하고 값을 리스트에 저장합니다.
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(이상행동여부 확률) : " + abnormalCationValueList[caputed_index].ToString() + "(%) → ";
                    abnormalCationValueList[caputed_index] = Int32.Parse(textBox1.Text);
                    Log.Text += abnormalCationValueList[caputed_index].ToString() + "(%)\n";
                    Log.SelectionStart = Log.Text.Length;
                    Log.ScrollToCaret();

            
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            // 입력값을 검증합니다.
            Regex regexNumber = new Regex(@"^[0-9]*$");
            if (!regexNumber.IsMatch(textBox2.Text))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                textBox2.Text = "0";
            }
            else
            {
                // 입력값이 올바른 경우, 입력 완료 메시지를 표시하고 값을 리스트에 저장합니다.
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    Log.Text += "[ " + caputed_index.ToString() + " ] " + " ▷ 수정 레이블(운전전환가능 확률) : " + driableStateValueList[caputed_index].ToString() + "(%) → ";
                    driableStateValueList[caputed_index] = Int32.Parse(textBox2.Text);
                    Log.Text += driableStateValueList[caputed_index].ToString() + "(%)\n";
                    Log.SelectionStart = Log.Text.Length;
                    Log.ScrollToCaret();

                }
            }
        }
      

  


    }
}