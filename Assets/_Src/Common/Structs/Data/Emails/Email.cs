using EmberToolkit.Common.DataTypes;
using Newtonsoft.Json;
using Sirenix.Serialization;
using SubNet.Common.Enum.Data.Missions;
using System;

namespace SubNet.Common.Struct.Emails
{
    public struct Email
    {
        [OdinSerialize]
        private Guid id;
        [OdinSerialize]
        private string name;
        [OdinSerialize]
        private string subject;
        [OdinSerialize]
        private string body;
        [OdinSerialize]
        private Guid sender;
        [OdinSerialize]
        private Guid missionId;
        [OdinSerialize]
        private EMissionState missionState;
        [OdinSerialize]
        private UDateTime sentDate;
        [OdinSerialize]
        private bool isRead;

        public Guid Id => id;
        public string Name => name;
        public Type ItemType => GetType();

        public string Subject => subject;
        public string Body => body;
        public Guid Sender => sender;
        public Guid MissionId => missionId;

        public EMissionState MissionState => missionState;

        public DateTime SentDate => sentDate.DateTime;

        public bool IsRead => isRead;

        [JsonConstructor]
        public Email([JsonProperty("Id")] string id, [JsonProperty("Name")] string name, [JsonProperty("Subject")] string subject, [JsonProperty("Body")] string body, [JsonProperty("Sender")] string sender, [JsonProperty("MissionId")] string missionId, [JsonProperty("MissionState")] string missionState, [JsonProperty("SentDate")] string sentDate, [JsonProperty("IsRead")] string isRead)
        {
            this.id = new Guid(id);
            this.name = name;
            this.subject = subject;
            this.body = body;
            this.sender = new Guid(sender);
            this.missionId = new Guid(missionId);
            this.missionState = (EMissionState)System.Enum.Parse(typeof(EMissionState), missionState);
            this.sentDate = new UDateTime(DateTime.Parse(sentDate));
            this.isRead = bool.Parse(isRead);
        }

        public Email(string subject, string body, Guid sender, Guid missionId, DateTime sentTime)
        {
            id = Guid.NewGuid();
            name = subject;
            this.subject = subject;
            this.body = body;
            this.sender = sender;
            this.missionId = missionId;
            missionState = EMissionState.NULL;
            sentDate = new UDateTime(sentTime);
            isRead = false;
        }

        public void MarkAsRead() => isRead = true;


        public void MarkAsUnread() => isRead = false;


        public void ChangeMissionState(EMissionState newState) => missionState = newState;

        public void ReplyToEmail(Guid dataQuadId)
        {
            //bbOnEmailReply?.Invoke(dataQuadId);
        }
    }
}
