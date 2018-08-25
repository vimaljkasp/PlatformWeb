using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Platform.Sql;

namespace Platform.Repository
{
    public class ItemRepository 
    {


        PlatformDBEntities _repository;
        public ItemRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }
        public List<ItemCategory> GetAll()
        {

            List<ItemCategory> itemList = new List<ItemCategory>();
            itemList = _repository.ItemCategories.ToList<Sql.ItemCategory>();


            return itemList;
        }

        public ItemCategory GetById(int itemId)
        {
            ItemCategory item = new ItemCategory();

            item = _repository.ItemCategories.FirstOrDefault(x => x.ItemId == itemId);



            return item;
        }


        public void Add(ItemCategory item)
        {

            if (item != null)
            {
                _repository.ItemCategories.Add(item);
            //    _repository.SaveChanges();

            }




        }

        public void Update(ItemCategory item)
        {

            if (item != null)
            {
                _repository.Entry<Sql.ItemCategory>(item).State = System.Data.Entity.EntityState.Modified;
             //   _repository.SaveChanges();

            }


        }

        public void Delete(int itemId)
        {
            var item = _repository.ItemCategories.Where(x => x.ItemId == itemId).FirstOrDefault();
            if (item != null)
                _repository.ItemCategories.Remove(item);

//_repository.SaveChanges();

        }

        


    }
}
