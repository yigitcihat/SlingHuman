using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{
    [SerializeField] protected List<Human> AllHumans;
    [SerializeField] protected Transform _humanPos;
    [SerializeField] protected Trajectory _trajectory;
    [SerializeField] protected float _pushForce;
    [SerializeField] protected float _maxForce;
    [SerializeField][Range(0f, 10f)] protected float _zMultiplier;

    private Vector2 _startPos, _endPos;
    private Vector3 _forcevector;
    private Vector3 _slingBantFirstPos;
    private Human _human;
    private Rigidbody _humanRb;
    private Animator humanAnimator;
    private bool isLevelStart;
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(() => isLevelStart = true);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(() => isLevelStart = true);

    }
    private void Start()
    {
        _slingBantFirstPos = transform.localPosition;
        _human = _humanPos.GetComponentInChildren<Human>();
        humanAnimator = _human.GetComponent<Animator>();
        _humanRb = _human.GetComponent<Rigidbody>();
        NewHumanGettingPosition();
    }

    private void Update()
    {
        if (isLevelStart) 
        {
            ControlSwipe();
        }
        
    }

    private void ControlSwipe()
    {
        if (_human)
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
                float distance = Vector2.Distance(_startPos, _endPos) / 30;
                transform.localPosition = new Vector3(_slingBantFirstPos.x + (_startPos.y - _endPos.y) / 10, transform.localPosition.y, -(_startPos.x - _endPos.x) / 10);
                _forcevector = direction * distance * _pushForce;
                _forcevector.z = _forcevector.y * _zMultiplier + 1f;
                _forcevector = Vector3.ClampMagnitude(_forcevector, _maxForce);

                _trajectory.UpdateDots(transform.position, _forcevector);
            }

            if (Input.GetMouseButtonUp(0))
            {

                _human.transform.SetParent(null);
                _human.Push(_forcevector);
                _human = null;
                humanAnimator.SetTrigger("Thrown");
                transform.localPosition = _slingBantFirstPos;
                Invoke("NewHumanGettingPosition", 0.5f);
                EventManager.OnHumanThrowed.Invoke();

                _trajectory.Hide();
            }
        }
    }

    public void NewHumanGettingPosition()
    {
        if (_humanPos.childCount > 0 || AllHumans.Count == 0) return;

        _human = AllHumans[AllHumans.Count-1];
        AllHumans.Remove(_human);
        humanAnimator = _human.GetComponent<Animator>();
        humanAnimator.SetTrigger("Jump");
        _human.transform.DOJump(_humanPos.position, 0.1f, 1, 0.5f).OnComplete(() => { humanAnimator.SetTrigger("Stay"); _human.transform.SetParent(_humanPos); });
        
        

    }
}