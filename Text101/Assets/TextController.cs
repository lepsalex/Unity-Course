using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;

    // All finite states
	private enum States {cell,
						 cell_mirror,
						 corridor_0,
						 lock_0,
						 lock_1,
						 mirror,
						 sheets_0,
						 sheets_1};

	// Init myState of type States
    private States myState;

	// Use this for initialization
	void Start() {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update() {
		print(myState);
		// Change text based on state
		if 		(myState == States.cell) 		{cell();}
		else if (myState == States.cell_mirror) {cell_mirror();}
		else if (myState == States.corridor_0) 	{corridor_0();}
		else if (myState == States.lock_0) 		{lock_0();}
		else if (myState == States.lock_1) 		{lock_1();}
		else if (myState == States.mirror) 		{mirror();}
		else if (myState == States.sheets_0)	{sheets_0();}
		else if (myState == States.sheets_1)	{sheets_1();}  
	}

	void cell() {
		text.text = "... what's going on, where am I? ...\n\n" +
					"... I'm in a prison cell, but how did I get here? ... \n\n" +
					"I see some dirty sheets on the bunk, there's a small" +
					" mirror on the wall, and the cell door which appears to" +
					" have be locked from the outside.\n\n" +
					"Press S to view sheets, M to view Mirror or L to view Lock";

		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_0;}
	}

	void cell_mirror() {
		text.text = "Now what? I know I can use this mirror somehow ...\n\n" +
					"Press S to view sheets or L to view Lock";

		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_1;}
	}

	void corridor_0() {
		text.text = "I'm not waiting around for whoever locked me in here to" +
					" come back, time to get out of here ...\n\n" +
					"OPTIONS TBD";

		if 		(Input.GetKeyDown(KeyCode.T)) 	{myState = States.cell;}
	}

	void lock_0() {
		text.text = "... Hmmm ... this looks like a simple numeric-keypad type lock ...\n\n" +
					"I can't see the keys from inside this cell ... I doubt my head will fit" +
					" through the bars, but maybe I could get my hand through ...\n\n" +
					"Press R to return";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell;}
	}

	void lock_1() {
		text.text = "... let's see here ... I wonder if ...\n\n" +
					"I knew it! Looks like someone had desert and didn't wash up. The" +
					" combination is made up of the numbers ... 1, 4, 8, and 9 ..." +
					" I wonder ... 1984 ... it worked! That's strange, 1984 is the" +
					" title of one my favourite books ...\n\n" +
					"Press R to return, Press O to open the door and continue into the corridor";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.O)) 	{myState = States.corridor_0;}
	}

	void mirror() {
		text.text = "Whoa ...\n\n" +
					"Is that what I look like right now ... how long have I been in here???\n\n" +
					"This mirror doesn't look very firmly attached to the wall ..." +
					"Press R to return or T to take the mirror";

		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell;}
		else if (Input.GetKeyDown(KeyCode.T)) 	{myState = States.cell_mirror;}
	}

	void sheets_0() {
		text.text = "These sheets look (and smell) like I've been here for" +
					" a while. I can't seem to remember anything though ..." +
					" is that blood? I need to get out of this cell!\n\n" +
					"Press R to return";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell;}
	}

	void sheets_1() {
		text.text = "That's definitely blood on these sheets, and something else" +
					" that I don't recognize but seems to be the source of this god" +
					" awful smell. I better see if there is something more I can" +
					" do with this mirror ...\n\n" +
					"Press R to return";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_mirror;}
	}
}
