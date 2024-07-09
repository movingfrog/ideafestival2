using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCode : MonoBehaviour
{
    public GameObject Player;
    SpriteRenderer A;
    float visible = 1f;

    private void Awake()
    {
        A = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float dis = Mathf.Sqrt(Mathf.Pow(Player.transform.position.x - transform.position.x, 2f) + Mathf.Pow(Player.transform.position.y - transform.position.y, 2f));
        A.color = new Color(255, 255, 255, visible - (dis * 0.15f) + 0.2f);
    }
}
