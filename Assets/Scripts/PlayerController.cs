using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Transform GroundCheck;
    public Transform Respawn;
    public Text CurrentScore;
    public LayerMask WhatIsGround;

    public float Score = 0;
    public float MaxSpeed = 10f;
    public float JumpForce = 700f;
    public float GroundRadius = 0.2f;
    public float Move;

    Rigidbody2D _rigidbody2D;
    bool _facingRight = true;
    bool _grounded = false;

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, WhatIsGround);
        Move = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        if (_grounded && (Input.GetKeyDown(KeyCode.W) 
            || Input.GetKeyDown(KeyCode.UpArrow) 
            || Input.GetKeyDown(KeyCode.Space)))
        {
            _rigidbody2D.AddForce(new Vector2(0f, JumpForce));
        }
        _rigidbody2D.velocity = new Vector2(Move * MaxSpeed, _rigidbody2D.velocity.y);

        if (Move > 0 && !_facingRight)
            Flip();
        else if (Move < 0 && _facingRight)
            Flip();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "DieCollider":
                SceneManager.LoadScene("main");
                break;

            case "Saw":
                SceneManager.LoadScene("main");
                break;

            case "Star":
                ++Score;
                CurrentScore.text = Score.ToString();
                Destroy(collision.gameObject);
                break;
        }
    }
}
