using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLightManager : MonoBehaviour
{
    private GameObject[] rocks;
    private RaycastHit2D[] hits;
    private Transform[] hitPoints;
    private Transform[] lightSpawnPoints;
    private Transform[] rayStartPoints;
    private LineRenderer[] beams;
    // Start is called before the first frame update
    void Start()
    {
      rocks = new GameObject[4];
      hits = new RaycastHit2D[4];
      hitPoints = new Transform[4];
      lightSpawnPoints = new Transform[4];
      rayStartPoints = new Transform[4];
      beams = new LineRenderer[4];
      rocks[0] = GameObject.Find("pushObject00");
      rocks[1] = GameObject.Find("pushObject01");
      rocks[2] = GameObject.Find("pushObject02");
      rocks[3] = GameObject.Find("pushObject03");

      for(int i = 0; i < 4; i++)
      {
        hitPoints[i] = rocks[i].transform.GetChild(1);
        lightSpawnPoints[i] = rocks[i].transform.GetChild(0);
        rayStartPoints[i] = rocks[i].transform.GetChild(2);
        beams[i] = lightSpawnPoints[i].GetComponent<LineRenderer>();
        beams[i].enabled = false;
      } 
      //Debug.Log(rocks[1].name);
    }
    // Update is called once per frame
    void Update()
    {
      hits[0] = Physics2D.Raycast(rayStartPoints[0].position, rayStartPoints[0].TransformDirection(Vector3.up));
      hitPoints[0].position = hits[0].point;
      beams[0].enabled = true;
      beams[0].SetPosition(0, lightSpawnPoints[0].position);
      beams[0].SetPosition(1, hitPoints[0].position);

      if(hits[0].collider.name == rocks[1].name)
      {
        hits[1] = Physics2D.Raycast(rayStartPoints[1].position, rayStartPoints[1].TransformDirection(Vector3.right));
        hitPoints[1].position = hits[1].point;
        beams[1].enabled = true;
        beams[1].SetPosition(0, lightSpawnPoints[1].position);
        beams[1].SetPosition(1, hitPoints[1].position);
      }
      else
      {
        beams[1].enabled = false;
      }

    if (hits[1].collider.name == rocks[2].name)
    {
      hits[2] = Physics2D.Raycast(rayStartPoints[2].position, rayStartPoints[2].TransformDirection(Vector3.down));
      hitPoints[2].position = hits[2].point;
      beams[2].enabled = true;
      beams[2].SetPosition(0, lightSpawnPoints[2].position);
      beams[2].SetPosition(1, hitPoints[2].position);
    }
    else
    {
      beams[2].enabled = false;
    }

    if (hits[2].collider.name == rocks[3].name)
    {
      hits[3] = Physics2D.Raycast(rayStartPoints[3].position, rayStartPoints[3].TransformDirection(Vector3.left));
      hitPoints[3].position = hits[3].point;
      beams[3].enabled = true;
      beams[3].SetPosition(0, lightSpawnPoints[3].position);
      beams[3].SetPosition(1, hitPoints[3].position);
    }
    else
    {
      beams[3].enabled = false;
    }

    if(hits[3].collider != null && hits[3].collider.name == rocks[0].name)
    {
      Debug.Log("You win!");
    }

      if(hits[0].collider.name == "Player")
      {
       for(int i = 1; i < 4; i++)
        {
          beams[i].enabled = false;
        }
      }
      if (hits[1].collider.name == "Player")
      {
        beams[2].enabled = false;
        beams[3].enabled = false;
      }
      if (hits[1].collider.name == "Player")
      {
        beams[3].enabled = false;
      }
  }
}
