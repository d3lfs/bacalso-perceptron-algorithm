using LogicGatesPerceptron.Common;
using LogicGatesPerceptron.Utils;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace LogicGatesPerceptron
{
    public partial class MainForm : Form
    {
        int _x = -1;
        int _y = -1;
        bool mouseMove = false;
        
        Graphics _canvas;
        Pen _pen;
        Bitmap _bmp;
        Perceptron perceptron;

        public MainForm()
        {
            InitializeComponent();
            perceptron = new Perceptron(225, 0.001, 1, true);
            
            _bmp = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            _canvas = Graphics.FromImage(_bmp);
            _canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _canvas.Clear(Color.White);
            
            canvasContainer.Image = _bmp;
          
            _pen = new Pen(Color.Black, 35);
            _pen.StartCap = _pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void CanvasContainer_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMove = true;
            _x = e.X;
            _y = e.Y;
            canvasContainer.Cursor = Cursors.Cross;
        }

        private void CanvasContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMove && _x != -1 && _y != -1)
            {
                _canvas.DrawLine(_pen, new Point(_x, _y), e.Location);
                _x = e.X;
                _y = e.Y;
            }
            canvasContainer.Refresh();
        }

        private void CanvasContainer_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMove = false;
            _x = -1;
            _y = -1;
            canvasContainer.Cursor = Cursors.Default;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            pictureBox.Image = null;
        }

        private void ClearCanvas()
        {
            canvasContainer.Image = null;
            _bmp = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            _canvas = Graphics.FromImage(_bmp);
            canvasContainer.Image = _bmp;
            _canvas.Clear(Color.White);
        }

        private void predictBtn_Click(object sender, EventArgs e)
        {
            ProcessImage();
        }
        
        private void ProcessImage()
        {
            var ms = new MemoryStream();
            var bmp = new Bitmap(canvasContainer.Width, canvasContainer.Height);

            canvasContainer.DrawToBitmap(bmp, new Rectangle(0, 0, canvasContainer.Width, canvasContainer.Height));
            bmp.Save(ms, ImageFormat.Png);
            

            var image = DIP.ResizeImage(bmp, 15, 15);
            image.Save(Path.Combine(AppContext.BaseDirectory, "images", $"{TimeStamp.GetUTCNow()}-{epochsInput.Text}.png"), ImageFormat.Png);

            pictureBox.Image = image;
        }

        private void Train()
        {
            var images = Directory.GetFiles(Path.Combine(AppContext.BaseDirectory, "images"), "*.png");
            for (int i = 0; i < Convert.ToInt32(epochsInput.Text); i++)
            {
                for (int j = 0; j < images.Length; j++)
                {
                    var x = new MemoryStream();
                    var image = Image.FromFile(images[j]);
                    image.Save(x, ImageFormat.Png);
                    
                    var y = int.Parse(Path.GetFileNameWithoutExtension(images[j]).Last().ToString());

                    perceptron.SetInput(DIP.GetBits(x));
                    perceptron.SetDesiredOutput(y);
                    perceptron.Learn();
                }

                if (perceptron.TotalError < 0.05)
                    break;
            }

            predictedOutput.Text = perceptron.TotalError.ToString();
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            Train();
        }
    }
}