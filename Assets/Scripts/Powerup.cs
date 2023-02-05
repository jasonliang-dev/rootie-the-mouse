using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public Player m_player;
    public FadeAppear m_fadeappear;
    public GameObject m_particles;
    public Transform m_slot;
    public string m_action;

    private Vector3 m_initialPosition;
    private bool m_following = false;
    private bool m_invoked = false;

    public Powerup Use()
    {
        m_following = false;
        return null;
    }

    void Start()
    {
        m_initialPosition = transform.position;
    }

    void Update()
    {
        if (m_following)
        {
            transform.position = Vector3.Lerp(transform.position, m_slot.position, Time.deltaTime * 4);
        }
        else
        {
            transform.position = m_initialPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (m_following)
        {
            return;
        }

        if (other.tag == "Player")
        {
            m_following = true;
            Invoke(m_action, 0);
        }
    }

    void OnFireCollect()
    {
        if (m_player.m_fire == null)
        {
            m_player.m_fire = this;

            if (!m_invoked)
            {
                m_invoked = true;
                m_fadeappear.FadeIn();
            }
        }
    }

    void OnWaterCollect()
    {
        if (!m_player.m_water)
        {
            m_player.m_water = this;

            if (!m_invoked)
            {
                m_invoked = true;
                m_fadeappear.FadeIn();
            }
        }
    }

    void OnAirCollect()
    {
        if (!m_player.m_air)
        {
            m_player.m_air = this;

            if (!m_invoked)
            {
                m_invoked = true;
                m_particles.SetActive(true);
            }
        }
    }
}
