using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class ConvertFromJson : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ConvertToDictionary();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConvertToDictionary()
    {
        string fetchJson = "[" +
                                "{" +
                                    "\"total_count\": 470522," +
                                    "\"items\": [" +
                                        "{" +
                                            "\"id\": 10270250," +
                                            "\"name\": \"react\"," +
                                            "\"full_name\": \"facebook/react\"," +
                                            "\"html_url\": \"https://github.com/facebook/react\"" +
                                            "\"owner\": [" +
                                                "{" +
                                                    "\"avatar_url\": \"https://avatars3.githubusercontent.com/u/69631?v=4\"" +
                                                "}" +
                                            "]" +
                                        "}," +
                                        "{" +
                                            "\"id\": 29028775," +
                                            "\"name\": \"react-native\"," +
                                            "\"full_name\": \"facebook/react-native\"," +
                                            "\"html_url\": \"https://github.com/facebook/react-native\"" +
                                            "\"owner\": [" +
                                                "{" +
                                                    "\"avatar_url\": \"https://avatars2.githubusercontent.com/u/1696866?v=4\"" +
                                                "}" +
                                            "]" +
                                        "}" +
                                    "]" +
                                "}" +
                            "]";
        print(fetchJson);

        // JSONデータは最初は配列から始まるので、Deserialize（デコード）した直後にリストへキャスト      
        IList fetchRepoList = (IList)Json.Deserialize(fetchJson);

        List<Dictionary<string, string>> itemDicList = new List<Dictionary<string, string>>();

        foreach (IDictionary fetch in fetchRepoList)
        {
            string total_count = fetch["total_count"].ToString();
            IList items = (IList)fetch["items"];

            foreach (IDictionary item in items)
            {
                Dictionary<string, string> itemDic = new Dictionary<string, string>();
                itemDic.Add("name", item["name"].ToString());
                itemDic.Add("full_name", item["full_name"].ToString());
                itemDic.Add("html_url", item["html_url"].ToString());


                IList owners = (IList)item["owner"];
                foreach (IDictionary owner in owners)
                {
                    itemDic.Add("avatar_url", owner["avatar_url"].ToString());
                }

                // リストに追加
                itemDicList.Add(itemDic);
            }
        }

        print("name: " + itemDicList[0]["name"]);
        print("avatar_url: " + itemDicList[0]["avatar_url"]);
        print("full_name: " + itemDicList[0]["full_name"]);
        print("html_url: " + itemDicList[0]["html_url"]);
    }

}
