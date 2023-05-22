namespace ProjectEON.Managers
{
    using UnityEngine;
    using Extension.Generic.Camera;

    [RequireComponent(typeof(CameraFade))]
    public class CameraSwapperManager : MonoBehaviour
    {
        [SerializeField]
        private CameraFade _fade;

        [SerializeField]
        private Camera _exploringCamera, _combatCamera;

        public void SwapToCombat()
        {
            _exploringCamera.enabled = false;
            _combatCamera.enabled = true;
        }

        public void SwapToExplore()
        {
            _exploringCamera.enabled = true;
            _combatCamera.enabled = false;
        }
    }
}
