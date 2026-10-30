using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using System;

namespace EF005.SetupEFCoreModel
{
    class Program
    {

        public static void RetreiveData()
        {
            using (var context = new AppDbContext())
            {
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
        }

        public static void RetreiveSingleItem()
        {
            var itemIdToRetreive = 4;

            using (var context = new AppDbContext())
            {
                var wallet = context.Wallets.FirstOrDefault(x => x.Id == itemIdToRetreive);
                Console.WriteLine(wallet);
            }
        }

        public static void AddData()
        {
            var wallet = new Wallet
            {
                Holder = "Nissrine",
                Balance = 2500.00M
            };

            using (var context = new AppDbContext())
            {
                context.Wallets.Add(wallet);
                context.SaveChanges();
            }
        }

        public static void UpdateData()
        {
            using (var context = new AppDbContext())
            {
                var wallet = context.Wallets.Single(x => x.Id == 1);

                wallet.Balance += 1000;

                context.SaveChanges();
            }
        }

        public static void DeleteData()
        {
            using (var context = new AppDbContext())
            {
                var wallet = context.Wallets.Single(x => x.Id == 3);
                context.Wallets.Remove(wallet);
                context.SaveChanges();
            }
        }

        public static void QueryData()
        {
            using (var context = new AppDbContext())
            {
                var result = context.Wallets.Where(x => x.Balance > 2000);

                foreach (var wallet in result)
                {
                    Console.WriteLine(wallet);
                }
            }
        }

        public static void Transaction()
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var fromWallet = context.Wallets.Single(x => x.Id == 1);

                    var toWallet = context.Wallets.Single(x => x.Id == 2);

                    var amountToTransfer = 500.00M;

                    fromWallet.Balance -= amountToTransfer;
                    context.SaveChanges();

                    toWallet.Balance += amountToTransfer;
                    context.SaveChanges();

                    transaction.Commit();
                }
            }
        }
        static void Main(string[] args)
        {
            //RetreiveData();
            //RetreiveSingleItem();
            //AddData();  
            //UpdateData();
            //DeleteData();
            //QueryData();*
            Transaction();
            Console.ReadKey();
        }
    }
}