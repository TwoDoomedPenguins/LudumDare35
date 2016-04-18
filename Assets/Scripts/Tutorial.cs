using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour {

    public string output1 = "";
    public string output2 = "";
    public string output3 = "";
    public string output4 = "";
    public string output5 = "";

    Text textBox;
    int counter = 0;


	// Use this for initialization
	void Start () 
    {
	    textBox = this.GetComponent<Text>();
        counter = 1;
        textBox.text = output1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        ButtonPress();
	}

    void ButtonPress()
    {

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            counter++;

            switch (counter)
            { 
                case 1:
                    textBox.text = output1;
                    break;
                case 2:
                    textBox.text = output2;
                    break;
                case 3:
                    textBox.text = output3;
                    break;
                case 4:
                    textBox.text = output4;
                    break;
                case 5:
                    textBox.text = output5;
                    break;
                case 6:
                    Application.LoadLevel(0);
                    break;
            }
           
        }


        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.LoadLevel(0);
        }

    
    } // END ButtonPress


} // END Class
