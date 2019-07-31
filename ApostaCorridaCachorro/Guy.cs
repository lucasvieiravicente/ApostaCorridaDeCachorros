using System.Windows.Forms;

namespace ApostaCorridaCachorro
{
    class Guy
    {
        public string Name;       //Nome da pessoa
        public Bet MyBet;        //Instância de Bet que tem a aposta
        public int Cash;        //Quantia que a pessoa tem

        //Variaveis para controle de formulário da GUI
        public RadioButton MyRadioButton;    //RadioButton da pessoa
        public Label MyLabel;               //Label da pessoa

        public void UpdateLabels() { MyRadioButton.Text = Name + " has " + Cash + " bucks"; }

        public void ClearBet()
        {
            MyBet = null;
            MyLabel.Text = Name + "'s Bet";
        }

        public bool PlaceBet(int Amount, int Dog)
        {
            if(Amount >= 5)
            {
                MyBet = new Bet { Amount = Amount, Dog = Dog, Bettor = this };
                return true;
            }
            else
            {
                MyBet = new Bet { Amount = 0, Dog = 0, Bettor = this };
                return false;
            }
        }
    }
}
