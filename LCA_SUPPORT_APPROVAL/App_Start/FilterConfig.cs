﻿using System.Web;
using System.Web.Mvc;

namespace LCA_SUPPORT_APPROVAL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
