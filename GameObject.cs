// GameObject.cs

using System;
using System.Numerics;
using Main;
using Raylib_cs;

namespace KatchIt;

// Class to hold objects
class GameObject
{
    // Circle Effects
    public static List<CircEffect> circeffects = new List<CircEffect>();

    // Text Effects
    public static List<TextEffect> texteffects = new List<TextEffect>();

    // Bowl of the Player
    public static Player player = 
    new Player( new Bowl(new Vector2(Window.Width/2, Window.Height-20), new Vector2(100, 10), 50, Color.Brown), 0);

    // Food List
    public static List<Food> foodList = new List<Food>();
}