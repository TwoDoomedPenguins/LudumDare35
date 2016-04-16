using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using FORMS = ENUMS.FORMS;
public class AttackButton : MonoBehaviour {

    public Combat combat;
    public FORMS form;
    public Sprite spriteDisable;
    public Sprite spriteEnable;

	// Use this for initialization
	void Start () 
    {
        spriteDisable = this.GetComponent<Image>().sprite;

        if (combat.playerCharacter.availableForms.Contains(form))
        { this.GetComponent<Image>().sprite = spriteEnable; }
        else
        { this.GetComponent<Button>().enabled = false; }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    { 

    }
}
