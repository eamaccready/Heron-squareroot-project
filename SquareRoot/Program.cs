using System;
using System.Collections.Generic;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //Create new list of 10,000 random numbers.
            List<double> randList = new List<double>();
            randList = MakeNumList();

            //Create new SquareRoot and test types, setting error for Heron method.
            SquareRoot Hroot = new SquareRoot(0.0001);
            RootTest testRoot = new RootTest();
            
            //Loop through list of random numbers and print out heron vs test for each number.
            foreach (double i in randList)
            {
                Console.WriteLine(Hroot.CalcRoot(i)+ ", " + testRoot.CalcRoot(i)); 
            }
            
            Console.ReadLine();
        }

        //Generates a list of 10,000 random numbers.
        private static List<double> MakeNumList()//method is screwed up.
        {
            var random = new Random();
            var rlist = new List<double>();

            for (int i = 0; i < 10000; i++)
            {
                rlist.Add(random.Next(1000));
            }

            return rlist;
        }
    }

    class SquareRoot
    {
        public double Error { get; set; }
        public SquareRoot(double error)
        {
            Error = error;
        }

        //Take guess number property, for now, set by user.
        public double CalcRoot(double number)
        {
            //Generate guess number. can also be passed by user maybe...
            double guess = new double();
            guess = number/2;

            //If user inputs guess or number that is negative, throw error.
            if (guess < 0 || number < 0)
            {
                Console.WriteLine("Please enter positive numbers only!");
                Console.ReadLine();   
            }

            // If guess error is <= error
            // return guess
            if (Math.Abs(number - (guess * guess)) <= Error)
            {
                return guess;
            }

            // Else if guess error is> error, take average of the factor and the quotient
            //and iterate until error is within set range.

            else
               
           {
                while (Math.Abs((number - (guess * guess))) > Error)
                {
                   
                   guess = (guess + (number / guess)) / 2;
                    
                }
                return guess;
            }
        }
    }
    class RootTest
    {
        public double CalcRoot(double number)
        {
            if (number < 0)
            {
                Console.WriteLine("Please enter positive numbers only!");
                Console.ReadLine();
            }

            number = Math.Sqrt(number);
            return number;
        }

    }

}
