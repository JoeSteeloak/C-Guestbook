/* 
Guestbook version 1

Create a simple guest book app

Written by Jonas Ståleker for Mittuniversitetet
 */

using System;
using System.Linq.Expressions;

namespace guestbook
{
    class Program
    {
        static void Main(string[] args)
        {

            GuestBook guestbook = new GuestBook(); 
            int i=0;

            while(true){ // Loopa igenom och presentera användarvalen i programmet
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("G U E S T B O O K\n\n");

                Console.WriteLine("1. Write entry");
                Console.WriteLine("2. Delete entry\n");
                Console.WriteLine("X. Exit\n");

                i=0;
                foreach(Entry entry in guestbook.getEntries()){ //skriv ut alla inläggen i gästboken
                    Console.WriteLine("[" + i++ + "] " + entry.Name + ": " + entry.Text);
                }

                int inp = Console.ReadKey(true).KeyChar;
                switch (inp) {
                    case '1': // lägg in nytt gästboksinlägg
                        // Rensa konsolen
                        Console.Clear();
                        Console.CursorVisible = true;
                        Console.Write("Enter your name: ");
                        string? name = Console.ReadLine();
                        Console.Write("Enter guestbook message: ");
                        string? text = Console.ReadLine();
                        if(!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(text)) guestbook.addEntry(name, text);
                        break;
                    case '2': // ta bort gästgboksinlägg
                        // Rensa konsolen
                        Console.Clear();
                        Console.CursorVisible = true;
                        Console.Write("Select index to delete: ");
                        string? index = Console.ReadLine();
                        if(!String.IsNullOrEmpty(index))
                            try{
                                guestbook.delEntry(Convert.ToInt32(index));
                            }
                            catch(Exception){
                                Console.WriteLine("Index out of range!\nPress any key to proceed.");
                                Console.ReadKey();
                            }
                        break;
                    case 'X':
                    case 'x': // avsluta programmet
                        // Rensa konsolen
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}