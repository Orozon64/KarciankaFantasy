using Godot;
using System;
using System.Collections.Generic;
public  class Card{

	int energy_cost;
	string name;
	string faction;
	int attack;
	int HP;
	 
	string category;
	

	List <string> tag_list = new List<string>();
	List <string> ability_list = new List<string>();
	//maybe change the above 3 to an array??
	//Okay, at this point the only thing that keeps me from making the tags(maybe abilities too) into an array/list is the way the constructor
	//works. Because, if we don't pass elements into it, it won't work, and if we do, not much will change.
	//Update: OPTIONAL PARAMETERS EXIST IN C# LET'S GO
	//I might do the same thing for abilities.
	//I really SHOULD do the same thing for abilities. You're hopefully seeing this after I already did, but previously... hoo boy.
	public Card (int energy_cost, string name, string faction, int attack, int HP, string category,  string tag1 ="", string tag2 = "", string tag3 = "", string ability1_name = "", string ability2_name = "", string ability3_name = ""){
		this.energy_cost = energy_cost;
		this.name = name;
		this.faction = faction;
		this.attack = attack;
		this.HP = HP;

		this.category = category;
		if (!string.IsNullOrEmpty(tag1)){
			this.tag_list.Add(tag1);
		}
		if (!string.IsNullOrEmpty(tag2)){
			this.tag_list.Add(tag2);
		}
		if(!string.IsNullOrEmpty(tag3)){
			this.tag_list.Add(tag3);
		}

		if (!string.IsNullOrEmpty(ability1_name)){
			this.ability_list.Add(ability1_name);
		}
		if (!string.IsNullOrEmpty(ability2_name)){
			this.ability_list.Add(ability2_name);
		}
		if (!string.IsNullOrEmpty(ability3_name)){
			this.ability_list.Add(ability3_name);
		}
	}
	
}
public partial class main_menu : Node2D
{
	
	public Card archer = new Card(1, "Archer", "GMK", 2, 1, "Unit",  "Creature", "Human", "", "Ranged");
	//Aaand voila, that works (for now)! To explain, the new thing in the Card class is a constructor - a method that activates when a new object of this class is made.
	//It takes in the arguments given in the parentheses, and sets the new Card's attributes to those arguments.
	//The "this" keyword is referring to the object currently being created. So the code in the constructor could be translated as:
	//"Set the new object's attributes to the given arguments".
	//So on and so forth, for all the other cards.
	public Card squire = new Card(1, "Squire", "GMK", 1, 1, "Unit", "Creature", "Human");
	public Card scholar = new Card(1, "Scholar", "GMK", 0, 2, "Unit", "Creature", "Human");
	
	public Card wagenburg = new Card(1, "Wagenburg", "GMK", 0, 0, "Effect", "Structure");
	public Card sword = new Card(1, "Sword", "GMK", 0, 0, "Item", "Weapon");
	public Card peasant_militia = new Card(2, "Peasant Militia", "GMK", 1, 1, "Unit", "Creature", "Human");
	public Card crossbower = new Card(2, "Crossbower", "GMK", 3, 2,  "Unit", "Creature", "Human", "", "Ranged");
	public Card horse_archer = new Card(2, "Horse Archer", "GMK", 3, 1, "Unit", "Creature", "Human", "", "Ranged", "Cavalry");
	public Card war_medic = new Card(2, "War Medic", "GMK", 0, 2, "Unit", "Creature", "Human");
	public Card horseman = new Card(2, "Horseman", "GMK", 3, 2, "Cavalry", "Unit", "Creature", "Human", "Beast");
	public Card royal_order = new Card(2, "Royal Order", "GMK", 0, 0, "Effect", "Vocal", "", "", "Refresh");
	public Card priest = new Card(3, "Priest", "GMK", 1, 1, "Unit", "Creature", "Human");
	public Card slaver = new Card(3, "Slaver", "GMK", 3, 3, "Unit", "Creature", "Human");
	public Card knight = new Card(3, "Knight", "GMK", 3, 3, "Unit", "Creature", "Human", "", "Armored1");
	public Card assasin = new Card(3, "Assasin", "GMK", 1, 1, "Unit", "Creature", "Human", "", "Killer5");
	public Card catapult = new Card(3, "Catapult", "GMK", 2, 2, "Unit", "Structure", "", "", "Ranged");
	public Card duel = new Card(3, "Duel", "GMK", 0, 0, "Effect");
	public Card barrage_of_arrows = new Card(3, "Barrage of Arrows",  "GMK", 0, 0, "Effect", "Weapon");
	public Card heavy_armor = new Card(3, "Heavy Armor", "GMK", 0, 0, "Item", "Armor");
	public Card greatsword = new Card(3, "Greatsword", "GMK", 0, 0, "Item", "Weapon");
	public Card general = new Card(4, "General", "GMK", 2, 2, "", "Unit", "Creature", "Human");
	public Card ranger = new Card(4, "Ranger", "GMK", 5, 2, "Unit", "Creature", "Human", "", "Ranged");
	public Card holy_shield = new Card(4, "Holy Shield", "GMK", 0, 0, "Item", "Weapon");
	public Card paladin = new Card(6, "Paladin", "GMK", 4, 4, "Unit", "Creature", "Human", "", "Armored1", "Monster slayer2");
	public Card bounty_hunter = new Card(6, "Bounty hunter", "GMK", 2, 2, "Unit", "Creature", "Human");
	public Card cannon = new Card(7, "Cannon", "GMK", 4, 6, "Unit", "Creature", "Human", "", "Ranged", "Demolisher 2");
	public Card winged_hussar = new Card(10, "Winged Hussar", "GMK", 6, 7, "Unit", "Creature", "Human", "Beast", "Monster slayer3", "Armored1", "Cavalry");
	public Card trebuchet = new Card(11, "Trebuchet", "GMK", 5, 7, "Unit", "Structure", "", "", "Demolisher2", "Ranged");
	//There we go! All GMK cards.
	int number_of_decks_GMK = 0;
	//The variable above is for the select deck option - if the number is zero, there will be a text saying the player has no decks from that faction.
	int number_of_decks_Mages = 0;
	int number_of_decks_Barbarians = 0;
	int number_of_decks_HM = 0; //half-monsters
	bool was_deck_selected = false;
	public SceneTree sTree= new SceneTree();
	
	private Node2D settingsMenu;
	private Node2D Main2D;
	string player_faction;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Main2D = GetNode<Node2D>("Main2D");
		Main2D.Show();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_create_deck_btn_pressed()
	{
		Main2D.Hide();
	}
	public void _on_select_deck_btn_pressed()
	{
		Main2D.Hide();
	}
	public void _on_setting_btn_pressed(){
		Main2D = GetNode<Node2D>("Main2D");
		Main2D.Hide();
		settingsMenu = GetNode<Node2D>("Settings2D");
		settingsMenu.Show();
	}
	public void _on_quit_button_pressed(){
		sTree.Quit();
	}
	public void _on_resume_button_pressed(){
		Main2D = GetNode<Node2D>("Main2D");
		settingsMenu = GetNode<Node2D>("Settings2D");
		settingsMenu.Hide();
		Main2D.Show();
	}
}

