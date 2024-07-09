using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 MoveX = Vector2.zero;
        Vector2 MoveY = Vector2.zero;
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            MoveX = new Vector2(2f, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            MoveX = new Vector2(-2f, 0);
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            MoveY = new Vector2(0, 2f);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            MoveY = new Vector2(0, -2f);
        }
        rb.velocity = MoveX + MoveY;
    }
}
