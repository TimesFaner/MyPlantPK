using UnityEngine;
using QFramework;
using ISingleton = Unity.VisualScripting.ISingleton;

namespace PlantPK
{
	
	public partial class ResControl : ViewController,QFramework.ISingleton
	{
		public GameObject seedoerfab;
		public GameObject WaterPrefab;
		public GameObject SmallPlantperfab;
		public static ResControl Instance => MonoSingletonProperty<ResControl>.Instance;
		
		public void OnSingletonInit()
		{
			
		}
		
	}
}
