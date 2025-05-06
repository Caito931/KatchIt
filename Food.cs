// Food.cs

using System;
using System.Numerics;
using Raylib_cs;

namespace KatchIt;

class Food
{
    // Shapes: Triangle, Circle, Rectangle
    // Properties
    public Vector2 pos;
    public String shape;
    public Vector2 size;
    public Color color;
    public double angle;
    public int rSpeed; // Rotation Speed
    private static int downSpeed = 200;

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

    // Check Collision
    public void CheckCollisionWithBowl(Bowl bowl, Player player)
    {
        if (shape == "rect") 
        {
            if (pos.Y + size.Y/2 >= bowl.pos.Y && 
                pos.X > bowl.pos.X && 
                pos.X < bowl.pos.X + bowl.size.X) 
            { GameObject.foodList.Remove(this); player.score += 10;} // Hit Bowl
            else if (pos.Y >= Window.Height) { GameObject.foodList.Remove(this); player.attemptsLeft -= 1;} // Hit 'Ground'
        }
        else if (shape == "circle")
        {
            if (pos.Y + size.Y >= bowl.pos.Y && 
                pos.X > bowl.pos.X && 
                pos.X < bowl.pos.X + bowl.size.X) 
            { GameObject.foodList.Remove(this); player.score += 10;} // Hit Bowl
            else if (pos.Y >= Window.Height) { GameObject.foodList.Remove(this); player.attemptsLeft -= 1;} // Hit 'Ground'
        }
    }

    // Main Methods
    //----------------------------

    // Update
    public void Update(double dt, Bowl bowl, Player player)
    {
        // Down
        pos.Y += downSpeed * (float)dt;

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