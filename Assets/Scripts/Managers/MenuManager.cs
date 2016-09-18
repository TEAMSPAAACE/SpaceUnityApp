using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRTK;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject steamVRRig;
    [SerializeField]
    private GameObject steamVRHelper;

    void Start()
    {
        var steamVRRigInstance = GameObject.FindGameObjectsWithTag(Tags.STEAMVR);

        if (steamVRRigInstance.Length == 0)
        {
            DontDestroyOnLoad((GameObject)Instantiate(steamVRRig, Vector3.zero, Quaternion.identity));
            DontDestroyOnLoad((GameObject)Instantiate(steamVRHelper, Vector3.zero, Quaternion.identity));
        }

        GameObject.FindGameObjectWithTag(Tags.LEVER_HYPER_DRIVE).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HyperDriveLeverListener);
    }

    
    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(Scenes.GAME_SCENE);
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

        SceneManager.LoadScene(Scenes.GAME_SCENE);
    }

    void OnDisable()
    {

    }
}
