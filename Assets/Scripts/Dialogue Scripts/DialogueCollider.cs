using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueCollider : MonoBehaviour
{
  public DialogueTrigger trigger;

  public void OnCollisionEnter2D(Collision2D thing)
  {
    trigger.startConversation();
    //Debug.Log("collision detected");
  }
}
