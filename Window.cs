
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

//Un buffer es como un contenedor en memoria.
//El VBO → contiene los vértices.
//El VAO → contiene instrucciones de cómo la GPU debe leer esos vértices.

class Window : GameWindow
{
   
    private int _vao;
    private int _vbo;
    private int _shaderProgram;
    List<Humans> listHumans = new List<Humans>();

    public Window(GameWindowSettings gws, NativeWindowSettings nws)
        : base(gws, nws)
    { }

    protected override void OnLoad()
    { 
      base.OnLoad();
      GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);

      float[] _vertices = {
            //   X      Y     Z
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.5f,  0.5f, 0.0f,
             0.5f,  0.5f, 0.0f,
            -0.5f,  0.5f, 0.0f,
            -0.5f, -0.5f, 0.0f
        };

      _vao = GL.GenVertexArray();
      GL.BindVertexArray(_vao);

      _vbo = GL.GenBuffer();
      GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
      GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

      //Shadears
      string vertexShaderSrc = @"
        #version 330 core
        layout (location = 0) in vec2 aPos;

        uniform mat4 transform; 

        void main()
         {
          gl_Position = transform * vec4(aPos, 0.0, 1.0);
         }";

        string fragmentShaderSrc = @"
        #version 330 core
        out vec4 FragColor;
	uniform vec3 uColor;
        void main()
        {
            FragColor = vec4(uColor, 1.0); 

        }";

       int vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, vertexShaderSrc);
        GL.CompileShader(vertexShader);

        int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, fragmentShaderSrc);
        GL.CompileShader(fragmentShader);

        _shaderProgram = GL.CreateProgram();
        GL.AttachShader(_shaderProgram, vertexShader);
        GL.AttachShader(_shaderProgram, fragmentShader);
        GL.LinkProgram(_shaderProgram);

        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);
      
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        // Inicializacion de la matriz 
        
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.UseProgram(_shaderProgram);
        GL.BindVertexArray(_vao);
  
        int transformLoc = GL.GetUniformLocation(_shaderProgram, "transform");
  
        float posX = -1.0f + 0.01f; 
        float posY = 1.0f - 0.015f; 
  
        float scaleX = 0.02f;
        float scaleY = 0.03f; 
  
        float spacing = scaleX * 1.0f;
  
        for(int y = 0; y < 50; y++)
        {
          for(int x = 0; x < 50; x++)
  	{
           var transform = Matrix4.CreateScale(scaleX, scaleY, 1.0f) * Matrix4.CreateTranslation(posX, posY, 0.0f);
  
           string ID = x.ToString() + y.ToString();
           Vector3 color = new Vector3(1.0f, 1.0f, 1.0f);
           int colorLoc = GL.GetUniformLocation(_shaderProgram, "uColor");
           Humans human = new Humans(x, y, ID, false, transform, transformLoc, color, colorLoc); 
  
  	   listHumans.Add(human);
           posX += spacing;
  	} 
  	 posY -= spacing;
  	 posX = -1.0f + 0.01f; 
        }
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    { 
      base.OnUpdateFrame(e);
      if (KeyboardState.IsKeyDown(Keys.C))
      {
        Close(); 
      }

      Vector3 colorDead = new Vector3(1.0f, 1.0f, 1.0f);
      Vector3 colorAlive = new Vector3(0.0f, 0.0f, 0.0f);

      for(int i = 0; i < listHumans.Count; i++)
      { 
	var human = listHumans[i];
        int[] counts = human.changeColor(listHumans);

	if (human.status == false && counts[1] == 3){//Nacimiento
           human.status = true;
	   human.Color = colorAlive;
	}else if (human.status == true && counts[1] > 3) //Muerte por sobrepoblacion
	{
           human.status = false;
	   human.Color = colorDead;
	}else if (human.status == true && counts[1] < 2)//Muerte por soledad 
 	{
           human.status = false;
	   human.Color = colorDead;
	}else if (human.status == true && counts[1] > 1 && counts[1] < 4)//Supervivencia
	{
           human.status = true;
	   human.Color = colorAlive;
	}
      }

    }

    protected override void OnRenderFrame(FrameEventArgs e)
    { 
      base.OnRenderFrame(e);

      GL.Clear(ClearBufferMask.ColorBufferBit);

      GL.UseProgram(_shaderProgram);
      GL.BindVertexArray(_vao);

      foreach(var human in listHumans)
      {
	var transform = human.Transform;

	if (human.id == "2020" || human.id == "1240" || human.id == "3030")
	{
          GL.UniformMatrix4(human.transformLoc, true, ref transform);
          Vector3 colorAlive = new Vector3(0.0f, 0.0f, 0.0f);
          GL.Uniform3(human.colorLoc, colorAlive);
	}else{
          GL.UniformMatrix4(human.transformLoc, false, ref transform);
          GL.Uniform3(human.colorLoc, human.Color);}
        GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
      }

    SwapBuffers();   
    }

    protected override void OnUnload()
    {}
}

