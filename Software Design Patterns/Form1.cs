using Software_Design_Patterns.Abstractions;
using Software_Design_Patterns.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Design_Patterns
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();

        private Toy _nextToy;

        private IToyFactory _factory;

        public IToyFactory Factory
        {
            get { return _factory; }
            set 
            { 
                _factory = value;
                DisplayNext();
            }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            mainPanel.Controls.Add(toy);
            toy.Left = -toy.Width;
            toy.Top = 140;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach(var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition) maxPosition = toy.Left;
            }

            if(maxPosition > 1000)
            {
                var firstToy = _toys[0];
                _toys.Remove(firstToy);
                mainPanel.Controls.Remove(firstToy);
            }
        }

        private void carButton_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void ballButton_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory()
            {
                BallColor = colorButton.BackColor
            };
        }

        private void presentButton_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory()
            {
                BoxColor = boxColorButton.BackColor,
                RibbonColor = ribbonColorButton.BackColor
            };
        }

        private void DisplayNext()
        {
            if (_nextToy != null) mainPanel.Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;

            mainPanel.Controls.Add(_nextToy);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = button.BackColor;
            if (cd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                button.BackColor = cd.Color;
            }
        }
    }
}
