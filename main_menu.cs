using Godot;
using System;

public  class Card{

	int energy_cost;
	string name;
	string faction;
	int attack;
	int HP;
	string ability_name; //left blank if the card does not have any of the named abilities (monster slayer, ranged, etc.)
}
public partial class main_menu : Node2D
{
	
	public Card archer = new Card();
	archer.energy_cost = 1; //I don't know why, but right now it's throwing errors saying that archer does not exist in the current context
	//(I'll let you guys know if restarting my computer fixed it, since it usually works for lots of the weird stuff).
	archer.name = "Archer";
	archer.faction = "GMK";
	archer.attack =  2;
	archer.HP = 1;
	archer.ability_name = "ranged";

	public Card squire = new Card();
	squire.energy_cost = 1;
	squire.name = "Squire";
	squire.faction = "GMK";
	archer.attack =  1;
	archer.HP = 1;
	
	int number_of_decks_GMK = 0;
	//The variable above is for the select deck option - if the number is zero, there will be a text saying the player has no decks from that faction.
	int number_of_decks_Mages = 0;
	int number_of_decks_Barbarians = 0;
	int number_of_decks_HM = 0; //half-monsters
	bool was_deck_selected = false;
	public SceneTree sceneTree;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Show();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_create_deck_btn_pressed()
	{
		Hide();
	}
	public void _on_select_deck_btn_pressed()
	{
		Hide();
	}
	public void _on_setting_btn_pressed(){
		Hide();
		var settings_menu = GetNode<Node2D>("Settings2D");
		settings_menu.Show();
	}
	public void _on_quit_button_pressed(){
		sceneTree.Quit();
	}
	public void _on_resume_button_pressed(){
		var settings_menu = GetNode<Node2D>("Settings2D");
		settings_menu.Hide();
		Show();
	}
}

