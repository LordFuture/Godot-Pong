using Godot;
using System;

public class Ball : KinematicBody2D
{
    float ballSpeed = 600.0f;
    Vector2 ballVelocity = Vector2.Zero;
    public override void _Ready()
    {
        GD.Randomize();
        int[] randomX = {-1, 1};
        float[] randomY = {-0.8f, 0.8f};

        ballVelocity.x = randomX[GD.Randi() % 2];
        ballVelocity.y = randomY[GD.Randi() % 2];
    }
    public override void _PhysicsProcess(float delta)
    {
        KinematicCollision2D  ballCollisionObject = MoveAndCollide(ballVelocity * ballSpeed * delta);
        if(ballCollisionObject != null)
        {
            ballVelocity = ballVelocity.Bounce(ballCollisionObject.Normal);
        }
    }
}
