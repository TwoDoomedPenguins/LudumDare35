using UnityEngine;
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
