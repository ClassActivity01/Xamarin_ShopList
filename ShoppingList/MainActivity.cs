using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using SQLiteDB.Resources.Helper;
using SQLiteDB.Resources.Model;
using SQLite;
using ShoppingList;
using System.Collections.Generic;

namespace ShoppingList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView lstViewData;
        List<Item> listSource = new List<Item>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Create Database 
            db = new Database();
            db.createDatabase();
            lstViewData = FindViewById<ListView>(Resource.Id.listView);
            var edtName = FindViewById<EditText>(Resource.Id.edtName);
          
            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
           
            var btnRemove = FindViewById<Button>(Resource.Id.btnRemove);
            //Load Data  
            LoadData();
            //Event  
            btnAdd.Click += delegate
            {
                Item person = new Item()
                {
                    Name = edtName.Text,
                };
                db.InsertIntoTable(person);
                LoadData();
            };
           
            btnRemove.Click += delegate
            {
                Item item = new Item()
                {
                    Id = int.Parse(edtName.Tag.ToString()),
                    Name = edtName.Text,
                   
                };
                db.removeTable(item);
                LoadData();
            };
            lstViewData.ItemClick += (s, e) =>
            {
                //Set Backround for selected item  
                for (int i = 0; i < lstViewData.Count; i++)
                {
                    if (e.Position == i)
                        lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Black);
                    else
                        lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
                //Binding Data  
                var txtName = e.View.FindViewById<TextView>(Resource.Id.txtView_Name);
            
                //edtEmail.Text = txtName.Text;
                edtName.Tag = e.Id;
                
            };
        }
        private void LoadData()
        {
            listSource = db.SelectTable();
            var adapter = new ListViewAdapter(this, listSource);
            lstViewData.Adapter = adapter;
        }
    }
}
        
    
