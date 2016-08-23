using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TestBindPickers
{
	public class App : Application
	{
		public App()
		{

			List<FirstModel> listFirstModel = new List<FirstModel>();
			listFirstModel.Add(new FirstModel { Key = "Pl", Description = "DescPl" });
			listFirstModel.Add(new FirstModel { Key = "Ps", Description = "DescPs" });
			listFirstModel.Add(new FirstModel { Key = "En", Description = "DescEn" });
			listFirstModel.Add(new FirstModel { Key = "H", Description = "DescH" });

			List<SecondModel> listSecondModel = new List<SecondModel>();
			listSecondModel.Add(new SecondModel {FirstModelKey ="Pl", Key = "Pl1", Description = "SecondModelPl1"  });
			listSecondModel.Add(new SecondModel { FirstModelKey = "Pl", Key = "Pl2", Description = "SecondModelPl2" });
			listSecondModel.Add(new SecondModel { FirstModelKey = "Pl", Key = "Pl3", Description = "SecondModelPl3" });

			listSecondModel.Add(new SecondModel { FirstModelKey = "Ps", Key = "Ps1", Description = "SecondModelPs1" });
			listSecondModel.Add(new SecondModel { FirstModelKey = "Ps", Key = "Ps2", Description = "SecondModelPs2" });
			listSecondModel.Add(new SecondModel { FirstModelKey = "Ps", Key = "Ps3", Description = "SecondModelPs3" });

			listSecondModel.Add(new SecondModel { FirstModelKey = "En", Key = "En1", Description = "SecondModelEn1" });
			listSecondModel.Add(new SecondModel { FirstModelKey = "En", Key = "En2", Description = "SecondModelEn2" });
			listSecondModel.Add(new SecondModel { FirstModelKey = "En", Key = "En3", Description = "SecondModelEn3" });

			listSecondModel.Add(new SecondModel { FirstModelKey = "H", Key = "H1", Description = "SecondModelH1" });
			listSecondModel.Add(new SecondModel { FirstModelKey = "H", Key = "H2", Description = "SecondModelH2" });
			listSecondModel.Add(new SecondModel { FirstModelKey = "H", Key = "H3", Description = "SecondModelH3" });

			Picker pickerSecondModel = new Picker { Title="SECOND PICKER depends by FIRST"};

			Picker pickerFirstModel = new Picker { Title = "FIRST PICKER" };
			foreach (FirstModel fm in listFirstModel) { 
				pickerFirstModel.Items.Add(fm.Description);
			}
			pickerFirstModel.SelectedIndexChanged += (sender, e) => { 
			
				pickerSecondModel.Items.Clear();

				string key = listFirstModel[pickerFirstModel.SelectedIndex].Key;
				foreach (SecondModel sm in listSecondModel.FindAll(o => o.FirstModelKey == key))
					pickerSecondModel.Items.Add(sm.Description);
					
			};



			StackLayout sl = new StackLayout {Padding = new Thickness(20,20,20,20) };
			sl.Children.Add(pickerFirstModel);
			sl.Children.Add(pickerSecondModel);

			ContentPage cp = new ContentPage();
			cp.Content = sl;
			MainPage = cp;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

