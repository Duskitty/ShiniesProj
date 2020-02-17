using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform lightHit;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer =GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //RayCastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        //Debug.DrawLine(transform.position, attackpoint);

    }
}
