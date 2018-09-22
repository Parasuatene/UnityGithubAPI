using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToJson : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateJson(string fetch){
        ResultSearchRepository rsp = new ResultSearchRepository();
        rsp = JsonUtility.FromJson<ResultSearchRepository>(fetch);
        Debug.Log("total_count: " + rsp.total_count);
    }
}
