using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{
    [SerializeField] protected Human _humanPrefab;
    [SerializeField] protected Transform _humanPos; 
    [SerializeField] protected Trajectory _trajectory;
    [SerializeField] protected float _pushForce;         
    [SerializeField] protected float _maxForce;        
    [SerializeField][Range(0f, 10f)] protected float _zMultiplier;   

    private Vector2 _startPos, _endPos;
    private Vector3 _forcevector;
    private Vector3 _slingBantFirstPos;
    private Human _human; 


    private void Start()
    {
        _slingBantFirstPos = transform.localPosition;
        Spawn();
    }

    private void Update()
    {
        ControlSwipe();
    }

    private void ControlSwipe()
    {
       
        if (Input.GetMouseButtonDown(0))
        {

            _trajectory.Show();

            
            _startPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            _endPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = (_startPos - _endPos).normalized;
            float distance = Vector2.Distance(_startPos, _endPos);
            transform.localPosition = new Vector3(_slingBantFirstPos.x +(_startPos.y - _endPos.y) / 10, transform.localPosition.y, -(_startPos.x - _endPos.x) / 10 );
            _forcevector = direction * distance * _pushForce;
            _forcevector.z = _forcevector.y * _zMultiplier + 1;
            _forcevector = Vector3.ClampMagnitude(_forcevector, _maxForce);

            _trajectory.UpdateDots(transform.position, _forcevector);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_human)
            {
                _human.Push(_forcevector);
                _human = null;
                transform.localPosition = _slingBantFirstPos;
                Invoke("Spawn", 1);
            }

            _trajectory.Hide();
        }
    }

    public void Spawn()
    {
        _human = Instantiate(_humanPrefab, _humanPos.position, Quaternion.identity);
        _human.transform.SetParent(transform);
    }
}