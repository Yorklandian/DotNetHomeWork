using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace homework9
{
    public class SimpleCrawler
    {
        private readonly Dictionary<Uri, bool> urls = new Dictionary<Uri, bool>();
        private int count = 0;
        readonly Regex regex = new Regex(@"(?:href|HREF)\s*=\s*[""']([^""']+\.(?:html|htm|aspx|jsp))[""']", RegexOptions.Compiled);
        static Uri current;
        public IEnumerable<string> Crawl(string startUrl)
        {          
                urls.Add(new Uri(startUrl), false);
                yield return "开始爬行.... \r\n";
                while (true)
                {
                    current = null;
                    foreach (Uri url in urls.Keys)
                    {
                        if (!urls[url])
                        {
                            current = url;
                        }
                    }
                    if (current == null || count > 10)
                    {
                        break;
                    }
                    yield return "爬行" + current + "页面...\r\n";
                    string message = null ;
                    
                        string html = DownLoad(current);
                        urls[current] = true;
                        count++;
                        Parse(html);                                       
                }
            yield return "爬行结束\r\n";
            urls.Clear();
                count = 0;
                   
        }

        public string DownLoad(Uri url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = url.AbsoluteUri.Substring(url.AbsoluteUri.LastIndexOf('/') + 1);
                if (fileName.Equals(""))
                {
                    fileName = "./index.html";
                }

                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                return ex.Message;
            } 
        }

        private void Parse(string html)
        {
            MatchCollection matches = regex.Matches(html);
            foreach (Match match in matches)
            {
                Uri strRef = new Uri(current, match.Groups[1].Value);
                if (!urls.ContainsKey(strRef))
                {
                    urls.Add(strRef, false);
                }
            }
        }
    }
}
