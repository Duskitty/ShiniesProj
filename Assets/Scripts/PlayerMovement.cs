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
  private bool isMovingUp = false;
  public bool hasShield = false;
  bool isMovingDown = false;
  bool isMovingRight = false;
  bool isMovingLeft = false;

  private AudioSource audioSrc;
  private bool isSprinting;
  public float walkSpeed;
  public float sprintSpeed;

  // Update is called once per frame
  private void Update()
  {
    /*if (animator.GetBool("hasShield"))
    { animator.SetBool("HasShield", true); }
    else
    {
      animator.SetBool("HasShield", false);
    }*/

    horizontalMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
    verticalMove = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
    //animator.SetFloat("Speed", Mathf.Abs(verticalMove));
    //if (textBoxAnimator.GetBool("isOpen"))
    //{
    //return;

    //}

    if (textBoxAnimator.GetBool("textboxOpen"))
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
      animator.SetBool("isMoving", true);

      isMovingUp = true;
      isMovingDown = false;
      isMovingLeft = false;
      isMovingRight = false;

      if (Input.GetKey(KeyCode.LeftShift))
      {
        Debug.Log("Sprinting");
        transform.Translate(new Vector3(0f, sprintSpeed * Time.deltaTime, 0f));
        GetComponent<PlayerMelee>().setSprint(true);

      }
      else
      {
        GetComponent<PlayerMelee>().setSprint(false);


      }


    }
    if (Input.GetKey(KeyCode.S))
    {
      transform.Translate(new Vector3(0f, -speed * Time.deltaTime, 0f));
      animator.SetBool("isDown", true);
      animator.SetBool("isRight", false);
      animator.SetBool("isLeft", false);
      animator.SetBool("isUp", false);
      animator.SetBool("isMoving", true);

      isMovingUp = false;
      isMovingDown = true;
      isMovingLeft = false;
      isMovingRight = false;

      if (Input.GetKey(KeyCode.LeftShift))
      {
        transform.Translate(new Vector3(0f, -sprintSpeed * Time.deltaTime, 0f));
        GetComponent<PlayerMelee>().setSprint(true);

      }
      else
      {
        GetComponent<PlayerMelee>().setSprint(false);

      }




    }
    if (Input.GetKey(KeyCode.A))
    {
      transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));

      animator.SetBool("isLeft", true);
      animator.SetBool("isRight", false);
      animator.SetBool("isDown", false);
      animator.SetBool("isUp", false);
      animator.SetBool("isMoving", true);

      isMovingUp = false;
      isMovingDown = false;
      isMovingLeft = true;
      isMovingRight = false;

      if (Input.GetKey(KeyCode.LeftShift))
      {
        transform.Translate(new Vector3(-sprintSpeed * Time.deltaTime, 0f, 0f));
        GetComponent<PlayerMelee>().setSprint(true);

      }
      else
      {

        GetComponent<PlayerMelee>().setSprint(false);

      }




    }
    if (Input.GetKey(KeyCode.D))
    {
      transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));


      animator.SetBool("isRight", true);
      animator.SetBool("isLeft", false);
      animator.SetBool("isDown", false);
      animator.SetBool("isUp", false);
      animator.SetBool("isMoving", true);

      isMovingUp = false;
      isMovingDown = false;
      isMovingLeft = false;
      isMovingRight = true;


      if (Input.GetKey(KeyCode.LeftShift))
      {
        transform.Translate(new Vector3(sprintSpeed * Time.deltaTime, 0f, 0f));
        GetComponent<PlayerMelee>().setSprint(true);

      }
      else
      {
        GetComponent<PlayerMelee>().setSprint(false);


      }



    }

    if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
    {//no input
      if (isMovingUp == true)
      {
        animator.SetBool("isIdleUp", true);
        animator.SetBool("isIdleDown", false);
        animator.SetBool("isIdleRight", false);
        animator.SetBool("isIdleLeft", false);
        animator.SetBool("isMoving", false);
        animator.SetBool("isUp", false);
        //Debug.Log("Not Moving Up");


      }

      if (isMovingLeft == true)
      {

        animator.SetBool("isIdleUp", false);
        animator.SetBool("isIdleDown", false);
        animator.SetBool("isIdleRight", false);
        animator.SetBool("isIdleLeft", true);
        animator.SetBool("isMoving", false);
        animator.SetBool("isUp", false);
        //  Debug.Log("Not Moving Left");


      }
      if (isMovingRight == true)
      {
        animator.SetBool("isIdleUp", false);
        animator.SetBool("isIdleDown", false);
        animator.SetBool("isIdleRight", true);
        animator.SetBool("isIdleLeft", false);
        animator.SetBool("isMoving", false);
        animator.SetBool("isUp", false);
        // Debug.Log("Not Moving Right");



      }
      if (isMovingDown == true)
      {
        animator.SetBool("isIdleUp", false);
        animator.SetBool("isIdleDown", true);
        animator.SetBool("isIdleRight", false);
        animator.SetBool("isIdleLeft", false);
        animator.SetBool("isMoving", false);
        animator.SetBool("isUp", false);

      }



    }


    
  }
  
}
