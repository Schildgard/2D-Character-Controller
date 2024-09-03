using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private CharacterController playerController;
    private Animator animator;
    private bool isWalking;
    private bool isRunning;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (playerController == null || animator == null)
        {
            Debug.Log("AnimationHandlingScript could not find Player Controller Script or Animator on GameObject");
            return;
        }

        isWalking = playerController.HorizontalInput != 0;
        if (animator.GetBool("isWalking") != isWalking)
        {
            animator.SetBool("isWalking", isWalking);
        }

        isRunning = playerController.IsRunning;
        if (animator.GetBool("isRunning") != isRunning)
        {
            animator.SetBool("isRunning", isRunning);
        }
    }
}
