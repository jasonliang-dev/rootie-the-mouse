using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRoot : MonoBehaviour
{
    public Player m_player;

    [HideInInspector]
    public bool m_grew = false;

    private bool m_entered = false;

    void Update()
    {
        if (!m_grew && m_entered && m_player.m_greenRoot == null)
        {
            m_player.m_greenRoot = this;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_entered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_entered = false;

            if (m_player.m_greenRoot == this)
            {
                m_player.m_greenRoot = null;
            }
        }
    }
}
