using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;

public class NeighborSelect : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject neighborPortrait;
    public GameObject chooseButton;
    public GameObject cancelButton;
    public GameObject chooseNeighborNameText;

    public GameObject otherNeighbor1;
    public GameObject otherNeighbor2;

    public static bool fashionDesignerNotSelected;
    public static bool vampireNurseNotSelected;
    public static bool pitifulRobotNotSelected;
    public static string currentNeighbor;

    void Start() {
        neighborPortrait.SetActive(true);
        chooseButton.SetActive(false);
        cancelButton.SetActive(false);
        chooseNeighborNameText.SetActive(false);
    }

    [YarnFunction("getFashionDesignerNotSelected")]
    public static bool GetFashionDesignerNotSelected() {
        return fashionDesignerNotSelected;
    }

    [YarnFunction("getVampireNurseNotSelected")]
    public static bool GetVampireNurseNotSelected() {
        return vampireNurseNotSelected;
    }

    [YarnFunction("getPitifulRobotNotSelected")]
    public static bool GetPitifulRobotNotSelected() {
        return pitifulRobotNotSelected;
    }

    [YarnCommand("setFashionDesignerNotSelected")]
    public static void SetFashionDesignerNotSelected(bool status) {
        fashionDesignerNotSelected = status;
    }

    [YarnCommand("setVampireNurseNotSelected")]
    public static void SetVampireNurseNotSelected(bool status) {
        vampireNurseNotSelected = status;
    }

    [YarnCommand("setPitifulRobotNotSelected")]
    public static void SetPitifulRobotNotSelected(bool status) {
        Debug.Log("GOTCHA");
        pitifulRobotNotSelected = status;
    }

    public void OnPointerClick(PointerEventData eventData)
    {   
        // Set up selection interface buttons & text
        chooseButton.SetActive(true);
        cancelButton.SetActive(true);
        chooseNeighborNameText.SetActive(true);
        
        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        parentCanva.SetChosenNeighbor(gameObject);

        // Turn off "Which neighbor does this item belong to?"
        parentCanva.transform.Find("ChooseText").gameObject.SetActive(false);

        neighborPortrait.GetComponent<Image>().color = Color.white;
        otherNeighbor1.GetComponent<Image>().color = Color.grey;
        otherNeighbor2.GetComponent<Image>().color = Color.grey;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {

    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {

    }
}