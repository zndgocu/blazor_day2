using System;
using System.Collections.Generic;

namespace ClassExtension.Nav
{
    public class NavMenuItem
    {
        private string _title;
        private string _url;
        private bool _expanded;
        private List<NavMenuItem> _childs;


        public string Title { get => _title; set => _title = value; }
        public string Url { get => _url; set => _url = value; }
        public bool Expanded { get => _expanded; set => _expanded = value; }
        public List<NavMenuItem> Childs { get => _childs; set => _childs = value; }

        public bool IsGroup
        {
            get
            {
                if (_childs == null) return false;
                return true;
            }
        }

        
        public static NavMenuItem CreateNavGroup(string title, bool expanded, params NavMenuItem[] navs)
        {
            NavMenuItem nav = new NavMenuItem();
            nav.Title = title;
            nav.Url = "";
            nav.Expanded = expanded;
            nav.Childs = new List<NavMenuItem>();
            nav.Childs.AddRange(navs);

            return nav;
        }


        public static NavMenuItem CreateNavItem(string title, string url)
        {
            NavMenuItem nav = new NavMenuItem();
            nav.Title = title;
            nav.Url = url;
            return nav;

        }
    }
}
