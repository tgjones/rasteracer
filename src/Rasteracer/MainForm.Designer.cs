namespace Rasteracer
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.spcSplitContainer = new System.Windows.Forms.SplitContainer();
			this.rayTracingControl1 = new RayTracingControl();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnRenderMethodAutomatic = new System.Windows.Forms.ToolStripButton();
			this.btnRenderMethodRayTracing = new System.Windows.Forms.ToolStripButton();
			this.btnRenderMethodXna = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnMouseModePan = new System.Windows.Forms.ToolStripButton();
			this.btnMouseModeArcBall = new System.Windows.Forms.ToolStripButton();
			this.spcSplitContainer.Panel1.SuspendLayout();
			this.spcSplitContainer.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// spcSplitContainer
			// 
			this.spcSplitContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.spcSplitContainer.Location = new System.Drawing.Point(0, 28);
			this.spcSplitContainer.Name = "spcSplitContainer";
			// 
			// spcSplitContainer.Panel1
			// 
			this.spcSplitContainer.Panel1.Controls.Add(this.rayTracingControl1);
			this.spcSplitContainer.Size = new System.Drawing.Size(784, 536);
			this.spcSplitContainer.SplitterDistance = 755;
			this.spcSplitContainer.TabIndex = 0;
			// 
			// rayTracingControl1
			// 
			this.rayTracingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rayTracingControl1.Location = new System.Drawing.Point(0, 0);
			this.rayTracingControl1.Name = "rayTracingControl1";
			this.rayTracingControl1.RenderMethod = RenderMethod.Automatic;
			this.rayTracingControl1.Size = new System.Drawing.Size(755, 536);
			this.rayTracingControl1.TabIndex = 0;
			this.rayTracingControl1.Text = "rayTracingControl1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRenderMethodAutomatic,
            this.btnRenderMethodRayTracing,
            this.btnRenderMethodXna,
            this.toolStripSeparator1,
            this.btnMouseModePan,
            this.btnMouseModeArcBall});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(784, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnRenderMethodAutomatic
			// 
			this.btnRenderMethodAutomatic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRenderMethodAutomatic.Image = ((System.Drawing.Image) (resources.GetObject("btnRenderMethodAutomatic.Image")));
			this.btnRenderMethodAutomatic.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRenderMethodAutomatic.Name = "btnRenderMethodAutomatic";
			this.btnRenderMethodAutomatic.Size = new System.Drawing.Size(67, 22);
			this.btnRenderMethodAutomatic.Text = "Automatic";
			this.btnRenderMethodAutomatic.Click += new System.EventHandler(this.btnRenderMethodAutomatic_Click);
			// 
			// btnRenderMethodRayTracing
			// 
			this.btnRenderMethodRayTracing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRenderMethodRayTracing.Image = ((System.Drawing.Image) (resources.GetObject("btnRenderMethodRayTracing.Image")));
			this.btnRenderMethodRayTracing.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRenderMethodRayTracing.Name = "btnRenderMethodRayTracing";
			this.btnRenderMethodRayTracing.Size = new System.Drawing.Size(73, 22);
			this.btnRenderMethodRayTracing.Text = "Ray Tracing";
			this.btnRenderMethodRayTracing.Click += new System.EventHandler(this.btnRenderMethodRayTracing_Click);
			// 
			// btnRenderMethodXna
			// 
			this.btnRenderMethodXna.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRenderMethodXna.Image = ((System.Drawing.Image) (resources.GetObject("btnRenderMethodXna.Image")));
			this.btnRenderMethodXna.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRenderMethodXna.Name = "btnRenderMethodXna";
			this.btnRenderMethodXna.Size = new System.Drawing.Size(35, 22);
			this.btnRenderMethodXna.Text = "XNA";
			this.btnRenderMethodXna.Click += new System.EventHandler(this.btnRenderMethodXna_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnMouseModePan
			// 
			this.btnMouseModePan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnMouseModePan.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMouseModePan.Name = "btnMouseModePan";
			this.btnMouseModePan.Size = new System.Drawing.Size(31, 22);
			this.btnMouseModePan.Text = "Pan";
			this.btnMouseModePan.Click += new System.EventHandler(this.btnMouseModePan_Click);
			// 
			// btnMouseModeArcBall
			// 
			this.btnMouseModeArcBall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnMouseModeArcBall.Image = ((System.Drawing.Image) (resources.GetObject("btnMouseModeArcBall.Image")));
			this.btnMouseModeArcBall.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMouseModeArcBall.Name = "btnMouseModeArcBall";
			this.btnMouseModeArcBall.Size = new System.Drawing.Size(48, 22);
			this.btnMouseModeArcBall.Text = "ArcBall";
			this.btnMouseModeArcBall.Click += new System.EventHandler(this.btnMouseModeArcBall_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 564);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.spcSplitContainer);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ray Tracing";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.spcSplitContainer.Panel1.ResumeLayout(false);
			this.spcSplitContainer.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer spcSplitContainer;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnRenderMethodAutomatic;
		private System.Windows.Forms.ToolStripButton btnRenderMethodRayTracing;
		private System.Windows.Forms.ToolStripButton btnRenderMethodXna;
		private RayTracingControl rayTracingControl1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnMouseModePan;
		private System.Windows.Forms.ToolStripButton btnMouseModeArcBall;
	}
}