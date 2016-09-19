using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRTK;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int warpDriveGaugeAmount;
    public float countdownTimer;

    [SerializeField]
    private float gameSessionLength = 90f; // 1.5 minute game session
    [SerializeField]
    private string warpReadyText = "Warp Ready!";

    private TaskTextUpdater taskTextUpdater;
    private WarpGaugeTextUpdater warpGaugeTextUpdater;
    private bool justLost;

    private Vector3 foo;
    private Transform sun;
    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    void OnEnable()
    {
        foo = new Vector3(.2f, .2f, .2f);
        sun = GameObject.FindGameObjectWithTag(Tags.SUN).transform;

        countdownTimer = gameSessionLength;
        taskTextUpdater = GameObject.FindGameObjectWithTag(Tags.TASK_TICKER_TEXT).GetComponent<TaskTextUpdater>();
        warpGaugeTextUpdater = GameObject.FindGameObjectWithTag(Tags.WARP_GAUGE_TEXT).GetComponent<WarpGaugeTextUpdater>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(Scenes.MAIN_MENU);
        }

        if (countdownTimer > 0f)
        {
            sun.localScale += foo * Time.deltaTime;
            countdownTimer -= Time.deltaTime;
        }
        
        if (countdownTimer <= 0f && !justLost)
        {
            taskTextUpdater.SetTickerText("You lose.");
            justLost = true;
            //SceneManager.LoadScene(Scenes.MAIN_MENU);
            //return;
        }
	}

    public void UpdateWarpDriveGauge(bool taskStatus, string taskTag)
    {
        if (taskStatus)
        {
            warpDriveGaugeAmount += 10; //TODO unhardcode this
        }
        else
        {
            if (warpDriveGaugeAmount >= 5)
                warpDriveGaugeAmount -= 5;
        }

        Debug.Log("warpDrive " + warpDriveGaugeAmount);
        warpGaugeTextUpdater.SetWarpGaugeText(warpDriveGaugeAmount);

        if (warpDriveGaugeAmount >= 100)
        {
            GameObject.FindGameObjectWithTag(Tags.LEVER_WARP_DRIVE).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HyperDriveLeverListener);
            taskTextUpdater.SetTickerText(warpReadyText);
        }
    }

    public void HyperDriveLeverListener(float value, float normalizedValue)
    {
        if (normalizedValue == 100)
        {
            StartCoroutine(HyperDriveDelay());
        }
    }

    IEnumerator HyperDriveDelay()
    {
        taskTextUpdater.SetTickerText("You managed to escape!");

        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

    /*
    void OnDisable()
    {
        GameObject.FindGameObjectWithTag(Tags.LEVER_HYPER_DRIVE).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.RemoveAllListeners();
    }
    */
}
