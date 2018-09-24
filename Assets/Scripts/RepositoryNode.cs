using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepositoryNode : MonoBehaviour {

    private string html_url;

    public void InitParam(string full_name, string html_url){
        gameObject.transform.Find("RepoName/Text").GetComponent<Text>().text = full_name;
        this.html_url = html_url;
    }

    public void JumpToLink(){
        print(html_url);
        // これでURLの先を開ける
        Application.OpenURL(html_url);
    }
}
