using RealEstate.Domain.Advertiser.ValueObjects;
using RealEstate.Domain.Common.Enums;

namespace RealEstate.Domain.Advertiser;

    public class Advertiser
    {
        public long Id { get; private set; }
        public string FullName { get; private set; }
        public string ContactNumber { get; private set; }
        public AdvertiserEmailAddress? EmailAddress { get; private set; }
        public string? SocialMediaLink { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; set; }


        private Advertiser(
            long id,
            string fullName,
            string contactNumber,
            AdvertiserEmailAddress? emailAddress,
            string? socialMediaLink,
            string username,
            string password,
            Role role)
        {
            Id = id;
            FullName = fullName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            SocialMediaLink = socialMediaLink;
            Username = username;
            Password = password;
            Role = role;
        }
        
         public static Result<Advertiser> CreateAdvertiser(
            long id,
            string fullName,
            string contactNumber,
            string? emailAddress,
            string? socialMediaLink,
            string username,
            string password,
            Role role)
        {
            var emailResult = AdvertiserEmailAddress.Create(emailAddress);
            
            return emailResult.Match(
             success =>
             {
                 var advertiser = new Advertiser(
                     id, 
                     fullName,
                     contactNumber,
                     emailResult.Value,
                     socialMediaLink,
                     username,
                     password,
                     role);

                 return Result<Advertiser>.Success(advertiser);
             },
             Result<Advertiser>.Failure
         );

        }
    }