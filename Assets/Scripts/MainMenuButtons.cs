﻿using UnityEngine;
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

        Application.LoadLevel(2);

    } // END ButtonNewGame

    public void ButtonTutorial()
    {

        Application.LoadLevel(1);

    } // END ButtonTutorial

    public void ButtonExit()
    {
        Application.Quit();
    } // END ButtonExit

} // END Class