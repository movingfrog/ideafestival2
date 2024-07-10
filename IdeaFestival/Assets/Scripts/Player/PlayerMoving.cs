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
    private Animator anim;

    public int walkCount = 16;
    private int currentWalkCount;

    private bool canMove = true;

    private LayerMask wallLayer;

    private void Start()
    {
        // Wall layer 설정 (Inspector에서 설정 가능)
        wallLayer = LayerMask.GetMask("Wall");
        anim = GetComponent<Animator>();
    }

    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
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

            anim.SetFloat("DirX", vector.x);
            anim.SetFloat("DirY", vector.y);
            anim.SetBool("IsMoving", true);

            while (currentWalkCount < walkCount)
            {
                if (vector.x != 0 && !IsWallInDirection(Vector2.right * vector.x))
                {
                    transform.Translate(vector.x * (speed + applyRunSpeed), 0, 0);
                }
                if (vector.y != 0 && !IsWallInDirection(Vector2.up * vector.y))
                {
                    transform.Translate(0, vector.y * (speed + applyRunSpeed), 0);
                }
                if (applyRun)
                    currentWalkCount++;
                currentWalkCount++;
                yield return new WaitForSeconds(0.01f);
            }
            currentWalkCount = 0;
        }
        anim.SetBool("IsMoving", false);
        canMove = true;
    }

    private bool IsWallInDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 0.25f, 0), direction, 0.275f, wallLayer);
        return hit.collider != null;
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