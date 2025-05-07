// Food.cs

using System;
using System.Numerics;
using Main;
using Raylib_cs;

namespace KatchIt;

class Food
{
    // Shapes: Circle, Rectangle
    // Properties
    public Vector2 pos;
    public String shape;
    public Vector2 size;
    public Color color;
    public double angle;
    public int rSpeed; // Rotation Speed
    private static int downSpeed = 10;
    public double velY = 0;
    private static int maxDownSpeed = 300;
    private static int scoreToPlayer = 10;

    // Constructor
    public Food(Vector2 pos, Vector2 size, String shape, Color color, int rSpeed)
    {
        this.pos = pos;
        this.size = size;
        this.shape = shape;
        this.color = color;
        this.rSpeed = rSpeed;
    }

    // Methods
    //----------------------------

    // Spawn Effects
    public void SpawnEffects()
    {
        GameObject.circeffects.Add(new CircEffect(pos, 1, 1, 50, 100, "Explode", color, 1));
        GameObject.texteffects.Add(new TextEffect(pos, Convert.ToString(scoreToPlayer), "+", 24, color, 50, -1, 0.01f));
    }

    // Check Collision
    public void CheckCollisionWithBowl(Bowl bowl, Player player)
    {
        // Rectangle Collision
        if (shape == "rect") 
        {
            if (pos.Y + size.Y/2 >= bowl.pos.Y && 
                pos.X > bowl.pos.X && 
                pos.X < bowl.pos.X + bowl.size.X) 
            { 
                // Hit Bowl
                GameObject.foodList.Remove(this); player.score += scoreToPlayer;
                SpawnEffects();
                
            }
            else if (pos.Y >= Window.Height) 
            {
                // Hit 'Ground'
                GameObject.foodList.Remove(this); player.attemptsLeft -= 1;
            } 
        }

        // Circle Collision
        else if (shape == "circle")
        {
            if (pos.Y + size.Y >= bowl.pos.Y && 
                pos.X > bowl.pos.X && 
                pos.X < bowl.pos.X + bowl.size.X) 
            {
                // Hit Bowl
                GameObject.foodList.Remove(this); player.score += 10;
                SpawnEffects();
            }
            else if (pos.Y >= Window.Height) 
            {
                // Hit 'Ground'
                GameObject.foodList.Remove(this); player.attemptsLeft -= 1;
            } 
        }
    }

    // Main Methods
    //----------------------------

    // Update
    public void Update(double dt, Bowl bowl, Player player)
    {
        // Down
        if (velY < maxDownSpeed) { velY += downSpeed * dt; }
        pos.Y += (float)velY;

        // Check Collision
        CheckCollisionWithBowl(bowl, player);

        // Rotate
        angle += rSpeed * dt;
    }

    // Draw
    public void Draw()
    {
        if (shape == "rect")
        {
            Raylib.DrawRectanglePro(
                new Rectangle(pos.X, pos.Y, size.X, size.Y), 
                new Vector2(size.X / 2, size.Y / 2),
                (float)angle, 
                color);
        }
        else if (shape == "circle")
        {
            Raylib.DrawCircleV(pos, size.X, color);
        }
    }

}