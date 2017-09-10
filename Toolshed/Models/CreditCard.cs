using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Toolshed
{
    public class CreditCard
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardNumber { get; set; }
        public string SecurityCode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string GetLastFourDigits()
        {
            if (IsCreditCardNumberValid())
            {
                return CreditCardNumber.Substring(CreditCardNumber.Length - 4);
            }

            return string.Empty;
        }
        public bool IsCreditCardNumberValid()
        {
            if (string.IsNullOrEmpty(CreditCardNumber))
            {
                return false;
            }

            CreditCardNumber = CreditCardNumber.RemoveNonNumbers();
            Regex r = new Regex(RegexPatterns.AllMajorCreditCards, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return r.IsMatch(CreditCardNumber);
        }
        public bool IsExpirationDateValid()
        {
            if (ExpirationDate == DateTime.MinValue || ExpirationDate == DateTime.MaxValue)
            {
                return false;
            }

            if (ExpirationDate < DateTime.Today.StartOfMonth())
            {
                return false;
            }

            //I've never seen an expiration date more than 5 years out, so kick it back
            //DONE: researched, not actual limit. most limit to 20 - 25 years, we'll go with that
            if (ExpirationDate > DateTime.Today.AddYears(25))
            {
                return false;
            }

            return true;
        }
        public CreditCardType GetCardType()
        {
            if (!IsCreditCardNumberValid())
            {
                return CreditCardType.Unknown;
            }

            switch (CreditCardNumber[0])
            {
                case '4':
                    return CreditCardType.Visa;
                case '5':
                    return CreditCardType.MasterCard;
                case '6':
                    return CreditCardType.Discover;
                case '3':
                    switch (CreditCardNumber[1])
                    {
                        case '4':
                        case '7':
                            return CreditCardType.AmericanExpress;
                        case '0':
                            return CreditCardType.Diners;
                    }
                    break;
            }

            return CreditCardType.Unknown;
        }
    }

}
