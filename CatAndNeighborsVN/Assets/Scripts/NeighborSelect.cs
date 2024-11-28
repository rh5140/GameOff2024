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

    public static bool fashionDesignerNotSelected;
    public static bool vampireNurseNotSelected;
    public static bool pitifulRobotNotSelected;
    public static string currentNeighbor;

    private static Vector3 buttonOriginalPosition;
    private static Vector3 nameOriginalPosition;

    void Start() {
        neighborPortrait.SetActive(true);
        chooseButton.SetActive(false);
        cancelButton.SetActive(false);
        chooseNeighborNameText.SetActive(false);

        NeighborCanvasParent originalPosition = GetComponentInParent<NeighborCanvasParent>();
        buttonOriginalPosition = originalPosition.transform.Find("CurrentSelection").position;
        nameOriginalPosition = originalPosition.transform.Find("ChosenNeighborName").position;
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
        chooseButton.SetActive(true);
        cancelButton.SetActive(true);
        chooseNeighborNameText.SetActive(true);

        TextMeshProUGUI selectText = chooseNeighborNameText.GetComponent<TextMeshProUGUI>();
        selectText.text = gameObject.name;
        
        NeighborCanvasParent parentCanva = GetComponentInParent<NeighborCanvasParent>();
        parentCanva.SetChosenNeighbor(gameObject);

        parentCanva.transform.Find("ChooseText").gameObject.SetActive(false);

        if (gameObject.name == "Marie-Elle") {
            // Change color of characters
            parentCanva.transform.Find("Marie-Elle").gameObject.GetComponentInChildren<Image>().color = Color.white;
            parentCanva.transform.Find("Dorian").gameObject.GetComponentInChildren<Image>().color = Color.grey;
            parentCanva.transform.Find("Fern").gameObject.GetComponentInChildren<Image>().color = Color.grey;

            // Position Name & Buttons to Left Side

        }
        else if (gameObject.name == "Dorian") {
            parentCanva.transform.Find("Dorian").gameObject.GetComponentInChildren<Image>().color = Color.white;
            parentCanva.transform.Find("Marie-Elle").gameObject.GetComponentInChildren<Image>().color = Color.grey;
            parentCanva.transform.Find("Fern").gameObject.GetComponentInChildren<Image>().color = Color.grey;
        }
        else {
            parentCanva.transform.Find("Fern").gameObject.GetComponentInChildren<Image>().color = Color.white;
            parentCanva.transform.Find("Marie-Elle").gameObject.GetComponentInChildren<Image>().color = Color.grey;
            parentCanva.transform.Find("Dorian").gameObject.GetComponentInChildren<Image>().color = Color.grey;

            // Position Name & Buttons to Right Side
            if (parentCanva.transform.Find("CurrentSelection").position - buttonOriginalPosition == new Vector3(0,0,0)) {
                
            }
        } 
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // if ((gameObject.name == "Marie-Elle" && GetFashionDesignerNotSelected()) ||
        //     (gameObject.name == "Dorian" && GetVampireNurseNotSelected()) ||
        //     (gameObject.name == "Fern" && GetPitifulRobotNotSelected())) {
        //     GetComponentInChildren<Image>().color = new Color(255, 0, 0 );
        // }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        // GetComponentInChildren<Image>().color = new Color(255, 255, 255);
    }
}