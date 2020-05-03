using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDPad : MonoBehaviour
{
    public void EnablePad() {
        GameObject.Find("DownButon").GetComponent<Down1>().enabled = true;
        GameObject.Find("UpButon").GetComponent<Up1>().enabled = true;
        GameObject.Find("LeftButon").GetComponent<Left1>().enabled = true;
        GameObject.Find("RightButon").GetComponent<Right1>().enabled = true;
    }
    public void DisablePad() {
        GameObject.Find("DownButon").GetComponent<Down1>().enabled = false;
        GameObject.Find("UpButon").GetComponent<Up1>().enabled = false;
        GameObject.Find("LeftButon").GetComponent<Left1>().enabled = false;
        GameObject.Find("RightButon").GetComponent<Right1>().enabled = false;





    }
}
