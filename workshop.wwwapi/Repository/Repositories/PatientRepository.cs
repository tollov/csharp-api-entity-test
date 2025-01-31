﻿using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.Domain;

namespace workshop.wwwapi.Repository.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        DatabaseContext db;
        public PatientRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public Task<Patient> Delete(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<Patient?> Get(object id)
        {
            return await db.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.ID == (int)id);
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await db.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
        }

        public async Task<Patient> Insert(Patient entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public Task<Patient> Update(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}
