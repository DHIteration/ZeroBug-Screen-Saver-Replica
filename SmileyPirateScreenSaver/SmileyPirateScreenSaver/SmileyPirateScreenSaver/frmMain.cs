using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using SmileyPirate;


namespace SmileyPirateScreenSaver
{

    public partial class frmMain : Form
    {

        System.OperatingSystem osInfo = System.Environment.OSVersion;

        [DllImport("user32.dll")]
	    static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
	 
	    [DllImport("user32.dll")]
	    static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
	 
	    [DllImport("user32.dll", SetLastError = true)]
	    static extern int GetWindowLong(IntPtr hWnd, int nIndex);
	 
	    [DllImport("user32.dll")]
	    static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        //determines if we are in preview mode.
        private bool previewMode = false;

        //Determines weather image grows and shrinks.
        private bool InflateDeflate = false;

        //Determines weather image is translucent
        private bool Ghost = false;

        //Used to close screensaver if mouse moves.
        private Point mouseLocation;
        private Point startPosition;

        //Holds the current Image
        private Image curImage;

        //Holds our Balls Info.
        Ball[] balls = new Ball[101];


        int BallCount = 0; //Ball Count is nulled.
        int BallSpeed = 15; //Ballspeed


        //PacMans X Y Loc.
        private int X = 0;
        private int Y = 0;

        //Setup our Registry object.
        RegistryKey key = null;
        public static RegistryKey key_ = null;

        //Used to get Wallpaper.
        RegistryKey key2 = null;
        public static RegistryKey key2_ = null;




        public frmMain(Rectangle Bounds, IntPtr PreviewWndHandle)
        {
           
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Bounds = Bounds;

            this.Width = Bounds.Width;
            this.Height = Bounds.Height;

            if (PreviewWndHandle != IntPtr.Zero)
            {
                // Set the preview window as the parent of this window
                SetParent(this.Handle, PreviewWndHandle);

                // Make this a child window so it will close when the parent dialog closes
                // GWL_STYLE = -16, WS_CHILD = 0x40000000
                SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

                // Place our window inside the parent
                Rectangle ParentRect;
                GetClientRect(PreviewWndHandle, out ParentRect);
                Size = ParentRect.Size;
                Location = new Point(0, 0);

                previewMode = true;

            }


            if (previewMode == true)
            {
                this.TransparencyKey = Color.Empty;
                this.BackColor = Color.Black;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                key2 = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
                key2_ = key2;

                if (key2 != null)
                {
                    string WallPaperLocation = (string)key2.GetValue("Wallpaper", "None");
                    Image Background = Image.FromFile(WallPaperLocation);
                    this.BackgroundImage = Background;
                }
            }
            else
            {
                this.TransparencyKey = Color.Gainsboro;
                this.BackColor = Color.Gainsboro;
            }


            curImage = SmileyPirate.Properties.Resources.Double; //Set our Image.
            ImageAnimator.Animate(curImage, new EventHandler(this.OnFrameChanged)); //Animate the gif.
            Application.DoEvents();

            key = Registry.CurrentUser.OpenSubKey("Software\\HackersScreenSaver", true);
            key_ = key;

            if (key == null)
            {
                //Create or Registry values.
                Registry.CurrentUser.CreateSubKey("Software\\HackersScreenSaver");
                key = Registry.CurrentUser.OpenSubKey("Software\\HackersScreenSaver", true);
                key_ = key;

                //Save our data.
                key.SetValue("amount", 50);
                key.SetValue("speed", 15);
                key.SetValue("ghost", false);
                key.SetValue("inflatedeflate", false);
            }

            LoadSettings();


            if (isXP_OS() == true)
            {
                this.TransparencyKey = Color.Empty;
                this.BackColor = Color.Black;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                key2 = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
                key2_ = key2;

                if (key2 != null)
                {
                    string WallPaperLocation = (string)key2.GetValue("Wallpaper", "None");
                    Image Background = Image.FromFile(WallPaperLocation);
                    this.BackgroundImage = Background;
                }

                tmrXP.Enabled = true;
            }

            if (Ghost == true && previewMode == false)
                this.Opacity = 0.50;


            AddSmiley(BallCount);  //Add our Smiley Balls.

            startPosition = Cursor.Position;
        }



        private void AddSmiley(int cNumber)
        {
            Random random = new Random();

            for (int z = 0; z < cNumber + 1; z++)
                balls[z] = new Ball();

 

            for (int i = 0; i < cNumber + 1; i++)
            {
                int randX = random.Next(0, this.Bounds.Width - random.Next(0, this.Bounds.Width / 2));
                int randY = random.Next(0, this.Bounds.Height - random.Next(0, this.Bounds.Height / 2));
                int randTag = random.Next(0, 4);
                int randRadius = random.Next(40, 76);
                int randGrow = random.Next(0, 2);

                if (randGrow == 0)
                {
                    balls[i].Grow = false;
                }
                else
                {
                    balls[i].Grow = true;
                }

                balls[i].Radius = randRadius; //curImage.Height;
                balls[i].X = randX;
                balls[i].Y = randY;
                balls[i].Vx = 10; //Velocity X
                balls[i].Vy = 10; //Velocity Y
                balls[i].Mass = balls[i].Radius;
                balls[i].Tag = randTag;

                Application.DoEvents();
            }
        }



        private void OnFrameChanged(object o, EventArgs e)
        {

            this.Invalidate();

            if (!mouseLocation.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - startPosition.X) > 5 || Math.Abs(mouseLocation.Y - startPosition.Y) > 5)
                {
                    if (!previewMode)
                        Application.Exit();
                }
            }

            // Update current mouse location
            mouseLocation = Cursor.Position;

        }


        //Updates the amount of balls on the screen.
        private void UpdateBalls(int BallCnt)
        {
            BallCount = BallCnt;
            AddSmiley(BallCnt);
        }



        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            
            Pen BlackPen = new Pen(Color.Black, 4); //Outline size 4

            for (int i = 0; i < BallCount; i++)
            {
                
                switch (balls[i].Tag)
                {
                    case 0: //Moving Left and Up

                        balls[i].X -= BallSpeed;
                        balls[i].Y -= BallSpeed;

                        if (balls[i].X <= 0)
                        {
                            balls[i].X += BallSpeed;
                            balls[i].Y -= BallSpeed;
                            balls[i].Vx += balls[i].Vx;
                            balls[i].Tag = 1; //Touched Left Side.. Move Right and Up.
                        }
                        else if (balls[i].Y <= 0)
                        {
                            balls[i].X -= BallSpeed;
                            balls[i].Y += BallSpeed;
                            balls[i].Vy += balls[i].Vy;
                            balls[i].Tag = 2; //Touched Top.. Move Down and Left.
                        }
                        
                        break;


                    case 1: //Moving Right and Up

                        balls[i].X += BallSpeed;
                        balls[i].Y -= BallSpeed;

                        if (balls[i].X >= (this.Bounds.Width - curImage.Width))
                        {
                            balls[i].X -= BallSpeed;
                            balls[i].Y -= BallSpeed;
                            balls[i].Vx += balls[i].Vx;
                            balls[i].Tag = 0; //Touched Right Side.. Move Up and Left.
                        }
                        else if (balls[i].Y <= 0)
                        {
                            balls[i].X += BallSpeed;
                            balls[i].Y += BallSpeed;
                            balls[i].Vy += balls[i].Vy;
                            balls[i].Tag = 3; //Touched Top.. Move Right and Down.
                        }

                        break;

                    case 2: //Moving Down and Left
                        
                        balls[i].X -= BallSpeed;
                        balls[i].Y += BallSpeed;


                        if (balls[i].X <= 0)
                        {
                            balls[i].X += BallSpeed;
                            balls[i].Y += BallSpeed;
                            balls[i].Vx += balls[i].Vx;
                            balls[i].Tag = 3; //Touched Left Side.. Move Right and Down.
                        }
                        else if ((balls[i].Y + curImage.Height) >= this.Bounds.Height)
                        {
                            balls[i].X -= BallSpeed;
                            balls[i].Y -= BallSpeed;
                            balls[i].Vy += balls[i].Vy;
                            balls[i].Tag = 0; //Touched Bottom.. Move Up and Left.
                        }

                        break;

                    case 3: //Moving Down and Right

                        balls[i].X += BallSpeed;
                        balls[i].Y += BallSpeed;


                        if (balls[i].X >= (this.Bounds.Width - curImage.Width))
                        {
                            balls[i].X -= BallSpeed;
                            balls[i].Y += BallSpeed;
                            balls[i].Vx += balls[i].Vx;
                            balls[i].Tag = 2; //Touched Right side.. Move Down and Up.
                        }
                        else if ((balls[i].Y + curImage.Height) >= this.Bounds.Height)
                        {
                            balls[i].X += BallSpeed;
                            balls[i].Y -= BallSpeed;
                            balls[i].Vy += balls[i].Vy;
                            balls[i].Tag = 1; //Touched Bottom.. Move Right and Up.
                        }

                        break;

                    default:

                        balls[i].X -= BallSpeed;
                        balls[i].Y -= BallSpeed;
                        balls[i].Tag = 0;
                        break;
                }
                


                
                //Uncomment to enable Collision Detection.
                for (int r = 0; r < BallCount; r++)
                {
                    Rectangle r1 = getBoundingRect(balls[r].X, balls[r].Y, curImage);

                    for (int k = 0; k < BallCount; k++)
                    {
                        if (r != k)
                        {
                            Rectangle r2 = getBoundingRect(balls[k].X, balls[k].Y, curImage);

                            if (r1.IntersectsWith(r2))
                            {
                                //Seperate Balls

                                //********************************************Newely Added*****************************************
                                //********************************************Removed if Needed************************************

                                /*
                                switch (balls[r].Tag)
                                {

                                    case 0: //Moving Left and Up
                                        balls[r].X += BallSpeed;
                                        balls[r].Y += BallSpeed;
                                        balls[r].Vy += balls[r].Vy;
                                        balls[r].Tag = 3; //Touched Top.. Move Right and Down.
                                    
                                        break;


                                    case 1: //Moving Right and Up
                                        balls[r].X -= BallSpeed;
                                        balls[r].Y += BallSpeed;
                                        balls[r].Vy += balls[r].Vy;
                                        balls[r].Tag = 2; //Touched Top.. Move Down and Left.
                                       

                                        break;

                                    case 2: //Moving Down and Left
                                        balls[r].X += BallSpeed;
                                        balls[r].Y -= BallSpeed;
                                        balls[r].Vx += balls[r].Vx;
                                        balls[r].Tag = 1; //Touched Left Side.. Move Right and Up.

                                        break;

                                    case 3: //Moving Down and Right
                                        balls[r].X -= BallSpeed;
                                        balls[r].Y -= BallSpeed;
                                        balls[r].Vy += balls[r].Vy;
                                        balls[r].Tag = 0; //Touched Bottom.. Move Up and Left.
                                      
                                        break;

                                    default:

                                        balls[r].X -= BallSpeed;
                                        balls[r].Y -= BallSpeed;
                                        balls[r].Tag = 0;
                                        break;



                                }


                                switch (balls[k].Tag)
                                {

                                    case 0: //Moving Left and Up
                                        balls[k].X += BallSpeed;
                                        balls[k].Y += BallSpeed;
                                        balls[k].Vy += balls[k].Vy;
                                        balls[k].Tag = 3; //Touched Top.. Move Right and Down.

                                        break;


                                    case 1: //Moving Right and Up
                                        balls[k].X -= BallSpeed;
                                        balls[k].Y += BallSpeed;
                                        balls[k].Vy += balls[k].Vy;
                                        balls[k].Tag = 2; //Touched Top.. Move Down and Left.


                                        break;

                                    case 2: //Moving Down and Left
                                        balls[k].X += BallSpeed;
                                        balls[k].Y -= BallSpeed;
                                        balls[k].Vx += balls[k].Vx;
                                        balls[k].Tag = 1; //Touched Left Side.. Move Right and Up.

                                        break;

                                    case 3: //Moving Down and Right
                                        balls[k].X -= BallSpeed;
                                        balls[k].Y -= BallSpeed;
                                        balls[k].Vy += balls[k].Vy;
                                        balls[k].Tag = 0; //Touched Bottom.. Move Up and Left.

                                        break;

                                    default:

                                        balls[k].X -= BallSpeed;
                                        balls[k].Y -= BallSpeed;
                                        balls[k].Tag = 0;
                                        break;



                                }


                                */


                                //**************************************************************************************************

                            }
                        }
                    }
                }
                



                if (balls[i].Grow == true)
                {
                    balls[i].Radius += 1;

                    if (balls[i].Radius >= 75)
                        balls[i].Grow = false;
                }
                else
                {
                    balls[i].Radius -= 1;

                    if (balls[i].Radius <= 25)
                        balls[i].Grow = true;
                }

                ImageAnimator.UpdateFrames(); //Animated Balls next frame.

                if(previewMode == true)
                {
                    e.Graphics.DrawEllipse(BlackPen, (int)balls[i].X, (int)balls[i].Y, 15, 15); //Draw Outline
                    e.Graphics.DrawImage(curImage, (int)balls[i].X, (int)balls[i].Y, 15, 15); //Draw preview Ball.
                }
                else if (InflateDeflate == true)
                {
                    e.Graphics.DrawEllipse(BlackPen, (int)balls[i].X, (int)balls[i].Y, (int)balls[i].Radius, (int)balls[i].Radius); //Draw Outline
                    e.Graphics.DrawImage(curImage, (int)balls[i].X, (int)balls[i].Y, (int)balls[i].Radius, (int)balls[i].Radius); //Draw growing shrinking Ball.
                }
                else
                {
                    e.Graphics.DrawEllipse(BlackPen, (int)balls[i].X, (int)balls[i].Y, curImage.Width, curImage.Height); //Draw Outline
                    e.Graphics.DrawImageUnscaled(curImage, (int)balls[i].X, (int)balls[i].Y); //Draw the Ball.
                }
                
            }

            e.Dispose();
            BlackPen.Dispose();
        }




        //Uncomment to enable ball collision detection.
        private Rectangle getBoundingRect(double xx, double yy, Image image)
        {
            double ballHeight = image.Height + 5;
            double ballWidth =  image.Width + 5;

            double x = xx - ballWidth / 2;
            double y = yy - ballHeight / 2;

            double a = x;
            double b = y;

            return new Rectangle((int)a, (int)b, (int)ballHeight, (int)ballWidth);
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!previewMode)
            {
                Cursor.Hide();
                //TopMost = true;
            }
        }



        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            curImage.Dispose();
            GC.Collect();

        }


        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (previewMode == false)
	            Application.Exit();
        }




        private void frmMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (previewMode == false)
                Application.Exit();
        }



        private void LoadSettings()
        {
            if (key == null)
            {
                BallCount = 50;
                BallSpeed = 15;
                Ghost = false;
                InflateDeflate = false;
            }
            else
            {
                BallCount = (int)key.GetValue("amount", 50);
                BallSpeed = (int)key.GetValue("speed", 15);


                bool a;
                Boolean.TryParse((((String)key_.GetValue("ghost", "False"))), out a);
                Ghost = a;

                bool b;
                Boolean.TryParse((((String)key_.GetValue("inflatedeflate", "False"))), out b);
                InflateDeflate = b;

            }

        }




        private bool isXP_OS()
        {

            //MessageBox.Show("Platform -" + osInfo.Platform + "  VerMaj - " + osInfo.Version.Major + "  VerMin - " + osInfo.Version.Minor);

            if (osInfo.Platform == System.PlatformID.Win32NT)
            {
                if (osInfo.Version.Major == 5)
                {
                    if (osInfo.Version.Minor != 0)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }




        private void tmrXP_Tick(object sender, EventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - startPosition.X) > 5 || Math.Abs(mouseLocation.Y - startPosition.Y) > 5)
                {
                    if (!previewMode)
                        Application.Exit();
                }
            }

            // Update current mouse location
            mouseLocation = Cursor.Position;
        }




    }



}
