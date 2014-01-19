using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using Telerik.Web.UI;

namespace CustomControl
{
    public class ComboxItemTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            LiteralControl literal = new LiteralControl();
            literal.DataBinding += literal_DataBinding;

            container.Controls.Add(literal);
        }

        private void literal_DataBinding(object sender, EventArgs e)
        {
            var literal = sender as LiteralControl;
            RadComboBoxItem comboxItem = literal.NamingContainer as RadComboBoxItem;

            var properties = comboxItem.DataItem.GetType().GetProperties();
            string itemTemplate =
                "<tr><td>$$Code$$</td><td>$$Name$$</td><td>$$UserTypeLabel$$</td><td>$$Description$$</td></tr>";
            StringBuilder itemHtml = new StringBuilder();

            foreach (var property in properties)
            {
                object value = property.GetValue(comboxItem.DataItem, null);
                itemTemplate = itemTemplate.Replace("$$" + property.Name + "$$",
                                                    value == null ? "" : value.ToString());
            }
            itemHtml.Append(itemTemplate);

            literal.Text = itemHtml.ToString();
        }
    }

    public  class ComboxCustomerSelectItemTemplate:ITemplate
    {
        public void InstantiateIn(Control container)
        {
            LiteralControl literal = new LiteralControl();
            literal.DataBinding += literal_DataBinding;
            container.Controls.Add(literal);
        }

        private void literal_DataBinding(object sender, EventArgs e)
        {
            var literal = sender as LiteralControl;
            RadComboBoxItem comboxItem = literal.NamingContainer as RadComboBoxItem;

            var codeProperty = comboxItem.DataItem.GetType().GetProperty("Code");
            var nameProperty = comboxItem.DataItem.GetType().GetProperty("Name");

            literal.Text = String.Format("{0}<{1}>", codeProperty.GetValue(comboxItem.DataItem, null),
                                         nameProperty.GetValue(comboxItem.DataItem, null));
        }
    }

    public class ComboxCustomerItemTemplate:ITemplate
    {
        private string HeaderText = "<table><thead><th>序号</th><th>编码</th><th>姓名</th><th>描述</th></thead>";
        public ComboxCustomerItemTemplate(string headerText)
        {
            if (String.IsNullOrEmpty(headerText))
            {
                HeaderText = headerText;
            }
        }

        public void InstantiateIn(Control container)
        {
            LiteralControl literal = new LiteralControl();
            literal.Text = HeaderText;
            container.Controls.Add(literal);
        }
    }
}
