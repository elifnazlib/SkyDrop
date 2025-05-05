using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10f;
    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            move += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move -= transform.right;
        }

        move = transform.position + playerSpeed * Time.deltaTime * move;
        move.x = Mathf.Clamp(move.x, -8.3f, 8.3f);
        transform.position = move;
    }
}