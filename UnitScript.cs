using Godot;
using System;
using System.Collections.Generic;
public partial class UnitScript : Area2D
{
	int id; //this will be set when the unit is created. The ID of the last card will be in the main_game script.
	//The IDs will be used for collision detection (trust me, this makes sense. let me cook!)
	List<int> colliderIDs = new List<int>(); //a list of the IDs of all units this unit's colliding with.

	//here comes a small sense of deja vu ;)
	[Export]
	int HP;

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


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_area_entered(){
		//We need to grab the id of the unit we are colliding with, then add it to the list.
	}
}
