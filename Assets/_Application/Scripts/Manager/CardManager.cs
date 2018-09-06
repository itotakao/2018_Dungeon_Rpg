using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Current { get; private set; }

    public Object[] resouceCardList;
    public List<GameObject> cardList = new List<GameObject>(0);

    void Awake()
    {
        Current = this;
    }

    void Start()
    {
        resouceCardList = Resources.LoadAll("Prefabs/Card", typeof(GameObject));
    }

    public void ShuffleCard()
    {
        foreach (var card in cardList)
        {
            Destroy(card);
        }
        cardList.Clear();

        int counter = 0;
        while (counter < 3)
        {
            int rand = Random.Range(0, resouceCardList.Length);
            int posY = 20;
            switch (counter)
            {
                case 0:
                    var obj0 = Instantiate((GameObject)resouceCardList[rand]);
                    obj0.transform.position = new Vector3( 0, posY, 0);
                    cardList.Add(obj0);
                    break;
                case 1:
                    var obj1 = Instantiate((GameObject)resouceCardList[rand]);
                    obj1.transform.position = new Vector3(Screen.width / 50, posY, 0);
                    cardList.Add(obj1);
                    break;
                case 2:
                    var obj2 = Instantiate((GameObject)resouceCardList[rand]);
                    obj2.transform.position = new Vector3(-Screen.width / 50, posY, 0);
                    cardList.Add(obj2);
                    break;
                default:
                    break;
            }
            counter++;
        }
    }
}
