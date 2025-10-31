using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector3 direction;

    public float GRAVITY = -9.8f;

    public float STRENGTH = 5f;

    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;
    private int spriteIdx;

    public GemeManager gemeManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void updateDirection() {
        direction = Vector3.up * this.STRENGTH;
    }

    private void Start()
    {
        gemeManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GemeManager>();
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            updateDirection();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                updateDirection();
            }
        }

        direction.y += this.GRAVITY * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite() { 
        spriteIdx++;

        if (spriteIdx >= sprites.Length)
        {
            spriteIdx = 0;
        }

        spriteRenderer.sprite = sprites[spriteIdx];

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gemeManager.GameOver();
        }
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
}
