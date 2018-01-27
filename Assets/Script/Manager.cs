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
    GameObject plant;
    float waitingTest =5f; //1.5f

    object[] parms2;
    AudioSource audio;
    float timeNo = 0;
    Sprite plant2Sprite;
    public static bool IsEvoluting = false;

    //stage
    Stage stage2;

    void Start () {
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
        plant = GameObject.Find("Seed");
        plant2Sprite = Resources.Load<Sprite>("Picture/PlantStages/stage2");
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
                            object[] parms = new object[3] {5.0f, plant2Sprite, plant.GetComponent<Image>().sprite};
                                StartCoroutine("CallEvolution", parms);
                        }
                Reset();
                break;
            case 2:
               // Reset();
                break;
                    
        }
        if (RoundNo == 8)
            Debug.Log("testing");
        
    }
   
    IEnumerator CallEvolution(object[] parms)
    {
        audio.Play();
        parms2 = parms;
        while (true)
        {
            IsEvoluting = true;
            if ((float)parms2[0] <= 0.01)
                break;
            timeNo += 0.95f;
            parms2[0] = (float)parms2[0] / waitingTest;
           // Debug.Log("parm2[0] " + (float)parms2[0] +" time "+ timeNo);
            StartCoroutine("SlowingDown", parms2);
            yield return new WaitForSeconds(0.95f);
        }
    }

    IEnumerator SlowingDown(object[] parms)
    {
        Sprite plantSp = plant.GetComponent<Image>().sprite;
        float time = (float)parms[0];
        Sprite nextSp = (Sprite)parms[1];
        Sprite currentSp = (Sprite)parms[2];

        while (true)
        {
            if ((float)parms2[0] <= 0.01)
            {
                plant.GetComponent<Image>().sprite = nextSp;
                RoundNo++;
                IsEvoluting = false;
                stage2.CallIE();
                Reset();
                Debug.Log(" "+ RoundNo);
                break;
            }
            if (plantSp == currentSp)
            {

                plant.GetComponent<Image>().sprite = nextSp;
            }
            else
            {
                plant.GetComponent<Image>().sprite = currentSp;
            }
            yield return new WaitForSeconds(time);
        }
    }
}
