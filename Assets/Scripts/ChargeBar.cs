using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Clase que maneja las barras de salud, tanto de enmigos como del jugador.
//Tambien maneja el movimiento del turn Counter y que cambie.
public class ChargeBar : MonoBehaviour
{
    public Slider slider;
    public GameObject barUI;

    public void toggleUI(bool x)
    {
        barUI.SetActive(x);
    }

    //Modifica visualmente la barra
    public void setCharge(float charge)
    {
        slider.value = charge;
    }

    public void setMaxCharge(float charge)
    {
        slider.maxValue = charge;
        slider.value = charge;
    }

}
