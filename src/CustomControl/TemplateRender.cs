using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Linq;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControl
{
    public class MyTemplate : ITemplate
    {

        private string _html;
        public MyTemplate(string html)
        {
            _html = html;
        }
        #region ITemplate Members

        private List<string> PropertyList;
        public void InstantiateIn(Control container)
        {
            Literal child = new Literal();
            child.Text = _html;
            child.DataBinding += new EventHandler(control_DataBinding);
            container.Controls.Add(child);
        }
        private const string pattern = "";
        void control_DataBinding(object sender, EventArgs e)
        {
            Literal child = sender as Literal;
            RepeaterItem item = child.NamingContainer as RepeaterItem;

            //// Option 1 get merge filed by  reflection
            //// option 2 get merge filed by    regular expression ($$.*?$$)
            if (PropertyList == null)
            {

                Type t = item.DataItem.GetType();
                PropertyInfo[] info = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var query = from it in info select it.Name;
                PropertyList = query.ToList();
            }
            foreach (var property in PropertyList)
            {
                Match match = Regex.Match(child.Text, @"\$\$" + property + @"(,\w+(?=\$\$))?\$\$", RegexOptions.Multiline);
                if (match == null || !match.Success)
                    continue;

                object o = DataBinder.GetPropertyValue(item.DataItem, property);
                if (o != null)
                {
                    string targetText = (o is IFormattable && match.Groups[1].Success) ?
                        (o as IFormattable).ToString(match.Groups[1].Value.TrimStart(','), System.Globalization.CultureInfo.CurrentUICulture.NumberFormat)
                        : o.ToString();
                    child.Text = child.Text.Replace(match.Value, targetText);
                }
                else
                {
                    child.Text = child.Text.Replace(match.Value, string.Empty);
                }
            }
        }

        #endregion
    }

    public class HtmlTemplate : ITemplate
    {
        public HtmlTemplate(string html)
        {
            this.Html = html;
        }
        #region ITemplate Members
        public string Html
        {
            get;
            set;
        }

        public void InstantiateIn(Control container)
        {
            Literal child = new Literal();
            child.Text = Html;
            container.Controls.Add(child);
        }

        #endregion
    }


    public class TemplateRender
    {
        private static RegexOptions options = ((RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline) | RegexOptions.IgnoreCase);

        private const string listPattern = "<list\\sdatasource=\"{0}\">(.*?)</list>";
        private const string clearPattern = "<list\\sdatasource=\".*?\">.*?</list>";
        private const string regexConst = "<{0}>(.*?)</{0}>";

        private string GetInnerHtml(string input, string tagKey)
        {
            string pattern = string.Format(regexConst, tagKey);
            Regex reg = new Regex(pattern, options);
            Match match = reg.Match(input);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return string.Empty;
        }

        public Dictionary<string, string> GetDictionary<T>(T t)
        {
            PropertyInfo[] property = t.GetType().GetProperties();
            Dictionary<string, string> de = new Dictionary<string, string>();
            foreach (var item in property)
            {
                //de.Add(item.Name,item.GetValue(t,null).ToString());
                object result = item.GetValue(t, null);
                de.Add(item.Name, result == null ? null : result.ToString());
            }
            return de;
        }

        public string Render<T>(string html, T t, params DictionaryEntry[] dataSources)
        {
            Dictionary<string, string> temp = GetDictionary(t);
            return Render(html, temp, dataSources);
        }


        private const string ItemTemplateTag = "ItemTemplate";
        private const string HeaderTemplateTag = "HeaderTemplate";
        private const string FooterTemplateTag = "FooterTemplate";
        /// <summary>
        /// DictionaryEntry value must be Implement Icollection interface, Ilist Generic
        /// </summary>
        /// <param name="Html">Html Template</param>
        /// <param name="list">merge Parms</param>
        public string Render(string Html, Dictionary<string, string> list, params DictionaryEntry[] dataSources)
        {
            if (dataSources != null)
            {
                foreach (var de in dataSources)
                {
                    StringBuilder sb = new StringBuilder();
                    string pattern = string.Format(listPattern, de.Key);
                    Regex reg = new Regex(pattern, options);
                    Match match = reg.Match(Html);
                    if (match.Success)
                    {
                        string input = match.Groups[1].Value;
                        string item = GetInnerHtml(input, ItemTemplateTag);
                        string header = GetInnerHtml(input, HeaderTemplateTag);
                        string footer = GetInnerHtml(input, FooterTemplateTag);
                        Repeater rpt = new Repeater();
                        rpt.DataSource = de.Value;
                        if (de.Value != null)
                        {
                            ICollection collection = (ICollection)de.Value;
                            if (collection.Count > 0)
                            {
                                rpt.HeaderTemplate = new HtmlTemplate(header);
                                rpt.FooterTemplate = new HtmlTemplate(footer);
                            }
                        }
                        rpt.ItemTemplate = new MyTemplate(item);
                        rpt.DataBind();

                        StringWriter sw = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(sw);
                        rpt.RenderControl(htw);

                        Html = reg.Replace(Html, sw.ToString());

                    }

                }
            }

            Regex clear = new Regex(clearPattern, options);
            Html = clear.Replace(Html, "<!---No contain this datasource---->");

            if (list != null)
            {
                foreach (var item in list)
                {
                    var key = item.Key;
                    if (!key.StartsWith("$$"))
                    {
                        key = string.Format("$${0}$$", key);
                    }
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        Html = Html.Replace(key, item.Value);
                    }
                    else
                    {
                        Html = Html.Replace(key, string.Empty);
                    }
                }

            }
            if (HttpContext.Current != null)
            {
                string host = "http://" + HttpContext.Current.Request.Headers["host"];
                Html = Html.Replace("$$host$$", host);
            }
            return Html;
        }


    }
}
