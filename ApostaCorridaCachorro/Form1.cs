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
        int trackLenght = 1000;
        public Form1()
        {
            InitializeComponent();

            //Atualização de dados cães
            //#1
            dogs[0] = new Greyhound() { StartingPosition = 0, Location = (int)StartPosition, MyPictureBox = dog1PictureBox,
                                                                                            RacetrackLenght = trackLenght, Randomizer = new Random() };
            //#2
            dogs[1] = new Greyhound() { StartingPosition = 0, Location = (int)StartPosition, MyPictureBox = dog2PictureBox,
                                                                                            RacetrackLenght = trackLenght, Randomizer = new Random() };
            //#3
            dogs[2] = new Greyhound() { StartingPosition = 0, Location = (int)StartPosition, MyPictureBox = dog3PictureBox,
                                                                                            RacetrackLenght = trackLenght, Randomizer = new Random() };
            //#4
            dogs[3] = new Greyhound() { StartingPosition = 0, Location = (int)StartPosition, MyPictureBox = dog4PictureBox,
                                                                                            RacetrackLenght = trackLenght, Randomizer = new Random()};
            

            //Atualização de dados dos apostadores
            //#1
            guys[0] = new Guy { Name = "Joe", Cash = 50, MyBet = null, MyLabel = joeLabel, MyRadioButton = joeRadioButton };
            //#2
            guys[1] = new Guy { Name = "Bob", Cash = 75, MyBet = null, MyLabel = bobLabel, MyRadioButton = bobRadioButton };
            //#3
            guys[2] = new Guy{ Name = "Al", Cash = 45, MyBet = null, MyLabel = alLabel, MyRadioButton = alRadioButton };

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
            for (int i = 0; i < trackLenght; i++)
            {
                //Random random1 = new Random();
                //Random random2 = new Random();
                //dogs[random1.Next(4)].Run();
                //dogs[random2.Next(4)].Run();
                //dogs[2].Run();
                //dogs[3].Run();
                //if (dogs[0].Run() || dogs[1].Run() || dogs[2].Run() || dogs[3].Run())
                //    break;

                if (dogs[0].Run() == true)
                {
                    winnerDog = 1;
                }
                if (dogs[1].Run() == true)
                {
                    winnerDog = 2;
                }
                if (dogs[2].Run() == true)
                {
                    winnerDog = 3;
                }
                if (dogs[3].Run() == true)
                {
                    winnerDog = 4;
                }
            }

            //Série para testar e aplicar a msg e apostas depois que chegar o cachorro vencedor
            if (winnerDog == 1)            
                MessageBox.Show("The winner is dog #1");                            
            else if (winnerDog == 2)            
                MessageBox.Show("The winner is dog #2");            
            else if (winnerDog == 3)            
                MessageBox.Show("The winner is dog #3");            
            else            
                MessageBox.Show("The winner is dog #4");

            guys[0].Cash += guys[0].MyBet.PayOut(winnerDog);
            guys[1].Cash += guys[1].MyBet.PayOut(winnerDog);
            guys[2].Cash += guys[2].MyBet.PayOut(winnerDog);
            
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
