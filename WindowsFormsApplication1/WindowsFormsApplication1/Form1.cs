using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<string> location = new List<string>();
        Dictionary<string, int> locationCount = new Dictionary<string, int>();
        Dictionary<string, double> locationPercent = new Dictionary<string, double>();
        int totalCount = 0;
        int labelPan1X = 0;
        int labelPan1Y = 0;
        int statLabelPanX = 0;
        int statLabelPanY = 0;
        int graphLabelPanX = 0;
        int graphLabelPanY = 0;
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(location.Contains(textBox1.Text))
            {
                int count;
                string currentKey;
                for(int x = 0;x < locationCount.Count;x++)
                {
                    var item = locationCount.ElementAt(x);
                    if(textBox1.Text == item.Key)
                    {
                        currentKey = item.Key;
                        count = item.Value;
                        count++;
                        locationCount[currentKey] = count;
                    }
                }
                panel3.Controls.Clear();
                panel4.Controls.Clear();
                statLabelPanY = 0;
                foreach (var loc in locationCount)
                {
                    Label statLocLabel = new Label();
                    Label statCountLabel = new Label();
                    statLocLabel.Text = loc.Key;
                    statLocLabel.ForeColor = Color.White;
                    statLocLabel.Location = new Point(statLabelPanX, statLabelPanY);
                    statCountLabel.Text = loc.Value.ToString();
                    statCountLabel.ForeColor = Color.White;
                    statCountLabel.Location = new Point(statLabelPanX, statLabelPanY);
                    statLabelPanY += 21;
                    panel3.Controls.Add(statLocLabel);
                    panel4.Controls.Add(statCountLabel);
                }
                totalCount = 0;
                foreach (var loc in locationCount)
                {
                    totalCount += loc.Value;
                }
                label8.Text = totalCount.ToString();
                locationPercent.Clear();
                for (int x = 0; x < locationCount.Count; x++)
                {
                    double percent = 0;
                    var item = locationCount.ElementAt(x);
                    percent = item.Value * 100 / totalCount;
                    locationPercent.Add(item.Key, Math.Round(percent, 2));
                }
                panel5.Controls.Clear();
                panel6.Controls.Clear();
                panel7.Controls.Clear();
                graphLabelPanY = 0;
                foreach (var loc in locationPercent)
                {
                    Label graphLocName = new Label();
                    Label graphLocPercent = new Label();
                    PictureBox graphPicBox = new PictureBox();
                    graphLocName.Text = loc.Key;
                    graphLocName.ForeColor = Color.White;
                    graphLocName.Location = new Point(graphLabelPanX, graphLabelPanY);
                    graphLocPercent.Text = loc.Value.ToString("F2");
                    graphLocPercent.ForeColor = Color.White;
                    graphLocPercent.Location = new Point(graphLabelPanX, graphLabelPanY);
                    graphPicBox.Location = new Point(graphLabelPanX, graphLabelPanY);
                    graphPicBox.Height = 12;
                    graphPicBox.Width = (int)loc.Value * 2;
                    graphPicBox.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    graphLabelPanY += 21;
                    panel5.Controls.Add(graphLocName);
                    panel6.Controls.Add(graphPicBox);
                    panel7.Controls.Add(graphLocPercent);
                }
                Label nameLabel = new Label();
                nameLabel.Text = textBox2.Text;
                nameLabel.ForeColor = Color.White;
                nameLabel.Location = new Point(labelPan1X, labelPan1Y);
                Label label = new Label();
                label.Text = textBox1.Text;
                label.ForeColor = Color.White;
                label.Location = new Point(labelPan1X, labelPan1Y);
                labelPan1Y += 20;
                panel1.Controls.Add(label);
                panel2.Controls.Add(nameLabel);
            }
            else
            {
                location.Add(textBox1.Text);
                locationCount.Add(textBox1.Text, 1);
                totalCount = 0;
                panel3.Controls.Clear();
                panel4.Controls.Clear();
                statLabelPanY = 0;
                foreach (var loc in locationCount)
                {
                    Label statLocLabel = new Label();
                    Label statCountLabel = new Label();
                    statLocLabel.Text = loc.Key;
                    statLocLabel.ForeColor = Color.White;
                    statLocLabel.Location = new Point(statLabelPanX, statLabelPanY);
                    statCountLabel.Text = loc.Value.ToString();
                    statCountLabel.ForeColor = Color.White;
                    statCountLabel.Location = new Point(statLabelPanX, statLabelPanY);
                    statLabelPanY += 21;
                    panel3.Controls.Add(statLocLabel);
                    panel4.Controls.Add(statCountLabel);
                }
                foreach (var loc in locationCount)
                {
                    totalCount += loc.Value;
                }
                label8.Text = totalCount.ToString();
                locationPercent.Clear();
                for (int x = 0; x < locationCount.Count; x++)
                {
                    double percent = 0;
                    var item = locationCount.ElementAt(x);
                    percent = item.Value * 100 / totalCount;
                    locationPercent.Add(item.Key, Math.Round(percent,2));
                }
                panel5.Controls.Clear();
                panel6.Controls.Clear();
                panel7.Controls.Clear();
                graphLabelPanY = 0;
                foreach (var loc in locationPercent)
                {
                    Label graphLocName = new Label();
                    Label graphLocPercent = new Label();
                    PictureBox graphPicBox = new PictureBox();
                    graphLocName.Text = loc.Key;
                    graphLocName.ForeColor = Color.White;
                    graphLocName.Location = new Point(graphLabelPanX, graphLabelPanY);
                    graphLocPercent.Text = loc.Value.ToString("F2");
                    graphLocPercent.ForeColor = Color.White;
                    graphLocPercent.Location = new Point(graphLabelPanX, graphLabelPanY);
                    graphPicBox.Location = new Point(graphLabelPanX, graphLabelPanY);
                    graphPicBox.Height = 12;
                    graphPicBox.Width = (int)loc.Value * 2;
                    graphPicBox.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    graphLabelPanY += 21;
                    panel5.Controls.Add(graphLocName);
                    panel6.Controls.Add(graphPicBox);
                    panel7.Controls.Add(graphLocPercent);
                }
                Label nameLabel = new Label();
                nameLabel.Text = textBox2.Text;
                nameLabel.ForeColor = Color.White;
                nameLabel.Location = new Point(labelPan1X, labelPan1Y);
                Label label = new Label();
                label.Text = textBox1.Text;
                label.ForeColor = Color.White;
                label.Location = new Point(labelPan1X,labelPan1Y);
                labelPan1Y += 20;
                panel1.Controls.Add(label);
                panel2.Controls.Add(nameLabel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            location.Clear();
            locationCount.Clear();
            locationPercent.Clear();
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            panel3.Controls.Clear();
            panel4.Controls.Clear();
            panel5.Controls.Clear();
            panel6.Controls.Clear();
            panel7.Controls.Clear();
            totalCount = 0;
            labelPan1X = 0;
            labelPan1Y = 0;
            statLabelPanX = 0;
            statLabelPanY = 0;
            graphLabelPanX = 0;
            graphLabelPanY = 0;
            label8.Text = totalCount.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
