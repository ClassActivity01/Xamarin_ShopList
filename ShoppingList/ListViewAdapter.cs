using Android.App;
using Android.Views;
using Android.Widget;
using ShoppingList;
using System.Collections.Generic;
using System.Resources;
namespace SQLiteDB.Resources.Model
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtDepartment { get; set; }
        public TextView txtEmail { get; set; }
    }
    public class ListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Item> listItem;
        public ListViewAdapter(Activity activity, List<Item> listItem)
        {
            this.activity = activity;
            this.listItem = listItem;
        }
        public override int Count
        {
            get { return listItem.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return listItem[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view, parent, false);
            var txtName = view.FindViewById<TextView>(Resource.Id.txtView_Name);
            
            txtName.Text = listItem[position].Name;
            return view;
        }
    }
}