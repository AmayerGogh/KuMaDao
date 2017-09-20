
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Utility
{

    public class HtmlAnalysis
    {
        //private HtmlDocument htmlDoc;
        //private HtmlWeb htmlWeb;

        //public HtmlAnalysis()
        //{
        //    htmlWeb = new HtmlWeb();
        //    htmlWeb.OverrideEncoding = Encoding.GetEncoding("gb2312");
        //}

        //public void LoadUrl(string url)
        //{
        //    htmlDoc = htmlWeb.Load(url, "GET");
        //}

        //public void LoadHtml(string html)
        //{
        //    htmlDoc.LoadHtml(html);
        //}

        //public string GetNodeText(string xpath)
        //{
        //    HtmlNode node = htmlDoc.DocumentNode.SelectSingleNode(xpath);
        //    if (node != null)
        //    {
        //        return node.InnerText;
        //    }
        //    return string.Empty;
        //}
        //public string GetNodeHtml(string xpath)
        //{
        //    HtmlNode node = htmlDoc.DocumentNode.SelectSingleNode(xpath);
        //    if (node != null)
        //    {
        //        var html = node.InnerHtml;
        //        html = System.Text.RegularExpressions.Regex.Replace(html, @"(<script[^>]*?>)(.*)(<\/script>)", string.Empty);
        //        html = System.Text.RegularExpressions.Regex.Replace(html, @"<a[^>]*?>", string.Empty);
        //        html = System.Text.RegularExpressions.Regex.Replace(html, @"</a>", string.Empty);
        //        return html;
        //    }
        //    return string.Empty;
        //}

        //public string GetAttributeValue(string xpath, string name)
        //{
        //    HtmlNode node = htmlDoc.DocumentNode.SelectSingleNode(xpath);
        //    string def = string.Empty;
        //    if (node != null)
        //    {
        //        return node.GetAttributeValue(name, def);
        //    }
        //    return def;
        //}

        //public List<string> GetAttributeValues(string xpath, string name)
        //{
        //    List<string> list = new List<string>();
        //    var nodes = htmlDoc.DocumentNode.SelectNodes(xpath);
        //    string def = string.Empty;
        //    foreach (var item in nodes)
        //    {
        //        var src = item.GetAttributeValue(name, def);
        //        if (list.Contains(src))
        //        {
        //            continue;
        //        }
        //        list.Add(src);
        //    }
        //    return list;
        //}

        //public void Analyse(string xpath)
        //{
        //    HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes(xpath);
        //    foreach (var item in nodes)
        //    {

        //    }
        //}
    }
}
