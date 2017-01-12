using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StackModel;
using System.ServiceModel.Web;
using TagSpecifiedDataOperation.ForDeliveryTool;
using System.ServiceModel.Activation;

namespace StackoverflowDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ThreadsGeneration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ThreadsGeneration.svc or ThreadsGeneration.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ThreadsGeneration : IThreadsGeneration
    {
        [WebGet(UriTemplate = "/GetAllQuestion?fromdate={fromdate}&todate={todate}&owner={owner}&scenarioId={scenarioId}&status={status}&delivery={delivery}", ResponseFormat = WebMessageFormat.Json)]
        public List<Question> GetAllQuestion(string fromdate, string todate, string owner, string scenarioId, string status, string delivery)
        {
            ///testing
            //fromdate = "3/25/2015";
            //todate = "12/2/2016";
            //owner = "all";
            //scenarioId = "all"; status = "All";delivery = "3";
            ///////////////////
            return new BLL().GetAllQuestion(fromdate, todate, owner, scenarioId, status, delivery);
        }

        [WebGet(UriTemplate = "/TakeThreadOwner?alias={alias}&istake={istake}&question_id={question_id}", ResponseFormat = WebMessageFormat.Json)]
        public TakeOwner TakeThreadOwner(string alias, string istake, string question_id)
        {
            return new BLL().TakeThreadOwner(alias, istake, question_id);
        }

        [WebGet(UriTemplate = "/SetThreadStatus?status={status}&question_id={question_id}", ResponseFormat = WebMessageFormat.Json)]
        public void SetThreadStatus(string status, string question_id)
        {
            new BLL().SetThreadStatus(status, question_id);
        }
        [WebGet(UriTemplate = "/GetMyProfile", ResponseFormat = WebMessageFormat.Json)]
        public string GetMyProfile()
        {
            return new BLL().GetMyProfile();
        }
        [WebGet(UriTemplate = "/SetMyProfile?sofID={sofID}", ResponseFormat = WebMessageFormat.Json)]
        public string SetMyProfile(string sofID)
        {
            return new BLL().SetMyProfile(sofID);
        }

        [WebGet(UriTemplate = "/GetDashBoardProperties", ResponseFormat = WebMessageFormat.Json)]
        public DashBoard GetDashBoardProperties()
        {
            return new BLL().GetDashBoardProperties();
        }
        [WebGet(UriTemplate = "/GetDashBoardDate?scenarioId={scenarioId}&status={status}&delivery={delivery}", ResponseFormat = WebMessageFormat.Json)]
        public DashBoardData GetDashBoardDate(string scenarioId,string status,string delivery)
        {
            return new BLL().GetDashBoardDate(scenarioId, status, delivery);
        }
        [WebGet(UriTemplate = "/GetScenarios", ResponseFormat = WebMessageFormat.Json)]
        public List<Scenario> GetScenarios()
        {
            return new BLL().GetAllScenarios();
        }
        [WebGet(UriTemplate = "/GetSElist", ResponseFormat = WebMessageFormat.Json)]
        public List<SupportEngineer> GetSElist()
        {
            return new BLL().GetSElist();
        }
        [WebGet(UriTemplate = "/LogUTData?question_id={question_id}&UT={UT}&UTComments={utcomments}", ResponseFormat = WebMessageFormat.Json)]
        public int LogUTData(string question_id, int UT, string UTComments)
        {
            return new BLL().LogUTData(question_id, UT, UTComments);
        }
        [WebGet(UriTemplate = "/GetScenarioMetricsByDate?fromdate={fromdate}&todate={todate}&cateNames={cateNames}&Scope={Scope}", ResponseFormat = WebMessageFormat.Json)]
        public List<ScenarioMetrics> GetScenarioMetricsByDate(string fromdate, string todate, string cateNames, string Scope)
        {
            return new BLL().GetScenarioMetricsByDate(fromdate,todate,cateNames,Scope);
        }
        [WebGet(UriTemplate = "/SetCustomerComment?question_id={question_id}&alias={alias}&status={status}&cusomercomments={cusomercomments}", ResponseFormat = WebMessageFormat.Json)]
        public void SetCustomerComment(string question_id, string alias, int status, string cusomercomments)
        {
            new DAL().UpdateCustomerComments(question_id, alias, status, cusomercomments);
        }
        [WebGet(UriTemplate = "/GetCustomerComment?question_id={question_id}", ResponseFormat = WebMessageFormat.Json)]
        public string GetCustomerComment(string question_id)
        {
            return new DAL().GetCustomerComments(question_id);

        }
        [WebGet(UriTemplate = "/GetLaborsByQuetionID?question_id={question_id}", ResponseFormat = WebMessageFormat.Json)]
        public List<Labors> GetLaborsByQuetionID(string question_id)
        {
            return new BLL().GetLaborsByQuetionID(question_id);
        }
        [WebInvoke(Method ="GET", UriTemplate = "/SetQualityReview?question_id={question_id}&points={points}&comment={comment}&create_time={create_time}&create_by={create_by}&isfixed={isfixed}&alias={alias}&isnotified={isnotified}&status={status}", ResponseFormat = WebMessageFormat.Json)]
        public void SetQualityReview( string question_id, int points, string comment, string create_time, string create_by, string isfixed, string alias, string isnotified, string status)
        {
            new BLL().SetQualityReview(question_id, points, comment, create_time, create_by, isfixed, alias, isnotified, status);
        }
        [WebGet(UriTemplate = "/GetQRByQuetionID?question_id={question_id}", ResponseFormat = WebMessageFormat.Json)]
        public List<QualityReview> GetQRByQuetionID(string question_id)
        {
            return new BLL().GetQRByQuetionID(question_id);
        }
        [WebInvoke(Method = "GET", UriTemplate = "/SetQualityReview_eng?question_id={question_id}&QR_id={QR_id}&alias={alias}&create_time={create_time}&eng_comment={eng_comment}&action={action}", ResponseFormat = WebMessageFormat.Json)]
        public void SetQualityReview_eng(string question_id, string QR_id, string alias, string create_time, string eng_comment, string action)
        {
            new BLL().SetQualityReview_eng(question_id, QR_id, alias, create_time, eng_comment, action);
        }
        [WebGet(UriTemplate = "/GetQR_eng_ByQuetionID?question_id={question_id}", ResponseFormat = WebMessageFormat.Json)]
        public List<QualityReview_eng> GetQR_eng_ByQuetionID(string question_id)
        {
            return new BLL().GetQR_eng_ByQuetionID(question_id);
        }
        [WebInvoke(Method = "GET", UriTemplate = "/SetVirtualTeam?question_id={question_id}&team={team}&assigned_by={assigned_by}", ResponseFormat = WebMessageFormat.Json)]
        public void SetVirtualTeam(string question_id, string team,string assigned_by)
        {
            new BLL().SetVirtualTeam(question_id, team, assigned_by);
        }
        [WebGet(UriTemplate = "/SetupdatedVirtualTeam?question_id={question_id}&team={team}", ResponseFormat = WebMessageFormat.Json)]
        public void SetupdatedVirtualTeam(string question_id, string team)
        {
            new DAL().SetupdatedVirtualTeam(question_id, team);
        }
        [WebGet(UriTemplate = "/GetVirtualTeam?question_id={question_id}", ResponseFormat = WebMessageFormat.Json)]
        public List<VirtualTeam> GetVirtualTeam(string question_id)
        {
            return new BLL().GetVirtualTeam(question_id);
        }
        [WebGet(UriTemplate = "/GetSupportTeam", ResponseFormat = WebMessageFormat.Json)]
        public List<SupportTeam> GetSupportTeam()
        {
            return new BLL().GetSupportTeam();
        }

    }
}
