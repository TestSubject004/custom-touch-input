using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touchmov : MonoBehaviour, IDragHandler,  IPointerDownHandler, IPointerUpHandler
{
    
    private Image img;
    private Vector2 pos;
    private bool move = false;
    public bool jump = false;
    private PointerEventData pointer = new PointerEventData(EventSystem.current);



    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        
    }

    void Update()
    {
        /*if (move)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            Vector2 temp = InputAxis(pointer);
            player.p_move(pos.x, pos.y);
        }*/
       
    }


    public void OnDrag(PointerEventData eventData)
    {
        
        //Debug.Log(eventData.position.x.ToString());
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            img.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = pos.x / (img.rectTransform.sizeDelta.x/2);
            pos.y = pos.y / (img.rectTransform.sizeDelta.y/2);
            //Debug.Log("dragged");
            //Debug.Log(pos.x.ToString() + "/" + pos.y.ToString());
            if (pos.magnitude > 1.5f)
            {
                pos = pos.normalized;
               // Debug.Log("normalized");
              //  Debug.Log(pos.x.ToString() + "/" + pos.y.ToString());
                jump = true;
            }
            

            
        }
    }

    

    /*public void OnPointerClick(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            img.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = pos.x / (img.rectTransform.sizeDelta.x/2);
            pos.y = pos.y / (img.rectTransform.sizeDelta.y/2);
            //Debug.Log("clicked");
            //Debug.Log(pos.x.ToString() + "/" + pos.y.ToString());
            
        }
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            img.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = pos.x / (img.rectTransform.sizeDelta.x/2);
            pos.y = pos.y / (img.rectTransform.sizeDelta.y/2);
            //Debug.Log("clicked");
            //Debug.Log(pos.x.ToString() + "/" + pos.y.ToString());

            if (pos.magnitude > 0.5f)
            {
                pos = pos.normalized;
                //Debug.Log("normalized");
               // Debug.Log(pos.x.ToString() + "/" + pos.y.ToString());
            }

            if (Mathf.Abs(pos.x) < 0.5 && Mathf.Abs(pos.y) < 0.5)
            {
                //Debug.Log("Jump");
                jump = true;
            }
            else
            {
              //  Debug.Log("walk");
                move = true;
               // player.move(pos.x, pos.y);
            }

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("pointer down");
        move = false;
        jump = false;
    }

   public float Xinput()
    {
        if (move)
        {
            return pos.x;
        }

        else
            return Input.GetAxisRaw("Horizontal");
    }

    public float Yinput()
    {
        if (move )
        {
            return pos.y;
        }
        else
            return Input.GetAxisRaw("Vertical"); 
    }

}
