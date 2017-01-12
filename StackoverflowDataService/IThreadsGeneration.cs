using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StackModel;

namespace StackoverflowDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IThreadsGeneration" in both code and config file together.
    [ServiceContract]
    public interface IThreadsGeneration
    {

        [OperationContract]
        List<Question> GetAllQuestion(string fromdate, string todate, string owner, string scenarioId, string status, string delivery);
        [OperationContract]
        TakeOwner TakeThreadOwner(string alias, string istake, string question_id);
        [OperationContract]
        void SetThreadStatus(string status, string question_id);
        [OperationContract]
        string GetMyProfile();
        [OperationContract]
        string SetMyProfile(string sofID);
        [OperationContract]
        DashBoard GetDashBoardProperties();
        [OperationContract]
        DashBoardData GetDashBoardDate(string scenarioId, string status, string delivery);
        [OperationContract]
        List<Scenario> GetScenarios();
        [OperationContract]
        List<SupportEngineer> GetSElist();
        [OperationContract]
        int LogUTData(string question_id, int UT, string UTComments);
        [OperationContract]
        List<ScenarioMetrics> GetScenarioMetricsByDate(string fromdate, string todate, string cateNames, string Scope);
        [OperationContract]
        void SetCustomerComment(string question_id, string alias, int status, string cusomercomments);
        [OperationContract]
        string GetCustomerComment(string question_id);
        [OperationContract]
        List<Labors> GetLaborsByQuetionID(string question_id);
        [OperationContract]
        void SetQualityReview(string question_id, int points, string comment, string create_time, string create_by, string isfixed, string alias, string isnotified, string status);

        [OperationContract]
        List<QualityReview> GetQRByQuetionID(string question_id);

        [OperationContract]
        void SetQualityReview_eng(string question_id, string QR_id, string alias, string create_time, string eng_comment, string action);
        [OperationContract]
        List<QualityReview_eng> GetQR_eng_ByQuetionID(string question_id);
        [OperationContract]
        void SetVirtualTeam(string question_id, string team, string assigned_by);
        [OperationContract]
        void SetupdatedVirtualTeam(string question_id, string team);
        [OperationContract]
        List<VirtualTeam> GetVirtualTeam(string question_id);
        [OperationContract]      
        List<SupportTeam> GetSupportTeam();
    }
}
