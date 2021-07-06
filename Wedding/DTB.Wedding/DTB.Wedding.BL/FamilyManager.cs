using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTB.Wedding.BL.Models;
using DTB.Wedding.PL;
using Microsoft.EntityFrameworkCore.Storage;

namespace DTB.Wedding.BL
{
    public class FamilyManager
    {
        public async static Task<List<Family>> Load()
        {
            try
            {
                List<Family> families = new List<Family>();
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {
                        foreach (TblFamily f in dc.TblFamilies.ToList())
                        {
                            Family family = new Family
                            {
                                Id = f.Id,
                                Name = f.Name,
                                Code = f.Code
                            };
                            families.Add(family);
                        }
                    }
                });
                return families;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async static Task<bool> Insert(Family family, bool rollback = false)
        {
            try
            {
                int results = 0;
                IDbContextTransaction transaction = null;
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        TblFamily newrow = new TblFamily
                        {
                            Id = family.Id,
                            Name = family.Name,
                            Code = family.Code
                        };

                        dc.TblFamilies.Add(newrow);
                        results = dc.SaveChanges();

                        if (rollback) transaction.Rollback();
                        
                    }
                });
                if (results > 0) return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<bool> Update(Family family, bool rollback = false )
        {
            try
            {
                int results = 0;
                IDbContextTransaction transaction = null;
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        TblFamily row = dc.TblFamilies.FirstOrDefault(u => u.Id == family.Id);

                        if (row != null)
                        {
                            row.Name = family.Name;
                            row.Code = family.Code;

                            results = dc.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        
                    }
                });
                if (results > 0) return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static async Task<bool> Delete(Guid familyId, bool rollback = false)
        {
            try
            {
                int results = 0;
                IDbContextTransaction transaction = null;
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {
                        

                        TblFamily row = dc.TblFamilies.FirstOrDefault(u => u.Id == familyId);

                        if (row != null)
                        {
                            if (rollback) transaction = dc.Database.BeginTransaction();

                            dc.TblFamilies.Remove(row);

                            results = dc.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("Row not found.");
                        }

                    }
                });
                if (results > 0) return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
