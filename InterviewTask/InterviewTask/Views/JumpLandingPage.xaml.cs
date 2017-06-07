using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterviewTask.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JumpLandingPage : ContentPage
	{
		public JumpLandingPage ()
		{
			StackLayout stackLayout = new StackLayout();
			Image image = new Image
			{
				Source = "BackArrow.png",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Start,
				HeightRequest = 30,
				Margin = new Thickness(10, 10, 0, 0)
			};
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				Return();
			};
			image.GestureRecognizers.Add(tapGestureRecognizer);

			stackLayout.Children.Add(image);
			stackLayout.Children.Add(new Label
			{
				Text = "This is Jump Landing Page",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				TextColor = Color.White
			});

			Content = stackLayout;

			InitializeComponent ();
		}

		void Return()
		{
			Navigation.PopAsync();
		}
	}
}