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
           
            Debug.Log("********0 transform.rotation : " + transform.rotation);
            transform.rotation = (myColliderObject.gameObject.transform.rotation);
            bInteractionCompleted = true;
            Debug.Log("********1 transform.rotation : " + transform.rotation);
            Destroy(myColliderObject);//.SetActive = false;
            myColliderObject = null;
            gameObject.GetComponent<MyInteractionBehaviour>().enabled = false;
            return;
        }

        if (currentlyInteractingWith == null)
        {
            Debug.Log("currentlyInteractingWith == null");
            return;
        }
        else
        {
            Debug.Log("currentlyInteractingWith != null  currentlyInteractingWith.bIsGraspBegin : " + currentlyInteractingWith.bIsGraspBegin);
        }
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
		Debug.Log("Tracking Begined!! ____________interactionBehaviour.bIsGraspBegin: True , This : " + this.name );
        if(myColliderObject != null)
		    myColliderObject.gameObject.GetComponent<Renderer> ().material = highlightMaterial;
	}



    void OnCollisionEnter(Collision collider1) {
        
        if (myColliderObject == null)
        {
            return;
        }
        Debug.Log("..............I am done:   ..    " + myColliderObject.name);
        Debug.Log("..............I am donadone:   ..   " + collider1.gameObject.name);//bru
        Vector3 myPosition = transform.position;
		//float move, dist;
		if (myColliderObject.name == collider1.gameObject.name)
        {
            Debug.Log("..............COLLIDED!!!!!!!!!!..............");
            Vector3 Targetposition = myColliderObject.transform.position;// new Vector3 (myPosition.x, myPosition.y, 1.13f);
			transform.position = Targetposition;
            bIsSnapped = true;
            Debug.Log("..............TransformED!!!!!!!!!!..............");


		}

	}
























	/*void OnCollisionEnter(Collision collision)
	{
		Vector3 myPosition = transform.position;
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay (contact.point, contact.normal, Color.blue,15);
			print ("inside the oncollisionenter function");
			Debug.Log(myPosition);
		}
	}
	void OnCollisionStay(Collision collisionInfo)
	{
		float move, dist;
		Vector3 Targetposition= new Vector3(0.04f,0.04f,0.04f);
		foreach (ContactPoint contact in collisionInfo.contacts) {
			Debug.DrawRay (contact.point, contact.normal, Color.blue,15);
			print ("inside the oncollisionstay function");
			Vector3 dir = Targetposition - transform.position;
			dist = dir.magnitude;
			dir = dir.normalized;
			move = speed * Time.deltaTime;
			if (move > dist)
				move = dist;
			transform.Translate (dir * move);


		}
	}
	void OnCollisionExit(Collision collisionInfo) {
		print("No longer in contact with " + collisionInfo.transform.name);
	}*/
}
