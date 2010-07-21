﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacebookSharp;
using FacebookSharp.Samples.Website;

public partial class FacebookAuthorize : BasePage
{
    public FacebookAuthenticationResult FacebookAuthenticationResult { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        // since this is not a desktop app we need to send the facebook settings,
        // so that it can get apikey, api secret and post authorize url.
        FacebookAuthenticationResult = new FacebookAuthenticationResult(HttpContext.Current.Request.Url.ToString(),
                                                                        FacebookContext.FacebookContext.Settings);

        DisplayAppropriateMesage();
    }

    private void DisplayAppropriateMesage()
    {
        if (FacebookAuthenticationResult.IsSuccess)
        {
            pnlOK.Visible = true;
            Session["access_token"] = FacebookAuthenticationResult.AccessToken;
            lblAccessToken.Text = FacebookAuthenticationResult.AccessToken;
        }
        else
        {
            pnlKO.Visible = true;
            Session["access_token"] = null;
            lblErrorReason.Text = FacebookAuthenticationResult.ErrorReasonText;
        }
    }
}