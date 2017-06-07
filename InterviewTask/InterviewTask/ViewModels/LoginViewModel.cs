using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace InterviewTask.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		public string Username { get; set; }
		public string Password { get; set; }

		public LoginViewModel()
		{
			Username = string.Empty;
			Password = string.Empty;
		}
	}
}