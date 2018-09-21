using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FetchRepositoryData : MonoBehaviour {

    private string url = "https://api.github.com/search/repositories?q=React+in:name&sort=stars";

    // Use this for initialization
    void Start () {
        print("start関数");
        StartCoroutine("StartConnection");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator StartConnection()
    {
        print("コルーチン開始");

        using (WWW www = new WWW(url))
        {
            while (!www.isDone)
            { // ダウンロードの進捗を表示
                print(Mathf.CeilToInt(www.progress * 100));
                yield return null;
            }

            yield return www;

            print(www.text);
        }

    }
}
