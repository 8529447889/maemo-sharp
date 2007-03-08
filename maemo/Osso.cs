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
using System.Collections;
using System.Runtime.InteropServices;

namespace Osso
{
	public class Context
	{
		private static IntPtr osso_context;
		
		private Context ()
		{
			// Only to prevent instance.
		}

		[DllImport("libosso")]
		static extern IntPtr osso_initialize(IntPtr application, IntPtr version, bool activation, IntPtr context);
		
		public static void Initialize (string application, string version)
		{
			IntPtr new_application = GLib.Marshaller.StringToPtrGStrdup (application);
			IntPtr new_version     = GLib.Marshaller.StringToPtrGStrdup (version);
			osso_context = osso_initialize(new_application, new_version, true, IntPtr.Zero);
			GLib.Marshaller.Free (new_application);
			GLib.Marshaller.Free (new_version);
		}

		[DllImport("libosso")]
		static extern IntPtr osso_deinitialize(IntPtr osso);
		
		public static void Deinitialize ()
		{
			osso_deinitialize(osso_context);
		}
	}
}
