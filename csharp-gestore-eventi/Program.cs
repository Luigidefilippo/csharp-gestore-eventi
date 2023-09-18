namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel programma di gestione eventi!");

            // Chiedi all'utente di inserire un nuovo programma di eventi
            Console.Write("Inserisci il titolo del tuo programma Eventi: ");
            string titoloProgramma = Console.ReadLine();

            ProgrammaEventi programmaEventi = new ProgrammaEventi(titoloProgramma);

            // Chiedi all'utente quanti eventi vuole aggiungere
            Console.Write("Indica il numero di eventi da inserire: ");
            int numeroEventi = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numeroEventi; i++)
            {
                Console.WriteLine($"Inserimento evento {i}");

                Console.Write("Inserisci il titolo dell'evento: ");
                string titolo = Console.ReadLine();

                Console.Write("Inserisci la data dell'evento (formato dd/MM/yyyy): ");
                DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.Write("Inserisci la capienza massima dell'evento: ");
                int capienzaMassima = int.Parse(Console.ReadLine());

                Evento nuovoEvento = new Evento(titolo, data, capienzaMassima);

                Console.WriteLine($"Hai creato un nuovo evento: {nuovoEvento}");

                // Chiedi all'utente quante prenotazioni vuole fare per l'evento corrente
                while (true)
                {
                    Console.Write("Vuoi effettuare una prenotazione per questo evento? (S/N): ");
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

                    // Aggiungi l'evento al programma di eventi
                    programmaEventi.AggiungiEvento(nuovoEvento);
            }

            Console.WriteLine($"Il numero di eventi nel tuo programma Eventi è: {programmaEventi.NumeroEventi()}");
            Console.WriteLine("Ecco il tuo programma Eventi:");
            Console.WriteLine(programmaEventi);

            // Chiedi all'utente una data e stampa gli eventi in quella data
            Console.Write("Inserisci una data (gg/mm/yyyy) per visualizzare gli eventi in quella data: ");
            DateTime dataDaCercare = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            List<Evento> eventiInData = programmaEventi.EventiInData(dataDaCercare);

            Console.WriteLine("Eventi in data selezionata:");
            Console.WriteLine(ProgrammaEventi.StampaEventi(eventiInData));

            // Elimina tutti gli eventi dal programma
            programmaEventi.SvuotaEventi();

            Console.WriteLine("Hai eliminato tutti gli eventi dal tuo programma Eventi.");


        }
    }
}