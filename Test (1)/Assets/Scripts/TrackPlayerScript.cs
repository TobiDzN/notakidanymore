using UnityEngine;

public class GoblinController : MonoBehaviour
{
    public int minRange;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private Transform target = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            target = other.transform;
        animator.SetBool("Move01", true);
        animator.SetBool("Idle01", false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            target = null;
        animator.SetBool("Move01", false);
        animator.SetBool("Idle01", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            animator.SetBool("Move01", false);
            animator.SetBool("Idle01", true);
            return;
        }
        else
        {
            animator.SetBool("Move01", true);
            animator.SetBool("Idle01", false);

        }

        transform.LookAt(target);
        float distance = Vector3.Distance(transform.position, target.position);
        bool tooClose = distance < minRange;
        Vector3 direction = tooClose ? Vector3.back : Vector3.forward;
        if (direction == Vector3.forward)
        {
            transform.Translate(direction * 6 * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction * 3 * Time.deltaTime);
        }

        if (tooClose)
        {
            animator.SetBool("Move01", false);
            animator.SetBool("Idle01", false);
            animator.SetBool("Attack01", true);
        }
        else if (target != null)
        {
            animator.SetBool("Move01", true);
            animator.SetBool("Idle01", false);
            animator.SetBool("Attack01", false);
        }
    }
}
