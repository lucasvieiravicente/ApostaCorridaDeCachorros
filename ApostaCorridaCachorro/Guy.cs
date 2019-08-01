using System.Windows.Forms;

namespace ApostaCorridaCachorro
{
    class Guy
    {
        //EXPLANATIONS ABOUT IN THE COMENTS!!!
        //IF YOU NEED HELP IN OTHER LANGUAGE, COMENTS IN BRAZILIAN PORTUGUESE JUST TRANSLATE ON GOOGLE TRANSLATE!!!!!

        public string Name;       //Nome da pessoa
        public Bet MyBet;        //Instância de Bet que tem a aposta
        public int Cash;        //Quantia que a pessoa tem

        //Variaveis para controle de formulário da GUI
        public RadioButton MyRadioButton;    //RadioButton da pessoa
        public Label MyLabel;               //Label da pessoa
        
        
        public void UpdateLabels() { MyRadioButton.Text = Name + " has " + Cash + " bucks"; }       //Método para atualizar texto do RadioButton da classe
        

        public void ClearBet()      //Método para limpar a aposta e atualizar o nome na label da classe
        {
            MyBet = null;
            MyLabel.Text = Name + "'s Bet";
        }

        public bool PlaceBet(int Amount, int Dog)       //Método para instanciar uma aposta na classe guy no objeto Bet
        {
            if(Cash >= 5 && Amount <= Cash)
            {
                MyBet = new Bet { Amount = Amount, Dog = Dog, Bettor = this };
                return true;
            }
            else
            {
                MessageBox.Show(Name + " can't bet, because don't have the amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                return false;
            }
        }
    }
}
