using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Tutorial : MonoBehaviour
{

    public List<Text> allText = new List<Text>();

    Text textBox;
    int counter = 0;


    // Use this for initialization
    void Start()
    {
        UpdateText();

    }

    private void UpdateText()
    {
        if (counter >= allText.Count)
        { Application.LoadLevel(0); }
        else
        {
            for (int i = 0; i < allText.Count; i++)
            {
                if (i == counter)
                {
                    allText[i].enabled = true;
                }
                else
                { allText[i].enabled = false; }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        ButtonPress();
    }

    void ButtonPress()
    {

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            counter++;
            UpdateText();
            //switch (counter)
            //{ 
            //    case 1:
            //        textBox.text = output1;
            //        break;
            //    case 2:
            //        textBox.text = output2;
            //        break;
            //    case 3:
            //        textBox.text = output3;
            //        break;
            //    case 4:
            //        textBox.text = output4;
            //        break;
            //    case 5:
            //        textBox.text = output5;
            //        break;
            //    case 6:
            //        Application.LoadLevel(0);
            //        break;
            //}

        }


        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.LoadLevel(0);
        }


    } // END ButtonPress


} // END Class

