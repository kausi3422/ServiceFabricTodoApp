using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoSFService.Interface;
using TodoSFService.Model;

namespace TodoSFService.Service
{
    public class TodoService
    {
        private readonly IRepository<Item> _item;

        public TodoService(IRepository<Item> item)
        {
            _item = item;
        }


        //Get Item Details By Item Id
        public IEnumerable<Item> GetItemByUserId(long ItemId)
        {
            return _item.GetAll().Where(x => x.id == ItemId).ToList();
        }


        //GET All Item Details 
        public IEnumerable<Item> GetAllItems()
        {
            try
            {
                return _item.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Get Item by Item Name
        public Item GetItemByItemName(string ItemName)
        {
            return _item.GetAll().Where(x => x.taskName == ItemName).FirstOrDefault();
        }


        //Add Item
        public async Task<Item> AddItem(Item Item)
        {
            return await _item.Create(Item);
        }


        //Delete Item 
        public bool DeleteItembyItemName(string ItemName)
        {

            try
            {
                var DataList = _item.GetAll().Where(x => x.taskName == ItemName).ToList();
                foreach (var item in DataList)
                {
                    _item.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }


        //Update Item Details
        public bool UpdateItem(Item item)
        {
            try
            {
                var DataList = _item.GetAll().Where(x => x.taskName != null).ToList();
                foreach (var i in DataList)
                {
                    _item.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
