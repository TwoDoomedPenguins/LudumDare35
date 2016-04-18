using UnityEngine;
using System.Collections;
using System.Collections.Generic;


using ELEMENTS = ENUMS.ELEMENTS;
using FORMS = ENUMS.FORMS;

public class Character : MonoBehaviour {

    public string charName;

    public int level;
    public int experience;

    public int healthPoints;
    public int healthPointsMax;

    public int strength;
    public int dexterity;
    public int constitution;
    public int endurance;
    public int perception;
    public int intelligence;
    
    public int attack;
    public int damage;
    public int damageMagic;
    public int defense;
        
    public int block;
    public int blockFire;
    public int blockWater;
    public int blockEarth;
    public int blockAir;

    public int amountAttacks;
    public List<FORMS> availableForms;
    public List<FORMS> predefinedAttackSequence;
    public AudioClip battleMusic;

    Animator animator;
    public ParticleSystem particleSystem;
    //SpriteRenderer spriteRenderer;
    //Sprite standardSprite;
    



	// Use this for initialization
	void Start () 
    {
        //spriteRenderer = this.GetComponent<SpriteRenderer>();
        //standardSprite = spriteRenderer.sprite;
        RecalcAttributes();
        animator = this.GetComponent<Animator>();
        //particleSystem = this.GetComponentInChildren<ParticleSystem>();
       
	}

    public void Attack(FORMS form)
    {
        //Debug.Log(spriteForm);
        //particleSystem.Play();
   
        StartCoroutine(AttackIEnum(form));
        //spriteRenderer.sprite = spriteForm;
        //Debug.Log(spriteRenderer.sprite);

        //Debug.Log("TEST");
        

    }

    IEnumerator AttackIEnum(FORMS form)
    {
        particleSystem.Play();
        animator.SetTrigger(form.ToString());
        yield return new WaitForSeconds(0.5f);
        particleSystem.Play();
    }


	// Update is called once per frame
	void Update () {

        //if(charName == "Player") Debug.Log(spriteRenderer.sprite);
	}



    public void RecalcAttributes()
    {
        healthPointsMax = constitution * 2 + endurance;

        attack = dexterity/2+strength/4+intelligence/4;
        
        damage = strength / 2 + dexterity / 4;
        damageMagic = intelligence / 2 + perception / 4;

        defense = dexterity/2+endurance/4+perception/4;
        block = constitution/2+endurance/2+strength/4;
        blockFire = intelligence/2 +perception/2+constitution/4;
        blockWater = intelligence/2 +perception/2+endurance/4;
        blockEarth = intelligence/2 +perception/2+strength/4;
        blockAir = intelligence/2 +perception/2+dexterity/4;

        amountAttacks = endurance/3;
    }



    public List<FORMS> createRandomAttackSequence()
    { 
        List<FORMS> attackList = new List<FORMS>();
        for(int i = 0;i<amountAttacks;i++)
        {
            attackList.Add(availableForms[Random.Range(0, availableForms.Count)]);
        }
        return attackList;
    }

}
