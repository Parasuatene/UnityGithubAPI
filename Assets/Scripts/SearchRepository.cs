using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniJSON;

public class SearchRepository : MonoBehaviour
{
    private string url = "https://api.github.com/search/repositories?";
    private string total_count; // 検索ヒット数
    public List<Dictionary<string, string>> reposDic;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject scrollView;

    public IEnumerator StartConnection(string queryParam)
    {
        url = url + queryParam;
        string jsonText;

        using (WWW www = new WWW(url))
        {
            while (!www.isDone)
            { // ダウンロードの進捗を表示
                print(Mathf.CeilToInt(www.progress * 100));
                yield return null;
            }

            yield return www;
            print("変換前");
            print(www.text);
            jsonText = www.text;
        }

        // jsonTextを扱える形に変換する
        jsonText = ConvertToArray(jsonText);

        // データが取得できなければ, エラーメッセージを表示する.
        try{
            // JSONデータをDeserialize, その後リストへとキャスト
            IList reposList = (IList)Json.Deserialize(jsonText);

            reposDic = new List<Dictionary<string, string>>();

            foreach (IDictionary repo in reposList)
            {
                total_count = repo["total_count"].ToString();
                IList items = (IList)repo["items"];

                foreach (IDictionary item in items)
                {
                    Dictionary<string, string> itemDic = new Dictionary<string, string>();

                    itemDic.Add("full_name", item["full_name"].ToString()); // "親リポジトリ名/子リポジトリ名"
                    itemDic.Add("html_url", item["html_url"].ToString()); // リポジトリのリンク先
                    itemDic.Add("updated_at", item["updated_at"].ToString()); // 最終更新日時
                    itemDic.Add("open_issues_count", item["open_issues_count"].ToString()); // 使用プログラム言語
                    itemDic.Add("stargazers_count", item["stargazers_count"].ToString()); // スターの数

                    reposDic.Add(itemDic);
                }
            }

            for (int i = 0; i < reposDic.Count; i++){
                print("full_name: " + reposDic[i]["full_name"]);
                print("html_url: " + reposDic[i]["html_url"]);
                print("updated_at: " + reposDic[i]["updated_at"]);
                print("open_issues_count: " + reposDic[i]["open_issues_count"]);
                print("stargazers_count: " + reposDic[i]["stargazers_count"]);
                print("----------------------------------------------");
            }

            // Debug
            InstansiateContent();
        }
        catch{
            Debug.Log("データを取得できませんでした。\nネットワークに接続されているか確認してください。");
        }


    }

    // MiniJsonが扱える形に変換する
    private string ConvertToArray(string fetchText){
        return "[" + fetchText + "]";
    }

    private void InstansiateContent(){
        Instantiate(scrollView).transform.SetParent(canvas.transform, false);
    }
}
