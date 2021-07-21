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
    public class TableManager
    {
        public async static Task<List<Table>> Load()
        {
            try
            {
                List<Table> tables = new List<Table>();
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {
                        foreach (TblTable t in dc.TblTables.ToList())
                        {
                            Table table = new Table
                            {
                                Id = t.Id,
                                Name = t.Name,
                                NumberChairs = t.NumberChairs

                            };
                            tables.Add(table);
                        }
                    }
                });
                return tables;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async static Task<Table> LoadById(Guid id)
        {
            try
            {
                Table table = new Table();
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {
                        foreach (TblTable t in dc.TblTables.ToList())
                        {
                            if (t.Id == id)
                            {
                                table.Id = t.Id;
                                table.Name = t.Name;
                                table.NumberChairs = t.NumberChairs;

                            };
                        }
                    }
                });
                return table;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async static Task<bool> Insert(Table table, bool rollback = false)
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

                        TblTable newrow = new TblTable
                        {
                            Id = table.Id,
                            Name = table.Name,
                            NumberChairs = table.NumberChairs
                        };

                        dc.TblTables.Add(newrow);
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

        public static async Task<bool> Update(Table table, bool rollback = false)
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

                        TblTable row = dc.TblTables.FirstOrDefault(u => u.Id == table.Id);

                        if (row != null)
                        {
                            row.Name = table.Name;
                            row.NumberChairs = table.NumberChairs;

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
        public static async Task<bool> Delete(Guid tableId, bool rollback = false)
        {
            try
            {
                int results = 0;
                IDbContextTransaction transaction = null;
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {


                        TblTable row = dc.TblTables.FirstOrDefault(u => u.Id == tableId);

                        if (row != null)
                        {
                            if (rollback) transaction = dc.Database.BeginTransaction();

                            dc.TblTables.Remove(row);

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