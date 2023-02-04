using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_speed = 1.0f;

    private Rigidbody2D m_rb;
    private Vector3 m_vel;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        m_vel = new Vector3(x, y, 0);
    }

    void FixedUpdate()
    {
        m_rb.velocity = m_vel * m_speed;
    }
}
