﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Threading;

namespace MultiFaceRec
{
    public partial class FrmPrincipal : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels= new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;


        public FrmPrincipal()
        {
            InitializeComponent();
            //Load haarcascades for face detection
            face = new HaarCascade("D:\\Online_Exam\\FaceC\\haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText("D:\\Online_Exam\\FaceC\\bin\\Debug\\TrainedFaces\\TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels+1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>("D:\\Online_Exam\\FaceC\\bin\\Debug\\TrainedFaces\\" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            
            }
            catch(Exception e)
            {
                //MessageBox.Show(e.ToString());
                //MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            button1.Enabled = false;
        }
        public void savedb()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
            //  SqlCommand cmd=new SqlCommand(CommandText,con);
            con.Open();
            SqlCommand cmm = new SqlCommand("select * from temp", con);
            SqlDataReader dr = cmm.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                // this.con.Close();
            }
           
          
          
        }


        public void savedb1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
            //  SqlCommand cmd=new SqlCommand(CommandText,con);
            con.Open();
            SqlCommand cmm = new SqlCommand("insert into successdb values ('"+ textBox2.Text +"') ", con);
           
            try
            {
                cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                // this.con.Close();
            }



        }
        public void  deletedb()
        {

            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
            //  SqlCommand cmd=new SqlCommand(CommandText,con);
            con.Open();
            SqlCommand cmm = new SqlCommand("delete from successdb1", con);

            try
            {
                cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                // this.con.Close();
            }



        }
        public void savedb2()
        {
            deletedb();
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
            //  SqlCommand cmd=new SqlCommand(CommandText,con);
            con.Open();
            SqlCommand cmm = new SqlCommand("insert into successdb1 values ('" + textBox2.Text + "') ", con);

            try
            {
                cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                // this.con.Close();
            }



        }
        public void deletesuccess()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
            //  SqlCommand cmd=new SqlCommand(CommandText,con);
            con.Open();
            SqlCommand cmm = new SqlCommand("delete from successdb", con);

            try
            {
                cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                // this.con.Close();
            }



        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(textBox1.Text);

                //Show face added in gray scale
                imageBox1.Image = TrainedFace;

                //Write the number of triained faces in a file text for further load
                File.WriteAllText("D:\\Online_Exam\\FaceC\\bin\\Debug\\TrainedFaces\\TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    textBox3.Text = "face" + i.ToString();
                    trainingImages.ToArray()[i - 1].Save("D:\\Online_Exam\\FaceC\\bin\\Debug\\TrainedFaces\\face" + i + ".bmp");
                    trainingImages.ToArray()[i - 1].Save("D:\\Online_Exam\\FaceC\\bin\\Debug\\TrainedFaces\\"+textBox1.Text +".bmp");
                    File.AppendAllText("D:\\Online_Exam\\FaceC\\bin\\Debug\\TrainedFaces\\TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                    savedb1();
                }

                MessageBox.Show(textBox1.Text + "´s face detected and added", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch
            {
                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        void FrameGrabber(object sender, EventArgs e)
        {
            label3.Text = "0";
            //label4.Text = "";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                    //Convert it to Grayscale
                    gray = currentFrame.Convert<Gray, Byte>();

                    //Face Detector
                    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                  face,
                  1.2,
                  10,
                  Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                  new Size(20, 20));

                    //Action for each element detected
                    foreach (MCvAvgComp f in facesDetected[0])
                    {
                        t = t + 1;
                        result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        //draw the face detected in the 0th (gray) channel with blue color
                        currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                        if (trainingImages.ToArray().Length != 0)
                        {
                            //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           3000,
                           ref termCrit);

                        name = recognizer.Recognize(result);
                        textBox2.Text = name;
                        if (textBox2.Text == textBox1.Text)
                        {
                            //Draw the label for each face detected and recognized
                            savedb2();
                            currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                            Thread.Sleep(2000);
                           // Application.Exit();
                        }

                        }

                            NamePersons[t-1] = name;
                            NamePersons.Add("");


                        //Set the number of faces detected on the scene
                        label3.Text = facesDetected[0].Length.ToString();
                       
                        /*
                        //Set the region of interest on the faces
                        
                        gray.ROI = f.rect;
                        MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                           eye,
                           1.1,
                           10,
                           Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                           new Size(20, 20));
                        gray.ROI = Rectangle.Empty;

                        foreach (MCvAvgComp ey in eyesDetected[0])
                        {
                            Rectangle eyeRect = ey.rect;
                            eyeRect.Offset(f.rect.X, f.rect.Y);
                            currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                        }
                         */

                    }
                        t = 0;

                        //Names concatenation of persons recognized
                    for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                    {
                        names = names + NamePersons[nnn] + ", ";
                    }
                    //Show the faces procesed and recognized
                    imageBoxFrameGrabber.Image = currentFrame;
                    label4.Text = names;
                    names = "";
                    //Clear the list(vector) of names
                    NamePersons.Clear();

                }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("Donate.html");
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            deletesuccess();
          savedb();
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            button1.Enabled = false;
        }

    }
}