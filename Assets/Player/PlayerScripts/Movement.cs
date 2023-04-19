using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 2f;
    [SerializeField] private float ShiftSpeed = 4f;

    private Animator animator;

    [Header("Arrow")]
    [SerializeField] private GameObject HandArrow;


    private void Start()
    {
        animator = GetComponent<Animator>();
        HandArrow.gameObject.SetActive(false);
    }

    private void HandArrowActive()
    {
        HandArrow.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("IsAttack", true);
        }
        else
        {
            animator.SetBool("IsAttack", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.forward * MoveSpeed * ShiftSpeed * Time.deltaTime);
                animator.SetBool("IsRun", true);
            }
            else
            {
                animator.SetBool("IsRun", false);
            }
        }
        else
        {
            animator.SetBool("IsRun", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * MoveSpeed * Time.deltaTime);
            animator.SetBool("IsBack", true);
        }
        else
        {
            animator.SetBool("IsBack", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
            animator.SetBool("IsLeft", true);
        }
        else
        {
            animator.SetBool("IsLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
            animator.SetBool("IsRight", true);
        }
        else
        {
            animator.SetBool("IsRight", false);
        }
    }
}  
