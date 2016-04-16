using UnityEngine;
using System.Collections;


using ELEMENTS = ENUMS.ELEMENTS;
using FORMS = ENUMS.FORMS;

public class Character : MonoBehaviour {

    public string charName;

    public int level;
    public int experience;

    public int healthPoints;

    public int strength;
    public int dexterity;
    public int constitution;
    public int endurance;
    public int perception;
    public int intelligence;



    public int attack;
    public int defense;
    
    
    public int block;
    public int blockFire;
    public int blockWater;
    public int blockEarth;
    public int blockAir;

    public int amountAttacks;
    
    
	// Use this for initialization
	void Start () 
    {
        
        RecalcAttributes();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void RecalcAttributes()
    {
        healthPoints = constitution * 2 + endurance;

        attack = dexterity/2+strength/4+intelligence/4;
        defense = dexterity/2+endurance/4+perception/4;
        block = constitution/2+endurance/2+strength/4;
        blockFire = intelligence/2 +perception/2+constitution/4;
        blockWater = intelligence/2 +perception/2+endurance/4;
        blockEarth = intelligence/2 +perception/2+strength/4;
        blockAir = intelligence/2 +perception/2+dexterity/4;

        amountAttacks = endurance/3;
    }

}
