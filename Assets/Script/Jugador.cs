using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioSource audioSource;//controla los sonidos del jugador ej saltar
    public AudioClip saltoSound; // sonido de salto
    public AudioClip monedasond;//sonido de moneda
    public AudioClip chek_point; 
    private int moneda; // para contar las monedas
    public TMP_Text nummoneda;//cuenta las monedas
 
    public  GameObject Tiempo ;

   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // busca el componente y lo guarda aca 
        spriteRenderer = GetComponent<SpriteRenderer>(); // busca el sprite renderer
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        if (Input.GetButtonDown("Jump") && esPiso)
{
    audioSource.PlayOneShot(saltoSound);
    rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, salto);

    animator.SetBool("correr", false);
    animator.SetBool("salto", true);
}


if (Input.GetButtonUp("Jump") && rb2d.linearVelocity.y > 0)
{
    rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, rb2d.linearVelocity.y * 0.5f);
}


    }
    private void FixedUpdate()//se analiza a cada rato 
    {
        esPiso = Physics2D.OverlapCircle(TocandoPiso.position, RadioDePiso, CapaDePiso);
    }

    private void OnTriggerEnter2D(Collider2D collision)//cuando un cuerpo entra
    {
        if (collision.transform.CompareTag("reiniciar"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//reinicia la esena 
        }

        if (collision.transform.CompareTag("moneda"))
        {
            audioSource.PlayOneShot(monedasond);
            moneda++;
            nummoneda.text = moneda.ToString();
            Destroy(collision.gameObject);
            if (moneda == 7)
            {
                if (Tiempo != null)
                {
                    Tiempo.SetActive(true); 
                }
            }
        }
        if (collision.transform.CompareTag("nivel"))
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
