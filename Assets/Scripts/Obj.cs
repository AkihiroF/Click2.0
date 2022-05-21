using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

[CreateAssetMenu(menuName = "Object")]
public class Obj : ScriptableObject
{
    [SerializeField] private string nameobj;
    public List<Sprite> upgradeicon;
    public bool active, buy;
    public int lvl, stadia, id;
    
}
