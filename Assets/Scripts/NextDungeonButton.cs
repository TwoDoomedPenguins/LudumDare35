using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using COMBATSTATUS = ENUMS.COMBATSTATUS;
public class NextDungeonButton : MonoBehaviour {

    public Combat combat;
    public Dungeon dungeon;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (combat.combatStatus == COMBATSTATUS.Win)
        { this.GetComponent<Button>().enabled = true; }
        else
        { this.GetComponent<Button>().enabled = false; }

	}

    public void ClickStartNextDungeon()
    {
        dungeon.StartNextDungeonLevel();
    }
}
