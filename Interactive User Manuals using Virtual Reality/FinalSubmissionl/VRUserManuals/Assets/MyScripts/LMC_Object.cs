using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

/*
 
 The matrials are static and initialized in main.                                                                        |
 The myColliderObject is searched in the begining and initialized in Start(). Thus we need to be carefull about the name.
    
 This object has a string named myColliderName which should match the instance name of collider object. 
 The collider object will get highlghted once we grab the object. This is done by searching the collider by name.     
     
 */

public class LMC_Object : MonoBehaviour {


   string   m_objectType;
   string   m_objectTypeName;
   string   m_objectMeshName;
   Vector3  m_sourcePosition;
   Vector3  m_targetPosition;
   Vector3 m_sourceRotation;
   Vector3 m_targetRotation;
    
    public Transform target;
	public float speed = 3;
	
	public GameObject myColliderObject; 
    private bool bIsSnapped ;
    private bool bInteractionCompleted;


    public MyInteractionBehaviour currentlyInteractingWith;
	public static Material highlightMaterial;
	public static Material defaultMaterial;


  
    void Start () {
        bIsSnapped = false;
        bInteractionCompleted = false;
        currentlyInteractingWith = GetComponentInParent<MyInteractionBehaviour>();
        currentlyInteractingWith.Manager = MyMain.S_InteractionManager;
        

    }
	void Update() {
        if (bInteractionCompleted)
            return;

        if (bIsSnapped)
        {
           
            transform.rotation = (myColliderObject.gameObject.transform.rotation);
            bInteractionCompleted = true;
            Destroy(myColliderObject);//.SetActive = false;
            myColliderObject = null;
            gameObject.GetComponent<MyInteractionBehaviour>().enabled = false;
            return;
        }

      /*  if (currentlyInteractingWith == null)
        {
            Debug.Log("currentlyInteractingWith == null");
            return;
        }
        else
        {
            Debug.Log("currentlyInteractingWith != null  currentlyInteractingWith.bIsGraspBegin : " + currentlyInteractingWith.bIsGraspBegin);
        }*/
		if (currentlyInteractingWith.bIsGraspBegin) {
			OnGrabbing ();
		}
		else 
		{
          
            myColliderObject.gameObject.GetComponent<Renderer> ().material = defaultMaterial;
		}
	}


	public void OnGrabbing()
	{
		
        if(myColliderObject != null)
		    myColliderObject.gameObject.GetComponent<Renderer> ().material = highlightMaterial;
	}



    void OnCollisionEnter(Collision collider1) {
        
        if (myColliderObject == null)
        {
            return;
        }
        Vector3 myPosition = transform.position;
		//float move, dist;
		if (myColliderObject.name == collider1.gameObject.name)
        {
            
            Vector3 Targetposition = myColliderObject.transform.position;// new Vector3 (myPosition.x, myPosition.y, 1.13f);
			transform.position = Targetposition;
            bIsSnapped = true;
            


		}

	}


  
}
