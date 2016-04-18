using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TakeValue : MonoBehaviour
{
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
        //Debug.Log(character.GetType());
        //Debug.Log(character.GetType().GetField(variableName));
        //Debug.Log(character.GetType().GetField(variableName).GetValue(character));
        //Debug.Log(character.GetType().GetField(variableName).GetValue(character).ToString());
        text.text = attributeText + character.GetType().GetField(variableName).GetValue(character).ToString();

	}
}
