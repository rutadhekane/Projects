using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
using UnityEngine.SceneManagement;

public class MyMain : MonoBehaviour {

	public Material highlightMaterial;
	public Material defaultMaterial;
    public GameObject mainMenu;
    public GameObject goBackMenu;
    //public GameObject demo;

    public LMC_Object[] LMCObectArray;
    public GameObject MyColliderObject;
    MyInteractionBehaviour interactionBehaviour;
     public InteractionManager interactionManager;//being set in scene inspector. do not mess.
     public static InteractionManager S_InteractionManager;// do not mess.

	// Use this for initialization
	void Start () {
            Debug.Log(" Start was called!!");
        S_InteractionManager = interactionManager;
        LMC_Object.defaultMaterial = defaultMaterial;
		LMC_Object.highlightMaterial= highlightMaterial;

        //LMC_ObjectAssembly loadAssembly = new LMC_ObjectAssembly(2);
    }

    public void LoadAssembly()
    {
        if (DropdownSelect.m_objId >= 0)
        {
            gameObject.AddComponent<LMC_ObjectAssembly>().LoadAssembly(DropdownSelect.m_objId);
            mainMenu.SetActive(false);
            goBackMenu.SetActive(true);

        }
    }


    public void LoadDemo()
    {
            gameObject.AddComponent<LMC_ObjectAssembly>().LoadAssembly(10);
            goBackMenu.SetActive(true);

        
    }

    public void ResetScene()
    {
        //load ne 
        //Application.LoadLevel("AnotherFinalSceneMoreBetter");
        SceneManager.LoadScene("AnotherFinalSceneMoreBetter");
    }

    public void DemoTutorial()
    {
        //load ne 
        //Application.LoadLevel("AnotherFinalSceneMoreBetter");
        //SceneManager.LoadScene("DemoTutorial");
        //demo.SetActive(true);
        SceneManager.LoadScene("DemoTutorial");
    }

    // Update is called once per frame
    void Update () {
		/*
		Debug.Log("Tracking Begined!! ____________interactionBehaviour.bIsGraspBegin: " + interactionBehaviour.bIsGraspBegin);
		if (interactionBehaviour.bIsGraspBegin) 
		{
			Debug.Log("Tracking Begined!! ____________LMCObectArray.Length: " + LMCObectArray.Length);
			for (int i = 0; i < LMCObectArray.Length; ++i) 
			{
				MyInteractionBehaviour currentlyInteractingWith = LMCObectArray[i].GetComponentInParent<MyInteractionBehaviour> ();
				Debug.Log("Tracking Begined!! ____________currentlyInteractingWith.bIsGraspBegin : " + currentlyInteractingWith.bIsGraspBegin);
			}

		}*/
    }


}
