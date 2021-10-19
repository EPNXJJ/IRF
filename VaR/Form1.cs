﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        List<decimal> Nyeresegek = new List<decimal>();

        public Form1()
        {
            InitializeComponent();

            Ticks = context.Tick.ToList();
            dataGridView1.DataSource = Ticks;

            CreatePortfolio();

            int intervalum = 30;
            DateTime kezdőDátum = (from x in Ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30);
            TimeSpan z = záróDátum - kezdőDátum;
            for (int i = 0; i < z.Days - intervalum; i++)
            {
                decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                           - GetPortfolioValue(kezdőDátum.AddDays(i));
                Nyeresegek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            var nyeresegekRendezve = (from x in Nyeresegek
                                      orderby x
                                      select x)
                                        .ToList();
            MessageBox.Show(nyeresegekRendezve[nyeresegekRendezve.Count() / 5].ToString());
        }

        private void CreatePortfolio()
        {
            portfolioItems.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            portfolioItems.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            portfolioItems.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = portfolioItems;
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in portfolioItems)
            {
                var last = (from x in Ticks
                            where item.Index == x.Index.Trim()
                               && date <= x.TradingDay
                            select x)
                            .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "txt files (*.txt) | *.txt";
            sfd.DefaultExt = "txt";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() != DialogResult.OK) return;

            using(StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                sw.Write("Időszak");
                sw.Write(" ");
                sw.Write("Nyereség");
                sw.WriteLine();

                int counter = 1;
                foreach (var item in Nyeresegek)
                {
                    sw.Write(counter);
                    sw.Write(" ");
                    sw.Write(item);
                    sw.WriteLine();

                    counter++;
                }
            }
        }
    }
}
