using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    private Animator m_anim;
    private bool m_shouldDie = false;

    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    void Update()
    {
        var info = m_anim.GetCurrentAnimatorStateInfo(0);
        var finished = info.normalizedTime > 1.0f;
        var isShrink = info.IsName("Base Layer.RootBigDecay");
        if (m_shouldDie && finished && isShrink)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            m_anim.Play("Base Layer.RootBigDecay");
            m_shouldDie = true;
        }
    }
}
