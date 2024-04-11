namespace task3
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private Graphics graphics;

        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shape[] shapes = new Shape[5]; // ����� ��� ��������� ��'���� �����

            // ���������� ����� ��������
            for (int i = 0; i < shapes.Length; i++)
            {
                int x = random.Next(10, pictureBox1.Width - 50); // ��������� ���������� X
                int y = random.Next(10, pictureBox1.Height - 50); // ��������� ���������� Y
                int size = random.Next(20, 100); // ���������� �����

                switch (random.Next(4)) // ��������� ������� ��� ������
                {
                    case 0:
                        shapes[i] = new Square(x, y, size);
                        break;
                    case 1:
                        shapes[i] = new Rectangle(x, y, size * 2, size);
                        break;
                    case 2:
                        shapes[i] = new Ellipse(x, y, size * 2, size);
                        break;
                    case 3:
                        shapes[i] = new Rhombus(x, y, size * 2, size);
                        break;
                }
            }

            // ������� ������ �� pictureBox
            graphics.Clear(Color.White);
            foreach (Shape shape in shapes)
            {
                shape.Draw(graphics);
            }
        }

        // ������� ���� ������
        public abstract class Shape
        {
            protected int x, y, width, height;

            public Shape(int x, int y, int width, int height)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
            }

            public abstract void Draw(Graphics graphics); // ³��������� ����� ��� ���������
        }

        // �������� ���� �������
        public class Square : Shape
        {
            public Square(int x, int y, int size) : base(x, y, size, size) { }

            public override void Draw(Graphics graphics)
            {
                using (Pen pen = new Pen(Color.Black))
                {
                    graphics.DrawRectangle(pen, x, y, width, height);
                }
            }
        }

        // �������� ���� �����������
        public class Rectangle : Shape
        {
            public Rectangle(int x, int y, int width, int height) : base(x, y, width, height) { }

            public override void Draw(Graphics graphics)
            {
                using (Pen pen = new Pen(Color.Black))
                {
                    graphics.DrawRectangle(pen, x, y, width, height);
                }
            }
        }

        // �������� ���� ����
        public class Ellipse : Shape
        {
            public Ellipse(int x, int y, int width, int height) : base(x, y, width, height) { }

            public override void Draw(Graphics graphics)
            {
                using (Pen pen = new Pen(Color.Black))
                {
                    graphics.DrawEllipse(pen, x, y, width, height);
                }
            }
        }

        // �������� ���� ����
        public class Rhombus : Shape
        {
            public Rhombus(int x, int y, int width, int height) : base(x, y, width, height) { }

            public override void Draw(Graphics graphics)
            {
                Point[] points = {
                    new Point(x + width / 2, y),
                    new Point(x + width, y + height / 2),
                    new Point(x + width / 2, y + height),
                    new Point(x, y + height / 2)
                };

                using (Pen pen = new Pen(Color.Black))
                {
                    graphics.DrawPolygon(pen, points);
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
