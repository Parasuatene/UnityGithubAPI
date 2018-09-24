using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPanel : MonoBehaviour
{

    [SerializeField] GameObject inputFieldObj;
    private InputField inputField;
    private Button button;
    [SerializeField] GameObject searchRepoObj;
    private SearchRepository searchRepo;

    // Use this for initialization
    void Start()
    {
        inputField = inputFieldObj.GetComponent<InputField>();
        button = gameObject.GetComponent<Button>();
        searchRepo = searchRepoObj.GetComponent<SearchRepository>();
    }

    void Update()
    {
        // 何も入力されていない時はSearch出来ないようにする
        if (inputField.text == "")
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    // リポジトリ検索ボタン
    public void SearchRepository()
    {
        string repoName = inputField.text;
        print(repoName);
        string queryParam = GameObject.Find("QueryParamManager").GetComponent<QueryParamManager>().CreateQueryParam(repoName);
        // 通信開始
        StartCoroutine(searchRepo.StartConnection(queryParam));
    }
}