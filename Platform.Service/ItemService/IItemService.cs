using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface IItemService
    {
         List<ItemCategoryDTO> GetAllItemCategory();

        ItemCategoryDTO GetItemCategoryById(int itemId);

        void AddItemCategory(ItemCategoryDTO customerDto);

        void UpdateItemCategory(ItemCategoryDTO customerDto);

        void DeleteItemCategory(int itemId);






    }
}
