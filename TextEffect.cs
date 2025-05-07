// TextEffect.cs

using System;
using System.Numerics;
using KatchIt;
using Raylib_cs;

namespace Main;

class TextEffect
{
    // Properties
    public Vector2 pos;
    public String text;
    public int fontsize;
    public Color color;
    public String sign;
    public double speed;
    public int direction;
    public float multiplier;
    public float alpha = 1.0f;

    // Constructor
    public TextEffect(Vector2 pos, String text, String sign, int fontsize, Color color, double speed, int direction, float multiplier)
    {
        this.pos = pos;
        this.text = text;
        this.sign = sign;
        this.fontsize = fontsize;
        this.color = color;
        this.speed = speed;
        this.direction = direction;
        this.multiplier = multiplier;
    }

    // Main Methods
    //----------------------------

    // Update
    public void Update(double dt, List<TextEffect> texteffects)
    {
        // Position
        pos.Y += (float)speed * (float)dt * direction;
        
        // Alpha
        this.alpha -= (float)(speed * dt * multiplier);

        // Remove
        if (this.alpha <= 0f) { texteffects.Remove(this);}
    }

    // Draw
    public void Draw()
    {
        Color fadedColor = Raylib.Fade(color, alpha);
        Raylib.DrawTextEx(Raylib.GetFontDefault(), $"{sign}{text}", pos, fontsize, 1, fadedColor);
    }
}