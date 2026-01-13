using System.Net.Mail;
using RealEstate.Domain.Common.Errors;

namespace RealEstate.Domain.Advertiser.ValueObjects;

    public class AdvertiserEmailAddress
    {
        private AdvertiserEmailAddress(string? value)
        {
            Value = value;
        }
        public string? Value { get; }
        
        public static Result<AdvertiserEmailAddress> Create(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) { 
                return Result<AdvertiserEmailAddress>.Success(new AdvertiserEmailAddress(null));
            }
            return IsEmailAddressValid(value)
                ? Result<AdvertiserEmailAddress>.Success(new AdvertiserEmailAddress(value))
                : Result<AdvertiserEmailAddress>.Failure(new Error("AdvertiserEmailAddress",
                $"Invalid value '{value}' for AdvertiserEmailAddress"));
        }
        public override string? ToString()
        {
            return Value;
        }

        private static bool IsEmailAddressValid(string value)
        {
            try
            {
                _ = new MailAddress(value);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }   
        }
    }