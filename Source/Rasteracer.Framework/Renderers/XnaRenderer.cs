using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using TJ.RayTracing.Framework.Lights;
using TJ.RayTracing.Framework.Primitives;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Cameras;
using Microsoft.Xna.Framework.Content;
using TJ.RayTracing.Framework.Materials;

namespace TJ.RayTracing.Framework.Renderers
{
	public class XnaRenderer : Renderer
	{
		private Effect _effect;

		public XnaRenderer(ContentManager contentManager, GraphicsDevice graphicsDevice, Scene scene, Camera camera)
			: base(graphicsDevice, scene, camera)
		{
			// We need to compile the effect here, rather than letting the Content Pipeline handle it,
			// because only at this stage do we know what the preprocessor define's need to be,
			// i.e. the number of lights.
			CompiledEffect compiledEffect = Effect.CompileEffectFromFile(@"Content\Effects\BasicEffect.fx",
				new CompilerMacro[] { new CompilerMacro { Name = "NumLights", Definition = "3" } },
				null, CompilerOptions.None, TargetPlatform.Windows);
			_effect = new Effect(GraphicsDevice, compiledEffect.GetEffectCode(), CompilerOptions.None, null);
		}

		public override void Draw()
		{
			GraphicsDevice.RenderState.DepthBufferEnable = true;

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

				_effect.Begin();
				foreach (EffectPass effectPass in _effect.CurrentTechnique.Passes)
				{
					effectPass.Begin();

					foreach (ModelMesh mesh in primitive.Model.Meshes)
					{
						foreach (ModelMeshPart meshPart in mesh.MeshParts)
						{
							GraphicsDevice.VertexDeclaration = meshPart.VertexDeclaration;
							GraphicsDevice.Vertices[0].SetSource(mesh.VertexBuffer,
								meshPart.StreamOffset, meshPart.VertexStride);
							GraphicsDevice.Indices = mesh.IndexBuffer;
							GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList,
								meshPart.BaseVertex, 0, meshPart.NumVertices,
								meshPart.StartIndex, meshPart.PrimitiveCount);
						}
					}

					effectPass.End();
				}
				_effect.End();
			}
		}
	}
}
