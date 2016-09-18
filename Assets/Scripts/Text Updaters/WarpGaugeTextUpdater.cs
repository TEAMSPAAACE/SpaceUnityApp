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

    public void SetWarpGaugeText(int currentWarpGaugeValue)
    {
        text.text = "Warp Recharge at " + currentWarpGaugeValue.ToString() + "%";
    }
}

