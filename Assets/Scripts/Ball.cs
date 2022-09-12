using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D m_rb;//tham chieu den rigi
    bool m_isGround = false;
    public float jumpForce;
    GameController m_gc;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isJumpKey = Input.GetKeyDown(KeyCode.Space);
        if (isJumpKey && m_isGround)
        {
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            m_gc.SetGameover(true);
            Destroy(gameObject);
        }
    }
}
