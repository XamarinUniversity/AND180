using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;

namespace Recipes
{
	[Activity(Label = "Recipes", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		ArrayAdapter adapter;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			var list = FindViewById<ListView>(Resource.Id.recipesListView);
			list.ItemClick += OnItemClick;
			list.Adapter = adapter = new ArrayAdapter<Recipe>(this, Android.Resource.Layout.SimpleListItem1, RecipeData.Recipes);
		}

		void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var intent = new Intent(this, typeof(DetailsActivity));
			intent.PutExtra("RecipeIndex", e.Position);
			StartActivityForResult(intent, 0 /* requestCode not needed but is a required parameter */);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			adapter.NotifyDataSetChanged(); // update ListView in case the 'favorite' setting of the recipe changed
		}
	}
}