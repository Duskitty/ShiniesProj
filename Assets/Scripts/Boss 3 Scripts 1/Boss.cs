using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	public static bool fireAttack = false;
	public static bool iceAttack = false;
	public static int heath = 1;
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
	}
	private void Update()
	{
		TakeDamage();
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
		yield return new WaitForSeconds(5);
		ani.SetTrigger("Walk");
		GetComponent<BossFollow>().enabled = true;
	}
	
	public IEnumerator IceAttack()
	{


		yield return new WaitForSeconds(5);
		animator.SetBool("isWalking", true);
		animator.SetBool("ice", false);

		GetComponent<BossFollow>().enabled = true;
		GetComponent<Boss>().enabled = true;

	}
	public IEnumerator FireAttack()
	{
		
		yield return new WaitForSeconds(5);
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
			GameControlScript.health -= 1;
		}
	}
	public void TakeDamage() {
		
		Debug.Log("Boss has" + heath);
		if (heath <= 0) {
			Destroy(this.gameObject);
		
		}
	}
}
