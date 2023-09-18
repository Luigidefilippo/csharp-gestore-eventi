namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel programma di gestione eventi");
            //Inseriamo un nuovo evento 

            Console.Write("Inserisci il titolo dell'evento");
            string titolo = Console.ReadLine();

            //Inseriamo la data dell'evento 

            Console.Write("Inserisci la data dell'evento (formato dd/MM/yyyy: ");
            DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }
    }
}