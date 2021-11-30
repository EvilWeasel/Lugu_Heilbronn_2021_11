using System;

namespace Basics01
{
    class Program
    {
        static void TestChecked()
        {
            checked
            {
                long l = 3_000_000_000;
                try
                {
                    int i = (int)l;
                    Console.WriteLine("CHECKED: " + i);
                }
                catch
                {
                    Console.WriteLine("DAS GEHT SO NICHT!!!");
                }
            }

            unchecked
            {
                long l2 = 3_000_000_000;
                int i2 = (int)l2;
                Console.WriteLine("UNCHECKED: " + i2);
            }

            long l3 = 3_000_000_000;
            try
            {
                int i3 = checked((int)l3);
                Console.WriteLine("CHECKED mit FUNKTION ... " + i3);
            }
            catch
            {
                Console.WriteLine("KEIN PROBLEM ...");
            }
        }

        static void NullableTest2()
        {
            //Wrapper

            Nullable<double> d1 = 2;
            double? d2 = null;
            d2 = 1.2;
            if (d2 == null) return;
            if (d2.HasValue) return;

            if (string.IsNullOrEmpty("")) return;

        }

        static void NullableTest1()
        {
            try
            {
                double d = double.Parse("");
                if (d == null)
                {
                    
                }
            }
            catch (Exception)
            {

            }
        }
        static void Main(string[] args)
        {


        }
    }
}
