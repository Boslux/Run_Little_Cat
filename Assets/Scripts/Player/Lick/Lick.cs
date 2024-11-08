using System.Collections;
using UnityEngine;

public class Lick : MonoBehaviour
{
    private const float LickDuration = 0.5f;
    private static readonly int LickTrigger = Animator.StringToHash("lick");

    public void Licking(Animator animator)
    {
        if (animator == null) return;

        if (Input.GetButton("Fire1"))
        {
            animator.SetBool(LickTrigger, true);
            StartCoroutine(ResetLick(animator));
        }
    }

    private IEnumerator ResetLick(Animator animator)
    {
        yield return new WaitForSeconds(LickDuration);
        animator.SetBool(LickTrigger, false);
    }
}
