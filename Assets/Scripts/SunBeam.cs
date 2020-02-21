using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBeam : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform lightHit;
    public Transform beam1;
    public Transform beam2;
    public Transform beam3;

  // Start is called before the first frame update
  void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = true;
        beam1.GetComponent<Renderer>().enabled = false;
        beam2.GetComponent<Renderer>().enabled = false;
        beam3.GetComponent<Renderer>().enabled = false;
  }

  // Update is called once per frame
  void Update()
  {
    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up));
    if(hit.collider != null)
    {
      Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up));
      lightHit.position = hit.point;
      lineRenderer.SetPosition(0, transform.position);
      lineRenderer.SetPosition(1, lightHit.position);
      lineRenderer.enabled = true;

      if(hit.collider.name == "Gold Man")
      {
        beam1.GetComponent<Renderer>().enabled = true;
        beam2.GetComponent<Renderer>().enabled = true;
        beam3.GetComponent<Renderer>().enabled = true;
      }
      else
      {
        
      }
    }

    else
    {
      lineRenderer.enabled = false;
      beam1.GetComponent<Renderer>().enabled = false;
      beam2.GetComponent<Renderer>().enabled = false;
      beam3.GetComponent<Renderer>().enabled = false;
    }
  }
}
