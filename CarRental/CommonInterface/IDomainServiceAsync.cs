using CarRental.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.CommonInterface
{
    public interface IDomainServiceAsync<T> where T : BaseClass
    {
        Task<T> AddAsync(T entity);

        Task<T> GetAsync(int id);

        Task<List<T>> GetAsync();

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
