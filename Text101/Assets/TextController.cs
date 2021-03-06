﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;

    // All finite states
	private enum States {
		cell, cell_mirror, closet_door,
		corridor_0, corridor_1, corridor_2, corridor_3,
		courtyard, floor, in_closet,
		lock_0, lock_1, mirror, sheets_0, sheets_1,
		stairs_0, stairs_1, stairs_2
		};

	// Init myState of type States
    private States myState;

	// Use this for initialization
	void Start() {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update() {
		/*
		 * Change text based on state
		*/

		// log my state to console
		// print(myState);

		// Scene 1: The Cell
		if 		(myState == States.cell) 		{cell();}
		else if (myState == States.cell_mirror) {cell_mirror();}
		else if (myState == States.lock_0) 		{lock_0();}
		else if (myState == States.lock_1) 		{lock_1();}
		else if (myState == States.mirror) 		{mirror();}
		else if (myState == States.sheets_0)	{sheets_0();}
		else if (myState == States.sheets_1)	{sheets_1();}

		// Scene 2: The Corridor
		else if (myState == States.closet_door) {closet_door();}
		else if (myState == States.corridor_0) 	{corridor_0();}
		else if (myState == States.corridor_1) 	{corridor_1();}
		else if (myState == States.corridor_2) 	{corridor_2();}
		else if (myState == States.corridor_3) 	{corridor_3();}
		else if (myState == States.courtyard) 	{courtyard();}
		else if (myState == States.floor) 		{floor();}
		else if (myState == States.in_closet) 	{in_closet();}
		else if (myState == States.stairs_0)	{stairs_0();}
		else if (myState == States.stairs_1)	{stairs_1();}
		else if (myState == States.stairs_2)	{stairs_2();}
	}

	#region Scene 1: The Cell (State Handler Methods)
	void cell() {
		text.text = "... what's going on, where am I? ...\n\n" +
					"... I'm in a prison cell, but how did I get here? ... \n\n" +
					"I see some dirty sheets on the bunk, there's a small" +
					" mirror on the wall, and the cell door which appears to" +
					" have be locked from the outside.\n\n" +
					"[Press S to view Sheets, M to approach the Mirror, or L to view Lock]";

		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_0;}
	}

	void cell_mirror() {
		text.text = "Now what? I know I can use this mirror somehow ...\n\n" +
					"[Press S to view Sheets or L to view Lock]";

		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_1;}
	}

	void lock_0() {
		text.text = "... Hmmm ... this looks like a simple numeric-keypad type lock ...\n\n" +
					"I can't see the keys from inside this cell ... I doubt my head will fit" +
					" through the bars, but maybe I could get my hand through ...\n\n" +
					"[Press R to Return]";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell;}
	}

	void lock_1() {
		text.text = "... let's see here ... I wonder if ...\n\n" +
					"I knew it! Looks like someone had desert and didn't wash up. The" +
					" combination is made up of the numbers ... 1, 4, 8, and 9 ..." +
					" I wonder ... 1984 ... it worked! That's strange, 1984 is the" +
					" title of one my favourite books ...\n\n" +
					"[Press R to Return, Press O to Open the door and continue into corridor]";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.O)) 	{myState = States.corridor_0;}
	}

	void mirror() {
		text.text = "Whoa ...\n\n" +
					"Is that what I look like right now ... how long have I been in here???\n\n" +
					"This mirror doesn't look very firmly attached to the wall ...\n\n" +
					"[Press R to Return or T to Take the mirror]";

		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell;}
		else if (Input.GetKeyDown(KeyCode.T)) 	{myState = States.cell_mirror;}
	}

	void sheets_0() {
		text.text = "These sheets look (and smell) like I've been here for" +
					" a while. I can't seem to remember anything though ..." +
					" is that blood? I need to get out of this cell!\n\n" +
					"[Press R to Return]";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell;}
	}

	void sheets_1() {
		text.text = "That's definitely blood on these sheets, and something else" +
					" that I don't recognize but seems to be the source of this god" +
					" awful smell. I better see if there is something more I can" +
					" do with this mirror ...\n\n" +
					"[Press R to Return]";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_mirror;}
	}
	#endregion

	#region Scene 2: The Corridor (State Handler Methods)
	void closet_door() {
		text.text = "Damn, it's locked.\n\n" +
					"[Press R to Return]";

		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_0;}
	}

	void corridor_0() {
		text.text = "Time to get the hell out of dodge. Let's see, I see what looks" +
					" like stairs, there's a door at the end of this corridor and" +
					" I think I see something glistening on the floor ...\n\n" +
					"[Press S for go up Stairs, F to take a better look at the Floor," +
					" or C to try the Closet door]";

		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_0;}
		else if (Input.GetKeyDown(KeyCode.F)) 	{myState = States.floor;}
		else if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.closet_door;}
	}

	void corridor_1() {
		text.text = "Ok great, armed with a mighty hair clip, watch out guards ...\n\n" +
					"... or I could try my hand at lock-picking ... \n\n" +
					"[Press S to go up Stairs, or P to Pick the closet door lock]";

		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_1;}
		else if (Input.GetKeyDown(KeyCode.P)) 	{myState = States.in_closet;}
	}

	void corridor_2() {
		text.text = "Ok, it's either go up these stairs and face these shadows" +
					" or think of something a little more creative ...\n\n" +
					"[Press S to go up Stairs, or B to go Back inside closet]";

		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_2;}
		else if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.in_closet;}
	}

	void corridor_3() {
		text.text = "Now this is more like it, I just hope they don't get a" +
					" good look at me ... and I really hope these stairs lead somewhere ...\n\n" +
					"[Press U to Undress, or S to take stairs to courtyard]";

		if 		(Input.GetKeyDown(KeyCode.U)) 	{myState = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.courtyard;}
	}

	void courtyard() {
		text.text = "... nice and easy ... I'm just another member of the staff ..." +
					" nothing to ...\n\n" +
					"What is this??? What happened to these guys? Looks like" +
					" some sort of animal ripped them apart ...\n\n" +
					"There's the door, I'm out of here!\n\n" +
					"[Press P to Play again!]";

		if 		(Input.GetKeyDown(KeyCode.P)) 	{myState = States.cell;}
	}

	void floor() {
		text.text = "Hmm ... looks like a hair clip, could be useful ...\n\n" +
					"[Press R to Return, or H to pick up Hairclip]";

		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.H)) 	{myState = States.corridor_1;}
	}

	void in_closet() {
		text.text = "It's just a closet, wonder if there is anything in here ...\n\n" +
					"A maintenance uniform, I might be able to work with this ...\n\n" +
					"[Press R to Return, or D to Dress up as maintenance staff and return]";

		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_2;}
		else if (Input.GetKeyDown(KeyCode.D)) 	{myState = States.corridor_3;}
	}

	void stairs_0() {
		text.text = "I hope these stairs lead to the exit ...\n\n" +
					"... wait ... is that a TV???\n\n" +
					"I think I see silhouettes, could be guards, I'd better go back!\n\n" +
					"[Press R to Return]";

		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_0;}
	}

	void stairs_1() {
		text.text = "TV's still on ... Better not risk it.\n\n" +
					"[Press R to Return]";

		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_1;}
	}

	void stairs_2() {
		text.text = "OK .. stairs it is ... \n\n" +
					"This is a terrible idea, I count at least two, maybe three silhouettes?\n\n" +
					"[Press R to Return]";

		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_2;}	
	}
	/*
	 * End Scene 2
	*/
	#endregion
}