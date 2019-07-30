using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApostaCorridaCachorro
{
    public partial class Form1 : Form
    {
        //Instancia dos caras e cachorros        
        Greyhound[] dogs = new Greyhound[4];
        Guy[] guys = new Guy[3];

        public Form1()
        {
            InitializeComponent();

            //Atualização de dados cães
            //#1            
            dogs[0].Location = 0;
            dogs[0].MyPictureBox = null;
            dogs[0].RacetrackLenght = 20;
            dogs[0].Randomizer = new Random();
            dogs[0].StartingPosition = 0;            
            //#2     
            dogs[1].Location = 0;
            dogs[1].MyPictureBox = null;
            dogs[1].RacetrackLenght = 20;
            dogs[1].Randomizer = new Random();
            dogs[1].StartingPosition = 0;
            //#3            
            dogs[2].Location = 0;
            dogs[2].MyPictureBox = null;
            dogs[2].RacetrackLenght = 20;
            dogs[2].Randomizer = new Random();
            dogs[0].StartingPosition = 0;
            //#4            
            dogs[3].Location = 0;
            dogs[3].MyPictureBox = null;
            dogs[3].RacetrackLenght = 20;
            dogs[3].Randomizer = new Random();
            dogs[3].StartingPosition = 0;

            //Atualização de dados dos apostadores
            //#1
            guys[0].Name = "Joe";
            guys[0].Cash = 50;
            guys[0].MyBet = null;
            guys[0].MyLabel = joeLabel;
            guys[0].MyRadioButton = joeRadioButton;
            //#2
            guys[1].Name = "Bob";
            guys[1].Cash = 75;
            guys[1].MyBet = null;
            guys[1].MyLabel = bobLabel;
            guys[1].MyRadioButton = bobRadioButton;
            //#3
            guys[2].Name = "Al";
            guys[2].Cash = 45;
            guys[2].MyBet = null;
            guys[2].MyLabel = alLabel;
            guys[2].MyRadioButton = alRadioButton;

            guys[0].UpdateLabels();
            guys[1].UpdateLabels();
            guys[2].UpdateLabels();
        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            if(joeRadioButton.Checked)            
                guys[0].PlaceBet(Convert.ToInt16(betNumericUpDown.Value), Convert.ToInt16(dogNumericUpDown.Value));                            

            if (bobRadioButton.Checked)            
                guys[1].PlaceBet(Convert.ToInt16(betNumericUpDown.Value), Convert.ToInt16(dogNumericUpDown.Value));            

            if (joeRadioButton.Checked)            
                guys[2].PlaceBet(Convert.ToInt16(betNumericUpDown.Value), Convert.ToInt16(dogNumericUpDown.Value));                
            
            guys[0].MyBet.GetDescription();
            guys[1].MyBet.GetDescription();
            guys[2].MyBet.GetDescription();
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            while (!dogs[0].Run() || !dogs[1].Run() || !dogs[2].Run())
            {
                dogs[0].Run();
                dogs[1].Run();
                dogs[2].Run();
            }
            if(dogs[0].Run())
            {
                MessageBox.Show("The winner is dog #1");

                if (guys[0].MyBet.Dog == 1)                
                    guys[0].Cash = guys[0].MyBet.Amount;
                
                if (guys[1].MyBet.Dog == 1)                
                    guys[1].Cash = guys[1].MyBet.Amount;
                
                if (guys[2].MyBet.Dog == 1)                
                    guys[2].Cash = guys[2].MyBet.Amount;                
            }
            else if (dogs[1].Run())
            {
                MessageBox.Show("The winner is dog #2");

                if (guys[0].MyBet.Dog == 2)
                    guys[0].Cash = guys[0].MyBet.Amount;

                if (guys[1].MyBet.Dog == 2)
                    guys[1].Cash = guys[1].MyBet.Amount;

                if (guys[2].MyBet.Dog == 2)
                    guys[2].Cash = guys[2].MyBet.Amount;
            }
            else if (dogs[2].Run())
            {
                MessageBox.Show("The winner is dog #3");
                if (guys[0].MyBet.Dog == 3)
                {
                    guys[0].Cash = guys[0].MyBet.Amount;
                }
                if (guys[1].MyBet.Dog == 3)
                {
                    guys[1].Cash = guys[1].MyBet.Amount;
                }
                if (guys[2].MyBet.Dog == 3)
                {
                    guys[2].Cash = guys[2].MyBet.Amount;
                }
            }
            else
            {
                MessageBox.Show("The winner is dog #4");
                if (guys[0].MyBet.Dog == 4)
                {
                    guys[0].Cash = guys[0].MyBet.Amount;
                }
                if (guys[1].MyBet.Dog == 4)
                {
                    guys[1].Cash = guys[1].MyBet.Amount;
                }
                if (guys[2].MyBet.Dog == 4)
                {
                    guys[2].Cash = guys[2].MyBet.Amount;
                }
            }

            guys[0].UpdateLabels();
            guys[1].UpdateLabels();
            guys[2].UpdateLabels();
        }
    }
}
