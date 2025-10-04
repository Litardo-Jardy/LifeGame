using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;

using MyGame.Core;

class Program {
   static void Main(string[] args) 
   {
      var nativeSettings = new NativeWindowSettings()
      {
        Size = new Vector2i(900,600),
	Location = new Vector2i(100, 100),
	Title = "Juego de la vida",

        API = ContextAPI.OpenGL,
        Profile = ContextProfile.Compatability, 
        APIVersion = new Version(3, 3),

      };

      using var window = new Window(GameWindowSettings.Default, nativeSettings);
      window.Run();
   }
}
