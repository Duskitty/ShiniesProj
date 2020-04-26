using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	private Animator animator;
	Animator ani;
	bool isIceAttack = false;
	bool isFireAttack = false;
	private float timer = 0f;
	public float waitTime = 3f;
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
		//animator.SetBool("isWalking", true);
		//animator.ResetTrigger("Ice Attack");
		GetComponent<BossFollow>().enabled = true;

		LookAtPlayer();
		timer = 0;

		if (BossFollow.isInStopDistnace == true)
		{

			int ranNumber = Random.Range(0, 2);//ran number between 0-1
			//Debug.Log(ranNumber);
			if (ranNumber == 0)
			{
				animator.SetBool("ice", true);
				GetComponent<BossFollow>().enabled = false;
				enabled = false;



			}
			else if (ranNumber == 1)
				{


					///add stuff here 

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

		animator.SetTrigger("Ice Attack");

		yield return new WaitForSeconds(2);
		animator.SetBool("isWalking", true);
		GetComponent<BossFollow>().enabled = true;

	}
	public IEnumerator FireAttack()
	{
		
		yield return new WaitForSeconds(2);
		animator.SetBool("isWalking", true);
		GetComponent<BossFollow>().enabled = true;

	}
}
