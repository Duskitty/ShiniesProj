using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GameObject.Find("Gnome").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Gnome").GetComponent<Boss>().SetWalk(animator);
        }

    }
}
