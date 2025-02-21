using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody2D;
    private Animator    _playerAnimator;
    public  float       _playerSpeed;
    private Vector2     _playerDirection;

    // novo (18/02)
    private CapsuleCollider2D CapsuleCollider;
    private RaycastHit2D hit;

    public DirecaoMovimento direcaoMovimento;
    
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();

        this.direcaoMovimento = DirecaoMovimento.Direita;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(_playerDirection.x > 0)
        {
            this.direcaoMovimento = DirecaoMovimento.Direita;
        }
        else if(_playerDirection.x < 0)
        {
            this.direcaoMovimento = DirecaoMovimento.Esquerda;
        }
    
        if(_playerDirection.sqrMagnitude > 0.1)
        {
            MovePlayer();
            _playerAnimator.SetFloat("AxisX", _playerDirection.x);
            _playerAnimator.SetFloat("AxisY", _playerDirection.y);

            _playerAnimator.SetInteger("Movimento", 1);
        }
        else
        {
            _playerAnimator.SetInteger("Movimento", 0);
        }
        // if ataque verdadeiro, movimento = 2

        // novo (18/02)
        hit = Physics2D.BoxCast(transform.position, CapsuleCollider.size, 0, new Vector2(0, _playerDirection.y), Mathf.Abs(_playerDirection.y * Time.deltaTime), LayerMask.GetMask("Personagem","Blocking"));
        if (hit.collider == null)
        {
            MovePlayer();
        }

        hit = Physics2D.BoxCast(transform.position, CapsuleCollider.size, 0, new Vector2(_playerDirection.x, 0), Mathf.Abs(_playerDirection.x * Time.deltaTime), LayerMask.GetMask("Personagem","Blocking"));
        if (hit.collider == null)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection.normalized * _playerSpeed * Time.fixedDeltaTime);  
    }
}
