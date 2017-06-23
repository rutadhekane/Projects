using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
using JsonFx.Json;
using System;

public class LMC_ObjectAssembly  : MonoBehaviour {


    public List<LMC_Object> arrayOfLMC_Objects;
    int totalObjects;
    Vector3 SourceScale;
    DatabaseManager dbManager;

    private string objComponentUrl = "http://127.0.0.1/ImportComponents.php";

    //make a class for objType like component

    public class Component
    {
        public string
            objId,
            sourcePos,
            targetPos,
            sourceRot,
            targetRot,
            meshName;
    }

    public void LoadDemoAssembly()
    {

        instantiateLMCObj(
            "3DModels",
            "Second",
            "ply",
             new Vector3(1.15f, 0.6f, 15.24f),//src pos
             new Vector3(0.81f, 0.46f, 15.21f), //tar pos
             new Vector3(0.001f, 0.001f, 0.001f),//src rot
             new Vector3(0.001f, 0.001f, 0.001f) //tar rot
            );

    }



    public void LoadAssembly(int objId)
    {

        dbManager = new global::DatabaseManager();
     
        arrayOfLMC_Objects = new List<LMC_Object>();
        string result = "";
        string post_url = objComponentUrl + "?objId=" +objId;
        Debug.Log("post_url >>> : " + post_url);
        StartCoroutine(dbManager.LoadDB_IEnumerator(post_url, result, LoadAssembly));//this will call the function asynchronously and data loading from db will take time.

    }

    public  void LoadAssembly(string result)
    {
        Debug.Log("---------resultStr : " + result);

        Component[] jsonObject = JsonReader.Deserialize<Component[]>(result.ToString());
        int i = 0;
        foreach (var row in jsonObject)
        {
            ++i;
            Debug.Log(" I : " + i + " row.meshName  >> : " + row.meshName);
            Debug.Log(" I : " + i + " row.targetPos >> : " + row.targetPos);
            Debug.Log(" I : " + i + " row.sourceRot >> : " + row.sourceRot);

            instantiateLMCObj("3DModels", "Second", row.meshName, StringToVector(row.sourcePos), StringToVector(row.targetPos), StringToVector(row.sourceRot), StringToVector(row.targetRot));

        }

     }

    Vector3 StringToVector(string vectorStr)
    {
        string vec1 = vectorStr;// "0.141, -0.720, 0.231";
        string[] vecs = vec1.Split(',');

        return new Vector3(float.Parse(vecs[0]), float.Parse(vecs[1]), float.Parse(vecs[2]));
    }

   
    void instantiateLMCObj(string objectType, string objectTypeName, string objectMeshName, Vector3 sourcePosition, Vector3 targetPosition, Vector3 sourceRotation, Vector3 targetRotation)
    {
        if(objectMeshName=="ply")
        {
            SourceScale = new Vector3(0.0005f, 0.0005f, 0.0005f);
        }
        else
            SourceScale = new Vector3(0.3f, 0.3f, 0.3f);
        string strLMCPrefab = "LMC_ObjectPrefab";
        string strColliderPrefab = "Collider";

        GameObject gameObj = GameObject.Instantiate(Resources.Load(strLMCPrefab, typeof(GameObject))) as GameObject;
        LMC_Object instanceOfLMCObj = gameObj.GetComponent<LMC_Object>();
        
        instanceOfLMCObj.name = objectMeshName;

        string strMesh = objectType + "/" + objectTypeName + "/" + objectMeshName;
        Mesh m = (Mesh)Resources.Load(strMesh, typeof(Mesh));
        instanceOfLMCObj.GetComponent<MeshFilter>().mesh = m;

        //add a box collider, which will have the box shape of size of current mesh
        BoxCollider instanceLMC_BoxCollider = gameObj.AddComponent<BoxCollider>();
       
        
        //add collder object
        instanceOfLMCObj.myColliderObject = GameObject.Instantiate(Resources.Load(strColliderPrefab, typeof(GameObject))) as GameObject;
        instanceOfLMCObj.myColliderObject.name = "ColliderOf" + instanceOfLMCObj.name; //ColliderOfPly
        instanceOfLMCObj.myColliderObject.GetComponent<MeshFilter>().mesh = m;
        //add a box collider to the pink wala object, which will have the box shape of size of current mesh
        instanceOfLMCObj.myColliderObject.AddComponent<BoxCollider>();


        //temp range to be considered = 0.6 to 0.99
        //scale 0.374
        instanceOfLMCObj.transform.position = sourcePosition;
        instanceOfLMCObj.transform.localScale = SourceScale;
        instanceOfLMCObj.transform.rotation = Quaternion.Euler(sourceRotation);

        
        instanceOfLMCObj.myColliderObject.transform.position = targetPosition;
        instanceOfLMCObj.myColliderObject.transform.localScale = SourceScale;
        instanceOfLMCObj.myColliderObject.transform.rotation = Quaternion.Euler(targetRotation);
        
        
        
       }


}
