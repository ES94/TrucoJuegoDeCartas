using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrucoJuegoDeCartas.Entidades
{
    public class Carta
    {
        public Carta(ValorEnum valor, PaloEnum palo)
        {
            Valor = valor;
            Palo = palo;
        }

        public ValorEnum Valor { get; }

        public PaloEnum Palo { get; }

        public int Peso
        {
            get
            {
                switch (this.Valor)
                {
                    case ValorEnum.Uno:
                        switch (this.Palo)
                        {
                            case PaloEnum.Espada:
                                return 1;
                                
                            case PaloEnum.Basto:
                                return 2;
                                
                            default:
                                return 7;
                        }

                    case ValorEnum.Dos:
                        return 6;

                    case ValorEnum.Tres:
                        return 5;

                    case ValorEnum.Cuatro:
                        return 14;

                    case ValorEnum.Cinco:
                        return 13;

                    case ValorEnum.Seis:
                        return 12;

                    case ValorEnum.Siete:
                        switch (this.Palo)
                        {
                            case PaloEnum.Espada:
                                return 3;

                            case PaloEnum.Oro:
                                return 4;

                            default:
                                return 11;
                        }

                    case ValorEnum.Sota:
                        return 10;

                    case ValorEnum.Caballo:
                        return 9;

                    case ValorEnum.Rey:
                        return 8;

                    default:
                        return 0;
                }
            }
        }
    }
}
