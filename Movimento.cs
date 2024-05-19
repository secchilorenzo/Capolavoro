using UnityEngine;

public class Movimento : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    public float Forza = 10f;
    public bool Saltando = false;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal") * speed));
        animator.SetBool("isJumping", Saltando);

        if (Input.GetKeyDown(KeyCode.Space) && !Saltando)
        {
            Salto();
        }

        if ((Input.GetAxis("Horizontal") * speed) > 0)
            gameObject.transform.localScale = new Vector3(2, 2, 2);

        else if ((Input.GetAxis("Horizontal") * speed) < 0)
            gameObject.transform.localScale = new Vector3(-2, 2, 2);


    }

    void Salto()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, Forza);
        Saltando = true; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Square"))
        {
            Saltando = false; 
        }
    }
}

 
