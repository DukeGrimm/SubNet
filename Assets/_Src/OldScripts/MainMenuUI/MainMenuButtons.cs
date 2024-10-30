using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        //_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleUserList()
    {
        if(_animator != null)
        {
            bool isOpen = _animator.GetBool("UserListOpen");
            _animator.SetBool("UserListOpen", !isOpen);
        }
    }

    public void ToggleSettingsList()
    {
        if (_animator != null)
        {
            bool isOpen = _animator.GetBool("SettingsOpen");
            _animator.SetBool("SettingsOpen", !isOpen);
        }
    }



}
