using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoSFService.Data;
using TodoSFService.Interface;
using TodoSFService.Model;

namespace TodoSFService.Repository
{
    public class RepositoryItem : IRepository<Item>
    {

        ApplicationDbContext _dbContext;
        public RepositoryItem(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Item> Create(Item _object)
        {
            var obj = await _dbContext.Items.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Item _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Item> GetAll()
        {
            try
            {
                return _dbContext.Items.Where(x => x.taskName != null).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Item GetById(int Id)
        {
            return _dbContext.Items.Where(x => x.taskName != null && x.id == Id).FirstOrDefault();
        }

        public void Update(Item _object)
        {
            _dbContext.Items.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
