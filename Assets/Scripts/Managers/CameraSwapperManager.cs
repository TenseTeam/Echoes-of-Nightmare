namespace ProjectEON.Managers
{
    using Extension.Generic.Camera;
    using UnityEngine;

    public class CameraSwapperManager : MonoBehaviour
    {
        [SerializeField]
        private Camera _exploringCamera, _combatCamera;
        private Fade _fade;

        public void Init(Fade fade, bool hasExploringCameraPriority = true)
        {
            _fade = fade;
            _exploringCamera.enabled = hasExploringCameraPriority;
            _combatCamera.enabled = !hasExploringCameraPriority;
        }

        private void OnEnable()
        {
            _fade.OnFadeInEnd += SwapCameras;
        }

        private void OnDisable()
        {
            _fade.OnFadeInEnd -= SwapCameras;
        }

        public void SwapCameras()
        {
            _exploringCamera.enabled = !_exploringCamera.enabled;
            _combatCamera.enabled = !_combatCamera.enabled;
        }

        //public void SwapToCombat()
        //{
        //    _exploringCamera.enabled = false;
        //    _combatCamera.enabled = true;
        //}

        //public void SwapToExplore()
        //{
        //    _exploringCamera.enabled = true;
        //    _combatCamera.enabled = false;
        //}
    }
}
