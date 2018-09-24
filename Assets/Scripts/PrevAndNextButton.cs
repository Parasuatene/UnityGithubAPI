using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    prev, next
};

public class PrevAndNextButton : MonoBehaviour
{

    private QueryParamManager queryParamManager;
    private int pageNumber;

    // Use this for initialization
    void Start()
    {
        queryParamManager = GameObject.Find("QueryParamManager").GetComponent<QueryParamManager>();
        pageNumber = queryParamManager.GetPageNumber();
    }

    // Update is called once per frame
    void Update()
    {

    }
}