// Program.cs

using System;
using System.Numerics;
using Main;
using Raylib_cs;

namespace KatchIt;

class Program
{
    // Random
    private static Random random = new Random();

    public static void Main()
    {
        // Window
        Raylib.InitWindow(Window.Width, Window.Height, "Katch It!");
        Raylib.SetTargetFPS(60);

        // Possible Colors
        List<Color> Pcolor = new List<Color>();
        Pcolor.Add(Color.Yellow);
        Pcolor.Add(Color.Green);
        Pcolor.Add(Color.Gray);
        Pcolor.Add(Color.Red);

        // Timer && mode
        float MaxFoodTimer = 1.5f;
        float FoodTimer = 0.0f;
        char mode = 'r'; // rectangle or circle

        // Loop
        while(!Raylib.WindowShouldClose())
        {
            // Update
            double dt = Raylib.GetFrameTime();

            // Timer
            if (FoodTimer > 0) { FoodTimer -= (float)dt;}
            // Add
            else if (FoodTimer <= 0) 
            { 
                // Rectangle
                if (mode == 'r') 
                {
                    FoodTimer = MaxFoodTimer; 
                    GameObject.foodList.Add(
                        new Food(
                        new Vector2(random.Next(25, Window.Width-25), 0), 
                        new Vector2(25, 25), 
                        "rect", Pcolor[random.Next(0, Pcolor.Count)], 200
                    ));
                    mode = 'c';
                }
                // Circle
                else if (mode == 'c')
                {
                    FoodTimer = MaxFoodTimer; 
                    GameObject.foodList.Add(
                        new Food(
                        new Vector2(random.Next(12, Window.Width-12), 0), 
                        new Vector2(12, 0), 
                        "circle", Pcolor[random.Next(0, Pcolor.Count)], 200
                    ));
                    mode = 'r';
                }

                // difficulty
                if (MaxFoodTimer > 0.5f) { MaxFoodTimer -= 0.025f;} 
            }

            // Objects

            GameObject.player.Update(dt);

            for (int i = GameObject.foodList.Count() - 1; i >= 0; i--)
            {
                GameObject.foodList[i].Update(dt, GameObject.player.bowl, GameObject.player);
            }

            for (int i = GameObject.circeffects.Count() - 1; i >= 0; i--)
            {
                GameObject.circeffects[i].Update(dt, GameObject.circeffects);
            }

            // Draw
            Raylib.BeginDrawing();
                // TODO
                Raylib.ClearBackground(Color.RayWhite);
                GameObject.player.Draw();
                foreach (Food f in GameObject.foodList) { f.Draw(); }
                foreach (CircEffect ce in GameObject.circeffects) { ce.Draw(); }
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}

// Window Properties
public class Window
{
    public static int Width = 600;
    public static int Height = 600;
}