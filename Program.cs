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
            fileName = Console.ReadLine();


            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                using (StreamWriter sw = new StreamWriter(fileName + ".max"))
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
                            char[] censored = nazwisko.ToCharArray();

                            for (int i = 1; i < nazwisko.Length - 3; i++)
                            {
                                censored[i] = '*';
                            }
                            nazwisko = new string(censored);
                            sw.WriteLine("{0} {1} {2}", imie, nazwisko, wiek);
                        }
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("Program has ecountered problem with reading file.");
                Console.WriteLine(e.Message);
            }
        }
    }
}
