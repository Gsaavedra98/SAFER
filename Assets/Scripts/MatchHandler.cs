using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchHandler : MonoBehaviour
{
    public Text txtLimpieza;
    public Text txtMetodo;
    public Text txtUlt;
    public Text txtMatch;
    private int contadorLimpieza = 0;
    private int contadorMetodo = 0;
    private int contadorUlt = 0;
    public int contadorMatch = 11;
    SwipeEffect swipeEffect;

    private AudioSource audioSource;
    public AudioClip acierto;
    public AudioClip error;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        txtMatch.text = contadorMatch.ToString();
        
    }
    private void Update()
    {
        swipeEffect = FindObjectOfType<SwipeEffect>();
        if(contadorMatch <= 0)
        {
            PasarNivel();
        }
    }

    private void PasarNivel()
    {
        SceneManager.LoadScene("Tienda");
    }

    public void Match()
    {
        contadorMatch--;
        switch (swipeEffect.dato1)
        {
            case "baja":
                contadorLimpieza += 0;
                break;
            case "media":
                contadorLimpieza += 1;
                break;
            case "alta":
                contadorLimpieza += 2;
                break;
        }
        switch (swipeEffect.dato2)
        {
            case "si":
                contadorMetodo++;
                break;
            case "no":
                contadorMetodo += 0;
                break;
        }
        switch (swipeEffect.dato3)
        {
            case "1 semana":
                contadorUlt += 0;
                break;
            case "1 mes":
                contadorUlt += 1;
                break;
            case "hace mucho":
                contadorUlt += 2;
                break;
        }
        txtLimpieza.text = contadorLimpieza.ToString();
        txtMetodo.text = contadorMetodo.ToString();
        txtUlt.text = contadorUlt.ToString();
        txtMatch.text = contadorMatch.ToString();
    }

    public void Acierto()
    {
        audioSource.PlayOneShot(acierto);
    }
    public void Error()
    {
        audioSource.PlayOneShot(error);
    }
}
