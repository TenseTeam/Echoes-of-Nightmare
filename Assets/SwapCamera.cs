using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCamera : MonoBehaviour
{
    [SerializeField] private Camera m_ExploringCamera;
    [SerializeField] private Camera m_CombatCameraCamera;

    public void SwapToCombat()
    {
        m_ExploringCamera.enabled = false;
        m_CombatCameraCamera.enabled = true;
    }

    public void SwapToExplore()
    {
        m_ExploringCamera.enabled = true;
        m_CombatCameraCamera.enabled = false;
    }
}
