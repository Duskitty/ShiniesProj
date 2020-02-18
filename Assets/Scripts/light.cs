using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
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
//<<<<<<< HEAD
        //RayCastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        //Debug.DrawLine(transform.position, attackpoint);
//=======
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        Debug.DrawLine(transform.position, hit.point);
//>>>>>>> 14e0c4edc7ff5b1fa93dd4104aa51eb6d5341d55

    }
}
