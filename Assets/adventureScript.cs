using UnityEngine;
using System.Collections;

public class adventureScript : MonoBehaviour {
	string currentRoom = "Lobby";
	bool hasKey = false;
	bool hasCode = false;

	// Update is called once per frame
	void Update () {
		string textBuffer = "You are currently in: " + currentRoom;

		if (currentRoom == "Lobby") {
			textBuffer += "\nPress [X] to explore the lobby.";
			textBuffer += "\nPress [E] to access the elevator.";
			textBuffer += "\nPress [O] to exit the building.";

			if (hasKey == true) {
				textBuffer += "\nYou found a key.";
			}

			if (Input.GetKeyDown (KeyCode.X)) {
				hasKey = true;
			} else if (Input.GetKeyDown (KeyCode.E) && hasKey == true) {
				currentRoom = "Elevator";
			} else if (Input.GetKeyDown (KeyCode.E) && hasKey == false) {
				textBuffer += "\nYou need a key to call the elevator. \nMaybe you should look around.";
			} else if (Input.GetKeyDown (KeyCode.O) && hasCode == false) {
				textBuffer += "\nYou need an access code to leave. \nMaybe you should look around.";
			} else if (Input.GetKeyDown (KeyCode.O) && hasCode == true) {
				currentRoom = "Outside";
			}
		} else if (currentRoom == "Elevator") {
			textBuffer += "\nPress [X] to explore the elevator.";
			textBuffer += "\nPress [L] to exit the elevator.";
			if (hasCode == true) {
				textBuffer += "\nYou found a note with an access code.";
			}

			if (Input.GetKeyDown (KeyCode.X)) {	
				hasCode = true;
			} else if (Input.GetKeyDown (KeyCode.L)) {
				currentRoom = "Lobby";
			}
		} else if (currentRoom == "Outside") {
			textBuffer += "\nCongratulations, you made it outside. \nGo home.";
		}
		GetComponent<TextMesh>().text = textBuffer;
	}
}