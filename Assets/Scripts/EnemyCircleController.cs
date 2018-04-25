using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleController : MonoBehaviour {

    public float Speed = 7f;
    float _direction = -1f;
    float tmp = 0;
    // Use this for initialization

    Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(Speed * _direction, _rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision tag = " + collision.tag);
    }
}
