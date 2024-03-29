﻿using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace comfybed.common
{
    public class DataMod
    {
        const string baseURL = "http://211.105.113.166:50002/api/OpenBED/";

        public DataMod()
        {

        }


        public void GetResult(String Q)
        {
            string uri = baseURL + Q;
             string responseText = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.Timeout = 30 * 1000; // 30초
            request.Headers.Add("Authorization", "BASIC SGVsbG8="); // 헤더 추가 방법 

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                Console.WriteLine(status);  // 정상이면 "OK"

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }
            Debug.WriteLine("여기에용" + responseText);

        }

        public JArray Open(string Q)
            {
            Uri uri = new Uri(string.Format(baseURL + Q, string.Empty));
            JObject jObject = new JObject();

            using (WebClient webclient = new WebClient())
            {
                try
                {
                    var response =  webclient.DownloadData(uri);
                    string S = Encoding.UTF8.GetString(response);
                    jObject = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(S);
                    JArray returnJarray = new JArray();

                    if (jObject.GetValue("Result").ToString().Equals("SUCC"))
                        return (JArray) jObject.GetValue("Msg");
                    else
                    {
                        Debug.WriteLine(jObject.GetValue("Msg").ToString());
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return null;
                }
            }
        }
    }
}