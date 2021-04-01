using Godot;
using System;

public class Level : Node
{
    const float PositionStartX = 640.0f;
    const float PositionStartY = 360.0f;

    KinematicBody2D currentBall = null;
    Timer timer = null;

    Label playerScoreLabel = null;
    Label opponentScoreLabel = null;

    Label countdownLabel = null;

    int playerScore = 0;
    int opponentScore = 0;

    string ballGroup = "BallGroup";
    string ballGroupMethodStop = "StopBall";
    string ballGroupMethodStart = "StartBall";
    
    private void _on_WallLeft_body_entered(Node body)
    {
        opponentScore++;
        ScoreAchieved();
    }

    private void _on_WallRight_body_entered(Node body)
    {
        playerScore++;
        ScoreAchieved();
    }

    private void ScoreAchieved()
    {
        currentBall.Position = new Vector2(PositionStartX, PositionStartY);
        GetTree().CallGroup(ballGroup, ballGroupMethodStop);
        timer.Start();
        countdownLabel.Visible = true;
    }

    private void _on_CountdownTimer_timeout()
    {
        GetTree().CallGroup(ballGroup, ballGroupMethodStart);
        countdownLabel.Visible = false;
    }
    public override void _Ready()
    {
        currentBall = GetNode<KinematicBody2D>("Ball");
        playerScoreLabel = GetNode<Label>("PlayerScore");
        opponentScoreLabel = GetNode<Label>("OpponentScore");
        timer = GetNode<Timer>("CountdownTimer");
        countdownLabel = GetNode<Label>("CountdownTimerLabel");
        countdownLabel.Visible = false;
    }

    public override void _Process(float delta)
    {
        playerScoreLabel.Text = playerScore.ToString();
        opponentScoreLabel.Text = opponentScore.ToString();
        countdownLabel.Text = Convert.ToString(Convert.ToInt32(timer.TimeLeft));
    }
}