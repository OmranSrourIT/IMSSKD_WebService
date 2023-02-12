//*****************************************************************************
// (c)Copyright 2014. All Rights Reserved
// IrisID Systems Inc, U.S.A.
// Project Name   : IrisAccelerator 
// File Name      : Utils.cs
// Description	  : common functions
//*****************************************************************************
using System;
using System.Text.RegularExpressions;


namespace CSharp_Sample
{
    /// <summary>
    /// Summary description for Utils.
    /// </summary>
    public class Utils
    {
        public Utils()
        {
        }

        /* ******************************************************************************** /
        Name		:: IsNumeric 
        Description :: Checks for Input string to be Numeric
        / ******************************************************************************* */
        public static bool IsNumeric(string strSource)
        {
            //validation for alphanumeric.
            Regex alphanumeric = new Regex("^\\d+$");
            return (alphanumeric.IsMatch(strSource));
        }

        /* ******************************************************************************** /
        Name		:: GetCurrentYear 
        Description :: Gets current year
        / ******************************************************************************* */
        public static int GetCurrentYear()
        {
            DateTime dtCurrent = DateTime.Now;
            int iCurrYear = dtCurrent.Year;
            return iCurrYear;
        }

        /* ******************************************************************************** /
        Name		:: ErrorHandler 
        Description :: Common functon to handle all errors
        / ******************************************************************************* */
        public static void ErrorHandler(int iErrorCode, ref string strErrMsg)
        {
            switch (iErrorCode)
            {
                case -1: strErrMsg = "Error"; break;
                case -2: strErrMsg = "SSL object not created."; break;
                case -3: strErrMsg = "File Uploaded Failed."; break;
                case -4: strErrMsg = "Certificate Error Incorrect Type"; break;
                case -5: strErrMsg = "Certificate Error in Server Public,Private Keys"; break;
                case -350: strErrMsg = "Certificate Error in Security Object"; break;

                //SSL Errors
                case -12: strErrMsg = "SSL receive failed."; break;
                case -11: strErrMsg = "SSL not initialized."; break;
                case -10: strErrMsg = "SSL send failed."; break;
                case -32: strErrMsg = "SSL client initialization failed."; break;
                case -31: strErrMsg = "SSL connection failed."; break;
                case -30: strErrMsg = "SSL initializing connection failed."; break;
                case -27: strErrMsg = "SSL connect to server failed."; break;
                case -26: strErrMsg = "SSL set client key data failed due to invalid key data."; break;
                case -25: strErrMsg = "SSL set client certificate data failed may be due to invalid MACAddress or invalid certificate data."; break;
                case -24: strErrMsg = "SSL set root certificate data failed may be due to invalid date or invalid certificate data."; break;
                case -23: strErrMsg = "SSL get client key failed. Please import client key using DM application."; break;
                case -22: strErrMsg = "SSL get client certificate failed. Please import certificate using DM application."; break;
                case -21: strErrMsg = "SSL get root certificate failed. Please import certificate using DM application."; break;
                case -20: strErrMsg = "SSL initializing object failed."; break;
                case -33: strErrMsg = "Getting SSLCertificate Path from Registry failed"; break;

                // Socket Errors.
                case 257: strErrMsg = "Socket already connected."; break;
                case 258: strErrMsg = "Connection failed. Please check IP Address of IrisAccelerator."; break;
                case 259: strErrMsg = "Socket send error."; break;
                case 260: strErrMsg = "Socket receive error."; break;
                case 261: strErrMsg = "Socket parameter error."; break;
                case 262: strErrMsg = "Socket error out of memory."; break;
                case 263: strErrMsg = "Socket timeout error."; break;
                case 264: strErrMsg = "Socket not available."; break;
                case 265: strErrMsg = "Socket error invalid packet."; break;
                case 272: strErrMsg = "Socket receive timeout error"; break;
                case 273: strErrMsg = "Socket exception."; break;
                case 274: strErrMsg = "Socket unknown packet."; break;
                case 275: strErrMsg = "Socket invalid."; break;
                case 276: strErrMsg = "Socket initialisation error"; break;
                case 277: strErrMsg = "Socket invalid parameter."; break;
                case 278: strErrMsg = "Socket send error."; break;
                case 279: strErrMsg = "Controller busy."; break;
                case 280: strErrMsg = "Socket receive error."; break;
                case 281: strErrMsg = "Socket invalid pointer."; break;
                //IAFormatter Error Codes.
                case 513: strErrMsg = "IAFormatter Invalid Parameter"; break;
                case 514: strErrMsg = "IAFormatter Packet Not Set"; break;
                case 515: strErrMsg = "IAFormatter Error Memory"; break;
                case 516: strErrMsg = "IAFormatter Error Invalid Data"; break;
                case 517: strErrMsg = "IAFormatter Error Tagend"; break;
                //IAPacket Error Codes
                case 769: strErrMsg = "IAPacket Invalid Parameter"; break;
                case 770: strErrMsg = "IAPacket Packet Not Set"; break;
                case 771: strErrMsg = "IAPacket Error Memory"; break;
                case 772: strErrMsg = "IAPacket Error Invalid Data"; break;
                case 773: strErrMsg = "IAPacket Error Tagend"; break;
		//IRIS SDK Error Codes
				case 1793: strErrMsg = "IRISSDK requires successful connection to IrisAccelerator"; break;
				case 1794: strErrMsg = "IRISSDK Error in getting ISO Iris Engine version"; break;
				case 1795: strErrMsg = "IRISSDK Error in Parameter"; break;
                //IMSSDK Error Codes
                case 1025: strErrMsg = "IMSSDK Error in Parameter"; break;
                case 1026: strErrMsg = "IMSSDK Error in Serverkey"; break;
                case 1027: strErrMsg = "IMSSDK Error Certificate File"; break;
                case 1028: strErrMsg = "IMSSDK Error Create Packet"; break;
                case 1029: strErrMsg = "IMSSDK Error Decrypt Data"; break;
                case 1030: strErrMsg = "IMSSDK Error Encrypt Data"; break;
                case 1031: strErrMsg = "IMSSDK Error Read Packet"; break;
                case 1032: strErrMsg = "IMSSDK Error in Certificate"; break;
                case 1043: strErrMsg = "Could not connect to IrisAccelerator. Please install client certificate"; break;
                //IMSSDKCmd Error Codes.
                case 1537: strErrMsg = "IMSSDKCmd Error in Parameter"; break;
                case 1538: strErrMsg = "IMSSDKCmd Error Read Packet"; break;
                case 1539: strErrMsg = "IMSSDKCmd Error Invalid Command"; break;
                case 1540: strErrMsg = "IMSSDKCmd Error Out Of Memory"; break;
                case 1541: strErrMsg = "IMSSDKCmd Error Invalid Packet"; break;
                case 1544: strErrMsg = "System DateTime is changed. Disconnecting IrisController"; break;
                case 1545: strErrMsg = "IMSSDKCmd Error Invalid Protocol"; break;
                case 85: strErrMsg = "Certificate has expired. Please contact your system administrator"; break;
                case 86: strErrMsg = "Invalid Certificate. Please import correct certificate."; break;
                case 87: strErrMsg = "Certificate has been deleted. Please contact your system administrator"; break;
                //IMSFTP Error codes.
                case 1281: strErrMsg = "IMSFTPClient Error in opening FTP connection."; break;
                case 1282: strErrMsg = "IMSFTPClient Error in connecting to FTP client."; break;
                case 1283: strErrMsg = "IMSFTPClient Error no session."; break;
                case 1284: strErrMsg = "IMSFTPClient Error in putting the file."; break;
                case 1285: strErrMsg = "IMSFTPClient Error in getting the file."; break;
                case 1286: strErrMsg = "IMSFTPClient Error Deleting."; break;

		case 1313: strErrMsg = "IrisImage Quality Threshold is less than required value."; break;

                case 4: strErrMsg = "SDK User doesn't have proper rights for the API"; break;
                case 8: strErrMsg = "No Memory"; break;
                case 13: strErrMsg = "IrisSABRE not connected to process request"; break;
                case 14: strErrMsg = "Specified IrisCode does not exist"; break;
                case 15: strErrMsg = "Specified IrisCode already exists"; break;
                case 16: strErrMsg = "User Record does not exist"; break;
                case 17: strErrMsg = "Incorrect Data"; break;
                case 18: strErrMsg = "Unknown error"; break;
                case 19: strErrMsg = "Left Eye of user already enrolled"; break;
                case 20: strErrMsg = "Right Eye of user already enrolled"; break;
                case 21: strErrMsg = "Both Eyes of user already enrolled"; break;
                case 23: strErrMsg = "Request not being processed due to load balancing"; break;
                case 25: strErrMsg = "Request IriSABRE (Blade ID) does not exist"; break;
                case 27: strErrMsg = "Lost Heartbeat to IriSABRE"; break;
                case 28: strErrMsg = "Exceeded Max IrisCode limit supported per IriSABRE"; break;
                case 29: strErrMsg = "Received System Alarm at IrisController"; break;
                case 30: strErrMsg = "Hamming Threshold value is incorrect"; break;
                case 31: strErrMsg = "Operator Invalid"; break;
                case 32: strErrMsg = "Unknown SDK Request"; break;
                case 33: strErrMsg = "Login failed. Please check Username and Password."; break;
                case 34: strErrMsg = "Password cannot be blank or just spaces."; break;
                case 37: strErrMsg = "Load balancing failed"; break;
                case 38: strErrMsg = "Could not get bsmp Host ID for IrisController"; break;
                case 39: strErrMsg = "Cannot connect multiple IriSABRE from one blade. "; break;
                case 40: strErrMsg = "IriSABRE connecting from Blade 0. Blade 0 is for IrisController"; break;
                case 41: strErrMsg = "IriSABRE connecting from an Invalid Blade"; break;
                case 42: strErrMsg = "Reboot requires application to run in super user mode"; break;
                case 43: strErrMsg = "Operator exists in IrisAccelerator. "; break;
                case 44: strErrMsg = "Admin User cannot be added or removed."; break;
                case 45: strErrMsg = "Unhealthy SABRE! Disconnected IriSABRE."; break;
                case 46: strErrMsg = "SDK User Certificate Not verified."; break;
                case 48: strErrMsg = "IriSABRE version incorrect"; break;
                case 49: strErrMsg = "SDK version incorrect"; break;
                case 50: strErrMsg = "IrisController version incorrect"; break;
                case 51: strErrMsg = "Could not read version from version file"; break;
                case 53: strErrMsg = "IrisController DB version incorrect"; break;
                case 54: strErrMsg = "Invalid SNMP User."; break;
                case 55: strErrMsg = "Max Iriscode limit not defined."; break;
                case 56: strErrMsg = "Error during upgrade."; break;
                case 57: strErrMsg = "Load Balancing started."; break;
                case 60: strErrMsg = "Certificate Error in IrisController during client verification"; break;
                case 62: strErrMsg = "Match queue is full.No more requests being accepted."; break;
                case 63: strErrMsg = "SNMP request timedout."; break;
                case 64: strErrMsg = "SNMP request for reboot failed."; break;
                case 66: strErrMsg = "Standby IriSABRE not identified."; break;
                case 67: strErrMsg = "Invalid slot identified for Standby IriSABRE."; break;
                case 70: strErrMsg = "System is under maintenance. Please try later."; break;
                case 5: strErrMsg = "ErrorMessage:5 Message Not Found"; break;
                case 7: strErrMsg = "ErrorMessage:7 Message Not Found"; break;
                case 9: strErrMsg = "ErrorMessage:9 Message Not Found"; break;
                case 10: strErrMsg = "ErrorMessage:10 Message Not Found"; break;
                case 11: strErrMsg = "ErrorMessage:11 Message Not Found"; break;
                case 12: strErrMsg = "ErrorMessage:12 Message Not Found"; break;
                case 22: strErrMsg = "ErrorMessage:22 Message Not Found"; break;
                case 24: strErrMsg = "ErrorMessage:24 Message Not Found"; break;
                case 47: strErrMsg = "ErrorMessage:47 Message Not Found"; break;
                case 52: strErrMsg = "ErrorMessage:52 Message Not Found"; break;
                //Backup and restore errors.
                case 71: strErrMsg = "Data error.Invalid Backup&Restore arguments or type of backup."; break;
                case 72: strErrMsg = "Invalid Permissions.Please run the controller in super user mode."; break;
                case 73: strErrMsg = "Mysql backup error."; break;
                case 74: strErrMsg = "Mysql full recovery error."; break;
                case 75: strErrMsg = "Mysql incremental recovery error."; break;
                case 76: strErrMsg = "Invalid host."; break;
                case 77: strErrMsg = "Invalid userid/password."; break;
                case 78: strErrMsg = "Invalid full file name."; break;
                case 79: strErrMsg = "Invalid incremental file name."; break;
                case 80: strErrMsg = "Insufficient storage error."; break;
                case 81: strErrMsg = "Unknown Ftp error."; break;
                case 82: strErrMsg = "Backup/ Restore failed, Script file not found."; break;
                case 83: strErrMsg = "Backup/ Restore failed, No execute permission for script."; break;
                case 84: strErrMsg = "Failed to connect to the database."; break;
                case 90: strErrMsg = "IrisCode exceeds the License limit."; break;
				case 129: strErrMsg = "UserID violated."; break;
				case 130: strErrMsg = "Requested user already updated."; break;
				case 131: strErrMsg = "Requested eye does not exist."; break;
                case -100:
                case -101:
                case 232:
                case 1287: strErrMsg = "Failed to read system MACAddress."; break;
		case -2147414015: strErrMsg = "No Match found"; break;
                default: strErrMsg = iErrorCode.ToString() + ":Error Description not found.";
                    break;

            }
        }
    }
}
