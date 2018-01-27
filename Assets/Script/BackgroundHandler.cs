using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundHandler : MonoBehaviour {

    public GameObject stagePanel;
    float a = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void openStagePanel()
    {
        stagePanel.SetActive(true);
        StartCoroutine("alphaChange");
    }

    IEnumerator alphaChange()
    {
        for (int i = 0; i < 200; i++)
        {
            a += 0.05f;
            stagePanel.GetComponent<CanvasGroup>().alpha = a;
            yield return new WaitForSeconds(0.01f);
        }

    }
}
