using Devlink.CallLogEvent_Parameter;
using Devlink.CallLogEvent_S_Enum;
using Devlink.CallLogEvent_Type;
using Devlink.CommsEvent_Enum;
using Devlink.CommsEvents_Parameter;
using Devlink.Connection_Enum;
using Devlink.Connection_Parameter;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Devlink
{

    //Define Delegate To External Event
    public delegate void COMMSEVENT(IntPtr pbxh, CommsEvent_State comm_state, int param1);
    public delegate void CALLLOGEVENT(IntPtr pbxh, string info);

    public delegate void Comms_Event(object source, CommEvent e);
    public delegate void CallLog_Event(object source, CallLog_Base_Parameter e);
    public delegate void CallLog_Event_A(object source, CallLog_A_Parameter e);
    public delegate void CallLog_Event_S(object source, CallLog_S_Parameter e);
    public delegate void CallLog_Event_D(object source, CallLog_D_Parameter e);
    public delegate void ConnectionStatus(object source, Connection_Status_Paramenter e);
    // Define Delegate End

    public sealed class DevlinkHelper
    {

        //To Do External Events
        private event COMMSEVENT oCommEvent;
        private event CALLLOGEVENT oCallEvent;

        public event Comms_Event OnCommsevent;
        public event CallLog_Event OnCallLogEvent;
        public event CallLog_Event_A OnCallLogEventA;
        public event CallLog_Event_S OnCallLogEventS;
        public event CallLog_Event_D OnCallLogEventD;
        public event ConnectionStatus OnConnectionStatus;
        // External Event End

        public CallLogType CallLogEventType = CallLogType.Base;
        public static bool bIsConnect = false;
        public bool bIsInterrupt = false;

        public static bool IsConnect
        {
            get
            {
                return bIsConnect;
            }
        }

        private void CallLogAdvanceEventA(CallLog_Base_Parameter Param)
        {
            string[] TMP= { };
            CallLog_A_Parameter e = new CallLog_A_Parameter();
            CallLogEvent_A oLogInfo = new CallLogEvent_A();
            try
            {
                TMP = Param.LogInfo.Split(',');

                oLogInfo.AcallId = TMP[(int)DevlinkAFieldEnum.AcallId];
                oLogInfo.BcallId = TMP[(int)DevlinkAFieldEnum.BcallId];
                oLogInfo.CallID = Convert.ToInt32((TMP[(int)DevlinkAFieldEnum.CallID]));

                e.IdPbx = Param.IdPbx;
                e.LogInfo = oLogInfo;

                if (OnCallLogEventA != null)
                    OnCallLogEventA(this, e);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oLogInfo = null;
            }
        }
        private void CallLogAdvanceEventS(CallLog_Base_Parameter Param)
        {
            string[] TMP = { };


            CallLogEvent_S oLogInfo = new CallLogEvent_S();
            CallLog_S_Parameter e = new CallLog_S_Parameter();
            try
            {
                TMP = Param.LogInfo.Split(',');

                oLogInfo.AcallId = TMP[(int)DevlinkFieldEnum.AcallID].ToString();
                oLogInfo.BcallId = TMP[(int)DevlinkFieldEnum.BcallID].ToString();
                int Astate = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Astate]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Astate]));
                int Bstate = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Bstate]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Bstate]));
                switch (Astate)
                {
                    case 0:
                        oLogInfo.Astate = StateCode.Idle;
                        break;
                    case 1:
                        oLogInfo.Astate = StateCode.Ringing;
                        break;
                    case 2:
                        oLogInfo.Astate = StateCode.Connected;
                        break;
                    case 3:
                        oLogInfo.Astate = StateCode.Disconnected;
                        break;
                    case 4:
                        oLogInfo.Astate = StateCode.Suspending;
                        break;
                    case 5:
                        oLogInfo.Astate = StateCode.Suspended;
                        break;
                    case 6:
                        oLogInfo.Astate = StateCode.Resuming;
                        break;
                    case 7:
                        oLogInfo.Astate = StateCode.Dialling;
                        break;
                    case 8:
                        oLogInfo.Astate = StateCode.Dialled;
                        break;
                    case 9:
                        oLogInfo.Astate = StateCode.Local_Dial;
                        break;
                    case 10:
                        oLogInfo.Astate = StateCode.Queued;
                        break;
                    case 11:
                        oLogInfo.Astate = StateCode.Parked;
                        break;
                    case 12:
                        oLogInfo.Astate = StateCode.Held;
                        break;
                    case 13:
                        oLogInfo.Astate = StateCode.Redialling;
                        break;
                    default:
                        oLogInfo.Astate = StateCode.Idle;
                        break;
                }
                switch (Bstate)
                {
                    case 0:
                        oLogInfo.Bstate = StateCode.Idle;
                        break;
                    case 1:
                        oLogInfo.Bstate = StateCode.Ringing;
                        break;
                    case 2:
                        oLogInfo.Bstate = StateCode.Connected;
                        break;
                    case 3:
                        oLogInfo.Bstate = StateCode.Disconnected;
                        break;
                    case 4:
                        oLogInfo.Bstate = StateCode.Suspending;
                        break;
                    case 5:
                        oLogInfo.Bstate = StateCode.Suspended;
                        break;
                    case 6:
                        oLogInfo.Bstate = StateCode.Resuming;
                        break;
                    case 7:
                        oLogInfo.Bstate = StateCode.Dialling;
                        break;
                    case 8:
                        oLogInfo.Bstate = StateCode.Dialled;
                        break;
                    case 9:
                        oLogInfo.Bstate = StateCode.Local_Dial;
                        break;
                    case 10:
                        oLogInfo.Bstate = StateCode.Queued;
                        break;
                    case 11:
                        oLogInfo.Bstate = StateCode.Parked;
                        break;
                    case 12:
                        oLogInfo.Bstate = StateCode.Held;
                        break;
                    case 13:
                        oLogInfo.Bstate = StateCode.Redialling;
                        break;
                    default:
                        oLogInfo.Bstate = StateCode.Idle;
                        break;
                }
                oLogInfo.Aconnected = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Aconnected]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Aconnected]));
                oLogInfo.AisMusic = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Aismusic]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Aismusic]));
                oLogInfo.Bconnected = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Bconnected]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Bconnected]));
                oLogInfo.BisMusic = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Bismusic]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Bismusic]));
                oLogInfo.Aname = TMP[(int)DevlinkFieldEnum.Aname].ToString();
                oLogInfo.Bname = TMP[(int)DevlinkFieldEnum.Bname].ToString();
                oLogInfo.Blist = TMP[(int)DevlinkFieldEnum.Blist].ToString();
                oLogInfo.AslotAchannel = TMP[(int)DevlinkFieldEnum.AslotAchannel].ToString();
                oLogInfo.BslotBchannel = TMP[(int)DevlinkFieldEnum.BslotBchannel].ToString();
                oLogInfo.CalledPartyPresentation = TMP[(int)DevlinkFieldEnum.Calledpartypresentationandtype].ToString();
                oLogInfo.CalledPartyNumber = TMP[(int)DevlinkFieldEnum.Calledpartynumber].ToString();
                oLogInfo.CallingPartyPresentationType = TMP[(int)DevlinkFieldEnum.Callingpartypresentationandtype].ToString();
                oLogInfo.CallingPartyNumber = TMP[(int)DevlinkFieldEnum.Callingpartynumber];
                oLogInfo.CalledSubAddress = TMP[(int)DevlinkFieldEnum.Calledsubaddress];
                oLogInfo.CallingSubAddress = TMP[(int)DevlinkFieldEnum.Callingsubaddress].ToString();
                oLogInfo.DialledPartyType = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Dialledpartytype]) == true) ? "0" : TMP[(int)DevlinkFieldEnum.Dialledpartytype]);
                oLogInfo.DialledPartyNumber = TMP[(int)DevlinkFieldEnum.Dialledpartynumber].ToString();
                oLogInfo.KeypadType = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Keypadtype]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Keypadtype]));
                oLogInfo.KeypadNumber = TMP[(int)DevlinkFieldEnum.Keypadnumber].ToString();
                oLogInfo.RingAttemptCount = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Ringattemptcount]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Ringattemptcount]));
                int cause = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Cause]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Cause]));
                switch (cause)
                {
                    case 0:
                        oLogInfo.Cause = CauseCode.CMCauseUnknown;
                        break;
                    case 1:
                        oLogInfo.Cause = CauseCode.CMCauseUnallocatedNumber;
                        break;
                    case 2:
                        oLogInfo.Cause = CauseCode.CMCauseForceIdle;
                        break;
                    case 3:
                        oLogInfo.Cause = CauseCode.CMCauseUnregister;
                        break;
                    case 16:
                        oLogInfo.Cause = CauseCode.CMCauseNormal;
                        break;
                    case 17:
                        oLogInfo.Cause = CauseCode.CMCauseBusy;
                        break;
                    case 18:
                        oLogInfo.Cause = CauseCode.CMCauseNoUserResponding;
                        break;
                    case 21:
                        oLogInfo.Cause = CauseCode.CMCauseCallRejected;
                        break;
                    case 31:
                        oLogInfo.Cause = CauseCode.CMCauseNormalUnspecified;
                        break;
                    case 34:
                        oLogInfo.Cause = CauseCode.CMCauseNoChannel;
                        break;
                    case 38:
                        oLogInfo.Cause = CauseCode.CMCauseNetworkOOO;
                        break;
                    case 88:
                        oLogInfo.Cause = CauseCode.CMCauseIncompatible;
                        break;
                    case 113:
                        oLogInfo.Cause = CauseCode.CMCausePhoneInfo;
                        break;
                    case 114:
                        oLogInfo.Cause = CauseCode.CMCauseReminderFree;
                        break;
                    case 115:
                        oLogInfo.Cause = CauseCode.CMCauseReminderNoAns;
                        break;
                    case 116:
                        oLogInfo.Cause = CauseCode.CMCauseE911Emergency;
                        break;
                    case 117:
                        oLogInfo.Cause = CauseCode.CMCauseParked;
                        break;
                    case 118:
                        oLogInfo.Cause = CauseCode.CMCauseUnParked;
                        break;
                    case 119:
                        oLogInfo.Cause = CauseCode.CMCausePickup;
                        break;
                    case 120:
                        oLogInfo.Cause = CauseCode.CMCauseReminder;
                        break;
                    case 121:
                        oLogInfo.Cause = CauseCode.CMCauseRedirect;
                        break;
                    case 122:
                        oLogInfo.Cause = CauseCode.CMCauseCallBarred;
                        break;
                    case 123:
                        oLogInfo.Cause = CauseCode.CMCauseForwardToVoicemail;
                        break;
                    case 124:
                        oLogInfo.Cause = CauseCode.CMCauseAnsweredByOther;
                        break;
                    case 125:
                        oLogInfo.Cause = CauseCode.CMCauseNoAccountCode;
                        break;
                    case 126:
                        oLogInfo.Cause = CauseCode.CMCauseTransfer;
                        break;
                    case 127:
                        oLogInfo.Cause = CauseCode.CMCauseConferencingMove;
                        break;
                    case 128:
                        oLogInfo.Cause = CauseCode.CMCauseRestrictedToPartner;
                        break;
                    case 129:
                        oLogInfo.Cause = CauseCode.CMCauseHeldCall;
                        break;
                    case 130:
                        oLogInfo.Cause = CauseCode.CMRingBackCheck;
                        break;
                    case 131:
                        oLogInfo.Cause = CauseCode.CMCauseAppearanceCallSteal;
                        break;
                    case 132:
                        oLogInfo.Cause = CauseCode.CMCauseAppearanceBridgeInto;
                        break;
                    case 133:
                        oLogInfo.Cause = CauseCode.CMCauseBumpedCall;
                        break;
                    case 134:
                        oLogInfo.Cause = CauseCode.CMCauseLineAppearanceCall;
                        break;
                    case 135:
                        oLogInfo.Cause = CauseCode.CMCauseUnheldCall;
                        break;
                    case 136:
                        oLogInfo.Cause = CauseCode.CMCauseReplaceCurrentCall;
                        break;
                    case 137:
                        oLogInfo.Cause = CauseCode.CMCauseGlare;
                        break;
                    case 138:
                        oLogInfo.Cause = CauseCode.CMCauseR21CompatConfMove;
                        break;
                }
                oLogInfo.VoicemailDisallow = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Voicemaildisallow]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Voicemaildisallow]));
                oLogInfo.SendingComplete = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Sendingcomplete]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Sendingcomplete]));
                oLogInfo.CallTypeTransportType = TMP[(int)DevlinkFieldEnum.CalltypeandTransporttype].ToString();
                oLogInfo.OwnerHuntGroupName = TMP[(int)DevlinkFieldEnum.Ownerhutgroupname].ToString();
                oLogInfo.OriginalHuntGroupName = TMP[(int)DevlinkFieldEnum.Originalhutgroupname].ToString();
                oLogInfo.OriginalUserName = TMP[(int)DevlinkFieldEnum.Originalusername].ToString();
                oLogInfo.TargetHuntGroupName = TMP[(int)DevlinkFieldEnum.Targethuntgroupname].ToString();
                oLogInfo.TargetUserName = TMP[(int)DevlinkFieldEnum.Targetusername].ToString();
                oLogInfo.TargetRASName = TMP[(int)DevlinkFieldEnum.TargetRASname].ToString();
                oLogInfo.IsInternalCall = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.IsInternalCall]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.IsInternalCall]));
                oLogInfo.TimeStamp = TMP[(int)DevlinkFieldEnum.Timestamp].ToString();
                oLogInfo.ConnectedTime = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Connectedtime]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Connectedtime]));
                oLogInfo.RingTime = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Ringtime]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Ringtime]));
                oLogInfo.ConnectedDuration = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Connectedduration]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Connectedduration]));
                oLogInfo.RingDuration = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Ringduration]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Ringduration]));
                oLogInfo.Locale = TMP[(int)DevlinkFieldEnum.Locale].ToString();
                oLogInfo.ParkSlotNumber = TMP[(int)DevlinkFieldEnum.ParkslotNumber];
                oLogInfo.CallWaiting = TMP[(int)DevlinkFieldEnum.Callwaiting];
                oLogInfo.Tag = TMP[(int)DevlinkFieldEnum.Tag].ToString();
                oLogInfo.Transferring = TMP[(int)DevlinkFieldEnum.Transferring];
                oLogInfo.ServiceActive = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Serviceactive]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Serviceactive]));
                oLogInfo.ServiceQuotaUsed = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Serviceqoutaused]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Serviceqoutaused]));
                oLogInfo.ServiceQuotaTime = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.Serviceqoutatime]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.Serviceqoutatime]));
                oLogInfo.AccountCode = TMP[(int)DevlinkFieldEnum.Accountcode].ToString();
                oLogInfo.CallID = ((string.IsNullOrEmpty(TMP[(int)DevlinkFieldEnum.CallID]) == true) ? 0 : Convert.ToInt32(TMP[(int)DevlinkFieldEnum.CallID]));
                e.IdPbx = Param.IdPbx;
                e.LogInfo = oLogInfo;

                if (OnCallLogEventS != null)
                    OnCallLogEventS(this, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oLogInfo = null;
            }

        }
        private void CallLogAdvanceEventD(CallLog_Base_Parameter Param)
        {
            string[] TMP= { };
            CallLog_D_Parameter e = new CallLog_D_Parameter();
            CallLogEvent_D oLogInfo = new CallLogEvent_D();

            try
            {
                TMP = Param.LogInfo.Split(',');
                oLogInfo.AcallId = TMP[(int)DevlinkDFieldEnum.AcallId];
                oLogInfo.BcallId = TMP[(int)DevlinkDFieldEnum.BcallId];
                oLogInfo.CallID = Convert.ToInt32((TMP[(int)DevlinkDFieldEnum.CallID]));

                e.IdPbx = Param.IdPbx;
                e.LogInfo = oLogInfo;

                if (OnCallLogEventD != null)
                    OnCallLogEventD(this, e);



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oLogInfo = null;
            }
        }
        ~DevlinkHelper()
        {

        }
        public DevlinkHelper()
        {
            oCommEvent += new COMMSEVENT(CommEvent);
            oCallEvent += new CALLLOGEVENT(CallEvent);
        }

        [DllImport("devlink.dll")]
        [SupportedOSPlatform("windows")]
        public static extern long DLOpen(IntPtr pbxh, string pbx_address, string pbx_password, string reserved1, string reserved2, COMMSEVENT cb);
        [DllImport("devlink.dll")]
        [SupportedOSPlatform("windows")]
        public static extern long DLClose(IntPtr pbxh);
        [DllImport("devlink.dll")]
        [SupportedOSPlatform("windows")]
        public static extern long DLRegisterType2CallDeltas(IntPtr pbxh, CALLLOGEVENT cb);

        /// <summary>
        /// Common Event
        /// </summary>

        private void CommEvent(IntPtr pbxh,
            CommsEvent_State comms_state, int parm1)
        {
            CommsEvents_Parameter.CommEvent e =
                new CommsEvents_Parameter.CommEvent();
            Connection_Parameter.Connection_Status_Paramenter e1 =
                new Connection_Parameter.Connection_Status_Paramenter();

            try
            {

                e.IdPbx = pbxh;
                e.comm_state = comms_state;
                e.parm1 = parm1;

                e1.IdPbx = pbxh;
                e1.ErrorLevel = Connection_Enum.ErrorLevel.info;
                e1.StatusMessage = "";
                e1.Status = comms_state;

                if (OnConnectionStatus != null)
                    OnConnectionStatus(this, e1);

                bIsConnect = true;

                if (OnCommsevent != null)
                    OnCommsevent(this, e);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CallEvent(IntPtr pbxh, string info)
        {
            Thread MyThread;
            CallLog_Base_Parameter cParameter = new CallLog_Base_Parameter();

            try
            {
                cParameter.IdPbx = pbxh.ToInt32();
                cParameter.LogInfo = info;

                MyThread = new Thread(() => CreateCallLogEvent(cParameter));
                MyThread.Start();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateCallLogEvent(CallLog_Base_Parameter Param)
        {
            try
            {
                if (CallLogEventType == CallLogType.Base
                    || CallLogEventType == CallLogType.BaseAndAdvanced)
                {
                    if (OnCallLogEvent != null)
                        OnCallLogEvent(this, Param);
                }

                if (CallLogEventType == CallLogType.Advavanced
                    || CallLogEventType == CallLogType.BaseAndAdvanced)
                {
                    string TmpStr = string.Empty;

                    TmpStr = Param.LogInfo.Substring(0, 6);

                    switch (TmpStr)
                    {
                        case "CALL:A":
                            CallLogAdvanceEventA(Param);
                            break;
                        case "CALL:S":
                            CallLogAdvanceEventS(Param);
                            break;
                        case "CALL:D":
                            CallLogAdvanceEventD(Param);
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PbxConnect(string address, string password)
        {
            try
            {
                Connection_Status_Paramenter PConn = new Connection_Status_Paramenter();
                PConn.IdPbx = new IntPtr(1);
                PConn.ErrorLevel = Connection_Enum.ErrorLevel.info;
                PConn.StatusMessage = "Connection in progress...";
                PConn.Status = CommsEvent_Enum.CommsEvent_State.DEVLINK_COMMS_OPERATIONAL;

                if (OnConnectionStatus != null)
                    OnConnectionStatus(this, PConn);

                long ret = DLOpen(new IntPtr(1), address, password, null, null, oCommEvent);
                Thread.Sleep(100);

                if (ret >= 0)
                {
                    ret = DLRegisterType2CallDeltas(new IntPtr(1), oCallEvent);

                }
            }
            catch (Exception ex)
            {


                throw ex;
            }
        }
        public void PbxClose(int id)
        {
            bIsInterrupt = true;
            try
            {
                Connection_Status_Paramenter PConn = new Connection_Status_Paramenter();
                PConn.IdPbx = new IntPtr(1);
                PConn.ErrorLevel = ErrorLevel.info;
                PConn.StatusMessage = "Connection Closed!";

                long ret = DLClose(new IntPtr(id));
                bIsConnect = false;

                if (OnConnectionStatus != null)
                    OnConnectionStatus(this, PConn);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

