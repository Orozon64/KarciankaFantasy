using Godot;
using System;
using System.Collections.Generic;

public class Monster{
	 
}
public partial class main_game_script : Node2D
{
	int round_number;
	int player_energy;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		round_number = 0;
		player_energy = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void EndTurn(){
		round_number++;
		player_energy = round_number;
	}
}
