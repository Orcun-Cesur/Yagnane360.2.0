//using Microsoft.AspNetCore.Components;
//using System;

//namespace Yaghane360.Components.Services
//{
//	// Services/LoadingService.cs
//	public class LoadingService
//	{
//		public event Action? OnChange;
//		public bool IsLoading { get; private set; }

//		//// Dispatcher'ı tutmak için bir değişken tanımlayın
//		//private readonly IDispatcher _dispatcher;

//		//// Constructor'a IDispatcher'ı ekleyin
//		//public LoadingService(IDispatcher dispatcher)
//		//{
//		//	_dispatcher = dispatcher;
//		//}

//		public void Show()
//		{
//			IsLoading = true;
//			NotifyStateChanged();
//		}

//		public void Hide()
//		{
//			IsLoading = false;
//			NotifyStateChanged();
//		}

//		private void NotifyStateChanged()
//		{
//			// UI güncelleme işlemini Dispatcher üzerinden yap
//			//_dispatcher.InvokeAsync(() => OnChange?.Invoke());
//		}
//	}
//}
