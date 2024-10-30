using SubNet.Common.Struct.Emails;
using System;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Game.Emails
{
    public interface IEmailManager
    {
        bool HasUnreadEmails { get; }

        event Action OnNewEmail;

        Email CreateEmail(string subject, string body, Guid sender, Guid missionId, DateTime sentTime);
        Email GetEmail(Guid emailId);
        IEnumerable<Email> GetAllEmails();
        IEnumerable<Email> GetEmailsPagination(int page, int pageSize);
        IEnumerable<Email> GetEmailsWhere(Func<Email, bool> predicate);
        bool SendMissionEmail(Email email);
        bool ReplyToMissionEmail(Guid emailId, Guid dataQuadId);
        bool DeleteEmail(Guid emailId);
    }
}
