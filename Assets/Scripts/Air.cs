using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    public Player m_player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!m_player.m_hasAir)
            {
                m_player.m_hasAir = true;
            }
        }
    }
}
