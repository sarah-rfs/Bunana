using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Criando duas vari�veis p�blicas para controlar a for�a do pulo e a velocidade
    // para que elas possam ser alteradas diretamente na unity e n�o precisar vir em linha de c�digo o tempo todo

    public float Speed;
    public float jumpForce;

    // Saber se o jogador est� pulando

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
        // Unity detectando os bot�es do eixo horizontal e transformando a posi��o dele vezes
        // o delta time pra deixar a movimenta��o suave , vezes o speed que � a for�a da movimenta��o

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;


        // Essa parte t� basicamente mudando o angulo do Sprite, evita retrabalho da arte de ter que
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
        // T� entre aspas como uma string pq a unity por estarmos usando
        // uma classe dependente dela mesma j� identifica os bot�es de Jump - A classe � uma do rigidbody
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }
}
