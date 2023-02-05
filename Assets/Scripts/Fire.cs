using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Player m_player;
    public FadeAppear m_fireplace;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!m_player.m_hasFire)
            {
                m_player.m_hasFire = true;
                m_fireplace.FadeIn();
            }
        }
    }
}
