using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Controller
    {
        private static Controller uniqueInstance = new Controller();
        public static Controller getInstance()
        {
            return uniqueInstance;
        }

        //Reads any text input
        public string TextInput()
        {
            return Console.ReadLine();
        }

        //Reads any integer input
        public int NumInput()
        {
            return Console.Read();
        }

        //Reads any movement input
        //Confined to the specific values of n/e/s/w/X
        public string MoveInput()
        {
            string input = "";
            bool flag = true;

            while (flag)
            {
                try
                {
                    input = Console.ReadLine();
                    if (!(input.Equals("n") || input.Equals("e") || input.Equals("s") || input.Equals("w") || input.Equals("X")))
                    {
                        throw new Exception("Error: Please enter a valid input (n/e/s/w/X)");
                    }
                    flag = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return input;
        }
    }
}