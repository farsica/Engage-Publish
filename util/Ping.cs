//Engage: Publish - http://www.engagemodules.com
//Copyright (c) 2004-2008
//by Engage Software ( http://www.engagesoftware.com )

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
//TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
//THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
//CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
//DEALINGS IN THE SOFTWARE.


using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Net;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Host;

namespace Engage.Dnn.Publish.Util
{
    public static class Ping
    {
        //http://solutionforyou.wordpress.com/2008/02/17/csharp-blog-ping-code-using-xml-rpc-and-weblogupdates-ping-for-pingomatic-technorati/
        public static void SendPing(string name, string url, string changesUrl, int portalId)
        {
            try
            {
                ArrayList listToPing = new ArrayList();
                string s = HostSettings.GetHostSetting(Utility.PublishPingServers + portalId.ToString(CultureInfo.InvariantCulture));
                if (Utility.HasValue(s))
                {
                    foreach (string sr in s.Split('\n'))
                    {
                        if (Utility.HasValue(sr))
                            listToPing.Add(sr.Replace("\r", ""));
                    }

                }
                else
                {
                    listToPing.Add("http://rpc.technorati.com/rpc/ping");
                    listToPing.Add("http://rpc.pingomatic.com");
                    listToPing.Add("http://blogsearch.google.com/ping/RPC2");
                }

                for (int i = 0; i < listToPing.Count; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(listToPing[i].ToString());
                    request.Method = "POST";
                    request.ContentType = "text/xml";

                    Stream stream = request.GetRequestStream();

                    using (XmlTextWriter xml = new XmlTextWriter(stream, Encoding.UTF8))
                    {
                        xml.WriteStartDocument();
                        xml.WriteStartElement("methodCall");
                        xml.WriteElementString("methodName", "weblogUpdates.ping");
                        xml.WriteStartElement("params");
                        xml.WriteStartElement("param");
                        xml.WriteElementString("value", name);
                        xml.WriteEndElement();
                        //changed page
                        xml.WriteStartElement("param");
                        xml.WriteElementString("value", changesUrl);
                        xml.WriteEndElement();

                        xml.WriteStartElement("param");
                        xml.WriteElementString("value", url);
                        xml.WriteEndElement();
                        xml.WriteEndElement();
                        xml.WriteEndElement();
                        xml.Close();
                    }

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            //string result = sr.ReadToEnd();
                            sr.ReadToEnd();
                            sr.Close();
                        }
                        response.Close();
                    }
                }
            }

            catch (Exception exc)
            {
                //do what with the exception?
                Exceptions.LogException(exc);
            }
        }

    }
}

