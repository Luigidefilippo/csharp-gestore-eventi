using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgrammaEventi
    {
        public string Titolo { get;  private set; }
        private List<Evento> eventi;

        public ProgrammaEventi (string titolo )
        {
            Titolo = titolo;
            eventi = new List<Evento> ();
        }
        public void AggiungiEvento(Evento evento )
        {
            eventi.Add (evento);
        }
        public List<Evento> EventiInData( DateTime data)
        {
            return eventi.FindAll( e => e.Data == data.Date );
        }

        public static string StampaEventi(List<Evento> eventi)
        {
            if( eventi.Count == 0 )
            {
                return "Nessun evento trovato";
            }
            string result = "";
            foreach (Evento e in eventi)
            {
                result += $"{e.Data.ToString("dd/MM/yyyy")} - {e.Titolo}\n";
            }
            return result;

        }
    }
}
