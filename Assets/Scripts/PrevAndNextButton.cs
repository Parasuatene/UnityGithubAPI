using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrevAndNextButton : MonoBehaviour
{
    public enum Type
    {
        prev, next
    }

    public Type type;

    private QueryParamManager queryParamManager;
    private int pageNumber;
    private int maxPageNumber;
    private Button button;

    // Use this for initialization
    void Start()
    {
        queryParamManager = GameObject.Find("QueryParamManager").GetComponent<QueryParamManager>();
        pageNumber = queryParamManager.GetPageNumber(); // 現在のページ番号を取得
        maxPageNumber = GameObject.Find("SearchRepository").GetComponent<SearchRepository>().MaxPageNumber(); // 最大ページ数を取得
        button = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(type == Type.prev){
            if(pageNumber == 1){
                button.interactable = false;
            }else{
                button.interactable = true;
            }
        }else{
            if(pageNumber == maxPageNumber){
                button.interactable = false;
            }else{
                button.interactable = true;
            }
        }
    }

    public void Paging(){
        if(type == Type.prev){
            pageNumber--;
        }else{
            pageNumber++;
        }
        queryParamManager.ReCreateQueryParam(pageNumber);
    }
}