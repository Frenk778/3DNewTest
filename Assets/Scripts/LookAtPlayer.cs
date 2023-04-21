using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform mainCameraTransform;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCameraTransform.transform);
    }
}