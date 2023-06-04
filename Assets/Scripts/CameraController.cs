using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform m_transform;
    public GameObject Player;
  
    public Vector3 Offset;

    private void Start()
    {
        m_transform.position = Player.transform.position;
    }
    void Update()
    {
        m_transform.position = Player.transform.position + Offset;
        m_transform.position = new Vector3(m_transform.position.x, Offset.y, m_transform.position.z);
    }
}