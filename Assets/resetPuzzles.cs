using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPuzzles : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetL1P2()
    {
      GameObject.Find("rock00").transform.position = GameObject.Find("rock00Pos").transform.position;
      GameObject.Find("rock00").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
      GameObject.Find("rock01").transform.position = GameObject.Find("rock01Pos").transform.position;
      GameObject.Find("rock01").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
      GameObject.Find("rock02").transform.position = GameObject.Find("rock02Pos").transform.position;
      GameObject.Find("rock02").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
    }

    public void resetL2P2()
    {
      GameObject.Find("miragePyramid00").transform.position = GameObject.Find("mPyramid00Pos").transform.position;
      GameObject.Find("miragePyramid00").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
      GameObject.Find("miragePyramid01").transform.position = GameObject.Find("mPyramid01Pos").transform.position;
      GameObject.Find("miragePyramid01").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
    }

  public void resetL3P1()
  {
    GameObject.Find("RedCrystal").transform.position = GameObject.Find("RedCrystalPos").transform.position;
    GameObject.Find("RedCrystal").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
    GameObject.Find("BlueCrystal").transform.position = GameObject.Find("BlueCrystalPos").transform.position;
    GameObject.Find("BlueCrystal").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
    GameObject.Find("GreenCrystal").transform.position = GameObject.Find("GreenCrystalPos").transform.position;
    GameObject.Find("GreenCrystal").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
    GameObject.Find("L3P1Manager").GetComponent<L3P1Manager>().resetDoor();
  }
}
