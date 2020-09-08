using System;
using System.Collections.Generic;
using System.Linq;
using Seat_Booking_Sys;
using System.Globalization;



namespace Seat_Booking_Sys_Business
{
    public class Program 
    {
        public static int USERID;
        public static int GAMEID;
        public static bool userLoadingCondtion;
        static void Main()
        {
            Console.WriteLine("Main Method");
        }

        public static bool Login(string username, string password)
        {
            bool result = false;
            using (var db = new GamedayContext())
            {
                foreach (var login in db.Users)
                {
                    if (login.Username == username && login.Password == password)
                    {
                        USERID = login.UserId;
                        result = true;
                    }
                }
            }
            return result;
        }
        public static void createNewUser(string firstname, string lastname, string dob, string address, string postcode, string city, string phone, string username, string password)
        {
            using (var db = new GamedayContext())
            {
                var newUser = new Users
                {
                    FirstName = firstname,
                    SecondName = lastname,
                    BirthDate = Convert.ToDateTime(dob),
                    Address = address,
                    Postcode = postcode,
                    City = city,
                    Phone = phone,
                    Username = username,
                    Password = password
                };
                db.Users.Add(newUser);
                db.SaveChanges();
            }


        }
        public static Queue<string> searchForUser()
        {
            Queue<string> userDetails = new Queue<string>();
            using (var db = new GamedayContext())
            {
                var users = (from u in db.Users
                             where u.UserId == USERID
                             select u).FirstOrDefault();
                
                userDetails.Enqueue(users.FirstName);
                userDetails.Enqueue(users.SecondName);
                userDetails.Enqueue((users.BirthDate).ToString());
                userDetails.Enqueue(users.Address);
                userDetails.Enqueue(users.Postcode);
                userDetails.Enqueue(users.City);
                userDetails.Enqueue(users.Phone);
                userDetails.Enqueue(users.Username);
                userDetails.Enqueue(users.Password);
            }

            return userDetails;
        }
        public static void updateUserDetails(Queue<string> updatedUser)
        {
            using (var db = new GamedayContext())
            {
                var assertUser = db.Users.Where(u => u.UserId == USERID).FirstOrDefault();

                assertUser.FirstName = updatedUser.Dequeue();
                assertUser.SecondName = updatedUser.Dequeue();
                assertUser.BirthDate = Convert.ToDateTime(updatedUser.Dequeue());
                assertUser.Address = updatedUser.Dequeue();
                assertUser.Postcode = updatedUser.Dequeue();
                assertUser.City = updatedUser.Dequeue();
                assertUser.Phone = updatedUser.Dequeue();
                assertUser.Username = updatedUser.Dequeue();
                assertUser.Password = updatedUser.Dequeue();

                db.SaveChanges();
            }
        }
        public static void updateUserLogin(string username, string password)
        {
            using (var db = new GamedayContext())
            {
                var changeLogin = db.Users.Where(u => u.UserId == USERID).FirstOrDefault();
                changeLogin.Username = username;
                changeLogin.Password = password;

                db.SaveChanges();
            }
        }
        public static void deleteUser()
        {
            using (var db = new GamedayContext())
            {
                var selectUser = db.Users.Where(u => u.UserId == USERID).FirstOrDefault();
                db.Remove(selectUser);
                db.SaveChanges();
            }
        }
        public static int selectGame(string selectedGame)
        {
            using (var db = new GamedayContext())
            {
                var chosenGame = db.Opposition.Where(o => o.Opposition1 == selectedGame).FirstOrDefault();
                GAMEID = chosenGame.GameId;
                //displaySeatsForGame(GAMEID);
            }
            return GAMEID;
        }
        public static List<string> displaySeatsForGame(int game)
        {
            using (var db = new GamedayContext())
            {
                List<string> gammeSeatResult = new List<string>();
                var displaySeats = from gs in db.GameSeats
                                   where gs.GameId == game && gs.UserId == USERID
                                   join s in db.Seating on gs.SeatId equals s.SeatId
                                   select new { occupiedSEats = s.Seat };

                foreach(var item in displaySeats)
                {
                    gammeSeatResult.Add(item.occupiedSEats);
                }
                return gammeSeatResult;
            }
        }
       public static List<string> displayOccupiedSeats(int game)
        {
            using(var db = new GamedayContext())
            {
                List<string> gammeSeatResult = new List<string>();
                var displaySeats = from gs in db.GameSeats
                                   where gs.GameId == game && gs.UserId != USERID
                                   join s in db.Seating on gs.SeatId equals s.SeatId
                                   select new { occupiedSEats = s.Seat };

                foreach (var item in displaySeats)
                {
                    gammeSeatResult.Add(item.occupiedSEats);
                }
                return gammeSeatResult;
            }
        }
        public static void updateSeats(List<string> newSeats)
        {
            using (var db = new GamedayContext())
            {
                
                //remove current users seats relative to game
                var updateSeats = db.GameSeats.Where(gs => gs.GameId == GAMEID && gs.UserId == USERID);

                foreach (var item in updateSeats)
                    db.Remove(item);

                //get seat IDs
                List<int> newSeatID = new List<int>();
                foreach (var item in newSeats)
                {
                    var SeatID = db.Seating.Where(s => s.Seat == item).FirstOrDefault();

                    newSeatID.Add(SeatID.SeatId);
                }

                foreach(var item in newSeatID)
                {
                    var assignSeat = new GameSeats
                    {
                        SeatId = item,
                        GameId = GAMEID,
                        UserId = USERID
                    
                    };

                    db.GameSeats.Add(assignSeat);
                }
                db.SaveChanges();
            }
        }
        public static List<string> PopulateComboBox()
        {
            List<string> teams = new List<string>();
            using (var db = new GamedayContext())
            {
                var test = from o in db.Opposition
                           select o;

                foreach (var item in test)
                    teams.Add(item.Opposition1);
                    

            }
            return teams;
        }
        

    }

}
