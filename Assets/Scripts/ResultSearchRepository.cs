using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct items{
    public int id;
    public string full_name;
}

[Serializable]
public class ResultSearchRepository : MonoBehaviour {

    // 検索ヒット数
    public int total_count;
    public items items;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
