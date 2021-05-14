using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class fire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public Animator animator;
    public bool inState;
    public float m_currentLayerWeight;
     public float m_current2LayerWeight;
    public float smoothTime = 0.3f;
    public float yVelocity = 0.0f;
    bool outState;  // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inState == true)
        {
            m_currentLayerWeight = animator.GetLayerWeight(animator.GetLayerIndex("topPortion"));
              m_current2LayerWeight = animator.GetLayerWeight(animator.GetLayerIndex("bottom"));
            m_currentLayerWeight = Mathf.SmoothDamp(m_currentLayerWeight, 1.0f, ref yVelocity, smoothTime);
            m_current2LayerWeight = Mathf.SmoothDamp(m_current2LayerWeight, 0.0f, ref yVelocity, smoothTime);
            
            animator.SetLayerWeight(animator.GetLayerIndex("topPortion"), m_currentLayerWeight);
            animator.SetLayerWeight(animator.GetLayerIndex("bottom2"), m_currentLayerWeight);
              animator.SetLayerWeight(animator.GetLayerIndex("bottom"), m_current2LayerWeight);
          
            if (m_currentLayerWeight == 1.0f)
            {
                inState = false;

            }
        }
        if (outState == true)
        {
            m_currentLayerWeight = animator.GetLayerWeight(animator.GetLayerIndex("topPortion"));
                 m_current2LayerWeight = animator.GetLayerWeight(animator.GetLayerIndex("bottom"));
        
            m_currentLayerWeight = Mathf.SmoothDamp(m_currentLayerWeight, 0.0f, ref yVelocity, smoothTime);
               m_current2LayerWeight = Mathf.SmoothDamp(m_current2LayerWeight, 1.0f, ref yVelocity, smoothTime);
            
         
            animator.SetLayerWeight(animator.GetLayerIndex("topPortion"), m_currentLayerWeight);
            animator.SetLayerWeight(animator.GetLayerIndex("bottom2"), m_currentLayerWeight);
             animator.SetLayerWeight(animator.GetLayerIndex("bottom"), m_current2LayerWeight);
            if (m_currentLayerWeight == 0.0f)
            {
                outState = false;

            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        inState = true;
        outState = false;
        //animator.SetLayerWeight(animator.GetLayerIndex("topPortion"), 1.0f);
        //animator.SetLayerWeight(animator.GetLayerIndex("bottom2"), 1.0f);

    }
    //event which calls when button is pressed up
    public void OnPointerUp(PointerEventData eventData)
    {

        inState = false;
        outState = true;
       /* animator.SetLayerWeight(animator.GetLayerIndex("topPortion"), 0.0f);
        animator.SetLayerWeight(animator.GetLayerIndex("bottom2"), 0.0f);
        animator.SetLayerWeight(animator.GetLayerIndex("bottom"), 1.0f);*/
    }

}
