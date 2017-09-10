using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Toolshed
{
    public static class NetMail
    {
        /// <summary>
        /// Adds all valid email addresses from the list provided. If an address is found not to be valid it is not added
        /// </summary>
        /// <param name="emails">A list of email addresses to validate before adding</param>
        public static void AddIfValidEmail(this MailAddressCollection mailAddressCollection, IEnumerable<string> emails)
        {
            foreach (var email in emails)
            {
                AddIfValidEmail(mailAddressCollection, email);
            }
        }

        /// <summary>
        /// Adds the specified email address if it is a valid email address.
        /// </summary>
        /// <param name="email">The email address to add if it is a valid email</param>
        public static void AddIfValidEmail(this MailAddressCollection mailAddressCollection, string email)
        {
            if (email.IsEmail())
            {
                mailAddressCollection.Add(email);
            }
        }

        /// <summary>
        /// Clears all the recipents for the mail message
        /// </summary>
        public static void ClearRecipients(this MailMessage message)
        {
            message.To.Clear();
            message.CC.Clear();
            message.Bcc.Clear();
        }

        /// <summary>
        /// Returns all mail addresses as a comma delimited list of addresses
        /// </summary>
        /// <returns>A comma delimited list of all email addresses</returns>
        public static string ToCommaDelimitedList(this MailAddressCollection mailAddressCollection)
        {
            if (mailAddressCollection.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            AddCollectionAsDelimitedList(mailAddressCollection, sb, ",");
            return sb.ToString().Substring(0, sb.Length - 1);
        }

        /// <summary>
        /// Returns the total number of recipients in all the mail address collections (to, cc and bcc)
        /// </summary>
        /// <returns>An INT representing the total number of recepients for this mail message</returns>
        public static int GetTotalRecipients(this MailMessage mailMessage)
        {
            return mailMessage.To.Count + mailMessage.CC.Count + mailMessage.Bcc.Count;
        }

        /// <summary>
        /// Overwrites the original recipients for all collections (TO, CC, BCC) and adds the specified email address
        /// </summary>
        /// <param name="email">The new email address that the message will be sent to</param>
        /// <param name="displayIntendedRecipients">Indicates whether the original recipients should be added to the bottom of the message's body</param>
        public static void OverwriteRecipients(this MailMessage mailMessage, string email, bool displayIntendedRecipients = true)
        {
            if (!email.IsEmail())
            {
                throw new ArgumentException("Email required for debugging clearing of collection.", "email");
            }

            if (displayIntendedRecipients)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("<p></p><hr /><hr />This message's recipients were cleared, there were {0} original recipient(s)<hr />", mailMessage.GetTotalRecipients());
                sb.Append("To:<br/>");
                AddRecipientListToBody(mailMessage.To, sb);
                sb.Append("CC:<br/>");
                AddRecipientListToBody(mailMessage.CC, sb);
                sb.Append("BCC:<br/>");
                AddRecipientListToBody(mailMessage.Bcc, sb);

                mailMessage.Body += sb.ToString();
            }

            mailMessage.ClearRecipients();
            mailMessage.To.Add(email);
        }

        /// <summary>
        /// Sends an email using the default SMTP client and settings. The SMTP client is disposed after sending the message.
        /// </summary>
        /// <param name="throwExceptionOnNoRecipients">Indicates whether an exception should be thrown if no recipients are found</param>
        /// <param name="throwExceptions">Indicates whether an exception is thrown if encountered while sending the message.</param>
        public static void Send(this MailMessage message, bool throwExceptionOnNoRecipients = false, bool throwExceptions = true)
        {
            if (!throwExceptionOnNoRecipients && message.GetTotalRecipients() == 0)
            {
                return;
            }

            var s = new SmtpClient();
            try
            {
                s.Send(message);
            }
            catch (System.Net.Mail.SmtpFailedRecipientException)
            {
                if (throwExceptionOnNoRecipients)
                {
                    throw;
                }
            }
            catch
            {
                if (throwExceptions)
                {
                    throw;
                }
            }
            finally
            {
                s.Dispose();
            }
        }


        #region Internal Helpers
        private static void AddCollectionAsDelimitedList(this MailAddressCollection mailAddressCollection, StringBuilder sb, string dilimiter)
        {
            int count = mailAddressCollection.Count;
            if (mailAddressCollection.Count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    string name = mailAddressCollection[i].DisplayName;
                    if (string.IsNullOrEmpty(name))
                    {
                        name = mailAddressCollection[i].Address;
                    }
                    sb.AppendFormat("{0}{1}", name, dilimiter);
                }
            }
        }
        private static void AddRecipientListToBody(MailAddressCollection collection, StringBuilder sb)
        {
            int count = collection.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    sb.AppendFormat("{0}<br/>", collection[i].Address);
                }
            }
        }

        #endregion
    }

}
