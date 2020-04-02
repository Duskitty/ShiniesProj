using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    public GameObject other;

    void Swap()
    {
        Vector3 temp = transform.position;
        transform.position = other.transform.position;
        other.transform.position = temp;
    }
}
