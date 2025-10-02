using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class contador : MonoBehaviour
{
    public TextMeshProUGUI ContadorTexto;

    public int Minutos;
    public float Segundos;
    public Color ColorAviso;
    public float SegundosLimites;

    void Start()
    {
        ActulizarContador();
    }
    void Update()
    {
        Segundos -= Time.deltaTime;

        if (Segundos <= 0)
        {
            if (Minutos == 0)
            {
                Accion();
            }
            else
            {
                Segundos = 60;
                Minutos -= 1;
            }
           
        }
        ActulizarContador();
        if (Segundos < SegundosLimites && Minutos < 1)
        {
            ContadorTexto.color = ColorAviso;
        }
    }

    public void ActulizarContador()
    {
        if (Segundos < 9.5f)
        {
            ContadorTexto.text = Minutos.ToString() + ":0" + Segundos.ToString("f0");
        }
        else
        {
            ContadorTexto.text = Minutos.ToString() + ":" + Segundos.ToString("f0");
        }

    }

    public void Accion()
    {




    }
}
