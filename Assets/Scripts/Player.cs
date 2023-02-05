using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_flame;

    public float m_speed = 1.0f;
    public float m_jumpVel = 10.0f;
    public float m_groundDist = 0.1f;

    [HideInInspector]
    public bool m_hasFire = false;

    private Rigidbody2D m_rb;
    private Animator m_anim;
    private BoxCollider2D m_box;

    private Vector3 m_vel;
    private bool m_jumpQueued = false;
    private bool m_shouldStopJump = false;
    private float m_lastXDirection = 1.0f;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_box = GetComponent<BoxCollider2D>();

        StartCoroutine(Idle());
    }

    IEnumerator Idle()
    {
        m_anim.Play("Base Layer.PlayerIdle");

        while (true)
        {
            var x = Input.GetAxis("Horizontal");
            if (x != 0)
            {
                yield return StartCoroutine(Walk());
                m_anim.Play("Base Layer.PlayerIdle");
            }

            if (Input.GetKeyDown("space"))
            {
                yield return StartCoroutine(Jump());
                m_anim.Play("Base Layer.PlayerIdle");
            }

            if (m_hasFire && Input.GetKeyDown("e"))
            {
                var f = Instantiate(m_flame, transform.position, Quaternion.identity);
                var rb = f.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector3(m_lastXDirection * 12, 0, 0);
            }

            yield return null;
        }
    }

    IEnumerator Walk()
    {
        m_anim.Play("Base Layer.PlayerWalk");

        while (true)
        {
            var x = Input.GetAxis("Horizontal");

            if (x > 0)
            {
                m_lastXDirection = 1.0f;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (x < 0)
            {
                m_lastXDirection = -1.0f;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                m_vel = new Vector3(0, 0, 0);
                yield break;
            }

            m_vel = new Vector3(x, 0, 0);

            if (Input.GetKeyDown("space"))
            {
                yield return StartCoroutine(Jump());
                m_anim.Play("Base Layer.PlayerWalk");
            }

            yield return null;
        }
    }

    IEnumerator Jump()
    {
        m_anim.Play("Base Layer.PlayerJump");
        m_jumpQueued = true;
        m_shouldStopJump = false;

        while (true)
        {
            var x = Input.GetAxis("Horizontal");

            if (x > 0)
            {
                m_lastXDirection = 1.0f;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (x < 0)
            {
                m_lastXDirection = -1.0f;
                transform.localScale = new Vector3(-1, 1, 1);
            }

            m_vel = new Vector3(x, 0, 0);

            if (m_shouldStopJump)
            {
                yield break;
            }

            yield return null;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Map")
        {
            m_shouldStopJump = true;
        }
    }
}
