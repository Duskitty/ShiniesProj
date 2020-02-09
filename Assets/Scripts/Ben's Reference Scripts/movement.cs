using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 0f;
    public float turnSpeed = 0f;
    private float verticalMovment = 20f;
    public GameObject weapon;
    public float weaponForce = 0f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate( -Time.deltaTime * speed, 0f, 0f);

          //  rb.AddRelativeForce(new Vector2(-1*verticalMovment*Time.deltaTime*speed, 0f));
        
        
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(  Time.deltaTime * speed, 0f, 0f);

           // rb.AddRelativeForce(new Vector2(verticalMovment * Time.deltaTime*speed, 0f));


        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f,   -Time.deltaTime * speed, 0f);
            //  rb.AddRelativeForce(new Vector2(0f, -1*horizontalMovment*Time.deltaTime*speed));


        }
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(0f,  Time.deltaTime * speed, 0f);

         //   rb.AddRelativeForce(new Vector2(0f,  verticalMovment * Time.deltaTime*speed));
        
        }
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        //transform.Translate(0f, vertical * Time.deltaTime*speed, 0f);
        //transform.Rotate(0f,0f,horizontal * Time.deltaTime * turnSpeed);

        //rb.AddRelativeForce(new Vector2(0f, vertical * Time.deltaTime * speed));
        //rb.AddTorque(horizontal * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.Space)) {
            GameObject newWeapon = Instantiate(weapon, transform.position, transform.rotation);
            newWeapon.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -weaponForce));
        
        }
    
    }
}
