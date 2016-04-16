using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using FORMS = ENUMS.FORMS;
using ENTITY = ENUMS.ENTITY;
public class Combat : MonoBehaviour
{
    public Character playerCharacter;
    public Character enemyCharacter;

    public GUI_AttackSequence GUIAttackPlayer;
    public GUI_AttackSequence GUIAttackEnemy;

    public Dictionary<ENTITY,List<FORMS>> attackSequence = new Dictionary<ENTITY,List<FORMS>>();

    // Use this for initialization
    void Start()
    {
        
        if(enemyCharacter.predefinedAttackSequence.Count >0)
        {attackSequence.Add(ENTITY.Enemy,enemyCharacter.predefinedAttackSequence);}
        else
        { attackSequence.Add(ENTITY.Enemy, enemyCharacter.createRandomAttackSequence()); }

        attackSequence.Add(ENTITY.Player, new List<FORMS>());

        GUIAttackPlayer.RefreshSequenceSprites();
        GUIAttackEnemy.RefreshSequenceSprites();
        
    }


    public void AddAttackToPlayerSequence(FORMS form)
    {
        if (attackSequence[ENTITY.Player].Count < playerCharacter.amountAttacks)
        {
            attackSequence[ENTITY.Player].Add(form);
            GUIAttackPlayer.RefreshSequenceSprites();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

