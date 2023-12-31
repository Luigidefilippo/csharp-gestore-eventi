﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Evento
    {
        private string titolo;
        private DateTime data;
        private int capienzaMassima;
        private int postiPrenotati;

        public string Titolo
        {
            get { return titolo; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Il totolo dell'evento non può essere vuoto ");
                titolo = value;
            }
        }

        public DateTime Data
        {
            get { return data; }
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentOutOfRangeException("La data non può essere un giorno nel passato ");
                data = value;
            }
        }
        
        public int CapienzaMassima
        { 
            get { return capienzaMassima;} 
        }
        public int PostiPrenotati
        {
            get { return postiPrenotati;}
            
        }
        public Evento(string titolo , DateTime data , int capienzaMassima)
        {
            Titolo = titolo;
            Data = data;
            if (capienzaMassima < 1)
                throw new ArgumentOutOfRangeException("La capienza massima deve essere maggiore di un partecipante");
            this.capienzaMassima = capienzaMassima;
            postiPrenotati = 0; 
        }
        public void PrenotaPosti( int numeroPosti)
        {
            if(postiPrenotati > this.capienzaMassima )
            {
                throw new ArgumentOutOfRangeException("i posti sono già tutti prenotati ");
            }
            else if (this.data < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("l'evento è terminato ");
            }
            else
            {
                postiPrenotati = numeroPosti;
            }
        }
        public void DisdiciPosti(int numeroPosti)
        {
            if ( numeroPosti < 0 )
            {
                throw new ArgumentException("Il numero di posti disdetti deve essere maggiore o uguale a 1 ");
            }
            else if ( numeroPosti > this.capienzaMassima )
            {
                throw new ArgumentOutOfRangeException("Non è possibile disdire più posti di quelli prenotati ");
            }
            else
            {
                this.postiPrenotati -= numeroPosti;
            }
        }

        public override string ToString()
        {
            return $"{data.ToString("dd/MM/yyyy")} - {Titolo}";
        }
    }

}
