using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour {


	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonNewGame()
    {

        Application.LoadLevel(1);

    } // END ButtonNewGame

    public void ButtonTutorial()
    { 
        
        /* 
         
         Hier muss noch ein bisschen Code eingefügt werden!!!!!!
         
         */

    } // END ButtonTutorial

    public void ButtonExit()
    {
        Application.Quit();
    } // END ButtonExit

} // END Class