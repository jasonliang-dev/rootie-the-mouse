using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_speed = 1.0f;
    public float m_jumpVel = 10.0f;

    private Rigidbody2D m_rb;
    private Vector3 m_vel;
    private bool m_jumpQueued = false;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_jumpQueued = false;
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        // var y = Input.GetAxis("Vertical");

        if (x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        m_vel = new Vector3(x, 0, 0);

        if (Input.GetKeyDown("space"))
        {
            m_jumpQueued = true;
        }
    }

    void FixedUpdate()
    {
        float y;
        if (m_jumpQueued)
        {
            m_jumpQueued = false;
            y = m_jumpVel;
        }
        else
        {
            y = m_rb.velocity.y;
        }

        m_rb.velocity = (m_vel * m_speed) + new Vector3(0, y, 0);
    }
}
