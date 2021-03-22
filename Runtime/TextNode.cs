using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace KConversation
{
	using static Conversation;

	/// <summary>
	/// テキスト表示用ノード
	/// </summary>
	public class TextNode : NodeBase
	{
		[Input( backingValue = ShowBackingValue.Always, connectionType = ConnectionType.Override ), SerializeField] private TextNodeData inputNodeData = null;
		[Output( backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override ), SerializeField] private TextNodeData outputNodeData = null;

		public TextNodeData InputNodeData => inputNodeData;

		public override void OnCreateConnection( NodePort from, NodePort to )
		{
			base.OnCreateConnection( from, to );

			if( from.node is NodeBase nodeBase )
			{
				// input = nodeBase;
			}
		}

		public override void OnRemoveConnection( NodePort port )
		{
			base.OnRemoveConnection( port );

			// 	input.OnChangeConnection( this, false );
			inputNodeData = null;
		}

		public override object GetValue( NodePort port )
		{
			outputNodeData = new TextNodeData( inputNodeData );

			return outputNodeData;
		}

		public override NodeBase MoveNext()
		{
			var port = GetOutputPort( "outputNodeData" );

			return port?.Connection?.node as NodeBase;
		}

		public override void OnCopy( NodeBase copiedNode )
		{
			base.OnCopy( copiedNode );

			if( copiedNode is TextNode textNode )
			{
				textNode.inputNodeData = new TextNodeData( inputNodeData );
			}
		}

		/// <summary>
		/// コピー
		/// </summary>
		/// <returns></returns>
		public TextNodeData GetTextNodeData()
		{
			return new TextNodeData( inputNodeData );
		}

		public override NodeOperation CreateNodeOperation( Conversation conversation, DefaultConversationCallback onDefaultConversation, CompleteCallback onComplete, DisposeCallback onDispose )
		{
			return new TextNodeOperation( conversation, this, onDefaultConversation, onComplete, onDispose );
		}
	}
}
