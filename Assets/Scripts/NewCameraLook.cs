using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraLook : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float smoothing = 1.5f;
    [SerializeField] private float delay = 0.1f;

    private Vector2 smoothMouse = Vector2.zero;
    private Vector2 mouseLook = Vector2.zero;
    private bool canRotate = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        mouseLook = new Vector2(player.transform.eulerAngles.y, transform.eulerAngles.x);
        transform.localRotation = Quaternion.Euler(0f, mouseLook.y, 0f);
        player.localRotation = Quaternion.Euler(0f, mouseLook.x, 0f);

        StartCoroutine(DelayRotation());
    }

    private IEnumerator DelayRotation()
    {
        yield return new WaitForSeconds(delay);

        canRotate = true;
    }

    private void Update()
    {
        if (canRotate)
        {
            var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

            smoothMouse.x = Mathf.Lerp(smoothMouse.x, mouseDelta.x, 1f / smoothing);
            smoothMouse.y = Mathf.Lerp(smoothMouse.y, mouseDelta.y, 1f / smoothing);

            mouseLook += smoothMouse;

            mouseLook.y = Mathf.Clamp(mouseLook.y, -80f, 80f);

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            player.localRotation = Quaternion.AngleAxis(mouseLook.x, player.up);
        }
    }
}