using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {
    public Slider PlayerOneHealthSlider, PlayerTwoHealthSlider;
    public Text PlayerOneDamageText, PlayerTwoDamageText;

    public void UpdateHealth(int _health, PlayerEnum _player)
    {
        switch (_player)
        {
            case PlayerEnum.PLAYER_ONE:
                PlayerOneHealthSlider.value = _health;
                break;
            case PlayerEnum.PLAYER_TWO:
                PlayerTwoHealthSlider.value = _health;
                break;
            default:
                break;
        }


    }

    public void UpdateDamageText(int _damage, PlayerEnum _player)
    {
        switch (_player)
        {
            case PlayerEnum.PLAYER_ONE:
                break;
            case PlayerEnum.PLAYER_TWO:
                break;
            case PlayerEnum.BOTH:
                break;
            default:
                break;
        }
    }

}
