using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepositoryNode : MonoBehaviour {

    private string html_url;

    public void InitParam(string full_name, string html_url, string star_count, string open_issue_count){
        gameObject.transform.Find("RepoName/Text").GetComponent<Text>().text = full_name;
        gameObject.transform.Find("star").GetComponent<Text>().text = "stargazers_count: " + star_count;
        gameObject.transform.Find("open_issue").GetComponent<Text>().text = "open_issues_count: " + open_issue_count;
        this.html_url = html_url;
    }

    public void JumpToLink(){
        print(html_url);
        // これでURLの先を開ける
        Application.OpenURL(html_url);
    }
}
