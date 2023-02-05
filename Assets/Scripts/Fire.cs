using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Player m_player;

    private SpriteRenderer m_ren;
    private bool m_active = true;

    void Start()
    {
        m_ren = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!m_active)
        {
            return;
        }

        if (other.tag == "Player")
        {
            if (!m_player.m_hasFire)
            {
                m_player.m_hasFire = true;
                Enable(false);
                StartCoroutine(WaitThenActivate());
            }
        }
    }

    void Enable(bool enable)
    {
        m_active = enable;
        m_ren.enabled = enable;
    }

    IEnumerator WaitThenActivate()
    {
        yield return new WaitForSeconds(3);
        Enable(true);
    }
}
