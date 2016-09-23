using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRTK;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int warpDriveGaugeAmount;
    public float countdownTimer;
    public float gameSessionLength = 120f; // 2 minute game session

    [SerializeField]
    private string warpReadyText = "Warp Ready!";

    private TaskTextUpdater taskTextUpdater;
    private WarpGaugeTextUpdater warpGaugeTextUpdater;
    private bool gameOver;

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

        if (countdownTimer > 0f && !gameOver)
        {
            sun.position += sun.forward * 0.1f * Time.deltaTime;
            countdownTimer -= Time.deltaTime;
        }
        
        if (countdownTimer <= 0f && !gameOver)
        {
            taskTextUpdater.SetTickerText("You lose.");
            gameOver = true;
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

        warpGaugeTextUpdater.SetWarpGaugeText(warpDriveGaugeAmount);

        if (warpDriveGaugeAmount == 50)
            GameObject.FindGameObjectWithTag(Tags.WARP_GAUGE_TEXT).GetComponent<WarpAudioManager>().playHalfChargeAudio();

        if (warpDriveGaugeAmount >= 100)
        {
            GameObject.FindGameObjectWithTag(Tags.WARP_GAUGE_TEXT).GetComponent<WarpAudioManager>().playFullChargeAudio();
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
        gameOver = true;
        taskTextUpdater.SetTickerText("You managed to escape!");

        yield return new WaitForSeconds(10f);

        //SceneManager.LoadScene(Scenes.MAIN_MENU);
    }

    /*
    void OnDisable()
    {
        GameObject.FindGameObjectWithTag(Tags.LEVER_HYPER_DRIVE).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.RemoveAllListeners();
    }
    */
}
