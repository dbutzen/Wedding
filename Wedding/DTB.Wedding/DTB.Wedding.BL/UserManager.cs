using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTB.Wedding.BL.Models;
using DTB.Wedding.PL;
using Microsoft.EntityFrameworkCore.Storage;

namespace DTB.Wedding.BL
{
    public class UserManager
    {
        public async static Task<List<User>> Load()
        {
            try
            {
                List<User> users = new List<User>();
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {
                        dc.TblUsers
                        .ToList()
                        .ForEach(u =>
                        {
                            var user = new User();
                            Fill(user, u);
                            users.Add(user);
                        });
                    }
                });
                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async static Task<User> LoadById(Guid userId)
        {
            try
            {
                var user = new User();
                await Task.Run(() =>
                {
                    using (var dc = new WeddingEntities())
                    {
                        var row = dc.TblUsers.FirstOrDefault(u => u.Id == userId);
                        if (row != null)
                        {
                            Fill(user, row);
                        }
                        else
                        {
                            throw new Exception("User could not be found");
                        }

                    }
                });

                return user;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async static Task<User> LoadBySessionKey(Guid sessionKey)
        {
            try
            {
                var user = new User();
                await Task.Run(() =>
                {
                    using (var dc = new WeddingEntities())
                    {
                        var row = dc.TblUsers.FirstOrDefault(u => u.SessionKey == sessionKey);
                        if (row != null)
                        {
                            Fill(user, row);
                        }
                        else
                        {
                            throw new Exception("User could not be found");
                        }

                    }
                });

                return user;

            }
            catch (Exception)
            {
                throw;
            }
        }



        public async static Task<bool> Insert(User user, bool rollback = false)
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
                        var row = new TblUser();

                        row.Id = user.Id;
                        row.Username = user.Username;
                        row.UniqueKey = Guid.NewGuid();
                        row.Password = ComputeSha256Hash($"{user.Password}{row.UniqueKey.ToString().ToUpper()}");
                        

                        dc.TblUsers.Add(row);
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

        public async static Task<User> LoadByUsername(string username)
        {
            try
            {
                var user = new User();
                await Task.Run(() =>
                {
                    using (var dc = new WeddingEntities())
                    {
                        var row = dc.TblUsers.FirstOrDefault(u => u.Username == username);
                        if (row != null)
                        {
                            Fill(user, row);
                        }
                        else
                        {
                            throw new Exception("User could not be found");
                        }
                    }
                });

                return user;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> Update(User user, bool rollback = false)
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

                        TblUser row = dc.TblUsers.FirstOrDefault(u => u.Id == user.Id);

                        if (row != null)
                        {
                            row.Username = user.Username;
                            if (user.SessionKey != null) row.SessionKey = user.SessionKey;
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
        public static async Task<bool> Delete(Guid userId, bool rollback = false)
        {
            try
            {
                int results = 0;
                IDbContextTransaction transaction = null;
                await Task.Run(() =>
                {
                    using (WeddingEntities dc = new WeddingEntities())
                    {


                        TblUser row = dc.TblUsers.FirstOrDefault(u => u.Id == userId);

                        if (row != null)
                        {
                            if (rollback) transaction = dc.Database.BeginTransaction();

                            dc.TblUsers.Remove(row);

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

        public static async Task<Guid> Login(User user, bool logoutOtherDevices = false, bool rollback = false)
        {
            try
            {
                var results = Guid.Empty;
                await Task.Run(() =>
                {
                    using (var dc = new WeddingEntities())
                    {
                        var row = dc.TblUsers.FirstOrDefault(u => u.Username == user.Username);
                        if (row != null)
                        {
                            var hashed_password = ComputeSha256Hash($"{user.Password}{row.UniqueKey.ToString().ToUpper()}");

                            if (hashed_password == row.Password)
                            {
                                Fill(user, row);
                                user.SessionKey = row.SessionKey;
                                if (logoutOtherDevices || user.SessionKey == null)
                                {
                                    user.SessionKey = Guid.NewGuid();
                                    var task = Update(user, rollback);
                                    task.Wait();
                                }
                                results = (Guid)user.SessionKey;
                            }
                        }
                    }
                });

                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<int> ChangePassword(User user, string newPassword, bool rollback = false)
        {
            try
            {
                var results = 0;
                await Task.Run(() =>
                {
                    using (var dc = new WeddingEntities())
                    {
                        IDbContextTransaction transaction = null;

                        if (rollback) transaction = dc.Database.BeginTransaction();


                        var row = dc.TblUsers.FirstOrDefault(u => u.Id == user.Id);
                        if (row != null)
                        {
                            var hashed_password = ComputeSha256Hash($"{user.Password}{row.UniqueKey.ToString().ToUpper()}");

                            if (hashed_password == row.Password)
                            {
                                if (!string.IsNullOrEmpty(newPassword.Trim()))
                                {
                                    row.UniqueKey = Guid.NewGuid();
                                    row.Password = ComputeSha256Hash($"{newPassword}{row.UniqueKey.ToString().ToUpper()}");


                                    results = dc.SaveChanges();

                                    if (rollback) transaction.Rollback();
                                }
                                else
                                {
                                    throw new Exception("New password can't be blank.");
                                }
                            }
                            else
                            {
                                throw new Exception("Old password is incorrect.");
                            }
                        }
                        else
                        {
                            throw new Exception("User could not be found.");
                        }
                    }
                });

                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private static void Fill(User user, TblUser row)
        {
            user.Id = row.Id;
            user.Username = row.Username;
            user.Password = row.Password;
            user.SessionKey = row.SessionKey;
            user.UniqueKey = row.UniqueKey;
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using (var sha = SHA256.Create())
            {
                var data = sha.ComputeHash(Encoding.Unicode.GetBytes(rawData));
                var builder = new StringBuilder();
                foreach (var d in data)
                {
                    builder.Append(d.ToString("X2"));
                }
                return builder.ToString();
            }
        }
    }
}