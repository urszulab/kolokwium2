using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;



namespace kolokwium2
{       // klasa Program
    class Program
    {
        class Ingredient: IComparable<Ingredient>

        {
            private string nazwaIngredienta;
            private string ilosc;
            private double cenaIngredienta;

            public Ingredient(string naz, string il, double cenaIngred)
            {
                this.nazwaIngredienta = naz;
                this.ilosc = il;
                this.cenaIngredienta = cenaIngred;
            }

            public override string ToString()
            {
                return "Nazwa:" + this.nazwaIngredienta + "ilosc:" + this.ilosc + "cena: " + this.cenaIngredienta;
            }

            public double Zwraca()
            {
                return this.cenaIngredienta;
            }

            public int CompareTo(Ingredient other)
            {
                return this.nazwaIngredienta.CompareTo(other.nazwaIngredienta);

            }
            
        }

        // klasa Przepis
        class Przepis
        {
            private string nazwa;
            double suma = 0;
            List<Ingredient> ingredienci = new List<Ingredient>();
            int czasPrzygotowania;   // w min.

            void DodajIngredient(string nazw, string il, double cena)
            {
                this.ingredienci.Add(new Ingredient(nazw, il, cena));
                this.suma = this.suma + cena;
            }
            
            public void UstawNazweICzas(string naz, int czas)
            {
                
                this.nazwa = naz;
                this.czasPrzygotowania = czas;
            }
            public override string ToString()
            {
                List<String> przepis = new List<String>();
                foreach (string el in przepis)
                {
                    przepis.Add(el.ToString());

                }
                if (przepis == null)
                {
                    return "";
                }
                return "Przepis: " + '\n' + przepis + '\n' + "Suma: " + this.suma;
                
            }

            public bool CzyCzas()
            {
                if (this.czasPrzygotowania > 0)
                {
                    return true;
                }
                return false;
            }

            public int IleIngredientow()
            {
                return this.ingredienci.Count;
            }

        }
        
        //klasa Zamowienie - abstrakcyjna
        abstract class Zamowienie
        {
            protected DateTime czasDostawy;

            public virtual bool PoprawnyCzas()
            {
                if (DateTime.Compare(this.czasDostawy, DateTime.Now) < 0) // jesli pierwsze wydarza sie wczensiej niz drugie to okej
                {
                    return true;
                }
                return false;
            }
            public void UstawCzasDostawy(DateTime data)
            {
                this.czasDostawy = data;

            }
        }

        // klasy dzidziczone po Zamowieniu
        class NaMiejscu: Zamowienie
        {

        }

        class NaWynos : Zamowienie
        {
            public override bool PoprawnyCzas()
            {
                TimeSpan roznica = this.czasDostawy - DateTime.Now;
                double minuty = (double)roznica.TotalMinutes;
                if (minuty <= 120)
                    return false;
                return true;
            }
        }


        static void Main(string[] args)
        {
            string nazwa_przepisuu;
            int czaas;
            Console.WriteLine("Podaj nazwe przepisu:");
            nazwa_przepisuu = Console.ReadLine();
            if (nazwa_przepisuu.Length == 0)
            {
                Console.WriteLine("Podaj poprawna nazwe: ");
                nazwa_przepisuu = Console.ReadLine();
            }
            Console.WriteLine("Podaj czas: ");
            czaas = Convert.ToInt32(Console.ReadLine());
            if (czaas > 0 && czaas < 300)
            {
                Console.WriteLine("Prosze podac czas przygotowania wiekszy od 0 i mniejszy od 300 minut");
                czaas = Convert.ToInt32(Console.ReadLine());
            }

        }
    }
}
