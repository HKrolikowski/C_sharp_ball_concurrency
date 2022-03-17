using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_wsp
{
    internal class Bajt
    {
        private Byte _wartosc;
        public int Wartosc
        {
            get => _wartosc;
            set
            {
                if ((value >= 0) && (value < 256))
                {
                    _wartosc = (Byte) value;
                }
            }
        }

        public Bajt(Byte wartosc)
        {
            _wartosc = wartosc;
        }

        //Sprawdzenie co znajduje sie na danym bicie
        public bool isBit(int pozycja) //pozycja od prawej
        {
            if (pozycja >= 0 && pozycja < 8)
            {
                return (_wartosc & (1 << pozycja)) != 0;
            }
            else return false;
        }

        //wstawienie 0 na dana pozycje w bajcie
        public void setBitZero(int pozycja)
        {
            if(pozycja >= 0 && pozycja < 8)
            {
                _wartosc = (Byte) (_wartosc & ~(1 << pozycja));
            }
        }


        //wstawianie 1 na dana pozycje w bajcie
        public void setBitOne(int pozycja)
        {
            if (pozycja >= 0 && pozycja < 8)
            {
                _wartosc = (Byte) (_wartosc | 1 << pozycja);
            }  
        }
    }
}
