﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountTask.Interfaces;
using BankAccountTask.Models;
using BankAccountTask.Server;

namespace BankAccountTask.Service
{
    class StandartBankAccountService : IService<BankAccount>
    {

        private IRepository<BankAccount> repository;
        private List<BankAccount> bankAccounts;
        public StandartBankAccountService(IRepository<BankAccount> repository)
        {
            this.repository = repository;
            this.bankAccounts = repository.Read();
        }




        public bool AddBankAccount(BankAccount obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
            bankAccounts.Add(obj);
            repository.AppendToEnd(obj);
            return true;

        }

        public bool DeleteBankAccount(int id)
        {
            var account = GetOne(id);
            if (account == null)
                throw new ArgumentNullException();
            bankAccounts.Remove(account);
            repository.Write(bankAccounts);
            return true;
        }

        public bool Deposit(int id, double amount)
        {
            var account = GetOne(id);
            bankAccounts.Remove(account);
            account.Amount += amount;
            account.BonusAmount = WorkWithBonus(account, amount, 0);
            bankAccounts.Add(account);
            repository.Write(bankAccounts);
            return true;

        }

        public bool Withdraw(int id, double amount)
        {

            var account = GetOne(id);
            bankAccounts.Remove(account);
            account.Amount -= amount;
            if (account.Amount <0)
            {
                account.Amount += amount;
                return false;
            }
            account.BonusAmount = WorkWithBonus(account, amount, 1);
            bankAccounts.Add(account);
            repository.Write(bankAccounts);
            return true;

        }

        protected virtual int WorkWithBonus(BankAccount obj, double amount, int format)
        {
            if (format != 0 && format != 1)
                throw new ArgumentException();
            if (format == 0)
            {
                if (obj.CardStatus == Enums.CardStatusEnum.Standart)
                    obj.BonusAmount += Convert.ToInt32((amount * 100) / 4);
                if (obj.CardStatus == Enums.CardStatusEnum.Gold)
                    obj.BonusAmount += Convert.ToInt32((amount * 100) / 3);
                if (obj.CardStatus == Enums.CardStatusEnum.Platinum)
                    obj.BonusAmount += Convert.ToInt32((amount * 100) / 2);
            }
            if (format == 1)
            {
                if (obj.CardStatus == Enums.CardStatusEnum.Standart)
                    obj.BonusAmount -= Convert.ToInt32((amount * 100) / 2.5);
                if (obj.CardStatus == Enums.CardStatusEnum.Gold)
                    obj.BonusAmount -= Convert.ToInt32((amount * 100) / 2);
                if (obj.CardStatus == Enums.CardStatusEnum.Platinum)
                    obj.BonusAmount -= Convert.ToInt32((amount * 100) / 3);
            }
            if (obj.BonusAmount < 0)
                obj.BonusAmount = 0;
            return obj.BonusAmount;
        }

        private BankAccount GetOne(int id)
        {
            try
            {
                return repository.Read().First(x => x.CardID == id);
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }
    }
}
