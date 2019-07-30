using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ApostaCorridaCachorro
{
    class Greyhound
    {
        public int StartingPosition;                  //Onde o PictureBox inicia
        public int RacetrackLenght;                  //Tamanho da pista de corrida
        public PictureBox MyPictureBox = null;      //Objeto pictureBox
        public int Location = 0;                   //Posição do objeto Greyhound na pista
        public Random Randomizer;                 //Instancia Random para trabalhar com valores aleatórios da classe

        public bool Run()
        {
            while (Location < RacetrackLenght)
            {
                Location += Randomizer.Next(0, 5);
                Point p = MyPictureBox.Location;
                p.X += Location;
                MyPictureBox.Location = p;
                if(Location >= RacetrackLenght)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }                                                    
        }

        public void TakingStartingPosition()
        {
            Location = StartingPosition;
        }
    }
}
