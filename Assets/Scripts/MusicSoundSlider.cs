using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicSoundSlider : MonoBehaviour {


    public AudioSource audioSource;
    private Slider slider;

	// Use this for initialization
	void Start () 
    {
        slider = this.GetComponent<Slider>();
        slider.value = audioSource.volume;
	}
	
	// Update is called once per frame
	void Update () 
    {
        audioSource.volume = slider.value ;
	}
}
