using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoTutorial : MonoBehaviour {
    //public GameObject goBackMenu;
    // Use this for initialization
    LMC_ObjectAssembly demoAssemble;
    void Start () {
        demoAssemble = new global::LMC_ObjectAssembly();
        demoAssemble.LoadDemoAssembly();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
