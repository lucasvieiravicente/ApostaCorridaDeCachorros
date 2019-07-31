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
            dogs[0] = new Greyhound();
            dogs[0].Location = 0;
            dogs[0].MyPictureBox = null;
            dogs[0].RacetrackLenght = 20;
            dogs[0].Randomizer = new Random();
            dogs[0].StartingPosition = 0;
            //#2
            dogs[1] = new Greyhound();
            dogs[1].Location = 0;
            dogs[1].MyPictureBox = null;
            dogs[1].RacetrackLenght = 20;
            dogs[1].Randomizer = new Random();
            dogs[1].StartingPosition = 0;
            //#3
            dogs[2] = new Greyhound();
            dogs[2].Location = 0;
            dogs[2].MyPictureBox = null;
            dogs[2].RacetrackLenght = 20;
            dogs[2].Randomizer = new Random();
            dogs[2].StartingPosition = 0;
            //#4
            dogs[3] = new Greyhound();
            dogs[3].Location = 0;
            dogs[3].MyPictureBox = null;
            dogs[3].RacetrackLenght = 20;
            dogs[3].Randomizer = new Random();
            dogs[3].StartingPosition = 0;

            //Atualização de dados dos apostadores
            //#1
            guys[0] = new Guy();
            guys[0].Name = "Joe";
            guys[0].Cash = 50;
            guys[0].MyBet = null;
            guys[0].MyLabel = joeLabel;
            guys[0].MyRadioButton = joeRadioButton;
            //#2
            guys[1] = new Guy();
            guys[1].Name = "Bob";
            guys[1].Cash = 75;
            guys[1].MyBet = null;
            guys[1].MyLabel = bobLabel;
            guys[1].MyRadioButton = bobRadioButton;
            //#3
            guys[2] = new Guy();
            guys[2].Name = "Al";
            guys[2].Cash = 45;
            guys[2].MyBet = null;
            guys[2].MyLabel = alLabel;
            guys[2].MyRadioButton = alRadioButton;

            //Atuaização do texto dos radioButtons com as apostas
            guys[0].UpdateLabels();
            guys[1].UpdateLabels();
            guys[2].UpdateLabels();
        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                guys[0].PlaceBet(Convert.ToInt16(betNumericUpDown.Value), Convert.ToInt16(dogNumericUpDown.Value));
                joeLabel.Text = guys[0].MyBet.GetDescription();
            }
            if (bobRadioButton.Checked)
            {
                guys[1].PlaceBet(Convert.ToInt16(betNumericUpDown.Value), Convert.ToInt16(dogNumericUpDown.Value));
                bobLabel.Text = guys[1].MyBet.GetDescription();
            }
            if (alRadioButton.Checked)
            {
                guys[2].PlaceBet(Convert.ToInt16(betNumericUpDown.Value), Convert.ToInt16(dogNumericUpDown.Value));
                alLabel.Text = guys[2].MyBet.GetDescription();
            }                                   
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            int winnerDog = 0;

            //Checa se não foi feito aposta e coloca uma aposta com 0 e sem cachorro
            if (guys[0].MyBet == null)
            {
                guys[0].PlaceBet(0, 0);
                joeLabel.Text = guys[0].MyBet.GetDescription();
            }

            if (guys[1].MyBet == null)
            {
                guys[1].PlaceBet(0, 0);
                bobLabel.Text = guys[1].MyBet.GetDescription();
            }

            if (guys[2].MyBet == null)
            {
                guys[2].PlaceBet(0, 0);
                alLabel.Text = guys[2].MyBet.GetDescription();
            }

            //Laço para fazer os cachorros correrem enquanto retornarem falso;
            for(int i = 0; i < 20; i++)
            {
                dogs[1].Run();
                dogs[0].Run();                
                dogs[2].Run();
                dogs[3].Run();

                if (dogs[0].Run() == true)
                {
                    winnerDog = 1;
                    break;
                }
                if (dogs[1].Run() == true)
                {
                    winnerDog = 2;
                    break;
                }
                if (dogs[2].Run() == true)
                {
                    winnerDog = 3;
                    break;
                }
                if (dogs[3].Run() == true)
                {
                    winnerDog = 4;
                    break;
                }
            }

            //Série para testar e aplicar a msg e apostas depois que chegar o cachorro vencedor
            if (winnerDog == 1)
            {
                MessageBox.Show("The winner is dog #1");
                guys[0].MyBet.PayOut(1);
                guys[1].MyBet.PayOut(1);
                guys[2].MyBet.PayOut(1);
            }
            else if (winnerDog == 2)
            {
                MessageBox.Show("The winner is dog #2");
                guys[0].MyBet.PayOut(2);
                guys[1].MyBet.PayOut(2);
                guys[2].MyBet.PayOut(2);
            }
            else if (winnerDog == 3)
            {
                MessageBox.Show("The winner is dog #3");
                guys[0].MyBet.PayOut(3);
                guys[1].MyBet.PayOut(3);
                guys[2].MyBet.PayOut(3);
            }
            else
            {
                MessageBox.Show("The winner is dog #4");
                guys[0].MyBet.PayOut(4);
                guys[1].MyBet.PayOut(4);
                guys[2].MyBet.PayOut(4);
            }

            //Atualiza os textos nos radioButtons após o fim da corrida e cobrança/pagamento das apostas
            guys[0].UpdateLabels();
            guys[1].UpdateLabels();
            guys[2].UpdateLabels();

            //Atualiza os textos da label para o nome
            guys[0].ClearBet();
            guys[1].ClearBet();
            guys[2].ClearBet();
        }
    }
}
