using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	
	private void _on_area_2d_area_entered(Area2D area)
	{
		// Win
		if(area.IsInGroup("Win"))
		{
			GD.Print("Win");
			GetTree().Quit();
		}
		
		// Die
		if(area.IsInGroup("DeathBox"))
		{
			GD.Print("Dead");
			GetTree().Quit();
		}
		
		// Teleport
		if(area.IsInGroup("Portal_0"))
		{
			Position = new Vector2(1830, 576);
		}
		
		if(area.IsInGroup("Portal_1"))
		{
			Position = new Vector2(3535, 800);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float inputX = Input.GetAxis("move_left", "move_right");
		Vector2 direction = new Vector2(inputX, 0);
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
