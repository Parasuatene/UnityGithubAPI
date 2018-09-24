using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PagingManager : MonoBehaviour
{
    private QueryParamManager queryParamManager;
    public int pageNumber;
    public int maxPageNumber;

    // Use this for initialization
    void Start()
    {
        queryParamManager = GameObject.Find("QueryParamManager").GetComponent<QueryParamManager>();
        pageNumber = queryParamManager.GetPageNumber(); // 現在のページ番号を取得
        maxPageNumber = GameObject.Find("SearchRepository").GetComponent<SearchRepository>().MaxPageNumber(); // 最大ページ数を取得
    }

    public void Paging(int number)
    {
        pageNumber += number;
        queryParamManager.ReCreateQueryParam(pageNumber);
    }
}