using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    private SpriteRenderer sprite_renderer;
    public Sprite[] sprites;
    private int sprite_index;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            direction = Vector3.up * strength;
        
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
                direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        ++sprite_index;
        if(sprite_index >= sprites.Length)
            sprite_index = 0;
        
        sprite_renderer.sprite = sprites[sprite_index];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
            FindObjectOfType<GameManager>().GameOver();
        else if(other.gameObject.tag == "Scoring")
            FindObjectOfType<GameManager>().IncreaseScore();
    }
}
