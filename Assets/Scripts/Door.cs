using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Transform m_teleportTarget;
    public GameObject m_player;

    void OnTriggerEnter2D(Collision2D other)
    {
        if (other.tag == "Player")
        {
            //teleport player somewhere else
            m_player.transform.position = m_teleportTarget.transform.position;
        }
    }

}
