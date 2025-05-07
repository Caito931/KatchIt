// Player.cs

using System;
using System.Numerics;
using Raylib_cs;

namespace KatchIt;

class Player
{
    // Properties
    public Bowl bowl;
    public int score;
    public int attemptsLeft = 7;

    // Constructor
    public Player(Bowl bowl, int score)
    {
        this.bowl = bowl;
        this.score = score;
    }

    // Main Methods
    //----------------------------

    // Update
    public void Update(double dt)
    {
        // Bowl
        this.bowl.Update(dt);

        // Gameover ( make bool later )
        if (this.attemptsLeft <= 0) { Raylib.CloseWindow();} // TODO change
    }

    // Draw
    public void Draw()
    {
        // Bowl
        this.bowl.Draw();

        // Attempts & Score
        Raylib.DrawText($"Left:{Convert.ToString(this.attemptsLeft)}", 5, 0, 24, Color.Brown);
        Raylib.DrawText("Score:", Window.Width-150, 0, 24, Color.Brown);
        Raylib.DrawText(Convert.ToString(this.score), Window.Width-75+5, 0, 25, Color.Green);
    }
}