﻿using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models.Enums;
using SmartHome.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Repository
{
    public class Repository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {
        private readonly SmartHomeDbContext dBcontext;
        private readonly DbSet<TType> dbSet;

        public Repository(SmartHomeDbContext dbContext)
        {
            this.dBcontext = dbContext;
            this.dbSet = this.dBcontext.Set<TType>();
        }

        public TType GetById(TId id)
        {
            TType entity = dbSet.Find(id);

            return entity;
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            TType entity = await dbSet.FindAsync(id);

            return entity;
        }

        public void Add(TType item)
        {
            this.dBcontext.Add(item);
            this.dBcontext.SaveChanges();
        }

        public async Task AddAysnc(TType item)
        {
            await this.dBcontext.AddAsync(item);
            await this.dBcontext.SaveChangesAsync();
        }

        public bool Delete(TId id)
        {
            TType entity = GetById(id);
            if (entity == null)
            {
                return false;
            }
            dbSet.Remove(entity);
            dBcontext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            TType entity = await GetByIdAsync(id);

            if (entity != null)
            {
                dbSet.Remove(entity);
                await dBcontext.SaveChangesAsync();
            }
            
            return true;
        }

        public IEnumerable<TType> GetAll()
        {
            return this.dbSet.ToArray();
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            return await this.dbSet.ToArrayAsync();
        }

        public IQueryable<TType> GetAllAttached()
        {
            return this.dbSet.AsQueryable();
        }

        public bool Update(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                dBcontext.Entry(item).State = EntityState.Modified;
                dBcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            } 
        }

        public async Task<bool> UpdateAysnc(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                dBcontext.Entry(item).State = EntityState.Modified;
                await dBcontext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}