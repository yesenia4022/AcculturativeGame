using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueUI : MonoBehaviour//NewBehaviourScript
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;


    private TypeWriterEffect typewritterEffect;


    private void Start(){
        typewritterEffect = GetComponent<TypeWriterEffect>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);

    }

    public void ShowDialogue(DialogueObject dialogueObject){
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject){
        //yield return new WaitForSeconds(2);

        foreach (string dialogue in dialogueObject.Dialogue){
            yield return typewritterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.touchCount > 0);
        }
        CloseDialogueBox();
    }

    private void CloseDialogueBox(){
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
