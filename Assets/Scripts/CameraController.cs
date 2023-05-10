using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController m_Player;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckPlayerInView();
    }

    private void CheckPlayerInView()
    {

    }
}
