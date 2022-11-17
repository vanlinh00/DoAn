using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InforUser : Singleton<InforUser>
{
    [SerializeField] Image _avatarImage;
    [SerializeField] Text _nameText;
    [SerializeField] Text _rankingText;
    [SerializeField] Text _levelText;

    void Start()
    {
        ChangeInforUser();
    }

    public void ChangeInforUser()
    {
       // InforPlayer inforPlayer = DataPlayer.getInforPlayer();
      //  _levelText.text = "Level 0" + inforPlayer.level.ToString();

    }
}
