using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCamera.transform);
    }
}