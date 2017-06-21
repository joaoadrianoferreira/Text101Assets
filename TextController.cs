﻿using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, stairs_0, floor, closet_door, stairs_1, corridor_1, in_closet, stairs_2, 
						corridor_2, courtyard, corridor_3}; 
	private States myState; 
	
	void Start () {
		myState = States.cell; 
	}
	
	void Update () {
		if (myState == States.cell) {
			state_cell(); 
		} else if (myState == States.sheets_0) {
			state_sheets_0(); 
		} else if (myState == States.lock_0) {
			state_lock_0(); 
		} else if (myState == States.mirror) {
			state_mirror(); 
		} else if (myState == States.cell_mirror) {
			state_cell_mirror(); 
		} else if (myState == States.sheets_1) {
			state_sheets_1(); 
		} else if (myState == States.lock_1) {
			state_lock_1(); 
		} else if (myState == States.corridor_0) {
			state_corridor_0(); 
		} else if (myState == States.stairs_0) {
			state_stairs_0(); 
		} else if (myState == States.floor) {
			state_floor(); 
		} else if (myState == States.closet_door) {
			state_closet_door(); 
		} else if (myState == States.stairs_1) {
			state_stairs_1(); 
		} else if (myState == States.corridor_1) {
			state_corridor_1(); 
		} else if (myState == States.in_closet) {
			state_in_closet(); 
		} else if (myState == States.stairs_2) {
			state_stairs_2(); 
		} else if (myState == States.corridor_2) {
			state_corridor_2(); 
		} else if (myState == States.courtyard) {
			state_courtyard(); 
		} else if (myState == States.corridor_3) {
			state_corridor_3(); 
		}
	}
	
	#region state handler methods 
	
	void state_cell () {
		text.text = "You are in a prison cell, and you want to scape. There are " + 
					"some dirty sheets on the bed, a mirror on the wall, and the door " +  
			 		"is locked from the outside\n\n" + 
					"Press S to view Sheets, M for Mirror or L for Lock"; 
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0; 
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror; 
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0; 
		}	
	}
	
	void state_sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's " + 
					"time somebody changed them. The pleasures of prison life " +  
					"I guess!\n\n" + 
					"Press R to Return to roaming your cell"; 
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell; 
		}
	}
	
	void state_sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " + 
					"any better!\n\n" + 
					"Press R to Return to roaming your cell"; 
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror; 
		}
	}
	
	void state_lock_0() {
		text.text = "This one of those button locks. You have no ideia what the " + 
					"combination is. You wish you could somehow see where the dirty " +  
					"fingerprints where, maybe that would help.\n\n" + 
					"Press R to Return to roaming your cell"; 
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell; 
		}
	}
	
	void state_lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round  " + 
					"so you can see the lock. You can just make out fingerprints around " +  
					"the buttons. You press the dirty buttons, and hear a clieck.\n\n" + 
					"Press O to Open or R to Return to roaming your cell"; 
		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.corridor_0; 
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror; 
		}
	}
	
	void state_cell_mirror() {
		text.text = "You are still in your cell, and you STILL want to escape! There are  " + 
					"some dirty sheets on the bed, a mark where the mirror was, " +  
					"and that pesky door is still there, and firmly locked!\n\n" + 
					"Press S to view Sheets or L to view Lock"; 
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1; 
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1; 
		}
	}
	
	void state_corridor_0() {
		text.text = "You're out of your cell, but not out of trouble." +
					"You are in the corridor, there's a closet and some stairs leading to " +
					"the courtyard. There's also various detritus on the floor.\n\n" +
					"C to view the Closet, F to inspect the Floor, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_0; 
		} else if (Input.GetKeyDown(KeyCode.F)) {
			myState = States.floor; 
		} else if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.closet_door; 
		}
	}
	
	void state_mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n " +  
					"Press T to Take the Mirror or R to Return to roaming your cell"; 
		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror; 
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell; 
		}
	}
	
	void state_stairs_0() {
		text.text = "Ypu start walking up the stairs towards the outside light. " +
					"You realize it's not break time, and you'll be caught imediately " + 
					"You slighter back down the stairs and reconsider.\n\n " +  
					"Press R to Return to the corridor"; 
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0; 
		}
	}
	
	void state_closet_door() {
		text.text = "You are looking at a closet door, unfortunately it's locked. " +
					"Maybe you could find something around to help enourage it open?\n\n" +
					"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0; 
		}
	}
	
	void state_floor() {
		text.text = "Rummagaing around the dirty floor, you find a hairclip.\n\n" +  
					"Press R to Return to the standing, or H to take the hairclip";  
		if (Input.GetKeyDown(KeyCode.H)) {
			myState = States.corridor_1; 
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0; 
		}	
	}
	
	void state_corridor_1() {
		text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
						"Now what? You wonder if that lock on the closet would succumb to " +
						"to some lock-picking?\n\n" +
						"P to Pick the lock, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_1; 
		} else if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.in_closet; 
		}
	}
	
	void state_stairs_1() {
		text.text = "Unfortunately weilding a puny hairclip hasn't give you the " +
					"confidence to walk out into a courtyard surrounded by armed guards!\n\n " +  
					"Press R to Retreat down the stairs";  
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_1; 
		}
	}
	
	void state_stairs_2() {
		text.text = "You feel smog for picking the close door open, and are still armed with " +
					"a hairclip (not badly bent). Even these achievements together don't give " + 
					"you the courage to climb up the stairs to your death!\n\n " +  
					"Press R to Return to the corridor";  
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_2; 
		}
	}
	
	void state_in_closet() {
		text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
					"Seems like your day is looking-up.\n\n" +
					"Press D to Dress up, or R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.corridor_3; 
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_2; 
		}
	}
	
	void state_corridor_2() {
		text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
					"Press C to revisit the Closet, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_2; 
		} else if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.in_closet; 
		}
	}
	
	void state_corridor_3() {
		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
					"You strongly consider the run for freedom.\n\n" +
					"Press S to take the Stairs, or U to Undress";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.courtyard; 
		} else if (Input.GetKeyDown(KeyCode.U)) {
			myState = States.in_closet; 
		}
	}
	
	void state_courtyard() {
		text.text = "You walk through the courtyard dressed as a cleaner. " +
					"The guard tips his hat at you as you waltz past, claiming " +
					"your freedom. You heart races as you walk into the sunset.\n\n" +
					"Press P to Play again.";  
		if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell; 
		}
	}
	
	#endregion

}
