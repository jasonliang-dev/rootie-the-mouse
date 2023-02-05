using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Player m_player;
    public FadeAppear m_waterfall;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!m_player.m_hasWater)
            {
                m_player.m_hasWater = true;
                m_waterfall.FadeIn();
            }
        }
    }
}
