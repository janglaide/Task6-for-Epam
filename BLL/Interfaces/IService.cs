using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Get(int id);
        public Task<T> Add(T item);
    }
}
