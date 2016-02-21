using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Strangelights;

namespace UserInterfacesCSharp
{
	public partial class FibForm_UsingFSharpLib : Form
	{
		public FibForm_UsingFSharpLib()
		{
			InitializeComponent();
		}

		private void calculate_Click(object sender, EventArgs e)
		{
			// convert input to an integer
			int n = Convert.ToInt32(input.Text);
			// calculate the appropriate fibonacci number
			// this part is from the FSharp libraries 
			// NOTE:
			n = Fibonacci.get(n);
			// display the result to the user 
			result.Text = n.ToString();
		}
	}
}
