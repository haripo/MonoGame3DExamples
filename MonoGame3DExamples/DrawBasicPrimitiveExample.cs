using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3DExamples
{
    class DrawBasicPrimitiveExample
    {
        private BasicEffect effect;
        private VertexPositionColor[] vertices;

        private BasicEffect CreateEffect(GraphicsDevice graphicsDevice)
        {
            var effect = new BasicEffect(graphicsDevice);
            effect.VertexColorEnabled = true;
            effect.View = Matrix.CreateLookAt(
                    new Vector3(0.0f, 2.0f, 2.0f),
                    Vector3.Zero,
                    Vector3.Up);
            effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                    MathHelper.PiOver4,
                    graphicsDevice.Viewport.AspectRatio,
                    1.0f,
                    100.0f);
            return effect;
        }

        private VertexPositionColor[] CreateVertices()
        {
            var vertices = new VertexPositionColor[3];
            vertices[0] = new VertexPositionColor(new Vector3(0, 0, 1), Color.Red);
            vertices[1] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Blue);
            vertices[2] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Green);
            return vertices;
        }

        public DrawBasicPrimitiveExample(Game game)
        {
            effect = CreateEffect(game.GraphicsDevice);
            vertices = CreateVertices();
        }

        public void Draw(GraphicsDevice graphicsDevice)
        {
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 1);
            }
        }
    }
}
