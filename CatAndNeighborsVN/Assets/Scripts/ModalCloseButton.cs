using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ModalCloseButton : MonoBehaviour
{
    public GameObject levelSelectorModal;
    public GameObject openModalButton;

    void Start() {
        levelSelectorModal.SetActive(false);
    }

     public void Click()
    {   
        openModalButton.SetActive(true);
        levelSelectorModal.SetActive(false);
    }
}