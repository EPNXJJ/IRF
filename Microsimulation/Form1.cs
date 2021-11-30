using Microsimulation.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsimulation
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        Random rng = new Random(1234);

        public Form1()
        {
            InitializeComponent();

            Population = ReadPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = ReadBirth(@"C:\Temp\születés.csv");
            DeathProbabilities = ReadDeath(@"C:\Temp\halál.csv");
            Simulation();
        }

        public List<Person> ReadPopulation(string fileName)
        {
            List<Person> population = new List<Person>();

            using(StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                while(!sr.EndOfStream)
                {
                    var person = sr.ReadLine().Split(';');

                    Person p = new Person()
                    {
                        BirthYear = int.Parse(person[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), person[1]),
                        NbrOfChildren = int.Parse(person[2])
                    };

                    population.Add(p);
                }
            }

            return population;
        }

        public List<BirthProbability> ReadBirth(string fileName)
        {
            List<BirthProbability> birthProbabilities = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var person = sr.ReadLine().Split(';');

                    BirthProbability bP = new BirthProbability()
                    {
                        Age = int.Parse(person[0]),
                        NbrOfChildren = int.Parse(person[1]),
                        Probability = double.Parse(person[2])
                    };

                    birthProbabilities.Add(bP);
                }
            }

            return birthProbabilities;
        }

        public List<DeathProbability> ReadDeath(string fileName)
        {
            List<DeathProbability> deathProbabilities = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var person = sr.ReadLine().Split(';');

                    DeathProbability dP = new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), person[0]),
                        Age = int.Parse(person[1]),
                        Probability = double.Parse(person[2])
                    };

                    deathProbabilities.Add(dP);
                }
            }

            return deathProbabilities;
        }

        public void Simulation()
        {
            for (int year = 2005; year < 2024; year++)
            {
                for (int population = 0; population < Population.Count; population++)
                {

                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk{1} Lányok{2}", year, nbrOfMales, nbrOfFemales));
            }
        }
    }
}