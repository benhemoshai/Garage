using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class InputValidator
    {
        // private const int MENU_CHOICES = 8;


        public static int getUserSelection(int i_StepNumber)
        {
            bool isValidType = false;
            int userSelection = 0;

            while (!isValidType)
            {
                try
                {
                    string userInput = Console.ReadLine();
                    bool isANumber = int.TryParse(userInput, out userSelection);

                    if (!isANumber)
                    {
                        throw new FormatException("Input is not a valid number.");
                    }
                    if (i_StepNumber == 1)
                    {
                        if (userSelection < 1 || userSelection > 8)
                        {
                            throw new ArgumentOutOfRangeException("Invalid selection. Please choose between 1 to 8.");
                        }

                    }
                    else if (i_StepNumber == 2)
                    {
                        if (userSelection < 1 || userSelection > 5)
                        {
                            throw new ArgumentOutOfRangeException("Invalid selection. Please choose between 1 to 5.");
                        }
                    }

                    isValidType = true;
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return userSelection;
        }

        internal static string GetLicensePlate()
        {
            Console.Clear();
            System.Console.WriteLine("Please enter the vehicle's license plate: ");
            return Console.ReadLine();
        }
    }
}
