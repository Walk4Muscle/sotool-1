using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackModel;
using System.Threading;

namespace TagSpecifiedDataOperation
{
    public class QuestionOperation : CommonOperation, IImportAction
    {
        private string _urlquestion = "https://api.stackexchange.com/2.1/questions?";
        private string _urlkey = "key=U4DMV*8nvpm3EOpvf69Rxw((&site=stackoverflow&";
        private string _urlfilter = "&filter=!LQaW)hhei.Eqvf3aaeU1vl";
        private MyCollection<Question> GetQuestionsByParam(QuestionParam param)
        {
            string url = _urlquestion;
            url += _urlkey;
            url = this.GetUrlforParam(url, param);
            url += _urlfilter;
            try
            {
                MyCollection<Question> questioncollection = GetDataFromStackflow<MyCollection<Question>>(url);
                return questioncollection;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool RecoredsExistAndUpdate(out int actionflag, Question question)
        {
            // actionflag 0: no recored
            // actionflag 1: need update
            // actionflag 2: no action needed 
            if (new DAL_Question().IfQuestionExist(question))
            {
                if (new DAL_Question().IfQuestionNeedUpdate(question))
                {
                    actionflag = 1;
                    return true;
                }
                else
                {
                    actionflag = 2;
                    return true;
                }
            }
            else
            {
                actionflag = 0;
                return false;
            }
        }
        public void InsertLocalRecoredsFromStackOverFlow(Question question)
        {
            // Add new Question
            new DAL_Question().AddNewQuestion(question);
            
            // Add new tags and question relatationship
            if (question.Tags != null )
            {
                new DAL_Tags().UpdateTags(question.Tags);
            }
            new DAL_Tags().AddTagQuestionRelationShip(question.Tags,question.Question_id.ToString());

            // Add stackoverflow users in scoped threads
            if (question.Owner != null)
            {
                new DAL_Users().UpdateUser(question.Owner);
            }
            // Add answers in scoped threads
            if (question.Answers != null)
            {
                new DAL_Answers().UpdateAnswer(question.Answers);
            }
            
            // Add Comments in scoped threads
            if (question.Comments !=null)
            {
                new DAL_Comments().UpdateComment(question.Comments);
            }
            
        }
        public void UpdateRecordsFromStackOverFlow(Question question)
        {
            // Update question
            new DAL_Question().UpdateQuestion(question);

            // Add new tags and question relatationship
            if (question.Tags != null)
            {
                new DAL_Tags().UpdateTags(question.Tags);
            }
            new DAL_Tags().AddTagQuestionRelationShip(question.Tags, question.Question_id.ToString());

            // Add stackoverflow users in scoped threads
            if (question.Owner != null)
            {
                new DAL_Users().UpdateUser(question.Owner);
            }
            // Add answers in scoped threads
            if (question.Answers != null)
            {
                new DAL_Answers().UpdateAnswer(question.Answers);
            }

            // Add Comments in scoped threads
            if (question.Comments != null)
            {
                new DAL_Comments().UpdateComment(question.Comments);
            }
        }
        private void UpdateByCreationdate(QuestionParam param)
        {
            QuestionParam initialGetquestion = new QuestionParam() { Fromdate = param.Fromdate, Todate = param.Todate, Sort = "creation", Tagged=param.Tagged };
            Console.WriteLine("Initial Get Question Totally Volumn Via Current Tags Setting: "+param.Tagged);
            MyCollection<Question> initialQuestionCollection = GetQuestionsByParam(initialGetquestion);
            string strsql = string.Empty;
            int pagecount = initialQuestionCollection.Total / 100 + 1;
            for (int i = 1; i <= pagecount; i++)
            {
                QuestionParam questionparam = new QuestionParam()
                {
                    Page = i,
                    Pagesize = 100,
                    Fromdate = param.Fromdate,
                    Todate = param.Todate,
                    Sort = "creation",
                    Tagged = param.Tagged
                };
                MyCollection<Question> taggedQuestionCollection = GetQuestionsByParam(questionparam);
                foreach (Question question in taggedQuestionCollection.Items)
                {
                    int actionFlag;
                    if (RecoredsExistAndUpdate(out actionFlag, question))
                    {
                        switch (actionFlag)
                        {
                            case 1:
                                UpdateRecordsFromStackOverFlow(question);
                                break;
                        }
                    }
                    else
                    {
                        InsertLocalRecoredsFromStackOverFlow(question);
                    }
                }
                Console.WriteLine(string.Format("Import question at {0} page(s) / among {1} page(s)", i,pagecount));
                //Thread.Sleep(10000);
            }
        }

        public void UpdateDataInfoTable(MyParam mytagparam)
        {
            UpdateByCreationdate((QuestionParam)mytagparam);
        }

    }
}
