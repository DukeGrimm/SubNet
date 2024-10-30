using EmberToolkit.Common.Interfaces.Repository;
using SubNet.Common.Enum.Data.Missions;
using System;

namespace SubNet.Common.Interfaces.Data.Email
{
    public interface IEmail : IEmberObject
    {
        string Subject { get; }
        string Body { get; }
        Guid Sender { get; }
        Guid MissionId { get; }
        EMissionState MissionState { get; }
        DateTime SentDate { get; }
        bool IsRead { get; }
        //Triggers Mission Completion, GUID = Dataquad ID for determing in player sent the correct dataquad object to the client.
        event Action<Guid> OnEmailReply;

        void MarkAsRead();
        void MarkAsUnread();
        //void SendMissionReply(Guid dataQuadId);
        void ChangeMissionState(EMissionState newState);

        void ReplyToEmail(Guid dataQuadId);

    }
}
