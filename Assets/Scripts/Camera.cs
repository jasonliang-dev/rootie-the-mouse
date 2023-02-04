using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform m_player;

    void Update()
    {
        var x = m_player.position.x;
        var y = m_player.position.y;
        var z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, z), Time.deltaTime);
    }
}
