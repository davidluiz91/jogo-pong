using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace pong
{
    class Program : GameWindow
    {
        int xDabola = 0;
        int yDabola = 0;
        int tamanhoDaBola = 20;
        int velocidadeDaBolaEmX = 3;
        int velocidadeDaBolaEmY = 3;

        int yDoJogador1 = 0;
        int yDoJogador2 = 0;

        int xDoJogador1()
        {
            return -ClientSize.Width / 2 + larguraDosJogadores() / 2;
        }

        int xDoJogador2()
        {
            return ClientSize.Width / 2 - larguraDosJogadores() / 2;

        }

        int larguraDosJogadores()
        {
            return tamanhoDaBola;
        }
        int alturaDosJogadores()
        {
            return 3 * tamanhoDaBola;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            xDabola = xDabola + velocidadeDaBolaEmX;
            yDabola = yDabola + velocidadeDaBolaEmY;


            if (xDabola + tamanhoDaBola / 2 > xDoJogador2() - larguraDosJogadores() / 2
                && yDabola - tamanhoDaBola / 2 < yDoJogador2 - larguraDosJogadores() / 2
                && yDabola + tamanhoDaBola / 2 > yDoJogador2 - alturaDosJogadores() / 2)
            {
                velocidadeDaBolaEmX = -velocidadeDaBolaEmX;
            }

            if (xDabola - tamanhoDaBola / 2 > xDoJogador1() + larguraDosJogadores() / 2
                && yDabola - tamanhoDaBola / 2 < yDoJogador1 + larguraDosJogadores() / 2
                && yDabola + tamanhoDaBola / 2 > yDoJogador1 - alturaDosJogadores() / 2)
            {
                velocidadeDaBolaEmX = -velocidadeDaBolaEmX;
            }

            if (yDabola + tamanhoDaBola / 2 > ClientSize.Height / 2)
            {
                velocidadeDaBolaEmY = -velocidadeDaBolaEmY;
            }

            if (yDabola - tamanhoDaBola / 2 < -ClientSize.Height / 2)
            {
                velocidadeDaBolaEmY = -velocidadeDaBolaEmY;
            }

            if (xDabola < -ClientSize.Width / 2 || xDabola > ClientSize.Width / 2)
            {
                xDabola = 0;
                yDabola = 0;

            }

            if (Keyboard.GetState().IsKeyDown(Key.W))
            {
                yDoJogador1 = yDoJogador1 + 5;
            }

            if (Keyboard.GetState().IsKeyDown(Key.S))
            {
                yDoJogador1 = yDoJogador1 - 5;
            }

            if (Keyboard.GetState().IsKeyDown(Key.Up))
            {
                yDoJogador2 = yDoJogador2 + 5;
            }

            if (Keyboard.GetState().IsKeyDown(Key.Down))
            {
                yDoJogador2 = yDoJogador2 - 5;
            }

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            Matrix4 projection = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 0.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            DesenharRetangulo(xDabola, yDabola, tamanhoDaBola, tamanhoDaBola, 1.0f, 1.0f, 0.0f);
            DesenharRetangulo(xDoJogador1(), yDoJogador1, larguraDosJogadores(), alturaDosJogadores(), 1.0f, 0.0f, 0.0f);
            DesenharRetangulo(xDoJogador2(), yDoJogador2, larguraDosJogadores(), alturaDosJogadores(), 0.0f, 0.0f, 1.0f);





            SwapBuffers();
        }

        void DesenharRetangulo(int x, int y, int largura, int altura, float r, float g, float b)
        {
            GL.Color3(r, g, b);


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
