//Engage: Publish - http://www.engagemodules.com
//Copyright (c) 2004-2008
//by Engage Software ( http://www.engagesoftware.com )

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
//TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
//THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
//CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
//DEALINGS IN THE SOFTWARE.

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.Exceptions;

//TODO: Show child items, articles, for the specified category ID (itemId from qs or module setting)

namespace Engage.Dnn.Publish.ArticleControls
{
    [Obsolete("This class is currently not in use.", false)]
    public partial class ArticleCategoryListing : ModuleBase, IActionable
    {

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            LoadControlType();
            base.OnInit(e);


        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += this.Page_Load;

        }
        #endregion

        //		private Article av;


        private void LoadControlType()
        {
            //if (ItemId == -1)
            //{
            //    VersionInfoObject = Category.Create(PortalId);

            //    // load email a friend and printer friendly
            //}
            //else
            //{
            //    VersionInfoObject = Category.GetCategory(ItemId, PortalId);
            //}
            base.BindItemData();
        }

        #region Event Handlers

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //int itemId = ItemId;

                //object o = Settings["CategoryId"];
                //if(o != null)//!String.IsNullOrEmpty(o.ToString()))
                //{
                //    int.TryParse(o.ToString(), out itemId);
                //    //REMOVE THIS FROM PUBLIC RELEASE
                //    //get old category ID
                //    //itemId = Convert.ToInt32(Settings["CategoryId"].ToString());
                //    itemId = Category.GetOldCategoryId(itemId);//Convert.ToInt32(o.ToString()));
                //}

                //bool overrideable = true;
                //object o = Settings["Overrideable"];
                //if (o != null)
                //{
                //    if (!bool.TryParse(o.ToString(), out overrideable))
                //    {
                //        overrideable = true;
                //    }
                //    //if(Convert.ToBoolean(Settings["Overrideable"].ToString()) == false)
                //    //{
                //    //    overrideable = false;
                //    //}
                //}

                // LogBreadcrumb is true by default.  Check to see if we need to turn it off.
                object o = Settings["LogBreadCrumb"];
                if (o != null)
                {
                    bool logBreadCrumb;
                    if (bool.TryParse(o.ToString(), out logBreadCrumb))
                    {
                        this.LogBreadcrumb = logBreadCrumb;
                    }
                }

                //                if (itemId > 0 && overrideable)
                //                {
                //                    //load category data
                ///*
                //                    VersionInfoObject = Category.GetCategory(itemId, PortalId);
                //                    DotNetNuke.Framework.CDefault tp = (DotNetNuke.Framework.CDefault)this.Page;
                //                    SetPageTitle();
                //                    Category c = (Category) VersionInfoObject;
                //                    lblArticleText.Text = c.Name;	
                //                    lblArticleTitle.Text = a.Name.ToString();	
                //                    */
                //                }
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

        #region Optional Interfaces

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get
            {
                DotNetNuke.Entities.Modules.Actions.ModuleActionCollection actions = new DotNetNuke.Entities.Modules.Actions.ModuleActionCollection();
                actions.Add(GetNextActionID(), Localization.GetString("Settings", LocalResourceFile), DotNetNuke.Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl("Settings"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                //Actions.Add(GetNextActionID(), Localization.GetString(DotNetNuke.Entities.Modules.Actions.ModuleActionType.AddContent, LocalResourceFile), DotNetNuke.Entities.Modules.Actions.ModuleActionType.AddContent, "", "", "", false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                return actions;
            }
        }

       
        #endregion
    }
}

