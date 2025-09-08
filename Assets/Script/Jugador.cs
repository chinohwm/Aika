using System;
using Unity.Mathematics;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float velocidad = 7;//velocidad del jugador
    private Rigidbody2D rb2d;   // El componente de fisicas
    private float movimiento; // la variable de movimiento 
    private SpriteRenderer spriteRenderer; // referencia al sprite renderer
    public float salto = 6; //fuerza del salto
    private bool esPiso; //para saber si tocamos piso 
    public Transform TocandoPiso;//detecta el piso
    public float RadioDePiso = 0.1f;//area de deteccion del piso
    public LayerMask CapaDePiso;//nose aun
    public Animator animator;// controla las animaciones
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // busca el componente y lo guarda aca 
        spriteRenderer = GetComponent<SpriteRenderer>(); // busca el sprite renderer
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = Input.GetAxisRaw("Horizontal");// Lee la entrada horizontal del jugador (-1 = izquierda, 0 = sin movimiento, 1 = derecha)
        rb2d.linearVelocity = new Vector2(movimiento * velocidad, rb2d.linearVelocity.y);//le digo que mantenga una velocidad depenediendo la emtrada del jugador sin afectar al salto
        // Si movimiento es distinto de 0, corre. Si es 0, está quieto
        animator.SetBool("correr", movimiento != 0);

        // Voltea el sprite automáticamente
        if (movimiento != 0)
        {
            spriteRenderer.flipX = (movimiento < 0);//si el personaje se mueve en el eje x para numeros negativos rota
            animator.SetBool("salto", false);
            
        }
        if (Input.GetButton("Jump") && esPiso)//si se preciona el espacio y detecta el piso
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, salto);
            animator.SetBool("correr", false);
            animator.SetBool("salto", true);
        }
       
        }
    private void FixedUpdate()//se analiza a cada rato 
    {
        esPiso = Physics2D.OverlapCircle(TocandoPiso.position,RadioDePiso,CapaDePiso);
    }
}
