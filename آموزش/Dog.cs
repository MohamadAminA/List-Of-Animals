using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace آموزش
{
    class Dog
    {
        public enum Jensiat
        {
            نر = 0 , ماده = 1
        }
        public Dog ()
        {
            
            ID = 1;
            Sal = 0;
            Mah = 0;

        }
        public Int32 ID { get; set; }
        public string Name { get; set; }
        public string Nezhad { get; set; }
        public Jensiat jensiat { get; set; }
        public Int32 Sal  { get; set; }
        public Int32 Mah { get; set; }
    }
}
