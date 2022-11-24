using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    // Start is called before the first frame update
   
    Player player;

    void Start()
    {
        player = gameObject.transform.parent.gameObject.GetComponent<Player>();
        
    }

    // Esses dois métodos são padrão da unity, eles servem pra dizer quando
    // se esta tocando um objeto ou deixando de tocar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            player.isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            player.isJumping = true;
        }
    }
}
