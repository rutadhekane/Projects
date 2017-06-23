using System.Collections;
using UnityEngine;
using JsonFx.Json;
using UnityEngine.UI;



public class DropdownSelect : MonoBehaviour {

    // Use this for initialization
    public Dropdown myObjTypeDropdown;
    public Dropdown myObjNameDropdown;
    DatabaseManager dbManager;
    ArrayList m_objTypes;
    ArrayList m_objNames;
    public static int m_objId = -1;
    public bool m_loading = false;
    private string objTypeUrl = "http://127.0.0.1/ImportObjType.php";

    public class objectType
    {
        public string
            objId,
            Type,
            Name;
    }

    void Start () {
        dbManager = new global::DatabaseManager();
        string result = "";

        StartCoroutine(dbManager.LoadDB_IEnumerator(objTypeUrl + "?Type=-1",result, LoadDropdownObjTypes));//this will call the function asynchronously and data loading from db will take time.


        myObjTypeDropdown.onValueChanged.AddListener(delegate {
            LoadNamesFromType(myObjTypeDropdown);
        });

        myObjNameDropdown.onValueChanged.AddListener(delegate {
            LoadAssembly(myObjNameDropdown);
        });
    }


    public void LoadDropdownObjTypes(string result)
    {
        myObjTypeDropdown.options.Clear();
        

        objectType[] jsonObject = JsonReader.Deserialize<objectType[]>(result.ToString());
        m_objTypes = new ArrayList();

        foreach (var row in jsonObject)
        {
            myObjTypeDropdown.options.Add(new Dropdown.OptionData(row.Type));
            m_objTypes.Add(row.Type);
        }

        if (myObjTypeDropdown.options.Count > 0)
        {
            myObjTypeDropdown.value = 1;
        }
       
    }


    public void LoadDropdownObjNames(string result)
    {
        objectType[] jsonObject = JsonReader.Deserialize<objectType[]>(result.ToString());
        m_objNames = new ArrayList();
        myObjNameDropdown.options.Clear();

        foreach (var row in jsonObject)
        {
            myObjNameDropdown.options.Add(new Dropdown.OptionData(row.Name));
            m_objNames.Add(row);
        }

        if (myObjNameDropdown.options.Count > 0)
        {
            myObjNameDropdown.value = 1;
        }
    }

    public void LoadNamesFromType(Dropdown target)
    {
        string result = "";
        StartCoroutine(dbManager.LoadDB_IEnumerator(objTypeUrl + "?Type=" + m_objTypes[target.value], result, LoadDropdownObjNames));//this will call the function asynchronously and data loading from db will take time.

    }
    
    public void LoadAssembly(Dropdown target)
    {
        if (m_loading == false)
        {
            m_loading = true;
        }
        
        objectType objTypeRow = m_objNames[target.value] as objectType;
        m_objId = int.Parse(objTypeRow.objId);
        
    }


}
