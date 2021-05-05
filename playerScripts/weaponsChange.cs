using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class weaponsChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

   public GameObject[] Guns;
 
   public int gunIndex;

    // Start is called before the first frame update

          public void OnPointerDown(PointerEventData eventData)
    {
        foreach(GameObject gun in Guns)
        {
            gun.gameObject.SetActive(false);
        }

        Guns[gunIndex].gameObject.SetActive(true);

    }
      public void OnPointerUp(PointerEventData eventData)
    {
        
      
     
    }

    
}
