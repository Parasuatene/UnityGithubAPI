using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrevAndNextButton : MonoBehaviour {

    public enum Type
    {
        prev, next
    }

    public Type type;

    [SerializeField] GameObject pagingManagerObj;
    private PagingManager pagingManager;

    private Button button;

    // Use this for initialization
    void Start () {
        pagingManager = pagingManagerObj.GetComponent<PagingManager>();
        button = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type == Type.prev)
        {
            if (pagingManager.pageNumber == 1)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
        else
        {
            if (pagingManager.pageNumber == pagingManager.maxPageNumber)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
    }
}
