using Orm_Entity.Data.DAL;
using Orm_Entity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orm_Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            BP_StadionDbContext dbContext = new BP_StadionDbContext();
            string answer;
            do
            {
                Console.WriteLine("======MENU======");
                Console.WriteLine("1. Stadion elave et\n2.Stadionları göster\n3.Verilmiş id - li stadionu göster\n4.Verilmiş id - li stadionu sil\n5.İstifadeçi elave et\n6.İstifadeçileri göster\n7.Rezervasiya yarat\n8.Rezervasiyalari goster\n9.Verilmiş id - li stadionun rezervasiyalarını göster\n0.Proqramdan cix");
                Console.WriteLine("seciminizi edin:");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("stadionun adini daxil edin: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("stadionun saatliq qiymetini daxil edin: ");
                        decimal hourlyPrice = GetDecimal();
                        Console.WriteLine("stadionun capacity'sini daxil edin: ");
                        int capacity = GetInt();
                        Stadion stadion = new Stadion()
                        {
                            Name = name,
                            HourlyPrice = hourlyPrice,
                            Capacity = capacity
                        };
                        dbContext.Stadions.Add(stadion);
                        dbContext.SaveChanges();
                        break;
                    case "2":
                        List<Stadion> data = dbContext.Stadions.ToList();
                        foreach (var item in data)
                        {
                            Console.WriteLine($"id: {item.Id} - name: {item.Name} - capacity: {item.Capacity} - hourlyPrice: {item.HourlyPrice}");
                        }
                        break;
                    case "3":
                        Console.WriteLine("id daxil edin: ");
                        int id = GetInt();
                        var result = dbContext.Stadions.Find(id);
                        if (result != null)
                        {
                            Console.WriteLine($"id: {result.Id} - name: {result.Name} - capacity: {result.Capacity} - hourlyPrice: {result.HourlyPrice}");
                        }
                        else
                        {
                            Console.WriteLine($"bu id'li stadion yoxdur");
                        }
                        break;
                    case "4":
                        Console.WriteLine("id daxil edin: ");
                        int idForRemove = GetInt();
                        var dataForRemove = dbContext.Stadions.Find(idForRemove);
                        if (dataForRemove!= null)
                        {
                            dbContext.Stadions.Remove(dataForRemove);
                        }
                        dbContext.SaveChanges();
                        break;
                    case "5":
                        Console.WriteLine("userin adini ve soyadini daxil edin: ");
                        string fullname = Console.ReadLine();
                        Console.WriteLine("userin emailini daxil edin: ");
                        string email = Console.ReadLine();
                        User user = new User()
                        {
                            Fullname = fullname,
                            Email = email
                        };
                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                        break;
                    case "6":
                        List<User> userData = dbContext.Users.ToList();
                        foreach (var item in userData)
                        {
                            Console.WriteLine($"id: {item.Id} - fullname: {item.Fullname} - email: {item.Email}");
                        }
                        break;
                    case "7":
                        Console.WriteLine("reservasiyanin baslama saatini daxil edin: ");
                        DateTime startDate = GetDatetime();
                        Console.WriteLine("reservasiyanin bitme saatini daxil edin: ");
                        DateTime endDate = GetDatetime();
                        Console.WriteLine("stadionId daxil edin: ");
                        int stadionId = GetStadionId(dbContext);
                        Console.WriteLine("userId daxil edin: ");
                        int userId = GetUserId(dbContext);
                        Reservation reservation = new Reservation()
                        {
                            StadionId = stadionId,
                            UserId = userId,
                            StartDate = startDate,
                            EndDate = endDate
                        };
                        dbContext.Reservations.Add(reservation);
                        dbContext.SaveChanges();
                        break;
                    case "8":
                        List<Reservation> reservations = dbContext.Reservations.ToList();
                        foreach (var item in reservations)
                        {
                            Console.WriteLine($"userId: {item.UserId} - stadionId: {item.StadionId} - startdate: {item.StartDate} - enddate: {item.EndDate}");
                        }
                        break;
                    case "9":
                        Console.WriteLine("istediyiniz stadionun id'sini daxil edin: ");
                        int stadionIdForSearch = GetStadionId(dbContext);
                        List<Reservation> stadionReserv = dbContext.Reservations.Where(x => x.StadionId == stadionIdForSearch).ToList();
                        foreach (var item in stadionReserv)
                        {
                            Console.WriteLine($"userId: {item.UserId} - stadionId: {item.StadionId} - startdate: {item.StartDate} - enddate: {item.EndDate}");
                        }
                        break;
                    case "0":
                        Console.WriteLine("proqram bitdi");
                        break;
                    default:
                        Console.WriteLine("menuda bele secim yoxdur");
                        break;
                }
            } while (answer != "0");
        }

        static decimal GetDecimal()
        {
            string decStr = Console.ReadLine();
            decimal dec;
            while (!decimal.TryParse(decStr, out dec))
            {
                Console.WriteLine("eded daxil edin");
                decStr = Console.ReadLine();
            }
            return dec;
        }
        static int GetInt()
        {
            string intStr = Console.ReadLine();
            int number;
            while (!int.TryParse(intStr, out number))
            {
                Console.WriteLine("eded daxil edin");
                intStr = Console.ReadLine();
            }
            return number;
        }
        static DateTime GetDatetime()
        {
            string dateTimeStr = Console.ReadLine();
            DateTime date;
            while (!DateTime.TryParse(dateTimeStr, out date))
            {
                Console.WriteLine("tarix daxil edin");
                dateTimeStr = Console.ReadLine();
            }
            return date;
        }

        static int GetStadionId(BP_StadionDbContext dbContext)
        {
            int id = GetInt();
            while (dbContext.Stadions.Find(id) == null)
            {
                Console.WriteLine("bu id'de stadion yoxdur. Yeni deyer daxil edin");
                id = GetInt();
            }
            return id;
        }
        static int GetUserId(BP_StadionDbContext dbContext)
        {
            int id = GetInt();
            while (dbContext.Users.Find(id) == null)
            {
                Console.WriteLine("bu id'de user yoxdur. Yeni deyer daxil edin");
                id = GetInt();
            }
            return id;
        }
    }
}
