namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Benvenuto nel programma di gestione eventi!");

            // Chiedi all'utente di inserire un nuovo evento
            Console.Write("Inserisci il titolo dell'evento: ");
            string titolo = Console.ReadLine();

            Console.Write("Inserisci la data dell'evento (formato dd/MM/yyyy): ");
            DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Inserisci la capienza massima dell'evento: ");
            int capienzaMassima = int.Parse(Console.ReadLine());

            // Istanzia un nuovo evento
            Evento nuovoEvento = new Evento(titolo, data, capienzaMassima);

            Console.WriteLine($"Hai creato un nuovo evento: {nuovoEvento}");

            // Chiedi all'utente quante prenotazioni vuole fare
            while (true)
            {
                Console.Write("Vuoi effettuare una prenotazione? (S/N): ");
                string risposta = Console.ReadLine().ToUpper();

                if (risposta != "S")
                    break;

                Console.Write("Quanti posti vuoi prenotare? ");
                int postiDaPrenotare = int.Parse(Console.ReadLine());

                try
                {
                    nuovoEvento.PrenotaPosti(postiDaPrenotare);
                    Console.WriteLine($"Hai prenotato {postiDaPrenotare} posti.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                }

                Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
                Console.WriteLine($"Posti disponibili: {nuovoEvento.CapienzaMassima - nuovoEvento.PostiPrenotati}");
            }

            // Chiedi all'utente se vuole disdire posti
            while (true)
            {
                Console.Write("Vuoi disdire dei posti? (S/N): ");
                string risposta = Console.ReadLine().ToUpper();

                if (risposta != "S")
                    break;

                Console.Write("Quanti posti vuoi disdire? ");
                int postiDaDisdire = int.Parse(Console.ReadLine());

                try
                {
                    nuovoEvento.DisdiciPosti(postiDaDisdire);
                    Console.WriteLine($"Hai disdetto {postiDaDisdire} posti.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                }

                Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
                Console.WriteLine($"Posti disponibili: {nuovoEvento.CapienzaMassima - nuovoEvento.PostiPrenotati}");
            }
        }
    }
}