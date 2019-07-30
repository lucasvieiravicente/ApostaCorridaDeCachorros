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
        public Form1()
        {
            InitializeComponent();
            //Instancia dos cães e atualização de dados
            Greyhound[] greyhounds = new Greyhound[4];
            //#1            
            greyhounds[0].Location = 0;
            greyhounds[0].MyPictureBox = null;
            greyhounds[0].RacetrackLenght = 0;
            greyhounds[0].Randomizer = new Random();
            greyhounds[0].RacetrackLenght = 0;
            //#2     
            greyhounds[1].Location = 0;
            greyhounds[1].MyPictureBox = null;
            greyhounds[1].RacetrackLenght = 0;
            greyhounds[1].Randomizer = new Random();
            greyhounds[1].RacetrackLenght = 0;
            //#3            
            greyhounds[2].Location = 0;
            greyhounds[2].MyPictureBox = null;
            greyhounds[2].RacetrackLenght = 0;
            greyhounds[2].Randomizer = new Random();
            greyhounds[2].RacetrackLenght = 0;
            //#4            
            greyhounds[3].Location = 0;
            greyhounds[3].MyPictureBox = null;
            greyhounds[3].RacetrackLenght = 0;
            greyhounds[3].Randomizer = new Random();
            greyhounds[3].RacetrackLenght = 0;

            //Instancia dos caras e atualização de dados
            Guy[] guys = new Guy[3];
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
        }

        private void betsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
