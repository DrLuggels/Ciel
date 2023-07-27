#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Media;
//using System.Threading;
//Desing
using FontAwesome.Sharp;
//Speech
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Documents;
using AudioSwitcher.AudioApi.CoreAudio;
using System.IO;

#endregion



namespace Ciel
{
    public partial class Form1 : Form
    {
        #region Speech
        SpeechRecognitionEngine h = new SpeechRecognitionEngine();
        SpeechSynthesizer s = new SpeechSynthesizer();
        SpeechSynthesizer synth = new SpeechSynthesizer();
        CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        #endregion

        #region Desing
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        #endregion


        public Form1()
        {
            InitializeComponent();



            #region InitializeComponent Form Desing
            //constructor
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            OpenChildForm(new NewFolder1.VoiceAsisten());
            #endregion
        }



        #region ARGB Color
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        #endregion



        //Methods Form Desing

        #region ActivateButton
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37,36,81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor= color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left Boarder Button 
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location= new Point(0,currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //iconCurrentChildForm
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                lbtTitleChildform.Text= currentBtn.Text;
                //lbtTitleChildform.ForeColor = color;
            }
        }
        #endregion

        #region DiasableButton
        private void DisableButton()
        {
            if(currentBtn != null)
            {

                currentBtn.BackColor = Color.FromArgb(49, 48, 104);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }
        #endregion

        #region Form in Form
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion


        
        private void Form1_Load(object sender, EventArgs e)
        {

            
                Choices commands = new Choices();
                string path = Directory.GetCurrentDirectory()+ "\\Befehle.txt";
                commands.Add(File.ReadAllLines(path));

                GrammarBuilder gBuilder = new GrammarBuilder();
                gBuilder.Append(commands);

                Grammar grammar = new Grammar(gBuilder);

                h.LoadGrammar(grammar);
                h.SetInputToDefaultAudioDevice();
                h.SpeechRecognized += recEngine_SpeechRecognized;

                h.RecognizeAsync(RecognizeMode.Multiple);
                s.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
                s.SpeakAsync("wie kann ich dir helfen");
        }

        #region Vorberreitung (switch case)

        Boolean hören = true; //hören


        #endregion


        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            string modus = e.Result.Text;
            if (modus == "sprech")
            {
                hören = true;
            }

            if (modus == "still")
            {
                hören = false;
            }

            if (hören == true)
            {


                switch (e.Result.Text)
                {

                    case "hallo":
                        s.SpeakAsync("Guten Tag");
                        break;

                    case "wie geht es dir":
                        s.SpeakAsync("ich habe keinerlei Gefühle, aber hir meine Auslastung");
                        iconButton3.PerformClick();  //Clickt Botton 
                        break;

                    case "statusbericht":
                        s.SpeakAsync("Meine Systembelastung beträgt wobei mein Ramm und meine die überschritten hat");
                        break;


                    case "shutdown":
                        s.SpeakAsync("wie sie wünschen");
                        break;

                    case "welcher tag ist heute":
                        s.SpeakAsync("heute ist der " + DateTime.Now.ToString("d"));
                        break;

                    case "wie spät ist es":
                        s.SpeakAsync("es ist " + DateTime.Now.ToString("HH:mm:ss"));
                        break;

                    case "maximiren":
                        this.WindowState = FormWindowState.Maximized;
                        s.SpeakAsync("maximiert");
                        break;

                    case "minnimiren":
                        this.WindowState = FormWindowState.Minimized;
                        s.SpeakAsync("minnimiert");
                        break;

                    case "normal":
                        this.WindowState = FormWindowState.Normal;
                        s.SpeakAsync("normal");
                        break;

                    case "close":
                        s.SpeakAsync("tschau");
                        this.Close();
                        break;

                    case "mute":
                        defaultPlaybackDevice.Mute(true);
                        break;

                    case "unmute":
                        defaultPlaybackDevice.Mute(false);
                        break;

                    
                }  
            }
        }

        

        #region Button
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new NewFolder1.Explorer());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new NewFolder1.Security());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new Forms.perf()); //ka warum der anders heißen muss
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new NewFolder1.Clipboard());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new NewFolder1.Settings());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Reset();
        }

        #endregion

        #region Reset
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lbtTitleChildform.Text = "Home";
            OpenChildForm(new NewFolder1.VoiceAsisten());
            //lbtTitleChildform.ForeColor = Color.Gainsboro;
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #region Drag Form
        // Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Titelbar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
