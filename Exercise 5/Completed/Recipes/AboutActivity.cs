using Android.App;
using Android.OS;

namespace Recipes
{
	[Activity(Label = "AboutActivity")]
	public class AboutActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.About);
		}
	}
}