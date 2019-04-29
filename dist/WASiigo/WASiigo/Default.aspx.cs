using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WASiigo.Controller;
using WASiigo.Model;

namespace WASiigo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    this.setTableDevelopers();
                    this.setTableProducts();
                }
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            createProduct();
        }

        public async void createProduct()
        {
            try
            {
                string code = txtCode.Value;
                string description = txtDescription.Value;
                string reference = txtReference.Value;
                string productType = txtTypeProduct.Value;
                string unit = txtMedyUnit.Value;
                string barCode = txtBarCode.Value;
                string comentary = txtComentary.Value;
                string costStr = txtCost.Value;
                string statusStr = txtStatus.Value;
                decimal cost = decimal.Parse(costStr);
                int status = int.Parse(statusStr);

                Product product = new Product();
                product.Id = 0;
                product.Code = code;
                product.Description = description;
                product.ReferenceManufactures = reference;
                product.ProductTypeKey = productType;
                product.MeasureUnit = unit;
                product.CodeBars = barCode;
                product.Comments = comentary;
                product.TaxAddID = 0;
                product.TaxDiscID = 0;
                product.IsIncluded = true;
                product.Cost = cost;
                product.IsInventoryControl = true;
                product.State = status;
                product.PriceList1 = 0;
                product.PriceList2 = 0;
                product.PriceList3 = 0;
                product.PriceList4 = 0;
                product.PriceList5 = 0;
                product.PriceList6 = 0;
                product.PriceList7 = 0;
                product.PriceList8 = 0;
                product.PriceList9 = 0;
                product.PriceList10 = 0;
                product.PriceList11 = 0;
                product.PriceList12 = 0;
                product.Image = "string";
                product.AccountGroupID = 40;
                product.SubType = 0;
                product.TaxAdd2ID = 0;
                product.TaxImpoValue = 0;
                product = await DefaultController.CreateProduct(product);
                if (product.Id < 0)
                    throw new Exception("No se puedo ingresar el producto.");
                else
                {
                    string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";
                    script = string.Format(script, "Producto agregado correctamente");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    this.setTableProducts();
                }
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                long id = long.Parse(GridView1.DataKeys[e.RowIndex].Values["Id"].ToString());
                DefaultController.DeleteProduct(id);
                string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";
                script = string.Format(script, "Producto eliminado correctamente");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                this.setTableProducts();
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        public async void setTableProducts()
        {
            try
            {
                List<Product> products = await DefaultController.GetProducts();
                DataTable tableProducts = Utils.Util.ConvertToDataTable<Product>(products);
                GridView1.DataSource = tableProducts;
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        public async void setTableDevelopers()
        {
            try
            {
                List<Developer> developers = await DefaultController.GetDevelopers();
                DataTable tableDevelopers = Utils.Util.ConvertToDataTable<Developer>(developers);
                GridView2.DataSource = tableDevelopers;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
    }
}