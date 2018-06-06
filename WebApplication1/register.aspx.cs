using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Label1.Text == "")
            {
                string path = Server.MapPath("images/fuchsiaRegister.csv");
                if (File.Exists(path))
                {
                    string[] data = File.ReadAllLines(path);

                    DataTable dt = new DataTable();

                    string[] col = data[0].Split(',');

                    foreach (string s in col)
                    {
                        dt.Columns.Add(s, typeof(string));
                    }

                    for (int i = 0; i < data.Length; i++)
                    {
                        string[] row = data[i].Split(',');
                        dt.Rows.Add(row);
                    }

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Label1.Text = "'Select' a flower to view images";
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int size = DropDownList1.SelectedIndex;
            switch (size)
            {
                case 1:
                    GridView1.Font.Size = 10;
                    break;
                case 2:
                    GridView1.Font.Size = 12;
                    break;
                case 3:
                    GridView1.Font.Size = 15;
                    break;
                case 4:
                    GridView1.Font.Size = 18;
                    break;
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {

            GridViewRow selectedRow = GridView1.SelectedRow;
            if (selectedRow != null)
            {
                string rowName = selectedRow.Cells[1].Text;
                Response.Redirect("https://www.google.com/search?site=imghp&tbm=isch&source=hp&biw=1304&bih=673&q=fuchsia+" + rowName + "&oq=fuchsia+" + rowName + "&gs_l=img.3...169095.173090.1.173223.15.5.1.9.0.0.277.515.2-2.2.0....0...1ac.1.64.img..17.5.813.p6IplvsSwrk");

            }
            else
                Label1.Text = "'Select' a flower to search for";

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button1.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            Button1.Text = "";
            Button4.Text = "";
            Button5.Text = "";
            Button6.Text = "";
            Button1.CssClass = "";
            Button4.CssClass = "";
            Button5.CssClass = "";
            Button6.CssClass = "";
            GridViewRow selectedRow = GridView1.SelectedRow;
            Label2.Text = selectedRow.Cells[1].Text;
            string imagePath = "images/" + selectedRow.Cells[1].Text;
            string image = imagePath + ".jpg";
            string image2 = imagePath + " 2.jpg";
            string image3 = imagePath + " 3.jpg";
            string image4 = imagePath + " 4.jpg";
            
            string path = Server.MapPath(image);
            string path2 = Server.MapPath(image2);
            string path3 = Server.MapPath(image3);
            string path4 = Server.MapPath(image4);

            if (File.Exists(path) && File.Exists(path2) && File.Exists(path3) && File.Exists(path4))
            {
                Button1.Enabled = true;
                Button4.Enabled = true;
                Button5.Enabled = true;
                Button6.Enabled = true;
                Button1.Text = "Image 1";
                Button4.Text = "Image 2";
                Button5.Text = "Image 3";
                Button6.Text = "Image 4";
                Button1.CssClass = "cursor";
                Button4.CssClass = "cursor";
                Button5.CssClass = "cursor";
                Button6.CssClass = "cursor";
                Label1.Text = "Click the buttons below to see images";
            }
            else if (File.Exists(path) && File.Exists(path2) && File.Exists(path3))
            {
                Button1.Enabled = true;
                Button4.Enabled = true;
                Button5.Enabled = true;
                Button1.Text = "Image 1";
                Button4.Text = "Image 2";
                Button5.Text = "Image 3";
                Button1.CssClass = "cursor";
                Button4.CssClass = "cursor";
                Button5.CssClass = "cursor";
                Label1.Text = "Click the buttons below to see images";
            }
            else if (File.Exists(path) && File.Exists(path2))
            {
                Button1.Enabled = true;
                Button4.Enabled = true;
                Button1.Text = "Image 1";
                Button4.Text = "Image 2";
                Button1.CssClass = "cursor";
                Button4.CssClass = "cursor";
                Label1.Text = "Click the buttons below to see images";
            }
            else if (File.Exists(path))
            {
                Button1.Enabled = true;
                Button1.Text = "Image 1";
                Button1.CssClass = "cursor";
                Label1.Text = "Click the button below to see an image";
            }
            else
            {
                Label1.Text = "There are no images available for that flower";
                
            }
        }

        protected void image1_Click(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridView1.SelectedRow;
            string image = "images/" + selectedRow.Cells[1].Text + ".jpg";
            Response.Redirect(image);
        }

        protected void image2_Click(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridView1.SelectedRow;
            string image = "images/" + selectedRow.Cells[1].Text + " 2.jpg";
            Response.Redirect(image);
        }
        
        protected void image3_Click(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridView1.SelectedRow;
            string image = "images/" + selectedRow.Cells[1].Text + " 3.jpg";
            Response.Redirect(image);
        }

        protected void image4_Click(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridView1.SelectedRow;
            string image = "images/" + selectedRow.Cells[1].Text + " 4.jpg";
            Response.Redirect(image);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (Literal1.Visible == true)
                Literal1.Visible = false;
            else 
                Literal1.Visible = true;
        }

        protected void login_Click(object sender, EventArgs e)
        {
            if (userTextBox.Text == userLabel.Text && passTextBox.Text == passLabel.Text)
            {
                upload.Enabled = true;
                imageUpload.Enabled = true;
                imageUpload.CssClass = "cursor";
                csvUpload.Enabled = true;
                csvUpload.CssClass = "cursor";
                Label1.Text = "Logged in successfully!";
            }
            else
            {
                Label1.Text = "The Admin details entered were incorrect";
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            upload.Enabled = false;
            imageUpload.Enabled = false;
            imageUpload.CssClass = "";
            csvUpload.Enabled = false;
            csvUpload.CssClass = "";
            Label1.Text = "Thanks " + userLabel.Text + ", you have been logged out";
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            if (upload.HasFile == false)
            {
                Label1.Text = "Please first select a file to upload...";
            }
            else
            {
                GridViewRow selectedRow = GridView1.SelectedRow;
                if (selectedRow == null)
                {
                    Label1.Text = "Select a flower to associate with your image";
                }
                else
                {
                    string imagePath = "~/images/" + selectedRow.Cells[1].Text;
                    string path = Server.MapPath(imagePath + ".jpg");
                    string path2 = Server.MapPath(imagePath + " 2.jpg");
                    string path3 = Server.MapPath(imagePath + " 3.jpg");
                    string path4 = Server.MapPath(imagePath + " 4.jpg");

                    if (File.Exists(path) && File.Exists(path2) && File.Exists(path3) && File.Exists(path4))
                    {
                        Label1.Text = "Maximum images (4) reached for that flower";
                    }
                    else if (File.Exists(path) && File.Exists(path2) && File.Exists(path3))
                    {
                        upload.SaveAs(path4);
                    }
                    else if (File.Exists(path) && File.Exists(path2))
                    {
                        upload.SaveAs(path3);
                    }
                    else if (File.Exists(path))
                    {
                        upload.SaveAs(path2);
                    }
                    else
                    {
                        upload.SaveAs(path);
                    }
                    GridView1_SelectedIndexChanged(this, e);
                }
            }
        }

        protected void csvUpload_Click(object sender, EventArgs e)
        {
            if (upload.HasFile == false)
            {
                Label1.Text = "Please first select a file to upload...";
            }
            else
            {
                string fileName = upload.PostedFile.FileName;
                string extension = fileName.Substring(fileName.Length - 4);
                if (extension == ".csv")
                {
                    string filePath = Server.MapPath("~/images/fuchsiaRegister.csv");
                    upload.SaveAs(filePath);

                    Label1.Text = "";
                    Page_Load(this, e);
                }
                else
                    Label1.Text = "The uploaded file must be in .csv format";
            }
        }
    }       
}
