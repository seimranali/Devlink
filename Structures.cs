namespace Devlink
{

    public enum CallLogType
    {
        Base = 0,
        Advavanced = 1,
        BaseAndAdvanced = 2,
    }


    public enum DevlinkFieldEnum
    {
        AcallID=0,
        BcallID=1,
        Astate=2,
        Bstate=3,
        Aconnected=4,
        Aismusic=5,
        Bconnected=6,
        Bismusic=7,
        Aname=8,
        Bname=9,
        Blist=10,
        AslotAchannel=11,
        BslotBchannel=12,
        Calledpartypresentationandtype=13,
        Calledpartynumber=14,
        Callingpartypresentationandtype=15,
        Callingpartynumber=16,
        Calledsubaddress=17,
        Callingsubaddress=18,
        Dialledpartytype=19,
        Dialledpartynumber=20,
        Keypadtype=21,
        Keypadnumber=22,
        Ringattemptcount=23,
        Cause=24,
        Voicemaildisallow=25,
        Sendingcomplete=26,
        CalltypeandTransporttype=27,
        Ownerhutgroupname=28,
        Originalhutgroupname=29,
        Originalusername=30,
        Targethuntgroupname=31,
        Targetusername=32,
        TargetRASname=33,
        IsInternalCall=34,
        Timestamp=35,
        Connectedtime=36,
        Ringtime=37,
        Connectedduration=38,
        Ringduration=39,
        Locale=40,
        ParkslotNumber=41,
        Callwaiting=42,
        Tag=43,
        Transferring=44,
        Serviceactive=45,
        Serviceqoutaused=46,
        Serviceqoutatime=47,
        Accountcode=48,
        CallID=49
    }

    public enum DevlinkAFieldEnum
    {
        AcallId=0,
        BcallId=1,
        CallID=2

    }
    public enum DevlinkDFieldEnum
    {
        AcallId=0,
        BcallId=1,
        CallID=2
    }

    namespace Connection_Parameter
    {

        public class Connection_Status_Paramenter
        {
            public IntPtr IdPbx { get; set; }
            public string StatusMessage { get; set; }
            public Connection_Enum.ErrorLevel ErrorLevel { get; set; }
            public CommsEvent_Enum.CommsEvent_State Status { get; set; }
        }

    }

    namespace Connection_Enum
    {
        public enum ErrorLevel
        {
            //' Fields
            ignore = 0,
            info = 1,
            warning = 2,
            fatal = 3
        }

    }

    namespace CommsEvent_Enum
    {
        public enum CommsEvent_State
        {

            DEVLINK_COMMS_OPERATIONAL = 0,
            DEVLINK_COMMS_NORESPONSE = 1,
            DEVLINK_COMMS_REJECTED = 2,
            DEVLINK_COMMS_MISSEDPACKETS = 3
        }

    }

    namespace CommsEvents_Parameter
    {
        public class CommEvent : EventArgs
        {
            ///'Inherits System.EventArgs
            public IntPtr IdPbx { get; set; }
            public CommsEvent_Enum.CommsEvent_State comm_state { get; set; }
            public int parm1 { get; set; }
        }
    }

    namespace CallLogEvent_S_Enum
    {
        public enum StateCode
        {
            Idle = 0,
            Ringing = 1,
            Connected = 2,
            Disconnected = 3,
            Suspending = 4,
            Suspended = 5,
            Resuming = 6,
            Dialling = 7,
            Dialled = 8,
            Local_Dial = 9,
            Queued = 10,
            Parked = 11,
            Held = 12,
            Redialling = 13

        }

        public enum CauseCode
        {
            CMCauseUnknown = 0,
            CMCauseUnallocatedNumber = 1,
            CMCauseForceIdle = 2,
            CMCauseUnregister = 3,
            CMCauseNormal = 16,
            CMCauseBusy = 17,
            CMCauseNoUserResponding = 18,
            CMCauseCallRejected = 21,
            CMCauseNormalUnspecified = 31,
            CMCauseNoChannel = 34,
            CMCauseNetworkOOO = 38,
            CMCauseIncompatible = 88,
            CMCausePhoneInfo = 113,
            CMCauseReminderFree = 114,
            CMCauseReminderNoAns = 115,
            CMCauseE911Emergency = 116,
            CMCauseParked = 117,
            CMCauseUnParked = 118,
            CMCausePickup = 119,
            CMCauseReminder = 120,
            CMCauseRedirect = 121,
            CMCauseCallBarred = 122,
            CMCauseForwardToVoicemail = 123,
            CMCauseAnsweredByOther = 124,
            CMCauseNoAccountCode = 125,
            CMCauseTransfer = 126,
            CMCauseConferencingMove = 127,
            CMCauseRestrictedToPartner = 128,
            CMCauseHeldCall = 129,
            CMRingBackCheck = 130,
            CMCauseAppearanceCallSteal = 131,
            CMCauseAppearanceBridgeInto = 132,
            CMCauseBumpedCall = 133,
            CMCauseLineAppearanceCall = 134,
            CMCauseUnheldCall = 135,
            CMCauseReplaceCurrentCall = 136,
            CMCauseGlare = 137,
            CMCauseR21CompatConfMove = 138
        }
    }

    namespace CallLogEvent_Type
    {
        public class CallLogEvent_S
        {
            public string AcallId { get; set; }
            public string BcallId { get; set; }
            public CallLogEvent_S_Enum.StateCode Astate { get; set; }
            public CallLogEvent_S_Enum.StateCode Bstate { get; set; }
            public int Aconnected { get; set; }
            public int AisMusic { get; set; }
            public int Bconnected { get; set; }
            public int BisMusic { get; set; }
            public string Aname { get; set; }
            public string Bname { get; set; }
            public string Blist { get; set; }
            public string AslotAchannel { get; set; }
            public string BslotBchannel { get; set; }
            public string CalledPartyPresentation { get; set; }
            public string CalledPartyNumber { get; set; }
            public string CallingPartyPresentationType { get; set; }
            public string CallingPartyNumber { get; set; }
            public string CalledSubAddress { get; set; }
            public string CallingSubAddress { get; set; }
            public string DialledPartyType { get; set; }
            public string DialledPartyNumber { get; set; }
            public int KeypadType { get; set; }
            public string KeypadNumber { get; set; }
            public int RingAttemptCount { get; set; }
            public CallLogEvent_S_Enum.CauseCode Cause { get; set; }
            public int VoicemailDisallow { get; set; }
            public int SendingComplete { get; set; }
            public string CallTypeTransportType { get; set; }
            public string OwnerHuntGroupName { get; set; }
            public string OriginalHuntGroupName { get; set; }
            public string OriginalUserName { get; set; }
            public string TargetHuntGroupName { get; set; }
            public string TargetUserName { get; set; }
            public string TargetRASName { get; set; }
            public int IsInternalCall { get; set; }
            public string TimeStamp { get; set; }
            public int ConnectedTime { get; set; }
            public int RingTime { get; set; }
            public int ConnectedDuration { get; set; }
            public int RingDuration { get; set; }
            public string Locale { get; set; }
            public string ParkSlotNumber { get; set; }
            public string CallWaiting { get; set; }
            public string Tag { get; set; }
            public string Transferring { get; set; }
            public int ServiceActive { get; set; }
            public int ServiceQuotaUsed { get; set; }
            public int ServiceQuotaTime { get; set; }
            public string AccountCode { get; set; }
            public int CallID { get; set; }

        }

        public class CallLogEvent_D
        {
            public string AcallId { get; set; }
            public string BcallId { get; set; }
            public int CallID { get; set; }
        }

        public class CallLogEvent_A
        {
            public string AcallId { get; set; }
            public string BcallId { get; set; }
            public int CallID { get; set; }
        }
    }

    namespace CallLogEvent_Parameter
    {
        public class CallLog_S_Parameter : EventArgs
        {
            //'Inherits System.EventArgs
            public int IdPbx { get; set; }
            public CallLogEvent_Type.CallLogEvent_S LogInfo { get; set; }
        }
        public class CallLog_A_Parameter : EventArgs
        {
            //'Inherits System.EventArgs
            public int IdPbx { get; set; }
            public CallLogEvent_Type.CallLogEvent_A LogInfo { get; set; }

        }
        public class CallLog_D_Parameter : EventArgs
        {

            public int IdPbx { get; set; }
            public CallLogEvent_Type.CallLogEvent_D LogInfo { get; set; }
        }

        public class CallLog_Base_Parameter : System.EventArgs
        {
            public int IdPbx { get; set; }
            public string LogInfo { get; set; }
        }
    }
}
