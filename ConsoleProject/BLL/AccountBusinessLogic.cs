using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class AccountBusinessLogic
    {
        public static void DisplayPrivacy(User user)
        {
            if (user.PrivateProfile == true)
                Console.WriteLine("Profile type:   PRIVATE");
            else
                Console.WriteLine("Profile type:   PUBLIC");
        }
        public static void ChangeProfileType(User user)
        {
            var db = new CryptoAvenueContext();

            Console.WriteLine("Press 1 to make your profile");
            if (user.PrivateProfile == false)
                Console.WriteLine("Public");
            else
                Console.WriteLine("Private");

            user.PrivateProfile = !user.PrivateProfile;
            db.Update(user);

            db.SaveChanges();
        }
        public static void UpdateUserEmail(User user, string email)
        {
            var db = new CryptoAvenueContext();

            var found = db.Users.Where(x => x == user).FirstOrDefault();
            found.Email = email;

            db.SaveChanges();
        }
        public static void UpdateUserPassword(User user, string password)
        {
            var db = new CryptoAvenueContext();
            var found = db.Users.Where(x => x == user).FirstOrDefault();

            found.Password = password;

            db.SaveChanges();
        }
        public static void UpdateUserQnA(User user, string question, string answer)
        {
            var db = new CryptoAvenueContext();
            var found = db.Users.Where(x => x == user).FirstOrDefault();

            found.SecurityQuestion = question;
            found.SecurityAnswer = answer;

            db.SaveChanges();
        }
    }
}
