using UnityEngine;

public abstract class BasePresenter<TView, TModel> where TView : BaseView where TModel : BaseModel
{
    protected abstract GameObject Prefab { get; }
    protected abstract Transform Parent { get; }

    private GameObject _instance;
    private bool _isEnabled;

    protected TView View;
    protected TModel Model;

    protected BasePresenter(UICanvasData uiCanvasData, UIProviderConfig uiProviderConfig)
    {
    }

    public void Enable(TModel model = null)
    {
        if (_isEnabled)
		{
			return;
		}

		_instance = Object.Instantiate(Prefab, Parent);
        View = _instance.GetComponent<TView>();
        Model = model;
        _isEnabled = true;

        OnEnable();
    }

	public void Disable()
	{
		Object.Destroy(_instance);
		_isEnabled = false;

		OnDisable();
	}

	protected virtual void OnEnable()
    {
    }

    protected virtual void OnDisable()
    {
    }
}