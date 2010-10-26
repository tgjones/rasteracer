using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Rasteracer.Framework.Cameras;
using Rasteracer.Framework.Lights;
using Rasteracer.Framework.Materials;

namespace Rasteracer.Framework.Renderers
{
	public class XnaRenderer : Renderer
	{
		private Effect _effect;

		public XnaRenderer(ContentManager contentManager, GraphicsDevice graphicsDevice, Scene scene, Camera camera)
			: base(graphicsDevice, scene, camera)
		{
			_effect = contentManager.Load<Effect>(@"Effects\BasicEffect");
		}

		public override void Draw()
		{
			GraphicsDevice.DepthStencilState = DepthStencilState.Default;

			// handle point lights
			PointLight[] pointLights = Scene.Lights.OfType<PointLight>().ToArray();
			for (int i = 0; i < pointLights.Length; i++)
			{
				_effect.Parameters["PointLights"].Elements[i].StructureMembers["Colour"].SetValue(pointLights[i].Colour.ToColor().ToVector3());
				_effect.Parameters["PointLights"].Elements[i].StructureMembers["Location"].SetValue(pointLights[i].Location);
			}

			foreach (IXnaDrawable primitive in Scene.Primitives.OfType<IXnaDrawable>())
			{
				_effect.Parameters["World"].SetValue(primitive.World);
				_effect.Parameters["ViewProjection"].SetValue(Camera.View * Camera.Projection);

				if (primitive.Material is CheckerboardMaterial)
				{
					_effect.Parameters["CheckerboardMaterial"].StructureMembers["Colour"].SetValue(primitive.Material.Colour.ToColor().ToVector3());
					_effect.Parameters["CheckerboardMaterial"].StructureMembers["AlternateColour"].SetValue(((CheckerboardMaterial) primitive.Material).AlternateColour.ToColor().ToVector3());
					_effect.CurrentTechnique = _effect.Techniques["TechniqueCheckerboardMaterial"];
				}
				else if (primitive.Material is Material)
				{
					_effect.Parameters["Material"].StructureMembers["Colour"].SetValue(primitive.Material.Colour.ToColor().ToVector3());
					_effect.CurrentTechnique = _effect.Techniques["TechniqueMaterial"];
				}
				else
				{
					throw new NotImplementedException();
				}

				foreach (EffectPass effectPass in _effect.CurrentTechnique.Passes)
				{
					effectPass.Apply();

					foreach (ModelMesh mesh in primitive.Model.Meshes)
					{
						foreach (ModelMeshPart meshPart in mesh.MeshParts)
						{
							GraphicsDevice.SetVertexBuffer(meshPart.VertexBuffer, meshPart.VertexOffset);
							GraphicsDevice.Indices = meshPart.IndexBuffer;
							GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList,
								meshPart.VertexOffset, 0, meshPart.NumVertices,
								meshPart.StartIndex, meshPart.PrimitiveCount);
						}
					}
				}
			}
		}
	}
}
