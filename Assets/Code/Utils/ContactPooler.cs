using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPooler
{
    private ContactPoint2D[] _contacts = new ContactPoint2D[10];
    private const float _collTreshhold = 0.6f;
    private int _contactCount;
    private Collider2D _collider2D;
    
    public bool IsGrounded { get; private set; }
    public bool HasLeftContact { get; private set; }
    public bool HasRightContact { get; private set; }
    
    public ContactPooler (Collider2D collider2D)
    {
        _collider2D = collider2D;
    }
    
    public void Update()
    {
        IsGrounded = false;
        HasLeftContact = false;
        HasRightContact = false;
        
        _contactCount = _collider2D.GetContacts(_contacts);
        
        for (int i = 0; i < _contactCount; i++)
        {
        	if(_contacts[i].normal.y > _collTreshhold) IsGrounded = true;
			if(_contacts[i].normal.x > _collTreshhold) HasLeftContact = true;
			if(_contacts[i].normal.x > -_collTreshhold) HasRightContact = true;
        }
    }
}
