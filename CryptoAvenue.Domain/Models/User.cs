using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Domain.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public bool PrivateProfile { get; set; } = false;

        #region Nav Properties 
        public ICollection<TradeOffer> OffersSent { get; set; } = new List<TradeOffer>();
        public ICollection<TradeOffer> OffersReceived { get; set; } = new List<TradeOffer>();

        
        #endregion

        #region ToString()
        public override string ToString()
        {
            return $"Email: {Email}\nPassword: {Password}\nAge: {Age}\nUserID: {Id}\nSecurity Question: {SecurityQuestion}\nSecurity Answer: {SecurityAnswer}\nPrivate profile:{PrivateProfile}\n";
        }
        #endregion

        #region Equals and GetHashCode
        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   Id.Equals(user.Id) &&
                   Email == user.Email &&
                   Password == user.Password &&
                   Age == user.Age &&
                   SecurityQuestion == user.SecurityQuestion &&
                   SecurityAnswer == user.SecurityAnswer &&
                   PrivateProfile == user.PrivateProfile &&
                   EqualityComparer<ICollection<TradeOffer>>.Default.Equals(OffersSent, user.OffersSent) &&
                   EqualityComparer<ICollection<TradeOffer>>.Default.Equals(OffersReceived, user.OffersReceived);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Email);
            hash.Add(Password);
            hash.Add(Age);
            hash.Add(SecurityQuestion);
            hash.Add(SecurityAnswer);
            hash.Add(PrivateProfile);
            hash.Add(OffersSent);
            hash.Add(OffersReceived);
            return hash.ToHashCode();
        }
        #endregion
    }
}
