using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    List<GameObject> AllButtons;
    public static int itemNo = 0;
    public static int RoundNo = 1;
    string things = "You have chosen ";
    List<int> thisRoundWeHave;
    static Text ItemText;
    List<GameObject> plants;
    float waitingTest =5f; //1.5f

    object[] parms2;
    AudioSource audio;
    float timeNo = 0;
    Sprite plant2Sprite;
    public static bool IsEvoluting = false;

    //stage
    Stage stage2;

    void Start () {
        plants = new List<GameObject>();
        AllButtons = new List<GameObject>();
        GameObject game1 = GameObject.Find("LeftCanvas");
        AllButtons.Add(game1.transform.GetChild(0).gameObject);
        AllButtons.Add(game1.transform.GetChild(1).gameObject);
        AllButtons.Add(game1.transform.GetChild(2).gameObject);
        AllButtons.Add(game1.transform.GetChild(3).gameObject);
        game1 = GameObject.Find("RightCanvas");
        AllButtons.Add(game1.transform.GetChild(0).gameObject);
        AllButtons.Add(game1.transform.GetChild(1).gameObject);
        AllButtons.Add(game1.transform.GetChild(2).gameObject);
        AllButtons.Add(game1.transform.GetChild(3).gameObject);
        ItemText = GameObject.Find("ItemNumber").GetComponent<Text>();

        audio = GetComponent<AudioSource>();
        for(int i = 1; i < 8; i++)
        {
            plants.Add(GameObject.Find("Seed"+i));
            plants[i - 1].SetActive(false);
        }
        plants[0].SetActive(true);
        stage2 = GameObject.Find("StageHandler").GetComponent<Stage>();
}
   public void UpdateText()
    {
        ItemText.text = things + itemNo;
    }
    public void Reset()//confirm
    {
        if (IsEvoluting == true)
            return;
        IsEvoluting = false;
        foreach (GameObject buttonObj in AllButtons)
        {
            buttonObj.GetComponent<EventHandling>().IsClicked = false;
            buttonObj.GetComponent<EventHandling>().UpdateButtonColor();
        }
        itemNo = 0;
        UpdateText();
    }

    public void Confirm()
    {
        if (IsEvoluting == true)
            return;
        thisRoundWeHave = new List<int>();
        foreach (GameObject buttonObj in AllButtons)
        {   if(buttonObj.GetComponent<EventHandling>().IsClicked==true)
                thisRoundWeHave.Add(buttonObj.GetComponent<EventHandling>().type);
        }
        switch (RoundNo)
        {
            case 1:
                if(thisRoundWeHave.Contains(1))
                    if(thisRoundWeHave.Contains(2))
                        if (thisRoundWeHave.Contains(6))
                        {   
                            object[] parms = new object[3] {5.0f, plants[1], plants[0]};
                                StartCoroutine("CallEvolution", parms);
                        }
                Reset();
                break;
            case 2:
                    if (thisRoundWeHave.Contains(2))
                        if (thisRoundWeHave.Contains(6))
                        {
                            object[] parms = new object[3] { 5.0f, plants[2], plants[1] };
                            StartCoroutine("CallEvolution", parms);
                        }
                Reset();
                break;
            case 3:
                if (thisRoundWeHave.Contains(4))
                    if (thisRoundWeHave.Contains(8))
                      if (thisRoundWeHave.Contains(7))
                        {
                            object[] parms = new object[3] { 5.0f, plants[3], plants[2] };
                            StartCoroutine("CallEvolution", parms);
                        }
                Reset();
                break;
            case 4:
                    if (thisRoundWeHave.Contains(1))
                        if (thisRoundWeHave.Contains(7))
                        {
                            object[] parms = new object[3] { 5.0f, plants[4], plants[3] };
                            StartCoroutine("CallEvolution", parms);
                        }
                Reset();
                break;
            case 5:
                if (thisRoundWeHave.Contains(1))
                    if (thisRoundWeHave.Contains(3))
                      if (thisRoundWeHave.Contains(7))
                          if (thisRoundWeHave.Contains(5))
                            {
                                object[] parms = new object[3] { 5.0f, plants[5], plants[4] };
                                StartCoroutine("CallEvolution", parms);
                            }
                Reset();
                break;
            case 6:
                if (thisRoundWeHave.Contains(6))
                    if (thisRoundWeHave.Contains(2))
                        if (thisRoundWeHave.Contains(5))
                        {
                            object[] parms = new object[3] { 5.0f, plants[6], plants[5] };
                            StartCoroutine("CallEvolution", parms);
                        }
                Reset();
                break;
            case 7:
                if (thisRoundWeHave.Contains(2))
                    if (thisRoundWeHave.Contains(4))
                    {
                        object[] parms = new object[3] { 5.0f, plants[7], plants[6] };
                        StartCoroutine("CallEvolution", parms);
                    }
                Reset();
                break;
        }
        if (RoundNo == 8)
            Debug.Log("testing");
        
    }
   
    IEnumerator CallEvolution(object[] parms)
    {
        audio.Play();
        parms2 = parms;
        RoundNo++;
        while (true)
        {
            IsEvoluting = true;
            if ((float)parms2[0] <= 0.01)
            {
                IsEvoluting = false;
                break;
            }
            timeNo += 0.95f;
            parms2[0] = (float)parms2[0] / waitingTest;
           // Debug.Log("parm2[0] " + (float)parms2[0] +" time "+ timeNo);
            StartCoroutine("SlowingDown", parms2);
            yield return new WaitForSeconds(0.95f);
        }
    }

    IEnumerator SlowingDown(object[] parms)
    {
        float time = (float)parms[0];
        GameObject nextSeed = (GameObject)parms2[1];
        GameObject currentSeed = (GameObject)parms2[2];
    
        while (true)
        {
            if ((float)parms2[0] <= 0.01)
            {
                nextSeed.SetActive(true); currentSeed.SetActive(false);
  
                IsEvoluting = false;
                stage2.CallIE();
                Reset();
                Debug.Log(" "+ RoundNo+ " Evoluting is false");
                break;
            }
            if (currentSeed.activeSelf==true)
            {
                nextSeed.SetActive(true);currentSeed.SetActive(false);
            }
            else
            {
                nextSeed.SetActive(false); currentSeed.SetActive(true);
            }
            yield return new WaitForSeconds(time);
        }
    }
}
