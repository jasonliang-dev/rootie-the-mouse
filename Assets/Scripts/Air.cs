using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    public Player m_player;
    public GameObject m_particles;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!m_player.m_hasAir)
            {
                m_player.m_hasAir = true;
                m_particles.SetActive(true);
            }
        }
    }
}
