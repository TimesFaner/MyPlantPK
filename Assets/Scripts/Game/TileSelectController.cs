using UnityEngine;
using QFramework;
using ISingleton = Unity.VisualScripting.ISingleton;
namespace PlantPK
{
	public partial class TileSelectController : ViewController, QFramework.ISingleton
	{
		public static TileSelectController Instance => MonoSingletonProperty<TileSelectController>.Instance;
		public void OnSingletonInit()
		{
		}
	}
}
