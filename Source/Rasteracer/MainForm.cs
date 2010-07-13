using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using TJ.RayTracing.Framework;

namespace TJ.RayTracing
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void ChangeRenderMethod(RenderMethod renderMethod)
		{
			rayTracingControl1.RenderMethod = renderMethod;

			switch (renderMethod)
			{
				case RenderMethod.Automatic :
					btnRenderMethodAutomatic.Checked = true;
					btnRenderMethodRayTracing.Checked = false;
					btnRenderMethodXna.Checked = false;
					break;
				case RenderMethod.RayTracing:
					btnRenderMethodAutomatic.Checked = false;
					btnRenderMethodRayTracing.Checked = true;
					btnRenderMethodXna.Checked = false;
					break;
				case RenderMethod.Xna:
					btnRenderMethodAutomatic.Checked = false;
					btnRenderMethodRayTracing.Checked = false;
					btnRenderMethodXna.Checked = true;
					break;
			}
		}

		private void btnRenderMethodAutomatic_Click(object sender, EventArgs e)
		{
			ChangeRenderMethod(RenderMethod.Automatic);
		}

		private void btnRenderMethodRayTracing_Click(object sender, EventArgs e)
		{
			ChangeRenderMethod(RenderMethod.RayTracing);
		}

		private void btnRenderMethodXna_Click(object sender, EventArgs e)
		{
			ChangeRenderMethod(RenderMethod.Xna);
		}

		private void ChangeMouseMode(MouseMode mouseMode)
		{
			rayTracingControl1.MouseMode = mouseMode;

			switch (mouseMode)
			{
				case MouseMode.Pan :
					btnMouseModePan.Checked = true;
					btnMouseModeArcBall.Checked = false;
					break;
				case MouseMode.ArcBall:
					btnMouseModePan.Checked = false;
					btnMouseModeArcBall.Checked = true;
					break;
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			ChangeRenderMethod(RenderMethod.Automatic);
			ChangeMouseMode(MouseMode.Pan);
		}

		private void btnMouseModePan_Click(object sender, EventArgs e)
		{
			ChangeMouseMode(MouseMode.Pan);
		}

		private void btnMouseModeArcBall_Click(object sender, EventArgs e)
		{
			ChangeMouseMode(MouseMode.ArcBall);
		}
	}

	public enum RenderMethod
	{
		Automatic,
		RayTracing,
		Xna
	}

	public enum MouseMode
	{
		Pan,
		ArcBall
	}
}
