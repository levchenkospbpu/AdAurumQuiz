using UnityEngine;
using Zenject;

public class SampleSceneInstaller : MonoInstaller
{
	[SerializeField]
	private UICanvasData _uiCanvasData;

	[SerializeField]
	private UIProviderConfig _uiProviderConfig;

	[SerializeField]
	private TextAsset _jsonAsset;

	public override void InstallBindings()
	{
		Container.BindInstance(_uiCanvasData).AsCached();
		Container.BindInstance(_uiProviderConfig).AsCached();
		Container.BindInstance(_jsonAsset).AsCached();

		Container.BindInterfacesTo<SampleSceneStateController>().AsCached();
		Container.BindInterfacesTo<GameState>().AsCached();
	}
}
