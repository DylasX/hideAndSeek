using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<string> sentences;
    //Queue FIFO
    public Text nameText;
    public Text descriptionText;
    public Animator animator;
    public GameObject Panel;
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (sentences.Count > 0 && Input.GetKeyDown("e"))
        {
            DisplayNextSentence();
        }else if (Input.GetKeyDown("e") && Panel.activeInHierarchy)
        {
            EndDialogue();
        }
    }

    // Update is called once per frame
    public void StartDialogue(Dialog dialogue)
    {
        Panel.SetActive(true);
        sentences.Clear();
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        descriptionText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void EndDialogue()
    {
       animator.SetBool("IsOpen", false);
    }

    IEnumerator TypeSentence (string sentence) {
        descriptionText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            descriptionText.text += letter;
            yield return letter;
        }
    }
}
