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
    public class GuestManager
    {
        public async static Task<List<Guest>> Load()
        {
            try
            {
                List<Guest> guests = new List<Guest>();
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {
                        foreach (TblGuest f in dc.TblGuests.ToList())
                        {
                            Guest guest = new Guest
                            {
                                Id = f.Id,
                                Name = f.Name,
                                FamilyId = f.FamilyId,
                                TableId = f.TableId,
                                PlusOne = f.PlusOne,
                                Attendance = f.Attendance,
                                PlusOneAttendance = f.PlusOneAttendance,
                                Responded = f.Responded

                            };
                            guests.Add(guest);
                        }
                    }
                });
                return guests;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async static Task<bool> Insert(Guest guest, bool rollback = false)
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

                        TblGuest newrow = new TblGuest
                        {
                            Id = guest.Id,
                            Name = guest.Name,
                            Attendance = guest.Attendance,
                            FamilyId = guest.FamilyId,
                            TableId = guest.TableId,
                            PlusOne = guest.PlusOne,
                            PlusOneAttendance = guest.PlusOneAttendance,
                            Responded = guest.Responded
                        };

                        dc.TblGuests.Add(newrow);
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

        public static async Task<bool> Update(Guest guest, bool rollback = false)
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

                        TblGuest row = dc.TblGuests.FirstOrDefault(u => u.Id == guest.Id);

                        if (row != null)
                        {
                            row.Name = guest.Name;
                            row.FamilyId = guest.FamilyId;
                            row.TableId = guest.TableId;
                            row.PlusOne = guest.PlusOne;
                            row.Attendance = guest.Attendance;
                            row.PlusOneAttendance = guest.PlusOneAttendance;
                            row.Responded = guest.Responded;

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
        public static async Task<bool> Delete(Guid guestId, bool rollback = false)
        {
            try
            {
                int results = 0;
                IDbContextTransaction transaction = null;
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {


                        TblGuest row = dc.TblGuests.FirstOrDefault(u => u.Id == guestId);

                        if (row != null)
                        {
                            if (rollback) transaction = dc.Database.BeginTransaction();

                            dc.TblGuests.Remove(row);

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
