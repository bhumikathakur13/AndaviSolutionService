using AndaviSolutionService.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AndaviSolutionService.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemDbContext _dbContext;

        public ItemService(ItemDbContext itemDbContext)
        {
            _dbContext = itemDbContext;
        }
        public int Add(Item item)
        {
            var result = _dbContext.Database
           .ExecuteSqlRaw(
               "EXEC AddItem @Name, @Description, @CreatedBy, @CreatedDate",
               new SqlParameter("@Name", item.Name),
               new SqlParameter("@Description", item.Description),
               new SqlParameter("@CreatedBy", item.CreatedBy),
               new SqlParameter("@CreatedDate", item.CreatedDate));

            return result;
        }

        public int Update(Item item)
        {
            var result = _dbContext.Database
           .ExecuteSqlRaw(
               "EXEC UpdateItem @Name, @Description, @ModifiedBy, @ModifiedDate",
               new SqlParameter("@Name", item.Name),
               new SqlParameter("@Description", item.Description),
               new SqlParameter("@ModifiedBy", item.CreatedBy),
               new SqlParameter("@ModifiedDate", item.CreatedDate));

            return result;
        }

        public int Delete(Item item)
        {
            var result = _dbContext.Database
           .ExecuteSqlRaw(
               "EXEC DeleteItem @Name",
               new SqlParameter("@Name", item.Name));

            return result;
        }
    }
}
