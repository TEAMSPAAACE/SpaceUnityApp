using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskTextUpdater : MonoBehaviour {

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(UpdateTextDelay());
    }
	
	void Update()
    {
        StartCoroutine(TextUpdateDelay());
    }

    IEnumerator TextUpdateDelay()
    {
        yield return new WaitForSeconds(.1f);
        Debug.Log("YOU WIN OMG GOOD JOB!!!1one");
        //GameObject.FindGameObjectWithTag(Tags.LEVER_HYPER_DRIVE).GetComponentInChildren<VRTK_Control>().enabled = false;
        SceneManager.LoadScene(Scenes.MAIN_MENU);
    }
}
