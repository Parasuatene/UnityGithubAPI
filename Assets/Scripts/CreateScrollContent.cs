using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateScrollContent : MonoBehaviour {

    [SerializeField] GameObject repoNode;
    RectTransform content;

    public void CreateRepoNode(string total_count, List<Dictionary<string,string>> reposDic){

        // Content取得
        content = gameObject.transform.Find("Viewport/Content").GetComponent<RectTransform>();
        print(content);
        // Contentの高さ決定
        // (repoNodeの高さ + repoNode同士の間隔)*repoNodeの個数
        float btnSpace = content.GetComponent<VerticalLayoutGroup>().spacing;
        float btnHeight = repoNode.GetComponent<LayoutElement>().preferredHeight;

        gameObject.transform.Find("Header/Text").GetComponent<Text>().text = "Searching Result: " + total_count;

        for (int i = 0; i < reposDic.Count; i++)
        {
            print(i);
            GameObject node = Instantiate(repoNode) as GameObject;
            // なぜかSetParentが通らなかったので強引にContentオブジェクトを取得
            node.transform.SetParent(GameObject.Find("Scroll View(Clone)/Viewport/Content").transform, false);
            node.transform.Find("RepoName/Text").GetComponent<Text>().text = reposDic[i]["full_name"];
            node.transform.Find("RepoName").GetComponent<Button>().onClick.AddListener(() => OnClick(reposDic[i]["html_url"]));
        }
    }

    public void OnClick(string html_url){
        print(html_url);
        // これでURLの先を開ける
        Application.OpenURL(html_url);
    }
}
