using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shopping : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int objId;
    public Text description;
    public Text money;
    static int saldo = 10;
    private int precio;
    private GameObject btnObject;
    private Button[] btnGroup;
    // Start is called before the first frame update
    void Start()
    {
        btnObject = GameObject.Find("Productos");
        btnGroup = btnObject.GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        money.text = saldo.ToString();
        if(saldo == 0)
        {
            description.text = "Se te acabo el dinero, continua para conseguir mas";
            foreach (var btn in btnGroup)
            {
                btn.interactable = false;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (objId)
        {
            case 1:
                description.text = "Los condones te protejen de 10 matches que no usen proteccion";
                break;
            case 2:
                description.text = "La ropa te consigue 10 match adicionales";
                break;
            case 3:
                description.text = "El lub te consigue 10 match adicionales";
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        description.text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        switch (objId)
        {
            case 1:
                precio = 10;
                if(saldo >= precio)
                    saldo -= 10;
                break;
            case 2:
                precio = 10;
                if (saldo >= precio)
                    saldo -= 10;
                break;
            case 3:
                precio = 10;
                if (saldo >= precio)
                    saldo -= 10;
                break;
        }
    }
}
