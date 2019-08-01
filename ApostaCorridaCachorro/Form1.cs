using System;
using System.Windows.Forms;

namespace ApostaCorridaCachorro
{
    public partial class Form1 : Form
    {
        //EXPLANATIONS ABOUT IN THE COMENTS!!!
        //IF YOU NEED HELP IN OTHER LANGUAGE, COMENTS IN BRAZILIAN PORTUGUESE JUST TRANSLATE ON GOOGLE TRANSLATE!!!!!

        //Instanciado os apostadores e cachorros        
        Greyhound[] dogs = new Greyhound[4];
        Guy[] guys = new Guy[3];           

        //Variaveis de controle do formulário (tamanho da pista e booleano para cachorro vencedor)
        int trackLenght = 705;
        bool hasWinner = false;                

        public Form1()
        {
            InitializeComponent();                       
            //Inserção dos dados dos cães no array
            //#1
            dogs[0] = new Greyhound() { StartingPosition = dog1PictureBox.Location.X, Distance = 0, MyPictureBox = dog1PictureBox, RacetrackLenght = trackLenght,
                                                                                                                                              Randomizer = new Random() };
            //#2
            dogs[1] = new Greyhound() { StartingPosition = dog2PictureBox.Location.X, Distance = 0, MyPictureBox = dog2PictureBox, RacetrackLenght = trackLenght,
                                                                                                                                              Randomizer = new Random() };
            //#3
            dogs[2] = new Greyhound() { StartingPosition = dog3PictureBox.Location.X, Distance = 0, MyPictureBox = dog3PictureBox, RacetrackLenght = trackLenght,
                                                                                                                                              Randomizer = new Random() };
            //#4
            dogs[3] = new Greyhound() { StartingPosition = dog4PictureBox.Location.X, Distance = 0, MyPictureBox = dog4PictureBox, RacetrackLenght = trackLenght,
                                                                                                                                              Randomizer = new Random() };            
            //Inserção dos dados dos apostadores no array
            //#1
            guys[0] = new Guy { Name = "Joe", Cash = 50, MyBet = null, MyLabel = joeLabel, MyRadioButton = joeRadioButton };
            //#2
            guys[1] = new Guy { Name = "Bob", Cash = 75, MyBet = null, MyLabel = bobLabel, MyRadioButton = bobRadioButton };
            //#3
            guys[2] = new Guy{ Name = "Al", Cash = 45, MyBet = null, MyLabel = alLabel, MyRadioButton = alRadioButton };

            //Atuaização do texto dos radioButtons com as apostas
            for(int i = 0; i < 3; i++) { guys[i].UpdateLabels(); }
        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            bool check;

            if (joeRadioButton.Checked)
            {
                check = guys[0].PlaceBet(Convert.ToInt16(betNumericUpDown.Value), Convert.ToInt16(dogNumericUpDown.Value));
                if (check)
                    joeLabel.Text = guys[0].MyBet.GetDescription();                
            }
            else if (bobRadioButton.Checked)
            {
                check = guys[1].PlaceBet(Convert.ToInt16(betNumericUpDown.Value), Convert.ToInt16(dogNumericUpDown.Value));
                if(check)
                    bobLabel.Text = guys[1].MyBet.GetDescription();
            }
            else
            {
                check = guys[2].PlaceBet(Convert.ToInt16(betNumericUpDown.Value), Convert.ToInt16(dogNumericUpDown.Value));
                if(check)
                    alLabel.Text = guys[2].MyBet.GetDescription();
            }                                   
        }

        private void raceButton_Click(object sender, EventArgs e)
        {            
            //Checa se não foi feito aposta e coloca uma aposta com 0 e sem cachorro
            for(int i = 0; i < 3; i++)
            {
                if (guys[i].MyBet == null)
                {
                    guys[i].PlaceBet(0, 0);
                    joeLabel.Text = guys[i].MyBet.GetDescription();
                }
            }            

            //Laço para fazer os cachorros correrem enquanto não tem vencedor
            while(!hasWinner)
            {
                //Variavel recebe o valor aleatorio de 0 a 3 e faz o cachorro de tal número correr
                Random random = new Random();
                int randomicDog = random.Next(4);
                hasWinner = dogs[randomicDog].Run();
                
                //Se tiver cachorro vencedor ele ira pegar o número aleatório e somar 1 e mostrar a mensagem
                if(hasWinner)
                {
                    randomicDog += 1;
                    MessageBox.Show("The winner is dog #" + randomicDog);

                    //Faz a função PayOut retornar os valores de acordo com o cão vencedor e suas apostas e a variável Cash de cada guy recebe esse retorno
                    for (int i = 0; i < 3; i++) { guys[i].Cash += guys[i].MyBet.PayOut(randomicDog); }
                    hasWinner = false;
                    break;
                }                  
            }                                                         

            //Atualiza os textos nos radioButtons após o fim da corrida e cobrança/pagamento das apostas
            for(int i = 0; i < 3; i++) { guys[i].UpdateLabels(); }

            //Atualiza os textos das labels para o padrão
            for (int i = 0; i < 3; i++) { guys[i].ClearBet(); }

            //Atualiza as posições dos cachorros e reseta para o padrão as variaveis de controle do formulário e lógica de corrida
            for(int i = 0; i < 4; i++) { dogs[i].TakingStartingPosition(); }                                    
        }        
    }
}
