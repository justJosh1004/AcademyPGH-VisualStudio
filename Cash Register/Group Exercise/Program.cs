using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //amount owed

            Console.WriteLine("How much did your items cost?");
            string cost = Console.ReadLine();
            decimal costInput = Convert.ToDecimal(cost);

            //amount given

            Console.WriteLine("How much did you give me?");
            string cash = Console.ReadLine();
            decimal cashInput = Convert.ToDecimal(cash);
            

            //change 

            decimal change;
            change = cashInput - costInput;
            Console.WriteLine("Your change is: $" + change + "\n\n");
            int tWbill = 0;
            int tNbill = 0;
            int fVbill = 0;
            int f1bill = 0;
            int qTcoin = 0;
            int dMcoin = 0;
            int nKcoin = 0;
            int pNcoin = 0;
            
            while (change >= 20)
            {
                change = change - 20;
                tWbill = tWbill + 1;
            }
            Console.WriteLine(change);

            while (change >= 10)
            {
                change = change - 10;
                tNbill = tNbill + 1;
            }
            Console.WriteLine(change);

            while (change >= 5)
            {
                change = change - 5;
                fVbill = fVbill + 1;
            }
            Console.WriteLine(change);
            while (change >= 1)
            {
                change = change - 1;
                f1bill = f1bill + 1;
            }
            Console.WriteLine(change);
            while (change >= .25m)
            {
                change = change - .25m;
                qTcoin = qTcoin + 1;
            }
            Console.WriteLine(change);
            while (change >= .10m)
            {
                change = change - .10m;
                dMcoin = dMcoin + 1;
            }
            Console.WriteLine(change);
            while (change >= .05m)
            {
                change = change - .05m;
                nKcoin++;
            }
            Console.WriteLine(change);
            while (change >= .01m)
            {
                change = change - .01m;
                pNcoin++;
            }
            Console.WriteLine(change);
            
            Console.WriteLine("$20 - " + tWbill + "\n$10 - " + tNbill + "\n$5 - " + fVbill + "\n$1 - " + f1bill + "\n$0.25 - " + qTcoin
                                    + "\n$0.10 - " + dMcoin + "\n$0.05 - " + nKcoin + "\n$0.01 - " + pNcoin);
            Console.ReadLine();
        }
    }
}
