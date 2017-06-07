using InterviewTask.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InterviewTask
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
			LoginPage loginPage = new LoginPage();
			Current.MainPage = new NavigationPage(loginPage);
			NavigationPage.SetHasNavigationBar(Current.MainPage.Navigation.NavigationStack[Current.MainPage.Navigation.NavigationStack.Count - 1], false);
			MessagingCenter.Subscribe<ContentPage>(Current.MainPage, "RemoveNavigationBar", (sender) => {
				NavigationPage.SetHasNavigationBar(Current.MainPage.Navigation.NavigationStack[Current.MainPage.Navigation.NavigationStack.Count - 1], false);
			});
		}
	}
}
