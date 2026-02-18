using System;
using System.Threading; // Necessario per il Thread.Sleep
using LaboratorioStack.Core;

namespace LaboratorioStack
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            // Impostazioni console per un look professionale
            Console.Title = "Laboratorio C# - Gestione Stack Robusta";
            EditorManager editor = new EditorManager();
            bool esci = false;

            while (!esci)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===============================================");
                Console.WriteLine("      SIMULATORE DI STACK (LOGICA LIFO)        ");
                Console.WriteLine("===============================================");
                Console.ResetColor();

                Console.WriteLine("\n[STATO ATTUALE]");
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($" {editor.TestoCorrente} ");
                Console.ResetColor();

                Console.WriteLine("\n--- MENU OPERAZIONI ---");
                Console.WriteLine("1. Scrivi nuova parola");
                Console.WriteLine("2. Undo (Annulla ultima azione)");
                Console.WriteLine("3. Redo (Ripristina azione annullata)");
                Console.WriteLine("4. Test Algoritmo: Verifica Parentesi");
                Console.WriteLine("5. Ispeziona Memoria (Debug Stack)");
                Console.WriteLine("0. ESCI");
                Console.WriteLine("-----------------------");
                Console.Write("Scegli un'opzione (0-5): ");

                string inputScegli = Console.ReadLine();

                // 1. VALIDAZIONE: L'input è un numero?
                if (!int.TryParse(inputScegli, out int scelta))
                {
                    MostraErrore("ERRORE: Devi inserire un numero intero! Le lettere non sono ammesse.");
                    continue; // Salta il resto del ciclo e torna al menu
                }

                // 2. LOGICA DI CONTROLLO (SWITCH)
                switch (scelta)
                {
                    case 1:
                        Console.Write("\nInserisci la parola da aggiungere: ");
                        string parola = Console.ReadLine();
                        // Controllo se l'utente ha premuto invio senza scrivere nulla
                        if (string.IsNullOrWhiteSpace(parola))
                        {
                            MostraErrore("AVVISO: Non puoi inserire una parola vuota.");
                        }
                        else
                        {
                            editor.Digita(parola);
                        }
                        break;

                    case 2:
                        editor.Annulla();
                        break;

                    case 3:
                        editor.Ripristina();
                        break;

                    case 4:
                        Console.Write("\nInserisci un'espressione matematica (es. (a+b)*c): ");
                        string esp = Console.ReadLine() ?? "";
                        bool corretta = AnalizzatoreSintattico.VerificaParentesi(esp);

                        if (corretta)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-> RISULTATO: Sintassi corretta!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("-> RISULTATO: Errore di bilanciamento parentesi.");
                        }
                        Console.ResetColor();
                        Console.WriteLine("\nPremi un tasto per tornare al menu...");
                        Console.ReadKey();
                        break;

                    case 5:
                        editor.StampaDebug();
                        Console.WriteLine("\nPremi un tasto per tornare al menu...");
                        Console.ReadKey();
                        break;

                    case 0:
                        Console.WriteLine("\nChiusura programma in corso...");
                        Thread.Sleep(800);
                        esci = true;
                        break;

                    // 3. GESTIONE NUMERI "A CAZZO" (FUORI RANGE)
                    default:
                        MostraErrore($"ERRORE: L'opzione [{scelta}] non è valida. Scegli tra 0 e 5.");
                        break;
                }
            }
        }

        /// <summary>
        /// Metodo di supporto per gestire gli errori di input graficamente
        /// </summary>
        static void MostraErrore(string messaggio)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{messaggio}");
            Console.ResetColor();
            Console.WriteLine("Riprova...");
            Thread.Sleep(2000); // Pausa di 2 secondi per far leggere l'errore
        }
    }
}