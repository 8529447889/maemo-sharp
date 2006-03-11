//
// Maemo# - Maemo bindings for Mono
//
// Author: 
//   Everaldo Canuto <everaldo@bananacrew.com>
//
// (C) 2006 BananaCrew Limited
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

public class HelloWorld : Hildon.App
{
	public static void Main (string[] args)
	{
		Application.Init ();
		new HelloWorld ();
		Application.Run ();
	}

	public HelloWorld ()
	{
		this.AppTitle = "Hildon# Sample";
		this.Appview  = new AppView("");
		this.DeleteEvent += new DeleteEventHandler (OnMyWindowDelete);

		Label label = new Label("Hello World!");
		this.Appview.Add (label);

		this.ShowAll ();
	}
	
	protected void OnMyWindowDelete (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
