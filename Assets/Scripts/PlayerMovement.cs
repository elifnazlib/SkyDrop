using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    private string lookingAt = "right";

    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (string.Equals(lookingAt, "right")) ;
            else if (string.Equals(lookingAt, "left"))
            {
                playerSpriteRenderer.flipX = false;
                lookingAt = "right";
            }

            animator.SetBool("isMoving", true);
            move += transform.right;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (string.Equals(lookingAt, "left")) ;
            else if (string.Equals(lookingAt, "right"))
            {
                playerSpriteRenderer.flipX = true;
                lookingAt = "left";
            }

            animator.SetBool("isMoving", true);
            move -= transform.right;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        move = transform.position + playerSpeed * Time.deltaTime * move;
        move.x = Mathf.Clamp(move.x, -8.3f, 8.3f);
        transform.position = move;
    }
}