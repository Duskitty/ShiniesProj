using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLightManager2 : MonoBehaviour
{
    private GameObject orb;
    private RaycastHit2D orbHit;
    private Transform orbRaySpawn;
    private Transform orbHitPoint;
    private Transform orbLightSpawn;
    private LineRenderer orbBeam;

    private GameObject[] rocks;
    private RaycastHit2D[] hits;
    private bool[] inPosition0;
    private bool[] inPosition1;
    private bool[] inPosition2;
    //private Vector3[] beamDirections;

    private GameObject zeroPos;
    private Transform zeroPosRaySpawn;
    private Transform zeroPosHitPoint;
    private Transform zeroPosLightSpawn;
    private LineRenderer zeroPosBeam;
    private Vector3 zeroPosBeamDirection;
    private GameObject firstPos;
    private Transform firstPosRaySpawn;
    private Transform firstPosHitPoint;
    private Transform firstPosLightSpawn;
    private LineRenderer firstPosBeam;
    private Vector3 firstPosBeamDirection;
    private GameObject secondPos;
    private Transform secondPosRaySpawn;
    private Transform secondPosHitPoint;
    private Transform secondPosLightSpawn;
    private LineRenderer secondPosBeam;
    private Vector3 secondPosBeamDirection;

    // Start is called before the first frame update
    void Start()
    {
      orb = GameObject.Find("rockLightOrb");
      orbRaySpawn = orb.transform.GetChild(1);
      orbHitPoint = orb.transform.GetChild(2);
      orbLightSpawn = orb.transform.GetChild(0);
      orbBeam = orbLightSpawn.GetComponent<LineRenderer>();

      rocks = new GameObject[3];
      rocks[0] = GameObject.Find("rock00");
      rocks[1] = GameObject.Find("rock01");
      rocks[2] = GameObject.Find("rock02");

      hits = new RaycastHit2D[3];

      inPosition0 = new bool[3];
      inPosition0[0] = false;
      inPosition0[1] = false;
      inPosition0[2] = false;

      inPosition1 = new bool[3];
      inPosition1[0] = false;
      inPosition1[1] = false;
      inPosition1[2] = false;

      inPosition2 = new bool[3];
      inPosition2[0] = false;
      inPosition2[1] = false;
      inPosition2[2] = false;

      GameObject.Find("Shield").GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      orbHit = Physics2D.Raycast(orbRaySpawn.position, orbRaySpawn.TransformDirection(Vector3.up));
      orbHitPoint.position = orbHit.point;
      orbBeam.enabled = true;
      orbBeam.SetPosition(0, orbLightSpawn.position);
      orbBeam.SetPosition(1, orbHitPoint.position);

      if(orbHit.collider.name == rocks[0].name)
      {
        zeroPos = rocks[0];
        inPosition0[0] = true;
        inPosition0[1] = false;
        inPosition0[2] = false;
        zeroPosBeamDirection = zeroPos.transform.GetChild(1).TransformDirection(Vector3.right);
      }
      else if (orbHit.collider.name == rocks[1].name)
      {
        zeroPos = rocks[1];
        inPosition0[0] = false;
        inPosition0[1] = true;
        inPosition0[2] = false;
        zeroPosBeamDirection = zeroPos.transform.GetChild(1).TransformDirection(Vector3.down);
      }
      else if (orbHit.collider.name == rocks[2].name)
      {
        zeroPos = rocks[2];
        inPosition0[0] = false;
        inPosition0[1] = false;
        inPosition0[2] = true;
        zeroPosBeamDirection = zeroPos.transform.GetChild(1).TransformDirection(Vector3.left);
      }
      else
      {
        inPosition0[0] = false;
        inPosition0[1] = false;
        inPosition0[2] = false;
      }

      for (int i = 0; i < 3; i++)
      {
        if (!inPosition0[i])
        { 
          rocks[i].transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
          
        }
      }

      if (orbHit.collider.name == rocks[0].name || orbHit.collider.name == rocks[1].name || orbHit.collider.name == rocks[2].name)
      {
        zeroPosLightSpawn = zeroPos.transform.GetChild(0);
        zeroPosHitPoint = zeroPos.transform.GetChild(2);
        zeroPosRaySpawn = zeroPos.transform.GetChild(1);
        zeroPosBeam = zeroPosLightSpawn.GetComponent<LineRenderer>();

        hits[0] = Physics2D.Raycast(zeroPosRaySpawn.position, zeroPosBeamDirection);
        zeroPosHitPoint.position = hits[0].point;
        zeroPosBeam.enabled = true;
        zeroPosBeam.SetPosition(0, zeroPosLightSpawn.position);
        zeroPosBeam.SetPosition(1, zeroPosHitPoint.position);

        if (hits[0].collider.name == rocks[0].name)
        {
          firstPos = rocks[0];
          inPosition1[0] = true;
          inPosition1[1] = false;
          inPosition1[2] = false;
          firstPosBeamDirection = firstPos.transform.GetChild(1).TransformDirection(Vector3.right);
        }
        else if (hits[0].collider.name == rocks[1].name)
        {
          firstPos = rocks[1];
          inPosition1[0] = false;
          inPosition1[1] = true;
          inPosition1[2] = false;
          firstPosBeamDirection = firstPos.transform.GetChild(1).TransformDirection(Vector3.down);
        }
        else if (hits[0].collider.name == rocks[2].name)
        {
          firstPos = rocks[2];
          inPosition1[0] = false;
          inPosition1[1] = false;
          inPosition1[2] = true;
          firstPosBeamDirection = firstPos.transform.GetChild(1).TransformDirection(Vector3.left);
        }
        else
        {
          inPosition1[0] = false;
          inPosition1[1] = false;
          inPosition1[2] = false;
        }

        for (int i = 0; i < 3; i++)
        {
          if (!inPosition0[i] && !inPosition1[i])
          {
            rocks[i].transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
          }
        }

        if (hits[0].collider.name == rocks[0].name || hits[0].collider.name == rocks[1].name || hits[0].collider.name == rocks[2].name)
        { 
            //Debug.Log("hewwo");
            firstPosLightSpawn = firstPos.transform.GetChild(0);
            firstPosHitPoint = firstPos.transform.GetChild(2);
            firstPosRaySpawn = firstPos.transform.GetChild(1);
            firstPosBeam = firstPosLightSpawn.GetComponent<LineRenderer>();

            hits[1] = Physics2D.Raycast(firstPosRaySpawn.position, firstPosBeamDirection);
            firstPosHitPoint.position = hits[1].point;
            firstPosBeam.enabled = true;
            firstPosBeam.SetPosition(0, firstPosLightSpawn.position);
            firstPosBeam.SetPosition(1, firstPosHitPoint.position);

            if (hits[1].collider.name == rocks[0].name)
            {
              secondPos = rocks[0];
              inPosition2[0] = true;
              inPosition2[1] = false;
              inPosition2[2] = false;
              secondPosBeamDirection = secondPos.transform.GetChild(1).TransformDirection(Vector3.right);
            }
            else if (hits[1].collider.name == rocks[1].name)
            {
              secondPos = rocks[1];
              inPosition2[0] = false;
              inPosition2[1] = true;
              inPosition2[2] = false;
              secondPosBeamDirection = secondPos.transform.GetChild(1).TransformDirection(Vector3.down);
            }
            else if (hits[1].collider.name == rocks[2].name)
            {
              secondPos = rocks[2];
              inPosition2[0] = false;
              inPosition2[1] = false;
              inPosition2[2] = true;
              secondPosBeamDirection = secondPos.transform.GetChild(1).TransformDirection(Vector3.left);
            }
            else
            {
              inPosition2[0] = false;
              inPosition2[1] = false;
              inPosition2[2] = false;
            }

            for (int i = 0; i < 3; i++)
            {
              if (!inPosition0[i] && !inPosition1[i] && !inPosition2[i])
              {
                rocks[i].transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
              }
            }

            if (hits[1].collider.name == rocks[0].name || hits[1].collider.name == rocks[1].name || hits[1].collider.name == rocks[2].name)
            {
                secondPosLightSpawn = secondPos.transform.GetChild(0);
                secondPosHitPoint = secondPos.transform.GetChild(2);
                secondPosRaySpawn = secondPos.transform.GetChild(1);
                secondPosBeam = secondPosLightSpawn.GetComponent<LineRenderer>();

                hits[2] = Physics2D.Raycast(secondPosRaySpawn.position, secondPosBeamDirection);
                secondPosHitPoint.position = hits[2].point;
                secondPosBeam.enabled = true;
                secondPosBeam.SetPosition(0, secondPosLightSpawn.position);
                secondPosBeam.SetPosition(1, secondPosHitPoint.position);

                if(hits[2].collider.name == orb.name)
                {
                  GameObject.Find("Bush").GetComponent<SpriteRenderer>().enabled = false;
                  GameObject.Find("Bush").GetComponent<BoxCollider2D>().enabled = false;

                  if (GameObject.Find("Shield") != null)
                  {
                      //Debug.Log("here");
                      GameObject.Find("Shield").GetComponent<CircleCollider2D>().enabled = true;
                  }
                }
            }
   
          
        }
      }
    }
}
