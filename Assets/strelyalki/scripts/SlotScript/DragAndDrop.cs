using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IDropHandler
{
    public CanvasGroup canvasGroup;
    public ScrollRect scrollRect;
    public Transform myPosition;
    Coroutine touchTimer;
    bool isDragging;
    [Inject]
    public void Construct(IInventar sRect){
        scrollRect=sRect.GetComponent<ScrollRect>();
    }
    

    

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Update(){
        
        if(isDragging==false){
            
            transform.position=myPosition.position;

        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        scrollRect.OnBeginDrag(eventData); // scroll ishlashi uchun

        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;

        touchTimer=StartCoroutine(MoveItem());
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            transform.position = Input.mousePosition;
        }
        else
        {
            scrollRect.OnDrag(eventData); // scroll ishlashi uchun
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        scrollRect.OnEndDrag(eventData);

        isDragging = false;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        StopCoroutine(touchTimer);
    }

    IEnumerator MoveItem()
    {
        yield return new WaitForSeconds(0.5f); // 2 sekund juda katta
        isDragging = true;
    }
    public void OnDrop(PointerEventData pedata)
    {
        Debug.Log("Слот не выбрано");
        if (pedata != null)
        {
            pedata.pointerDrag.GetComponent<RectTransform>().position = myPosition.position;

            Transform tempMyPosition=pedata.pointerDrag.GetComponent<DragAndDrop>().myPosition;
            pedata.pointerDrag.GetComponent<DragAndDrop>().myPosition=myPosition;
            myPosition=tempMyPosition;
        }
    }
}