using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitGame()
        {
        Debug.Log("Quitting the game...");
        Application.Quit();
        }
}
