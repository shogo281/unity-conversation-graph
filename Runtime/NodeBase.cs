using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace KConversation
{
	using static Conversation;

	/// <summary>
	/// ノードベースクラス
	/// </summary>
	public abstract class NodeBase : Node
	{
		/// <summary>
		/// 遷移先のノードを定義する
		/// </summary>
		/// <returns></returns>
		public abstract NodeBase MoveNext();

		/// <summary>
		/// コピーした時の処理
		/// </summary>
		/// <param name="copiedNode"></param>
		public virtual void OnCopy( NodeBase copiedNode )
		{

		}

		/// <summary>
		/// オペレーションを生成する
		/// baseの呼び出しは必要ない
		/// </summary>
		/// <param name="onComplete"></param>
		/// <param name="onDispose"></param>
		/// <returns></returns>
		public virtual NodeOperation CreateNodeOperation( Conversation conversation, DefaultConversationCallback onDefaultConversation, CompleteCallback onComplete, DisposeCallback onDispose )
		{
			return new NodeOperation( conversation, this, onComplete, onDispose );
		}
	}
}