using System;
using System.Collections.Generic;
using System.Drawing;

namespace Müllabfuhrkalender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var restmuell = new List<DateTime>();
            var gelberSack = new List<DateTime>();

            var bitmap = (Bitmap)Bitmap.FromFile("Müllkalender.png");

            var dx = (float)bitmap.Width / 12;
            var dy = (float)bitmap.Height / 31;

            for (int monat = 1; monat <= 12; monat++)
                for (int tag = 1; tag <= 31; tag++)
                {
                    var x0 = (int)((monat - 0.5) * dx);
                    var y0 = (int)((tag - 0.5) * dy);

                    var pixelMitte = bitmap.GetPixel(x0, y0);

                    if (pixelMitte.R == 255 && pixelMitte.G == 0 && pixelMitte.B == 0)
                    {
                        //Papiertonne
                    }
                    else
                    {
                        //Gelb
                        if (pixelMitte.R == 255 && pixelMitte.G == 255 && pixelMitte.B == 0)
                            gelberSack.Add(new DateTime(2023, monat, tag));

                        //Orange
                        if (pixelMitte.R == 237 && pixelMitte.G == 125 && pixelMitte.B == 49)
                            gelberSack.Add(new DateTime(2023, monat, tag));

                        for (int x2 = 0; x2 < 50; x2++)
                        {
                            var pixelSuche = bitmap.GetPixel(x0 + x2, y0);

                            if (pixelSuche.R == 255 && pixelSuche.G == 0 && pixelSuche.B == 0)
                            {
                                restmuell.Add(new DateTime(2023, monat, tag));
                                break;
                            }
                        }
                    }
                }

            Console.WriteLine("Restmüll:");
            Console.WriteLine("        dates:");

            foreach (var date in restmuell)
                Console.WriteLine("          - \"" + date.ToString("yyyy-MM-dd")+"\"");

            Console.WriteLine("");

            Console.WriteLine("Gelber Sack:");
            Console.WriteLine("        dates:");

            foreach (var date in gelberSack)
                Console.WriteLine("          - \"" + date.ToString("yyyy-MM-dd") + "\"");

            Console.Read();

        }
    }
}
