using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RefreshTextBasedOnSliderValue : MonoBehaviour
{
    public Text text;
    public Slider slider;
    bool includingMax = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = slider.value.ToString();
        if (includingMax)
        { text.text += " / " + slider.maxValue.ToString(); }
	}
}
