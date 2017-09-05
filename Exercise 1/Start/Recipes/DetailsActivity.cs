using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;

namespace Recipes
{
	[Activity(Label = "DetailsActivity")]
	public class DetailsActivity : Activity
	{
		Recipe recipe;
		ArrayAdapter adapter;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Details);

			//
			// Retrieve the recipe to be displayed on this page
			//
			int index = Intent.GetIntExtra("RecipeIndex", -1);
			recipe = RecipeData.Recipes[index];

			//
			// Show the recipe name
			//
			var name = FindViewById<TextView>(Resource.Id.nameTextView);
			name.Text = recipe.Name;

			//
			// Show the list of ingredients
			//
			var list = FindViewById<ListView>(Resource.Id.ingredientsListView);
			list.Adapter = adapter = new ArrayAdapter<Ingredient>(this, Android.Resource.Layout.SimpleListItem1, recipe.Ingredients);

			//
			// Set up the "Favorite" toggle, we use different images for the 'on' and 'off' states
			//
			var toggle = FindViewById<ToggleButton>(Resource.Id.favoriteButton);
			toggle.CheckedChange += OnFavoriteCheckedChange;
			SetFavoriteDrawable(recipe.IsFavorite);

			//
			// Set up the "Number of servings" buttons
			//
			FindViewById<Button>(Resource.Id.oneServingButton).Click   += (sender, e) => SetServings(1);
			FindViewById<Button>(Resource.Id.twoServingsButton).Click  += (sender, e) => SetServings(2);
			FindViewById<Button>(Resource.Id.fourServingsButton).Click += (sender, e) => SetServings(4);

			//
			// Navigation button: navigate back to the previous page
			//
			FindViewById<ImageButton>(Resource.Id.backButton).Click += (sender, e) => Finish();

			//
			// Navigation button: navigate forward to the About page
			//
			FindViewById<Button>(Resource.Id.aboutButton).Click += (sender, e) => StartActivity(typeof(AboutActivity));
		}

		//
		// Handler for the 'favorite' toggle button
		//
		void OnFavoriteCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			recipe.IsFavorite = e.IsChecked; // update the recipe's state

			SetFavoriteDrawable(e.IsChecked); // toggle the image used on the button
		}

		void SetFavoriteDrawable(bool isFavorite)
		{
			Drawable drawable = null;

			if (isFavorite)
				drawable = base.GetDrawable(Resource.Drawable.ic_favorite_white_24dp); // filled in 'heart' image
			else
				drawable = base.GetDrawable(Resource.Drawable.ic_favorite_border_white_24dp); // 'heart' image border only

			FindViewById<ToggleButton>(Resource.Id.favoriteButton).SetCompoundDrawablesWithIntrinsicBounds(null, drawable, null, null);
		}
		// Note: base.GetDrawable requires API level 21
		// To run on earlier versions, change the minimum API level in the project settings and use the following code:
		//void SetFavoriteDrawables(bool isFavorite)
		//{
		//	Drawable drawable = null;
		//
		//	if (isFavorite)
		//		drawable = Resources.GetDrawable(Resource.Drawable.ic_favorite_white_24dp);
		//	else
		//		drawable = Resources.GetDrawable(Resource.Drawable.ic_favorite_border_white_24dp);
		//
		//	FindViewById<ToggleButton>(Resource.Id.favoriteButton).SetCompoundDrawablesWithIntrinsicBounds(null, drawable, null, null);
		//}

		void SetServings(int numServings)
		{
			recipe.NumServings = numServings;

			adapter.NotifyDataSetChanged();
		}
	}
}