using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Google.Android.Play.Core.Tasks
{
   	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.android.play.core.tasks']/class[@name='NativeOnCompleteListener']"
	[global::Android.Runtime.Register ("com/google/android/play/core/tasks/NativeOnCompleteListener", DoNotGenerateAcw=true)]
	public partial class NativeOnCompleteListener : global::Java.Lang.Object, global::Com.Google.Android.Play.Core.Tasks.IOnCompleteListener {

		static readonly JniPeerMembers _members = new XAPeerMembers ("com/google/android/play/core/tasks/NativeOnCompleteListener", typeof (NativeOnCompleteListener));
		internal static new IntPtr class_ref {
			get {
				return _members.JniPeerType.PeerReference.Handle;
			}
		}

		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		protected override IntPtr ThresholdClass {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		protected NativeOnCompleteListener (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.google.android.play.core.tasks']/class[@name='NativeOnCompleteListener']/constructor[@name='NativeOnCompleteListener' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='int']]"
		[Register (".ctor", "(JI)V", "")]
		public unsafe NativeOnCompleteListener (long p0, int p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			const string __id = "(JI)V";

			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [2];
				__args [0] = new JniArgumentValue (p0);
				__args [1] = new JniArgumentValue (p1);
				var __r = _members.InstanceMethods.StartCreateInstance (__id, ((object) this).GetType (), __args);
				SetHandle (__r.Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance (__id, this, __args);
			} finally {
			}
		}

		static Delegate cb_nativeOnComplete_JILjava_lang_Object_I;
#pragma warning disable 0169
		static Delegate GetNativeOnComplete_JILjava_lang_Object_IHandler ()
		{
			if (cb_nativeOnComplete_JILjava_lang_Object_I == null)
				cb_nativeOnComplete_JILjava_lang_Object_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, int, IntPtr, int>) n_NativeOnComplete_JILjava_lang_Object_I);
			return cb_nativeOnComplete_JILjava_lang_Object_I;
		}

		static void n_NativeOnComplete_JILjava_lang_Object_I (IntPtr jnienv, IntPtr native__this, long p0, int p1, IntPtr native_p2, int p3)
		{
			global::Com.Google.Android.Play.Core.Tasks.NativeOnCompleteListener __this = global::Java.Lang.Object.GetObject<global::Com.Google.Android.Play.Core.Tasks.NativeOnCompleteListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p2 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.NativeOnComplete (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.play.core.tasks']/class[@name='NativeOnCompleteListener']/method[@name='nativeOnComplete' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='int'] and parameter[3][@type='java.lang.Object'] and parameter[4][@type='int']]"
		[Register ("nativeOnComplete", "(JILjava/lang/Object;I)V", "GetNativeOnComplete_JILjava_lang_Object_IHandler")]
		public virtual unsafe void NativeOnComplete (long p0, int p1, global::Java.Lang.Object p2, int p3)
		{
			const string __id = "nativeOnComplete.(JILjava/lang/Object;I)V";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [4];
				__args [0] = new JniArgumentValue (p0);
				__args [1] = new JniArgumentValue (p1);
				__args [2] = new JniArgumentValue ((p2 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p2).Handle);
				__args [3] = new JniArgumentValue (p3);
				_members.InstanceMethods.InvokeVirtualVoidMethod (__id, this, __args);
			} finally {
			}
		}

		// This method is explicitly implemented as a member of an instantiated Com.Google.Android.Play.Core.Tasks.IOnCompleteListener
		void global::Com.Google.Android.Play.Core.Tasks.IOnCompleteListener.OnComplete (global::Com.Google.Android.Play.Core.Tasks.Task p0)
		{
            ((IOnCompleteListener) this).OnComplete (global::Java.Interop.JavaObjectExtensions.JavaCast<global::Com.Google.Android.Play.Core.Tasks.Task>(p0));
		}

	}
}