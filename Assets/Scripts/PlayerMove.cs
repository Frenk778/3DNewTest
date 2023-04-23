using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Arrow")]
    [SerializeField] private GameObject _handArrow;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _shiftSpeed = 4f;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _handArrow.gameObject.SetActive(false);
    }

    private void HandArrowActive()
    {
        _handArrow.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _animator.SetBool("IsAttack", true);
        }
        else
        {
            _animator.SetBool("IsAttack", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
            _animator.SetBool("IsWalk", true);
        }
        else
        {
            _animator.SetBool("IsWalk", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.forward * _moveSpeed * _shiftSpeed * Time.deltaTime);
                _animator.SetBool("IsRun", true);
            }
            else
            {
                _animator.SetBool("IsRun", false);
            }
        }
        else
        {
            _animator.SetBool("IsRun", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * _moveSpeed * Time.deltaTime);
            _animator.SetBool("IsBack", true);
        }
        else
        {
            _animator.SetBool("IsBack", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
            _animator.SetBool("IsLeft", true);
        }
        else
        {
            _animator.SetBool("IsLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
            _animator.SetBool("IsRight", true);
        }
        else
        {
            _animator.SetBool("IsRight", false);
        }
    }
}  
