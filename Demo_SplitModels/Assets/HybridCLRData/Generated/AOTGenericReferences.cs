using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"GameFramework.dll",
		"System.dll",
		"UnityEngine.CoreModule.dll",
		"UnityGameFramework.Runtime.dll",
		"mscorlib.dll",
		"protobuf-net.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// GameFramework.DataTable.IDataTable<object>
	// GameFramework.GameFrameworkAction<object>
	// GameFramework.GameFrameworkLinkedList.Enumerator<object>
	// GameFramework.GameFrameworkLinkedList<object>
	// GameFramework.ObjectPool.IObjectPool<object>
	// GameFramework.Variable<byte>
	// System.Action<UnityEngine.Vector3>
	// System.Action<byte>
	// System.Action<object>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.Vector3>
	// System.Collections.Generic.ArraySortHelper<byte>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<UnityEngine.Vector3>
	// System.Collections.Generic.Comparer<byte>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Dictionary.Enumerator<StarForce.AIUtility.CampPair,byte>
	// System.Collections.Generic.Dictionary.Enumerator<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary.Enumerator<byte,object>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<StarForce.AIUtility.CampPair,byte>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<byte,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<StarForce.AIUtility.CampPair,byte>
	// System.Collections.Generic.Dictionary.KeyCollection<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary.KeyCollection<byte,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,byte>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<StarForce.AIUtility.CampPair,byte>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<byte,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<StarForce.AIUtility.CampPair,byte>
	// System.Collections.Generic.Dictionary.ValueCollection<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary.ValueCollection<byte,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,byte>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary<StarForce.AIUtility.CampPair,byte>
	// System.Collections.Generic.Dictionary<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary<byte,object>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<object,byte>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.EqualityComparer<StarForce.AIUtility.CampPair>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<byte,byte>>
	// System.Collections.Generic.EqualityComparer<byte>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<StarForce.AIUtility.CampPair,byte>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<byte,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<UnityEngine.Vector3>
	// System.Collections.Generic.ICollection<byte>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.IComparer<UnityEngine.Vector3>
	// System.Collections.Generic.IComparer<byte>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<StarForce.AIUtility.CampPair,byte>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<byte,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<UnityEngine.Vector3>
	// System.Collections.Generic.IEnumerable<byte>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<StarForce.AIUtility.CampPair,byte>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<byte,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<UnityEngine.Vector3>
	// System.Collections.Generic.IEnumerator<byte>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEqualityComparer<StarForce.AIUtility.CampPair>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<byte,byte>>
	// System.Collections.Generic.IEqualityComparer<byte>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IList<UnityEngine.Vector3>
	// System.Collections.Generic.IList<byte>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.KeyValuePair<StarForce.AIUtility.CampPair,byte>
	// System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.KeyValuePair<byte,byte>
	// System.Collections.Generic.KeyValuePair<byte,object>
	// System.Collections.Generic.KeyValuePair<int,int>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<object,byte>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.LinkedList.Enumerator<object>
	// System.Collections.Generic.LinkedList<object>
	// System.Collections.Generic.LinkedListNode<object>
	// System.Collections.Generic.List.Enumerator<UnityEngine.Vector3>
	// System.Collections.Generic.List.Enumerator<byte>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<UnityEngine.Vector3>
	// System.Collections.Generic.List<byte>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<UnityEngine.Vector3>
	// System.Collections.Generic.ObjectComparer<byte>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<StarForce.AIUtility.CampPair>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<byte,byte>>
	// System.Collections.Generic.ObjectEqualityComparer<byte>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<object>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.Vector3>
	// System.Collections.ObjectModel.ReadOnlyCollection<byte>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<UnityEngine.Vector3>
	// System.Comparison<byte>
	// System.Comparison<object>
	// System.EventHandler<object>
	// System.Nullable<int>
	// System.Predicate<UnityEngine.Vector3>
	// System.Predicate<byte>
	// System.Predicate<object>
	// }}

	public void RefMethods()
	{
		// GameFramework.DataTable.IDataTable<object> GameFramework.DataTable.IDataTableManager.GetDataTable<object>()
		// System.Void GameFramework.Fsm.Fsm<object>.ChangeState<object>()
		// System.Void GameFramework.Fsm.FsmState<object>.ChangeState<object>(GameFramework.Fsm.IFsm<object>)
		// object GameFramework.Fsm.IFsm<object>.GetData<object>(string)
		// System.Void GameFramework.Fsm.IFsm<object>.SetData<object>(string,object)
		// System.Void GameFramework.Network.INetworkChannel.Send<object>(object)
		// GameFramework.ObjectPool.IObjectPool<object> GameFramework.ObjectPool.IObjectPoolManager.CreateSingleSpawnObjectPool<object>(string,int)
		// string GameFramework.Utility.Text.Format<int>(string,int)
		// string GameFramework.Utility.Text.Format<object,object>(string,object,object)
		// string GameFramework.Utility.Text.Format<object>(string,object)
		// string GameFramework.Utility.Text.ITextHelper.Format<int>(string,int)
		// string GameFramework.Utility.Text.ITextHelper.Format<object,object>(string,object,object)
		// string GameFramework.Utility.Text.ITextHelper.Format<object>(string,object)
		// System.Void ProtoBuf.Serializer.Serialize<object>(System.IO.Stream,object)
		// System.Void ProtoBuf.Serializer.SerializeWithLengthPrefix<object>(System.IO.Stream,object,ProtoBuf.PrefixStyle)
		// System.Void ProtoBuf.Serializer.SerializeWithLengthPrefix<object>(System.IO.Stream,object,ProtoBuf.PrefixStyle,int)
		// object System.Activator.CreateInstance<object>()
		// object[] System.Array.Empty<object>()
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.Component.GetComponentInParent<object>()
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object UnityEngine.Object.FindObjectOfType<object>()
		// object UnityEngine.Object.Instantiate<object>(object)
		// object UnityExtension.GetOrAddComponent<object>(UnityEngine.GameObject)
		// GameFramework.DataTable.IDataTable<object> UnityGameFramework.Runtime.DataTableComponent.GetDataTable<object>()
		// object UnityGameFramework.Runtime.GameEntry.GetComponent<object>()
		// GameFramework.ObjectPool.IObjectPool<object> UnityGameFramework.Runtime.ObjectPoolComponent.CreateSingleSpawnObjectPool<object>(string,int)
	}
}