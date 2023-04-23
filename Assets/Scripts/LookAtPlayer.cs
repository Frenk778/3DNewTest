using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform _mainCameraTransform;

    private void Start()
    {
        _mainCameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(_mainCameraTransform.transform);
    }
}