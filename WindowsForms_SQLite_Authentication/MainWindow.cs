using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_SQLite_Authentication
{
    public partial class MainWindow : Form
    {
        private int direction = 0;
        private int score = 1;
        private Timer gameLoop = new Timer();
        private Random random = new Random();
        private Graphics graphics;
        private Snake snake;
        private Food food;

        public MainWindow()
        {
            InitializeComponent();
            snake = new Snake();
            food = new Food(random);
            gameLoop.Interval = 75;

            gameLoop.Tick += Update;
        }
        string username;
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();

            username = login.usernames;
            lblWellcome.Text = "Wellcome, " + username + " !";
        }
        

        
        private void Update(object sender, EventArgs e)
        {
            this.Text = string.Format("Snake - Score: {0}", score);
            snake.Move(direction);
            for (int i = 1; i < snake.Body.Length; i++)

                if (snake.Body[0].IntersectsWith(snake.Body[i]))
                    Restart();
            if (snake.Body[0].X < 0 || snake.Body[0].X > 290)
                Restart();
            if (snake.Body[0].Y < 0 || snake.Body[0].Y > 190)
                Restart();
            if (snake.Body[0].IntersectsWith(food.piece))
            {
                score++;
                snake.Grow();
                food.Generate(random);
            }
            this.Invalidate();

        }

        private void Restart()
        {
            gameLoop.Stop();
            graphics.Clear(SystemColors.Control);
            snake = new Snake();
            food = new Food(random);
            direction = 0;
            score = 1;
            lblStart.Visible = true;
            lblWellcome.Visible = true;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
                {
                    case Keys.Enter:
                        if (lblStart.Visible && lblWellcome.Visible)
                        {
                            lblStart.Visible = false;
                            lblWellcome.Visible = false;
                            gameLoop.Start();
                        }

                        break;
                    case Keys.Space:
                        if (!lblStart.Visible)
                        {
                            gameLoop.Enabled = (gameLoop.Enabled) ? false : true;
                            MessageBox.Show("Pause");
                        }
                        break;
                    case Keys.Right:
                        if (direction != 2)
                            direction = 0;
                        break;
                    case Keys.Down:
                        if (direction != 3)
                            direction = 1;
                        break;
                    case Keys.Left:
                        if (direction != 0)
                            direction = 2;
                        break;
                    case Keys.Up:
                        if (direction != 1)
                            direction = 3;
                        break;
                }
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            snake.Draw(graphics);
            food.Draw(graphics);
        }
    }
}
