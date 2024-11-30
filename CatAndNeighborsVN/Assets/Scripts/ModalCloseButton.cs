using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ModalCloseButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject levelSelectorModal;
    public GameObject openModalButton;

     public void OnPointerClick(PointerEventData eventData)
    {   
        levelSelectorModal.SetActive(false);
        openModalButton.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // orange like the pawprint
        gameObject.GetComponent<Image>().color = new Color(248, 180, 76);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        // back to original color
        gameObject.GetComponent<Image>().color = new Color(89, 47, 12);
    }
}