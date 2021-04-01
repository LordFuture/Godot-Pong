using Godot;
using System;

public class Ball : KinematicBody2D
{
    const float DefaultBallSpeed = 600.0f;
    float ballSpeed = DefaultBallSpeed;
    Vector2 ballVelocity = Vector2.Zero;

    int[] randomX = {-1, 1};
    float[] randomY = {-0.8f, 0.8f};
    private void RandomBallAngle()
    {
        ballVelocity.x = new int[]{-1, 1}[GD.Randi() % 2];
        ballVelocity.y = new float[]{-0.8f, 0.8f}[GD.Randi() % 2];
    }
    public override void _Ready()
    {
        GD.Randomize();
        RandomBallAngle();
    }
    public override void _PhysicsProcess(float delta)
    {
        KinematicCollision2D  ballCollisionObject = MoveAndCollide(ballVelocity * ballSpeed * delta);
        if(ballCollisionObject != null)
        {
            ballVelocity = ballVelocity.Bounce(ballCollisionObject.Normal);
        }
    }

    private void StopBall()
    {
        ballSpeed = 0.0f;
    }

    private void StartBall()
    {
        ballSpeed = DefaultBallSpeed;
        RandomBallAngle();
    }
}
