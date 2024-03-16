using Godot;
using System;

public partial class Monster : Area2D //inheritance should probably be used here, but for now, let's just stick with the base class for testing.
{
	[Signal]
	public delegate void MonsterActivatedEventHandler(int monsterHP, Vector2 monster_position);
	[Export]
	int hp_per_player = 20; //temporary solution, it will be set in the subclasses when I use inheritance (see above).
	int hp; //Will be set to hp_per_player * number of players.
	[Export]
	string name;
	public void _on_main_game_send_player_num_to_monster(int playernum){
		hp = hp_per_player * playernum;	
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		Vector2 MonsterPosition = GlobalPosition;
		EmitSignal(SignalName.MonsterActivated, hp, MonsterPosition);
	}
	//Soo turns out there's a class called inputevent handler, maybe we should replace the AttackClick action in main_game_script with this here...
	//I know my code is confusing, but don't worry - documentation is coming in n + 1 weeks :)

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void FireBreath(){

	}
	public void TailSwipe(){

	}
	
}
