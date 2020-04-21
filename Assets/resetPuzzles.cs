using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPuzzles : MonoBehaviour
{
  private GameObject l2p2Manager;
    // Start is called before the first frame update
    void Start()
    {
      l2p2Manager = GameObject.Find("L2P2Manager");
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
      /*GameObject.Find("mirageOrb00").GetComponent<Animator>().SetBool("isLit", false);
      GameObject.Find("mirageOrb01").GetComponent<Animator>().SetBool("isLit", false);*/
      //GameObject.Find("mirageOrb00").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
      //GameObject.Find("mirageOrb01").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;

      GameObject.Find("miragePyramid00").transform.position = GameObject.Find("mPyramid00Pos").transform.position;
      GameObject.Find("miragePyramid00").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
      GameObject.Find("miragePyramid01").transform.position = GameObject.Find("mPyramid01Pos").transform.position;
      GameObject.Find("miragePyramid01").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;

    }
}
