using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Xamarin;
using Flurry.Analytics;

namespace Appcachstorage
{

    public class WebService
    {
#if QA
		public const string kWJIV_API_Endpoint_Host = "https://wjqamobileservice.rpcsys.hmco.com";
		public const string HOST = "wjqamobileservice.rpcsys.hmco.com";
#elif STAGING
		public const string kWJIV_API_Endpoint_Host        =         "https://wj4stgmobileservice.rpclearning.com";
		public const string HOST                 =                    "wj4stgmobileservice.rpclearning.com";
#else
        public const string kWJIV_API_Endpoint_Host = "https://wjscoremobileservice.com";
        public const string HOST = "wjscoremobileservice.com";
#endif
        public const string GetUpdateAndCheckTestRecordInUse = kWJIV_API_Endpoint_Host + "/TestForm/GetUpdateAndCheckTestRecordInUse?subjectTestInstanceId=%a&inUseUserId=%b";
        public const string GetUserService = kWJIV_API_Endpoint_Host + "/user/Getuser?version=%a";
        public const string ForgotPassword_SERVICE = kWJIV_API_Endpoint_Host + "/Account/ForgotPassword";
        public const string LastActionPerformedCaseloadURL = kWJIV_API_Endpoint_Host + "/Caseload/PostLastActionPerformed";
        public const string RecentExaminee_SERVICE = kWJIV_API_Endpoint_Host + "/Caseload/GetAllSubjectsByCid?caseFolderId=%d";
        public const string Acedemicyears_SERVICE = kWJIV_API_Endpoint_Host + "/Caseload/GetCaseloadYears?UserID=%d";
        public const string CaseLoadFolder_Service = kWJIV_API_Endpoint_Host + "/Caseload/GetAllCaseFolders?userId=%d&includecasefolder=%p&pageNum=1&numOfRows=1&academicYear=%f";
        public const string SharedCaseLoad_service_ah = kWJIV_API_Endpoint_Host + "/Caseload/GetAllUsersForAh?OrganizationID=%d&userType=%e&userid=%f";
        public const string sharedcaseload_service_ad_ex = kWJIV_API_Endpoint_Host + "/Caseload/GetAllSharedCaseFolders?userId=%d";
        public const string examinee_dwnld_service = kWJIV_API_Endpoint_Host + "/OfflineMobile/GetSubjectDetailsByCasefolderIdsOffline?cIds=%d&userIds=%f";
        public const string Gender_service = kWJIV_API_Endpoint_Host + "/Subject/GetGenders";
        public const string Language_service = kWJIV_API_Endpoint_Host + "/Subject/GetLanguages";
        public const string Ethnicites_service = kWJIV_API_Endpoint_Host + "/Subject/GetEthnicities";
        public const string Race_service = kWJIV_API_Endpoint_Host + "/Subject/GetRace";
        public const string FundingSources_service = kWJIV_API_Endpoint_Host + "/Subject/GetFundingSources";
        public const string Diagnosis_service = kWJIV_API_Endpoint_Host + "/Subject/GetDiagnosis";
        public const string UserIdentifyFields_service = kWJIV_API_Endpoint_Host + "/Subject/GetResearchCodesOfOrg";
        public const string ExamineeCaseFolders_Service = kWJIV_API_Endpoint_Host + "/Subject/GetcaseFolders?userId=%d";
        public const string PostAddExaminee_SERVICE = kWJIV_API_Endpoint_Host + "/Subject/PostSubject";
        public const string GetEditExaminee_SERVICE = kWJIV_API_Endpoint_Host + "/Subject/GetEditSubject?id=%a";
        public const string PostEditExaminee_SERVICE = kWJIV_API_Endpoint_Host + "/Subject/PostEditSubject";
        public const string GetDeleteExamineeFromDasboard_SERVICE = kWJIV_API_Endpoint_Host + "/Subject/GetDeleteSubject?userId=%a&cid=%b&PageFrom1=%c";
        public const string AddCaseloadfolder_SERVICE = kWJIV_API_Endpoint_Host + "/Caseload/PostCasefolder";
        public const string EditCaseloadfolder_SERVICE = kWJIV_API_Endpoint_Host + "/Caseload/PostEditCasefolder";
        public const string SearchCaseloadfolder_SERVICE = kWJIV_API_Endpoint_Host + "/Caseload/GetSearchCaseFolder?Title=%a&ExaminerFirstName=%b&ExaminerLastName=%c&ExaminerEmailAddress=%d&pageNum=0&numOfRows=100&userType=null";
        public const string DeleteCaseloadfolder_SERVICE = kWJIV_API_Endpoint_Host + "/Caseload/GetDeleteCasefolderSelected?ids=%a";
        public const string Searchexaminee_SERVICE = kWJIV_API_Endpoint_Host + "/Subject/GetExaminees?firstname=%a&lastname=%b&dateofbirth=%c&examineeId=%d&examiner=%e&withDeletedTestRecordsOnly=%f&onlyDeletedSubjects=%g";
        public const string GetExamineeInfo_SERVICE = kWJIV_API_Endpoint_Host + "/Subject/GetSubjectTestRecord?id=%a&cid=%b";
        public const string GetAllTestRecord_SERVICE = kWJIV_API_Endpoint_Host + "/TestForm/GetTestRecordByOrganization?userId=%a";
        public const string PostTestForms = kWJIV_API_Endpoint_Host + "/TestForm/SaveTestRecord";
        public const string GetEditTestForm = kWJIV_API_Endpoint_Host + "/TestForm/GetEditTestForm?subjectTestInstanceId=%d";
        public const string PostTestForm = kWJIV_API_Endpoint_Host + "/TestForm/PostSubjectTestInstance";
        public const string AutoFillExaminerName = kWJIV_API_Endpoint_Host + "/TestForm/GetAutoExaminerName?text=%a";
        public const string OfflineMasterDownload = kWJIV_API_Endpoint_Host + "/OfflineMobile/GetOfflineMobileDetails";
        public const string offlineTestRecordDownload = kWJIV_API_Endpoint_Host + "/OfflineMobile/GetTestRecordDetailsOffline?iDs=%a&subjectInstanceIds=%b";
        public const string CaseloadbyAcademicyear = kWJIV_API_Endpoint_Host + "/Caseload/GetallCasefoldersforOfflineDownload?acedemicYear=%a";
        public const string CheckExaminerRoles = kWJIV_API_Endpoint_Host + "/OfflineMobile/PostCheckExaminerRoles";

        public const string OfflineSubjectsSync = kWJIV_API_Endpoint_Host + "/OfflineMobile/PostAllOfflineExaminees";

        public const string OfflineCasefoldersSync = kWJIV_API_Endpoint_Host + "/OfflineMobile/PostAllOfflineCasefolders";

        public const string OfflineTestRecordSync = kWJIV_API_Endpoint_Host + "/OfflineMobile/PostAllOfflineTestrecords";

        public const string GetMobileReportName = kWJIV_API_Endpoint_Host + "/Subject/GetMobileReportNames";
        public const string GetReportDetails = kWJIV_API_Endpoint_Host + "/Subject/GetReportDetails";
        public const string GetReportCasefldrs = kWJIV_API_Endpoint_Host + "/Subject/GetMobileCaseFolders?productId=%a";
        public const string GetMobileStudents = kWJIV_API_Endpoint_Host + "/Subject/GetMobileStudents?caseFolderId=%a&productId=%b";

        public const string GetStudentsTestRecords = kWJIV_API_Endpoint_Host + "/Subject/GetStudentTestRecords?studentId=%a&productId=%b";

        public const string GetMobileAddTemplate = kWJIV_API_Endpoint_Host + "/Subject/GetMobileAddTemplate?reportTypeId=%a&productId=%b&normativeBasisId=%c";
        public const string PostTemplate = kWJIV_API_Endpoint_Host + "/Subject/PostTemplate";
        public const string GetVariations = kWJIV_API_Endpoint_Host + "/Subject/GetVariations";

        public const string GetOptionalScores = kWJIV_API_Endpoint_Host + "/Subject/GetOptionalScores";

        public const string GetStudentTestRecords = kWJIV_API_Endpoint_Host + "/Subject/GetStudentTestRecords?studentId=%a&productId=%b";
        public const string GetComparison = kWJIV_API_Endpoint_Host + "/Subject/GetComparison";
        public const string DefaultTemplates = kWJIV_API_Endpoint_Host + "/Subject/GetDefaultTemplates?reportTypeId=%a";
        public const string GetTemplateById = kWJIV_API_Endpoint_Host + "/Subject/GetTemplateById?templateId=%a&reportTypeId=%b&productId=%c&normativeBasisId=%d";
        //
        public const string GetDeleteById = kWJIV_API_Endpoint_Host + "/Subject/GetDeleteTemplate?templateId=%a";
        public const string RunReport = kWJIV_API_Endpoint_Host + "/Subject/GetRunReport?studentId=%a&testRecordForms=%b&normativeBasis=%c&optionalScores=%d&variations=%e&comparisons=%f&templateId=%g&groupingOption=%h" +
                                        "&outputFormat=%i&productId=%j&isSave=%k&reportTitle=%l&reportTypeId=%m&subReportTypeId=%n&languageid=%o";
        public const string GetDeleteTemplate = kWJIV_API_Endpoint_Host + "/Subject/GetDeleteTemplate?templateId=%a";
        public const string GetOfflineExamineeSearch = kWJIV_API_Endpoint_Host + "/OfflineMobile/GetOfflineExamineeDownloadSearch?firstname=%a&lastname=%b&dateofbirthfrom=%c&dateofbirthfromto=%d&examineeId=%e&examiner=%f&cids=%g";
        public const string GetRestoreTestRecord = kWJIV_API_Endpoint_Host + "/Subject/GetRestoreRecords?subjectId=%a";
        public const string GetDeleteTestRecord = kWJIV_API_Endpoint_Host + "/Subject/GetDeleteTestrecords?testInstanceIds=%a";
        public const string CheckExaminerRolesforReconcile = kWJIV_API_Endpoint_Host + "/OfflineMobile/GetCheckExaminerRolesforReconcile?loginUserId=%a&editeduserid=%b";
        public const string CheckEditPermission = kWJIV_API_Endpoint_Host + "/OfflineMobile/GetCheckExamineeEditPermissionforReconcile?studentId=%a&roleId=%b&createdBy=%c&userId=%d&examiners=%e&organizationId=%f";
        public const string CheckTestRecordEditPermission = kWJIV_API_Endpoint_Host + "/OfflineMobile/GetCheckTestRecordEditPermissionforReconcile?studentId=%a&roleId=%b&createdBy=%c&userId=%d&examiners=%e&organizationId=%f";
        public const string CheckDateofBithLessthan2 = kWJIV_API_Endpoint_Host + "/OfflineMobile/GetCheckDateOfBirth?studentId=%a";

        public const string GetAllExaminers = kWJIV_API_Endpoint_Host + "/TestForm/GetExaminers?orgId=%a";
        public const string GetRestoreSubject = kWJIV_API_Endpoint_Host + "/Subject/GetRestoreSubject?userids=%a";


        public static async Task<string> PostLoginRequestWithUsernamePasswordAsync(string urlString, string userauth)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlString);
            request.Method = "GET";
            request.Headers.Add("Authorization", userauth);
            request.ContentType = "application/json";
            request.Timeout = 30000;
            request.Host = HOST;
            try
            {
                using (var response = await request.GetResponseAsync())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var responseString = reader.ReadToEnd();
                        return responseString;
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }
    }

    public partial class CryptLib
    {
        public string EncryptString(string plainSourceStringToEncrypt, string passPhrase)
        {
            //Set up the encryption objects
            using (AesCryptoServiceProvider acsp = GetProvider(Encoding.Default.GetBytes(passPhrase)))
            {
                byte[] sourceBytes = Encoding.ASCII.GetBytes(plainSourceStringToEncrypt);
                ICryptoTransform ictE = acsp.CreateEncryptor();

                //Set up stream to contain the encryption
                MemoryStream msS = new MemoryStream();

                //Perform the encrpytion, storing output into the stream
                CryptoStream csS = new CryptoStream(msS, ictE, CryptoStreamMode.Write);
                csS.Write(sourceBytes, 0, sourceBytes.Length);
                csS.FlushFinalBlock();

                //sourceBytes are now encrypted as an array of secure bytes
                byte[] encryptedBytes = msS.ToArray(); //.ToArray() is important, don't mess with the buffer

                //return the encrypted bytes as a BASE64 encoded string
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        private static AesCryptoServiceProvider GetProvider(byte[] key)
        {
            AesCryptoServiceProvider result = new AesCryptoServiceProvider();
            result.BlockSize = 128;
            result.KeySize = 128;
            result.Mode = CipherMode.CBC;
            result.Padding = PaddingMode.PKCS7;

            result.GenerateIV();
            result.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            byte[] RealKey = GetKey(key, result);
            result.Key = RealKey;
            // result.IV = RealKey;
            return result;
        }

        private static byte[] GetKey(byte[] suggestedKey, SymmetricAlgorithm p)
        {
            byte[] kRaw = suggestedKey;
            var kList = new List<byte>();

            for (int i = 0; i < p.LegalKeySizes[0].MinSize; i += 8)
            {
                kList.Add(kRaw[(i / 8) % kRaw.Length]);
            }
            byte[] k = kList.ToArray();
            return k;
        }

    }
}