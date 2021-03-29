using Godot;
using System;

public class Player : KinematicBody2D
{
    float playerSpeed = 400.0f;
    public override void _PhysicsProcess(float delta)
    {
        Vector2 playerVelocity = Vector2.Zero;
        if(Input.IsActionPressed("ui_up"))
        {
            playerVelocity.y -= 1;
        }
        if(Input.IsActionPressed("ui_down"))
        {
            playerVelocity.y += 1;
        }

        MoveAndSlide(playerVelocity * playerSpeed);
    }
}
