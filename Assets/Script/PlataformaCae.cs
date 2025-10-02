using UnityEngine;

public class PlataformaCae : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Vector3 posInicial;
    [SerializeField] private float tiempoEspera;
    [SerializeField] private float tiempoReaparicion;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Invoke("Cae", tiempoEspera);
            Invoke("Reaparece", tiempoReaparicion);
        }
    }
    private void Cae()
    {
        rBody.isKinematic = false;
    }
    private void Reaparece()
    {
        rBody.linearVelocity = Vector3.zero;
        rBody.isKinematic = true;
        transform.position = posInicial;
    }
}
