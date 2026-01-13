namespace RealEstate.Infrastructure.Persistance.Entities;

using RealEstate.Domain.Common.Enums;
using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;

    public class Advertiser
    {
        public long Id { get; private set; }
        public string FullName { get; private set; }
        public string ContactNumber { get; private set; }
        public string? EmailAddress { get; private set; }
        public string? SocialMediaLink { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public long PropertyId { get; set; }
        public ICollection<Property> Properties { get; set; } = new List<Property>();
        public Role Role { get; set; } = Role.USER;

        public Advertiser(
            string fullName,
            string contactNumber,
            string? emailAddress,
            string? socialMediaLink,
            string username,
            string password,
            Role role
        )
        {
            FullName = fullName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            SocialMediaLink = socialMediaLink;
            Username = username;
            Password = password;
            Role = role;
        }
        
         public static Result<DomainAdvertiser> ToDomain(Advertiser entity) 
         {
            return DomainAdvertiser.CreateAdvertiser
            (
                entity.Id,
                entity.FullName,
                entity.ContactNumber,
                entity.EmailAddress,
                entity.SocialMediaLink,
                entity.Username,
                entity.Password,
                entity.Role
            );

         }
         
         public static Result<Advertiser> FromDomain(DomainAdvertiser entity) 
         {
             return new Advertiser
             (
                 entity.FullName,
                 entity.ContactNumber,
                 entity.EmailAddress?.Value,
                 entity.SocialMediaLink,
                 entity.Username,
                 entity.Password,
                 entity.Role
             );

         }
    }