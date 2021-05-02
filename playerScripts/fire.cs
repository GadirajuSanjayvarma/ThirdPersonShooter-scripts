using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class fire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

public Animator animator;    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public void OnPointerDown(PointerEventData eventData)
    {
           
      animator.SetLayerWeight(animator.GetLayerIndex("topPortion"),1.0f);
        animator.SetLayerWeight(animator.GetLayerIndex("bottom2"),1.0f);
          animator.SetLayerWeight(animator.GetLayerIndex("bottom"),0.0f);
    }
    //event which calls when button is pressed up
    public void OnPointerUp(PointerEventData eventData)
    {
        
      
        animator.SetLayerWeight(animator.GetLayerIndex("topPortion"),0.0f);
        animator.SetLayerWeight(animator.GetLayerIndex("bottom2"),0.0f);
          animator.SetLayerWeight(animator.GetLayerIndex("bottom"),1.0f);
    }

}
