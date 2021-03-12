using NotePadServerAPI.Data;
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
        private readonly NotePadServerAPIDBContext _dbContext;
        private static int getLastId(NotePadServerAPIDBContext context)
        {
            if (context.purchases.ToList().FirstOrDefault() == null)
                return 1;
            else
                return context.purchases.ToList().Last().id + 1;
        }
        public PurchasesDAO(NotePadServerAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void addPurchase(Purchase purchase)
        {
            purchase.id = getLastId(_dbContext);
            _dbContext.purchases.Add(purchase);
            _dbContext.SaveChanges();
        }
        public void delPurchase(int userId, int purchaseId)
        {
            foreach (Purchase p in _dbContext.purchases.ToList())
            {
                if (p.userId == userId && p.id == purchaseId)
                {
                    _dbContext.purchases.Remove(p);
                    break;
                }
            }
            _dbContext.SaveChanges();
        }
        public void delUserPurchases(int userId)
        {
            foreach (Purchase p in _dbContext.purchases.ToList())
            {
                if (p.userId == userId)
                    _dbContext.purchases.Remove(p);
            }
            _dbContext.SaveChanges();
        }
        public Purchase getPurchase(int userId, int purchaseId)
        {
            foreach (Purchase p in _dbContext.purchases.ToList())
            {
                if (p.userId == userId && p.id == purchaseId)
                {
                    return p;
                    break;
                }
            }
            return null;
        }
        public List<Purchase> getPurchases(int userId)
        {
            List<Purchase> purchases = new List<Purchase>();

            foreach (Purchase p in _dbContext.purchases.ToList())
            {
                if (p.userId == userId)
                    purchases.Add(p);
            }
            return purchases;
        }
    }
}
