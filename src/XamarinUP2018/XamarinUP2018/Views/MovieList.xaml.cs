﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUP2018.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieList : ContentPage
	{
		public MovieList ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}