using System;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestbank.Data
{
    public class TestbankDbService
    {
        private readonly TestbankDbContext tbdbContext;

        public TestbankDbService(TestbankDbContext tbContext)
        {
            tbdbContext = tbContext;
        }

        // Get List of Testbanks
        public async Task<List<Testbank>> GetAllTestbanksAsync()
        {
            return await tbdbContext.Testbanks.ToListAsync();
        }

        // Insert a Testbank
        public async Task<bool> InsertTestbankAsync(Testbank tb)
        {
            await tbdbContext.Testbanks.AddAsync(tb);
            await tbdbContext.SaveChangesAsync();
            return true;
        }

        // Get a Testbank by Id
        public async Task<Testbank?> GetTestbankAsync(int Id)
        {
            Testbank? tb = await tbdbContext.Testbanks.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return tb;
        }
        
        // Update a Testbank
        public async Task<bool> UpdateTestbankAsync(Testbank tb)
        {
            tbdbContext.Testbanks.Update(tb);
            await tbdbContext.SaveChangesAsync();
            return true;
        }

        // Delete a Testbank
        public async Task<bool> DeleteTestbankAsync(Testbank tb)
        {
            tbdbContext.Remove(tb);
            await tbdbContext.SaveChangesAsync();
            return true;
        }
    }
}
