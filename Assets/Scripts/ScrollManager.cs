using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour {

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject repoNode;
    [SerializeField] GameObject scrollView;
    RectTransform content;

    public void CreateRepoNode(string total_count, List<Dictionary<string,string>> reposDic){

        GameObject prefab = Instantiate(scrollView) as GameObject;
        prefab.transform.SetParent(canvas.transform, false);

        // Content取得
        content = prefab.transform.Find("Viewport/Content").GetComponent<RectTransform>();

        // Contentの高さ決定
        // (repoNodeの高さ + repoNode同士の間隔)*repoNodeの個数
        float btnSpace = content.GetComponent<VerticalLayoutGroup>().spacing;
        float btnHeight = repoNode.GetComponent<LayoutElement>().preferredHeight;

        prefab.transform.Find("Header/Text").GetComponent<Text>().text = "Searching Result: " + total_count;

        for (int i = 0; i < reposDic.Count; i++)
        {
            GameObject node = Instantiate(repoNode) as GameObject;
            node.transform.SetParent(content, false);
            node.transform.GetComponent<RepositoryNode>().InitParam(reposDic[i]["full_name"], reposDic[i]["html_url"]);
        }
    }
}
