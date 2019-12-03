using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SentimentAnalysisDesktopML.Model;


namespace SentimentAnalysisDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label2.Text = "No ML";
            if (predictSentiment())
            {
                label2.Text = "😊";
                label2.ForeColor = Color.Green;
            }
            else
            {
                label2.Text = "😠";
                label2.ForeColor = Color.Red;
            }

            label2.Visible = true;
        }

        //TO DO: Add machine learning
        // Machine learning method
        private bool predictSentiment()
        {
            // Add input data
            var input = new ModelInput();
            input.Comment = textBox1.Text;

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);
            return result.Prediction;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
