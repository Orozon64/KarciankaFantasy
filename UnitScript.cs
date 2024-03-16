using Godot;
using System;
using System.Collections.Generic;
public partial class UnitScript : Area2D
{
	int UnitID;
	[Export] //I'll be adjusting this in the editor to test various cards.
	bool is_active = true; //TEMPORARY SOLUTION FOR ATTACK SYSTEM TESTS. Will be set to false in the final version.
	bool is_attacking = false;
	int id; //this will be set when the unit is created. The ID of the last card will be in the main_game script.
	//The IDs will be used for collision detection (trust me, this makes sense. let me cook!)
	List<int> colliderIDs = new List<int>(); //a list of the IDs of all units this unit's colliding with.

	//here comes a small sense of deja vu ;)
	[Export]
	int HP = 1; //maaybe let's not have a situation where the unit dies right when the game starts, and I feel sheer frustration and confusion??

	[Export] //if you're wondering, this lets me edit the variable directly in Godot's editor.
	int cost;
	[Export]
	string name;
	[Export]
	string category;
	[Export] 
	int attack;
	[Export]
	string faction;
	[Export]
	string tag1;
	[Export]
	string tag2;
	[Export]
	string tag3;
	[Export]
	string ability1;
	[Export]
	string ability2;
	[Export]
	string ability3;
	bool was_active_singal_sent;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 current_position = GlobalPosition;
		if(Input.IsActionJustPressed("AttackToggle")){
			if(!is_attacking){
				EnableAttackMode();
			}
		}
		if(is_active && !was_active_singal_sent){
			EmitSignal(SignalName.UnitActivated, attack, HP, current_position);
			was_active_singal_sent = true;
		}
		
	}
	public void _on_area_entered()
	{
		
	}
	public void EnableAttackMode(){
		is_attacking = true;
		EmitSignal(SignalName.EnterAttackMode, is_attacking);
		
		
	}
	public void _on_main_game_new_unit_entered(int ID){
		UnitID = ID;
		//In the future, we'll have to add a system for only affecting the newest node, not all of them.
	}
	
	[Signal]
	public delegate void UnitActivatedEventHandler(int atk_value, int HP_value, Vector2 pos);

	[Signal]
	public delegate void EnterAttackModeEventHandler(bool is_attacking);

	

}
