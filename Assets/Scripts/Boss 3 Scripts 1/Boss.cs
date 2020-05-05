using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
	public float attackDistance = 1.5f;
	private Transform target;
	public static bool fireAttack = false;
	public static bool iceAttack = false;
    public static bool isSmashed = false;
	private int heath = 12;
	private Animator animator;
	Animator ani;
	private bool isAttack = false;
	public void SetWalk(Animator animator) {
		ani = animator;
		StartCoroutine(IdleToWalk());
	}
  //script used to rotate the boss 


	public Transform player;

	public bool isFlipped = false;
	private void Start()
	{
		animator = GetComponent<Animator>();
		target = GameObject.Find("Player").GetComponent<Transform>();

	}
	private void Update()
	{
		animator.SetBool("isWalking", false);
		
		//	LookAtPlayer();
		isAttack = false;

		if (BossFollow.isInStopDistnace == true)
		{

			int ranNumber = Random.Range(0, 2);//ran number between 0-1
			//Debug.Log(ranNumber);
			if (ranNumber == 0)
			{
				iceAttack = true;
				fireAttack = false;
				isAttack = true;
				animator.SetBool("ice", true);
				GetComponent<BossFollow>().enabled = false;
				GetComponent<Boss>().enabled = false;
				Attacking();
				StartCoroutine(IceAttack());

			}
			else if (ranNumber == 1)
				{
				fireAttack = true;
				iceAttack = false;
				isAttack = true;
				animator.SetBool("fire", true);
				GetComponent<BossFollow>().enabled = false;
				GetComponent<Boss>().enabled = false;
				Attacking();

				StartCoroutine(FireAttack());

			}


		}

	}
	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
	public IEnumerator IdleToWalk()
	{
		yield return new WaitForSeconds(2f);
		ani.SetTrigger("Walk");
		GetComponent<BossFollow>().enabled = true;
	}
	
	public IEnumerator IceAttack()
	{


		yield return new WaitForSeconds(2f);
		animator.SetBool("isWalking", true);
		animator.SetBool("ice", false);

		GetComponent<BossFollow>().enabled = true;
		GetComponent<Boss>().enabled = true;

	}
	public IEnumerator FireAttack()
	{
		yield return new WaitForSeconds(2f);
		animator.SetBool("isWalking", true);
		animator.SetBool("fire", false);

		GetComponent<BossFollow>().enabled = true;
		GetComponent<Boss>().enabled = true;

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player")&& isAttack==true && Invincible.isHit == false) {
			//do damage 
			Invincible.isHit = true;
            isSmashed = true;

			//GameControlScript.health -= 1;
		}
	}
	public void TakeDamage() {
		heath -= 1;
		GameObject.FindGameObjectWithTag("HealthBar").transform.localScale = new Vector3((heath / 12.0f), 1f, 1f);

		if (heath <= 0) {
			StartCoroutine(Death());
		}
	}
    public void PlayerDamaged()
    {
        if (isSmashed)
        {
            //do damage 
            GameControlScript.health -= 1;
            isSmashed = false;
        }
    }
	public IEnumerator Death()
	{

		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
        SceneManager.LoadScene("You Win Scene");

    }
	void Attacking() { //area of effect for the player 
		
			if (Vector2.Distance(transform.position, target.position) <= attackDistance&& Invincible.isHit==false) {
				GameControlScript.health -= 1;
			}
		
	
	}
}
