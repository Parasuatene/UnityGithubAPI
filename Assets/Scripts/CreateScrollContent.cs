using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateScrollContent : MonoBehaviour {

    [SerializeField] GameObject repoNode;
    [SerializeField] int repoNodeCount; // スクロールビューに表示するオブジェクトの個数
    [SerializeField] GameObject contentObj;


	// Use this for initialization
	void Start () {
        // Content取得
        RectTransform content = contentObj.GetComponent<RectTransform>();
        // Contentの高さ決定
        // (repoNodeの高さ + repoNode同士の間隔)*repoNodeの個数
        float btnSpace = content.GetComponent<VerticalLayoutGroup>().spacing;
        float btnHeight = repoNode.GetComponent<LayoutElement>().preferredHeight;

        repoNodeCount = 30;

        for (int i = 0; i < repoNodeCount; i++){
            int number = i;
            GameObject node = (GameObject)Instantiate(repoNode);
            node.transform.SetParent(content, false);
            node.transform.Find("RepoName/Text").GetComponent<Text>().text = number.ToString();
            //node.transform.GetComponent<Button>().onClick.AddListener(() => OnClick());
        }
    }

    public void OnClick(){

    }
}
