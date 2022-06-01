using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorialscr : MonoBehaviour
{
   public List<GameObject> tutorobj;
   private int activepage = 0;
   public CreateData data;

   public void NextPage()
   {
      if (activepage < tutorobj.Count)
      {
         if (activepage < tutorobj.Count-1)
         {
            tutorobj[activepage + 1].SetActive(true);
         }
         Destroy(tutorobj[activepage]);
         activepage++;
      }
      if(activepage == tutorobj.Count) {data.data.tutorial = true; JsonSave.SaveToJSON(data.data, data.filename);}
   }
}
