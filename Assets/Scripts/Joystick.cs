using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 0.001f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            pointA = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {
        if (touchStart) {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            print(direction);
            moveCharacter(direction);
        }
    }

    void moveCharacter(Vector2 direction) {

        player.Translate(Vector2.ClampMagnitude(direction.normalized * speed * Time.deltaTime, speed));
    }
}
