﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozvrhHodin
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            /*
            Rozvrh r1 = new Rozvrh();
            Predmet pr1 = new Predmet();
            Predmet pr2 = new Predmet("Test", "T", TypVyuky.Teorie, 0);
            */
            
            Console.WriteLine();




            Rozvrh test = new Rozvrh("test", "C4b");
            Console.WriteLine(test.ToString());


            /*
             * Fungování aplikace
             * 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
        }
    }
}
