using System;
using Unity.Mathematics;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float velocidad = 4;//velocidad del jugador
    private Rigidbody2D rb2d;   // El componente de fisicas
    private float movimiento; // la variable de movimiento 
    private SpriteRenderer spriteRenderer; // referencia al sprite renderer
    public float salto = 6; //fuerza del salto
    private bool esPiso; //para saber si tocamos piso 
    public Transform TocandoPiso;//detecta el piso
    public float RadioDePiso = 0.1f;//area de deteccion del piso
    public LayerMask CapaDePiso;//nose aun
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // busca el componente y lo guarda aca 
        spriteRenderer = GetComponent<SpriteRenderer>(); // busca el sprite renderer
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = Input.GetAxisRaw("Horizontal");// Lee la entrada horizontal del jugador (-1 = izquierda, 0 = sin movimiento, 1 = derecha)
        rb2d.linearVelocity = new Vector2(movimiento * velocidad, rb2d.linearVelocity.y);//le digo que mantenga una velocidad depenediendo la emtrada del jugador sin afectar al salto

        // Voltea el sprite automáticamente
        if (movimiento != 0)
        {
            spriteRenderer.flipX = (movimiento < 0);//si el personaje se mueve en el eje x para numeros negativos rota
        }
        if (Input.GetButton("Jump") && esPiso)//si se preciona el espacio y detecta el piso
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, salto);
        }
    }
    private void FixedUpdate()//se analiza a cada rato 
    {
        esPiso = Physics2D.OverlapCircle(TocandoPiso.position,RadioDePiso,CapaDePiso);
    }
}
