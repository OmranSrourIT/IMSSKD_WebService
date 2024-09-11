using CSharp_Sample;
using IMSSDKLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Web.Http;
using static IMSSKD_WebService.WebApiApplication;

namespace IMSSKD_WebService
{
    public abstract class WebApiConfig
    {
        public static IMSClientClass m_ImsClient = IMSSDK.GetInstance();
        public static int m_iErrorNone;
        public static EyeType m_WhichEye;
        public static int m_iUserID;
        public static string IresutlMatch = "";
        public static List<string> arlist1 = new List<string>();
        public static string ErrorCodeRes = "";
        public static string m_strIPAddress;

        private delegate void DelegateResponse(int iCID, int iRequestID, int iResponse);

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
             
            m_ImsClient.OnAddSingleEyeResponded += new _IIMSClientEvents_OnAddSingleEyeRespondedEventHandler(OnAddSingleEyeResponded);
            m_ImsClient.OnAddBothEyesResponded += new _IIMSClientEvents_OnAddBothEyesRespondedEventHandler(OnAddBothEyesResponded);
            m_ImsClient.OnAddBothEyeForcedResponded += new _IIMSClientEvents_OnAddBothEyeForcedRespondedEventHandler(OnAddBEForcedResponded);
            m_ImsClient.OnVerifySingleEyeResponded += new _IIMSClientEvents_OnVerifySingleEyeRespondedEventHandler(OnVerifySingleEyeResponded);
            m_ImsClient.OnVerifyBothEyesResponded += new _IIMSClientEvents_OnVerifyBothEyesRespondedEventHandler(OnVerifyBothEyesResponded);
            m_ImsClient.OnRemoveUserResponded += new _IIMSClientEvents_OnRemoveUserRespondedEventHandler(OnRemoveUserResponded);
            m_ImsClient.OnDeleteAllIrisCodesResponded += new _IIMSClientEvents_OnDeleteAllIrisCodesRespondedEventHandler(OnDeleteAllIrisCode);
            m_ImsClient.OnUpdateEyesResponded += new _IIMSClientEvents_OnUpdateEyesRespondedEventHandler(OnUpdateEyesResponded);
            m_ImsClient.OnDisconnect += new _IIMSClientEvents_OnDisconnectEventHandler(OnDisconnect);
            m_ImsClient.OnError += new _IIMSClientEvents_OnErrorEventHandler(OnError);
            m_ImsClient.OnAlarm += new _IIMSClientEvents_OnAlarmEventHandler(OnAlarmRaised);
            m_ImsClient.OnBackPressure += new _IIMSClientEvents_OnBackPressureEventHandler(OnBackPressureEvent);
            m_ImsClient.OnMatchSingleEyeResponded += new _IIMSClientEvents_OnMatchSingleEyeRespondedEventHandler(OnMatchSingleEyeResponded);
            m_ImsClient.OnMatchBothEyesResponded += new _IIMSClientEvents_OnMatchBothEyesRespondedEventHandler(OnMatchBothEyesResponded);


        }

        private static void UnregisterEventHandlers()
        {
            m_ImsClient.OnAddSingleEyeResponded -= new _IIMSClientEvents_OnAddSingleEyeRespondedEventHandler(OnAddSingleEyeResponded);
            m_ImsClient.OnAddBothEyesResponded -= new _IIMSClientEvents_OnAddBothEyesRespondedEventHandler(OnAddBothEyesResponded);
            m_ImsClient.OnRemoveUserResponded -= new _IIMSClientEvents_OnRemoveUserRespondedEventHandler(OnRemoveUserResponded);
            m_ImsClient.OnDisconnect -= new _IIMSClientEvents_OnDisconnectEventHandler(OnDisconnect);
            m_ImsClient.OnError -= new _IIMSClientEvents_OnErrorEventHandler(OnError);
            m_ImsClient.OnDeleteAllIrisCodesResponded -= new _IIMSClientEvents_OnDeleteAllIrisCodesRespondedEventHandler(OnDeleteAllIrisCode);
            m_ImsClient.OnAlarm -= new _IIMSClientEvents_OnAlarmEventHandler(OnAlarmRaised);
            m_ImsClient.OnUpdateEyesResponded -= new _IIMSClientEvents_OnUpdateEyesRespondedEventHandler(OnUpdateEyesResponded);
            m_ImsClient.OnVerifySingleEyeResponded -= new _IIMSClientEvents_OnVerifySingleEyeRespondedEventHandler(OnVerifySingleEyeResponded);
            m_ImsClient.OnVerifyBothEyesResponded -= new _IIMSClientEvents_OnVerifyBothEyesRespondedEventHandler(OnVerifyBothEyesResponded);
            m_ImsClient.OnBackPressure -= new _IIMSClientEvents_OnBackPressureEventHandler(OnBackPressureEvent);
            m_ImsClient.OnMatchSingleEyeResponded -= new _IIMSClientEvents_OnMatchSingleEyeRespondedEventHandler(OnMatchSingleEyeResponded);
            m_ImsClient.OnMatchBothEyesResponded -= new _IIMSClientEvents_OnMatchBothEyesRespondedEventHandler(OnMatchBothEyesResponded);
            m_ImsClient.OnAddBothEyeForcedResponded -= new _IIMSClientEvents_OnAddBothEyeForcedRespondedEventHandler(OnAddBEForcedResponded);

            m_ImsClient = IMSSDK.GetInstance();
            m_iErrorNone = 0;
            m_iUserID = 0;
            IresutlMatch = "";
            arlist1 = new List<string>();
            m_strIPAddress = "";
        }



        public static void OnMatchSingleEyeResponded(int iCID, int iRequestID, int MatchFound, object UserID, object HammingDistance, object MatchedEye, object ImageQuality, int iResponse)
        {
            try
            {
                if (iResponse != m_iErrorNone)
                {
                    IresutlMatch = ShowErrorMessage(iResponse, Constants.IDENTIFY);
                    ErrorCodeRes = iResponse.ToString();
                }
                else
                {
                    if (MatchFound != 0)
                    {
                        IresutlMatch = MatchFoundStringBuilder(MatchFound, UserID, HammingDistance, null, Constants.IDENTIFY);
                        ErrorCodeRes = "100"; //code when found Matching
                    }
                    else
                    {
                        IresutlMatch = "Dose Not Found Matching";
                        ErrorCodeRes = "400"; //code when found Matching
                    }

                }
            }
            catch (Exception e)
            {
                IresutlMatch = e.Message;
            }
        }

        private static void OnMatchBothEyesResponded(int iCID, int iRequestID, int MatchFound, object UserID, object HammingDistance_RE, object HammingDistance_LE, object MatchedEye_RE, object MatchedEye_LE, object ImageQuality_RE, object ImageQuality_LE, int iResponse)
        {

            ErrorCodeRes = "";
            IresutlMatch = "";

            try
            {
                if (iResponse != m_iErrorNone)
                {
                    IresutlMatch = ShowErrorMessage(iResponse, Constants.IDENTIFY);
                    ErrorCodeRes = iResponse.ToString();
                }
                else
                {
                    if (MatchFound != 0)
                    {
                        IresutlMatch = MatchFoundBothStringBuilder(MatchFound, UserID, HammingDistance_RE, HammingDistance_LE, MatchedEye_RE, MatchedEye_LE, null, Constants.IDENTIFY);
                        ErrorCodeRes = "100"; //code when found Matching
                    }
                    else
                    {
                        IresutlMatch = "Dose Not Found Matching";
                        ErrorCodeRes = "400"; //code when found Matching
                    }


                }

            }
            catch (Exception e)
            {
                IresutlMatch = e.Message;
            }
        }

        public static void OnAlarmRaised(int iSessionID, int iBladeID, string strDateTime, int iErrorCode, string strDescription)
        {
            try
            {
                IresutlMatch = strDescription;
            }
            catch (Exception e)
            {
                IresutlMatch = e.Message + " " + Constants.STRING_APPNAME;
            }
        }

        public static void OnAddBEForcedResponded(int iCID, int iRequestID, int iResponse)
        {
            try
            {
                if (iResponse != m_iErrorNone)
                {
                    IresutlMatch = ShowErrorMessage(iResponse, Constants.ADD_FORCE);
                    ErrorCodeRes = iResponse.ToString();
                }
                else
                {
                    IresutlMatch = string.Format("Both Eyes for User : {0} added.{1}", m_iUserID.ToString(), "\t");
                    ErrorCodeRes = "";

                }

            }
            catch (Exception e)
            {
                IresutlMatch = e.Message + " " + Constants.STRING_APPNAME;
            }
        }


        public static void OnUpdateEyesResponded(int iCID, int iRequestID, int iResponse)
        {
            try
            {

                if (iResponse != m_iErrorNone)
                {

                    IresutlMatch = ShowErrorMessage(iResponse, Constants.UPDATE_USER);
                    ErrorCodeRes = iResponse.ToString();
                }
                else
                {
                    IresutlMatch = string.Format("User : {0} updated.{1}", m_iUserID.ToString(), Constants.UPDATE_USER);

                }

            }
            catch (Exception e)
            {
                IresutlMatch = e.Message + Constants.STRING_APPNAME;
            }
        }


        public static void OnDeleteAllIrisCode(int iCID, int lGroupID, int lRequestID)
        {
            try
            {
                IresutlMatch = Constants.IRIACODES_DELETED + " " + Constants.DELETE_IRIACODES;

            }
            catch (Exception e)
            {
                IresutlMatch = e.Message;
            }
        }
        public static void OnRemoveUserResponded(int iCID, int iRequestID, int iResponse)
        {
            try
            {
                if (iResponse != m_iErrorNone)
                {
                    IresutlMatch = ShowErrorMessage(iResponse, Constants.REMOVE_USER);
                    ErrorCodeRes = iResponse.ToString();
                }

                else
                {
                    IresutlMatch = string.Format("{0}{1} for User : {2} ,  removed {3}", Convert.ToString(m_WhichEye), (((int)m_WhichEye) > 2 ? " Eyes" : " Eye"), Convert.ToString(m_iUserID), "\t") + Constants.REMOVE_USER;
                    ErrorCodeRes = "100";
                }

                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                IresutlMatch = e.Message;
            }
        }


        public static void OnVerifyBothEyesResponded(int iSessionID, int iRequestID, int iMatchFound, double dRHammingDistance, double dLHammingDistance, object objRMatchedEye, object objLMatchedEye, int iResponse)
        {
            try
            {
                if (iResponse != m_iErrorNone)
                {

                    IresutlMatch = ShowErrorMessage(iResponse, Constants.UPDATE_USER);
                    ErrorCodeRes = iResponse.ToString();
                }
                else
                {
                    IresutlMatch = string.Format("UserId is  : {0} , Match Count found : {1}  , Right Hamming Dictance : {2} , Left  Hamming Dictance : {3} , Right Eye Matched : {4} , Left Eye Matched : {5} Method is", m_iUserID.ToString(), iMatchFound, dRHammingDistance, dLHammingDistance, objRMatchedEye, objLMatchedEye) + Constants.VERIFY_EYE;

                }

            }
            catch (Exception e)
            {
                IresutlMatch = e.Message;
            }
        }

        public static void OnVerifySingleEyeResponded(int iSessionID, int iRequestID, int iMatchFound, double dHammingDistance, int iResponse)
        {
            try
            {

                if (iResponse != m_iErrorNone)
                {
                    IresutlMatch = ShowErrorMessage(iResponse, Constants.UPDATE_USER);
                    ErrorCodeRes = iResponse.ToString();
                }
                else
                {
                    IresutlMatch = string.Format("UserID is : {0} , MatchFound : {1} , HammingDistance : {2}  , Response is : {3} ", m_iUserID.ToString(), iMatchFound, dHammingDistance, iResponse) + Constants.VERIFY_EYE;

                    ErrorCodeRes = "100"; //code when found Matching
                }

            }
            catch (Exception e)
            {
                IresutlMatch = e.Message;
            }
        }

        public static void OnAddSingleEyeResponded(int iCID, int iRequestID, int MatchFound, object UserID, object HammingDistance, object MatchedEye, object ImageQuality, int iResponse)
        {
            try
            {
                if (iResponse != m_iErrorNone)
                {
                    IresutlMatch = ShowErrorMessage(iResponse, Constants.ENROLL);
                    ErrorCodeRes = iResponse.ToString();
                }
                else if (MatchFound > 0)
                {
                    IresutlMatch = MatchFoundStringBuilder(MatchFound, UserID, HammingDistance, null, Constants.ENROLL);
                    ErrorCodeRes = "100"; //code when found Matching
                }
                else
                {
                    IresutlMatch = string.Format("{0} Eye for User ID : {1} enrolled.{2}", Convert.ToString(m_WhichEye), Convert.ToString(m_iUserID), Constants.ENROLL); ;
                    ErrorCodeRes = ""; //code when found Enroll   

                }
            }
            catch (Exception e)
            {
                IresutlMatch = e.Message;
            }

        }

        private static void OnAddBothEyesResponded(int iCID, int iRequestID, int MatchFound, object UserID, object HammingDistance_RE, object HammingDistance_LE, object MatchedEye_RE, object MatchedEye_LE, object ImageQuality_RE, object ImageQuality_LE, int iResponse)
        {
            try
            {
                if (iResponse != m_iErrorNone)
                {
                    IresutlMatch = ShowErrorMessage(iResponse, Constants.ENROLL);
                    ErrorCodeRes = iResponse.ToString();
                }
                else if (MatchFound > 0)
                {
                    IresutlMatch = MatchFoundBothStringBuilder(MatchFound, UserID, HammingDistance_RE, HammingDistance_LE, MatchedEye_RE, MatchedEye_LE, null, Constants.ENROLL);

                }
                else
                {
                    IresutlMatch = string.Format("Both Eyes for User ID : {0}  , enrolled.{1}", Convert.ToString(m_iUserID), Constants.ENROLL);

                }

            }
            catch (Exception e)
            {
                IresutlMatch = e.Message;
            }

        }

        private static string MatchFoundBothStringBuilder(int MatchFound, object UserID, object HammingDistance_RE, object HammingDistance_LE, object MatchedEye_RE, object MatchedEye_LE, object RankedIndex, string strOwner)
        {

            string strMatch = string.Empty;

            try
            {
                if (RankedIndex != null)
                {
                    foreach (int i in (int[])RankedIndex)
                    {
                        strMatch += String.Format(" {0}/{1}/{2}, ", ((int[])UserID)[i], ((double[])HammingDistance_RE)[i], ((double[])HammingDistance_LE)[i]);
                    }
                }
                else
                {
                    int iCount = 0;
                    foreach (int i in (int[])UserID)
                    {
                        strMatch += i.ToString() + ",";
                        //String.Format(" {0}/{1}/{2}, ", i.ToString(), ((double[])HammingDistance_RE)[iCount], ((double[])HammingDistance_LE)[iCount]);
                        //strMatch += "\n";
                        iCount++;
                    }


                    strMatch = strMatch.Remove(strMatch.Length - 1, 1);



                    var EndReusltProfileNo = strMatch.Split(',');

                    for (var x = 0; x < EndReusltProfileNo.Length; x++)
                    {
                        arlist1.Add(EndReusltProfileNo[x]);
                    }


                }

                if (strMatch != string.Empty)
                {
                    //strMatch = string.Format("{0} match found.{1}User {2}{3}{4}", Convert.ToString(MatchFound), "\n", (MatchFound > 1 ? "ID's are (UID/RHd/LHd) : " : "ID is (UID:RHd/LHd) : "), strMatch.Remove(strMatch.Length - 2, 2), "\t");

                    strMatch = string.Format("{0} match found {1} User {2} {3}", Convert.ToString(MatchFound), "For " + WebApiConfig.m_WhichEye + " Eye", (MatchFound > 1 ? "ID's are : " : "ID is : "), strMatch);
                }
                else
                {
                    strMatch = string.Format("{0} match found.{1}", Convert.ToString(MatchFound), "\t");
                }

            }
            catch (Exception e)
            {
                strMatch = e.Message;
            }

            return strMatch;
        }

        private static string MatchFoundStringBuilder(int MatchFound, object UserID, object HammingDistance, object RankedIndex, string strOwner)
        {

            string strMatch = string.Empty;
            try
            {
                if (RankedIndex != null)
                {
                    foreach (int i in (int[])RankedIndex)
                    {
                        strMatch += ((int[])UserID)[i].ToString();
                        strMatch += ((double[])HammingDistance)[i].ToString() + ", ";
                    }
                }
                else
                {
                    int iCount = 0;
                    foreach (int i in (int[])UserID)
                    {
                        strMatch += i.ToString() + ",";
                        // strMatch += ((double[])HammingDistance)[iCount].ToString() + ", ";
                        iCount++;
                    }

                    strMatch = strMatch.Remove(strMatch.Length - 1, 1);
                }

                if (strMatch != string.Empty)
                {
                    strMatch = string.Format("{0} match found {1} User {2} {3}", Convert.ToString(MatchFound), "For " + WebApiConfig.m_WhichEye + " Eye", (MatchFound > 1 ? "ID's are : " : "ID is : "), strMatch);
                }
                else
                {
                    strMatch = string.Format("{0} match found.{1}", Convert.ToString(MatchFound), "\t");

                    var strMessage = strMatch;
                }

            }
            catch (Exception e)
            {
                var strErrorMessage = e.Message;

            }

            return strMatch;
        }




        private static void OnError(int iCID, int iBladeID, string strDateTime, int iCommand, int iError, string strDecription)
        {
            try
            {

                IresutlMatch = string.Format(Constants.ERROR_MSG, iBladeID, iCommand, iError, strDecription);


            }
            catch (Exception e)
            {
                IresutlMatch = e.Message + " " + Constants.STRING_APPNAME;
            }
        }

        public static void OnDisconnect(int iSessionID)
        {
            try
            {
                UnregisterEventHandlers();
                IresutlMatch = Constants.DISCONNECT_SERVER + m_strIPAddress;


            }
            catch (Exception e)
            {
                IresutlMatch = e.Message + " " + Constants.STRING_APPNAME;
            }
        }

        private static void OnBackPressureEvent(int iCID, byte status, string date_time)
        {
            try
            {

                if (status == 0)
                    IresutlMatch = Constants.BACK_PRESSURE_OFF;
                else
                    IresutlMatch = Constants.BACK_PRESSURE_ON;

            }
            catch (Exception e)
            {
                IresutlMatch = e.Message + " " + Constants.STRING_APPNAME;
            }
        }



        private static string ShowErrorMessage(int iResponse, string strOwner)
        {
            var strErrMsg = string.Empty;
            Utils.ErrorHandler(iResponse, ref strErrMsg);
            return strErrMsg + "For UserId " + WebApiConfig.m_iUserID;
        }




        public static void RegisterEventHandlers()
        {

            m_ImsClient.OnAddSingleEyeResponded += new _IIMSClientEvents_OnAddSingleEyeRespondedEventHandler(OnAddSingleEyeResponded);
            m_ImsClient.OnAddBothEyesResponded += new _IIMSClientEvents_OnAddBothEyesRespondedEventHandler(OnAddBothEyesResponded);
            m_ImsClient.OnAddBothEyeForcedResponded += new _IIMSClientEvents_OnAddBothEyeForcedRespondedEventHandler(OnAddBEForcedResponded);
            m_ImsClient.OnVerifySingleEyeResponded += new _IIMSClientEvents_OnVerifySingleEyeRespondedEventHandler(OnVerifySingleEyeResponded);
            m_ImsClient.OnVerifyBothEyesResponded += new _IIMSClientEvents_OnVerifyBothEyesRespondedEventHandler(OnVerifyBothEyesResponded);
            m_ImsClient.OnRemoveUserResponded += new _IIMSClientEvents_OnRemoveUserRespondedEventHandler(OnRemoveUserResponded);
            m_ImsClient.OnDeleteAllIrisCodesResponded += new _IIMSClientEvents_OnDeleteAllIrisCodesRespondedEventHandler(OnDeleteAllIrisCode);
            m_ImsClient.OnUpdateEyesResponded += new _IIMSClientEvents_OnUpdateEyesRespondedEventHandler(OnUpdateEyesResponded);
            m_ImsClient.OnDisconnect += new _IIMSClientEvents_OnDisconnectEventHandler(OnDisconnect);
            m_ImsClient.OnError += new _IIMSClientEvents_OnErrorEventHandler(OnError);
            m_ImsClient.OnAlarm += new _IIMSClientEvents_OnAlarmEventHandler(OnAlarmRaised);
            m_ImsClient.OnBackPressure += new _IIMSClientEvents_OnBackPressureEventHandler(OnBackPressureEvent);
            m_ImsClient.OnMatchSingleEyeResponded += new _IIMSClientEvents_OnMatchSingleEyeRespondedEventHandler(OnMatchSingleEyeResponded);
            m_ImsClient.OnMatchBothEyesResponded += new _IIMSClientEvents_OnMatchBothEyesRespondedEventHandler(OnMatchBothEyesResponded);
        }




    }
}
