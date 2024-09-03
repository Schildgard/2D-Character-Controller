using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.gameObject.tag == "Player" && !dialogueBox.activeSelf)
        {
            dialogueBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (_collision.gameObject.tag == "Player" && dialogueBox.activeSelf)
        {
            dialogueBox.SetActive(false);
        }
    }
}
