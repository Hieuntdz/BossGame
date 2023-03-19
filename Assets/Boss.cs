using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public Transform player;

    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private LayerMask wallLayer;

    [SerializeField] private LayerMask bulletLayer;

    private BossHealthBar bossHealth;

    private Rigidbody2D body;
	private BoxCollider2D boxCollider;

    private Animator animator;
	private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		animator = GetComponent<Animator>();
        var bossBar = GameObject.FindWithTag("BossHealth");
        bossHealth = bossBar.GetComponent<BossHealthBar>();
    }

    public void Update()
    {
        LookAtPlayer();

        if (onWall() || onPlayer())
        {
            body.gravityScale = 0;
        }
        else
        {
            body.gravityScale = 7;
        }
    }

    public void LookAtPlayer()
    {
        if (transform.position.x > player.position.x)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 1f);
        }
        else if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }
    }

    public void ReduceHealth(int value)
    {
        animator.SetTrigger("Hurt");
        if(bossHealth.currentHealth <= 0)
        {
            return;
        }
        bossHealth.reduceHealth(value);
        if(bossHealth.currentHealth <= 0)
        {
            animator.SetTrigger("Die");
        }
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0,
            new Vector2(transform.localScale.x, 0),
            0.1f,
            wallLayer
        );
        return raycastHit.collider != null;
    }

    private bool onPlayer()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0,
            new Vector2(transform.localScale.x, 0),
            0.1f,
            playerLayer
        );
        return raycastHit.collider != null;
    }
}
