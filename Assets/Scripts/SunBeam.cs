using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBeam : MonoBehaviour
{
    
    public Transform beam1;
    public Transform beam2;
    public Transform beam3;
    public SunlightTrigger sunPatch1;
    private Animator playerDirection;
    private RaycastHit2D hit;
    // Up direction hitpoint, spawn, and linerenderer
    public Transform lightSpawnUp;
    private LineRenderer lightLineUp;
    public Transform hitPointUp;
    // Right direction hitpoint, spawn, and linerenderer
    public Transform lightSpawnRight;
    private LineRenderer lightLineRight;
    public Transform hitPointRight;
    // Left direction hitpoint, spawn, and linerenderer
    public Transform lightSpawnLeft;
    private LineRenderer lightLineLeft;
    public Transform hitPointLeft;
    // Down direction hitpoint, spawn, and linerenderer
    public Transform lightSpawnDown;
    private LineRenderer lightLineDown;
    public Transform hitPointDown;

  // Start is called before the first frame update
  void Start()
    {
        lightLineUp = lightSpawnUp.GetComponent<LineRenderer>();
        lightLineUp.enabled = true;
        lightLineUp.useWorldSpace = true;

        lightLineRight = lightSpawnRight.GetComponent<LineRenderer>();
        lightLineRight.enabled = true;
        lightLineRight.useWorldSpace = true;

        lightLineLeft = lightSpawnLeft.GetComponent<LineRenderer>();
        lightLineLeft.enabled = true;
        lightLineLeft.useWorldSpace = true;

        lightLineDown = lightSpawnDown.GetComponent<LineRenderer>();
        lightLineDown.enabled = true;
        lightLineDown.useWorldSpace = true;

        beam1.GetComponent<Renderer>().enabled = false;
        beam2.GetComponent<Renderer>().enabled = false;
        beam3.GetComponent<Renderer>().enabled = false;
        playerDirection = transform.GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (sunPatch1.inSunlight == true)
    {
      if (playerDirection.GetBool("isUp"))
      {
        hit = Physics2D.Raycast(lightSpawnUp.position, lightSpawnUp.TransformDirection(Vector3.up));
      }
      else if (playerDirection.GetBool("isRight"))
      {
        hit = Physics2D.Raycast(lightSpawnRight.position, lightSpawnRight.TransformDirection(Vector3.right));
      }
      else if (playerDirection.GetBool("isLeft"))
      {
        hit = Physics2D.Raycast(lightSpawnLeft.position, lightSpawnLeft.TransformDirection(Vector3.left));
      }
      else if (playerDirection.GetBool("isDown"))
      {
        hit = Physics2D.Raycast(lightSpawnDown.position, lightSpawnDown.TransformDirection(Vector3.down));
      }

      if (hit.collider != null)
      {
        //Debug.DrawRay(lightSpawnUp.position, lightSpawnUp.TransformDirection(Vector3.up));

        if (playerDirection.GetBool("isUp"))
        {
          hitPointUp.position = hit.point;
          lightLineUp.SetPosition(0, lightSpawnUp.position);
          lightLineUp.SetPosition(1, hitPointUp.position);
          lightLineUp.enabled = true;
          lightLineRight.enabled = false;
          lightLineLeft.enabled = false;
          lightLineDown.enabled = false;
        }
        else if (playerDirection.GetBool("isRight"))
        {
          hitPointRight.position = hit.point;
          lightLineRight.SetPosition(0, lightSpawnRight.position);
          lightLineRight.SetPosition(1, hitPointRight.position);
          lightLineUp.enabled = false;
          lightLineRight.enabled = true;
          lightLineLeft.enabled = false;
          lightLineDown.enabled = false;
        }
        else if (playerDirection.GetBool("isLeft"))
        {
          hitPointLeft.position = hit.point;
          lightLineLeft.SetPosition(0, lightSpawnLeft.position);
          lightLineLeft.SetPosition(1, hitPointLeft.position);
          lightLineUp.enabled = false;
          lightLineRight.enabled = false;
          lightLineLeft.enabled = true;
          lightLineDown.enabled = false;
        }
        else if (playerDirection.GetBool("isDown"))
        {
          hitPointDown.position = hit.point;
          lightLineDown.SetPosition(0, lightSpawnDown.position);
          lightLineDown.SetPosition(1, hitPointDown.position);
          lightLineUp.enabled = false;
          lightLineRight.enabled = false;
          lightLineLeft.enabled = false;
          lightLineDown.enabled = true;
        }


        if (hit.collider.name == "Red Man")
        {
          beam1.GetComponent<Renderer>().enabled = true;
          beam2.GetComponent<Renderer>().enabled = true;
          beam3.GetComponent<Renderer>().enabled = true;
        }
        else
        {

        }
      }
    }
    else
    {
      lightLineUp.enabled = false;
      lightLineRight.enabled = false;
      lightLineLeft.enabled = false;
      lightLineDown.enabled = false;
      beam1.GetComponent<Renderer>().enabled = false;
      beam2.GetComponent<Renderer>().enabled = false;
      beam3.GetComponent<Renderer>().enabled = false;
    }
  }
}
