using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniJSON;

public class SearchRepository : MonoBehaviour
{
    private string total_count; // 検索ヒット数
    public List<Dictionary<string, string>> reposDic;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject scrollManager;
    [SerializeField] GameObject loadingEffect;

    public IEnumerator StartConnection(string queryParam)
    {
        string url = "https://api.github.com/search/repositories?";
        url = url + queryParam;
        print("URL: " + url);
        string jsonText;

        using (WWW www = new WWW(url))
        {
            GameObject loadingEffectPrefab = Instantiate(loadingEffect) as GameObject;
            loadingEffectPrefab.transform.SetParent(canvas.transform, false);

            while (!www.isDone)
            { 
                // ダウンロードの進捗を表示
                print(Mathf.CeilToInt(www.progress * 100));
                yield return null;
            }

            Destroy(loadingEffectPrefab);

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

            scrollManager.GetComponent<ScrollManager>().CreateRepoNode(total_count, reposDic);
        }
        catch{
            Debug.Log("データを取得できませんでした。\nネットワークに接続されているか確認してください。");
        }
    }

    // MiniJsonが扱える形に変換する
    private string ConvertToArray(string fetchText){
        return "[" + fetchText + "]";
    }

    public int MaxPageNumber(){
        return (int.Parse(total_count) / 30) + 1;
    }
}
