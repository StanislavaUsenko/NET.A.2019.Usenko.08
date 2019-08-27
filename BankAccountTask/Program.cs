using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountTask.Interfaces;
using BankAccountTask.Models;
using BankAccountTask.Server;
using BankAccountTask.Service;

namespace BankAccountTask
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<BankAccount> repository = new BinaryRepository();
            IService<BankAccount> service = new StandartBankAccountService(repository);

            List<BankAccount> list = repository.Read();

            //Console.WriteLine("Add new account");
            //service.AddBankAccount(new BankAccount(34, "test", "test", 0));

            //Console.WriteLine("all accounts");
            //foreach (var a in list)
            //    Console.WriteLine(a.ToString());

            //service.DeleteBankAccount(34);

            //Console.WriteLine("all accounts");
            //foreach (var a in list)
            //    Console.WriteLine(a.ToString());

            Console.WriteLine("deposite on 0 id");
            service.Deposit(0, 100);

            Console.WriteLine("all accounts");
            foreach (var a in list)
                Console.WriteLine(a.ToString());

            Console.WriteLine("withdraw on 1 id");
            service.Withdraw(0, 300);


            Console.WriteLine("all accounts");
            foreach (var a in list)
                Console.WriteLine(a.ToString());

            Console.ReadLine();





        }




        public static void FirstInitialisation()
        {
            IRepository<BankAccount> repository = new BinaryRepository();
            IService<BankAccount> service = new StandartBankAccountService(repository);

            service.AddBankAccount(new BankAccount(0, "Boris", "Chapaev", Enums.CardStatusEnum.Standart));
            service.AddBankAccount(new BankAccount(1, "Jones", "Stethem", Enums.CardStatusEnum.Platinum));
            service.AddBankAccount(new BankAccount(2, "Klara", "Daniels", Enums.CardStatusEnum.Platinum));
            bool a = service.Deposit(1, 20000.0);
            a = service.Deposit(2, 10000.0);
            a = service.Deposit(2, 500.0);




        }
    }
}
