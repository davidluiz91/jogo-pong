using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace pong
{
    internal class Program : GameWindow
    {
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            Matrix4 projection = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 0.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            DesenharRetangulo(0, 0, 20, 20);
            DesenharRetangulo(-310, 0, 20, 40);
            DesenharRetangulo(310, 0, 20, 40);



            SwapBuffers();
        }

        void DesenharRetangulo(int x, int y, int largura, int altura)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.5f * largura + x, -0.5f * altura + y);
            GL.Vertex2(0.5f * largura + x, -0.5f * altura + y);
            GL.Vertex2(0.5f * largura + x, 0.5f * altura + y);
            GL.Vertex2(-0.5f * largura + x, 0.5f * altura + y);
            GL.End();
        }


        static void Main()
        {
            new Program().Run();
        }
    }
}
