using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour

{
    public float speed = 0f;
    public Animator textBoxAnimator;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (textBoxAnimator.GetBool("isOpen")){
            return;

        }
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(new Vector3(0f, speed * Time.deltaTime,0f));


        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0f, -speed * Time.deltaTime,0f));


        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed*Time.deltaTime,0f,0f));

            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed*Time.deltaTime,0f,0f));


        }
    }
 
}
