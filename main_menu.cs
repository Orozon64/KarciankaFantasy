using Godot;
using System;

public  class Card{

	int energy_cost;
	string name;
	string faction;
	int attack;
	int HP;
	string ability_name; //left blank if the card does not have any of the named abilities (monster slayer, ranged, etc.)
	public Card (int energy_cost, string name, string faction, int attack, int HP, string ability_name){
		this.energy_cost = energy_cost;
		this.name = name;
		this.faction = faction;
		this.attack = attack;
		this.HP = HP;
		this.ability_name = ability_name;
	}
}
public partial class main_menu : Node2D
{
	
	public Card archer = new Card(1, "Archer", "GMK", 2, 1, "Ranged");
	//Aaand voila, that works (for now)! To explain, the new thing in the Card class is a constructor - a method that activates when a new object of this class is made.
	//It takes in the arguments given in the parentheses, and sets the new Card's attributes to those arguments.
	//The "this" keyword is referring to the object currently being created. So the code in the constructor could be translated as:
	//"Set the new object's attributes to the given arguments".
	//So on and so forth, for all the other cards.
	public Card squire = new Card(1, "Squire", "GMK", 1, 1, " ");
	public Card scholar = new Card(1, "Scholar", "GMK", 0, 2, " ");
	
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

