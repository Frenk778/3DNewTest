using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraLook : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _sensitivity = 2f;
    [SerializeField] private float _smoothing = 1.5f;
    [SerializeField] private float _delay = 0.1f;

    private Vector2 smoothMouse = Vector2.zero;
    private Vector2 mouseLook = Vector2.zero;
    private bool _isCanRotate = false;
    private float _maxMouseLookValue = 80f;
    private float _minMouseLookValue = -80f;
    private float _xRotationCamera = 0f;
    private float _zRotationCamera = 0f;
    private const float _smoothingSpeed = 1f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        mouseLook = new Vector2(_player.transform.eulerAngles.y, transform.eulerAngles.x);
        transform.localRotation = Quaternion.Euler(_xRotationCamera, mouseLook.y, _zRotationCamera);
        _player.localRotation = Quaternion.Euler(_xRotationCamera, mouseLook.x, _zRotationCamera);

        StartCoroutine(DelayRotation());
    }

    private void Update()
    {
        if (_isCanRotate)
        {
            var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            mouseDelta = Vector2.Scale(mouseDelta, new Vector2(_sensitivity * _smoothing, _sensitivity * _smoothing));

            smoothMouse.x = Mathf.Lerp(smoothMouse.x, mouseDelta.x, _smoothingSpeed / _smoothing);
            smoothMouse.y = Mathf.Lerp(smoothMouse.y, mouseDelta.y, _smoothingSpeed / _smoothing);

            mouseLook += smoothMouse;

            mouseLook.y = Mathf.Clamp(mouseLook.y, _minMouseLookValue, _maxMouseLookValue);

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            _player.localRotation = Quaternion.AngleAxis(mouseLook.x, _player.up);
        }
    }

    private IEnumerator DelayRotation()
    {
        yield return new WaitForSeconds(_delay);

        _isCanRotate = true;
    }
}