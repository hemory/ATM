using System;
using System.Runtime.Remoting.Services;

namespace ATM_APP
{
    class Program
    {

        static void Main(string[] args)
        {

            double bankAcct = 500;
            int pin = 1234;
            int pinCount = 0;
            int pinInput = 0;
            int inputNumber = 0;
            double withdrawAmount = 0;

            bool performAnotherAction = true;

            while (performAnotherAction)
            {
                Console.WriteLine("Welcome to the ATM Application. Please enter your four digit pin. ");

                try
                {
                     pinInput = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Really bro?");
                }
                


                pinCount++;

                if (pinCount > 4)
                {
                    Console.WriteLine("Sorry, you have exceed the maximum amount of tries! Goodbye");
                    Console.WriteLine("Press Enter to exit program");
                    Console.ReadLine();
                    break;
                }

                if (pinInput == pin)
                {
                    Console.WriteLine("Please choose a menu option from below");
                    Console.WriteLine(" 1 - Balance Inquiry | 2 - Quick Withdraw | 3 - Withdraw | 4 - Deposit");

                    try
                    {
                        inputNumber = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Numbers only, please.");
                    }

                    switch (inputNumber)
                    {
                        case 1:
                            Console.WriteLine($"Your current balance is ${BalanceInquiry(ref bankAcct)}");

                            PerformAnotherAction(ref performAnotherAction);
                            break;
                        case 2:
                            Console.WriteLine(
                                "This option allows you to quickly withdraw $60. Would you like to continue with this option?");
                            string keepGoing = Console.ReadLine();

                            try
                            {
                                if (keepGoing.ToLower() == "y" || keepGoing.ToLower() == "yes")
                                {
                                    Console.WriteLine($"Your new balance is now {QuickWithdraw(ref bankAcct)}");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a value");
                            }
                          

                            PerformAnotherAction(ref performAnotherAction);

                            break;
                        case 3:

                            Console.WriteLine("How much would you like to withdraw. Please use increments of 20");

                            try
                            {
                                 withdrawAmount = double.Parse(Console.ReadLine());

                            }
                            catch
                            {
                                Console.WriteLine("Please enter numbers only");
                            }

                            if (withdrawAmount > bankAcct)
                            {
                                Console.WriteLine($"I am sorry, you are requesting more than you have in the account. Your current balance is {bankAcct}");

                                PerformAnotherAction(ref performAnotherAction);
                            }
                            else
                            {
                                Console.WriteLine($"Your new account balance is {Withdraw(withdrawAmount, ref bankAcct)}");

                            }

                            PerformAnotherAction(ref performAnotherAction);
                            break;
                        case 4:
                            Console.WriteLine($"Your new account balance is {Deposit(ref bankAcct)}");

                            PerformAnotherAction(ref performAnotherAction);
                            break;
                        default:
                            Console.WriteLine("Please enter a valid menu option");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Please try and enter your in again.");
                }


            }

            Console.WriteLine("Thank you for using our application");
            Console.WriteLine("Press Enter to exit the program");
            Console.ReadLine();


        }

        private static bool PerformAnotherAction(ref bool performAnotherAction)
        {

            Console.WriteLine("Would you like to perform another action?");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "y" || userInput.ToLower() == "yes")
            {
                performAnotherAction = true;
            }
            else
            {
                performAnotherAction = false;
            }

            return performAnotherAction;
        }

        //METHODS

        private static double BalanceInquiry(ref double bankAcct)
        {

            double balance = bankAcct;
            return balance;
        }

        private static double QuickWithdraw(ref double bankAcct)
        {
            return bankAcct -= 60;
        }

        private static double Withdraw(double withdrawAmount, ref double bankAcct)
        {
            if (withdrawAmount % 5 == 0)
            {
                bankAcct -= withdrawAmount;

                Console.WriteLine($"You have deducted {withdrawAmount} from your account");
            }

            return bankAcct;
        }

        private static double Deposit(ref double bankAcct)
        {
            Console.WriteLine("How much money would you like to deposit? Please enter a value");
            double inputAmount = 0;

            try
            {
                 inputAmount = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a valid number");
            }

            bankAcct += inputAmount;

            return bankAcct;
        }
    }
}
