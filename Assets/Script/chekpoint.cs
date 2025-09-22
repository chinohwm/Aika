using Unity.VisualScripting;
using UnityEngine;

public class chekpoint : MonoBehaviour
{
    public AudioClip chek_point;
    public AudioSource audioSource;//controla los sonidos del jugador ej saltar
      void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(chek_point);
            collision.GetComponent<chekpoint_aparece>().ReachedCheckPoint(transform.position.x, transform.position.y);
        }
    }
}
