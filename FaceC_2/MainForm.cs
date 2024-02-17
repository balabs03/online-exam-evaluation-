using System;
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
using login_logout;
using System.Drawing.Drawing2D;
using System.Collections;

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
        SqlConnection con1 = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=continuous_exam;Integrated Security=True");
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
                    trainingImages.ToArray()[i - 1].Save("D:\\Online_Exam\\FaceC\\bin\\Debug\\TrainedFaces\\face" + i + ".bmp");
                    File.AppendAllText("D:\\Online_Exam\\FaceC\\bin\\Debug\\TrainedFaces\\TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
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
            textBox2.Text = "";
            int jj = 0;
            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            File.Delete(Application.StartupPath + "\\ctestimg.jpg");
            string filename1 = Application.StartupPath + "\\ctestimg.jpg";
           
          //  currentFrame.Save(filename1);
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
                    int jk = facesDetected[0].Length;
                    foreach (MCvAvgComp f in facesDetected[0])
                    {
                        jj = 1;
                        t = t + 1;
                        string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\", "*.jpg");
                        int i55 = filePaths.Length;


                        try
                        {
                            //File.Delete(Application.StartupPath + "\\ctestimg.jpg");
                            //string filename1 = Application.StartupPath + "\\ctestimg.jpg";
                            //FileStream fstream1 = new FileStream(filename1, FileMode.Create);

                           
                            // pictureBox2.Image.Save(fstream1, System.Drawing.Imaging.ImageFormat.Jpeg);

                        }
                        catch
                        {
                        }
                       // k++;
                      
                        result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        //draw the face detected in the 0th (gray) channel with blue color
                      //  currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


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

                    //    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
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

                        if ((k == 1)&&(jk>0))
                        {
                            string filename2 = Application.StartupPath + "\\Ref.jpg";
                            currentFrame.Save(filename2);
                            k++;
                        }
                        else
                        {
                            if (k > 1)
                            {
                                currentFrame.Save(filename1);
                            }
                        }
                        try
                        {
                            if (k > 1)
                            {
                                timer5.Start();
                               
                            }
                        }
                        catch (Exception ex)
                        { }
                     //   Thread.Sleep(100);
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
                    //if ((jj == 0) && (jk == 0))
                    //{
                    //    try
                    //    {
                    //        //  MessageBox.Show("Wrong user");
                    //        con1.Open();

                    //        SqlCommand cmd1 = new SqlCommand("delete from t1", con1);
                    //        cmd1.ExecuteNonQuery();
                    //        con1.Close();
                    //        con1.Open();

                    //        SqlCommand cmd = new SqlCommand("insert into t1 values('yes')", con1);
                    //        cmd.ExecuteNonQuery();
                    //        con1.Close();
                    //    }
                    //    catch (Exception ex)
                    //    {

                    //    }
                    //}
                }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("Donate.html");
        }
        int k = 0;
        int ccou = 0;
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {

                File.Delete(Application.StartupPath+"\\ref.jpg");
                File.Delete(Application.StartupPath+"\\ctestimg.jpg");


            }
            catch
            {
            }
            k = 1;
            //deletesuccess();
          savedb();
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            button1.Enabled = false;
         // timer1.Start();
           
        }
        
        private void SaveImageCapture1(System.Drawing.Image image)
        {
            File.Delete(Application.StartupPath + "\\ref.jpg");
            string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\", "*.jpg");
            int i55 = filePaths.Length;

            string filename1 = Application.StartupPath + "\\Ref.jpg";
            FileStream fstream1 = new FileStream(filename1, FileMode.Create);
            image.Save(fstream1, System.Drawing.Imaging.ImageFormat.Jpeg);
            fstream1.Close();
            string filename2 = Application.StartupPath + "\\Ref1.jpg";
            FileStream fstream2= new FileStream(filename2, FileMode.Create);
            image.Save(fstream2, System.Drawing.Imaging.ImageFormat.Jpeg);
            fstream2.Close();
            timer1.Stop();

        }
  
        SqlConnection con43 = new SqlConnection("server=.\\sqlexpress;integrated security=true;database=continuous_exam;");
        IBitmapCompare CompareBox;
        Hashtable ImageVsSimilarity = new Hashtable();
        double[] sindexes = null;
        int i;
        static string fname1, fname2;
        Bitmap img1, img2;

        int count1 = 0, count2 = 0;
        bool flag = true;
       Bitmap  img11, img22;

        private void timer2_Tick(object sender, EventArgs e)
        {
           
          //  fstream1.Close();
            timer1.Stop();
            timer2.Stop();
            timer3.Start();
          
            //if (textBox2.Text == textBox1.Text)
            //{
            //    //Draw the label for each face detected and recognized
            //    //savedb1();
               
            //  //  Thread.Sleep(2000);
            //    textBox3.Text = "Normal";
            //    con1.Open();
            //    SqlCommand cmd1 = new SqlCommand("delete from t1", con1);
            //    cmd1.ExecuteNonQuery();
            //    con1.Close();
            //}
            //else
            //{
            //    //MessageBox.Show("Wrong user");
            //    textBox3.Text = "Wrong";
            //    con1.Open();

            //    SqlCommand cmd1 = new SqlCommand("delete from t1", con1);
            //    cmd1.ExecuteNonQuery();
            //    con1.Close();
            //    con1.Open();

            //    SqlCommand cmd = new SqlCommand("insert into t1 values('yes')", con1);
            //    cmd.ExecuteNonQuery();
            //    con1.Close();
            //}
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            File.Delete(Application.StartupPath + "\\ref.jpg");
            string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\", "*.jpg");
            int i55 = filePaths.Length;

            string filename1 = Application.StartupPath + "\\Ref.jpg";
            // FileStream fstream1 = new FileStream(filename1, FileMode.Create);
            currentFrame.Save(filename1);
        timer1.Stop();
        // timer4.Start();
        }
        private void check()
        {
            count2 = 0;
            string img1_ref, img2_ref;
            img1 = new Bitmap(Image.FromFile(Application.StartupPath + "\\ref.jpg"));
            img2 = new Bitmap(Image.FromFile(Application.StartupPath + "\\ctestimg.jpg"));
           
            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {


                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {

                        img1_ref = img1.GetPixel(i, j).ToString();

                        img2_ref = img2.GetPixel(i, j).ToString();

                        if (img1_ref == img2_ref)
                        {

                            count2++;
                            flag = false;
                            break;

                        }
                        else
                            count1++;

                    }
                }

                int aaa = (img2.Width * 320) / 10;
                if (count2 < 40)
                {
                    try
                    {
                        //  MessageBox.Show("Wrong user");
                        con1.Open();

                        SqlCommand cmd1 = new SqlCommand("delete from t1", con1);
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                      
                        
                        ccou = ccou + 1;
                        if (ccou > 3)
                        {
                            con1.Open();

                            SqlCommand cmd = new SqlCommand("insert into t1 values('yes')", con1);
                            cmd.ExecuteNonQuery();
                            con1.Close();
                         Application.Exit();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    count1 = 0;
                    // MessageBox.Show("Normal User");
                    con1.Open();

                    SqlCommand cmd1 = new SqlCommand("delete from t1", con1);
                    cmd1.ExecuteNonQuery();
                    con1.Close();
                    con1.Open();

                    SqlCommand cmd = new SqlCommand("insert into t1 values('no')", con1);
                    cmd.ExecuteNonQuery();
                    con1.Close();
                }
            } 
Thread.Sleep(400);
       
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            //timer2.Stop();

          
            //SaveImageCapture1(pictureBox2.Image);
                


                string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\", "*.jpg");
                int i55 = filePaths.Length;


                  try
                {
                    File.Delete(Application.StartupPath+"\\ctestimg.jpg");
                    string filename1 = Application.StartupPath+"\\ctestimg.jpg";
                    //FileStream fstream1 = new FileStream(filename1, FileMode.Create);
                      currentFrame.Save(filename1);
                   // pictureBox2.Image.Save(fstream1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    
                }
                catch
                {
                }
   timer3.Stop();
              //  timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
       count2 = 0;
        string img1_ref, img2_ref;
       img1 = new Bitmap(Image.FromFile(Application.StartupPath + "\\ref.jpg"));
        img2 = new Bitmap(Image.FromFile(Application.StartupPath + "\\ctestimg.jpg"));
        //    count1 = 0;
        //    if (img11.Width == img22.Width && img11.Height == img22.Height)
        //    {
        //        for (int i = 0; i < img11.Width; i++)
        //        {
        //            for (int j = 0; j < img11.Height; j++)
        //            {

        //                img1_ref = img11.GetPixel(i, j).ToString();
        //                img2_ref = img22.GetPixel(i, j).ToString();

        //                if (img1_ref != img2_ref)
        //                {
        //                    count2++;
        //                    flag = false;
        //                    break;

        //                }
        //                count1++;

        //            }
        //        }
        if (img1.Width == img2.Width && img1.Height == img2.Height)
        {


            for (int i = 0; i < img1.Width; i++)
            {
                for (int j = 0; j < img1.Height; j++)
                {

                    img1_ref = img1.GetPixel(i, j).ToString();

                    img2_ref = img2.GetPixel(i, j).ToString();

                    if (img1_ref == img2_ref)
                    {

                        count2++;
                        flag = false;
                        break;

                    }
                    else
                        count1++;

                }
            }

            int aaa = (img2.Width * 320) / 10;
            if (count2 > 315)
            {
                try
                {
                  //  MessageBox.Show("Wrong user");
                    con1.Open();

                    SqlCommand cmd1 = new SqlCommand("delete from t1", con1);
                    cmd1.ExecuteNonQuery();
                    con1.Close();
                    con1.Open();

                    SqlCommand cmd = new SqlCommand("insert into t1 values('yes')", con1);
                    cmd.ExecuteNonQuery();
                    con1.Close();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                count1 = 0;
                // MessageBox.Show("Normal User");
                con1.Open();

                SqlCommand cmd1 = new SqlCommand("delete from t1", con1);
                cmd1.ExecuteNonQuery();
                con1.Close();
                con1.Open();

                SqlCommand cmd = new SqlCommand("insert into t1 values('no')", con1);
                cmd.ExecuteNonQuery();
                con1.Close();
            }
        }
        //        if (count1 > 1)
        //        {
        //            count1 = 0;
        //            // MessageBox.Show("Normal User");
        //            con1.Open();

        //            SqlCommand cmd1 = new SqlCommand("delete from t1", con1);
        //            cmd1.ExecuteNonQuery();
        //            con1.Close();
        //            con1.Open();

        //            SqlCommand cmd = new SqlCommand("insert into t1 values('no')", con1);
        //            cmd.ExecuteNonQuery();
        //            con1.Close();
        //        }
        //        else
        //        {
        //            if (count2 > 300)
        //            {
        //                // MessageBox.Show("Wrong user");
        //                con1.Open();

        //                SqlCommand cmd1 = new SqlCommand("delete from t1", con1);
        //                cmd1.ExecuteNonQuery();
        //                con1.Close();
        //                con1.Open();

        //                SqlCommand cmd = new SqlCommand("insert into t1 values('yes')", con1);
        //                cmd.ExecuteNonQuery();
        //                con1.Close();
        //            }
        //        }

        //    }
        //    else
        //    {


        //    }


        //    timer4.Stop();
        //    timer3.Start();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            check();
            timer5.Stop();
        }

    }
}