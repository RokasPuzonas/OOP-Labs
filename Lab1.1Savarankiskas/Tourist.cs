using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1._1Savarankiskas
{
    class Tourist
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Money { get; set; }
        public Tourist(string name, string surname, double money)
        {
            Name = name;
            Surname = surname;
            Money = money;
        }
    }
}
