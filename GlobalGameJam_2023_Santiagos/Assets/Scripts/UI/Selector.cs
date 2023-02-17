using UnityEngine;
public class Selector : MonoBehaviour
{
    [SerializeField] private RootController _rootController;
    private void Update() { if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.L)) {_rootController.SetCamera(); AudioManager.Instance.Zoom_In();}}
}
