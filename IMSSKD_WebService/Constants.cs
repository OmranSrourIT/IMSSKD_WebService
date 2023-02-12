//*****************************************************************************
// (c)Copyright 2014. All Rights Reserved
// IrisID Systems Inc, U.S.A.
// Project Name   : IrisAccelerator 
// File Name      : Constants.cs
// Description	  : Constants to be used in the application
//*****************************************************************************
namespace CSharp_Sample
{
    /// <summary>
    /// Summary description for Constants.
    /// </summary>
    /// 
    public class Constants
    {
        //EYE
        public const int EYE_RIGHT = 1;
        public const int EYE_LEFT = 2;
        public const int EYE_BOTH = 3;

        //Size of IrisCode.
        public const int IRISCODE_SIZE_SHORT = 512;
        public const int IRISCODE_SIZE_LONG = 1024;
        public const int IRIS_IMAGE_SIZE = 640 * 480;
        public const int IRIS_IMAGE_RECT = 100;
        public const int IRIS_IMAGE_RECT_WIDTH = 640;
        public const int IRIS_IMAGE_RECT_HEIGHT = 480;

		//Match Type
		public const byte MATCH_HIERARCHIAL = 0;
		public const byte MATCH_EXHAUSTIVE = 1;


        //LONG IrisCode Files
        public const string LONG_IRIS_CODE_FILE_RIGHT = "\\SampleIrisFiles\\RightEyeLongIrisCode.dat";
        public const string LONG_IRIS_CODE_FILE_LEFT = "\\SampleIrisFiles\\LeftEyeLongIrisCode.dat";

        //SHORT IrisCode Files
        public const string SHORT_IRIS_CODE_FILE_RIGHT = "\\SampleIrisFiles\\RightEyeShortIrisCode.dat";
        public const string SHORT_IRIS_CODE_FILE_LEFT = "\\SampleIrisFiles\\LeftEyeShortIrisCode.dat";

        //Iris Image files
        public const string IRIS_IMAGE_FILE_RIGHT = "\\SampleIrisFiles\\RightEyeImage.dat";
        public const string IRIS_IMAGE_FILE_LEFT = "\\SampleIrisFiles\\LeftEyeImage.dat";

        //Apllication Title
        public const string STRING_APPNAME = "CSharp Sample";
        public const int ERROR_NONE = 0;
        public const int ERROR_UNKNOWN = 4;

        //Copy Right String
        public const string STRING_COPYRIGHT = "2005-{0:####} Iris ID Systems, Inc. All rights reserved.\r\nIris ID, Iris ID Systems, the Iris ID logo, IrisAccess, iData, iCAM and SoHo are either registered trademarks, or copyrights of their respective holders.";

        //Operations
        public const string EXECUTE = "Execute";
        public const string ADD_FORCE = "Add Force";
        public const string IDENTIFY = "Identify";
        public const string ENROLL = "Enroll";
        public const string DELETE_IRIACODES = "Delete All Iris Codes";
        public const string DISCONNECT = "Disconnect";
        public const string SABRE_ID = "SABRE ID";
        public const string IRIS_ACCELERATOR_VERSION = "IrisAccelerator Version";
        public const string REMOVE_USER = "Remove User";
		public const string UPDATE_USER = "Update User";
		public const string USER_TEMPLATES = "Get User Templates";
		public const string VERIFY_EYE = "Verify Eye";

        //Operation Messages
        public const string IRIACODES_DELETED = "All Iris Codes deleted.\t";
        public const string ERROR_CLOSE_CONNECTION = "Error while closing the connection.\t";
        public const string DISCONNECT_SERVER = "Disconnected from server: ";
        public const string SABRE_ID_USER = "SABRE ID for User ";
        public const string BACK_PRESSURE_OFF = "Back Pressure OFF, started sending requests";
        public const string BACK_PRESSURE_ON = "Back Pressure ON, stopped sending requests";

        //Input Type
        public const string SHORT_IRIS_CODE = "Short Iris Code";
        public const string LONG_IRIS_CODE = "Long Iris Code";
        public const string IRIS_IMAGE = "Iris Image";

        //Error Message
        public const string ERROR_MSG = "[Error event] BladeID: {0}, Command: {1}, Error code: {2}, Description: {3}";
    }
}
