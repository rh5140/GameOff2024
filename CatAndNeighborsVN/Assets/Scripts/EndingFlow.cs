using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class EndingFlow : MonoBehaviour
{
    public static int amountSoloConvoDone;

    void Start() {
        amountSoloConvoDone = 0;
    }

    [YarnFunction("getAmountSoloConvoDone")]
    public static int GetAmountSoloConvoDone() {
        return amountSoloConvoDone;
    }

    [YarnCommand("addAmountSoloConvoDone")]
    public static void AddAmountSoloConvoDone() {
        amountSoloConvoDone += 1;
    }
}