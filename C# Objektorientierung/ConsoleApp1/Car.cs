using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Car
    {
        // objektorientierung - private, public 
        // Attribute:
        public int baujahr;
        public int preis;

        public double ps;

        public bool broken;

        public string kennzeichen;
        public string color;
        public string brand;

        private string identification_number;

        // Konstruktor
        // Basis Konstruktor
        public Car()
        {
            
        }

        // kein this
        public Car(string _kennzeichen, double _ps, int _baujahr)
        {
            // Ein Konstruktor oder Methoden haben Zugriff auf alle Attribute in einer Klasse
            kennzeichen = _kennzeichen;
            ps = _ps;
            baujahr = _baujahr;
        }

        // Methode
        public void drive()
        {
            Console.WriteLine("Driving");
        }
        public void stop()
        {
            Console.WriteLine("Stopping");
        }
    }
}
