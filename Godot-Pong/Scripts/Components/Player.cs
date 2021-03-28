using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    float speed = 400.0f;
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        Vector2 velocity = Vector2.Zero;
        if(Input.IsActionPressed("ui_up"))
        {
            velocity.y -= 1;
        }
        if(Input.IsActionPressed("ui_down"))
        {
            velocity.y += 1;
        }

        MoveAndSlide(velocity * speed);
    }
    
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
