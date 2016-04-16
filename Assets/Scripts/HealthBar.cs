﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;

using ENTITY = ENUMS.ENTITY;
public class HealthBar : MonoBehaviour
{
    public Combat combat;
    public ENTITY entity;

    Character character;

    // Use this for initialization
    void Start()
    {
        if (entity == ENTITY.Enemy)
        {
            character = combat.enemyCharacter;
        }
        else
        {
            character = combat.playerCharacter;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Slider>().maxValue = character.healthPointsMax;
        this.GetComponent<Slider>().value = character.healthPoints;
    }
}
