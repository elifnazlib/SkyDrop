using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10f;
    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // Update is called once per frame
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

        transform.position += playerSpeed * Time.deltaTime * move;
    }
}