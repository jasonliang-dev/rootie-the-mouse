using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSlot : MonoBehaviour
{
    public Transform m_slot;

    private bool m_following = false;

    void Update()
    {
        if (m_following)
        {
            transform.position = Vector3.Lerp(transform.position, m_slot.position, Time.deltaTime * 4);
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
        }
    }
}
