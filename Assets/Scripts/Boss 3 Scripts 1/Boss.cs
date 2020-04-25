using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

	Animator ani;

	public void SetWalk(Animator animator) {
		ani = animator;
		StartCoroutine(IdleToWalk());
	}
  //script used to rotate the boss 


	public Transform player;

	public bool isFlipped = false;
	private void Start()
	{
		
	}
	private void Update()
	{
		
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
	public void PlayIce(Animator anim) {
		ani = anim;
	}
	public IEnumerator IceAttack()
	{
		yield return new WaitForSeconds(2);
		ani.SetBool("isWalking", true);
	}
}
