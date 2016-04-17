using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using FORMS = ENUMS.FORMS;
using ELEMENTS = ENUMS.ELEMENTS;
using ENTITY = ENUMS.ENTITY;
using COMBATSTATUS = ENUMS.COMBATSTATUS;
public class Combat : MonoBehaviour
{
    public Character playerCharacter;
    public GameObject enemyObject;
    public Character enemyCharacter;

    public GUI_AttackSequence GUIAttackPlayer;
    public GUI_AttackSequence GUIAttackEnemy;

    public DamageTextIndicator damageTextPlayer;
    public DamageTextIndicator damageTextEnemy;
    public DamageTextIndicator WinLooseText;

    public Dictionary<ENTITY, List<FORMS>> attackSequence = new Dictionary<ENTITY, List<FORMS>>();
    public Dungeon dungeon;

    public COMBATSTATUS combatStatus = COMBATSTATUS.Progress;
    bool isFightInProgress = false;

    AudioSource audioSource;
    public AudioClip musicIdle;
    public AudioClip musicLoose;
    public AudioClip musicWon;

    // Use this for initialization
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();


    }

    public void StartNewFight()
    {
        enemyCharacter = enemyObject.GetComponent<Character>();
        attackSequence.Clear();

        if (enemyCharacter.predefinedAttackSequence.Count > 0)
        { attackSequence.Add(ENTITY.Enemy, enemyCharacter.predefinedAttackSequence); }
        else
        { attackSequence.Add(ENTITY.Enemy, enemyCharacter.createRandomAttackSequence()); }

        if (enemyCharacter.battleMusic != null)
        {
            audioSource.clip = enemyCharacter.battleMusic;
            audioSource.Play();
        }
        enemyCharacter.healthPoints = enemyCharacter.healthPointsMax;

        attackSequence.Add(ENTITY.Player, new List<FORMS>());

        GUIAttackPlayer.RefreshSequenceSprites();
        GUIAttackEnemy.RefreshSequenceSprites();
        combatStatus = COMBATSTATUS.Progress;
    }


    public void AddAttackToPlayerSequence(FORMS form)
    {
        if (!isFightInProgress && combatStatus == COMBATSTATUS.Progress)
        {
            if (attackSequence[ENTITY.Player].Count < playerCharacter.amountAttacks)
            {
                attackSequence[ENTITY.Player].Add(form);
                GUIAttackPlayer.RefreshSequenceSprites();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Fight()
    {

        if (!isFightInProgress && combatStatus == COMBATSTATUS.Progress)
        {
            StartCoroutine(FightProceed());
        }
    }

    IEnumerator FightProceed()
    {
        isFightInProgress = true;
        if (combatStatus == COMBATSTATUS.Progress)
        {
            int rounds = 0;
            if (attackSequence[ENTITY.Enemy].Count > attackSequence[ENTITY.Player].Count)
            { rounds = attackSequence[ENTITY.Enemy].Count; }
            else
            { rounds = attackSequence[ENTITY.Player].Count; }


            for (int round = 0; round < rounds; round++)
            {

                Debug.Log(round.ToString() + " of " + rounds.ToString());

                FORMS attackForm = FORMS.NOTHING;
                ENTITY attackEntity = ENTITY.Player;

                FORMS defendForm = FORMS.NOTHING;
                ENTITY defendEntity = ENTITY.Player;
                for (int i = 0; i <= 1; i++)
                {
                    if (i == 0) // Player --> Enemy
                    {
                        attackEntity = ENTITY.Player;
                        defendEntity = ENTITY.Enemy;
                    }
                    else// Enemy --> Player
                    {
                        attackEntity = ENTITY.Enemy;
                        defendEntity = ENTITY.Player;
                    }

                    if (round < attackSequence[attackEntity].Count)
                    { attackForm = attackSequence[attackEntity][round]; }
                    else
                    { attackForm = FORMS.NOTHING; }

                    if (round < attackSequence[defendEntity].Count)
                    { defendForm = attackSequence[defendEntity][round]; }
                    else
                    { defendForm = FORMS.NOTHING; }

                    if (attackEntity == ENTITY.Enemy && attackForm == FORMS.QuestionMark)
                    {
                        attackForm = enemyCharacter.availableForms[(Random.Range(0, enemyCharacter.availableForms.Count - 1))];
                    }

                    if (attackEntity == ENTITY.Enemy) Debug.Log(attackForm.ToString());

                    if (i == 0)
                    { if (attackForm != FORMS.NOTHING) damageTextEnemy.NewDamageText(CalculateFight(playerCharacter, attackForm, enemyCharacter, defendForm)); }
                    else
                    { if (attackForm != FORMS.NOTHING) damageTextPlayer.NewDamageText(CalculateFight(enemyCharacter, attackForm, playerCharacter, defendForm)); }
                }

                if (playerCharacter.healthPoints <= 0)
                {
                    WinLooseText.NewDamageText("You Loose");
                    combatStatus = COMBATSTATUS.Loose;
                    audioSource.clip = musicLoose;
                    audioSource.Play();
                    yield return new WaitForSeconds(audioSource.clip.length);
                    audioSource.clip = musicIdle;
                    audioSource.Play();
                    break;
                }
                else if (enemyCharacter.healthPoints <= 0)
                {
                    WinLooseText.NewDamageText("You Win");
                    combatStatus = COMBATSTATUS.Win;
                    DestroyImmediate(enemyObject);
                    enemyObject = null;
                    enemyCharacter = null;
                    GUIAttackEnemy.ResetSequenceSprites();
                    audioSource.clip = musicWon;
                    audioSource.Play();
                    yield return new WaitForSeconds(audioSource.clip.length);
                    audioSource.clip = musicIdle;
                    audioSource.Play();
                    break;
                }
                yield return new WaitForSeconds(1.5f);

            }
        }
        attackSequence[ENTITY.Player].Clear();
        GUIAttackPlayer.RefreshSequenceSprites();
        isFightInProgress = false;
    }


    private string CalculateFight(Character attacker, FORMS attackForm, Character defender, FORMS defenceForm)
    {



        int attack = attacker.attack;
        int damage = attacker.damage;
        int damageMagic = attacker.damageMagic;

        ELEMENTS attackType = ELEMENTS.Physisc;

        switch (attackForm)
        {
            case FORMS.Cross://Counterspell
                return "CounterSpell";
            case FORMS.Diamond: //Abwehr
                return "Block";
            case FORMS.Square: //Ausweichen
                return "Evade";
            case FORMS.Trapeze: //Magic Shield
                return "Magic Shield";


            case FORMS.TriangleDown: //Leichter Angriff
                attack += 80;
                damage += 5;
                break;
            case FORMS.TriangleUp: //Schwerer Angriff
                attack += 50;
                damage += 10;
                break;


            case FORMS.Circle: //Wasser
                attackType = ELEMENTS.Water;
                attack += 60;
                damageMagic += 6;
                break;
            case FORMS.Hexagon: //Feuer
                attackType = ELEMENTS.Fire;
                attack += 50;
                damageMagic += 8;
                break;
            case FORMS.Pentagon: //Erde
                attackType = ELEMENTS.Earth;
                attack += 60;
                damageMagic += 5;
                break;
            case FORMS.Star: //Luft
                attackType = ELEMENTS.Air;
                attack += 80;
                damageMagic += 5;
                break;

        }

        int defense = defender.defense;
        int block = defender.block;
        int blockFire = defender.blockFire;
        int blockWater = defender.blockWater;
        int blockEarth = defender.blockEarth;
        int blockAir = defender.blockAir;


        switch (defenceForm)
        {
            case FORMS.Cross: // Counterspell
                blockFire += 20;
                blockWater += 20;
                blockEarth += 20;
                blockAir += 20;
                break;
            case FORMS.Diamond: //Abwehr
                block += 30;
                blockFire += 5;
                blockWater += 5;
                blockEarth += 5;
                blockAir += 5;
                break;
            case FORMS.Square: //Ausweichen
                defense += 10;
                break;
            case FORMS.Trapeze: //Magic Shield
                block += 5;
                blockFire += 20;
                blockWater += 20;
                blockEarth += 20;
                blockAir += 20;
                break;


            case FORMS.TriangleDown: //Leichter Angriff
                break;
            case FORMS.TriangleUp: //Schwerer Angriff
                defense -= 10;
                break;


            case FORMS.Circle: //Wasser
                break;
            case FORMS.Hexagon: //Feuer
                break;
            case FORMS.Pentagon: //Erde
                break;
            case FORMS.Star: //Luft
                break;
        }


        attack -= defense;
        if (attack <= 0) return "MISS";

        if (Random.Range(1, 100) > attack) return "MISS";

        int damageResult = 0;
        switch (attackType)
        {
            case ELEMENTS.Physisc:
                damageResult = damage - block;
                break;
            case ELEMENTS.Air:
                damageResult = damageMagic - blockAir;
                break;
            case ELEMENTS.Earth:
                damageResult = damageMagic - blockEarth;
                break;
            case ELEMENTS.Fire:
                damageResult = damageMagic - blockFire;
                break;
            case ELEMENTS.Water:
                damageResult = damageMagic - blockWater;
                break;
        }
        damageResult = Mathf.Clamp(damageResult, 1, defender.healthPoints);

        defender.healthPoints -= damageResult;
        return damageResult.ToString();



    }



}

