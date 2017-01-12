using StackModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagSpecifiedDataOperation.ForDeliveryTool
{
    public class BLL
    {
        public BLL()
        { }
        private string GetIRTHoursFormat(long seconds)
        {
            float hours = seconds / 3600;
            return hours.ToString();
        }
        public List<Question> GetAllQuestion(string fromdate, string todate, string owner, string scenarioId, string status, string delivery)
        {
            List<Question> questionlist = new List<Question>();
            DataTable dt = null;
            dt = new DAL().GetQuestionByThreadsStatus(fromdate, todate, owner, scenarioId, status, delivery);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Question question = new Question();
                    question.Question_id = Convert.ToInt32(dt.Rows[i]["question_id"]);
                    if (dt.Rows[i]["support_alias"] == null || dt.Rows[i]["support_alias"] == DBNull.Value)
                    {
                        question.Support_alias = string.Empty;
                    }
                    else
                    {
                        question.Support_alias = dt.Rows[i]["support_alias"].ToString();
                    }
                    question.Title = dt.Rows[i]["title"].ToString(); ;
                    question.Link = dt.Rows[i]["link"].ToString(); ;
                    question.status = dt.Rows[i]["status"].ToString();
                    question.Body = new DAL().GetThreadBodyByQuestionID(question.Question_id.ToString()).Replace("'", "＇").Replace("\"", "＂");
                    question.Create_date = new CommonOperation().UnixStamptoDateTime(Convert.ToInt32(dt.Rows[i]["creation_date"])).ToString();
                    question.Active_date = new CommonOperation().UnixStamptoDateTime(Convert.ToInt32(dt.Rows[i]["last_activity_date"])).ToString();
                    question.IRT = dt.Rows[i]["IRT"].ToString();
                    question.Tags = new []{dt.Rows[i]["tags"].ToString()};
                    question.UTData = new DAL().GetUTDataByQuestionID(question.Question_id.ToString());
                    questionlist.Add(question);
                }
            }
            return questionlist;
        }
        public TakeOwner TakeThreadOwner(string alias, string istake, string question_id)
        {
            TakeOwner takeowner = null;
            string myalias = System.Web.HttpContext.Current.User.Identity.Name.Substring(System.Web.HttpContext.Current.User.Identity.Name.IndexOf("\\") + 1);
            if (Convert.ToBoolean(istake))
            {
                if (new DAL().IsSupport(alias))
                {
                    new DAL().UnlockThread(question_id);
                    new DAL().LockThread(question_id, alias);
                    takeowner = new TakeOwner();
                    takeowner.TakeOwnerResult = true;
                    takeowner.ErrorMessage = "take ownership success";
                }
                else
                {

                    takeowner = new TakeOwner();
                    takeowner.TakeOwnerResult = false;
                    takeowner.ErrorMessage = "SE is not registered as a support for stackoverflow, please fill the profile first!";
                }
            }
            else
            {
                DataTable dt = new DAL().GetThreadOwnerByQeusionID(question_id);
                if (dt.Rows[0]["support_alias"].ToString() != myalias)
                {
                    takeowner = new TakeOwner();
                    takeowner.TakeOwnerResult = false;
                    takeowner.ErrorMessage = "You are not the owner of this thread, could not unlock it!";
                }
                else
                {
                    //unlock
                    new DAL().UnlockThread(question_id);
                    takeowner = new TakeOwner();
                    takeowner.TakeOwnerResult = true;
                    takeowner.ErrorMessage = "unlock success";
                }
            }
            return takeowner;
            //if (myalias.Equals(alias))
            //{
            //    if (new DAL().IsSupport(alias))
            //    {
            //        DataTable dt = new DAL().GetThreadOwnerByQeusionID(question_id);
            //        if (dt != null)
            //        {
            //            if (Convert.ToBoolean(istake))
            //            {
            //                takeowner = new TakeOwner();
            //                takeowner.TakeOwnerResult = false;
            //                takeowner.ErrorMessage = "This thread has already been locked! Please refresh page to see the updated status!";
            //            }
            //            else
            //            {
            //                if (dt.Rows[0]["support_alias"].ToString() != alias)
            //                {
            //                    takeowner = new TakeOwner();
            //                    takeowner.TakeOwnerResult = false;
            //                    takeowner.ErrorMessage = "You are not the owner of this thread, could not unlock it!";
            //                }
            //                else
            //                {
            //                    //unlock
            //                    new DAL().UnlockThread(question_id);
            //                    takeowner = new TakeOwner();
            //                    takeowner.TakeOwnerResult = true;
            //                    takeowner.ErrorMessage = "unlock success";
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (Convert.ToBoolean(istake))
            //            {
            //                // take owner
            //                new DAL().LockThread(question_id,alias);
            //                takeowner = new TakeOwner();
            //                takeowner.TakeOwnerResult = true;
            //                takeowner.ErrorMessage = "lock success";
            //            }
            //            else
            //            {
            //                // already been unlocked
            //                takeowner = new TakeOwner();
            //                takeowner.TakeOwnerResult = false;
            //                takeowner.ErrorMessage = "This thread has already been un-locked! Please refresh page to see the updated status!";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        takeowner = new TakeOwner();
            //        takeowner.TakeOwnerResult = false;
            //        takeowner.ErrorMessage = "You are not registered as a support for stackoverflow, please fill your profile first!";
            //    }
            //}
            //else
            //{
            //    //takeowner = new TakeOwner();
            //    //takeowner.TakeOwnerResult = false;
            //    //takeowner.ErrorMessage = "Your client identity is not correct, please login again!";

            //    // Dispatch owner
            //    new DAL().UnlockThread(question_id);
            //    new DAL().LockThread(question_id, alias);
            //    takeowner = new TakeOwner();
            //    takeowner.TakeOwnerResult = true;
            //    takeowner.ErrorMessage = "Dispatch success";
            //}

        }
        public void SetThreadStatus(string status, string question_id)
        {
            new DAL().SetThreadStatus(status, question_id);
        }
        public string GetMyProfile()
        {
            string myalias = System.Web.HttpContext.Current.User.Identity.Name.Substring(System.Web.HttpContext.Current.User.Identity.Name.IndexOf("\\") + 1);
            return new DAL().GetMyProfile(myalias);
        }
        public string SetMyProfile(string sofID)
        {
            string myalias = System.Web.HttpContext.Current.User.Identity.Name.Substring(System.Web.HttpContext.Current.User.Identity.Name.IndexOf("\\") + 1);
            string mysofID = new DAL().GetMyProfile(myalias);
            if (mysofID != string.Empty)
            {
                new DAL().UpdateMyProfile(myalias, sofID);
                return "Update Success";
            }
            else
            {
                new DAL().AddMyProfile(myalias, sofID);
                return "Add New Success";
            }
        }

        public DashBoard GetDashBoardProperties()
        {
            DashBoard db = new DashBoard();
            db.alias = System.Web.HttpContext.Current.User.Identity.Name.Substring(System.Web.HttpContext.Current.User.Identity.Name.IndexOf("\\") + 1);
            db.fromdate = DateTime.Now.AddMonths(-1).ToString("MM/dd/yyyy");
            db.todate = DateTime.Now.ToString("MM/dd/yyyy");
            return db;
        }

        public DashBoardData GetDashBoardDate(string scenarioId, string status, string delivery)
        {
            string myalias = System.Web.HttpContext.Current.User.Identity.Name.Substring(System.Web.HttpContext.Current.User.Identity.Name.IndexOf("\\") + 1);
            string fromdate = DateTime.Now.AddMonths(-1).ToString("MM/dd/yyyy");
            string todate = DateTime.Now.ToString("MM/dd/yyyy");
            List<Question> listTotal = this.GetAllQuestion(fromdate, todate, "all", scenarioId, status, delivery);
            List<Question> listPersonal = this.GetAllQuestion(fromdate, todate, myalias, scenarioId, status, delivery);
            DashBoardData dbdate = new DashBoardData();
            dbdate.Total = listTotal.Count();
            dbdate.Personal = listPersonal.Count();
            return dbdate;
        }

        public List<Scenario> GetAllScenarios()
        {
            List<Scenario> scenarioslist = new List<Scenario>();
            DataTable dt = new DAL().GetAllScenarios();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Scenario scenario = new Scenario();
                    scenario.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    scenario.ScenarioName = dt.Rows[i]["ScenarioName"].ToString();
                    scenario.Category = dt.Rows[i]["Category"].ToString();
                    scenario.Tags = dt.Rows[i]["Tags"].ToString();
                    scenario.Description = dt.Rows[i]["Description"].ToString();
                    scenarioslist.Add(scenario);
                }
            }
            return scenarioslist;
        }
        public List<SupportEngineer> GetSElist()
        {
            List<SupportEngineer> supportEnglist = new List<SupportEngineer>();
            DataTable dt = new DAL().GetSupportEngList();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SupportEngineer se = new SupportEngineer();
                    se.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    se.Alias = dt.Rows[i]["alias"].ToString();
                    se.DisplayName = dt.Rows[i]["DisplayName"].ToString();
                    se.StackoverflowID = dt.Rows[i]["stackoverflow_user_id"].ToString();
                    supportEnglist.Add(se);
                }
            }
            return supportEnglist;
        }
        public int LogUTData(string question_id, int UT, string UTComments)
        {
            string myalias = System.Web.HttpContext.Current.User.Identity.Name.Substring(System.Web.HttpContext.Current.User.Identity.Name.IndexOf("\\") + 1);
            string LogDate = new CommonOperation().DateTimetoUnixStamp(DateTime.Now).ToString();
            int currentUT = new DAL().GetUTDataByQuestionID(question_id);
            new DAL().AddUTData(question_id, myalias, UT, UTComments, LogDate);
            return currentUT + UT;
        }

        public List<Labors> GetLaborsByQuetionID(string question_id)
        {
            List<Labors> llb = new List<Labors>();
            DataTable dt = new DAL().GetLaborsListByQuestionID(question_id);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Labors lbr = new Labors();
                    lbr.Question_id = Convert.ToInt32(dt.Rows[i]["question_id"]);
                    lbr.Alias= dt.Rows[i]["alias"].ToString();
                    //System.Web.HttpContext.Current.User.Identity.Name.Substring(System.Web.HttpContext.Current.User.Identity.Name.IndexOf("\\") + 1);// 
                    lbr.UT= Convert.ToInt32(dt.Rows[i]["UT"]);
                    lbr.LogDate = new CommonOperation().UnixStamptoDateTime(Convert.ToInt32(dt.Rows[i]["LogDate"])).ToString();
                    lbr.UTComments = dt.Rows[i]["UTComments"].ToString();
                 
                    llb.Add(lbr);
                }
            }
            return llb;

        }
        public List<QualityReview> GetQRByQuetionID(string question_id)
        {
            List<QualityReview> qrlist = new List<QualityReview>();
            DataTable dt = new DAL().GetQRByQuetionID(question_id);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QualityReview qr = new QualityReview();
                    qr.points= Convert.ToInt32(dt.Rows[i]["points"]);
                    qr.alias = dt.Rows[i]["alias"].ToString();
                    //System.Web.HttpContext.Current.User.Identity.Name.Substring(System.Web.HttpContext.Current.User.Identity.Name.IndexOf("\\") + 1); //
                    qr.create_by = dt.Rows[i]["create_by"].ToString();
                    qr.createtime = new CommonOperation().UnixStamptoDateTime(Convert.ToInt32(dt.Rows[i]["create_time"])).ToString();//dt.Rows[i]["create_time"].ToString();
                    //new CommonOperation().UnixStamptoDateTime(Convert.ToInt32(dt.Rows[i]["create_time"])).ToString(); //
                    qr.comment = dt.Rows[i]["comment"].ToString();
                    qr.status = dt.Rows[i]["status"].ToString();
                    qr.QR_id = dt.Rows[i]["QR_id"].ToString();
                    qrlist.Add(qr);
                }
            }
            return qrlist;

        }
        public void SetQualityReview(string question_id, int points, string comment, string create_time, string create_by, string isfixed, string alias, string isnotified, string status)
        {
         string createtime= new CommonOperation().DateTimetoUnixStamp(DateTime.Now).ToString();
            new DAL().SetQualityReview(question_id, points, comment, createtime, create_by, isfixed, alias, isnotified, status);
        }
        public void SetQualityReview_eng(string question_id, string QR_id, string alias, string create_time, string eng_comment, string action)
        {
            string createtime = new CommonOperation().DateTimetoUnixStamp(DateTime.Now).ToString();
            new DAL().SetQualityReview_eng(question_id, QR_id, alias, createtime, eng_comment, action);
        }
        public void SetVirtualTeam(string question_id, string team, string assigned_by)
        {
            string assign_time = new CommonOperation().DateTimetoUnixStamp(DateTime.Now).ToString();
            new DAL().SetVirtualTeam(question_id, team, assigned_by, assign_time);
        }
        public List<VirtualTeam> GetVirtualTeam(string question_id)
        {
            List<VirtualTeam> vt = new List<VirtualTeam>();
            DataTable dt = new DAL().GetVirtualTeam(question_id);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VirtualTeam vtm = new VirtualTeam();
                    vtm.question_id = dt.Rows[i]["question_id"].ToString();
                    vtm.team_name = dt.Rows[i]["team_name"].ToString();                   
                    vt.Add(vtm);
                }
            }
            else
            {
                VirtualTeam vtm = new VirtualTeam();
                //vtm.question_id = dt.Rows[0]["question_id"].ToString();
                vtm.team_name = "Not Assigned";
                vt.Add(vtm);
            }
            return vt;

        }
        public List<QualityReview_eng> GetQR_eng_ByQuetionID(string question_id)
        {
            List<QualityReview_eng> qr_eng_list = new List<QualityReview_eng>();
            DataTable dt = new DAL().QualityReview_eng(question_id);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QualityReview_eng qr = new QualityReview_eng();
                    qr.question_id = dt.Rows[i]["question_id"].ToString();
                    qr.alias = dt.Rows[i]["alias"].ToString();
                    qr.create_time = new CommonOperation().UnixStamptoDateTime(Convert.ToInt32(dt.Rows[i]["create_time"])).ToString(); //dt.Rows[i]["create_time"].ToString();
                    qr.eng_comment = dt.Rows[i]["eng_comment"].ToString();
                    //new CommonOperation().UnixStamptoDateTime(Convert.ToInt32(dt.Rows[i]["create_time"])).ToString();
                    qr.action = dt.Rows[i]["action"].ToString();

                    qr_eng_list.Add(qr);
                }
            }
            return qr_eng_list;

        }
        public List<SupportTeam> GetSupportTeam()
        {
            List<SupportTeam> st_list = new List<SupportTeam>();
            DataTable dt = new DAL().GetSupportTeam();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SupportTeam qr = new SupportTeam();
                    qr.Team_name = dt.Rows[i]["Team_name"].ToString();
                    //qr.alias = dt.Rows[i]["alias"].ToString();
                   
                    st_list.Add(qr);
                }
            }
            return st_list;

        }
        public List<ScenarioMetrics> GetScenarioMetricsByDate(string fromdate, string todate, string cateNames, string Scope)
        {
            DataTable dt = new DAL().GetCateIDFromCategoryName(cateNames);
            string ids = "";
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ids += dt.Rows[i]["id"].ToString() + ",";

                }
            }
            ids.Remove(ids.Length-1);
            DataTable dt_metrics=new DAL().GetMetricsBydata(fromdate, todate, ids, Scope);
            if (dt_metrics != null && dt_metrics.Rows.Count > 0)
            {
                return HelperFunction<ScenarioMetrics>.ConvertToList(dt_metrics);

            }
            return null;
        }

    }
}
