using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRTK;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float gameTime;
    private int hyperDriveGauge;

    void Awake()
    {
        var steamVRRigInstance = GameObject.FindGameObjectsWithTag(Tags.STEAMVR);

        if (steamVRRigInstance.Length == 0)
        {
            SceneManager.LoadScene(Scenes.MAIN_MENU);
            return;
        }

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
        gameTime += Time.deltaTime;
        //TODO scale the sun or new GO with coroutine
	}

    public void UpdateHypeDriveGauge(bool taskStatus, string taskTag)
    {
        //TODO stuff
    }
}
