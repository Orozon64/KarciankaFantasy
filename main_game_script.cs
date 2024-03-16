using Godot;
using System;
using System.Collections.Generic;


public partial class main_game_script : Node2D
{
	int round_number;
	int player_energy;
	Label message;
	int ID_of_last_unit = 0; //the ID of the last unit that entered the game.
	int ATK_of_current_unit;
	int HP_of_current_unit;

	int HP_of_targeted_unit;
	Vector2 pos_of_current_unit;
	bool is_current_unit_attacking = false;

	int number_of_players = 1; //temporary solution, ofc. will change that later.
	Vector2 pos_of_targeted_unit;

	[Signal]
	public delegate void NewUnitEnteredEventHandler(int id);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		round_number = 0;
		player_energy = 0;
		GetNode<Label>("EnergyLabel").Text = "Your energy is: " + player_energy.ToString();
		EmitSignal(SignalName.SendPlayerNumToMonster, number_of_players);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("AttackClick"))
		{ //In the future, we should get the coords of the targeted unit here.
			if(Math.Sqrt(Math.Pow(pos_of_current_unit.X - pos_of_targeted_unit.X, 2) + Math.Pow(pos_of_current_unit.Y - pos_of_targeted_unit.Y, 2)) <= 57 && is_current_unit_attacking){
				//Time to explain what I'm trying to do here. If the attacking unit is not too far away from the attcking unit(i.e. they are colliding), the attack is possible.
				//Maybe I should pass the node through the signal, then use "oncollisionwith" or smth for the current node?
				HP_of_targeted_unit -= ATK_of_current_unit;
			}
		}
		if(HP_of_targeted_unit == 0){
			GD.Print("I am dead!");
		}
	}
	public void EndRound(){
		round_number++;
		player_energy = round_number;
		GetNode<Label>("EnergyLabel").Text = "Your energy is: " + player_energy.ToString();
	}
	public void _on_base_unit_tree_entered(){
		ID_of_last_unit++;
		//set the unit's ID to ID_of_last_unit.
		//CREATE A NEW SIGNAL CALLED "NEW UNIT CREATED" WITH "ID" PARAMETER, CONNECT IT TO BASE UNIT.
		EmitSignal(SignalName.NewUnitEntered, ID_of_last_unit);
	}

	public void _on_base_unit_unit_activated(int unit_atk, int unit_hp, Vector2 unit_pos){
		ATK_of_current_unit = unit_atk;
		HP_of_current_unit = unit_hp;
		pos_of_current_unit = unit_pos;
		
		//when a unit attacks, we'll check its atk value and subtract it from the hp of the attacked unit.
		//jfc i need to write better documentation. in something like a game i can't keep everything in my head. 
	}
	public void _on_base_unit_enter_attack_mode(bool is_attacking){
		is_current_unit_attacking = is_attacking;
	}
	public void _on_dragon_monster_activated(int monsterHP, Vector2 MonsterPosition){
		HP_of_targeted_unit = monsterHP; //not activated, TARGETTED, AAAAAAAA
		pos_of_targeted_unit = MonsterPosition;
	}
	[Signal]
	public delegate void SendPlayerNumToMonsterEventHandler(int playernum);
}
