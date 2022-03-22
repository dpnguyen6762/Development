using System;
using System.IO;

namespace RobotNavigation
{
    internal class Program
    {
        static readonly string textFile = @"C:\Users\Nina\Desktop\Jobs Search\Test\RobotProblem_Input.txt";

        private static void Main()
        {
            try
            {
                if (File.Exists(textFile))
                {
                    // Read file using StreamReader. Reads file line by line  
                    using (StreamReader file = new StreamReader(textFile))
                    {
                        //int ilnCounter        = 0;
                        string ln             = string.Empty;
                        int iForwardTotal     = 0;
                        int iDownTotal        = 0;
                        bool bFirstHorizontal = true;

                        while ((ln = file.ReadLine()) != null)
                        {
                            //Console.WriteLine(ln);

                            var sForward = ln.Contains("forward") ? ln.Substring(7,ln.Length - 7).Trim() : string.Empty;
                            var sDown    = ln.Contains("down") ? ln.Substring(4, ln.Length - 4).Trim() : string.Empty;
                            var sUp      = ln.Contains("up") ? ln.Substring(2, ln.Length - 2).Trim() : string.Empty;
                            var sBack    = ln.Contains("Back") ? ln.Substring(4, ln.Length - 4).Trim() : string.Empty;

                            if (!string.IsNullOrEmpty(sForward))
                            {
                                if (bFirstHorizontal)
                                {
                                    bFirstHorizontal = false;
                                }
                                else
                                {
                                    Console.WriteLine(String.Format("Horizontal={0},Depth={1},CurrentPosition={2}", iForwardTotal, iDownTotal, iForwardTotal * iDownTotal));
                                }
                            }

                            int iForward = !string.IsNullOrEmpty(sForward) ? Int32.Parse(sForward) : 0;
                            int iBack    = !string.IsNullOrEmpty(sBack) ? Int32.Parse(sForward) : 0;
                            int iDown    = !string.IsNullOrEmpty(sDown) ? Int32.Parse(sDown) : 0;
                            int iUp      = !string.IsNullOrEmpty(sUp) ? Int32.Parse(sUp) : 0;


                            if (iBack > 0)
                            {
                                iForward -= iBack;
                            }

                            if (iUp > 0)
                            {
                                iDownTotal -= iUp;
                            }

                            iForwardTotal += iForward;
                            iDownTotal    += iDown;
                            
                            //ilnCounter++;
                        }

                        Console.WriteLine(String.Format("Horizontal={0},Depth={1},FinalPosition={2}", iForwardTotal.ToString(), iDownTotal.ToString(), iForwardTotal * iDownTotal));

                        file.Close();
                        //Console.WriteLine($"File has {ilnCounter} lines.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
