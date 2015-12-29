using CarRental.Model.Common;
using System.Collections.Generic;

namespace CarRental.Service.Static.CSVContext.Common
{
    public interface ICSVContext<T> where T : BaseClass
    {
        void Add(T item);
        T Get(int id);
        List<T> Get();
        void Delete(int id);
    }
}