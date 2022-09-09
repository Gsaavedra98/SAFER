using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSample : MonoBehaviour
{
    public Image cBase;
    public Image cBoca;
    public Image cOjos;
    public Image cBg;
    public Text cNames;
    public Text txtclean;
    public Text txtprotection;
    public Text txtlastTime;
    public GameObject bg;

    public Color[] backColor;
    public string[] names;
    public string[] limpieza;
    public string[] proteccion;
    public string[] ultimaVez;
    public Sprite[] Base;
    public Sprite[] Boca;
    public Sprite[] Ojos;
    public Sprite[] BG;

    public string clean;
    public string protection;
    public string ulti;

    // Use this for initialization
    void Start()
    {
        RandomizeCharacter();
    }

    public void RandomizeCharacter()
    {

        cBase.sprite = Base[Random.Range(0, Base.Length)];
        cBoca.sprite = Boca[Random.Range(0, Boca.Length)];
        cOjos.sprite = Ojos[Random.Range(0, Ojos.Length)];
        cBg.sprite = BG[Random.Range(0, BG.Length)];
        cNames.text = names[Random.Range(0, names.Length)];

        txtclean.text = limpieza[Random.Range(0, limpieza.Length)];
        txtprotection.text = proteccion[Random.Range(0, proteccion.Length)];
        txtlastTime.text = ultimaVez[Random.Range(0, ultimaVez.Length)];

        if (txtclean.text == "baja")
        {
            txtclean.color = backColor[0];
        }
        else if (txtclean.text == "media")
        {
            txtclean.color = backColor[1];
        }
        else
        {
            txtclean.color = backColor[2];
        }

        bg.GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        cNames.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        clean = txtclean.text;
        protection = txtprotection.text;
        ulti = txtlastTime.text;
    }

}
