using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using FORMS = ENUMS.FORMS;
using ENTITY = ENUMS.ENTITY;
public class GUI_AttackSequence : MonoBehaviour
{
    public Combat combat;


    public List<GameObject> attackSequence;
    public ENTITY entity;
    public List<FORMS> forms;
    public List<Sprite> formSprites;


    public Dictionary<FORMS, Sprite> formAndSprites = new Dictionary<FORMS, Sprite>();

    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < forms.Count; i++)
        {
            formAndSprites.Add(forms[i], formSprites[i]);
        }
    }

    public void RefreshSequenceSprites()
    {
        int amountVisibleForms = 0;
        if (entity == ENTITY.Enemy)
        {
            amountVisibleForms = combat.playerCharacter.perception / 3;
        }

        for (int i = 0; i < attackSequence.Count; i++)
        {
            if (i < combat.attackSequence[entity].Count)
            {
                attackSequence[i].SetActive(true);
                if (entity == ENTITY.Enemy)
                {
                    if (i < amountVisibleForms)
                    {
                        attackSequence[i].GetComponent<Image>().sprite = formAndSprites[combat.attackSequence[entity][i]];
                    }
                    else
                    {
                        attackSequence[i].GetComponent<Image>().sprite = formAndSprites[FORMS.Unknown];
                    }
                }
                else
                {
                    attackSequence[i].GetComponent<Image>().sprite = formAndSprites[combat.attackSequence[entity][i]];
                }
            }
            else
            {
                attackSequence[i].SetActive(false);
            }

        }
    }

    public void ResetSequenceSprites()
    {
        for (int i = 0; i < attackSequence.Count; i++)
        { attackSequence[i].SetActive(false); }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
