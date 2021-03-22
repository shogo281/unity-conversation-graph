using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KConversation
{
	using static Conversation;

	/// <summary>
	/// �m�[�h�̑���
	/// </summary>
	public class NodeOperation : IDisposable
	{
		private NodeBase node = null;
		private bool isDisposed = false;
		private CompleteCallback onComplete = null;
		private DisposeCallback onDispose = null;
		private bool isCompleted = false;

		public bool IsCompleted => isCompleted;

		protected NodeBase Node => node;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="node"></param>
		/// <param name="onComplete"></param>
		/// <param name="onDispose"></param>
		public NodeOperation( Conversation conversation, NodeBase node, CompleteCallback onComplete, DisposeCallback onDispose )
		{
			this.node = node;
			isDisposed = false;
			this.onComplete = onComplete;
			this.onDispose = onDispose;
			isCompleted = false;
		}

		/// <summary>
		/// �X�V
		/// </summary>
		/// <param name="dt"></param>
		public void Update( float dt )
		{
			if( isDisposed == true )
			{
				return;
			}

			if( isCompleted == true )
			{
				return;
			}

			OnUpdate( dt );
		}

		/// <summary>
		/// �X�V�Ăяo����
		/// </summary>
		/// <param name="dt"></param>
		protected virtual void OnUpdate( float dt )
		{

		}

		/// <summary>
		/// �j��
		/// </summary>
		public void Dispose()
		{
			if( isDisposed == true )
			{
				return;
			}

			OnDispose();

			isDisposed = false;
			onDispose?.Invoke();

		}

		/// <summary>
		/// �j���Ăяo����
		/// </summary>
		protected virtual void OnDispose()
		{

		}

		/// <summary>
		/// ����
		/// </summary>
		protected void Complete()
		{
			if( IsCompleted == true )
			{
				return;
			}

			isCompleted = true;
			onComplete?.Invoke();
			Dispose();
		}
	}
}
