using System;
using System.Collections.Generic;
using System.Text;

namespace Toolshed
{
    public static class RegexPatterns
    {
        public const string AllMajorCreditCardsGrouped = @"^(?:(?<visa>4[0-9]{12}(?:[0-9]{3})?) |(?<mastercard>5[1-5][0-9]{14}) |(?<discover>6(?:011|5[0-9][0-9])[0-9]{12}) |(?<amex>3[47][0-9]{13}) |(?<diners>3(?:0[0-5]|[68][0-9])[0-9]{11})$";
        public const string AllMajorCreditCards = @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11})$";
        public const string Email = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,}|[0-9]{1,3})(\]?)$";
        public const string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
        public const string Guid = @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$";
        public const string PascalSplit = @"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])";
    }
}
