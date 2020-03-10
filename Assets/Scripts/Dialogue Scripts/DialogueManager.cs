using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
  public Text nameText;
  public Text lineText;
  public Animator textBoxAnimator;
  private Queue<string> dialogueLines;
  
  // Start is called before the first frame update
  void Start()
    {
    dialogueLines = new Queue<string>();
    }

  public void startDialogue(Dialogue d)
  {
    textBoxAnimator.SetBool("textboxOpen", true);
    nameText.text = d.name;

    dialogueLines.Clear();
    foreach (string line in d.dialogueLines)
    {
      dialogueLines.Enqueue(line);
    }

    displayNextLine();
  }

  public void displayNextLine()
  {
    if (dialogueLines.Count == 0)
    {
      endConversation();
      return;
    }

    string line = dialogueLines.Dequeue();
    lineText.text = line;
  }

  public void endConversation()
  {
    textBoxAnimator.SetBool("textboxOpen", false);
  }
}
