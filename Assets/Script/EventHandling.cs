using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandling : MonoBehaviour {
    static Manager manager;
    public bool IsClicked = false;
    public int type; 
    // 1 sun 2 water 3 insects 4 animal
    //5 Human 6 Soil 7 Wind 8 Pesticide
    // Use this for initialization
    void Start () {
        manager = GameObject.Find("EventSystem").GetComponent<Manager>();
    }

    public void ClickMe()
    {
        if (Manager.IsEvoluting == true)
            return;
        if (IsClicked == false)
        {
            Manager.itemNo++;
            manager.UpdateText();
            IsClicked = true;
            UpdateButtonColor();
           // Debug.Log("true " + type);
        }
        else
        {
            Manager.itemNo--;
            manager.UpdateText();
            IsClicked = false;
          //  Debug.Log("false " + type);
            UpdateButtonColor();
        }
    }

   public void UpdateButtonColor()
    {
        if(IsClicked==true)
            this.gameObject.GetComponent<Image>().color = Color.grey;
        else
            this.gameObject.GetComponent<Image>().color = Color.white;
    }
}
