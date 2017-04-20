using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Amayer.Com.Com
{
    public class XmlHelper
    {
        private XmlDocument xmlDoc = null;

        public XmlHelper(string xmlFilePath)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
        }

        public List<Menu> GetRootMenuList()
        {
            List<Menu> list = new List<Menu>();
            XmlNode root = xmlDoc.FirstChild.NextSibling;
            XmlNodeList rootMenu = root.ChildNodes;
            foreach (XmlNode item in rootMenu)
            {
                Menu entity = new Menu();
                entity.Id = int.Parse(item.Attributes["id"].Value);
                entity.Title = item.Attributes["title"].Value;
                entity.Description = item.Attributes["description"].Value;
                list.Add(entity);
            }
            return list;
        }

        public List<Menu> GetMenuList(string title)
        {
            List<Menu> list = new List<Menu>();
            string nodeTitle = "menuRoot/menuNode[@title='" + title + "']";
            XmlNode node = xmlDoc.SelectSingleNode(nodeTitle);
            XmlNodeList nodeList = node.ChildNodes;
            foreach (XmlNode item in nodeList)
            {
                Menu entity = new Menu();
                entity.Id = int.Parse(item.Attributes["id"].Value);
                entity.Title = item.Attributes["title"].Value;
                entity.Description = item.Attributes["description"].Value;
                entity.Items = GetMenuItems(entity.Title);
                list.Add(entity);
            }
            return list;
        }

        public List<Item> GetMenuItems(string title)
        {
            List<Item> list = new List<Item>();
            string nodeTitle = "menuRoot/menuNode/subMenuNode[@title='" + title + "']";
            XmlNode node = xmlDoc.SelectSingleNode(nodeTitle);
            XmlNodeList nodeList = node.ChildNodes;
            foreach (XmlNode item in nodeList)
            {
                Item entity = new Item();
                entity.Id = int.Parse(item.Attributes["id"].Value);
                entity.Title = item.Attributes["title"].Value;
                entity.Description = item.Attributes["description"].Value;
                entity.Url = item.Attributes["url"].Value;
                list.Add(entity);
            }
            return list;
        }
    }

    public class Menu
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        List<Item> _Items;

        public List<Item> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
    }

    public class Item
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _Url;

        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
    }
}
