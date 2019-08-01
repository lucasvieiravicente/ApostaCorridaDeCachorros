using System;
using System.Drawing;
using System.Windows.Forms;

namespace ApostaCorridaCachorro
{
    class Greyhound
    {
        //EXPLANATIONS ABOUT IN THE COMENTS!!!
        //IF YOU NEED HELP IN OTHER LANGUAGE, COMENTS IN BRAZILIAN PORTUGUESE JUST TRANSLATE ON GOOGLE TRANSLATE!!!!!

        public int StartingPosition;                  //Posição inicial da PictureBox
        public int RacetrackLenght;                  //Tamanho da pista de corrida
        public PictureBox MyPictureBox;             //Objeto pictureBox
        public int Distance = 0;                   //Distância percorrida pelo cachorro no método Run()
        public Random Randomizer;                 //Instância Random para trabalhar com valores aleatórios da classe        


        public bool Run()   //Método para fazer o cachorro correr e retornar o valor booleano se ganhar
        {            
            Distance = Randomizer.Next(1,5);
            Point point = MyPictureBox.Location;
            point.X += Distance;
            MyPictureBox.Location = point;
            Application.DoEvents();

            if (MyPictureBox.Location.X >= RacetrackLenght)            
                return true;            

            else            
                return false;            
        }

        public void TakingStartingPosition()
        {
            Point point = MyPictureBox.Location;
            point.X = StartingPosition;
            MyPictureBox.Location = point;
            Application.DoEvents();            
        }
    }
}
