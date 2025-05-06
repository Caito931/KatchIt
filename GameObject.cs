// GameObject.cs

using System;
using System.Numerics;
using Raylib_cs;

namespace KatchIt;

// Class to hold objects
class GameObject
{

    // Bowl of the Player
    public static Player player = 
    new Player( new Bowl(new Vector2(Window.Width/2, Window.Height-20), new Vector2(100, 10), 400, Color.Brown), 0);

    // Food List
    public static List<Food> foodList = new List<Food>();
}