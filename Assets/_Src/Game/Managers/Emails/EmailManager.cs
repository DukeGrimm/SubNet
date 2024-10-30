using EmberToolkit.Common.Attributes;
using EmberToolkit.Unity.Behaviours;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SubNet.Common.Interfaces.Game.Emails;
using SubNet.Common.Struct.Emails;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubNet.Game.Managers.Emails
{
    public class EmailManager : EmberSingleton, IEmailManager
    {

        [OdinSerialize] [SaveField] private Dictionary<Guid, Email> emailRepo = new Dictionary<Guid, Email>();

        public event Action OnNewEmail;

        public bool HasUnreadEmails => emailRepo.Values.Any(email => !email.IsRead);

        protected override void Awake()
        {
            base.Awake();
        }
        
        public Email CreateEmail(string subject, string body, Guid sender, Guid missionId, DateTime sentTime)
        {
            Email email = new Email(subject, body, sender, missionId, sentTime); 
            AddEmail(email);
            return email;
        }

        private void AddEmail(Email email)
        {
            emailRepo.Add(email.Id, email);
            OnNewEmail?.Invoke();
        }

        public Email GetEmail(Guid emailId) => emailRepo[emailId];

        public IEnumerable<Email> GetAllEmails() => emailRepo.Values;

        public IEnumerable<Email> GetEmailsPagination(int page, int pageSize) => emailRepo.Values.Skip(page * pageSize).Take(pageSize);

        public IEnumerable<Email> GetEmailsWhere(Func<Email, bool> predicate) => emailRepo.Values.Where(predicate);

        public bool SendMissionEmail(Email email)
        {
            AddEmail(email);
            return true;
        }

        public bool ReplyToMissionEmail(Guid emailId, Guid dataQuadId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmail(Guid emailId) => emailRepo.Remove(emailId);
    }
}
