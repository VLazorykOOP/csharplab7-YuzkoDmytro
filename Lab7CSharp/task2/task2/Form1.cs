using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap originalImage = new Bitmap(pictureBox1.Image);
                Bitmap grayImage = ConvertToGrayScale(originalImage);
                pictureBox1.Image = grayImage;
            }
            else
            {
                MessageBox.Show("Спочатку відкрийте зображення.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Bitmap Image|*.bmp";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                }
            }
            else
            {
                MessageBox.Show("Зображення не збережено.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private Bitmap ConvertToGrayScale(Bitmap originalImage)
        {
            Bitmap grayImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int i = 0; i < originalImage.Width; i++)
            {
                for (int j = 0; j < originalImage.Height; j++)
                {
                    Color pixelColor = originalImage.GetPixel(i, j);
                    int grayValue = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));
                    Color newColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    grayImage.SetPixel(i, j, newColor);
                }
            }

            return grayImage;
        }
    }
}