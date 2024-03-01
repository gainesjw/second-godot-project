using Godot;
using System;

public partial class mob : Path2D
{
	[Export]
	public bool loop = true;
	
	[Export]
	public float speed = (float)2.0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var animation = GetNode<AnimationPlayer>("AnimationPlayer");
		animation.Play("new_animation");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var path = GetNode<PathFollow2D>("PathFollow2D");
		path.Progress += speed;
	}
}
