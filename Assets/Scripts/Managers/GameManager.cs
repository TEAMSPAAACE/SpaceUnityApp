using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRTK;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private float gameTimeLimit = 180f; // 180 second game sessions

    private float gameTimeElapsed;
    
    public int hyperDriveGauge;


    void Awake()
    {
        /*
        var steamVRRigInstance = GameObject.FindGameObjectsWithTag(Tags.STEAMVR);

        if (steamVRRigInstance.Length == 0)
        {
            SceneManager.LoadScene(Scenes.MAIN_MENU);
            return;
        }
        */

        if (Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    void OnEnable()
    {
        
    }


    void Start ()
    {
	
	}
	
	void Update ()
    {
        gameTimeElapsed += Time.deltaTime;
        
        if (gameTimeElapsed >= gameTimeLimit)
        {
            Debug.Log("You lose.");
            SceneManager.LoadScene(Scenes.MAIN_MENU);
            return;
        }
	}

    public void UpdateHyperDriveGauge(bool taskStatus, string taskTag)
    {
        if (taskStatus)
        {
            hyperDriveGauge += 10; //TODO unhardcode this
        }
        else
        {
            if (hyperDriveGauge >= 5)
                hyperDriveGauge -= 5;
        }

        Debug.Log("hyperDrive " + hyperDriveGauge);

        if (hyperDriveGauge >= 100)
        {
            GameObject.FindGameObjectWithTag(Tags.LEVER_HYPER_DRIVE).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HyperDriveLeverListener);
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
        yield return new WaitForSeconds(1f);
        Debug.Log("YOU WIN OMG GOOD JOB!!!1one");
        //GameObject.FindGameObjectWithTag(Tags.LEVER_HYPER_DRIVE).GetComponentInChildren<VRTK_Control>().enabled = false;
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }
    /*
    void OnDisable()
    {
        GameObject.FindGameObjectWithTag(Tags.LEVER_HYPER_DRIVE).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.RemoveAllListeners();
    }
    */
}
