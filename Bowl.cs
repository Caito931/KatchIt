// Bowl.cs

using System;
using System.Numerics;
using Raylib_cs;

namespace KatchIt;

class Bowl
{
    // Properties
    public Vector2 pos;
    public Vector2 size;
    public double speed;
    public Color color;
    public double velX;

    // Constructor
    public Bowl(Vector2 pos, Vector2 size, double speed, Color color)
    {
        this.pos = pos;
        this.size = size;
        this.speed = speed;
        this.color = color;
    }

    // Methods
    //----------------------------

    // Move
    public void Move(double dt)
    {
        float acceleration = (float)(speed * dt);
        float maxSpeed = (float)speed;
        float friction = 0.9f; // Or tune this closer to 1 for slower stop

        // Input handling
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            if(!(pos.X <= 0)) 
            {
                velX -= acceleration;
            }
        }
        else if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            if (!(pos.X + size.X >= Window.Width))
            {
                velX += acceleration;
            }
        }
        else
        {
            // Apply friction when no keys are pressed
            velX *= friction;

            // Stop tiny movement noise
            if (Math.Abs(velX) < 0.01f)
                velX = 0;
        }

        // Clamp speed to avoid infinite acceleration
        velX = Math.Clamp(velX, -maxSpeed, maxSpeed);

        // Apply movement
        pos.X += (float)velX;
    }

    // Keep in Bounds
    public void KeepInBounds()
    {
        // Check Left
        if (pos.X <=0) {pos.X = 0;}

        // Check Right
        if (pos.X + size.X >= Window.Width) { pos.X = Window.Width - size.X;}

    }

    // Main Methods
    //----------------------------

    // Update
    public void Update(double dt)
    {
        Move(dt);
        KeepInBounds();
    }

    // Draw
    public void Draw()
    {
        Raylib.DrawRectangleV(pos, size, color);
    }
}