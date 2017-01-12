using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackModel;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Reflection;
using System.Data;

namespace TagSpecifiedDataOperation
{
    public class CommonOperation
    {
        private static readonly DateTime dtstart = new DateTime(1970, 1, 1).ToUniversalTime();

        private static int hour = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) - new DateTime(1970, 1, 1).ToUniversalTime()).Hours;

        public DateTime UnixStamptoDateTime(long unixTime)
        {

            return dtstart.AddSeconds(unixTime).AddHours(hour).ToUniversalTime();
        }

        public long DateTimetoUnixStamp(DateTime? dateTime)
        {
            if (dateTime != null)
            {
                DateTime dtNow = DateTime.Parse(dateTime.Value.ToString()).ToUniversalTime();
                TimeSpan toNow = dtNow.Subtract(dtstart);
                string timeStamp = toNow.Ticks.ToString();
                timeStamp = timeStamp.Substring(0, timeStamp.Length - 7);
                return long.Parse(timeStamp);
            }
            else
            {  
                throw new Exception("The datetime is null");
            }
        }

        protected T GetDataFromStackflow<T>(string url)
        {
        GetResponse:
            HttpWebRequest request = HttpWebRequest.Create(new Uri(url)) as HttpWebRequest;
            //  request.Proxy = new WebProxy("199.239.136.200", true);
            //  request.Proxy = new WebProxy("172.25.230.230");
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = "GET";
            HttpWebResponse response;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("wait some time,start again!");
                Thread.Sleep(1000 * 10);
                goto GetResponse;
            }

            return SerilzerStreamObject<T>(response.GetResponseStream());


        }

        protected string GetUrlforParam(string url, MyParam param)
        {
            Type type = param.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var item in properties)
            {
                if (item.Name.ToLower() == "fromdate" || item.Name.ToLower() == "todate" || item.Name.ToLower() == "max" || item.Name.ToLower() == "min")
                {
                    if (item.GetValue(param) !=null)
                    {
                        url += item.Name.ToLower() + "=" + this.DateTimetoUnixStamp(Convert.ToDateTime(item.GetValue(param))) + "&";
                    }
                    
                }
                else
                {
                    if (item.GetValue(param) != null)
                    {
                        url += item.Name.ToLower() + "=" + item.GetValue(param).ToString() + "&";
                    }
                }
                //switch (item.Name.ToLower())
                //{
                //    case "page":
                //        url += "page=" + item.GetValue(param).ToString() + "&";
                //        break;
                //    case "pagesize":
                //        url += "pagesize=" + param.Pagesize + "&";
                //        break;
                //    case "fromdate":
                //        url += "fromdate=" + this.DateTimetoUnixStamp(param.Fromdate) + "&";
                //        break;
                //    case "todate":
                //        url += "todate=" + this.DateTimetoUnixStamp(param.Todate) + "&";
                //        break;
                //    case "max":
                //        url += "max=" + this.DateTimetoUnixStamp(param.Max) + "&";
                //        break;
                //    case "min":
                //        url += "min=" + this.DateTimetoUnixStamp(param.Min) + "&";
                //        break;
                //    case "order":
                //        url += "order=" + param.Order + "&";
                //        break;
                //    case "sort":
                //        url += "sort=" + param.Sort + "&";
                //        break;
                //    case "tagged":
                //        url += "tagged=" + item.GetValue(param).ToString() + "&";
                //        break;
                //}
            }
            url = url.Remove(url.LastIndexOf('&'));
            return url;
        }

        private T SerilzerStreamObject<T>(Stream stream)
        {
            T data = default(T);
            StreamReader sr = new StreamReader(stream);
            string str = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            MemoryStream objstream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(str));
            try
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
                data = (T)json.ReadObject(objstream);
                objstream.Close();
            }
            catch
            {
                throw new Exception("json serilzer exception,Please check model!");
            }
            return data;
        }

       
    }
    public class HelperFunction<T> where T : new()
    {
        public static List<T> ConvertToList(DataTable dt)
        {
            List<T> ts = new List<T>();
            Type type = typeof(T);
            string tempName = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    if (dt.Columns.Contains(tempName))
                    {

                        if (!pi.CanWrite) continue;

                        object value = dr[tempName];

                        if (value == DBNull.Value)
                        {
                            if (pi.PropertyType.Name == "String")
                            {
                                value = "";
                            }
                            else if (pi.PropertyType.Name == "Int")
                            {
                                value = 0;
                            }
                            else if (pi.PropertyType.Name == "Double")
                            {
                                value = 0.0;
                            }

                            pi.SetValue(t, value, null);
                        }
                        else
                        {

                            pi.SetValue(t, value, null);
                        }

                    }
                }

                ts.Add(t);
            }

            return ts;

        }
    }
}
