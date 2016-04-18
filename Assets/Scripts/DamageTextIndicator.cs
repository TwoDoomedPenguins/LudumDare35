using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageTextIndicator : MonoBehaviour
{

    public float timerMax = 5;
    public float timer;
    public bool isActive = false;

    public Text text;
    public Color color;

    // Use this for initialization
    void Start()
    {
        timer = timerMax;
        text = this.GetComponent<Text>();
        color = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;
            //Debug.Log((1 / timerMax) * timer);
           
            color.a = Mathf.Clamp((1 / timerMax) * timer,0,1);
            text.color = color;
            if (timer <= 0) isActive = false;
        }

    }


    public void NewDamageText(string damageText)
    {
        text.text = damageText;
        timer = timerMax;
        color.a = 1;
        text.color = color;
        isActive = true;
    }


}
