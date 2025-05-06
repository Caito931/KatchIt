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
        // Left
        if(Raylib.IsKeyDown(KeyboardKey.A)) { this.pos.X -= (float)(this.speed * dt); }
        // Right
        if(Raylib.IsKeyDown(KeyboardKey.D)) { this.pos.X += (float)(this.speed * dt); }
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