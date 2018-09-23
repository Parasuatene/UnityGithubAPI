using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchButton : MonoBehaviour {

    [SerializeField] GameObject inputFieldObj;
    private InputField inputField;
    private Button button;
    [SerializeField] GameObject searchRepoObj;
    private SearchRepository searchRepo;

	// Use this for initialization
	void Start () {
        inputField = inputFieldObj.GetComponent<InputField>();
        button = gameObject.GetComponent<Button>();
        searchRepo = searchRepoObj.GetComponent<SearchRepository>();
    }

    void Update()
    {
        // 何も入力されていない時はSearch出来ないようにする
        if(inputField.text == ""){
            button.interactable = false;
        }else{
            button.interactable = true;
        }
    }

    // リポジトリ検索ボタン
    public void SearchRepository(){
        string repoName = inputField.text;
        print(repoName);
        string queryParam = CreateQueryParam(repoName);

        // これでURLの先を開ける
        //Application.OpenURL("https://github.com/reactnativecn/react-native-guide");

        // 通信開始
        //StartCoroutine(searchRepo.StartConnection(queryParam));
    }

    // 与えられたパラメータからクエリを作成して返却
    private string CreateQueryParam(string repoName, int pageNumber = 1, string sort = "", string order = "")
    {
        string pageParam = "page=" + pageNumber;
        string repoParam = "&q=" + repoName;
        // sortとorderは指定がある場合, 先頭に&を付与する
        string sortParam = (sort == "" ? "" : "&" + sort);
        string orderParam = (order == "" ? "" : "&" + order);

        return pageParam + repoParam + sortParam + orderParam;
    }
}
