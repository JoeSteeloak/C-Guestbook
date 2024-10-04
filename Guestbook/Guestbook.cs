using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace guestbook
{
    
    public class GuestBook
    {   //Hämta den lagrade gästboksfilen och skapa en ny lista
        private string filename = @"guestbook.json";
        private List<Entry> entries = new List<Entry>();

        public GuestBook(){ // Om gästboksfilen finns, läs in den och serialisera den 
            if(File.Exists(filename)==true){
                string jsonString = File.ReadAllText(filename);
                entries = JsonSerializer.Deserialize<List<Entry>>(jsonString)!;
            }
        }
        //Lägg till inlägg i gästboken
        public Entry addEntry(string n, string t){
            Entry obj = new Entry { Name = n, Text = t };
            entries.Add(obj); // Lägg till objektet i listan
            marshal(); // Spara till fil
            return obj;
        }
        //Ta bort inlägg baserat på index
        public int delEntry(int index){
            entries.RemoveAt(index);
            marshal();
            return index;
        }

        //Hämta listan med inlägg
        public List<Entry> getEntries(){
            return entries;
        }

        // Serialisera alla objekt och spara till fil
        private void marshal()
        {
            var jsonString = JsonSerializer.Serialize(entries);
            File.WriteAllText(filename, jsonString);
        }
    }
}