using UnityEngine;

public class chekpoint_aparece : MonoBehaviour
{
    private float chekpointPositionX, chekpointPositionY;





    void Start()
    {
        if (PlayerPrefs.GetFloat("chekpointPositionX")!= 0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("chekpointPositionX"), PlayerPrefs.GetFloat("chekpointPositionY")));
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("chekpointPositionX", x);
        PlayerPrefs.SetFloat("chekpointPositionY",y);
    }
}
