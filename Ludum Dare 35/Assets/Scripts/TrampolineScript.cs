using UnityEngine;
using System.Collections;

public class TrampolineScript : MonoBehaviour
{

    public float JumpStrength = 10;

    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Trampoline(collider.gameObject.GetComponent<Rigidbody2D>());
    }

    void Trampoline(Rigidbody2D body)
    {
        var angle = Mathf.Deg2Rad * gameObject.transform.rotation.eulerAngles.z;
        var velocity = -body.velocity;
        velocity = Vector2.Reflect(velocity, new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));

        if (velocity.magnitude < JumpStrength)
        {
            velocity.Normalize();
            velocity *= JumpStrength;
        }

        body.velocity = velocity;

        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }
    }
}
