using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private int _maxNumberScene = 4;
    private static int _actualSceneNumber = 0;
    [SerializeField] private Image _background;
    [SerializeField] private Image _miki;
    [SerializeField] private TextMeshProUGUI _textMiki;
    [SerializeField] private TextMeshProUGUI _textButton1;
    [SerializeField] private TextMeshProUGUI _textButton2;
    [SerializeField] private TextMeshProUGUI _textButton3;
    private List<MikiText> _listMikiText = new List<MikiText>();
    [SerializeField] private Animation _animationMikiComplimented;

    public void Start()
    {
        for (int scene = 0; scene < _maxNumberScene; scene++)
        {
            _listMikiText.Add(Resources.Load<MikiText>($"MikiScene/Scene{scene}"));
        }
    }

    public void Button1()
    {
        //Fonction appeller quand le bouton1 est appuyé.
        //Elle actualise la scene choisie par l'utilisateur et la charge
        switch (_actualSceneNumber)
        {
            case 0:
            {
                _actualSceneNumber = 1;
                break;
            }
            case 1:
            {
                _actualSceneNumber = 2;
                break;
            }
            case 2:
            {
                _actualSceneNumber = 1;
                break;
            }
            case 3:
            {
                _actualSceneNumber = 1;
                break;
            }
        }
    
        ChangeSceneManager();
    }
    public void Button2()
    {
        //Fonction appeller quand le bouton2 est appuyé.
        //Elle actualise la scene choisie par l'utilisateur et la charge
        switch (_actualSceneNumber)
        {
            case 0:
            {
                _actualSceneNumber = 0;
                break;
            }
            case 1:
            {
                _actualSceneNumber = 3;
                break;
            }
            case 2:
            {
                _actualSceneNumber = 3;
                break;
            }
            case 3:
            {
                _actualSceneNumber = 2;
                break;
            }
        }

        ChangeSceneManager();
        
        if (_actualSceneNumber == 0)
        {
            //on ne veux changer le text de miki suivant la réponse pour la première scene :
            _textMiki.text = _listMikiText[_actualSceneNumber].mikiTextAfterAnswer2;
            _textMiki.GetComponent<SlowRevealCharacter>().RevealCharacter();
        }
    }
    public void Button3()
    {
        //Fonction appeller quand le bouton3 est appuyé.
        //Elle actualise la tenue de Miki, affiche le son text après avoir été complimenter et la fait "bouger"
        switch (_actualSceneNumber)
        {
            case 0:
            {
                _miki.sprite = Resources.Load<Sprite>("Miki/Miki_Miko/Miki_A_Miko_Open_Blush");
                break;
            }
            case 1:
            {
                _miki.sprite = Resources.Load<Sprite>("Miki/Miki_Yukata/Miki_A_Yukata_Open_Blush");
                break;
            }
            case 2:
            {
                _miki.sprite = Resources.Load<Sprite>("Miki/Miki_Swimsuit/Miki_A_Swimsuit_Open_Blush");
                break;
            }
            case 3:
            {
                _miki.sprite = Resources.Load<Sprite>("Miki/Miki_Winter_Coat/Miki_A_Coat_Open_Blush");
                break;
            }
        }
        
        _textMiki.text = _listMikiText[_actualSceneNumber].mikiTextAfterAnswer3;
        _textMiki.GetComponent<SlowRevealCharacter>().RevealCharacter();
        //On fait "bouger" Miki
        _animationMikiComplimented.Play();
    }

    private void ChangeSceneManager()
    {
        //Fonction qui permet d'actualiser la totalité de la scene
        _textMiki.text = _listMikiText[_actualSceneNumber].sceneEnterText;
        _textButton1.text = _listMikiText[_actualSceneNumber].answer1;
        _textButton2.text = _listMikiText[_actualSceneNumber].answer2;
        _textButton3.text = _listMikiText[_actualSceneNumber].answer3;
        _textMiki.GetComponent<SlowRevealCharacter>().RevealCharacter();
        _background.sprite = Resources.Load<Sprite>($"Background/Scene{_actualSceneNumber}");
        _miki.sprite = Resources.Load<Sprite>(_listMikiText[_actualSceneNumber].mikiSpritPath);
    }
    
    
}
