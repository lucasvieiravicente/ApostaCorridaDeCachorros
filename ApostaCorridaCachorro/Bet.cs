using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApostaCorridaCachorro
{
    class Bet
    {
        public int Amount;      //A quantidade de dinheiro que foi apostada
        public int Dog;         //O número do cão em que se apostou
        public Guy Bettor;      //O cara quem fez a aposta;

        public string GetDescription()
        {
            if(Amount == 0)
            {
                return Bettor.Name + " não apostou.";
            }
            else
            {
                return Bettor.Name + " apostou " + Amount + "R$ no cão " + Dog + "#";
            }
        }
    }
}
