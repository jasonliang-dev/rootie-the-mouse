using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform m_player;
    public float m_blend1 = 0.85f;
    public float m_blend2 = 30.0f;
    public float m_offY = 4.0f;

    void Update()
    {
        var x = m_player.position.x;
        var y = m_player.position.y + m_offY;
        var z = transform.position.z;

        var blend = 1 - Mathf.Pow(m_blend1, Time.deltaTime * m_blend2);
        transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, z), blend);
    }
}
