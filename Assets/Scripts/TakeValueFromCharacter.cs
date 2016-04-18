using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TakeValueFromCharacter : MonoBehaviour
{
    public Combat combat;
    public Character character;
    public string attributeText;
    public string variableName;

    private Text text;

    // Use this for initialization
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() 
    {

        if (combat != null) character = combat.enemyCharacter;
        //Debug.Log(character.GetType());
        //Debug.Log(character.GetType().GetField(variableName));
        //Debug.Log(character.GetType().GetField(variableName).GetValue(character));
        //Debug.Log(character.GetType().GetField(variableName).GetValue(character).ToString());
        if (character == null)
        { text.text = attributeText; }
        else
        {
            text.text = attributeText + character.GetType().GetField(variableName).GetValue(character).ToString();
        }

	}
}
