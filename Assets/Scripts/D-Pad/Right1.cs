using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right1 : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isUsingDPad = false;
    GameObject player;
    Animator animator;
    private float speed = 5f;
    bool isRight = false;
    Touch touch;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (Input.GetMouseButtonDown(0) && touch.position.x == transform.position.x && touch.position.y == transform.position.y)
            {
                Debug.Log("true");
                OnMouseDown();

            }
            if (Input.GetMouseButtonUp(0))
            {

                isRight = false;
                isUsingDPad = false;
            }
        }
    }

    void OnMouseDown()
    {
        player.transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));


        isUsingDPad = true;
        animator.SetBool("isRight", true);
        animator.SetBool("isLeft", false);
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isMoving", true);

        PlayerMovement.isMovingUp = false;
        PlayerMovement.isMovingDown = false;
        PlayerMovement.isMovingLeft = false;
        PlayerMovement.isMovingRight = true;
        isRight = true;

    }
}

