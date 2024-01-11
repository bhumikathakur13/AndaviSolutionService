using AndaviSolutionService.Models;

namespace AndaviSolutionService.Services
{
    public interface IItemService
    {
        int Add(Item item);
        int Update(Item item);
        int Delete(Item item);
    }
}
