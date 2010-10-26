using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Rasteracer.Framework.Cameras
{
	public class GuiCamera : Camera
	{
		protected const float ROTATION_SPEED = 0.01f;
		protected const float TRANSLATION_SPEED = 0.025f;
		protected const float PITCH_CLAMP_ANGLE = 90.0f - 0.1f;

		public Vector3 Position
		{
			get;
			set;
		}

		public Vector3 Target
		{
			get;
			set;
		}

		private UpdateHandler[] _updateHandlers;
		private int _activeUpdateHandler;

		public GuiCameraUpdateMode UpdateMode
		{
			get { return (GuiCameraUpdateMode) _activeUpdateHandler; }
			set { _activeUpdateHandler = (int) value; }
		}

		private MouseState _previousMouseState;

		public GuiCamera(GraphicsDevice graphicsDevice, IntPtr windowHandle, int windowWidth, int windowHeight)
			: base(graphicsDevice)
		{
			Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, windowWidth / (float) windowHeight, 0.1f, 1000.0f);

			Position = new Vector3(0, 5, 20);

			Target = Position + Vector3.Forward;
			View = Matrix.CreateLookAt(Position, Target, Vector3.Up);

			_updateHandlers = new UpdateHandler[2];
			_updateHandlers[0] = new PanUpdateHandler(this);
			_updateHandlers[1] = new ArcBallUpdateHandler(this);
			_activeUpdateHandler = 0;

			Mouse.WindowHandle = windowHandle;
			_previousMouseState = Mouse.GetState();
		}

		public bool Update()
		{
			MouseState currentMouseState = Mouse.GetState();

			bool updated = _updateHandlers[_activeUpdateHandler].Update(_previousMouseState, currentMouseState);

			View = Matrix.CreateLookAt(Position, Target, Vector3.Up);

			// move forward and backward
			if (currentMouseState.ScrollWheelValue - _previousMouseState.ScrollWheelValue != 0)
			{
				Vector3 direction = Vector3.Normalize(Target - Position);
				Vector3 tMovement = direction * TRANSLATION_SPEED * (currentMouseState.ScrollWheelValue - _previousMouseState.ScrollWheelValue);
				Position += tMovement;
				Target += tMovement;
				updated = true;
			}

			_previousMouseState = currentMouseState;

			return updated;
		}

		#region Update methods

		private abstract class UpdateHandler
		{
			protected GuiCamera Parent
			{
				get;
				private set;
			}

			public UpdateHandler(GuiCamera parent)
			{
				Parent = parent;
			}

			public virtual void Activate() { }
			public abstract bool Update(MouseState previousMouseState, MouseState currentMouseState);
		}

		private class PanUpdateHandler : UpdateHandler
		{
			public PanUpdateHandler(GuiCamera parent)
				: base(parent)
			{

			}

			public override bool Update(MouseState previousMouseState, MouseState currentMouseState)
			{
				bool updated = false;

				if (previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed)
				{
					Vector3 direction = Parent.Target - Parent.Position;

					// unproject screen-space mouse delta to get delta in world coordinates

					// get z position of world origin, in screen space
					Vector3 screenSpaceOrigin = Parent.GetProjectedPosition(Vector3.Zero);
					Vector3 previousMouseWorldPos = Parent.GetUnprojectedPosition(new Vector3(previousMouseState.X, previousMouseState.Y, screenSpaceOrigin.Z));
					Vector3 currentMouseWorldPos = Parent.GetUnprojectedPosition(new Vector3(currentMouseState.X, currentMouseState.Y, screenSpaceOrigin.Z));
					Vector3 worldDelta = currentMouseWorldPos - previousMouseWorldPos;
					Parent.Position -= worldDelta;

					Parent.Target = Parent.Position + direction;

					updated = true;
				}

				return updated;
			}
		}

		private class ArcBallUpdateHandler : UpdateHandler
		{
			public ArcBallUpdateHandler(GuiCamera parent)
				: base(parent)
			{

			}

			public override void Activate()
			{
				// get ray at centre of screen in world coordinates
				Ray worldScreenCentreRay = Parent.GetUnprojectedRay(
					Parent.GraphicsDevice.Viewport.Width / 2,
					Parent.GraphicsDevice.Viewport.Height / 2);

				Parent.Target = worldScreenCentreRay.Position + (worldScreenCentreRay.Direction * 5);
			}

			public override bool Update(MouseState previousMouseState, MouseState currentMouseState)
			{
				bool updated = false;

				if (previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed)
				{
					Point deltaMousePos = new Point(currentMouseState.X - previousMouseState.X, currentMouseState.Y - previousMouseState.Y);

					// Check for input to rotate the camera up and down around the model, and limit the arc movement.
					float pitch = -deltaMousePos.Y * ROTATION_SPEED;
					pitch = MathHelper.Clamp(pitch, -PITCH_CLAMP_ANGLE, PITCH_CLAMP_ANGLE);

					// Check for input to rotate the camera around the model.
					float yaw = deltaMousePos.X * ROTATION_SPEED;

					Matrix rotation = Matrix.CreateFromYawPitchRoll(yaw, pitch, 0);
					Vector3 dirFromTargetToPos = Parent.Position - Parent.Target;
					Vector3 rotatedDirFromTargetToPos = Vector3.Transform(dirFromTargetToPos, rotation);
					Parent.Position = Parent.Target + rotatedDirFromTargetToPos;

					updated = true;
				}

				return updated;
			}
		}

		#endregion
	}

	public enum GuiCameraUpdateMode
	{
		Pan,
		ArcBall
	}
}
