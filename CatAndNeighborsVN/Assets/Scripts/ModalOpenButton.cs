using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ModalOpenButton : MonoBehaviour
{
    public GameObject levelSelectorModal;

     public void Click()
    {   
        levelSelectorModal.SetActive(true);
    }
}