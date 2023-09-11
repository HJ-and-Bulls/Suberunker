using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    [SerializeField] private GameObject _characterPrefab;

    List<GameObject> _characters;
    [SerializeField] InputActionAsset[] _inputActions;
    [SerializeField] RuntimeAnimatorController[] _animationControllers;

    private void Awake()
    {
        Instance = this;
        _characters = new List<GameObject>();
    }

    public GameObject MakeCharacter(int characterCode)
    {
        GameObject GeneratedCharacter = Instantiate(_characterPrefab);
        GeneratedCharacter.GetComponent<Animator>().runtimeAnimatorController = _animationControllers[characterCode];
        _characters.Add(GeneratedCharacter);
        
        if (_characters.Count == 2 )
        { // 2명이 플레이
            _characters[0].transform.Translate(Vector3.left);
            GeneratedCharacter.transform.Translate(Vector3.right);
            GeneratedCharacter.GetComponent<PlayerInput>().actions = _inputActions[1];
        }

        return GeneratedCharacter;
    }
}
