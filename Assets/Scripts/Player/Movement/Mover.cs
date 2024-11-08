using UnityEngine;

public class Mover : MonoBehaviour
{
    private static readonly int RunSpeedParam = Animator.StringToHash("run");
    private static readonly int RunningBoolParam = Animator.StringToHash("running");

    public void Movement(float speed, Rigidbody2D rb, Animator anim)
    {
        if (rb == null || anim == null) return;

        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(hMove, vMove).normalized * speed * Time.fixedDeltaTime;
        rb.linearVelocity = movement; // Obsolete hatası düzeltildi

        UpdateAnimation(anim, rb, hMove);
    }

    private void UpdateAnimation(Animator anim, Rigidbody2D rb, float horizontalMove)
    {
        anim.SetFloat(RunSpeedParam, rb.linearVelocity.magnitude); // Burada da linearVelocity kullanıldı

        if (horizontalMove != 0)
        {
            anim.SetBool(RunningBoolParam, true);
            transform.localScale = new Vector2(Mathf.Sign(horizontalMove), 1);
        }
        else
        {
            anim.SetBool(RunningBoolParam, false);
        }
    }
}
