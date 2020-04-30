using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Google.Android.Play.Core.Assetpacks
{
    public partial class NativeAssetPackStateUpdateListener
    {
        [Register("onStateUpdate", "(Lcom/google/android/play/core/assetpacks/AssetPackState;)V", "GetOnStateUpdate_Lcom_google_android_play_core_assetpacks_AssetPackState_Handler")]
        public virtual unsafe void OnStateUpdate(Java.Lang.Object p0)
        {
            const string __id = "onStateUpdate.(Lcom/google/android/play/core/assetpacks/AssetPackState;)V";
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                __args[0] = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object)p0).Handle);
                _members.InstanceMethods.InvokeVirtualVoidMethod (__id, this, __args);
            }
            finally
            {
            }
        }
    }
}