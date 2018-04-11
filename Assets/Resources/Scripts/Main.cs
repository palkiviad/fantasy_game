using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Main : MonoBehaviour
{
    // Use this for initialization
    protected void Start()
    {
        Debug.Log("Hello my fantasy game!");
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add( new MultipartFormDataSection("name=authorize") );
        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080", formData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        
        Debug.Log("SERVER SAYS : " + www.downloadHandler.text);
    }
}