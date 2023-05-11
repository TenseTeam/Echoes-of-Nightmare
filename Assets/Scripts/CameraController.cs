using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float TimeOfHiding;
    private PlayerController m_Player;
    private GameObject m_LastObstacle;
    private CinemachineFramingTransposer m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GetComponentInParent<PlayerController>();
        m_Camera = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckPlayerInView();
    }

    private IEnumerator WaitBetweenCasting()
    {
        yield return new WaitForSeconds(1f);
        CheckPlayerInView();
    }

    private void CheckPlayerInView()
    {
        RaycastHit hit;
        Vector3 direction = transform.position - m_Player.transform.position;
        Debug.DrawLine(m_Player.transform.position, transform.position, Color.red);
        if (Physics.Raycast(m_Player.transform.position, direction.normalized, out hit, m_Camera.m_CameraDistance))
        {
            if(hit.collider.gameObject != gameObject)
            {
                HideObstacle(hit.collider.gameObject, 0f);
            }
        }
        else
        {
            try
            {
                ShowLastObstacle(m_LastObstacle, 1f);
            }
            catch(Exception e)
            {

            }
        }
    }
    
    private void ShowLastObstacle(GameObject obstacle, float alpha)
    {
        if (obstacle.TryGetComponent(out MeshRenderer meshRenderer))
        {
            SetToOpaque(meshRenderer.material);
            ColorLerping(meshRenderer, alpha);
            m_LastObstacle = null;
        }
    }

    private void HideObstacle(GameObject obstacle, float alpha)
    {
        if(obstacle.TryGetComponent(out MeshRenderer meshRenderer))
        {
            meshRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            meshRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            meshRenderer.material.SetInt("_ZWrite", 0);
            meshRenderer.material.DisableKeyword("_ALPHATEST_ON");
            meshRenderer.material.EnableKeyword("_ALPHABLEND_ON");
            meshRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            meshRenderer.material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            ColorLerping(meshRenderer, alpha);
            m_LastObstacle = obstacle;
        }
    }

    private void ColorLerping(MeshRenderer meshRenderer, float alpha)
    {
        Color tmp = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, alpha);
        Color colorLerp = Color.Lerp(meshRenderer.material.color, tmp, TimeOfHiding);
        meshRenderer.material.color = colorLerp;
    }
    
    private void SetToTransparent(Material material)
    {
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
    }

    private void SetToOpaque(Material material)
    {
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        material.SetInt("_ZWrite", 1);
        material.DisableKeyword("_ALPHATEST_ON");
        material.DisableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = -1; // Impostare la coda di rendering a default
    }
}
