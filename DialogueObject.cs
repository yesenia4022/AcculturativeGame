using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject //NewBehaviourScript
{
   [SerializeField] [TextArea] private string[] dialogue;

   public string[] Dialogue => dialogue;
}
