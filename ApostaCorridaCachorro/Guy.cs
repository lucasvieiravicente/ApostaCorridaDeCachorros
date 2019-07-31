using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                MyBet = new Bet();
                MyBet.Amount = Amount;
                MyBet.Dog = Dog;
                MyBet.Bettor = this;                
                return true;
            }
            else
            {
                MyBet = new Bet();
                MyBet.Amount = 0;
                MyBet.Dog = 0;
                MyBet.Bettor = this;
                return false;
            }
        }
    }
}
