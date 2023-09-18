namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel programma di gestione eventi");
            //Inseriamo un nuovo evento 

            Console.Write("Inserisci il titolo dell'evento: ");
            string titolo = Console.ReadLine();

            //Inseriamo la data dell'evento 

            Console.Write("Inserisci la data dell'evento (formato dd/MM/yyyy: ");
            DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            //Inseriamo la capienza massima dei partecipanti all'evento

            Console.Write("Inserisci la capienza massima dell'evento: ");
            int capienzaMassima = int.Parse(Console.ReadLine());

            //Instanziamo un nuovo evento 
            
            Evento nuovoEvento = new Evento(titolo , data, capienzaMassima);

            Console.WriteLine($"Hai creato un nuovo evento : {nuovoEvento}");

            //Chiediamo all'utente quante prenotazioni farà 
            while( true )
            {
                Console.WriteLine("Vuoi effettuare una prenotazione ? (S/N) ");
                string risposta = Console.ReadLine().ToUpper();

                if (risposta != "S")
                    break;

                Console.WriteLine("Quanti posti vuoi prenotare ?  ");
                int postiDaPrenotare = int.Parse(Console.ReadLine());

                try
                {
                    nuovoEvento.PrenotaPosti(postiDaPrenotare);
                    Console.WriteLine($"Hai prenotato {postiDaPrenotare} posti ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore : {ex.Message}");
                }
                Console.WriteLine($"Posti prenotati : {nuovoEvento.PostiPrenotati}");
                Console.WriteLine($"Posti disponibili: {nuovoEvento.CapienzaMassima - nuovoEvento.PostiPrenotati}");
            }
        }
    }
}