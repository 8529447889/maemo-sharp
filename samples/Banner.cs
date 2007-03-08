//
// Maemo# - Maemo bindings for Mono
//
// Author: 
//   Michael Golisch <mgolisch@googlemail.com>
//
// Copyright (c) 2006 - 2007 Novell, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using Gtk;
using Hildon;

public class BannerExample : Hildon.Window
{
	public static void Main (string[] args)
	{
		Application.Init ("mono", ref args);

		Program program = Program.Instance;
		program.AddWindow (new BannerExample ());

		Application.Run ();
	}

	private static Hildon.Banner banner = null;
	private static int banner_type = 1;
	
	public BannerExample ()
	{
		this.Destroyed += delegate {Application.Quit ();};
		this.Title = "BannerExample";
		this.BorderWidth = 6;

		Gtk.VBox vbox_main = new VBox (false, 0);
		Gtk.Button btn = new Button ("Show Info");
		btn.Clicked += new EventHandler (show_banner);

		vbox_main.PackStart (btn);

		this.Add (vbox_main);
		this.ShowAll();	
	}

	protected void show_banner(object source, EventArgs e)
	{
		  switch (banner_type) {
		  
		  case 1:
		  /* Show normal information banner and this automatically goes away */
		  Banner.ShowInformation(this, null, "Hi there!");
		  break;

		  case 2:
		  /* Informaton banner with animation icon. This banner does not automatically disapear. */
		  banner = (Hildon.Banner) Banner.ShowAnimation(this, null, "This is animation icon");
		  break;

		  case 3:
		  /* Remove current information banner */
		  banner.Destroy();
		  break;

		  case 4:
		  /* Information banner with progressbar */
		  banner = (Hildon.Banner) Banner.ShowProgress (this, null, "Info with progress bar");
		  /* Set bar to be 20% full */
		  banner.Fraction = (double)0.2;
		  break;

		  case 5:
		  /* Set bar to be 80% full */
		  banner.Fraction = (double)0.8;
		  break;

		  case 6:
		  /* With sixth click, end the application */
		  Application.Quit();
		  break;
		  }

		  /* Increase the counter */
		  banner_type++;
	}
}
