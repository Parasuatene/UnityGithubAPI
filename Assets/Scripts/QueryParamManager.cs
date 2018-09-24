using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueryParamManager : MonoBehaviour
{

    private int pageNumber;
    private string repoParam;
    private string sortParam;
    private string orderParam;

    // 与えられたパラメータからクエリを作成して返却
    public string CreateQueryParam(string repoName, int pageNumber = 1, string sort = "", string order = "")
    {
        this.pageNumber = pageNumber;
        string pageParam = "page=" + pageNumber;
        this.repoParam = "&q=" + repoName;
        // sortとorderは指定がある場合, 先頭に&を付与する
        this.sortParam = (sort == "" ? "" : "&" + sort);
        this.orderParam = (order == "" ? "" : "&" + order);

        return pageParam + repoParam + sortParam + orderParam;
    }

    public void ReCreateQueryParam(int pageNumber){
        string pageParam = "page=" + pageNumber;
        string reQueryParam = pageParam + repoParam + sortParam + orderParam;
        StartCoroutine(GameObject.Find("SeardhRepository").GetComponent<SearchRepository>().StartConnection(reQueryParam));
    }

    public int GetPageNumber()
    {
        return this.pageNumber;
    }
}
