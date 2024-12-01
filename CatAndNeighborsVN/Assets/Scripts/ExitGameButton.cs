using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{

     public void Click()
    {   
        Debug.Log("Quit Game");
        Application.Quit();
    }
}