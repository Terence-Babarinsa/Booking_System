using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Seat_Booking_Sys_Business;
using Seat_Booking_Sys;
using System.IO;



namespace Gameday_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

            Program.createNewUser("Sarah", "Biggins", "08/10/1997", "57 Welsh Road", "cw5 5ew", "Ceshire", "07908093711", "sarahbiggins", "jumpinjumpout");

        }

        [TearDown]
        public void Teardown()
        {
            using (var db = new GamedayContext())
            {
                var removeUser = db.Users.Where(u => u.FirstName == "Sarah");
                foreach (var item in removeUser)
                {
                    db.Users.Remove(item);
                }

                db.SaveChanges();

                var removeGameSeat = db.GameSeats.Where(gs => gs.UserId == 4);
                foreach (var item in removeGameSeat)
                {
                    db.GameSeats.Remove(item);
                }

                db.SaveChanges();
            }
        }

        [TestCase("WillBot64", "brianBrian", true)]
        [TestCase("Hemobo883", "nialNial", true)]
        [TestCase("Stale76234", "yeahYeah", true)]
        public void CorrectLogin(string username, string password, bool expected)
        {

            bool result = Program.Login(username, password);
            Assert.AreEqual(expected, result);
        }

        [TestCase("ekjbneui", "brianBrian", false)]
        [TestCase("eoirnucer", "oiuer", false)]
        [TestCase("Stale56234", "yeahYeah", false)]
        public void IncorrectLogin(string username, string password, bool expected)
        {

            bool result = Program.Login(username, password);
            Assert.AreEqual(expected, result);
        }

        [TestCase("Sarah", "Biggins", "08/10/ 1997", "57 Welsh Road", "cw5 5ew", "Ceshire", "07795054834", "sarahbiggins", "secondSarah")]
        public void InsertCorrectUserDetails(string firstname, string lastname, string dob, string address, string postcode, string city, string phone, string username, string password)
        {
            int userCount1;
            int userCount2;

            using (var db = new GamedayContext())
            {
                var count = from u in db.Users
                            select u;
                userCount1 = count.Count();
            }
            Program.createNewUser(firstname, lastname, dob, address, postcode, city, phone, username, password);

            using (var db = new GamedayContext())
            {
                var count = from u in db.Users
                            select u;
                userCount2 = count.Count();
            }

            Assert.AreEqual(userCount1 + 1, userCount2);
        }

        [TestCase("Liam", "Hemming")]
        [TestCase("William", "Babarinsa")]
        [TestCase("Dale", "Lemon")]
        public void SearchForCorrectUser(string firstName, string lastName)
        {
            //Queue<string> user = Program.searchForUser(firstName, lastName);

            //using (var db = new GamedayContext())
            //{
            //    var expectedUser = (from u in db.Users
            //                        where u.FirstName == firstName && u.SecondName == lastName
            //                        select u).FirstOrDefault();

            //    Assert.IsTrue(user.Contains(expectedUser.FirstName));
            //    Assert.IsTrue(user.Contains(expectedUser.SecondName));
            //    Assert.IsTrue(user.Contains(expectedUser.BirthDate.ToString()));
            //    Assert.IsTrue(user.Contains(expectedUser.Address));
            //    Assert.IsTrue(user.Contains(expectedUser.Postcode));
            //    Assert.IsTrue(user.Contains(expectedUser.City));
            //    Assert.IsTrue(user.Contains(expectedUser.Phone));
            //}
        }
        [Test]
        public void updateUserDeatails()
        {

            Queue<string> newUserDeatails = new Queue<string>();
            newUserDeatails.Enqueue("Sarah");
            newUserDeatails.Enqueue("Biggins");
            newUserDeatails.Enqueue("08/10/1997");
            newUserDeatails.Enqueue("57 Welsh Road");
            newUserDeatails.Enqueue("bw5 5ew");
            newUserDeatails.Enqueue("Birmingham");
            newUserDeatails.Enqueue("07795054834");

            using (var db = new GamedayContext())
            {
                var editUser = db.Users.Where(u => u.Phone == "07908093711").FirstOrDefault();

                Program.USERID = editUser.UserId;

            }

            Program.updateUserDetails(newUserDeatails);

            Queue<string> final = new Queue<string>();
            final.Enqueue("Sarah");
            final.Enqueue("Biggins");
            final.Enqueue("08/10/1997");
            final.Enqueue("57 Welsh Road");
            final.Enqueue("bw5 5ew");
            final.Enqueue("Birmingham");
            final.Enqueue("07795054834");

            using (var db = new GamedayContext())
            {
                var editedUser = db.Users.Where(u => u.UserId == Program.USERID).FirstOrDefault();

                Assert.IsTrue(final.Contains(editedUser.FirstName));
                Assert.IsTrue(final.Contains(editedUser.SecondName));
                Assert.IsTrue(final.Contains(editedUser.BirthDate.Value.ToShortDateString()));
                Assert.IsTrue(final.Contains(editedUser.Address));
                Assert.IsTrue(final.Contains(editedUser.Postcode));
                Assert.IsTrue(final.Contains(editedUser.City));
                Assert.IsTrue(final.Contains(editedUser.Phone));
            }

        }
        [TestCase("usernametest","passwordtest")]
        [TestCase("24397fhwec", "wef3f34f3ew")]
        [TestCase("2ed23d3d", "3rf54f34dwqx")]
        public void updateLoginDetails(string username, string passwrod)
        {
            
            using (var db = new GamedayContext())
            {
                var newLogin = db.Users.Where(u => u.Username == "sarahbiggins" && u.Password == "jumpinjumpout").FirstOrDefault();
                Program.USERID = newLogin.UserId;
            }

            Program.updateUserLogin(username, passwrod);

            using (var db = new GamedayContext())
            {
                var findUser = db.Users.Where(u => u.UserId == Program.USERID).FirstOrDefault();
                Assert.AreEqual(username, findUser.Username);
                Assert.AreEqual(passwrod, findUser.Password);
            }
        }
        [Test]
        public void confirmRemovedUser()
        {
            int userCount1;
                int userCount2;

            using (var db = new GamedayContext())
            {
                var firstCount = db.Users.Select(u => u);
                userCount1 = firstCount.Count();

                var removeUser = db.Users.Where(u => u.FirstName == "Sarah").FirstOrDefault();
                Program.USERID = removeUser.UserId;

                Program.deleteUser();

                var secondCount = db.Users.Select(u => u);
                userCount2 = secondCount.Count();

                Assert.AreNotEqual(userCount1, userCount2);
            }

        }
        [Test]
        public void selectSeatsForGame()
        {
            int gameID1;
            int gameID2;

            Program.selectGame("Blackheath");
            gameID1 = Program.GAMEID;

            using (var db = new GamedayContext())
            {
                var checkopp = db.Opposition.Where(o => o.Opposition1 == "Blackheath").FirstOrDefault();
                gameID2 = checkopp.GameId;
            }

            Assert.AreEqual(gameID1, gameID2);
        }
        [Test]
        public void correctSeatsDisplayed()
        {
            int bookedSeats;
            int expectedBookedSeats;

            Program.USERID = 5;
            List<string> bookSeats =  Program.displaySeatsForGame(7);
            bookedSeats = bookSeats.Count();

            using (var db = new GamedayContext())
            {
                List<string> gammeSeatResult = new List<string>();
                var displaySeats = from gs in db.GameSeats
                                   where gs.GameId == 7 && gs.UserId == 5
                                   select gs;

                expectedBookedSeats = displaySeats.Count();
                                   
            }

            Assert.AreEqual(expectedBookedSeats, bookedSeats);
        }
        [Test]
        public void correctSeatUpdate()
        {
            using (var db = new GamedayContext())
            {
                db.Add(new GameSeats
                {
                    SeatId = 28,
                    GameId = 3,
                    UserId = 4
                });
                db.SaveChanges();
            }

            Program.USERID = 4;
            Program.GAMEID = 3;

            List<string> update = new List<string> { "E6", "E7" };
            Program.updateSeats(update);

            using (var db = new GamedayContext())
            {
                var findResult = from gs in db.GameSeats
                                 where gs.GameId == 3 && gs.UserId == 4
                                 join s in db.Seating on gs.SeatId equals s.SeatId
                                 select s;
                foreach(var item in findResult)
                {
                    Assert.IsTrue(update.Contains(item.Seat));
                }
              
                
            }



        }



    }
}