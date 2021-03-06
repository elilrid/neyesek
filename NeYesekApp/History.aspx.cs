﻿using NeYesekApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeYesekApp
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["IsLoggedIn"] == null || Session["IsLoggedIn"] is bool == false)
                {
                    Response.Redirect("/Default.aspx");
                    return;
                }

                using (var ctx = new NeYesekAppContext())
                {
                    rptHistories.DataSource = ctx.RestaurantHistories.ToList();
                    rptHistories.DataBind();
                }

            }

        }
    }
}