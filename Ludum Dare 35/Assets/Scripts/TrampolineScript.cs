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

    void OnCollisionEnter2D(Collision2D collision)
    {
        var angle = Mathf.Deg2Rad * gameObject.transform.rotation.eulerAngles.z;
        var velocity = collision.relativeVelocity;
        velocity = Vector2.Reflect(velocity, new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));

        if (velocity.magnitude < JumpStrength)
        {
            velocity.Normalize();
            velocity *= JumpStrength;
        }

        collision.rigidbody.velocity = velocity;

        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }
    }
}
