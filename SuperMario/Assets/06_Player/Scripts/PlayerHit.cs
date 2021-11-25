using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour, IState
{
    public void GetItem(Item item)
    {
        if(item == Item.FLOWER)
        {

        }
        else if(item == Item.COIN)
        {

        }
    }

    public void ObjectHit(HitList hitList)
    {

    }
}
