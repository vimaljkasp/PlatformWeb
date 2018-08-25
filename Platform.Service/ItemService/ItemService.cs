using Platform.DTO;
using Platform.Repository;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class ItemService : IItemService,IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork();


        public void AddItemCategory(ItemCategoryDTO itemDTO)
        {
          
            ItemCategory itemCategory = new ItemCategory();

            ItemConvertor.ConvertToItemCategoryEntity(ref itemCategory, itemDTO, false);
            unitOfWork.ItemRepository.Add(itemCategory);
        }

        public void DeleteItemCategory(int itemId)
        {
            unitOfWork.ItemRepository.Delete(itemId);
        }

        public List<ItemCategoryDTO> GetAllItemCategory()
        {
            List<ItemCategoryDTO> itemCategoryList = new List<ItemCategoryDTO>();
            var itemCategories = unitOfWork.ItemRepository.GetAll();
            if (itemCategories != null)
            {
                foreach (var itemCategory in itemCategories)
                {
                    itemCategoryList.Add(ItemConvertor.ConvertToItemCategoryDto(itemCategory));
                }

            }

            return itemCategoryList;
        }

        public ItemCategoryDTO GetItemCategoryById(int itemId)
        {
            ItemCategoryDTO itemCategoryDTO = null;
            var itemCategory = unitOfWork.ItemRepository.GetById(itemId);
            if (itemCategory != null)
            {
                itemCategoryDTO = ItemConvertor.ConvertToItemCategoryDto(itemCategory);
            }
            return itemCategoryDTO;
        }

        public void UpdateItemCategory(ItemCategoryDTO itemCategoryDTO)
        {
            ItemCategory itemCategory = new ItemCategory();
            ItemConvertor.ConvertToItemCategoryEntity(ref itemCategory, itemCategoryDTO, true);
            unitOfWork.ItemRepository.Update(itemCategory);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (unitOfWork != null)
                {
                    unitOfWork.Dispose();
                    unitOfWork = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
