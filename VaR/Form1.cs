using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaR.Entities;

namespace VaR
{
    public partial class Form1 : Form
    {
        List<Tick> Ticks;
        PortfolioEntities context = new PortfolioEntities();
        List<PortfolioItem> portfolioItems = new List<PortfolioItem>();

        public Form1()
        {
            InitializeComponent();

            Ticks = context.Tick.ToList();
            dataGridView1.DataSource = Ticks;

            CreatePortfolio();
        }

        private void CreatePortfolio()
        {
            portfolioItems.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            portfolioItems.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            portfolioItems.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = portfolioItems;
        }
    }
}
