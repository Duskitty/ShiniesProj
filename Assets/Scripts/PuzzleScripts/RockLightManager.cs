using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLightManager : MonoBehaviour
{
    private GameObject[] rocks;
    private RaycastHit2D[] hits;
    private bool[] inPosition1;
    private bool[] inPosition2;
    private bool[] inPosition3;

    private GameObject zeroPos;
    private Transform zeroPosRaySpawn;
    private Transform zeroPosHitPoint;
    private Transform zeroPosLightSpawn;
    private LineRenderer zeroPosBeam;
    private GameObject firstPos;
    private Transform firstPosRaySpawn;
    private Transform firstPosHitPoint;
    private Transform firstPosLightSpawn;
    private LineRenderer firstPosBeam;
    private GameObject secondPos;
    private Transform secondPosRaySpawn;
    private Transform secondPosHitPoint;
    private Transform secondPosLightSpawn;
    private LineRenderer secondPosBeam;
    private GameObject thirdPos;
    private Transform thirdPosRaySpawn;
    private Transform thirdPosHitPoint;
    private Transform thirdPosLightSpawn;
    private LineRenderer thirdPosBeam;

    // Start is called before the first frame update
    void Start()
    {
      rocks = new GameObject[4];
      hits = new RaycastHit2D[4];
      inPosition1 = new bool[4];
      inPosition2 = new bool[4];
      inPosition3 = new bool[4];

      rocks[0] = GameObject.Find("rock00");
      rocks[1] = GameObject.Find("rock01");
      rocks[2] = GameObject.Find("rock02");
      rocks[3] = GameObject.Find("rock03");

      inPosition1[0] = false;
      inPosition1[1] = false;
      inPosition1[2] = false;
      inPosition1[3] = false;

      inPosition2[0] = false;
      inPosition2[1] = false;
      inPosition2[2] = false;
      inPosition2[3] = false;

      inPosition3[0] = false;
      inPosition3[1] = false;
      inPosition3[2] = false;
      inPosition3[3] = false;

      zeroPos = rocks[0];
      zeroPosLightSpawn = zeroPos.transform.GetChild(0);
      zeroPosHitPoint = zeroPos.transform.GetChild(1);
      zeroPosRaySpawn = zeroPos.transform.GetChild(2);
      zeroPosBeam = zeroPosLightSpawn.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      hits[0] = Physics2D.Raycast(zeroPosRaySpawn.position, zeroPosRaySpawn.TransformDirection(Vector3.up));
      zeroPosHitPoint.position = hits[0].point;
      zeroPosBeam.enabled = true;
      zeroPosBeam.SetPosition(0, zeroPosLightSpawn.position);
      zeroPosBeam.SetPosition(1, zeroPosHitPoint.position);

      if(hits[0].collider.name == rocks[1].name)
      {
        firstPos = rocks[1];
        inPosition1[1] = true;
        inPosition1[2] = false;
        inPosition1[3] = false;
      }
      else if(hits[0].collider.name == rocks[2].name)
      {
        firstPos = rocks[2];
        inPosition1[1] = false;
        inPosition1[2] = true;
        inPosition1[3] = false;
      }
      else if (hits[0].collider.name == rocks[3].name)
      {
        firstPos = rocks[3];
        inPosition1[1] = false;
        inPosition1[2] = false;
        inPosition1[3] = true;
      }
      else
      {
        inPosition1[1] = false;
        inPosition1[2] = false;
        inPosition1[3] = false;
      }

      for(int i = 1; i < 4; i++)
      {
        if (!inPosition1[i])
        {
          rocks[i].transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
        }
      }

      if (hits[0].collider.name == rocks[1].name || hits[0].collider.name == rocks[2].name || hits[0].collider.name == rocks[3].name)
      {
        firstPosLightSpawn = firstPos.transform.GetChild(0);
        firstPosHitPoint = firstPos.transform.GetChild(1);
        firstPosRaySpawn = firstPos.transform.GetChild(2);
        firstPosBeam = firstPosLightSpawn.GetComponent<LineRenderer>();

        hits[1] = Physics2D.Raycast(firstPosRaySpawn.position, firstPosRaySpawn.TransformDirection(Vector3.right));
        firstPosHitPoint.position = hits[1].point;
        firstPosBeam.enabled = true;
        firstPosBeam.SetPosition(0, firstPosLightSpawn.position);
        firstPosBeam.SetPosition(1, firstPosHitPoint.position);

        if(hits[1].collider.name == rocks[1].name)
        {
          secondPos = rocks[1];
          inPosition2[1] = true;
          inPosition2[2] = false;
          inPosition2[3] = false;
        }
        else if (hits[1].collider.name == rocks[2].name)
        {
          secondPos = rocks[2];
          inPosition2[1] = false;
          inPosition2[2] = true;
          inPosition2[3] = false;
        }
        else if (hits[1].collider.name == rocks[3].name)
        {
          secondPos = rocks[3];
          inPosition2[1] = false;
          inPosition2[2] = false;
          inPosition2[3] = true;
        }
        else
        {
          inPosition2[1] = false;
          inPosition2[2] = false;
          inPosition2[3] = false;
        }

        for (int i = 1; i < 4; i++)
        {
          if (!inPosition1[i] && !inPosition2[i])
          {
            rocks[i].transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
          }
        }

      if (hits[1].collider.name == rocks[1].name || hits[1].collider.name == rocks[2].name || hits[1].collider.name == rocks[3].name)
      {
         secondPosLightSpawn = secondPos.transform.GetChild(0);
         secondPosHitPoint = secondPos.transform.GetChild(3);
         secondPosRaySpawn = secondPos.transform.GetChild(4);
         secondPosBeam = secondPosLightSpawn.GetComponent<LineRenderer>();

         hits[2] = Physics2D.Raycast(secondPosRaySpawn.position, secondPosRaySpawn.TransformDirection(Vector3.down));
         secondPosHitPoint.position = hits[2].point;
         secondPosBeam.enabled = true;
         secondPosBeam.SetPosition(0, secondPosLightSpawn.position);
         secondPosBeam.SetPosition(1, secondPosHitPoint.position);

        if(hits[2].collider.name == rocks[1].name)
        {
          thirdPos = rocks[1];
          inPosition3[1] = true;
          inPosition3[2] = false;
          inPosition3[3] = false;
        }
        else if (hits[2].collider.name == rocks[2].name)
        {
          thirdPos = rocks[2];
          inPosition3[1] = false;
          inPosition3[2] = true;
          inPosition3[3] = false;
        }
        else if (hits[2].collider.name == rocks[3].name)
        {
          thirdPos = rocks[3];
          inPosition3[1] = false;
          inPosition3[2] = false;
          inPosition3[3] = true;
        }
        else
        {
          inPosition3[1] = false;
          inPosition3[2] = false;
          inPosition3[3] = false;
        }

        for (int i = 1; i < 4; i++)
        {
          if (!inPosition1[i] && !inPosition2[i] && !inPosition3[i])
          {
            rocks[i].transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
          }
        }

        if (hits[2].collider.name == rocks[1].name || hits[2].collider.name == rocks[2].name || hits[2].collider.name == rocks[3].name)
        {
          thirdPosLightSpawn = thirdPos.transform.GetChild(0);
          thirdPosHitPoint = thirdPos.transform.GetChild(5);
          thirdPosRaySpawn = thirdPos.transform.GetChild(6);
          thirdPosBeam = thirdPosLightSpawn.GetComponent<LineRenderer>();

          hits[3] = Physics2D.Raycast(thirdPosRaySpawn.position, thirdPosRaySpawn.TransformDirection(Vector3.left));
          thirdPosHitPoint.position = hits[3].point;
          thirdPosBeam.enabled = true;
          thirdPosBeam.SetPosition(0, thirdPosLightSpawn.position);
          thirdPosBeam.SetPosition(1, thirdPosHitPoint.position);

          if (hits[3].collider.name == rocks[0].name)
          {
            //Debug.Log("You Win!!!");
          }
        }
      }
    }
  }
}
