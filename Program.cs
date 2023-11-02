using System;
using System.Threading;

namespace Exercicio3_SO_Threads;
internal class Program {

    static string[] songNames = {
        "At Doom's Gate",
        "The Imp's Song",
        "Dark Halls",
        "Kitchen Ace (And Taking Names)",
        "Suspense",
        "On the Hunt"
    };

    public static void ThreadProc() {

        for (int i = 0; i < songNames.Length; i++) {
            Console.WriteLine("Thread {0} - Musica atual {1} {2}", 
                Environment.CurrentManagedThreadId, 
                i, 
                songNames[i]);

            Thread.Sleep(0);
        }
    }

    static void Main(string[] args) {        

        Console.WriteLine("Thread Principal: Iniciando threads secundarias.");
        
        //Cria duas Threads
        Thread t1 = new Thread(new ThreadStart(ThreadProc));
        Thread t2 = new Thread(new ThreadStart(ThreadProc));

        //Inicializa as duas Threads
        t1.Start();
        t2.Start();

        //Ocupa a Thread principal
        for (int i = 0; i < 4; i++) {
            Console.WriteLine("Thread Principal: Ocupada com outras coisas");
            Thread.Sleep(0);
        }

        Console.WriteLine("Thread Principal: Aguardando threads secundarias terminarem");

        //Aguarda o trabalho secundario terminar para continuar a execucao da
        //thread principal
        t1.Join();
        t2.Join();

        Console.WriteLine("Thread Principal: Threads secundarias terminaram.");
        Console.WriteLine("Pressione Enter para finalizar");
        Console.ReadLine();
    }
}
