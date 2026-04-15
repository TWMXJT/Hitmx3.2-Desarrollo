using Godot;

public class PlayerS : KinematicBody2D
{
    string name = "Jose Juan";
    int HP = 100;

    int speed = 3;

    Vector2 velocity = new Vector2(0, 0);

    public override void _Ready()
    {
      Position = new Vector2(1000,500);  
    }

    public override void _Process(float delta)
    {
        velocity.x = 0;
        velocity.y = 0;
        if (Input.IsActionPressed("Right"))
        {
            velocity.x += speed;
        }
        if (Input.IsActionPressed("Left"))
        {
            velocity.x -= speed;
        }
        if (Input.IsActionPressed("Up"))
        {
            velocity.y -= speed;
        }
        if (Input.IsActionPressed("Down"))
        {
            velocity.y += speed;
        }
        if (Input.IsActionPressed("Run"))
        {
            velocity *= speed;
        }
        Position += velocity;
    }
}