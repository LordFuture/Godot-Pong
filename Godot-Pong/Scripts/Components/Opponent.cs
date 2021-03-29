using Godot;
using System;

public class Opponent : KinematicBody2D
{
    float opponentSpeed = 200.0f;
    KinematicBody2D ball = null;

    private float GetOpponentDirection(KinematicBody2D ball)
    { 
        if((System.Math.Abs(ball.Position.y - Position.y)) > 25)
        {
            if(ball.Position.y > Position.y)
            {
                return 1.0f;
            }
            return -1.0f;
        }
        return 0.0f;
    }
    public override void _Ready()
    {
        ball = GetParent().FindNode("Ball") as KinematicBody2D;
    }
    public override void _PhysicsProcess(float delta)
    {
        MoveAndSlide(new Vector2(0.0f, (GetOpponentDirection(ball) * opponentSpeed)));
    }
}