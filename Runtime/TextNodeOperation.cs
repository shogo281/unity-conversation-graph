using System;
using System.Collections;
using System.Collections.Generic;
using KConversation;
using UnityEngine;

namespace KConversation
{
	using static Conversation;

	/// <summary>
	/// テキストノード操作
	/// </summary>
	public class TextNodeOperation : NodeOperation
	{
		private TextNode textNode = null;
		private int index = 0;
		private DefaultConversationCallback onDefaultConversation = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="node"></param>
		/// <param name="onComplete"></param>
		/// <param name="onDispose"></param>
		public TextNodeOperation( Conversation conversation, NodeBase node, DefaultConversationCallback onDefaultConversation, CompleteCallback onComplete, DisposeCallback onDispose ) : base( conversation, node, onComplete, onDispose )
		{
			this.onDefaultConversation = onDefaultConversation;
			index = 0;
			textNode = node as TextNode;

#if UNITY_EDITOR
			Debug.Assert( textNode != null );
#endif
		}

		protected override void OnUpdate( float dt )
		{
			base.OnUpdate( dt );

			if( index < textNode.InputNodeData.textArray.Length )
			{
				var str = textNode.InputNodeData.textArray[index];
				onDefaultConversation?.Invoke( str );
				index++;
			}
			else
			{
				Complete();
			}
		}
	}
}
