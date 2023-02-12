//*****************************************************************************
// (c)Copyright 2014. All Rights Reserved
// IrisID Systems Inc, U.S.A.
// Project Name   : IrisAccelerator 
// File Name      : IMSSDK.cs
// Description	  : IMSSDK Instance & IrisCode Generation
//*****************************************************************************
using IMSSDKLib;
using System.IO;


namespace CSharp_Sample
{
    public enum EyeType
    {
        Right = Constants.EYE_RIGHT,
        Left ,
        Both 
    };

    /// <summary>
    /// Summary description for IMSSDK.
    /// </summary>
    public class IMSSDK
    {
        private static IMSClientClass Instance;
        private static IrisSDKClass IrisInstance;

        private IMSSDK()
        {
        }

        #region Variables
        private static int m_iCID;
        private static string m_strIPAddress;
        private static int m_iUserType;
#endregion

        #region Properties
        public static void SetConnectionID(int iCID)
        {
            m_iCID = iCID;
        }

        public static void SetConnectionIP(string strIPAddress)
        {
            m_strIPAddress = strIPAddress;
        }

        public static void SetUserType(int iUserType)
        {
            m_iUserType = iUserType;
        }

        public static string GetConnectionIP()
        {
            return m_strIPAddress;
        }

        public static int GetConnectionID()
        {
            return m_iCID;
        }

        public static int GetUserType()
        {
            return m_iUserType;
        }
        #endregion

        #region Methods
        public static IMSClientClass GetInstance()
        {
            if (Instance == null)
                Instance = new IMSClientClass();

            return Instance;
        }

        public static IrisSDKClass GetIrisInstance()
        {
            if (IrisInstance == null)
                IrisInstance = new IrisSDKClass();

            return IrisInstance;
        }

        /* ******************************************************************************** /
        Name		:: ReadIrisFromFile
        Description :: Reading IrisCodes from file in varying formats of IrisData
                        Supports Short and Long Iriscodes
        / ******************************************************************************* */
        public static int ReadIrisFromFile(EyeType stEyeType, int IrisCodeSize, ref byte[] byIrisCode)
        
        {
            string strFilePath = @"C:\Users\admin\Desktop\accelerator\";//Application.StartupPath ;

            //Reading short IrisCodes from file
            if (IrisCodeSize == Constants.IRISCODE_SIZE_SHORT)
            {
                if (stEyeType == EyeType.Left)
                    //Reading IrisCodes from file for Left Eye
                    strFilePath += Constants.SHORT_IRIS_CODE_FILE_LEFT;
                else
                    //Reading IrisCodes from file for Right Eye
                    strFilePath += Constants.SHORT_IRIS_CODE_FILE_RIGHT;
            }
            //Reading long IrisCodes from file
            else if (IrisCodeSize == Constants.IRISCODE_SIZE_LONG)
            {
                if (stEyeType == EyeType.Left)
                    //Reading IrisCodes from file for Left Eye
                    strFilePath += Constants.LONG_IRIS_CODE_FILE_LEFT;
                else
                    //Reading IrisCodes from file for Right Eye
                    strFilePath += Constants.LONG_IRIS_CODE_FILE_RIGHT;
            }
            else if (IrisCodeSize == Constants.IRIS_IMAGE_SIZE)
            {
                if (stEyeType == EyeType.Left)
                    //Reading IrisImage from file for Left Eye
                    strFilePath += Constants.IRIS_IMAGE_FILE_LEFT;
                else
                    //Reading IrisImage from file for Right Eye
                    strFilePath += Constants.IRIS_IMAGE_FILE_RIGHT;
            }

            if (!File.Exists(strFilePath))
            {
                //MessageBox.Show(string.Format("Iris Data file not found.{0}Insure the Iris Data file is present in '{1}'", "\n", strFilePath.Substring(0, strFilePath.LastIndexOf("\\"))), Constants.STRING_APPNAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }

			FileStream fs = new  FileStream( strFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
			BinaryReader br = new BinaryReader(fs);
            byIrisCode = br.ReadBytes(IrisCodeSize);
            br.Close();
            return 0;
        }
        #endregion
    }
}
