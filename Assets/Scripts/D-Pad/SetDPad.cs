using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDPad : MonoBehaviour
{
    public void EnablePad() {
        GameObject.Find("UpButton").GetComponent<Up1>().enabled = true;
        GameObject.Find("DownButton").GetComponent<Down1>().enabled = true;
        GameObject.Find("LeftButton").GetComponent<Left1>().enabled = true;
        GameObject.Find("RightButton").GetComponent<Right1>().enabled = true;




    }
    public void DisablePad() {
        GameObject.Find("UpButton").GetComponent<Up1>().enabled = false;
        GameObject.Find("DownButton").GetComponent<Down1>().enabled = false;
        GameObject.Find("LeftButton").GetComponent<Left1>().enabled = false;
        GameObject.Find("RightButton").GetComponent<Right1>().enabled = false;




    }
}
