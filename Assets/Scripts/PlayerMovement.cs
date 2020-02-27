using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
    //1 is up, 2 is down, 3 is left and 4 is right
{
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public Animator animator;
    public float speed = 0f;
    public Animator textBoxAnimator;
    public Rigidbody2D player;
    public bool bridgeSafe = false;
    // Update is called once per frame
    void FixedUpdate()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        verticalMove = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        //animator.SetFloat("Speed", Mathf.Abs(verticalMove));
        if (textBoxAnimator.GetBool("isOpen"))
        {
            return;

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
            animator.SetBool("isUp", true);
            animator.SetBool("isDown", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0f, -speed * Time.deltaTime, 0f));
            animator.SetBool("isDown", true);
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isUp", false);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));
            
             animator.SetBool("isLeft", true);
            animator.SetBool("isRight", false);
            animator.SetBool("isDown", false);
            animator.SetBool("isUp", false);




        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));
           

                animator.SetBool("isRight", true);
                animator.SetBool("isLeft", false);
                 animator.SetBool("isDown", false);
            animator.SetBool("isUp", false);




        }
        /*  if (player.velocity.y == 0)
          {
              animator.SetFloat("Speed", -1);
              animator.SetBool("isDown", false);

          }*/
    }
}
