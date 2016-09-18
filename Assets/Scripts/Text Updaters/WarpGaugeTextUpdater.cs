using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WarpGaugeTextUpdater : MonoBehaviour {

    private Text text;
    private string taskText;

    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    public void SetWarpGaugeText(int currentValue)
    {
        text.text = "Warp Recharge at " + currentValue.ToString() + "%";
    }
}

