using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void LateUpdate()
    {
        transform.LookAt(mainCamera.transform);
    }
}