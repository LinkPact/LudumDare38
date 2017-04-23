using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WorldObjectType {
    axe,
    berry,
    campfire,
    digging_spot,
    fish,
    fishing_rod,
    flat_stone,
    gravestone,
    message_in_a_bottle,
    rope,
    sharp_stone,
    ship_wreck,
    shovel,
    straw_bush,
    tree,
    wood,
    empty
}

public class WorldObjectInformation : MonoBehaviour {

    public WorldObjectType world_object_type;
}
