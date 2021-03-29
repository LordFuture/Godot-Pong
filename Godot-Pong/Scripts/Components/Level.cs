using Godot;
using System;

public class Level : Node
{
    const float PositionStartX = 640.0f;
    const float PositionStartY = 360.0f;
    KinematicBody2D currentBall = null;

    private void RelaunchBall()
    {
        foreach(Node child in GetChildren())
        {
             if(child.Name.ToUpper() == "BALL")   
             {
                if(child.HasMethod("LaunchBall"))
                {
                    child.Call("LaunchBall");
                }
             }
        }
    }
    
    private void _on_WallLeft_body_entered(Node body)
    {
        currentBall.Position = new Vector2(PositionStartX, PositionStartY);
        RelaunchBall();
    }

    private void _on_WallRight_body_entered(Node body)
    {
        currentBall.Position = new Vector2(PositionStartX, PositionStartY);
        RelaunchBall();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        currentBall = GetNode<KinematicBody2D>("Ball");
    }
}