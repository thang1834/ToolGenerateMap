using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Button> ButtonList = new List<Button>();
        List<int> ClickCount = new List<int>();
        List<int> Map = new List<int>();
        List<List<int>> MapRow = new List<List<int>>();
        bool isMouseClicked = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            int width = 64;
            int heigth = 36;
            int sz = 23;
            flowLayoutPanel1.Size = new Size((sz) * width + 5, (sz) * heigth);
            for (int i = 0; i < width * heigth; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(sz, sz);
                btn.Margin = new Padding(0);
                btn.BackColor = Color.White;
                //btn.Text = i.ToString();
                //flowLayoutPanel1.MouseDown += (sender1, e1) =>
                //{
                //    isMouseClicked = true;
                //};
                //flowLayoutPanel1.MouseUp += (sender1, e1) =>
                //{
                //    isMouseClicked = false;
                //};
                btn.MouseHover += (sender1, e1) =>
                {
                    ChangeColor(btn);
                };
                flowLayoutPanel1.Controls.Add(btn);
                ButtonList.Add(btn);
                ClickCount.Add(0);
            }
        }

        void ChangeColor(Button btn)
        {
            int index = ButtonList.IndexOf(btn);
            int Count = ClickCount[index];
            switch (Count % 5)
            {
                // duong di
                case 0:
                    btn.Text = "1";
                    btn.BackColor = Color.Green;
                    break;
                // start
                case 1:
                    btn.Text = "-1";
                    btn.BackColor = Color.Yellow;
                    break;
                // stop
                case 2:
                    btn.Text = "2";
                    btn.BackColor = Color.Red;
                    break;
                // reset
                case 3:
                    btn.Text = "3";
                    btn.BackColor = Color.Gray;
                    break;
                case 4:
                    btn.Text = "";
                    btn.BackColor = Color.White;
                    break;
            }
            ClickCount[index]++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = @"int[,] array = new int[,]
{";
            int count = 0;
            for (int i = 0; i < ButtonList.Count; i++)
            {
                Button btn = ButtonList[i];
                switch (btn.Text)
                {
                    // duong di
                    case "1":
                        Map.Add(1);
                        break;
                    // start
                    case "-1":
                        Map.Add(-1);
                        break;
                    // stop
                    case "2":
                        Map.Add(2);
                        break;
                    // reset
                    case "3":
                        Map.Add(3);
                        break;
                    case "":
                        Map.Add(0);
                        break;
                }
            }
            for (int i = 0; i < 36; i++)
            {
                MapRow.Add(Map.GetRange(count, 64));
                count += 64;
                text += "{" + String.Join(",", MapRow[i]) + "},\n";
            }
            text = text.Substring(0, text.Length - 2) + "\n};";
            Clipboard.SetText(text);
            MessageBox.Show("xong roi =))))");
        }
    }
}