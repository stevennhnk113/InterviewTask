using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTask;
using InterviewTask.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterviewTask.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		LoginViewModel viewModel;
		StackLayout stackLayout;
		Image RememberPasswordCheckbox;
		Image UsernameInputBoxFocus;
		Image PasswordInputBoxFocus;
		CustomEntry UsernameInputBoxFocusEntry;
		CustomEntry PasswordInputBoxFocusEntry;

		public LoginPage()
		{
			var style = new Style(typeof(Grid))
			{
				Setters =
				{
					new Setter { Property = Grid.HorizontalOptionsProperty, Value = LayoutOptions.Center },
					new Setter { Property = Grid.WidthRequestProperty, Value = 200}
			}
			};
			Resources = new ResourceDictionary();
			Resources.Add(style);

			BindingContext = this.viewModel = new LoginViewModel();
			stackLayout = new StackLayout();

			BackgroundImage = "LoginBackground.png";
			Content = stackLayout;
			SetUpLayout();

			InitializeComponent();
		}

		void SetUpLayout()
		{
			SetUpBackArrow();
			SetUpTitle();
			SetUpSignInIcon();
			stackLayout.Children.Add(new Label { Text = "Or", FontSize = 12, TextColor = new Color(255, 255, 255), HorizontalTextAlignment = TextAlignment.Center });
			SetUpInputBox();
			SetUpRememberPasswordBox();
			SetUpLoginAndRegisterButton();
			stackLayout.Children.Add(new Label
			{
				Text = "@2016 SapphireView Inc. All right Reserved",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.EndAndExpand,
				Margin = new Thickness(0, 0, 0, 10),
				FontSize = 10
			});
		}

		void SetUpBackArrow()
		{
			Image image = new Image();
			image.Source = "BackArrow.png";
			image.HorizontalOptions = new LayoutOptions(LayoutAlignment.Start, false);
			image.VerticalOptions = new LayoutOptions(LayoutAlignment.Center, false);
			image.Margin = new Thickness(10, 10, 0, 0);
			image.HeightRequest = 30;

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				Exit();
			};
			image.GestureRecognizers.Add(tapGestureRecognizer);

			stackLayout.Children.Add(image);
		}

		void SetUpTitle()
		{
			Grid grid = new Grid();
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

			grid.Children.Add(new Label
			{
				Text = "Log In",
				FontSize = 35,
				TextColor = new Color(255, 255, 255),
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalOptions = new LayoutOptions(LayoutAlignment.Center, true)
			}, 0, 1);

			stackLayout.Children.Add(grid);
		}

		void SetUpSignInIcon()
		{
			var style = new Style(typeof(Image))
			{
				Setters =
				{
					new Setter { Property = Image.HorizontalOptionsProperty, Value = LayoutOptions.Center },
					new Setter { Property = Image.VerticalOptionsProperty, Value = LayoutOptions.Center}
			}
			};

			Grid grid = new Grid();
			grid.Resources = new ResourceDictionary();
			grid.Resources.Add(style);

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(45) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(45) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(45) });

			grid.Children.Add(new Image { Source = "Facebook.png" }, 0, 0);
			grid.Children.Add(new Image { Source = "Twitter.png" }, 2, 0);
			grid.Children.Add(new Image { Source = "Google.png" }, 4, 0);
			grid.Children.Add(new Image { Source = "QQ.png" }, 0, 1);
			grid.Children.Add(new Image { Source = "Wechat.png" }, 2, 1);
			grid.Children.Add(new Image { Source = "Weibo.png" }, 4, 1);

			TapGestureRecognizer tapGestureRecognizer;
			foreach (var image in grid.Children)
			{
				tapGestureRecognizer = new TapGestureRecognizer();
				tapGestureRecognizer.Tapped += (s, e) =>
				{
					OnTapGestureRecognizerTapped();
				};
				image.GestureRecognizers.Add(tapGestureRecognizer);
			}

			stackLayout.Children.Add(grid);
		}

		void SetUpInputBox()
		{
			Grid grid = new Grid();

			grid.Resources = new ResourceDictionary();
			grid.Resources.Add(new Style(typeof(CustomEntry))
			{
				Setters =
				{
					new Setter { Property = CustomEntry.BackgroundColorProperty, Value = Color.Transparent },
					new Setter { Property = CustomEntry.TextColorProperty, Value = Color.White },
					new Setter { Property = CustomEntry.FontSizeProperty, Value = 12 },
					new Setter { Property = CustomEntry.PlaceholderColorProperty, Value = Color.White },
					new Setter { Property = CustomEntry.VerticalOptionsProperty, Value = LayoutOptions.Center },
					new Setter { Property = CustomEntry.MarginProperty, Value = new Thickness(10,0,0,0) }
				}
			});
			grid.Resources.Add(new Style(typeof(Image))
			{
				Setters =
				{
					new Setter { Property = Image.AspectProperty, Value = Aspect.Fill }
				}
			});

			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(35) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(35) });

			// Username input box
			grid.Children.Add(new Image { Source = "Txt.png" }, 0, 0);

			UsernameInputBoxFocus = new Image { Source = "TxtFocus.png", IsVisible = false };
			grid.Children.Add(UsernameInputBoxFocus, 0, 0);

			UsernameInputBoxFocusEntry = new CustomEntry { Placeholder = "Username" };
			UsernameInputBoxFocusEntry.Focused += ChangeUsernameInputBoxFocus;
			UsernameInputBoxFocusEntry.Unfocused += ChangeUsernameInputBoxFocus;
			grid.Children.Add(UsernameInputBoxFocusEntry, 0, 0);

			// Password input box
			grid.Children.Add(new Image { Source = "Txt.png" }, 0, 1);

			PasswordInputBoxFocus = new Image { Source = "TxtFocus.png", IsVisible = false };
			grid.Children.Add(PasswordInputBoxFocus, 0, 1);

			PasswordInputBoxFocusEntry = new CustomEntry { Placeholder = "Password", IsPassword = true };
			PasswordInputBoxFocusEntry.Focused += ChangePasswordInputBoxFocus;
			PasswordInputBoxFocusEntry.Unfocused += ChangePasswordInputBoxFocus;
			grid.Children.Add(PasswordInputBoxFocusEntry, 0, 1);

			stackLayout.Children.Add(grid);
		}

		void SetUpRememberPasswordBox()
		{
			Grid grid = new Grid();

			var style = new Style(typeof(Image))
			{
				Setters =
				{
					new Setter { Property = Image.InputTransparentProperty, Value = true }
				}
			};
			grid.Resources = new ResourceDictionary();
			grid.Resources.Add(style);

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto)});
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto)});
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto)});

			Button button = new Button { BackgroundColor = Color.Transparent, BorderColor = Color.Transparent, Opacity = 0 };
			button.Clicked += ChangeCheckBoxStatus;
			grid.Children.Add(button, 0, 0);
			Grid.SetColumnSpan(button, 3);

			grid.Children.Add(new Image { Source = "UnCheckBox.png" }, 0, 0);
			RememberPasswordCheckbox = new Image { Source = "CheckBox.png", IsVisible = false };
			grid.Children.Add(RememberPasswordCheckbox, 0, 0);

			grid.Children.Add(new Label
			{
				Text = "Remember me?",
				LineBreakMode = LineBreakMode.NoWrap,
				VerticalOptions = LayoutOptions.Center,
				InputTransparent = true,
				TextColor = Color.White
			}, 1, 0);

			stackLayout.Children.Add(grid);

		}

		void SetUpLoginAndRegisterButton()
		{
			Button button;
			Grid grid = new Grid();

			grid.Resources = new ResourceDictionary();
			grid.Resources.Add(new Style(typeof(Image))
			{
				Setters =
				{
					new Setter { Property = Image.InputTransparentProperty, Value = true }
				}
			});
			grid.Resources.Add(new Style(typeof(Label))
			{
				Setters =
				{
					new Setter { Property = Label.FontSizeProperty, Value = 20 },
					new Setter { Property = Label.TextColorProperty, Value = Color.White },
					new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.Center },
					new Setter { Property = Label.VerticalOptionsProperty, Value = LayoutOptions.Center },
					new Setter { Property = Label.InputTransparentProperty, Value = true }
				}
			});

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(35) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(35) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

			// Log In
			button = new Button();
			button.Clicked += LogUserIn;
			grid.Children.Add(button, 0, 0);

			grid.Children.Add(new Image { Source = "RedBTN.png" }, 0, 0);
			grid.Children.Add(new Label { Text = "Login" }, 0, 0);

			// Forgot password
			Label label = new Label { Text = "Forgot your password?", TextColor = Color.Red, FontSize = (double)NamedSize.Default, Margin = new Thickness(0,0,0,20), InputTransparent = false};
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				OnTapGestureRecognizerTapped();
			};
			label.GestureRecognizers.Add(tapGestureRecognizer);
			grid.Children.Add(label, 0, 1);

			// Register
			button = new Button();
			button.Clicked += LogUserIn;
			grid.Children.Add(button, 0, 2);

			grid.Children.Add(new Image { Source = "RedBTN.png" }, 0, 2);
			grid.Children.Add(new Label { Text = "Register" }, 0, 2);

			stackLayout.Children.Add(grid);

		}

		private void LogUserIn(object sender, EventArgs e)
		{
			DisplayAlert("Invalid", "Please input or input invalid username/password", "OK");
		}

		private void ChangeCheckBoxStatus(object sender, EventArgs e)
		{
			RememberPasswordCheckbox.IsVisible = !RememberPasswordCheckbox.IsVisible;
		}

		private void ChangePasswordInputBoxFocus(object sender, FocusEventArgs e)
		{
			if (PasswordInputBoxFocusEntry.Placeholder.Equals(string.Empty))
			{
				PasswordInputBoxFocusEntry.Placeholder = "Password";
			}
			else
			{
				PasswordInputBoxFocusEntry.Placeholder = string.Empty;
			}
			PasswordInputBoxFocus.IsVisible = !PasswordInputBoxFocus.IsVisible;
		}

		private void ChangeUsernameInputBoxFocus(object sender, FocusEventArgs e)
		{
			if (UsernameInputBoxFocusEntry.Placeholder.Equals(string.Empty))
			{
				UsernameInputBoxFocusEntry.Placeholder = "Username";
			}
			else
			{
				UsernameInputBoxFocusEntry.Placeholder = string.Empty;
			}
			UsernameInputBoxFocus.IsVisible = !UsernameInputBoxFocus.IsVisible;
		}

		void OnTapGestureRecognizerTapped()
		{
			JumpLandingPage page = new JumpLandingPage();
			Navigation.PushAsync(page);
			NavigationPage.SetHasNavigationBar(page, false);
		}

		void Exit()
		{
			//string alert;
			//switch (Device.RuntimePlatform)
			//{
			//	case Device.iOS:
			//		alert = "Please press home button to exit";
			//		break;
			//	case Device.Android:
			//		alert = "Please press home button to exit";
			//		break;
			//	case Device.Windows:
			//		alert = "Just click the x button on upper left corner";
			//		break;
			//	case Device.WinPhone:
			//		alert = "Please press home button to exit";
			//		break;
			//}
			//DisplayAlert("Exiting", alert, "OK");

			DisplayAlert("Exiting", "Just click the x button on upper left corner", "OK");
		}
	}
}