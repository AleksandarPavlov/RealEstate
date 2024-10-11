using RealEstate.Domain.Advertiser.ValueObjects;

namespace RealEstate.Domain.Advertiser;

    public class Advertiser
    {
        public long Id { get; private set; }
        public string FullName { get; private set; }
        public string ContactNumber { get; private set; }
        public AdvertiserEmailAddress? EmailAddress { get; private set; }
        public string? SocialMediaLink { get; private set; }

        private Advertiser(
            long id,
            string fullName,
            string contactNumber,
            AdvertiserEmailAddress? emailAddress,
            string? socialMediaLink)
        {
            Id = id;
            FullName = fullName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            SocialMediaLink = socialMediaLink;
        }
        
         public static Result<Advertiser> CreateAdvertiser(
            long id,
            string fullName,
            string contactNumber,
            string? emailAddress,
            string? socialMediaLink)
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
                     socialMediaLink);

                 return Result<Advertiser>.Success(advertiser);
             },
             Result<Advertiser>.Failure
         );

        }
    }