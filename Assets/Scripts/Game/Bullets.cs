using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector3 angle, float power)
    {
        rigid.AddForce(angle * power * 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && GameManager.Instance.IsPlayer1Turn)
        {
            GameManager.Instance.player1Hp -= 20.0f;
            if (GameManager.Instance.player1Hp <= 0)
                GameManager.Instance.IsPlayer2Win = true;
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player2") && !GameManager.Instance.IsPlayer1Turn)
        {
            GameManager.Instance.player2Hp -= 20.0f;
            if (GameManager.Instance.player2Hp <= 0)
                GameManager.Instance.IsPlayer1Win = true;
            Destroy(gameObject);
        }

        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
