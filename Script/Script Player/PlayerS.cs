using Godot;
using System;

public class PlayerS : KinematicBody2D
{
	string name = "Jose Juan";
	int HP = 100;

	[Export] int speed = 100; 
	Vector2 velocity = new Vector2(0, 0);
	
	// Variable para recordar la última dirección
	private string _lastDirection = "down";
	private AnimatedSprite _anim;

	public override void _Ready()
	{
		// Asegúrate de que el nodo se llame AnimatedSprite en Godot
		_anim = GetNode<AnimatedSprite>("AnimatedSprite");
		Position = new Vector2(200, 200);  
	}

	public override void _PhysicsProcess(float delta)
	{
		velocity = Vector2.Zero; 
		string currentDir = ""; 

		// 1. Detectar movimiento (Tus acciones con Mayúscula)
		if (Input.IsActionPressed("Right")) { velocity.x += 1; currentDir = "right"; }
		else if (Input.IsActionPressed("Left")) { velocity.x -= 1; currentDir = "left"; }
		else if (Input.IsActionPressed("Up")) { velocity.y -= 1; currentDir = "up"; }
		else if (Input.IsActionPressed("Down")) { velocity.y += 1; currentDir = "down"; }

		// 2. Lógica de Animaciones y Movimiento
		if (velocity != Vector2.Zero)
		{
			_lastDirection = currentDir; 
			velocity = velocity.Normalized() * speed;

			if (Input.IsActionPressed("Run")) {
				velocity *= 2;
			}

			// Reproduce ej: "run right"
			_anim.Play("run " + _lastDirection);
		}
		else
		{
			// Reproduce ej: "idle down" cuando está quieto
			_anim.Play("idle " + _lastDirection);
		}

		// 3. Aplicar física
		velocity = MoveAndSlide(velocity); 
	}
} // <--- Esta es la llave que faltaba para cerrar la Clase
