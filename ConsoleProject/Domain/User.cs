
using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Domain
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Guid UserID { get; set; } = Guid.NewGuid();
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public bool PrivateProfile { get; set; } = false;
        public User(string email, string password, int age, string securityQuestion, string securityAnswer)
        {
            Email = email;
            Password = password;
            Age = age;
            SecurityQuestion = securityQuestion;
            SecurityAnswer = securityAnswer;
        }
        public User(string email, string password, int age, string securityQuestion, string securityAnswer, bool privateProfile) : this(email, password, age, securityQuestion, securityAnswer)
        {
            PrivateProfile = privateProfile;
        }
        public override string ToString()
        {
            return $"Email: {Email}\nPassword: {Password}\nAge: {Age}\nUserID: {UserID}\nSecurity Question: {SecurityQuestion}\nSecurity Answer: {SecurityAnswer}\nPrivate profile:{PrivateProfile}\n";
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Email == user.Email &&
                   Password == user.Password &&
                   Age == user.Age &&
                   UserID.Equals(user.UserID) &&
                   SecurityQuestion == user.SecurityQuestion &&
                   SecurityAnswer == user.SecurityAnswer &&
                   PrivateProfile == user.PrivateProfile &&
                   EqualityComparer<ICollection<TradeOffer>>.Default.Equals(OffersSent, user.OffersSent) &&
                   EqualityComparer<ICollection<TradeOffer>>.Default.Equals(OffersReceived, user.OffersReceived);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Email);
            hash.Add(Password);
            hash.Add(Age);
            hash.Add(UserID);
            hash.Add(SecurityQuestion);
            hash.Add(SecurityAnswer);
            hash.Add(PrivateProfile);
            hash.Add(OffersSent);
            hash.Add(OffersReceived);
            return hash.ToHashCode();
        }
        #region Nav Properties 
        public ICollection<TradeOffer> OffersSent { get; set; } = new List<TradeOffer>();
        public ICollection<TradeOffer> OffersReceived { get; set; } = new List<TradeOffer>();
        #endregion
    }
}
