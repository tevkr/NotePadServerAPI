using NotePadServerAPI.Data;
using NotePadServerAPI.Models;
using System.Collections.Generic;
using System.Linq;

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
        Purchase delPurchase(int userId, int purchaseId);
        //Deletes all user purchases
        void delUserPurchases(int userId);
    }
    public class PurchasesDAO : IPurchasesDAO
    {
        private readonly NotePadServerAPIDBContext _dbContext;
        public PurchasesDAO(NotePadServerAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void addPurchase(Purchase purchase)
        {
            _dbContext.purchases.Add(purchase);
            _dbContext.SaveChanges();
        }
        public Purchase delPurchase(int userId, int purchaseId)
        {
            var purchaseToDelete = _dbContext.purchases.Where(
                p => (p.userId == userId && p.id == purchaseId)
                ).FirstOrDefault();
            _dbContext.purchases.Remove(purchaseToDelete);
            _dbContext.SaveChanges();
            return purchaseToDelete;
        }
        public void delUserPurchases(int userId)
        {
            var purchasesToDelete =_dbContext.purchases.Where(
                p => p.userId == userId).ToList();
            _dbContext.RemoveRange(purchasesToDelete);
            _dbContext.SaveChanges();
        }
        public Purchase getPurchase(int userId, int purchaseId)
        {
            var purchase = _dbContext.purchases.Where(
                p => (p.userId == userId && p.id == purchaseId)).FirstOrDefault();
            return purchase;
        }
        public List<Purchase> getPurchases(int userId)
        {
            var purchases = _dbContext.purchases.Where(
                p => p.userId == userId).ToList();
            return purchases;
        }
    }
}
