﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        TType GetById(TId id);

        Task<TType> GetByIdAsync(TId id);

        IEnumerable<TType> GetAll();
        Task<IEnumerable<TType>> GetAllAsync();

        IEnumerable<TType> GetAllAttached();

        void Add(TType item);
        Task AddAysnc(TType item);

        bool Delete(TId id);
        Task<bool> DeleteAsync(TId id);

        bool SoftDelete(TId id);

        Task<bool> SoftDeleteAsync(TId id);

        bool Update(TType item);
        Task UpdateAysnc(TType item);
    }
}
