using Godot;
using System;
using System.Collections.Generic;
public partial class VolumeSlider : HSlider
{
	[Export]
	string audio_bus_name = "Master";

	
	int bus_index;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bus_index = AudioServer.GetBusIndex(audio_bus_name); //the tutorial i looked at had this outside the method with an 'onready'
		//keyword in front of it. this is the same as declaring the variable outside the function, then initializing it in the ready function.
		Value = Mathf.DbToLinear(AudioServer.GetBusVolumeDb(bus_index));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _on_value_changed(){
		
		AudioServer.SetBusVolumeDb(bus_index, Mathf.LinearToDb((float)Value)); //UNSURE IF THIS IS CORRECT INTERPRETATION
		
	}
}
