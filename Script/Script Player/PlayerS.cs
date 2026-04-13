using Godot;

public class PlayerS : KinematicBody2D
{
    string name = "Elvio Lado";
    int HP = 100;

    int speed = 10;

    Vector2 velocity = new Vector2(5, 5);

    public override void _Ready()
    {
        
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
        Position += velocity;
    }
}