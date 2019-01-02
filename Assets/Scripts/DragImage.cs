using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DragImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject myImage;
    int id;
    public static event Action DragEvent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GetComponent<Image>().sprite != null)
        {
            myImage = new GameObject("myImage");
            myImage.transform.SetParent(transform.root, false);
            myImage.transform.SetAsLastSibling();
            myImage.AddComponent<Image>().sprite = GetComponent<Image>().sprite;
            myImage.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GetComponent<Image>().sprite != null)
        {
            SetDraggedPosition(eventData);
            //myImage.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GetComponent<Image>().sprite != null)
        {

            if (eventData.pointerEnter != null && eventData.pointerEnter.tag == "forging")
            {
                id = int.Parse(myImage.GetComponent<Image>().sprite.name);

                if (eventData.pointerEnter.GetComponent<Image>().sprite.name == "0")
                {
                    eventData.pointerEnter.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                    Destroy(myImage);
                    id = int.Parse(myImage.GetComponent<Image>().sprite.name);
                    GoodsModel gm = Save.GoodList.Find(x => x.Id == id);
                    gm.Num -= 1;
                    DragEvent();
                }
                else
                {
                    GoodsModel gm1 = Save.GoodList.Find(x => x.Id == id);
                    gm1.Num -= 1;
                    id = int.Parse(eventData.pointerEnter.GetComponent<Image>().sprite.name);
                    eventData.pointerEnter.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                    Destroy(myImage);
                    GoodsModel gm = Save.GoodList.Find(x => x.Id == id);
                    gm.Num += 1;
                    DragEvent();
                    //Sprite temp = eventData.pointerEnter.GetComponent<Image>().sprite;
                    //eventData.pointerEnter.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                    //GetComponent<Image>().sprite = temp;
                    //Destroy(myImage);
                }
            }
            else
            {
                Destroy(myImage);
            }
        }
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(myImage.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            myImage.transform.position = globalMousePos;
        }

    }
}