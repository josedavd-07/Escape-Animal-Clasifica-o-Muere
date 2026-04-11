using UnityEngine;
using UnityEngine.Rendering;

public class AnimalMove : MonoBehaviour
{
    [SerializeField] AnimalFeatures animalFeatures;
    public AnimalFeatures data;
    public int speed;
    public int routine;
    public float cronometer = 1;
    public Animator animator;
    public Quaternion rotation;
    public float angle;
    public GameObject target;

    void Awake()
    {
        if (data == null)
        {
            data = animalFeatures;
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");

        if (target == null)
        {
            Debug.LogError("Player object not found. Please ensure there is a GameObject with the tag 'Player' in the scene.");
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > 10)
        {
            animator.SetBool("isRunning", false);
            cronometer += 1 * Time.deltaTime;
            if (cronometer >= 4)
            {
                routine = Random.Range(0, 3);
                cronometer = 0;
            }
            switch (routine)
            {
                case 0:
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isIdle", true);
                    break;
                case 1:
                    angle = Random.Range(0, 360);
                    rotation = Quaternion.Euler(0, angle, 0);
                    routine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.5f);
                    transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isWalking", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, -3);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);

        }
    }
}
