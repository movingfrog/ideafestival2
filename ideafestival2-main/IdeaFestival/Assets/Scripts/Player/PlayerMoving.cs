using System.Collections;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float speed;

    private Vector3 vector;
    [SerializeField]
    private float runSpeed = 0.0625f;
    private float applyRunSpeed = 0.0625f;
    private bool applyRun;

    public int walkCount = 16;
    private int currentWalkCount;

    private bool canMove = true;

    IEnumerator MoveCoroutine()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            applyRunSpeed = runSpeed;
            applyRun = true;
        }
        else
        {
            applyRunSpeed = 0;
            applyRun = false;
        }

        vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

        while (currentWalkCount < walkCount)
        {
            if (vector.x != 0)
            {
                transform.Translate(vector.x * (speed + applyRunSpeed), 0, 0);
            }
            if (vector.y != 0)
            {
                transform.Translate(0, vector.y * (speed + applyRunSpeed), 0);
            }
            if (applyRun)
                currentWalkCount++;
            currentWalkCount++;
            yield return new WaitForSeconds(0.01f);
        }
        currentWalkCount = 0;
        canMove = true;
    }

    private void Update()
    {

        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && canMove)
        {
            canMove = false;
            StartCoroutine(MoveCoroutine());
        }
    }
}