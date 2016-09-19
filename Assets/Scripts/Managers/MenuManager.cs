using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRTK;

public class MenuManager : MonoBehaviour
{

    void Start()
    {
        GameObject.FindGameObjectWithTag(Tags.LEVER_WARP_DRIVE).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HyperDriveLeverListener);
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
        GameObject.FindGameObjectWithTag(Tags.PARTICLES).GetComponent<ParticleSystem>().Play();

        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(Scenes.GAME_SCENE);
    }

    void OnDisable()
    {
        //GameObject.FindGameObjectWithTag(Tags.LEVER_HYPER_DRIVE).GetComponentInChildren<VRTK_Control>().defaultEvents.OnValueChanged.RemoveListener(HyperDriveLeverListener);
    }
}
