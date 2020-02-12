using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmeraFollow : MonoBehaviour
{
    public GameObject target;
    public float smoothSpeed = 0f;
    public Vector3 offset;
    public Vector3 moveOffset;
    public float lookAhead;

    public float distanceProblem;

    PlayerMovment pm;

    void Start()
    {
        pm = target.GetComponent<PlayerMovment>();
    }

    void FixedUpdate()
    {
        Vector3 desiredPostion = target.transform.position + offset + (pm.moveDirection * pm.speedPerFrame * -1 * lookAhead);

        distanceProblem = Vector3.Distance(transform.position, desiredPostion);
        if (distanceProblem < 100)
        {
            Vector3 smoothPosion = Vector3.Lerp(transform.position, desiredPostion, smoothSpeed * Time.deltaTime);

            transform.position = smoothPosion;
        }
        else
        {
            transform.position = desiredPostion;
        }

    }
}
