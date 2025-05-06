// CircEffect.cs

using System;
using System.Numerics;
using Raylib_cs;

namespace Main;

class CircEffect
{
    // Properties
    public Vector2 pos;
    public double radius;
    public double maxRadius;
    public double minRadius;
    public double speed;
    public String mode;
    public Color color;
    public double alpha;

    // Constructor
    public CircEffect(Vector2 pos, int radius, int minRadius, int maxRadius, double speed, String mode, Color color, double alpha)
    {
        this.pos = pos;
        this.radius = radius;
        this.minRadius = minRadius;
        this.maxRadius = maxRadius;
        this.speed = speed;
        this.mode = mode;
        this.color = color;
        this.alpha = alpha;
    }

    // Update
    public void Update(double dt, List<CircEffect> circeffects)
    {
        // Explode
        if (mode == "Explode")
        {
            if (radius < maxRadius) 
            {
                radius += speed * dt; 
                alpha = 1.0 - ((radius - minRadius) / (maxRadius - minRadius));
            }
            else { circeffects.Remove(this);}
        }
        // Implode
        if (mode == "Implode")
        {
            if (radius > minRadius) 
            { 
                radius -= speed * dt; 
                alpha = (radius - minRadius) / (maxRadius - minRadius);
                alpha = Math.Max(0.0, Math.Min(1.0, alpha));
            }
            else { circeffects.Remove(this);}
        }
    }

    // Draw
    public void Draw()
    {
        // Draw itself
        Color fadedColor = Raylib.Fade(color, (float)alpha);
        Raylib.DrawCircle((int)pos.X, (int)pos.Y, (int)radius, fadedColor);
    }
}