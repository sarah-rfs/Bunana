using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Criando duas variáveis públicas para controlar a força do pulo e a velocidade
    // para que elas possam ser alteradas diretamente na unity e não precisar vir em linha de código o tempo todo

    public float Speed;
    public float jumpForce;

    // Saber se o jogador está pulando

    public bool isJumping;

    // Criando o Rigidbody pra poder usar a classe
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        Move();
        Jump();
        
    }

    private void Move()
    {
        // Unity detectando os botões do eixo horizontal e transformando a posição dele vezes
        // o delta time pra deixar a movimentação suave , vezes o speed que é a força da movimentação

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;


        // Essa parte tá basicamente mudando o angulo do Sprite, evita retrabalho da arte de ter que
        // fazer o personagem para os dois lados

        float inputAxis = Input.GetAxis("Horizontal");

        if(inputAxis > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }

        if (inputAxis < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }

    }

    void Jump()
    {   
        // Tá entre aspas como uma string pq a unity por estarmos usando
        // uma classe dependente dela mesma já identifica os botões de Jump - A classe é uma do rigidbody
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }
}
