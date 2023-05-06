namespace Extension.Generic.Console
{
    using UnityEngine;

    [RequireComponent(typeof(Console))]
    public abstract class CustomCommands : MonoBehaviour
    {
        protected Console console;

        private void Awake()
        {
            console = GetComponent<Console>();
        }

        protected abstract void Commands(string command);
    }
}
