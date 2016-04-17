using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using COMBATSTATUS = ENUMS.COMBATSTATUS;
public class Dungeon : MonoBehaviour
{

    public int dungeonLevel = 0;

    public List<GameObject> dungeons;
    public List<GameObject> monsterList;

    public GameObject enemySpawn;

    public Combat combat;
    public GameObject WinGameObject;

    public Color colorDone;
    public Color colorCurrent;
    public Color colorNext;

    public AudioClip musicLoose;
    public AudioClip musicWon;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartNextDungeonLevel()
    {
        dungeonLevel++;
        for (int i = 1; i <= dungeons.Count; i++)
        {
            if (i < dungeonLevel)
            { dungeons[i - 1].GetComponent<Image>().color = colorDone; }
            else if (i == dungeonLevel)
            { dungeons[i - 1].GetComponent<Image>().color = colorCurrent; }
            else
            { dungeons[i - 1].GetComponent<Image>().color = colorNext; }
        }

        if ((dungeonLevel - 1) >= monsterList.Count)
        {
            combat.combatStatus = COMBATSTATUS.FINISHED;
            GameWon();
        }
        else
        {
            //combat.enemyCharacter = monsterList[dungeonLevel - 1].GetComponent<Character>();
            GameObject enemyObject = (GameObject)Instantiate(monsterList[dungeonLevel - 1]);
            enemyObject.transform.position = enemySpawn.transform.position;
            combat.enemyObject = enemyObject;
            combat.StartNewFight();
        }
        //combat.combatStatus = COMBATSTATUS.Progress;
    }

    public void GameWon()
    {
        WinGameObject.SetActive(true);
    }

    public void StartDungeonLevel()
    {

    }
}
