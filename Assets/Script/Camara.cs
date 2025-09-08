using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;//para que siga al jugador
    

    public void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); 
    }

}
