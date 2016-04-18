using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuButtons : MonoBehaviour
{

    public void Click_ReturnToMainMenu()
    { Application.LoadLevel(0); }

    public void Click_RestartDungeon()
    {
        Application.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
