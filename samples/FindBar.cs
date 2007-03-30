//
// Maemo# - Maemo bindings for Mono
//
// Author: 
//   Everaldo Canuto <ecanuto@novell.com>
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

public class FindWindow : Hildon.Window
{
	FindToolbar findbar;
	Button button;
	
	public static void Main (string[] args)
	{
		Application.Init ("Maemo# FindToolbar", ref args);

		Program program = Program.Instance;
		program.AddWindow ( new FindWindow () );

		Application.Run ();
	}

	public FindWindow ()
	{
		this.Destroyed += delegate {Application.Quit ();};

		// Button		
		button = new Button ("Show FindToolbar");
		button.Clicked += new EventHandler (show_findbar);
		this.Add (button);
		
		this.ShowAll ();
	}
	
	protected void show_findbar (object source, EventArgs e)
	{
		if (findbar == null) {
			findbar = new FindToolbar ("Search:");
			findbar.Closed += new EventHandler (findbar_close);
			findbar.Search += new EventHandler (findbar_search);
			findbar.InvalidInput += new EventHandler (findbar_invalid_input);
			findbar.HistoryAppend += new EventHandler (findbar_history_append);
			this.AddToolbar (findbar);
		}
		findbar.Show ();
		button.Hide ();
	}
	
	protected void findbar_close (object obj, EventArgs args)
	{
		FindToolbar control = (FindToolbar) obj;
		Console.WriteLine ("close");
		button.Show ();
		findbar.Hide ();
	}
	
	protected void findbar_search (object obj, EventArgs args)
	{
		Console.WriteLine ("search");
	}

	protected void findbar_invalid_input (object obj, EventArgs args)
	{
		Console.WriteLine ("invalid input");
	}

	protected void findbar_history_append (object obj, EventArgs args)
	{
		Console.WriteLine ("history append");
	}
}
