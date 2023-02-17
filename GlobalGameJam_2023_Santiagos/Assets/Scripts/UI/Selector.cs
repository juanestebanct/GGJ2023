using UnityEngine;
public class Selector : MonoBehaviour
{
    [SerializeField] private RootController _rootController;
    private void Update() { if (Input.GetKeyDown(KeyCode.Z)) {_rootController.SetCamera(); AudioManager.Instance.Zoom_In();}}
}
