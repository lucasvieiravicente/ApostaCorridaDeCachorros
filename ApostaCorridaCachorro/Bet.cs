namespace ApostaCorridaCachorro
{
    class Bet
    {
        public int Amount;        //A quantidade de dinheiro que foi apostada
        public int Dog;          //O número do cão em que se apostou
        public Guy Bettor;      //O cara quem fez a aposta;

        public string GetDescription()
        {
            if(Amount == 0)            
                return Bettor.Name + " hasn't bet.";       
            
            else            
                return Bettor.Name + " bet " + Amount + " bucks on dog " + Dog + "#";            
        }

        public int PayOut(int Winner)
        {
            if (Dog == Winner)
                return Amount;

            else
                return -Amount;
        }
    }
}
