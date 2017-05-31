using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApp1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] ImagePaths = Directory.GetFiles(Server.MapPath("~/Images/"));
                List<ListItem> Imgs = new List<ListItem>();
                foreach (string imgPath in ImagePaths)
                {
                    string ImgName = Path.GetFileName(imgPath);
                    Imgs.Add(new ListItem(ImgName, "~/Images/" + ImgName));
                }
                Gv_imgs.DataSource = Imgs;
                Gv_imgs.DataBind();
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fupload.HasFile)
            {
                string fileName = fupload.FileName;
                fupload.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                Response.Redirect(Request.Url.AbsoluteUri);

            }

        }
    }
}