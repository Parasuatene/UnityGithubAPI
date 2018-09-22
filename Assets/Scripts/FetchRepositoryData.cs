using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniJSON;

public class FetchRepositoryData : MonoBehaviour
{

    private string url = "https://api.github.com/search/repositories?q=React+in:name&sort=stars";

    // Use this for initialization
    void Start()
    {
        print("start関数");
        //StartCoroutine("StartConnection");
    }

    // Update is called once per frame
    void Update()
    {

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
            string fetchJson = www.text;

            // JSONデータは最初は配列から始まるので、Deserialize（デコード）した直後にリストへキャスト      
            IList fetchRepoList = (IList)Json.Deserialize(fetchJson);

            List<Dictionary<string, string>> itemDicList = new List<Dictionary<string, string>>();

            foreach(IDictionary fetch in fetchRepoList){
                string total_count = fetch["total_count"].ToString();
                IList items = (IList)fetch["items"];

                foreach (IDictionary item in items)
                {
                    Dictionary<string, string> itemDic = new Dictionary<string, string>();
                    itemDic.Add("name", (string)item["name"]);
                    itemDic.Add("full_name", (string)item["full_name"]);
                    itemDic.Add("html_url", (string)item["html_url"]);

                    // リストに追加
                    itemDicList.Add(itemDic);
                }
            }

            print("name: " + itemDicList[0]["name"]);
            print("full_name: " + itemDicList[0]["full_name"]);
            print("html_url: " + itemDicList[0]["html_url"]);

        }
    }
}