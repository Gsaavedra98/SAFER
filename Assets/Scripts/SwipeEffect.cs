using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

public class SwipeEffect : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 _initialPosition;
    private float _distanceMoved;
    private bool _swipeLeft;

    public event Action cardMoved;

    private MatchHandler matchHandler;

    public string dato1;
    public string dato2;
    public string dato3;

    

    private void Start()
    {
        matchHandler = GameObject.Find("CanvasMatch").GetComponent<MatchHandler>();
        dato1 = transform.GetChild(2).GetComponent<RandomSample>().clean;
        dato2 = transform.GetChild(2).GetComponent<RandomSample>().protection;
        dato3 = transform.GetChild(2).GetComponent<RandomSample>().ulti;

        
    }

    public void OnBeginDrag(PointerEventData eventData) //Metodo para guardar la posicion inicial al inicio del arrastre
    {
        _initialPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData) //Metodo para mover la carta hacia la izq o derecha en el eje X
    {
        transform.localPosition = new Vector2(x: transform.localPosition.x + eventData.delta.x, transform.localPosition.y);

        if (transform.localPosition.x - _initialPosition.x > 0)
        {
            transform.localEulerAngles = new Vector3(x: 0, y: 0, z: Mathf.LerpAngle(a: 0, b:-30,
                t: (_initialPosition.x + transform.localPosition.x)/(Screen.width/2)));
        }
        else
        {
            transform.localEulerAngles = new Vector3(x: 0, y: 0, z: Mathf.LerpAngle(a: 0, b: 30,
                t: (_initialPosition.x - transform.localPosition.x) / (Screen.width / 2)));
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _distanceMoved = Mathf.Abs(f: transform.localPosition.x - _initialPosition.x);
        if(_distanceMoved < 0.4 * Screen.width)
        {
            transform.localPosition = _initialPosition;
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            if(transform.localPosition.x > _initialPosition.x)
            {
                _swipeLeft = false;
                matchHandler.Acierto();
                matchHandler.Match();
            }
            else
            {
                _swipeLeft = true;
                matchHandler.Error();
                
            }

            cardMoved?.Invoke();
            StartCoroutine(routine: MovedCard());

        }
        
    }
    
    private IEnumerator MovedCard()
    {
        float time = 0;
        while(GetComponent<Image>().color != new Color(r: transform.GetComponent<Image>().color.r, g: transform.GetComponent<Image>().color.g, b: transform.GetComponent<Image>().color.b, a: 0))
        {
            time += Time.deltaTime;
            if (_swipeLeft)
            {
                transform.localPosition = new Vector3(x: Mathf.SmoothStep(from: transform.localPosition.x,
                    to: transform.localPosition.x - Screen.width,t: 4 * time), y: transform.localPosition.y, z: 0);
                
            }
            else
            {
                transform.localPosition = new Vector3(x: Mathf.SmoothStep(from: transform.localPosition.x,
                    to: transform.localPosition.x + Screen.width, t: 4 * time), y: transform.localPosition.y, z: 0);
                
            }
            GetComponent<Image>().color = new Color(r: transform.GetComponent<Image>().color.r, g: transform.GetComponent<Image>().color.g, b: transform.GetComponent<Image>().color.b, a: Mathf.SmoothStep(from: 1, to: 0, t: 4 * time));
            yield return null;
        }
        Destroy(gameObject);  
    }

    
}
