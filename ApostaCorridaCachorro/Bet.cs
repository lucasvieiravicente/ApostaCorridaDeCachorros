namespace ApostaCorridaCachorro
{
    class Bet
    {
        //EXPLANATIONS ABOUT IN THE COMENTS!!!
        //IF YOU NEED HELP IN OTHER LANGUAGE, COMENTS IN BRAZILIAN PORTUGUESE JUST TRANSLATE ON GOOGLE TRANSLATE!!!!!

        public int Amount;        //A quantidade de dinheiro que foi apostada
        public int Dog;          //O número do cão em que se apostou
        public Guy Bettor;      //O cara quem fez a aposta;


        public string GetDescription()  //Método que retorna se foi feito uma aposta
        {
            if(Amount == 0)            
                return Bettor.Name + " hasn't bet.";       
            
            else            
                return Bettor.Name + " bet " + Amount + " bucks on dog " + Dog + "#";            
        }


        public int PayOut(int Winner)       //Método para fazer o pagamento ou cobrança da aposta com base no cão vencedor
        {
            if (Dog == Winner)
                return Amount;

            else
                return -Amount;
        }
    }
}
