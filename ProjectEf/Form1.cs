using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace ProjectEf
{
    public partial class Form1 : Form
    {
        ProjectContainer EfContainer;
        public Form1()
        {
            InitializeComponent();
            EfContainer = new ProjectContainer();
        }
        private void display()
        {
            int id;
            if(int.TryParse(WareH_id.Text, out id))
            {
                var Store = EfContainer.stores;
                stores store = Store.Find(id);
                if (store == null)
                {
                    store = new stores();
                    store.Id = int.Parse(WareH_id.Text);
                    store.Name = WareH_N.Text;
                    store.Adress = WareH_Add.Text;
                    store.ManagerName = WareH_Manager.Text;
                    EfContainer.stores.Add(store);
                    EfContainer.SaveChanges();

                }
                else
                {
                    var x = MessageBox.Show("You are going to update Store", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (x == DialogResult.Yes)
                    {
                        store.Name = WareH_N.Text;
                        store.Adress = WareH_Add.Text;
                        store.ManagerName = WareH_Manager.Text;
                        EfContainer.SaveChanges();
                    }
                }
            }

            var Show = EfContainer.stores.ToList();
            dataGridView1.DataSource = Show;
            dataGridView1.Columns["StoredCategories"].Visible = false;
            WareH_N.Text = WareH_id.Text = WareH_Add.Text = WareH_Manager.Text = WareH_Add.Text = "";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            display();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var Show = from d in EfContainer.StoredCategories select new
            {
                StoreId= d.storesId,
                StoreName=d.store.Name,
                categoryName=d.categorize.Name,
                AmountInStore=d.AmountInStore,
            };
          
            dataGridView1.DataSource=Show.ToList();
        
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var Category = EfContainer.categorizes1;
            categorizes categorizes = Category.Find(int.Parse(Category_id.Text));
            if (categorizes == null)
            {
                categorizes = new categorizes();
                categorizes.Id = int.Parse(Category_id.Text);
                categorizes.Name = Category_Name.Text;
                categorizes.UnitM = Category_Unit.Text;
                categorizes.Amount = int.Parse(Category_Amount.Text);
                EfContainer.categorizes1.Add(categorizes);
                EfContainer.SaveChanges();

            }
            else
            {
                var x = MessageBox.Show("You are going to update Category", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.Yes)
                {
                    categorizes.Name = Category_Name.Text;
                    categorizes.UnitM = Category_Unit.Text;
                    categorizes.Amount = int.Parse(Category_Amount.Text);
                    EfContainer.SaveChanges();
                }
            }
            var Show = EfContainer.categorizes1.ToList();
            dataGridView2.DataSource = Show;
            Category_id.Text=Category_Name.Text=Category_Unit.Text=Category_Amount.Text ="";

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var Supplier = EfContainer.Suppliers1;
            int id;
            if (int.TryParse(Supplier_id.Text, out id))
            {
                Suppliers supp = Supplier.Find(id);
                if (supp == null)
                {
                    supp = new Suppliers();

                    supp.Id = id;
                    supp.Name = Supplier_Name.Text;
                    supp.PhoneNum = int.Parse(Supplier_PN.Text);
                    supp.Tele = int.Parse(Supplier_Tele.Text);
                    supp.Fax = Supplier_Fax.Text;
                    supp.WebSite = Supplier_Web.Text;
                    supp.Mail = Supplier_Mail.Text;
                    EfContainer.Suppliers1.Add(supp);

                }
                else
                {
                    var x = MessageBox.Show("You are going to update Suppler Info", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (x == DialogResult.Yes)
                    {
                        supp.Name = Supplier_Name.Text;
                        supp.PhoneNum = int.Parse(Supplier_PN.Text);
                        supp.Tele = int.Parse(Supplier_Tele.Text);
                        supp.Fax = Supplier_Fax.Text;
                        supp.WebSite = Supplier_Web.Text;
                        supp.Mail = Supplier_Mail.Text;
                    }
                }
            }
           
            EfContainer.SaveChanges();
            var show=EfContainer.Suppliers1.ToList();
            dataGridView3.DataSource = show;
            dataGridView3.Columns["Imports"].Visible = false;
            Supplier_id.Text = Supplier_Fax.Text = Supplier_Name.Text = Supplier_PN.Text = Supplier_Web.Text = Supplier_Tele.Text = Supplier_Mail.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var Cli = EfContainer.Clients;
            Clients client = Cli.Find(int.Parse(Client_id.Text));
            if (client == null)
            {
                client = new Clients();
                client.Id = int.Parse(Client_id.Text);
                client.CName = Client_Name.Text;
                client.CPhone = int.Parse(Client_PN.Text);
                client.Tele = int.Parse(Client_Tele.Text);
                client.Fax = Client_Fax.Text;
                client.Website = Client_web.Text;
                client.Mail = Supplier_Mail.Text;
                EfContainer.Clients.Add(client);
                

            }
            else
            {
                var x = MessageBox.Show("You are going to update Suppler Info", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.Yes)
                {
                    client.Id = int.Parse(Client_id.Text);
                    client.CName = Client_Name.Text;
                    client.CPhone = int.Parse(Client_PN.Text);
                    client.Tele = int.Parse(Client_Tele.Text);
                    client.Fax = Client_Fax.Text;
                    client.Website = Client_web.Text;
                    client.Mail = Supplier_Mail.Text;
                }
            }

            EfContainer.SaveChanges();
            var show = Cli.ToList();
            dataGridView4.DataSource = show;
            dataGridView4.Columns["Exports"].Visible = false;
            Cli_id.Text=Client_Fax.Text=Client_Mail.Text=Client_Name.Text=Client_PN.Text=Client_web.Text=Client_Tele.Text="";

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int cId = int.Parse(ICate_Id.Text);
            var Imports = EfContainer.Imports1;
            var stores = (from d in EfContainer.stores where d.Name == StoreName.Text select d).FirstOrDefault();
            ImportedCategory importedCategory = new ImportedCategory();
            categorizes category = EfContainer.categorizes1.Find(cId);
            Import imp = new Import();
            imp.Id = int.Parse(Import_Id.Text);
            imp.StoreName = StoreName.Text;
            imp.SuppliersId = int.Parse(Supp_ID.Text);
            imp.Date = DateTime.Now;
            EfContainer.Imports1.Add(imp);
            importedCategory.ImportId = int.Parse(Import_Id.Text);
            importedCategory.categorizesId = cId;
            DateTime prodDate;
            DateTime ExpDate;
            if (DateTime.TryParseExact(ProdD.Text, "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture ,System.Globalization.DateTimeStyles.None,out prodDate))
            {
                importedCategory.prodDate = prodDate;
            }
            if (DateTime.TryParseExact(ExpD.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ExpDate))
            {
                importedCategory.ExpDate = ExpDate;
            }
                importedCategory.Amount = int.Parse(IAmount.Text);
                EfContainer.ImportedCategories.Add(importedCategory);
                if (category == null)
                {
                    category = new categorizes();
                    category.Id = cId;
                    category.Name = CateName.Text;
                    category.UnitM = Category_Unit.Text;
                    category.Amount = int.Parse(IAmount.Text);
                    EfContainer.categorizes1.Add(category);
                    StoredCategory stored = new StoredCategory();
                    stored.categorizesId = cId;
                    stored.storesId = stores.Id;
                    stored.AmountInStore = int.Parse(IAmount.Text);
                    stored.ProdDate = prodDate;
                    stored.ExpDate = ExpDate;
                EfContainer.StoredCategories.Add(stored);

                }
                else  
                {
                MessageBox.Show(prodDate+"");
                    var stored=EfContainer.StoredCategories.FirstOrDefault( d=> d.categorizesId == cId && d.store.Name==StoreName.Text && d.ProdDate == prodDate);
                    if (stored == null)
                    {
                        StoredCategory store = new StoredCategory();
                        store.categorizesId = cId;
                        store.storesId = stores.Id;
                        store.AmountInStore = int.Parse(IAmount.Text);
                        store.ProdDate = prodDate;
                        store.ExpDate = ExpDate;
                        category.Amount += int.Parse(IAmount.Text);
                        EfContainer.StoredCategories.Add(store);
                    }
                    else {
                        stored.AmountInStore += int.Parse(IAmount.Text);
                        category.Amount += int.Parse(IAmount.Text);
                    }
                    


                }
                EfContainer.SaveChanges();
                var show = EfContainer.Imports1.ToList();
                dataGridView5.DataSource = show;
        }

        private void ExPerm_Click(object sender, EventArgs e)
        {
            int x= int.Parse(Amount.Text);
            var Exports = EfContainer.Exports;
            var Stord = (from d in EfContainer.StoredCategories where d.AmountInStore >= (int.Parse(Amount.Text)) orderby d.ExpDate  select d ).FirstOrDefault();
            Export Exp = Exports.Find(int.Parse(Export_Id.Text));
            ExportedCategory exportedCategory = new ExportedCategory();
            categorizes category = EfContainer.categorizes1.Find(int.Parse(ECate_Id.Text));
            int Check = (from d in EfContainer.categorizes1 where d.Id== (int.Parse(ECate_Id.Text)) select (d.Amount)).Sum();
            if (Check >= x && Exp == null)
            {
                Exp = new Export();
                Exp.Id = int.Parse(Import_Id.Text);
                Exp.StoreName = Stord.store.Name;
                Exp.ClientsId = int.Parse(Cli_id.Text);
                Exp.Date = DateTime.Now;
                EfContainer.Exports.Add(Exp);
                exportedCategory.ExportId = int.Parse(Export_Id.Text);
                exportedCategory.categorizesId = int.Parse(ECate_Id.Text);
                exportedCategory.Amount = int.Parse(Amount.Text);
                category.Amount -= int.Parse(Amount.Text);
                EfContainer.ExportedCategories.Add(exportedCategory);
                EfContainer.SaveChanges();
            }
            else if (Exp == null) {
                MessageBox.Show("Invalid Process There is Not Enough Amount ");
            }
            else if (Exp != null) {
                Exp.ClientsId = int.Parse(Cli_id.Text);
            }
        }

        private void StoreRep_Click(object sender, EventArgs e)
        {
            int Store = int.Parse(WareH_id.Text);
            var I = from d in EfContainer.StoredCategories where d.storesId==Store orderby d.storesId select new
            {
                StoreName=d.store.Name,
                StoreAddres=d.store.Adress,
                StoreManager=d.store.ManagerName,
                Category=d.categorize.Name,
                Amount=d.AmountInStore,
                ExpDate=d.ExpDate,
            }; 
            dataGridView1.DataSource=I.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int Store = int.Parse(WareH_id.Text);
            var I = from d in EfContainer.StoredCategories group d by d.categorizesId into g select new
            {
                category=g.Key,
                StoreNum=g.Sum(x=>x.storesId)
            };
            var c = from d in I join w in EfContainer.categorizes1 on d.category equals w.Id select new {
                CategoryId=d.category,
                CategoryName=w.Name,
                NumOfStores=d.StoreNum,
                UnitM=w.UnitM,
                TotalAmount=w.Amount
            };
            dataGridView2.DataSource=c.ToList();
        }


        private void WareHouse_Selected(object sender, TabControlEventArgs e)
        {
            dataGridView6.DataSource= EfContainer.StoredCategories.ToList();
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow=dataGridView6.Rows[e.RowIndex];
            string ExportId = Export_Id.Text;
            string StoreName=selectedRow.Cells[0].Value.ToString();
            string CliId=selectedRow.Cells[3].Value.ToString();
            string CateId = selectedRow.Cells[1].Value.ToString();
            string amount=selectedRow.Cells[2].Value.ToString();
            ExportFStore.Text=StoreName;
            Cli_id.Text=CliId;
            ECate_Id.Text=CateId;
            Amount.Text=amount;
            dataGridView7.Rows.Add(ExportId,StoreName,CliId,CateId,amount);
        }


        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView7.ColumnCount=5;
            dataGridView7.Columns[0].Name = "Expo";
        }
    }
}
