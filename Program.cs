using System;
using System.IO;

namespace NajwyzszaSkutecznoscString
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName, imie, nazwisko;
            int wiek;
            float skutecznosc, max = 0;

            //wczytanie nazwy pliku
            //fileName = Console.ReadLine();
            fileName = "lista.txt";


            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] osoba = line.Split(" ");
                        skutecznosc = Convert.ToSingle(osoba[3]);
                        if (skutecznosc > max) max = skutecznosc;
                    }

                    // powrot na poczatek pliku
                    sr.BaseStream.Position = 0; 

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] osoba = line.Split(" ");
                        imie = osoba[0];
                        nazwisko = osoba[1];
                        wiek = Convert.ToInt32(osoba[2]);
                        skutecznosc = Convert.ToSingle(osoba[3]);

                        if (imie.Length > 3 && nazwisko.EndsWith("ski") && skutecznosc == max)
                        {
                            using (StreamWriter sw = new StreamWriter(fileName + ".max", true))
                            {
                                sw.WriteLine("{0} {1} {2}", imie, nazwisko, wiek);
                            }
                        }
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("Program has ecountered problem with reading file.");
                Console.WriteLine(e.Message);
            }


            //wez najlepsza skutecznosc
           /* foreach (var line in lines)
            {
                string[] osoba = line.Split(" ");
                skutecznosc = Convert.ToSingle(osoba[3]);
                if (skutecznosc > max) max = skutecznosc;
            }
            Console.WriteLine(max);

            foreach (var line in lines)
            {
                string[] osoba = line.Split(" ");
                imie = osoba[0];
                nazwisko = osoba[1];
                wiek = Convert.ToInt32(osoba[2]);
                skutecznosc = Convert.ToSingle(osoba[3]);

                if (imie.Length > 3 && nazwisko.EndsWith("ski") && skutecznosc == max)
                {
                    Console.WriteLine("{0} pasuje", nazwisko);
                }
            } */
        }
    }
}
