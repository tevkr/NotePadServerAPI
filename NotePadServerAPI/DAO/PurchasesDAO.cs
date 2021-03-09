using NotePadServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotePadServerAPI.DAO
{
    public interface IPurchasesDAO
    {
        //Returns a list of all the user's purchases
        List<Purchase> getPurchases(int userId);
        //Returns a specific user purchase
        Purchase getPurchase(int userId, int purchaseId);
        //Adds a purchase to the database
        void addPurchase(Purchase purchase);
        //Deletes a purchase from the database
        void delPurchase(int userId, int purchaseId);
        //Deletes all user purchases
        void delUserPurchases(int userId);
    }
    public class PurchasesDAO : IPurchasesDAO
    {
        private static uint PURCHASES_COUNT;
        private List<Purchase> purchases;
        public PurchasesDAO()
        {
            //In the near future there will be a DB
            purchases = new List<Purchase>();
            DateTime date1 = new DateTime(2015, 7, 20, 18, 30, 25);
            purchases.Add(new Purchase(0, PURCHASES_COUNT++, date1, "name1", 35.2));
            purchases.Add(new Purchase(0, PURCHASES_COUNT++, date1, "name2", 22));
            purchases.Add(new Purchase(2, PURCHASES_COUNT++, date1, "name3", 0.15));
            purchases.Add(new Purchase(2, PURCHASES_COUNT++, date1, "name4", 1000023));
            purchases.Add(new Purchase(0, PURCHASES_COUNT++, date1, "name5", 323232));
        }
        public void addPurchase(Purchase purchase)
        {
            purchase.id = PURCHASES_COUNT++;
            purchases.Add(purchase);
        }
        public void delPurchase(int userId, int purchaseId)
        {
            purchases.RemoveAll(p => (p.id == purchaseId && p.userId == userId));
        }
        public void delUserPurchases(int userId)
        {
            purchases.RemoveAll(p => p.userId == userId);
        }
        public Purchase getPurchase(int userId, int purchaseId)
        {
            return purchases.Find(p => (p.id == purchaseId && p.userId == userId));
        }
        public List<Purchase> getPurchases(int userId)
        {
            return purchases.FindAll(p => (p.userId == userId));
        }
    }
}
