using System.Runtime.InteropServices;

namespace Triangles
{
    public partial class Form1 : Form
    {
        Graphics g;
        public double ABlength;
        public double AClength;
        public double BClength;

        public double A;
        public double B;
        public double C;

        public double area;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
           
            
        }

        private double radiansToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }
        private void pointMoved()
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 5f);
            g.DrawLine(pen, panel1.Location, panel2.Location);
            g.DrawLine(pen, panel1.Location, panel3.Location);
            g.DrawLine(pen, panel2.Location, panel3.Location);

            ABlength = Math.Round((Math.Sqrt(Math.Pow((double)panel1.Location.X - (double)panel2.Location.X, 2) + Math.Pow((double)panel1.Location.Y - (double)panel2.Location.Y, 2))) / 10, 2);
            label7.Text = "AB: " + ABlength.ToString();

            AClength = Math.Round((Math.Sqrt(Math.Pow((double)panel1.Location.X - (double)panel3.Location.X, 2) + Math.Pow((double)panel1.Location.Y - (double)panel3.Location.Y , 2))) / 10, 2);
            label8.Text = "AC: " + AClength.ToString();

            BClength = Math.Round(Math.Sqrt((Math.Pow((double)panel2.Location.X - (double)panel3.Location.X, 2) + Math.Pow((double)panel2.Location.Y - (double)panel3.Location.Y / 10, 2))) / 10, 2);
            label9.Text = "AC: " + BClength.ToString();

            A = Math.Round(radiansToDegrees(Math.Acos((Math.Pow(AClength, 2) + Math.Pow(ABlength, 2) - Math.Pow(BClength, 2)) / (2 * AClength * BClength))), 2);
            label1.Text = "A: " + A.ToString();

            B = Math.Round(radiansToDegrees(Math.Acos((Math.Pow(BClength, 2) + Math.Pow(ABlength, 2) - Math.Pow(AClength, 2)) / (2 * BClength * ABlength))), 2);
            label2.Text = "B: " + B.ToString();

            C = 180 - (A + B);
            label6.Text = "C: " + C.ToString();

            area = Math.Round(0.5 * BClength * AClength * radiansToDegrees(Math.Sin(C)), 2);
            label10.Text = "Area: " + area.ToString();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private const int SYSTEMCOMMAND = 0x112;
        private const int SC_DRAGMOVE = 0xF012;

        // This function moves the MainForm.
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(panel1.Handle, SYSTEMCOMMAND, SC_DRAGMOVE, 0);
            pointMoved();
            label3.Location = new Point(panel1.Location.X, panel1.Location.Y - 18);
        }

        // This function only moves the panel.
        private void panel1_MouseMove_object(object sender, MouseEventArgs e)
        {
            ReleaseCapture();

            Panel panel = sender as Panel;
            SendMessage(panel.Handle, SYSTEMCOMMAND, SC_DRAGMOVE, 0);
            label3.Location = new Point(panel1.Location.X, panel1.Location.Y - 18);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(panel2.Handle, SYSTEMCOMMAND, SC_DRAGMOVE, 0);
            pointMoved();
            label4.Location = new Point(panel2.Location.X - 5, panel2.Location.Y + 13);
        }

        // This function only moves the panel.
        private void panel2_MouseMove_object(object sender, MouseEventArgs e)
        {
            ReleaseCapture();

            Panel panel = sender as Panel;
            SendMessage(panel.Handle, SYSTEMCOMMAND, SC_DRAGMOVE, 0);
            label4.Location = new Point(panel2.Location.X - 5, panel2.Location.Y + 13);
        }
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(panel3.Handle, SYSTEMCOMMAND, SC_DRAGMOVE, 0);
            pointMoved();
            label5.Location = new Point(panel3.Location.X, panel3.Location.Y + 13);
        }

        // This function only moves the panel.
        private void panel3_MouseMove_object(object sender, MouseEventArgs e)
        {
            ReleaseCapture();

            Panel panel = sender as Panel;
            SendMessage(panel.Handle, SYSTEMCOMMAND, SC_DRAGMOVE, 0);
            pointMoved();
            label5.Location = new Point(panel3.Location.X, panel3.Location.Y + 13);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel3_MouseMove_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(panel3.Handle, SYSTEMCOMMAND, SC_DRAGMOVE, 0);
            pointMoved();
            label5.Location = new Point(panel3.Location.X, panel3.Location.Y + 13);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}