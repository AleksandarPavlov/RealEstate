namespace RealEstate.Infrastructure.Persistance.Entities;
using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;

    public class Advertiser
    {
        public long Id { get; private set; }
        public string FullName { get; private set; }
        public string ContactNumber { get; private set; }
        public string? EmailAddress { get; private set; }
        public string? SocialMediaLink { get; private set; }
        public long PropertyId { get; set; }
        public Property? Property { get; set; }
        
        public Advertiser(
            string fullName,
            string contactNumber,
            string? emailAddress,
            string? socialMediaLink
        )
        {
            FullName = fullName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            SocialMediaLink = socialMediaLink;
        }
        
         public static Result<DomainAdvertiser> ToDomain(Advertiser entity) 
        {
            return DomainAdvertiser.CreateAdvertiser
            (
                entity.Id,
                entity.FullName,
                entity.ContactNumber,
                entity.EmailAddress,
                entity.SocialMediaLink
       
            );

        }
         
         public static Result<Advertiser> FromDomain(DomainAdvertiser entity) 
         {
             return new Advertiser
             (
                 entity.FullName,
                 entity.ContactNumber,
                 entity.EmailAddress?.Value,
                 entity.SocialMediaLink
       
             );

         }
    }