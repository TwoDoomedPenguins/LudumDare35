using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExperienceBar : MonoBehaviour {

    public Character character;

    Slider slider;
	// Use this for initialization
	void Start () {
        slider = this.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = character.experience;
	}
}
