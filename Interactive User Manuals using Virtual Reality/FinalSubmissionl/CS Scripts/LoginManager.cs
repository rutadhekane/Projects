using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoginManager : MonoBehaviour {
    #region Variable
    //public section
    public InputField userNameInput;
    public InputField passwordInput;


    public InputField createUserNameInput;
    public InputField createUserNameInput_1;
    public InputField createPasswordInput;
    public InputField createPasswordInput_1;

    public GameObject messagePanel;
    public GameObject createAccountPanel;
    public Text ErrorString;

    	
	
	private string CreateAccountUrl="http://127.0.0.1/CreateAccount.php";
	private string LoginUrl="http://127.0.0.1/UserLoginT.php";
	private string CurrentMenu="Login";


    #endregion


    void Start() {
        messagePanel.SetActive(false);
        createAccountPanel.SetActive(false);
	}//End of Start

	//Main GUI function

	void OnGUI()
	{
	
	}

     

    #region CustomMethods
   
    #endregion


    #region CoRoutines 




    public void CreateAccount()
    {
       
        StartCoroutine(Signup());
       
    }

    public void Login()
    {
       
        StartCoroutine(LoginAccount());
        
    }

    public IEnumerator Signup()
{
       
        string username = createUserNameInput.text;
        string password = createPasswordInput.text;
        
		string post_url = CreateAccountUrl + "?Email=" + WWW.EscapeURL(username) + "&Password=" + WWW.EscapeURL(password);// +"&hash=" + hash;
		



		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done


		if (hs_post.error != null)
		{
			Debug.LogError ("Cannot Connect to Login Account!");
			Debug.LogError ("server returned: " + hs_post.error);
			
		}

		else {
			string LogText = hs_post.text;
			if(LogText.ToString().Equals("Success")){
				CurrentMenu = "Login";
			}
		}
}

IEnumerator LoginAccount()
{
        string username = userNameInput.text;
        string password = passwordInput.text;

        string post_url = LoginUrl + "?Email=" + WWW.EscapeURL(username) + "&Password=" + WWW.EscapeURL(password);// +"&hash=" + hash;
		
        
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done

		if (hs_post.error != null)
		{
			Debug.LogError ("Cannot Connect to Login Account!");
			Debug.LogError ("server returned: " + hs_post.error);
			
		}
		else
		{
			
			string LogText = hs_post.text;
			//print (LogText);

			 switch (LogText.ToString())
            {
                case "Success":
                    SceneManager.LoadScene("LetUsFinalizeThisSceneForNoReason");
                    break;
                case "WrongPassword":
                case "EmailDoesNotExist":
                    messagePanel.SetActive(true);
                    ErrorString.text = "Email Id does not exists.. Please create account!!!!!";
                    break;
                default:
                    break;
            }
		}
}

    public void HideErrorMessage()
    {
        messagePanel.SetActive(false);
    }

    public void showCreateAccountPanel()
    {
        createAccountPanel.SetActive(true);
    }

    public void hideCreateAccountPanel()
    {
        createAccountPanel.SetActive(false);
    }

    #endregion

}
