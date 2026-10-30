#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename R, typename T1>
struct VirtualFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R, typename T1, typename T2>
struct VirtualFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};

// System.Collections.Generic.IReadOnlyList`1<System.String>
struct IReadOnlyList_1_t7BB300FE9C8B0D3BCB34B752D2516BD12EB5E8CF;
// System.Collections.Generic.List`1<UnityEngine.UI.Image>
struct List_1_tE6BB71ABF15905EFA2BE92C38A2716547AEADB19;
// System.Collections.Generic.List`1<System.Object>
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D;
// System.Collections.Generic.List`1<System.String>
struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD;
// System.Collections.Generic.List`1<DG.Tweening.Tween>
struct List_1_tDA2C18E15C40590123A37DABB6D0D9AEB77A3BBD;
// DG.Tweening.TweenCallback`1<System.Int32>
struct TweenCallback_1_tF0ADCA0C226C9C243ACB55E67D852E4BB53AEB67;
// UnityEngine.UI.CoroutineTween.TweenRunner`1<UnityEngine.UI.CoroutineTween.ColorTween>
struct TweenRunner_1_t5BB0582F926E75E2FE795492679A6CF55A4B4BC4;
// UnityEngine.Events.UnityEvent`1<UnityEngine.SpriteRenderer>
struct UnityEvent_1_t8ABE5544759145B8D7A09F1C54FFCB6907EDD56E;
// DG.Tweening.DOTweenAnimation[]
struct DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33;
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// UnityEngine.Keyframe[]
struct KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3;
// System.Object[]
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
// System.String[]
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
// DG.Tweening.Tween[]
struct TweenU5BU5D_t6E5F58C51FA0DA64C990C1C7E02EE9B70220C2F7;
// System.Type[]
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
// UnityEngine.UIVertex[]
struct UIVertexU5BU5D_tBC532486B45D071A520751A90E819C77BA4E3D2F;
// UnityEngine.Vector2[]
struct Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA;
// UnityEngine.Vector3[]
struct Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C;
// DG.Tweening.Core.ABSAnimationComponent
struct ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C;
// AOTGenericReferences
struct AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1;
// UnityEngine.AnimationCurve
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354;
// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
// System.Reflection.Binder
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
// UnityEngine.Camera
struct Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184;
// UnityEngine.Canvas
struct Canvas_t2DB4CEFDFF732884866C83F11ABF75F5AE8FFB26;
// UnityEngine.CanvasRenderer
struct CanvasRenderer_tAB9A55A976C4E3B2B37D0CE5616E5685A8B43860;
// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3;
// DG.Tweening.DOTweenAnimation
struct DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// DG.Tweening.EaseFunction
struct EaseFunction_t0F945D9D726B0915C5FBF30862E987EC3AC12A04;
// UnityEngine.UI.FontData
struct FontData_tB8E562846C6CB59C43260F69AE346B9BF3157224;
// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F;
// System.IAsyncResult
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
// UnityEngine.UI.Image
struct Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E;
// UnityEngine.Events.InvokableCallList
struct InvokableCallList_t309E1C8C7CE885A0D2F98C84CEA77A8935688382;
// UnityEngine.Material
struct Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3;
// System.Reflection.MemberFilter
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
// UnityEngine.Mesh
struct Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71;
// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C;
// UnityEngine.Events.PersistentCallGroup
struct PersistentCallGroup_tB826EDF15DC80F71BCBCD8E410FD959A04C33F25;
// UnityEngine.UI.RectMask2D
struct RectMask2D_tACF92BE999C791A665BD1ADEABF5BCEB82846670;
// UnityEngine.RectTransform
struct RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5;
// UnityEngine.Renderer
struct Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF;
// UnityEngine.Rigidbody
struct Rigidbody_t268697F5A994213ED97393309870968BC1C7393C;
// UnityEngine.Rigidbody2D
struct Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F;
// DG.Tweening.Sequence
struct Sequence_tEADBE56D6ED2E9EE8FB2E5459C3E57131EC0545C;
// UnityEngine.Sprite
struct Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99;
// UnityEngine.SpriteRenderer
struct SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B;
// System.String
struct String_t;
// UnityEngine.UI.Text
struct Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62;
// UnityEngine.TextGenerator
struct TextGenerator_t85D00417640A53953556C01F9D4E7DDE1ABD8FEC;
// UnityEngine.Texture2D
struct Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4;
// UnityEngine.Transform
struct Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1;
// DG.Tweening.Tween
struct Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C;
// DG.Tweening.TweenCallback
struct TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24;
// DG.Tweening.Tweener
struct Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140;
// System.Type
struct Type_t;
// UnityEngine.Events.UnityAction
struct UnityAction_t11A1F3B953B365C072A5DCC32677EE1796A962A7;
// UnityEngine.Events.UnityEvent
struct UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977;
// UnityEngine.UI.VertexHelper
struct VertexHelper_tB905FCB02AE67CBEE5F265FE37A5938FC5D136FE;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// UnityEngine.Camera/CameraCallback
struct CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD;
// UnityEngine.UI.MaskableGraphic/CullStateChangedEvent
struct CullStateChangedEvent_t6073CD0D951EC1256BF74B8F9107D68FC89B99B8;
// UnityEngine.RectTransform/ReapplyDrivenProperties
struct ReapplyDrivenProperties_t3482EA130A01FF7EE2EEFE37F66A5215D08CFE24;

IL2CPP_EXTERN_C RuntimeClass* AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Debugger_tCF42DBFBF81B46CDEE59CA397F2860F3427FE1F0_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Rigidbody_t268697F5A994213ED97393309870968BC1C7393C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Type_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral0B34DFC38793BF0AF6DEA9A94F7CCB4150E999A6;
IL2CPP_EXTERN_C String_t* _stringLiteral3A9AC714D9B78BE9FD8D8488AC619D7F2556992A;
IL2CPP_EXTERN_C String_t* _stringLiteral5C7CEB94DDE6943CD9A1AFDE2E7DC4665C264D15;
IL2CPP_EXTERN_C String_t* _stringLiteralA3F029047BA90CC134023587DF7DCF444B38D009;
IL2CPP_EXTERN_C String_t* _stringLiteralACB79D4299D8B996F0F42C2299600522CACB4665;
IL2CPP_EXTERN_C String_t* _stringLiteralC7E9DAF844B25471D821CB8F094AE5423C2EECC4;
IL2CPP_EXTERN_C String_t* _stringLiteralC84B9655C474BF596AF319C7618FB8F6B4CC74BC;
IL2CPP_EXTERN_C String_t* _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709;
IL2CPP_EXTERN_C const RuntimeMethod* Component_GetComponents_TisDOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89_mBD8DF07C7D147339501B59183140B9EF098D3204_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* DOTweenAnimation_U3CCreateTweenU3Eb__30_0_m755B57E81CDC2C38C648AC70205AB9799BE36F90_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_GetComponents_TisDOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89_m95D9515665F9034EBE662B8B4835DB6B2817259B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenExtensions_Pause_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m67DE92D56689877B5E346FE6239B6DEF7BB63685_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenExtensions_Play_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCD6CAE712476C0289135EE4E2113770DFB882C79_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_From_TisTweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_mBD5BB455040E882AE50EEAB6A2501BE795C1D799_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_OnComplete_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mBE711AE994C1480385AE49921B1DE8D773AC0F6F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_OnKill_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mBBA1302CE258A2BE2EDB4EAB0282A0F7E57A574F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_OnPlay_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m0FBA342A78026EAD99F1F4E3E4985D1872AEBF3B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_OnStart_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m745FAA93F7F77272847DE1A1E848E87E6D71DD85_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_OnStepComplete_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m792BB03889E21524E3344FA61E814C7584D3BE7C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_OnUpdate_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m57E18275D826369CD94860A3F1C39309D94D7379_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_SetAutoKill_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCBB51799984C28B2039C1B35CB74368B6086A92B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_SetDelay_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m2CEAE4E85D33463167ECC3B78A9F01FF36E41E43_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_SetEase_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mDA92D25D7C9B5461C21556F824B8615E54D4B102_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_SetEase_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mEAB195CDAFF31E19188BBC670CFC250810B26F6F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_SetId_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m29DE8BDBFA580F00E9FAE7DDC47937BCFCC30085_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_SetLoops_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mD6F6CE91C47CB2C78B0DC42F6F9452FEF789419C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_SetRelative_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m39A70F3F6856D8F28E39EDE44E5A3E20053DA917_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_SetTarget_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m27A612ECE14371AB2BA5F411E9D7739F28208EC5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* TweenSettingsExtensions_SetUpdate_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mC3077CF17652F227E5720D80251A7B8238090CF8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* UnityEvent_Invoke_mFBF80D59B03C30C5FE6A06F897D954ACADE061D2_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeType* Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Rigidbody_t268697F5A994213ED97393309870968BC1C7393C_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_0_0_0_var;
IL2CPP_EXTERN_C const RuntimeType* Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_0_0_0_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;

struct DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33;
struct KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3;
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tBB65183F1134474D09FF49B95625D25472B9BA8B 
{
};

// System.Collections.Generic.List`1<System.Object>
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___s_emptyArray_5;
};

// System.Collections.Generic.List`1<System.String>
struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___s_emptyArray_5;
};

// System.Collections.Generic.List`1<DG.Tweening.Tween>
struct List_1_tDA2C18E15C40590123A37DABB6D0D9AEB77A3BBD  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	TweenU5BU5D_t6E5F58C51FA0DA64C990C1C7E02EE9B70220C2F7* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

struct List_1_tDA2C18E15C40590123A37DABB6D0D9AEB77A3BBD_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	TweenU5BU5D_t6E5F58C51FA0DA64C990C1C7E02EE9B70220C2F7* ___s_emptyArray_5;
};

// DG.Tweening.Core.ABSSequentiable
struct ABSSequentiable_t05DF85FC63E3650D2D4CF6ABBA0F43263EB8CE89  : public RuntimeObject
{
	// DG.Tweening.TweenType DG.Tweening.Core.ABSSequentiable::tweenType
	int32_t ___tweenType_0;
	// System.Single DG.Tweening.Core.ABSSequentiable::sequencedPosition
	float ___sequencedPosition_1;
	// System.Single DG.Tweening.Core.ABSSequentiable::sequencedEndPosition
	float ___sequencedEndPosition_2;
	// DG.Tweening.TweenCallback DG.Tweening.Core.ABSSequentiable::onStart
	TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___onStart_3;
};
struct Il2CppArrayBounds;

// DG.Tweening.DOTweenAnimationExtensions
struct DOTweenAnimationExtensions_t322F12945BA2ABB5DA1E5C986FC693E30DE1D5C6  : public RuntimeObject
{
};

// DG.Tweening.Core.Debugger
struct Debugger_tCF42DBFBF81B46CDEE59CA397F2860F3427FE1F0  : public RuntimeObject
{
};

struct Debugger_tCF42DBFBF81B46CDEE59CA397F2860F3427FE1F0_StaticFields
{
	// System.Int32 DG.Tweening.Core.Debugger::logPriority
	int32_t ___logPriority_0;
};

// System.Reflection.MemberInfo
struct MemberInfo_t  : public RuntimeObject
{
};

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// UnityEngine.Events.UnityEventBase
struct UnityEventBase_t4968A4C72559F35C0923E4BD9C042C3A842E1DB8  : public RuntimeObject
{
	// UnityEngine.Events.InvokableCallList UnityEngine.Events.UnityEventBase::m_Calls
	InvokableCallList_t309E1C8C7CE885A0D2F98C84CEA77A8935688382* ___m_Calls_0;
	// UnityEngine.Events.PersistentCallGroup UnityEngine.Events.UnityEventBase::m_PersistentCalls
	PersistentCallGroup_tB826EDF15DC80F71BCBCD8E410FD959A04C33F25* ___m_PersistentCalls_1;
	// System.Boolean UnityEngine.Events.UnityEventBase::m_CallsDirty
	bool ___m_CallsDirty_2;
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// UnityEngine.Color
struct Color_tD001788D726C3A7F1379BEED0260B9591F440C1F 
{
	// System.Single UnityEngine.Color::r
	float ___r_0;
	// System.Single UnityEngine.Color::g
	float ___g_1;
	// System.Single UnityEngine.Color::b
	float ___b_2;
	// System.Single UnityEngine.Color::a
	float ___a_3;
};

// System.Int32
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// UnityEngine.Keyframe
struct Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 
{
	// System.Single UnityEngine.Keyframe::m_Time
	float ___m_Time_0;
	// System.Single UnityEngine.Keyframe::m_Value
	float ___m_Value_1;
	// System.Single UnityEngine.Keyframe::m_InTangent
	float ___m_InTangent_2;
	// System.Single UnityEngine.Keyframe::m_OutTangent
	float ___m_OutTangent_3;
	// System.Int32 UnityEngine.Keyframe::m_WeightedMode
	int32_t ___m_WeightedMode_4;
	// System.Single UnityEngine.Keyframe::m_InWeight
	float ___m_InWeight_5;
	// System.Single UnityEngine.Keyframe::m_OutWeight
	float ___m_OutWeight_6;
};

// UnityEngine.Rect
struct Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D 
{
	// System.Single UnityEngine.Rect::m_XMin
	float ___m_XMin_0;
	// System.Single UnityEngine.Rect::m_YMin
	float ___m_YMin_1;
	// System.Single UnityEngine.Rect::m_Width
	float ___m_Width_2;
	// System.Single UnityEngine.Rect::m_Height
	float ___m_Height_3;
};

// System.Single
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	// System.Single System.Single::m_value
	float ___m_value_0;
};

// DG.Tweening.Tween
struct Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C  : public ABSSequentiable_t05DF85FC63E3650D2D4CF6ABBA0F43263EB8CE89
{
	// System.Single DG.Tweening.Tween::timeScale
	float ___timeScale_4;
	// System.Boolean DG.Tweening.Tween::isBackwards
	bool ___isBackwards_5;
	// System.Object DG.Tweening.Tween::id
	RuntimeObject* ___id_6;
	// System.Object DG.Tweening.Tween::target
	RuntimeObject* ___target_7;
	// DG.Tweening.UpdateType DG.Tweening.Tween::updateType
	int32_t ___updateType_8;
	// System.Boolean DG.Tweening.Tween::isIndependentUpdate
	bool ___isIndependentUpdate_9;
	// DG.Tweening.TweenCallback DG.Tweening.Tween::onPlay
	TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___onPlay_10;
	// DG.Tweening.TweenCallback DG.Tweening.Tween::onPause
	TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___onPause_11;
	// DG.Tweening.TweenCallback DG.Tweening.Tween::onRewind
	TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___onRewind_12;
	// DG.Tweening.TweenCallback DG.Tweening.Tween::onUpdate
	TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___onUpdate_13;
	// DG.Tweening.TweenCallback DG.Tweening.Tween::onStepComplete
	TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___onStepComplete_14;
	// DG.Tweening.TweenCallback DG.Tweening.Tween::onComplete
	TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___onComplete_15;
	// DG.Tweening.TweenCallback DG.Tweening.Tween::onKill
	TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___onKill_16;
	// DG.Tweening.TweenCallback`1<System.Int32> DG.Tweening.Tween::onWaypointChange
	TweenCallback_1_tF0ADCA0C226C9C243ACB55E67D852E4BB53AEB67* ___onWaypointChange_17;
	// System.Boolean DG.Tweening.Tween::isFrom
	bool ___isFrom_18;
	// System.Boolean DG.Tweening.Tween::isBlendable
	bool ___isBlendable_19;
	// System.Boolean DG.Tweening.Tween::isRecyclable
	bool ___isRecyclable_20;
	// System.Boolean DG.Tweening.Tween::isSpeedBased
	bool ___isSpeedBased_21;
	// System.Boolean DG.Tweening.Tween::autoKill
	bool ___autoKill_22;
	// System.Single DG.Tweening.Tween::duration
	float ___duration_23;
	// System.Int32 DG.Tweening.Tween::loops
	int32_t ___loops_24;
	// DG.Tweening.LoopType DG.Tweening.Tween::loopType
	int32_t ___loopType_25;
	// System.Single DG.Tweening.Tween::delay
	float ___delay_26;
	// System.Boolean DG.Tweening.Tween::isRelative
	bool ___isRelative_27;
	// DG.Tweening.Ease DG.Tweening.Tween::easeType
	int32_t ___easeType_28;
	// DG.Tweening.EaseFunction DG.Tweening.Tween::customEase
	EaseFunction_t0F945D9D726B0915C5FBF30862E987EC3AC12A04* ___customEase_29;
	// System.Single DG.Tweening.Tween::easeOvershootOrAmplitude
	float ___easeOvershootOrAmplitude_30;
	// System.Single DG.Tweening.Tween::easePeriod
	float ___easePeriod_31;
	// System.Type DG.Tweening.Tween::typeofT1
	Type_t* ___typeofT1_32;
	// System.Type DG.Tweening.Tween::typeofT2
	Type_t* ___typeofT2_33;
	// System.Type DG.Tweening.Tween::typeofTPlugOptions
	Type_t* ___typeofTPlugOptions_34;
	// System.Boolean DG.Tweening.Tween::active
	bool ___active_35;
	// System.Boolean DG.Tweening.Tween::isSequenced
	bool ___isSequenced_36;
	// DG.Tweening.Sequence DG.Tweening.Tween::sequenceParent
	Sequence_tEADBE56D6ED2E9EE8FB2E5459C3E57131EC0545C* ___sequenceParent_37;
	// System.Int32 DG.Tweening.Tween::activeId
	int32_t ___activeId_38;
	// DG.Tweening.Core.Enums.SpecialStartupMode DG.Tweening.Tween::specialStartupMode
	int32_t ___specialStartupMode_39;
	// System.Boolean DG.Tweening.Tween::creationLocked
	bool ___creationLocked_40;
	// System.Boolean DG.Tweening.Tween::startupDone
	bool ___startupDone_41;
	// System.Boolean DG.Tweening.Tween::playedOnce
	bool ___playedOnce_42;
	// System.Single DG.Tweening.Tween::position
	float ___position_43;
	// System.Single DG.Tweening.Tween::fullDuration
	float ___fullDuration_44;
	// System.Int32 DG.Tweening.Tween::completedLoops
	int32_t ___completedLoops_45;
	// System.Boolean DG.Tweening.Tween::isPlaying
	bool ___isPlaying_46;
	// System.Boolean DG.Tweening.Tween::isComplete
	bool ___isComplete_47;
	// System.Single DG.Tweening.Tween::elapsedDelay
	float ___elapsedDelay_48;
	// System.Boolean DG.Tweening.Tween::delayComplete
	bool ___delayComplete_49;
	// System.Int32 DG.Tweening.Tween::miscInt
	int32_t ___miscInt_50;
};

// UnityEngine.Events.UnityEvent
struct UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977  : public UnityEventBase_t4968A4C72559F35C0923E4BD9C042C3A842E1DB8
{
	// System.Object[] UnityEngine.Events.UnityEvent::m_InvokeArray
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___m_InvokeArray_3;
};

// UnityEngine.Vector2
struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 
{
	// System.Single UnityEngine.Vector2::x
	float ___x_0;
	// System.Single UnityEngine.Vector2::y
	float ___y_1;
};

struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_StaticFields
{
	// UnityEngine.Vector2 UnityEngine.Vector2::zeroVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___zeroVector_2;
	// UnityEngine.Vector2 UnityEngine.Vector2::oneVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___oneVector_3;
	// UnityEngine.Vector2 UnityEngine.Vector2::upVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___upVector_4;
	// UnityEngine.Vector2 UnityEngine.Vector2::downVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___downVector_5;
	// UnityEngine.Vector2 UnityEngine.Vector2::leftVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___leftVector_6;
	// UnityEngine.Vector2 UnityEngine.Vector2::rightVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rightVector_7;
	// UnityEngine.Vector2 UnityEngine.Vector2::positiveInfinityVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___positiveInfinityVector_8;
	// UnityEngine.Vector2 UnityEngine.Vector2::negativeInfinityVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___negativeInfinityVector_9;
};

// UnityEngine.Vector3
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 
{
	// System.Single UnityEngine.Vector3::x
	float ___x_2;
	// System.Single UnityEngine.Vector3::y
	float ___y_3;
	// System.Single UnityEngine.Vector3::z
	float ___z_4;
};

struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields
{
	// UnityEngine.Vector3 UnityEngine.Vector3::zeroVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___zeroVector_5;
	// UnityEngine.Vector3 UnityEngine.Vector3::oneVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___oneVector_6;
	// UnityEngine.Vector3 UnityEngine.Vector3::upVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___upVector_7;
	// UnityEngine.Vector3 UnityEngine.Vector3::downVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___downVector_8;
	// UnityEngine.Vector3 UnityEngine.Vector3::leftVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___leftVector_9;
	// UnityEngine.Vector3 UnityEngine.Vector3::rightVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rightVector_10;
	// UnityEngine.Vector3 UnityEngine.Vector3::forwardVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___forwardVector_11;
	// UnityEngine.Vector3 UnityEngine.Vector3::backVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___backVector_12;
	// UnityEngine.Vector3 UnityEngine.Vector3::positiveInfinityVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positiveInfinityVector_13;
	// UnityEngine.Vector3 UnityEngine.Vector3::negativeInfinityVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___negativeInfinityVector_14;
};

// UnityEngine.Vector4
struct Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 
{
	// System.Single UnityEngine.Vector4::x
	float ___x_1;
	// System.Single UnityEngine.Vector4::y
	float ___y_2;
	// System.Single UnityEngine.Vector4::z
	float ___z_3;
	// System.Single UnityEngine.Vector4::w
	float ___w_4;
};

struct Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3_StaticFields
{
	// UnityEngine.Vector4 UnityEngine.Vector4::zeroVector
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___zeroVector_5;
	// UnityEngine.Vector4 UnityEngine.Vector4::oneVector
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___oneVector_6;
	// UnityEngine.Vector4 UnityEngine.Vector4::positiveInfinityVector
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___positiveInfinityVector_7;
	// UnityEngine.Vector4 UnityEngine.Vector4::negativeInfinityVector
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___negativeInfinityVector_8;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// UnityEngine.AnimationCurve
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354  : public RuntimeObject
{
	// System.IntPtr UnityEngine.AnimationCurve::m_Ptr
	intptr_t ___m_Ptr_0;
};
// Native definition for P/Invoke marshalling of UnityEngine.AnimationCurve
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke
{
	intptr_t ___m_Ptr_0;
};
// Native definition for COM marshalling of UnityEngine.AnimationCurve
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_com
{
	intptr_t ___m_Ptr_0;
};

// System.Delegate
struct Delegate_t  : public RuntimeObject
{
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject* ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.IntPtr System.Delegate::interp_method
	intptr_t ___interp_method_7;
	// System.IntPtr System.Delegate::interp_invoke_impl
	intptr_t ___interp_invoke_impl_8;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t* ___method_info_9;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t* ___original_method_info_10;
	// System.DelegateData System.Delegate::data
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_12;
};
// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};

// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;
};

struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_StaticFields
{
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;
};
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};

// System.RuntimeTypeHandle
struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	// System.IntPtr System.RuntimeTypeHandle::value
	intptr_t ___value_0;
};

// DG.Tweening.Tweener
struct Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140  : public Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C
{
	// System.Boolean DG.Tweening.Tweener::hasManuallySetStartValue
	bool ___hasManuallySetStartValue_51;
	// System.Boolean DG.Tweening.Tweener::isFromAllowed
	bool ___isFromAllowed_52;
};

// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.Material
struct Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// System.MulticastDelegate
struct MulticastDelegate_t  : public Delegate_t
{
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates_13;
};
// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_13;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_13;
};

// System.Type
struct Type_t  : public MemberInfo_t
{
	// System.RuntimeTypeHandle System.Type::_impl
	RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ____impl_8;
};

struct Type_t_StaticFields
{
	// System.Reflection.Binder modreq(System.Runtime.CompilerServices.IsVolatile) System.Type::s_defaultBinder
	Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235* ___s_defaultBinder_0;
	// System.Char System.Type::Delimiter
	Il2CppChar ___Delimiter_1;
	// System.Type[] System.Type::EmptyTypes
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___EmptyTypes_2;
	// System.Object System.Type::Missing
	RuntimeObject* ___Missing_3;
	// System.Reflection.MemberFilter System.Type::FilterAttribute
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterAttribute_4;
	// System.Reflection.MemberFilter System.Type::FilterName
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterName_5;
	// System.Reflection.MemberFilter System.Type::FilterNameIgnoreCase
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterNameIgnoreCase_6;
};

// UnityEngine.Behaviour
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.Renderer
struct Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.Rigidbody
struct Rigidbody_t268697F5A994213ED97393309870968BC1C7393C  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.Rigidbody2D
struct Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.Transform
struct Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// DG.Tweening.TweenCallback
struct TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24  : public MulticastDelegate_t
{
};

// UnityEngine.Camera
struct Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

struct Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_StaticFields
{
	// UnityEngine.Camera/CameraCallback UnityEngine.Camera::onPreCull
	CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD* ___onPreCull_4;
	// UnityEngine.Camera/CameraCallback UnityEngine.Camera::onPreRender
	CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD* ___onPreRender_5;
	// UnityEngine.Camera/CameraCallback UnityEngine.Camera::onPostRender
	CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD* ___onPostRender_6;
};

// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

// UnityEngine.RectTransform
struct RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5  : public Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1
{
};

struct RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_StaticFields
{
	// UnityEngine.RectTransform/ReapplyDrivenProperties UnityEngine.RectTransform::reapplyDrivenProperties
	ReapplyDrivenProperties_t3482EA130A01FF7EE2EEFE37F66A5215D08CFE24* ___reapplyDrivenProperties_4;
};

// UnityEngine.SpriteRenderer
struct SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B  : public Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF
{
	// UnityEngine.Events.UnityEvent`1<UnityEngine.SpriteRenderer> UnityEngine.SpriteRenderer::m_SpriteChangeEvent
	UnityEvent_1_t8ABE5544759145B8D7A09F1C54FFCB6907EDD56E* ___m_SpriteChangeEvent_4;
};

// DG.Tweening.Core.ABSAnimationComponent
struct ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// System.Boolean DG.Tweening.Core.ABSAnimationComponent::hasOnStart
	bool ___hasOnStart_4;
	// System.Boolean DG.Tweening.Core.ABSAnimationComponent::hasOnPlay
	bool ___hasOnPlay_5;
	// System.Boolean DG.Tweening.Core.ABSAnimationComponent::hasOnUpdate
	bool ___hasOnUpdate_6;
	// System.Boolean DG.Tweening.Core.ABSAnimationComponent::hasOnStepComplete
	bool ___hasOnStepComplete_7;
	// System.Boolean DG.Tweening.Core.ABSAnimationComponent::hasOnComplete
	bool ___hasOnComplete_8;
	// UnityEngine.Events.UnityEvent DG.Tweening.Core.ABSAnimationComponent::onStart
	UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* ___onStart_9;
	// UnityEngine.Events.UnityEvent DG.Tweening.Core.ABSAnimationComponent::onPlay
	UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* ___onPlay_10;
	// UnityEngine.Events.UnityEvent DG.Tweening.Core.ABSAnimationComponent::onUpdate
	UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* ___onUpdate_11;
	// UnityEngine.Events.UnityEvent DG.Tweening.Core.ABSAnimationComponent::onStepComplete
	UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* ___onStepComplete_12;
	// UnityEngine.Events.UnityEvent DG.Tweening.Core.ABSAnimationComponent::onComplete
	UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* ___onComplete_13;
	// DG.Tweening.Tween DG.Tweening.Core.ABSAnimationComponent::tween
	Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___tween_14;
};

// AOTGenericReferences
struct AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
};

struct AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_StaticFields
{
	// System.Collections.Generic.IReadOnlyList`1<System.String> AOTGenericReferences::PatchedAOTAssemblyList
	RuntimeObject* ___PatchedAOTAssemblyList_4;
};

// UnityEngine.EventSystems.UIBehaviour
struct UIBehaviour_tB9D4295827BD2EEDEF0749200C6CA7090C742A9D  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
};

// DG.Tweening.DOTweenAnimation
struct DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89  : public ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C
{
	// System.Single DG.Tweening.DOTweenAnimation::delay
	float ___delay_15;
	// System.Single DG.Tweening.DOTweenAnimation::duration
	float ___duration_16;
	// DG.Tweening.Ease DG.Tweening.DOTweenAnimation::easeType
	int32_t ___easeType_17;
	// UnityEngine.AnimationCurve DG.Tweening.DOTweenAnimation::easeCurve
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___easeCurve_18;
	// DG.Tweening.LoopType DG.Tweening.DOTweenAnimation::loopType
	int32_t ___loopType_19;
	// System.Int32 DG.Tweening.DOTweenAnimation::loops
	int32_t ___loops_20;
	// System.String DG.Tweening.DOTweenAnimation::id
	String_t* ___id_21;
	// System.Boolean DG.Tweening.DOTweenAnimation::isRelative
	bool ___isRelative_22;
	// System.Boolean DG.Tweening.DOTweenAnimation::isFrom
	bool ___isFrom_23;
	// System.Boolean DG.Tweening.DOTweenAnimation::isIndependentUpdate
	bool ___isIndependentUpdate_24;
	// System.Boolean DG.Tweening.DOTweenAnimation::autoKill
	bool ___autoKill_25;
	// System.Boolean DG.Tweening.DOTweenAnimation::isActive
	bool ___isActive_26;
	// System.Boolean DG.Tweening.DOTweenAnimation::isValid
	bool ___isValid_27;
	// UnityEngine.Component DG.Tweening.DOTweenAnimation::target
	Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* ___target_28;
	// DG.Tweening.Core.DOTweenAnimationType DG.Tweening.DOTweenAnimation::animationType
	int32_t ___animationType_29;
	// System.Boolean DG.Tweening.DOTweenAnimation::autoPlay
	bool ___autoPlay_30;
	// System.Single DG.Tweening.DOTweenAnimation::endValueFloat
	float ___endValueFloat_31;
	// UnityEngine.Vector3 DG.Tweening.DOTweenAnimation::endValueV3
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___endValueV3_32;
	// UnityEngine.Color DG.Tweening.DOTweenAnimation::endValueColor
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___endValueColor_33;
	// System.String DG.Tweening.DOTweenAnimation::endValueString
	String_t* ___endValueString_34;
	// UnityEngine.Rect DG.Tweening.DOTweenAnimation::endValueRect
	Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___endValueRect_35;
	// System.Boolean DG.Tweening.DOTweenAnimation::optionalBool0
	bool ___optionalBool0_36;
	// System.Single DG.Tweening.DOTweenAnimation::optionalFloat0
	float ___optionalFloat0_37;
	// System.Int32 DG.Tweening.DOTweenAnimation::optionalInt0
	int32_t ___optionalInt0_38;
	// DG.Tweening.RotateMode DG.Tweening.DOTweenAnimation::optionalRotationMode
	int32_t ___optionalRotationMode_39;
	// DG.Tweening.ScrambleMode DG.Tweening.DOTweenAnimation::optionalScrambleMode
	int32_t ___optionalScrambleMode_40;
	// System.String DG.Tweening.DOTweenAnimation::optionalString
	String_t* ___optionalString_41;
	// System.Int32 DG.Tweening.DOTweenAnimation::_playCount
	int32_t ____playCount_42;
};

// UnityEngine.UI.Graphic
struct Graphic_tCBFCA4585A19E2B75465AECFEAC43F4016BF7931  : public UIBehaviour_tB9D4295827BD2EEDEF0749200C6CA7090C742A9D
{
	// UnityEngine.Material UnityEngine.UI.Graphic::m_Material
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___m_Material_6;
	// UnityEngine.Color UnityEngine.UI.Graphic::m_Color
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_Color_7;
	// System.Boolean UnityEngine.UI.Graphic::m_SkipLayoutUpdate
	bool ___m_SkipLayoutUpdate_8;
	// System.Boolean UnityEngine.UI.Graphic::m_SkipMaterialUpdate
	bool ___m_SkipMaterialUpdate_9;
	// System.Boolean UnityEngine.UI.Graphic::m_RaycastTarget
	bool ___m_RaycastTarget_10;
	// System.Boolean UnityEngine.UI.Graphic::m_RaycastTargetCache
	bool ___m_RaycastTargetCache_11;
	// UnityEngine.Vector4 UnityEngine.UI.Graphic::m_RaycastPadding
	Vector4_t58B63D32F48C0DBF50DE2C60794C4676C80EDBE3 ___m_RaycastPadding_12;
	// UnityEngine.RectTransform UnityEngine.UI.Graphic::m_RectTransform
	RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5* ___m_RectTransform_13;
	// UnityEngine.CanvasRenderer UnityEngine.UI.Graphic::m_CanvasRenderer
	CanvasRenderer_tAB9A55A976C4E3B2B37D0CE5616E5685A8B43860* ___m_CanvasRenderer_14;
	// UnityEngine.Canvas UnityEngine.UI.Graphic::m_Canvas
	Canvas_t2DB4CEFDFF732884866C83F11ABF75F5AE8FFB26* ___m_Canvas_15;
	// System.Boolean UnityEngine.UI.Graphic::m_VertsDirty
	bool ___m_VertsDirty_16;
	// System.Boolean UnityEngine.UI.Graphic::m_MaterialDirty
	bool ___m_MaterialDirty_17;
	// UnityEngine.Events.UnityAction UnityEngine.UI.Graphic::m_OnDirtyLayoutCallback
	UnityAction_t11A1F3B953B365C072A5DCC32677EE1796A962A7* ___m_OnDirtyLayoutCallback_18;
	// UnityEngine.Events.UnityAction UnityEngine.UI.Graphic::m_OnDirtyVertsCallback
	UnityAction_t11A1F3B953B365C072A5DCC32677EE1796A962A7* ___m_OnDirtyVertsCallback_19;
	// UnityEngine.Events.UnityAction UnityEngine.UI.Graphic::m_OnDirtyMaterialCallback
	UnityAction_t11A1F3B953B365C072A5DCC32677EE1796A962A7* ___m_OnDirtyMaterialCallback_20;
	// UnityEngine.Mesh UnityEngine.UI.Graphic::m_CachedMesh
	Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* ___m_CachedMesh_23;
	// UnityEngine.Vector2[] UnityEngine.UI.Graphic::m_CachedUvs
	Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA* ___m_CachedUvs_24;
	// UnityEngine.UI.CoroutineTween.TweenRunner`1<UnityEngine.UI.CoroutineTween.ColorTween> UnityEngine.UI.Graphic::m_ColorTweenRunner
	TweenRunner_1_t5BB0582F926E75E2FE795492679A6CF55A4B4BC4* ___m_ColorTweenRunner_25;
	// System.Boolean UnityEngine.UI.Graphic::<useLegacyMeshGeneration>k__BackingField
	bool ___U3CuseLegacyMeshGenerationU3Ek__BackingField_26;
};

struct Graphic_tCBFCA4585A19E2B75465AECFEAC43F4016BF7931_StaticFields
{
	// UnityEngine.Material UnityEngine.UI.Graphic::s_DefaultUI
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___s_DefaultUI_4;
	// UnityEngine.Texture2D UnityEngine.UI.Graphic::s_WhiteTexture
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* ___s_WhiteTexture_5;
	// UnityEngine.Mesh UnityEngine.UI.Graphic::s_Mesh
	Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* ___s_Mesh_21;
	// UnityEngine.UI.VertexHelper UnityEngine.UI.Graphic::s_VertexHelper
	VertexHelper_tB905FCB02AE67CBEE5F265FE37A5938FC5D136FE* ___s_VertexHelper_22;
};

// UnityEngine.UI.MaskableGraphic
struct MaskableGraphic_tFC5B6BE351C90DE53744DF2A70940242774B361E  : public Graphic_tCBFCA4585A19E2B75465AECFEAC43F4016BF7931
{
	// System.Boolean UnityEngine.UI.MaskableGraphic::m_ShouldRecalculateStencil
	bool ___m_ShouldRecalculateStencil_27;
	// UnityEngine.Material UnityEngine.UI.MaskableGraphic::m_MaskMaterial
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___m_MaskMaterial_28;
	// UnityEngine.UI.RectMask2D UnityEngine.UI.MaskableGraphic::m_ParentMask
	RectMask2D_tACF92BE999C791A665BD1ADEABF5BCEB82846670* ___m_ParentMask_29;
	// System.Boolean UnityEngine.UI.MaskableGraphic::m_Maskable
	bool ___m_Maskable_30;
	// System.Boolean UnityEngine.UI.MaskableGraphic::m_IsMaskingGraphic
	bool ___m_IsMaskingGraphic_31;
	// System.Boolean UnityEngine.UI.MaskableGraphic::m_IncludeForMasking
	bool ___m_IncludeForMasking_32;
	// UnityEngine.UI.MaskableGraphic/CullStateChangedEvent UnityEngine.UI.MaskableGraphic::m_OnCullStateChanged
	CullStateChangedEvent_t6073CD0D951EC1256BF74B8F9107D68FC89B99B8* ___m_OnCullStateChanged_33;
	// System.Boolean UnityEngine.UI.MaskableGraphic::m_ShouldRecalculate
	bool ___m_ShouldRecalculate_34;
	// System.Int32 UnityEngine.UI.MaskableGraphic::m_StencilValue
	int32_t ___m_StencilValue_35;
	// UnityEngine.Vector3[] UnityEngine.UI.MaskableGraphic::m_Corners
	Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* ___m_Corners_36;
};

// UnityEngine.UI.Image
struct Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E  : public MaskableGraphic_tFC5B6BE351C90DE53744DF2A70940242774B361E
{
	// UnityEngine.Sprite UnityEngine.UI.Image::m_Sprite
	Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* ___m_Sprite_38;
	// UnityEngine.Sprite UnityEngine.UI.Image::m_OverrideSprite
	Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* ___m_OverrideSprite_39;
	// UnityEngine.UI.Image/Type UnityEngine.UI.Image::m_Type
	int32_t ___m_Type_40;
	// System.Boolean UnityEngine.UI.Image::m_PreserveAspect
	bool ___m_PreserveAspect_41;
	// System.Boolean UnityEngine.UI.Image::m_FillCenter
	bool ___m_FillCenter_42;
	// UnityEngine.UI.Image/FillMethod UnityEngine.UI.Image::m_FillMethod
	int32_t ___m_FillMethod_43;
	// System.Single UnityEngine.UI.Image::m_FillAmount
	float ___m_FillAmount_44;
	// System.Boolean UnityEngine.UI.Image::m_FillClockwise
	bool ___m_FillClockwise_45;
	// System.Int32 UnityEngine.UI.Image::m_FillOrigin
	int32_t ___m_FillOrigin_46;
	// System.Single UnityEngine.UI.Image::m_AlphaHitTestMinimumThreshold
	float ___m_AlphaHitTestMinimumThreshold_47;
	// System.Boolean UnityEngine.UI.Image::m_Tracked
	bool ___m_Tracked_48;
	// System.Boolean UnityEngine.UI.Image::m_UseSpriteMesh
	bool ___m_UseSpriteMesh_49;
	// System.Single UnityEngine.UI.Image::m_PixelsPerUnitMultiplier
	float ___m_PixelsPerUnitMultiplier_50;
	// System.Single UnityEngine.UI.Image::m_CachedReferencePixelsPerUnit
	float ___m_CachedReferencePixelsPerUnit_51;
};

struct Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E_StaticFields
{
	// UnityEngine.Material UnityEngine.UI.Image::s_ETC1DefaultUI
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___s_ETC1DefaultUI_37;
	// UnityEngine.Vector2[] UnityEngine.UI.Image::s_VertScratch
	Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA* ___s_VertScratch_52;
	// UnityEngine.Vector2[] UnityEngine.UI.Image::s_UVScratch
	Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA* ___s_UVScratch_53;
	// UnityEngine.Vector3[] UnityEngine.UI.Image::s_Xy
	Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* ___s_Xy_54;
	// UnityEngine.Vector3[] UnityEngine.UI.Image::s_Uv
	Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* ___s_Uv_55;
	// System.Collections.Generic.List`1<UnityEngine.UI.Image> UnityEngine.UI.Image::m_TrackedTexturelessImages
	List_1_tE6BB71ABF15905EFA2BE92C38A2716547AEADB19* ___m_TrackedTexturelessImages_56;
	// System.Boolean UnityEngine.UI.Image::s_Initialized
	bool ___s_Initialized_57;
};

// UnityEngine.UI.Text
struct Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62  : public MaskableGraphic_tFC5B6BE351C90DE53744DF2A70940242774B361E
{
	// UnityEngine.UI.FontData UnityEngine.UI.Text::m_FontData
	FontData_tB8E562846C6CB59C43260F69AE346B9BF3157224* ___m_FontData_37;
	// System.String UnityEngine.UI.Text::m_Text
	String_t* ___m_Text_38;
	// UnityEngine.TextGenerator UnityEngine.UI.Text::m_TextCache
	TextGenerator_t85D00417640A53953556C01F9D4E7DDE1ABD8FEC* ___m_TextCache_39;
	// UnityEngine.TextGenerator UnityEngine.UI.Text::m_TextCacheForLayout
	TextGenerator_t85D00417640A53953556C01F9D4E7DDE1ABD8FEC* ___m_TextCacheForLayout_40;
	// System.Boolean UnityEngine.UI.Text::m_DisableFontTextureRebuiltCallback
	bool ___m_DisableFontTextureRebuiltCallback_42;
	// UnityEngine.UIVertex[] UnityEngine.UI.Text::m_TempVerts
	UIVertexU5BU5D_tBC532486B45D071A520751A90E819C77BA4E3D2F* ___m_TempVerts_43;
};

struct Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_StaticFields
{
	// UnityEngine.Material UnityEngine.UI.Text::s_DefaultText
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___s_DefaultText_41;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// DG.Tweening.DOTweenAnimation[]
struct DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33  : public RuntimeArray
{
	ALIGN_FIELD (8) DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* m_Items[1];

	inline DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// UnityEngine.Keyframe[]
struct KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3  : public RuntimeArray
{
	ALIGN_FIELD (8) Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 m_Items[1];

	inline Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 value)
	{
		m_Items[index] = value;
	}
};
// System.Object[]
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918  : public RuntimeArray
{
	ALIGN_FIELD (8) RuntimeObject* m_Items[1];

	inline RuntimeObject* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline RuntimeObject* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<System.Object>::Add(T)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Add_mEBCF994CC3814631017F46A387B1A192ED6C85C7_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, RuntimeObject* ___item0, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::From<System.Object>(T,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_From_TisRuntimeObject_m581919CB70693A14993B037509BAA8E8EC1EC530_gshared (RuntimeObject* ___t0, bool ___isRelative1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::SetRelative<System.Object>(T,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_SetRelative_TisRuntimeObject_mA2AD07BE9F0E803F61F6B09473DFE479A65ADBE1_gshared (RuntimeObject* ___t0, bool ___isRelative1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::SetTarget<System.Object>(T,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_SetTarget_TisRuntimeObject_m864840DC4375075588F2154A96F118D5FAEE3FD6_gshared (RuntimeObject* ___t0, RuntimeObject* ___target1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::SetDelay<System.Object>(T,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_SetDelay_TisRuntimeObject_mF70ED89B398DC4E92D4C6835829159161826326B_gshared (RuntimeObject* ___t0, float ___delay1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::SetLoops<System.Object>(T,System.Int32,DG.Tweening.LoopType)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_SetLoops_TisRuntimeObject_m47D6D13211B8E98EC93621D5ACA6828C463AFBF9_gshared (RuntimeObject* ___t0, int32_t ___loops1, int32_t ___loopType2, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::SetAutoKill<System.Object>(T,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_SetAutoKill_TisRuntimeObject_m5303908097DB4965532C4DAE045A5ADB75808258_gshared (RuntimeObject* ___t0, bool ___autoKillOnCompletion1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::OnKill<System.Object>(T,DG.Tweening.TweenCallback)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_OnKill_TisRuntimeObject_m168DA4CCA1333ECE0D8191965AFF93CEB822BA14_gshared (RuntimeObject* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::SetEase<System.Object>(T,UnityEngine.AnimationCurve)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_SetEase_TisRuntimeObject_mDA26A73227A145837952376DD9573026EB80599F_gshared (RuntimeObject* ___t0, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___animCurve1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::SetEase<System.Object>(T,DG.Tweening.Ease)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_SetEase_TisRuntimeObject_m28E0D61D2E7C5417FB6048D549C4A02BCABF3F46_gshared (RuntimeObject* ___t0, int32_t ___ease1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::SetId<System.Object>(T,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_SetId_TisRuntimeObject_m4B8AB59FFA372675B88C64DFDD914995A0FAB349_gshared (RuntimeObject* ___t0, RuntimeObject* ___id1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::SetUpdate<System.Object>(T,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_SetUpdate_TisRuntimeObject_m31DAD606349424C0FDDA8FD20A1155DB5DE576D7_gshared (RuntimeObject* ___t0, bool ___isIndependentUpdate1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::OnStart<System.Object>(T,DG.Tweening.TweenCallback)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_OnStart_TisRuntimeObject_m52FC13AB79CA3D572C72BA5BBCE169E95B255CE5_gshared (RuntimeObject* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::OnPlay<System.Object>(T,DG.Tweening.TweenCallback)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_OnPlay_TisRuntimeObject_m3DC6406E5D6E8C865EB9FDFCF625C08A9A0870B7_gshared (RuntimeObject* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::OnUpdate<System.Object>(T,DG.Tweening.TweenCallback)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_OnUpdate_TisRuntimeObject_m15415E2F0A79910AE2BEE06E8C7B0696B9E6ECE8_gshared (RuntimeObject* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::OnStepComplete<System.Object>(T,DG.Tweening.TweenCallback)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_OnStepComplete_TisRuntimeObject_mECE3A33094D444884FDA86525A4C76348E06008A_gshared (RuntimeObject* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::OnComplete<System.Object>(T,DG.Tweening.TweenCallback)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenSettingsExtensions_OnComplete_TisRuntimeObject_mC014D07E92193DA79B257C4508B6DF208FE502A6_gshared (RuntimeObject* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenExtensions::Play<System.Object>(T)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenExtensions_Play_TisRuntimeObject_m255A424EE8F1D490359AB0C9CC5D8393F5C2B1B7_gshared (RuntimeObject* ___t0, const RuntimeMethod* method) ;
// T DG.Tweening.TweenExtensions::Pause<System.Object>(T)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* TweenExtensions_Pause_TisRuntimeObject_m36D60DCEDF6720E9E82F204E1AE3B95E9E53C364_gshared (RuntimeObject* ___t0, const RuntimeMethod* method) ;
// T[] UnityEngine.GameObject::GetComponents<System.Object>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* GameObject_GetComponents_TisRuntimeObject_m1654344F5C897CA86F9AB51530972086BDB05948_gshared (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method) ;
// T[] UnityEngine.Component::GetComponents<System.Object>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* Component_GetComponents_TisRuntimeObject_m35447B0B07F9C06A1AF846E482EC6FEB09D2436F_gshared (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method) ;

// System.Void UnityEngine.MonoBehaviour::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<System.String>::.ctor()
inline void List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*, const RuntimeMethod*))List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared)(__this, method);
}
// System.Void System.Collections.Generic.List`1<System.String>::Add(T)
inline void List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, String_t* ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*, String_t*, const RuntimeMethod*))List_1_Add_mEBCF994CC3814631017F46A387B1A192ED6C85C7_gshared_inline)(__this, ___item0, method);
}
// System.Void DG.Tweening.DOTweenAnimation::CreateTween()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_CreateTween_m91F4DAB080F554854AF7953DC7EF81409098F8F2 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) ;
// System.Boolean DG.Tweening.TweenExtensions::IsActive(DG.Tweening.Tween)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool TweenExtensions_IsActive_m7CB8E490D86B9E14B6B4B4004F1D199790397743_inline (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, const RuntimeMethod* method) ;
// System.Void DG.Tweening.TweenExtensions::Kill(DG.Tweening.Tween,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TweenExtensions_Kill_mFFDE4DE45D8A91C357ABFF2F8FA95D412924F466 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, bool ___complete1, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Object::op_Equality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___x0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___y1, const RuntimeMethod* method) ;
// UnityEngine.GameObject UnityEngine.Component::get_gameObject()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method) ;
// System.String UnityEngine.Object::get_name()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Object_get_name_mAC2F6B897CF1303BA4249B4CB55271AFACBB6392 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* __this, const RuntimeMethod* method) ;
// System.String System.String::Format(System.String,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Format_mA8DBB4C2516B9723C5A41E6CB1E2FAF4BBE96DD8 (String_t* ___format0, RuntimeObject* ___arg01, const RuntimeMethod* method) ;
// System.Void UnityEngine.Debug::LogWarning(System.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogWarning_m23033D7E2F0F298BE465B7F3A63CDF40A4EB70EB (RuntimeObject* ___message0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___context1, const RuntimeMethod* method) ;
// System.Type System.Object::GetType()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t* Object_GetType_mE10A8FC1E57F3DF29972CCBC026C2DC3942263B3 (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t* Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57 (RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ___handle0, const RuntimeMethod* method) ;
// System.Boolean DG.Tweening.DOTweenAnimationExtensions::IsSameOrSubclassOf(System.Type,System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8 (Type_t* ___t0, Type_t* ___tBase1, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions46::DOAnchorPos3D(UnityEngine.RectTransform,UnityEngine.Vector3,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions46_DOAnchorPos3D_mD3C94958F7972F83394BA948D2C8B647730FE6CF (RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___endValue1, float ___duration2, bool ___snapping3, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOMove(UnityEngine.Transform,UnityEngine.Vector3,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOMove_mC87BC8CB9F4E50901E6E7C970083FCB10BE97DA7 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___endValue1, float ___duration2, bool ___snapping3, const RuntimeMethod* method) ;
// UnityEngine.Vector2 UnityEngine.Vector2::op_Implicit(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Implicit_mE8EBEE9291F11BB02F062D6E000F4798968CBD96_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v0, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions43::DOMove(UnityEngine.Rigidbody2D,UnityEngine.Vector2,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions43_DOMove_mBB1F0330438A14C8380F8559F9BA19C279AE87B6 (Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F* ___target0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___endValue1, float ___duration2, bool ___snapping3, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOMove(UnityEngine.Rigidbody,UnityEngine.Vector3,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOMove_mA4F3D349D60820C1D16C10FAE5DE6AB3DC27FDC9 (Rigidbody_t268697F5A994213ED97393309870968BC1C7393C* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___endValue1, float ___duration2, bool ___snapping3, const RuntimeMethod* method) ;
// UnityEngine.Transform UnityEngine.Component::get_transform()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371 (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOLocalMove(UnityEngine.Transform,UnityEngine.Vector3,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOLocalMove_mE8D7AFEDAD7C66BA5FC0D4120E224AE0D70285AF (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___endValue1, float ___duration2, bool ___snapping3, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DORotate(UnityEngine.Transform,UnityEngine.Vector3,System.Single,DG.Tweening.RotateMode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DORotate_m4D79691940046EC19FAB940BA10F860A88DEC522 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___endValue1, float ___duration2, int32_t ___mode3, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions43::DORotate(UnityEngine.Rigidbody2D,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions43_DORotate_mAD9778B3D728A804C0D1FF4786D124683A82E600 (Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F* ___target0, float ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DORotate(UnityEngine.Rigidbody,UnityEngine.Vector3,System.Single,DG.Tweening.RotateMode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DORotate_m61ED3A616AA5410E25FEB01FC262E1E0CD257852 (Rigidbody_t268697F5A994213ED97393309870968BC1C7393C* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___endValue1, float ___duration2, int32_t ___mode3, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOLocalRotate(UnityEngine.Transform,UnityEngine.Vector3,System.Single,DG.Tweening.RotateMode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOLocalRotate_m027486E5C7F402BCABC9BA2599BA9BC85D77731A (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___endValue1, float ___duration2, int32_t ___mode3, const RuntimeMethod* method) ;
// System.Void UnityEngine.Vector3::.ctor(System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOScale(UnityEngine.Transform,UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOScale_m5D4EEFCF953640BEDFDE4A43162BEB9E533C24DE (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions43::DOColor(UnityEngine.SpriteRenderer,UnityEngine.Color,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions43_DOColor_m93DBCF7427FA75576E02531A8888053735F60AD5 (SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B* ___target0, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// UnityEngine.Material UnityEngine.Renderer::get_material()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* Renderer_get_material_m5BA2A00816C4CC66580D4B2E409CF10718C15656 (Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF* __this, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOColor(UnityEngine.Material,UnityEngine.Color,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOColor_m97E7121A6D5733170515C79FA753F6DFA5CEF7BF (Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___target0, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions46::DOColor(UnityEngine.UI.Image,UnityEngine.Color,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions46_DOColor_mACBA44C55FA1833043B88499BDE9CCDFED6E459E (Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E* ___target0, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions46::DOColor(UnityEngine.UI.Text,UnityEngine.Color,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions46_DOColor_m1A1DB7FCA93E4FFB66E43D1565C62CA3632D4772 (Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62* ___target0, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions43::DOFade(UnityEngine.SpriteRenderer,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions43_DOFade_m479E5D5206F105288CF8AE4C0AB6E01028E577B7 (SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B* ___target0, float ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOFade(UnityEngine.Material,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOFade_mD6507EB288274EA459D2997A8EF5E47C7EA72C33 (Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___target0, float ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions46::DOFade(UnityEngine.UI.Image,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions46_DOFade_mF0F20522E904CF538B5036C6F9F6A98DE0FB98EC (Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E* ___target0, float ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions46::DOFade(UnityEngine.UI.Text,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions46_DOFade_mAE86E0EA9887447ED242D3E359B6EFA8ABFF4F25 (Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62* ___target0, float ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions46::DOText(UnityEngine.UI.Text,System.String,System.Single,System.Boolean,DG.Tweening.ScrambleMode,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions46_DOText_m6F718F5034C1576A75508D3E31E39B71F5A97E94 (Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62* ___target0, String_t* ___endValue1, float ___duration2, bool ___richTextEnabled3, int32_t ___scrambleMode4, String_t* ___scrambleChars5, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions46::DOPunchAnchorPos(UnityEngine.RectTransform,UnityEngine.Vector2,System.Single,System.Int32,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions46_DOPunchAnchorPos_mAFB78DA20738B0D3E353919CE027000FBF010918 (RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5* ___target0, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___punch1, float ___duration2, int32_t ___vibrato3, float ___elasticity4, bool ___snapping5, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOPunchPosition(UnityEngine.Transform,UnityEngine.Vector3,System.Single,System.Int32,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOPunchPosition_mD022015ABB94942EE909F7F8E0F3660D52FA3D9E (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___punch1, float ___duration2, int32_t ___vibrato3, float ___elasticity4, bool ___snapping5, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOPunchScale(UnityEngine.Transform,UnityEngine.Vector3,System.Single,System.Int32,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOPunchScale_mD7D825D1761F0264BC1D00027B79330844400B9A (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___punch1, float ___duration2, int32_t ___vibrato3, float ___elasticity4, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOPunchRotation(UnityEngine.Transform,UnityEngine.Vector3,System.Single,System.Int32,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOPunchRotation_mDC55C1F23E2C17A4E9D4BF5BB787BB1DE98D7AC4 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___punch1, float ___duration2, int32_t ___vibrato3, float ___elasticity4, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions46::DOShakeAnchorPos(UnityEngine.RectTransform,System.Single,UnityEngine.Vector2,System.Int32,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions46_DOShakeAnchorPos_m487B2DFC55303E3199ED9ED9CEFF29E00FFB9ECA (RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5* ___target0, float ___duration1, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___strength2, int32_t ___vibrato3, float ___randomness4, bool ___snapping5, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOShakePosition(UnityEngine.Transform,System.Single,UnityEngine.Vector3,System.Int32,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOShakePosition_mB1708D218190B3BB17EA994EC7FE38871215603A (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, float ___duration1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___strength2, int32_t ___vibrato3, float ___randomness4, bool ___snapping5, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOShakeScale(UnityEngine.Transform,System.Single,UnityEngine.Vector3,System.Int32,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOShakeScale_mC989EA82445A6F7C2181903FB28705523259B234 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, float ___duration1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___strength2, int32_t ___vibrato3, float ___randomness4, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOShakeRotation(UnityEngine.Transform,System.Single,UnityEngine.Vector3,System.Int32,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOShakeRotation_m28BF1DB063CEC970358BB0A55DF067AE5677B619 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___target0, float ___duration1, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___strength2, int32_t ___vibrato3, float ___randomness4, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOAspect(UnityEngine.Camera,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOAspect_m9259E372B05B663CEAF34FD052C7208B122F1B85 (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___target0, float ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOColor(UnityEngine.Camera,UnityEngine.Color,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOColor_m3F4236307CE5FFE06252C267B8C4A869DD6F8A84 (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___target0, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOFieldOfView(UnityEngine.Camera,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOFieldOfView_m2BDF26AA4FB6FA6D8FF303820B6DEAE4A5825E62 (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___target0, float ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOOrthoSize(UnityEngine.Camera,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOOrthoSize_m1264C986FBD05AA4E4EBEA48697ACCA451A18CFA (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___target0, float ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DOPixelRect(UnityEngine.Camera,UnityEngine.Rect,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DOPixelRect_mA1A61FA657FFDA09A2BC26FE8F076940FB48DD17 (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___target0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// DG.Tweening.Tweener DG.Tweening.ShortcutExtensions::DORect(UnityEngine.Camera,UnityEngine.Rect,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ShortcutExtensions_DORect_mB8CE84B918D661843A2C175D715BC10D3F59453D (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___target0, Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D ___endValue1, float ___duration2, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::From<DG.Tweening.Tweener>(T,System.Boolean)
inline Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* TweenSettingsExtensions_From_TisTweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_mBD5BB455040E882AE50EEAB6A2501BE795C1D799 (Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* ___t0, bool ___isRelative1, const RuntimeMethod* method)
{
	return ((  Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* (*) (Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140*, bool, const RuntimeMethod*))TweenSettingsExtensions_From_TisRuntimeObject_m581919CB70693A14993B037509BAA8E8EC1EC530_gshared)(___t0, ___isRelative1, method);
}
// T DG.Tweening.TweenSettingsExtensions::SetRelative<DG.Tweening.Tween>(T,System.Boolean)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_SetRelative_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m39A70F3F6856D8F28E39EDE44E5A3E20053DA917 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, bool ___isRelative1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, bool, const RuntimeMethod*))TweenSettingsExtensions_SetRelative_TisRuntimeObject_mA2AD07BE9F0E803F61F6B09473DFE479A65ADBE1_gshared)(___t0, ___isRelative1, method);
}
// T DG.Tweening.TweenSettingsExtensions::SetTarget<DG.Tweening.Tween>(T,System.Object)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_SetTarget_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m27A612ECE14371AB2BA5F411E9D7739F28208EC5 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, RuntimeObject* ___target1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, RuntimeObject*, const RuntimeMethod*))TweenSettingsExtensions_SetTarget_TisRuntimeObject_m864840DC4375075588F2154A96F118D5FAEE3FD6_gshared)(___t0, ___target1, method);
}
// T DG.Tweening.TweenSettingsExtensions::SetDelay<DG.Tweening.Tween>(T,System.Single)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_SetDelay_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m2CEAE4E85D33463167ECC3B78A9F01FF36E41E43 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, float ___delay1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, float, const RuntimeMethod*))TweenSettingsExtensions_SetDelay_TisRuntimeObject_mF70ED89B398DC4E92D4C6835829159161826326B_gshared)(___t0, ___delay1, method);
}
// T DG.Tweening.TweenSettingsExtensions::SetLoops<DG.Tweening.Tween>(T,System.Int32,DG.Tweening.LoopType)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_SetLoops_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mD6F6CE91C47CB2C78B0DC42F6F9452FEF789419C (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, int32_t ___loops1, int32_t ___loopType2, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, int32_t, int32_t, const RuntimeMethod*))TweenSettingsExtensions_SetLoops_TisRuntimeObject_m47D6D13211B8E98EC93621D5ACA6828C463AFBF9_gshared)(___t0, ___loops1, ___loopType2, method);
}
// T DG.Tweening.TweenSettingsExtensions::SetAutoKill<DG.Tweening.Tween>(T,System.Boolean)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_SetAutoKill_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCBB51799984C28B2039C1B35CB74368B6086A92B (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, bool ___autoKillOnCompletion1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, bool, const RuntimeMethod*))TweenSettingsExtensions_SetAutoKill_TisRuntimeObject_m5303908097DB4965532C4DAE045A5ADB75808258_gshared)(___t0, ___autoKillOnCompletion1, method);
}
// System.Void DG.Tweening.TweenCallback::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TweenCallback__ctor_m68CC9304423CBDE43001F9B1413B5DAAF70DB621 (TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::OnKill<DG.Tweening.Tween>(T,DG.Tweening.TweenCallback)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_OnKill_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mBBA1302CE258A2BE2EDB4EAB0282A0F7E57A574F (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*, const RuntimeMethod*))TweenSettingsExtensions_OnKill_TisRuntimeObject_m168DA4CCA1333ECE0D8191965AFF93CEB822BA14_gshared)(___t0, ___action1, method);
}
// T DG.Tweening.TweenSettingsExtensions::SetEase<DG.Tweening.Tween>(T,UnityEngine.AnimationCurve)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_SetEase_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mDA92D25D7C9B5461C21556F824B8615E54D4B102 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___animCurve1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, const RuntimeMethod*))TweenSettingsExtensions_SetEase_TisRuntimeObject_mDA26A73227A145837952376DD9573026EB80599F_gshared)(___t0, ___animCurve1, method);
}
// T DG.Tweening.TweenSettingsExtensions::SetEase<DG.Tweening.Tween>(T,DG.Tweening.Ease)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_SetEase_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mEAB195CDAFF31E19188BBC670CFC250810B26F6F (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, int32_t ___ease1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, int32_t, const RuntimeMethod*))TweenSettingsExtensions_SetEase_TisRuntimeObject_m28E0D61D2E7C5417FB6048D549C4A02BCABF3F46_gshared)(___t0, ___ease1, method);
}
// System.Boolean System.String::IsNullOrEmpty(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478 (String_t* ___value0, const RuntimeMethod* method) ;
// T DG.Tweening.TweenSettingsExtensions::SetId<DG.Tweening.Tween>(T,System.Object)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_SetId_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m29DE8BDBFA580F00E9FAE7DDC47937BCFCC30085 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, RuntimeObject* ___id1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, RuntimeObject*, const RuntimeMethod*))TweenSettingsExtensions_SetId_TisRuntimeObject_m4B8AB59FFA372675B88C64DFDD914995A0FAB349_gshared)(___t0, ___id1, method);
}
// T DG.Tweening.TweenSettingsExtensions::SetUpdate<DG.Tweening.Tween>(T,System.Boolean)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_SetUpdate_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mC3077CF17652F227E5720D80251A7B8238090CF8 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, bool ___isIndependentUpdate1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, bool, const RuntimeMethod*))TweenSettingsExtensions_SetUpdate_TisRuntimeObject_m31DAD606349424C0FDDA8FD20A1155DB5DE576D7_gshared)(___t0, ___isIndependentUpdate1, method);
}
// T DG.Tweening.TweenSettingsExtensions::OnStart<DG.Tweening.Tween>(T,DG.Tweening.TweenCallback)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_OnStart_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m745FAA93F7F77272847DE1A1E848E87E6D71DD85 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*, const RuntimeMethod*))TweenSettingsExtensions_OnStart_TisRuntimeObject_m52FC13AB79CA3D572C72BA5BBCE169E95B255CE5_gshared)(___t0, ___action1, method);
}
// T DG.Tweening.TweenSettingsExtensions::OnPlay<DG.Tweening.Tween>(T,DG.Tweening.TweenCallback)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_OnPlay_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m0FBA342A78026EAD99F1F4E3E4985D1872AEBF3B (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*, const RuntimeMethod*))TweenSettingsExtensions_OnPlay_TisRuntimeObject_m3DC6406E5D6E8C865EB9FDFCF625C08A9A0870B7_gshared)(___t0, ___action1, method);
}
// T DG.Tweening.TweenSettingsExtensions::OnUpdate<DG.Tweening.Tween>(T,DG.Tweening.TweenCallback)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_OnUpdate_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m57E18275D826369CD94860A3F1C39309D94D7379 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*, const RuntimeMethod*))TweenSettingsExtensions_OnUpdate_TisRuntimeObject_m15415E2F0A79910AE2BEE06E8C7B0696B9E6ECE8_gshared)(___t0, ___action1, method);
}
// T DG.Tweening.TweenSettingsExtensions::OnStepComplete<DG.Tweening.Tween>(T,DG.Tweening.TweenCallback)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_OnStepComplete_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m792BB03889E21524E3344FA61E814C7584D3BE7C (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*, const RuntimeMethod*))TweenSettingsExtensions_OnStepComplete_TisRuntimeObject_mECE3A33094D444884FDA86525A4C76348E06008A_gshared)(___t0, ___action1, method);
}
// T DG.Tweening.TweenSettingsExtensions::OnComplete<DG.Tweening.Tween>(T,DG.Tweening.TweenCallback)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenSettingsExtensions_OnComplete_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mBE711AE994C1480385AE49921B1DE8D773AC0F6F (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* ___action1, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*, const RuntimeMethod*))TweenSettingsExtensions_OnComplete_TisRuntimeObject_mC014D07E92193DA79B257C4508B6DF208FE502A6_gshared)(___t0, ___action1, method);
}
// T DG.Tweening.TweenExtensions::Play<DG.Tweening.Tween>(T)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenExtensions_Play_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCD6CAE712476C0289135EE4E2113770DFB882C79 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, const RuntimeMethod*))TweenExtensions_Play_TisRuntimeObject_m255A424EE8F1D490359AB0C9CC5D8393F5C2B1B7_gshared)(___t0, method);
}
// T DG.Tweening.TweenExtensions::Pause<DG.Tweening.Tween>(T)
inline Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* TweenExtensions_Pause_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m67DE92D56689877B5E346FE6239B6DEF7BB63685 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, const RuntimeMethod* method)
{
	return ((  Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* (*) (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*, const RuntimeMethod*))TweenExtensions_Pause_TisRuntimeObject_m36D60DCEDF6720E9E82F204E1AE3B95E9E53C364_gshared)(___t0, method);
}
// System.Int32 DG.Tweening.DOTween::Play(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_Play_m466F46F9DF6585E17C595438BA15147319540DC4 (RuntimeObject* ___targetOrId0, const RuntimeMethod* method) ;
// System.Int32 DG.Tweening.DOTween::PlayBackwards(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_PlayBackwards_m3709E26071CCE5CB368584477DF2FC9A8B9D052B (RuntimeObject* ___targetOrId0, const RuntimeMethod* method) ;
// System.Int32 DG.Tweening.DOTween::PlayForward(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_PlayForward_m4F27092024989DEB74466D9D9C370D5FA6621DCF (RuntimeObject* ___targetOrId0, const RuntimeMethod* method) ;
// System.Int32 DG.Tweening.DOTween::Pause(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_Pause_m498BECFBBC8FBD76425B8AE1F38E2ECC9AE296D4 (RuntimeObject* ___targetOrId0, const RuntimeMethod* method) ;
// System.Int32 DG.Tweening.DOTween::TogglePause(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_TogglePause_m8CE7CA00FE30F3C926F34362E2DE67A161536598 (RuntimeObject* ___targetOrId0, const RuntimeMethod* method) ;
// T[] UnityEngine.GameObject::GetComponents<DG.Tweening.DOTweenAnimation>()
inline DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* GameObject_GetComponents_TisDOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89_m95D9515665F9034EBE662B8B4835DB6B2817259B (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method)
{
	return ((  DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* (*) (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, const RuntimeMethod*))GameObject_GetComponents_TisRuntimeObject_m1654344F5C897CA86F9AB51530972086BDB05948_gshared)(__this, method);
}
// System.Boolean DG.Tweening.TweenExtensions::IsInitialized(DG.Tweening.Tween)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TweenExtensions_IsInitialized_m8C2B24B55147A6773849EB32D4D00E128CAB211B (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, const RuntimeMethod* method) ;
// System.Void DG.Tweening.TweenExtensions::Rewind(DG.Tweening.Tween,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TweenExtensions_Rewind_m0ECE9F671C1A1BE35270FD24F9AC81DC5645DAF1 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, bool ___includeDelay1, const RuntimeMethod* method) ;
// System.Void DG.Tweening.Core.Debugger::LogNullTween(DG.Tweening.Tween)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debugger_LogNullTween_m9C6A433A68F2C3DFCDFF127434135F8BBC116740 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, const RuntimeMethod* method) ;
// System.Void DG.Tweening.DOTweenAnimation::ReEvaluateRelativeTween()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_ReEvaluateRelativeTween_mD0A5E517DC24E42DA505252FF14510A82AF3D884 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) ;
// System.Int32 DG.Tweening.DOTween::Restart(System.Object,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_Restart_mC5BA3049922D5EA43F9E7A0B05735A21CADDBB64 (RuntimeObject* ___targetOrId0, bool ___includeDelay1, const RuntimeMethod* method) ;
// System.Int32 DG.Tweening.DOTween::Complete(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_Complete_mD95127D82A6D30613E788A90C9FA6E17BBDA634E (RuntimeObject* ___targetOrId0, const RuntimeMethod* method) ;
// System.Int32 DG.Tweening.DOTween::Kill(System.Object,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_Kill_mAB4C96CE1F1BCF25E5347AE0FC295D064EA53FB2 (RuntimeObject* ___targetOrId0, bool ___complete1, const RuntimeMethod* method) ;
// System.Int32 DG.Tweening.DOTween::Play(System.Object,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_Play_mEFD3A1E3CC218D3916032325F2E119C2004D9473 (RuntimeObject* ___target0, RuntimeObject* ___id1, const RuntimeMethod* method) ;
// T[] UnityEngine.Component::GetComponents<DG.Tweening.DOTweenAnimation>()
inline DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* Component_GetComponents_TisDOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89_mBD8DF07C7D147339501B59183140B9EF098D3204 (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method)
{
	return ((  DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* (*) (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3*, const RuntimeMethod*))Component_GetComponents_TisRuntimeObject_m35447B0B07F9C06A1AF846E482EC6FEB09D2436F_gshared)(__this, method);
}
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___x0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___y1, const RuntimeMethod* method) ;
// System.Boolean DG.Tweening.TweenExtensions::IsPlaying(DG.Tweening.Tween)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TweenExtensions_IsPlaying_m32EF28DEB59B931FA4607BAC3BED0DE275A1D843 (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, const RuntimeMethod* method) ;
// System.Boolean DG.Tweening.TweenExtensions::IsComplete(DG.Tweening.Tween)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TweenExtensions_IsComplete_mBB619B64C19A85AB4EEEBB3D37D3E720A9E0AF4C (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, const RuntimeMethod* method) ;
// System.Int32 DG.Tweening.DOTween::Rewind(System.Object,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_Rewind_m5C4020E9007FAAF719C1BE01CE440EBB39193619 (RuntimeObject* ___targetOrId0, bool ___includeDelay1, const RuntimeMethod* method) ;
// System.Void DG.Tweening.DOTweenAnimation::DOPlayNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOPlayNext_mB0A10A4963CBB56BC6AA79B312D7B8C00AADB1CA (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) ;
// System.Int32 DG.Tweening.DOTween::Restart(System.Object,System.Object,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DOTween_Restart_m777E54A0343B1EC43975D4DEBBE7B1958B52A63F (RuntimeObject* ___target0, RuntimeObject* ___id1, bool ___includeDelay2, const RuntimeMethod* method) ;
// System.Collections.Generic.List`1<DG.Tweening.Tween> DG.Tweening.DOTween::TweensByTarget(System.Object,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_tDA2C18E15C40590123A37DABB6D0D9AEB77A3BBD* DOTween_TweensByTarget_mA0B2273692BDA3C8658C4CD3FF177C74C2783B1A (RuntimeObject* ___target0, bool ___playingOnly1, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Transform::get_position()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Vector3::op_Addition(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Addition_m78C0EC70CB66E8DCAC225743D82B268DAEE92067_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Transform::get_localPosition()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Transform_get_localPosition_mA9C86B990DF0685EA1061A120218993FDCC60A95 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Keyframe::.ctor(System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34 (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* __this, float ___time0, float ___value1, const RuntimeMethod* method) ;
// System.Void UnityEngine.AnimationCurve::.ctor(UnityEngine.Keyframe[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* __this, KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* ___keys0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Color::.ctor(System.Single,System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* __this, float ___r0, float ___g1, float ___b2, float ___a3, const RuntimeMethod* method) ;
// System.Void UnityEngine.Rect::.ctor(System.Single,System.Single,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Rect__ctor_m18C3033D135097BEE424AAA68D91C706D2647F23 (Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D* __this, float ___x0, float ___y1, float ___width2, float ___height3, const RuntimeMethod* method) ;
// System.Void DG.Tweening.Core.ABSAnimationComponent::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ABSAnimationComponent__ctor_mF2DC2EF90DDA4C57EC4858124EEEE03FE4CBB328 (ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C* __this, const RuntimeMethod* method) ;
// System.Boolean System.Type::op_Equality(System.Type,System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Type_op_Equality_m99930A0E44E420A685FABA60E60BA1CC5FA0EBDC (Type_t* ___left0, Type_t* ___right1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Vector2::.ctor(System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* __this, float ___x0, float ___y1, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void AOTGenericReferences::RefMethods()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AOTGenericReferences_RefMethods_m17CF257D96D8BC2F232C4C1502905B792D17170C (AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1* __this, const RuntimeMethod* method) 
{
	{
		// }
		return;
	}
}
// System.Void AOTGenericReferences::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AOTGenericReferences__ctor_m41CBD692FC9B521512E552575AFE7A385DEC71A6 (AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1* __this, const RuntimeMethod* method) 
{
	{
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
		return;
	}
}
// System.Void AOTGenericReferences::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AOTGenericReferences__cctor_mA46BDC06A6577D725A2E5284A2A34C974CE65F68 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0B34DFC38793BF0AF6DEA9A94F7CCB4150E999A6);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5C7CEB94DDE6943CD9A1AFDE2E7DC4665C264D15);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA3F029047BA90CC134023587DF7DCF444B38D009);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralACB79D4299D8B996F0F42C2299600522CACB4665);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC7E9DAF844B25471D821CB8F094AE5423C2EECC4);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC84B9655C474BF596AF319C7618FB8F6B4CC74BC);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
		// {
		//     "GameFramework.dll",
		//     "System.dll",
		//     "UnityEngine.CoreModule.dll",
		//     "UnityGameFramework.Runtime.dll",
		//     "mscorlib.dll",
		//     "protobuf-net.dll",
		// };
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_0 = (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*)il2cpp_codegen_object_new(List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E(L_0, List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_1 = L_0;
		NullCheck(L_1);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_1, _stringLiteralACB79D4299D8B996F0F42C2299600522CACB4665, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_2 = L_1;
		NullCheck(L_2);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_2, _stringLiteralA3F029047BA90CC134023587DF7DCF444B38D009, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_3 = L_2;
		NullCheck(L_3);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_3, _stringLiteralC7E9DAF844B25471D821CB8F094AE5423C2EECC4, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_4 = L_3;
		NullCheck(L_4);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_4, _stringLiteralC84B9655C474BF596AF319C7618FB8F6B4CC74BC, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_5 = L_4;
		NullCheck(L_5);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_5, _stringLiteral0B34DFC38793BF0AF6DEA9A94F7CCB4150E999A6, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_6 = L_5;
		NullCheck(L_6);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_6, _stringLiteral5C7CEB94DDE6943CD9A1AFDE2E7DC4665C264D15, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		((AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_StaticFields*)il2cpp_codegen_static_fields_for(AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_il2cpp_TypeInfo_var))->___PatchedAOTAssemblyList_4 = L_6;
		Il2CppCodeGenWriteBarrier((void**)(&((AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_StaticFields*)il2cpp_codegen_static_fields_for(AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_il2cpp_TypeInfo_var))->___PatchedAOTAssemblyList_4), (void*)L_6);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void DG.Tweening.DOTweenAnimation::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_Awake_m8531F674633C180916C447ACF6C986EC18AF7B3B (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	{
		// if (!isActive || !isValid) return;
		bool L_0 = __this->___isActive_26;
		if (!L_0)
		{
			goto IL_0010;
		}
	}
	{
		bool L_1 = __this->___isValid_27;
		if (L_1)
		{
			goto IL_0011;
		}
	}

IL_0010:
	{
		// if (!isActive || !isValid) return;
		return;
	}

IL_0011:
	{
		// CreateTween();
		DOTweenAnimation_CreateTween_m91F4DAB080F554854AF7953DC7EF81409098F8F2(__this, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::OnDestroy()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_OnDestroy_mCE1919BF0059EA93C96345E2D2F7C0BE0F61B9AC (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	{
		// if (tween != null && tween.IsActive()) tween.Kill();
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_0 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		if (!L_0)
		{
			goto IL_0021;
		}
	}
	{
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_1 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		bool L_2;
		L_2 = TweenExtensions_IsActive_m7CB8E490D86B9E14B6B4B4004F1D199790397743_inline(L_1, NULL);
		if (!L_2)
		{
			goto IL_0021;
		}
	}
	{
		// if (tween != null && tween.IsActive()) tween.Kill();
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_3 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		TweenExtensions_Kill_mFFDE4DE45D8A91C357ABFF2F8FA95D412924F466(L_3, (bool)0, NULL);
	}

IL_0021:
	{
		// tween = null;
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)(Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*)NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::CreateTween()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_CreateTween_m91F4DAB080F554854AF7953DC7EF81409098F8F2 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTweenAnimation_U3CCreateTweenU3Eb__30_0_m755B57E81CDC2C38C648AC70205AB9799BE36F90_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Rigidbody_t268697F5A994213ED97393309870968BC1C7393C_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Rigidbody_t268697F5A994213ED97393309870968BC1C7393C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_0_0_0_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenExtensions_Pause_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m67DE92D56689877B5E346FE6239B6DEF7BB63685_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenExtensions_Play_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCD6CAE712476C0289135EE4E2113770DFB882C79_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_From_TisTweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_mBD5BB455040E882AE50EEAB6A2501BE795C1D799_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_OnComplete_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mBE711AE994C1480385AE49921B1DE8D773AC0F6F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_OnKill_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mBBA1302CE258A2BE2EDB4EAB0282A0F7E57A574F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_OnPlay_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m0FBA342A78026EAD99F1F4E3E4985D1872AEBF3B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_OnStart_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m745FAA93F7F77272847DE1A1E848E87E6D71DD85_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_OnStepComplete_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m792BB03889E21524E3344FA61E814C7584D3BE7C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_OnUpdate_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m57E18275D826369CD94860A3F1C39309D94D7379_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_SetAutoKill_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCBB51799984C28B2039C1B35CB74368B6086A92B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_SetDelay_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m2CEAE4E85D33463167ECC3B78A9F01FF36E41E43_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_SetEase_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mDA92D25D7C9B5461C21556F824B8615E54D4B102_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_SetEase_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mEAB195CDAFF31E19188BBC670CFC250810B26F6F_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_SetId_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m29DE8BDBFA580F00E9FAE7DDC47937BCFCC30085_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_SetLoops_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mD6F6CE91C47CB2C78B0DC42F6F9452FEF789419C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_SetRelative_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m39A70F3F6856D8F28E39EDE44E5A3E20053DA917_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_SetTarget_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m27A612ECE14371AB2BA5F411E9D7739F28208EC5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenSettingsExtensions_SetUpdate_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mC3077CF17652F227E5720D80251A7B8238090CF8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UnityEvent_Invoke_mFBF80D59B03C30C5FE6A06F897D954ACADE061D2_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral3A9AC714D9B78BE9FD8D8488AC619D7F2556992A);
		s_Il2CppMethodInitialized = true;
	}
	Type_t* V_0 = NULL;
	int32_t V_1 = 0;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* G_B22_0 = NULL;
	DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* G_B22_1 = NULL;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* G_B21_0 = NULL;
	DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* G_B21_1 = NULL;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B23_0;
	memset((&G_B23_0), 0, sizeof(G_B23_0));
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* G_B23_1 = NULL;
	DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* G_B23_2 = NULL;
	{
		// if (target == null) {
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_0 = __this->___target_28;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_1)
		{
			goto IL_002f;
		}
	}
	{
		// Debug.LogWarning(string.Format("{0} :: This tween's target is NULL, because the animation was created with a DOTween Pro version older than 0.9.255. To fix this, exit Play mode then simply select this object, and it will update automatically", this.gameObject.name), this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_2;
		L_2 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		NullCheck(L_2);
		String_t* L_3;
		L_3 = Object_get_name_mAC2F6B897CF1303BA4249B4CB55271AFACBB6392(L_2, NULL);
		String_t* L_4;
		L_4 = String_Format_mA8DBB4C2516B9723C5A41E6CB1E2FAF4BBE96DD8(_stringLiteral3A9AC714D9B78BE9FD8D8488AC619D7F2556992A, L_3, NULL);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_5;
		L_5 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_LogWarning_m23033D7E2F0F298BE465B7F3A63CDF40A4EB70EB(L_4, L_5, NULL);
		// return;
		return;
	}

IL_002f:
	{
		// Type t = target.GetType();
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_6 = __this->___target_28;
		NullCheck(L_6);
		Type_t* L_7;
		L_7 = Object_GetType_mE10A8FC1E57F3DF29972CCBC026C2DC3942263B3(L_6, NULL);
		V_0 = L_7;
		// switch (animationType) {
		int32_t L_8 = __this->___animationType_29;
		V_1 = L_8;
		int32_t L_9 = V_1;
		switch (L_9)
		{
			case 0:
			{
				goto IL_07f1;
			}
			case 1:
			{
				goto IL_00a1;
			}
			case 2:
			{
				goto IL_01a5;
			}
			case 3:
			{
				goto IL_01cd;
			}
			case 4:
			{
				goto IL_0287;
			}
			case 5:
			{
				goto IL_02af;
			}
			case 6:
			{
				goto IL_02f2;
			}
			case 7:
			{
				goto IL_03e5;
			}
			case 8:
			{
				goto IL_04d8;
			}
			case 9:
			{
				goto IL_0526;
			}
			case 10:
			{
				goto IL_05f2;
			}
			case 11:
			{
				goto IL_05c4;
			}
			case 12:
			{
				goto IL_0620;
			}
			case 13:
			{
				goto IL_06e7;
			}
			case 14:
			{
				goto IL_06b9;
			}
			case 15:
			{
				goto IL_0715;
			}
			case 16:
			{
				goto IL_073c;
			}
			case 17:
			{
				goto IL_0763;
			}
			case 18:
			{
				goto IL_0787;
			}
			case 19:
			{
				goto IL_07ab;
			}
			case 20:
			{
				goto IL_07cf;
			}
		}
	}
	{
		goto IL_07f1;
	}

IL_00a1:
	{
		// if (t.IsSameOrSubclassOf(typeof(RectTransform))) tween = ((RectTransform)target).DOAnchorPos3D(endValueV3, duration, optionalBool0);
		Type_t* L_10 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_11 = { reinterpret_cast<intptr_t> (RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_12;
		L_12 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_11, NULL);
		bool L_13;
		L_13 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_10, L_12, NULL);
		if (!L_13)
		{
			goto IL_00e0;
		}
	}
	{
		// if (t.IsSameOrSubclassOf(typeof(RectTransform))) tween = ((RectTransform)target).DOAnchorPos3D(endValueV3, duration, optionalBool0);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_14 = __this->___target_28;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15 = __this->___endValueV3_32;
		float L_16 = __this->___duration_16;
		bool L_17 = __this->___optionalBool0_36;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_18;
		L_18 = ShortcutExtensions46_DOAnchorPos3D_mD3C94958F7972F83394BA948D2C8B647730FE6CF(((RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5*)CastclassSealed((RuntimeObject*)L_14, RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_il2cpp_TypeInfo_var)), L_15, L_16, L_17, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_18;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_18);
		goto IL_07f1;
	}

IL_00e0:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Transform))) tween = ((Transform)target).DOMove(endValueV3, duration, optionalBool0);
		Type_t* L_19 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_20 = { reinterpret_cast<intptr_t> (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_21;
		L_21 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_20, NULL);
		bool L_22;
		L_22 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_19, L_21, NULL);
		if (!L_22)
		{
			goto IL_011f;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Transform))) tween = ((Transform)target).DOMove(endValueV3, duration, optionalBool0);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_23 = __this->___target_28;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24 = __this->___endValueV3_32;
		float L_25 = __this->___duration_16;
		bool L_26 = __this->___optionalBool0_36;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_27;
		L_27 = ShortcutExtensions_DOMove_mC87BC8CB9F4E50901E6E7C970083FCB10BE97DA7(((Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*)CastclassClass((RuntimeObject*)L_23, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_il2cpp_TypeInfo_var)), L_24, L_25, L_26, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_27;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_27);
		goto IL_07f1;
	}

IL_011f:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Rigidbody2D))) tween = ((Rigidbody2D)target).DOMove(endValueV3, duration, optionalBool0);
		Type_t* L_28 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_29 = { reinterpret_cast<intptr_t> (Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_30;
		L_30 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_29, NULL);
		bool L_31;
		L_31 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_28, L_30, NULL);
		if (!L_31)
		{
			goto IL_0163;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Rigidbody2D))) tween = ((Rigidbody2D)target).DOMove(endValueV3, duration, optionalBool0);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_32 = __this->___target_28;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_33 = __this->___endValueV3_32;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_34;
		L_34 = Vector2_op_Implicit_mE8EBEE9291F11BB02F062D6E000F4798968CBD96_inline(L_33, NULL);
		float L_35 = __this->___duration_16;
		bool L_36 = __this->___optionalBool0_36;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_37;
		L_37 = ShortcutExtensions43_DOMove_mBB1F0330438A14C8380F8559F9BA19C279AE87B6(((Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F*)CastclassSealed((RuntimeObject*)L_32, Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F_il2cpp_TypeInfo_var)), L_34, L_35, L_36, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_37;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_37);
		goto IL_07f1;
	}

IL_0163:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Rigidbody))) tween = ((Rigidbody)target).DOMove(endValueV3, duration, optionalBool0);
		Type_t* L_38 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_39 = { reinterpret_cast<intptr_t> (Rigidbody_t268697F5A994213ED97393309870968BC1C7393C_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_40;
		L_40 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_39, NULL);
		bool L_41;
		L_41 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_38, L_40, NULL);
		if (!L_41)
		{
			goto IL_07f1;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Rigidbody))) tween = ((Rigidbody)target).DOMove(endValueV3, duration, optionalBool0);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_42 = __this->___target_28;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43 = __this->___endValueV3_32;
		float L_44 = __this->___duration_16;
		bool L_45 = __this->___optionalBool0_36;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_46;
		L_46 = ShortcutExtensions_DOMove_mA4F3D349D60820C1D16C10FAE5DE6AB3DC27FDC9(((Rigidbody_t268697F5A994213ED97393309870968BC1C7393C*)CastclassClass((RuntimeObject*)L_42, Rigidbody_t268697F5A994213ED97393309870968BC1C7393C_il2cpp_TypeInfo_var)), L_43, L_44, L_45, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_46;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_46);
		// break;
		goto IL_07f1;
	}

IL_01a5:
	{
		// tween = transform.DOLocalMove(endValueV3, duration, optionalBool0);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_47;
		L_47 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_48 = __this->___endValueV3_32;
		float L_49 = __this->___duration_16;
		bool L_50 = __this->___optionalBool0_36;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_51;
		L_51 = ShortcutExtensions_DOLocalMove_mE8D7AFEDAD7C66BA5FC0D4120E224AE0D70285AF(L_47, L_48, L_49, L_50, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_51;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_51);
		// break;
		goto IL_07f1;
	}

IL_01cd:
	{
		// if (t.IsSameOrSubclassOf(typeof(Transform))) tween = ((Transform)target).DORotate(endValueV3, duration, optionalRotationMode);
		Type_t* L_52 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_53 = { reinterpret_cast<intptr_t> (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_54;
		L_54 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_53, NULL);
		bool L_55;
		L_55 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_52, L_54, NULL);
		if (!L_55)
		{
			goto IL_020c;
		}
	}
	{
		// if (t.IsSameOrSubclassOf(typeof(Transform))) tween = ((Transform)target).DORotate(endValueV3, duration, optionalRotationMode);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_56 = __this->___target_28;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_57 = __this->___endValueV3_32;
		float L_58 = __this->___duration_16;
		int32_t L_59 = __this->___optionalRotationMode_39;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_60;
		L_60 = ShortcutExtensions_DORotate_m4D79691940046EC19FAB940BA10F860A88DEC522(((Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*)CastclassClass((RuntimeObject*)L_56, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_il2cpp_TypeInfo_var)), L_57, L_58, L_59, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_60;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_60);
		goto IL_07f1;
	}

IL_020c:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Rigidbody2D))) tween = ((Rigidbody2D)target).DORotate(endValueFloat, duration);
		Type_t* L_61 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_62 = { reinterpret_cast<intptr_t> (Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_63;
		L_63 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_62, NULL);
		bool L_64;
		L_64 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_61, L_63, NULL);
		if (!L_64)
		{
			goto IL_0245;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Rigidbody2D))) tween = ((Rigidbody2D)target).DORotate(endValueFloat, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_65 = __this->___target_28;
		float L_66 = __this->___endValueFloat_31;
		float L_67 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_68;
		L_68 = ShortcutExtensions43_DORotate_mAD9778B3D728A804C0D1FF4786D124683A82E600(((Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F*)CastclassSealed((RuntimeObject*)L_65, Rigidbody2D_tBEBE9523CF4448544085AF46BF7E10AA499F320F_il2cpp_TypeInfo_var)), L_66, L_67, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_68;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_68);
		goto IL_07f1;
	}

IL_0245:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Rigidbody))) tween = ((Rigidbody)target).DORotate(endValueV3, duration, optionalRotationMode);
		Type_t* L_69 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_70 = { reinterpret_cast<intptr_t> (Rigidbody_t268697F5A994213ED97393309870968BC1C7393C_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_71;
		L_71 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_70, NULL);
		bool L_72;
		L_72 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_69, L_71, NULL);
		if (!L_72)
		{
			goto IL_07f1;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Rigidbody))) tween = ((Rigidbody)target).DORotate(endValueV3, duration, optionalRotationMode);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_73 = __this->___target_28;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_74 = __this->___endValueV3_32;
		float L_75 = __this->___duration_16;
		int32_t L_76 = __this->___optionalRotationMode_39;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_77;
		L_77 = ShortcutExtensions_DORotate_m61ED3A616AA5410E25FEB01FC262E1E0CD257852(((Rigidbody_t268697F5A994213ED97393309870968BC1C7393C*)CastclassClass((RuntimeObject*)L_73, Rigidbody_t268697F5A994213ED97393309870968BC1C7393C_il2cpp_TypeInfo_var)), L_74, L_75, L_76, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_77;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_77);
		// break;
		goto IL_07f1;
	}

IL_0287:
	{
		// tween = transform.DOLocalRotate(endValueV3, duration, optionalRotationMode);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_78;
		L_78 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_79 = __this->___endValueV3_32;
		float L_80 = __this->___duration_16;
		int32_t L_81 = __this->___optionalRotationMode_39;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_82;
		L_82 = ShortcutExtensions_DOLocalRotate_m027486E5C7F402BCABC9BA2599BA9BC85D77731A(L_78, L_79, L_80, L_81, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_82;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_82);
		// break;
		goto IL_07f1;
	}

IL_02af:
	{
		// tween = transform.DOScale(optionalBool0 ? new Vector3(endValueFloat, endValueFloat, endValueFloat) : endValueV3, duration);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_83;
		L_83 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(__this, NULL);
		bool L_84 = __this->___optionalBool0_36;
		G_B21_0 = L_83;
		G_B21_1 = __this;
		if (L_84)
		{
			G_B22_0 = L_83;
			G_B22_1 = __this;
			goto IL_02c6;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_85 = __this->___endValueV3_32;
		G_B23_0 = L_85;
		G_B23_1 = G_B21_0;
		G_B23_2 = G_B21_1;
		goto IL_02dd;
	}

IL_02c6:
	{
		float L_86 = __this->___endValueFloat_31;
		float L_87 = __this->___endValueFloat_31;
		float L_88 = __this->___endValueFloat_31;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_89;
		memset((&L_89), 0, sizeof(L_89));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_89), L_86, L_87, L_88, /*hidden argument*/NULL);
		G_B23_0 = L_89;
		G_B23_1 = G_B22_0;
		G_B23_2 = G_B22_1;
	}

IL_02dd:
	{
		float L_90 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_91;
		L_91 = ShortcutExtensions_DOScale_m5D4EEFCF953640BEDFDE4A43162BEB9E533C24DE(G_B23_1, G_B23_0, L_90, NULL);
		NullCheck(G_B23_2);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)G_B23_2)->___tween_14 = L_91;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)G_B23_2)->___tween_14), (void*)L_91);
		// break;
		goto IL_07f1;
	}

IL_02f2:
	{
		// isRelative = false;
		__this->___isRelative_22 = (bool)0;
		// if (t.IsSameOrSubclassOf(typeof(SpriteRenderer))) tween = ((SpriteRenderer)target).DOColor(endValueColor, duration);
		Type_t* L_92 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_93 = { reinterpret_cast<intptr_t> (SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_94;
		L_94 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_93, NULL);
		bool L_95;
		L_95 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_92, L_94, NULL);
		if (!L_95)
		{
			goto IL_0332;
		}
	}
	{
		// if (t.IsSameOrSubclassOf(typeof(SpriteRenderer))) tween = ((SpriteRenderer)target).DOColor(endValueColor, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_96 = __this->___target_28;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_97 = __this->___endValueColor_33;
		float L_98 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_99;
		L_99 = ShortcutExtensions43_DOColor_m93DBCF7427FA75576E02531A8888053735F60AD5(((SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B*)CastclassSealed((RuntimeObject*)L_96, SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B_il2cpp_TypeInfo_var)), L_97, L_98, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_99;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_99);
		goto IL_07f1;
	}

IL_0332:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Renderer))) tween = ((Renderer)target).material.DOColor(endValueColor, duration);
		Type_t* L_100 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_101 = { reinterpret_cast<intptr_t> (Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_102;
		L_102 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_101, NULL);
		bool L_103;
		L_103 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_100, L_102, NULL);
		if (!L_103)
		{
			goto IL_0370;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Renderer))) tween = ((Renderer)target).material.DOColor(endValueColor, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_104 = __this->___target_28;
		NullCheck(((Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF*)CastclassClass((RuntimeObject*)L_104, Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF_il2cpp_TypeInfo_var)));
		Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* L_105;
		L_105 = Renderer_get_material_m5BA2A00816C4CC66580D4B2E409CF10718C15656(((Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF*)CastclassClass((RuntimeObject*)L_104, Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF_il2cpp_TypeInfo_var)), NULL);
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_106 = __this->___endValueColor_33;
		float L_107 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_108;
		L_108 = ShortcutExtensions_DOColor_m97E7121A6D5733170515C79FA753F6DFA5CEF7BF(L_105, L_106, L_107, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_108;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_108);
		goto IL_07f1;
	}

IL_0370:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Image))) tween = ((Image)target).DOColor(endValueColor, duration);
		Type_t* L_109 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_110 = { reinterpret_cast<intptr_t> (Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_111;
		L_111 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_110, NULL);
		bool L_112;
		L_112 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_109, L_111, NULL);
		if (!L_112)
		{
			goto IL_03a9;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Image))) tween = ((Image)target).DOColor(endValueColor, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_113 = __this->___target_28;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_114 = __this->___endValueColor_33;
		float L_115 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_116;
		L_116 = ShortcutExtensions46_DOColor_mACBA44C55FA1833043B88499BDE9CCDFED6E459E(((Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E*)CastclassClass((RuntimeObject*)L_113, Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E_il2cpp_TypeInfo_var)), L_114, L_115, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_116;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_116);
		goto IL_07f1;
	}

IL_03a9:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Text))) tween = ((Text)target).DOColor(endValueColor, duration);
		Type_t* L_117 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_118 = { reinterpret_cast<intptr_t> (Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_119;
		L_119 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_118, NULL);
		bool L_120;
		L_120 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_117, L_119, NULL);
		if (!L_120)
		{
			goto IL_07f1;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Text))) tween = ((Text)target).DOColor(endValueColor, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_121 = __this->___target_28;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_122 = __this->___endValueColor_33;
		float L_123 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_124;
		L_124 = ShortcutExtensions46_DOColor_m1A1DB7FCA93E4FFB66E43D1565C62CA3632D4772(((Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62*)CastclassClass((RuntimeObject*)L_121, Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_il2cpp_TypeInfo_var)), L_122, L_123, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_124;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_124);
		// break;
		goto IL_07f1;
	}

IL_03e5:
	{
		// isRelative = false;
		__this->___isRelative_22 = (bool)0;
		// if (t.IsSameOrSubclassOf(typeof(SpriteRenderer))) tween = ((SpriteRenderer)target).DOFade(endValueFloat, duration);
		Type_t* L_125 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_126 = { reinterpret_cast<intptr_t> (SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_127;
		L_127 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_126, NULL);
		bool L_128;
		L_128 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_125, L_127, NULL);
		if (!L_128)
		{
			goto IL_0425;
		}
	}
	{
		// if (t.IsSameOrSubclassOf(typeof(SpriteRenderer))) tween = ((SpriteRenderer)target).DOFade(endValueFloat, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_129 = __this->___target_28;
		float L_130 = __this->___endValueFloat_31;
		float L_131 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_132;
		L_132 = ShortcutExtensions43_DOFade_m479E5D5206F105288CF8AE4C0AB6E01028E577B7(((SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B*)CastclassSealed((RuntimeObject*)L_129, SpriteRenderer_t1DD7FE258F072E1FA87D6577BA27225892B8047B_il2cpp_TypeInfo_var)), L_130, L_131, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_132;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_132);
		goto IL_07f1;
	}

IL_0425:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Renderer))) tween = ((Renderer)target).material.DOFade(endValueFloat, duration);
		Type_t* L_133 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_134 = { reinterpret_cast<intptr_t> (Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_135;
		L_135 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_134, NULL);
		bool L_136;
		L_136 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_133, L_135, NULL);
		if (!L_136)
		{
			goto IL_0463;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Renderer))) tween = ((Renderer)target).material.DOFade(endValueFloat, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_137 = __this->___target_28;
		NullCheck(((Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF*)CastclassClass((RuntimeObject*)L_137, Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF_il2cpp_TypeInfo_var)));
		Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* L_138;
		L_138 = Renderer_get_material_m5BA2A00816C4CC66580D4B2E409CF10718C15656(((Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF*)CastclassClass((RuntimeObject*)L_137, Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF_il2cpp_TypeInfo_var)), NULL);
		float L_139 = __this->___endValueFloat_31;
		float L_140 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_141;
		L_141 = ShortcutExtensions_DOFade_mD6507EB288274EA459D2997A8EF5E47C7EA72C33(L_138, L_139, L_140, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_141;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_141);
		goto IL_07f1;
	}

IL_0463:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Image))) tween = ((Image)target).DOFade(endValueFloat, duration);
		Type_t* L_142 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_143 = { reinterpret_cast<intptr_t> (Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_144;
		L_144 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_143, NULL);
		bool L_145;
		L_145 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_142, L_144, NULL);
		if (!L_145)
		{
			goto IL_049c;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Image))) tween = ((Image)target).DOFade(endValueFloat, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_146 = __this->___target_28;
		float L_147 = __this->___endValueFloat_31;
		float L_148 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_149;
		L_149 = ShortcutExtensions46_DOFade_mF0F20522E904CF538B5036C6F9F6A98DE0FB98EC(((Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E*)CastclassClass((RuntimeObject*)L_146, Image_tBC1D03F63BF71132E9A5E472B8742F172A011E7E_il2cpp_TypeInfo_var)), L_147, L_148, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_149;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_149);
		goto IL_07f1;
	}

IL_049c:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Text))) tween = ((Text)target).DOFade(endValueFloat, duration);
		Type_t* L_150 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_151 = { reinterpret_cast<intptr_t> (Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_152;
		L_152 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_151, NULL);
		bool L_153;
		L_153 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_150, L_152, NULL);
		if (!L_153)
		{
			goto IL_07f1;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Text))) tween = ((Text)target).DOFade(endValueFloat, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_154 = __this->___target_28;
		float L_155 = __this->___endValueFloat_31;
		float L_156 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_157;
		L_157 = ShortcutExtensions46_DOFade_mAE86E0EA9887447ED242D3E359B6EFA8ABFF4F25(((Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62*)CastclassClass((RuntimeObject*)L_154, Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_il2cpp_TypeInfo_var)), L_155, L_156, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_157;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_157);
		// break;
		goto IL_07f1;
	}

IL_04d8:
	{
		// if (t.IsSameOrSubclassOf(typeof(Text))) tween = ((Text)target).DOText(endValueString, duration, optionalBool0, optionalScrambleMode, optionalString);
		Type_t* L_158 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_159 = { reinterpret_cast<intptr_t> (Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_160;
		L_160 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_159, NULL);
		bool L_161;
		L_161 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_158, L_160, NULL);
		if (!L_161)
		{
			goto IL_07f1;
		}
	}
	{
		// if (t.IsSameOrSubclassOf(typeof(Text))) tween = ((Text)target).DOText(endValueString, duration, optionalBool0, optionalScrambleMode, optionalString);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_162 = __this->___target_28;
		String_t* L_163 = __this->___endValueString_34;
		float L_164 = __this->___duration_16;
		bool L_165 = __this->___optionalBool0_36;
		int32_t L_166 = __this->___optionalScrambleMode_40;
		String_t* L_167 = __this->___optionalString_41;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_168;
		L_168 = ShortcutExtensions46_DOText_m6F718F5034C1576A75508D3E31E39B71F5A97E94(((Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62*)CastclassClass((RuntimeObject*)L_162, Text_tD60B2346DAA6666BF0D822FF607F0B220C2B9E62_il2cpp_TypeInfo_var)), L_163, L_164, L_165, L_166, L_167, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_168;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_168);
		// break;
		goto IL_07f1;
	}

IL_0526:
	{
		// if (t.IsSameOrSubclassOf(typeof(RectTransform))) tween = ((RectTransform)target).DOPunchAnchorPos(endValueV3, duration, optionalInt0, optionalFloat0, optionalBool0);
		Type_t* L_169 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_170 = { reinterpret_cast<intptr_t> (RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_171;
		L_171 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_170, NULL);
		bool L_172;
		L_172 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_169, L_171, NULL);
		if (!L_172)
		{
			goto IL_0576;
		}
	}
	{
		// if (t.IsSameOrSubclassOf(typeof(RectTransform))) tween = ((RectTransform)target).DOPunchAnchorPos(endValueV3, duration, optionalInt0, optionalFloat0, optionalBool0);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_173 = __this->___target_28;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_174 = __this->___endValueV3_32;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_175;
		L_175 = Vector2_op_Implicit_mE8EBEE9291F11BB02F062D6E000F4798968CBD96_inline(L_174, NULL);
		float L_176 = __this->___duration_16;
		int32_t L_177 = __this->___optionalInt0_38;
		float L_178 = __this->___optionalFloat0_37;
		bool L_179 = __this->___optionalBool0_36;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_180;
		L_180 = ShortcutExtensions46_DOPunchAnchorPos_mAFB78DA20738B0D3E353919CE027000FBF010918(((RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5*)CastclassSealed((RuntimeObject*)L_173, RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_il2cpp_TypeInfo_var)), L_175, L_176, L_177, L_178, L_179, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_180;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_180);
		goto IL_07f1;
	}

IL_0576:
	{
		// else if (t.IsSameOrSubclassOf(typeof(Transform))) tween = ((Transform)target).DOPunchPosition(endValueV3, duration, optionalInt0, optionalFloat0, optionalBool0);
		Type_t* L_181 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_182 = { reinterpret_cast<intptr_t> (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_183;
		L_183 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_182, NULL);
		bool L_184;
		L_184 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_181, L_183, NULL);
		if (!L_184)
		{
			goto IL_07f1;
		}
	}
	{
		// else if (t.IsSameOrSubclassOf(typeof(Transform))) tween = ((Transform)target).DOPunchPosition(endValueV3, duration, optionalInt0, optionalFloat0, optionalBool0);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_185 = __this->___target_28;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_186 = __this->___endValueV3_32;
		float L_187 = __this->___duration_16;
		int32_t L_188 = __this->___optionalInt0_38;
		float L_189 = __this->___optionalFloat0_37;
		bool L_190 = __this->___optionalBool0_36;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_191;
		L_191 = ShortcutExtensions_DOPunchPosition_mD022015ABB94942EE909F7F8E0F3660D52FA3D9E(((Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*)CastclassClass((RuntimeObject*)L_185, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_il2cpp_TypeInfo_var)), L_186, L_187, L_188, L_189, L_190, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_191;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_191);
		// break;
		goto IL_07f1;
	}

IL_05c4:
	{
		// tween = transform.DOPunchScale(endValueV3, duration, optionalInt0, optionalFloat0);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_192;
		L_192 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_193 = __this->___endValueV3_32;
		float L_194 = __this->___duration_16;
		int32_t L_195 = __this->___optionalInt0_38;
		float L_196 = __this->___optionalFloat0_37;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_197;
		L_197 = ShortcutExtensions_DOPunchScale_mD7D825D1761F0264BC1D00027B79330844400B9A(L_192, L_193, L_194, L_195, L_196, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_197;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_197);
		// break;
		goto IL_07f1;
	}

IL_05f2:
	{
		// tween = transform.DOPunchRotation(endValueV3, duration, optionalInt0, optionalFloat0);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_198;
		L_198 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(__this, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_199 = __this->___endValueV3_32;
		float L_200 = __this->___duration_16;
		int32_t L_201 = __this->___optionalInt0_38;
		float L_202 = __this->___optionalFloat0_37;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_203;
		L_203 = ShortcutExtensions_DOPunchRotation_mDC55C1F23E2C17A4E9D4BF5BB787BB1DE98D7AC4(L_198, L_199, L_200, L_201, L_202, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_203;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_203);
		// break;
		goto IL_07f1;
	}

IL_0620:
	{
		// if (t.IsSameOrSubclassOf(typeof(RectTransform))) tween = ((RectTransform)target).DOShakeAnchorPos(duration, endValueV3, optionalInt0, optionalFloat0, optionalBool0);
		Type_t* L_204 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_205 = { reinterpret_cast<intptr_t> (RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_206;
		L_206 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_205, NULL);
		bool L_207;
		L_207 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_204, L_206, NULL);
		if (!L_207)
		{
			goto IL_066b;
		}
	}
	{
		// if (t.IsSameOrSubclassOf(typeof(RectTransform))) tween = ((RectTransform)target).DOShakeAnchorPos(duration, endValueV3, optionalInt0, optionalFloat0, optionalBool0);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_208 = __this->___target_28;
		float L_209 = __this->___duration_16;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_210 = __this->___endValueV3_32;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_211;
		L_211 = Vector2_op_Implicit_mE8EBEE9291F11BB02F062D6E000F4798968CBD96_inline(L_210, NULL);
		int32_t L_212 = __this->___optionalInt0_38;
		float L_213 = __this->___optionalFloat0_37;
		bool L_214 = __this->___optionalBool0_36;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_215;
		L_215 = ShortcutExtensions46_DOShakeAnchorPos_m487B2DFC55303E3199ED9ED9CEFF29E00FFB9ECA(((RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5*)CastclassSealed((RuntimeObject*)L_208, RectTransform_t6C5DA5E41A89E0F488B001E45E58963480E543A5_il2cpp_TypeInfo_var)), L_209, L_211, L_212, L_213, L_214, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_215;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_215);
	}

IL_066b:
	{
		// if (t.IsSameOrSubclassOf(typeof(Transform))) tween = ((Transform)target).DOShakePosition(duration, endValueV3, optionalInt0, optionalFloat0, optionalBool0);
		Type_t* L_216 = V_0;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_217 = { reinterpret_cast<intptr_t> (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_0_0_0_var) };
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		Type_t* L_218;
		L_218 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_217, NULL);
		bool L_219;
		L_219 = DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8(L_216, L_218, NULL);
		if (!L_219)
		{
			goto IL_07f1;
		}
	}
	{
		// if (t.IsSameOrSubclassOf(typeof(Transform))) tween = ((Transform)target).DOShakePosition(duration, endValueV3, optionalInt0, optionalFloat0, optionalBool0);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_220 = __this->___target_28;
		float L_221 = __this->___duration_16;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_222 = __this->___endValueV3_32;
		int32_t L_223 = __this->___optionalInt0_38;
		float L_224 = __this->___optionalFloat0_37;
		bool L_225 = __this->___optionalBool0_36;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_226;
		L_226 = ShortcutExtensions_DOShakePosition_mB1708D218190B3BB17EA994EC7FE38871215603A(((Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1*)CastclassClass((RuntimeObject*)L_220, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1_il2cpp_TypeInfo_var)), L_221, L_222, L_223, L_224, L_225, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_226;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_226);
		// break;
		goto IL_07f1;
	}

IL_06b9:
	{
		// tween = transform.DOShakeScale(duration, endValueV3, optionalInt0, optionalFloat0);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_227;
		L_227 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(__this, NULL);
		float L_228 = __this->___duration_16;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_229 = __this->___endValueV3_32;
		int32_t L_230 = __this->___optionalInt0_38;
		float L_231 = __this->___optionalFloat0_37;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_232;
		L_232 = ShortcutExtensions_DOShakeScale_mC989EA82445A6F7C2181903FB28705523259B234(L_227, L_228, L_229, L_230, L_231, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_232;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_232);
		// break;
		goto IL_07f1;
	}

IL_06e7:
	{
		// tween = transform.DOShakeRotation(duration, endValueV3, optionalInt0, optionalFloat0);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_233;
		L_233 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(__this, NULL);
		float L_234 = __this->___duration_16;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_235 = __this->___endValueV3_32;
		int32_t L_236 = __this->___optionalInt0_38;
		float L_237 = __this->___optionalFloat0_37;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_238;
		L_238 = ShortcutExtensions_DOShakeRotation_m28BF1DB063CEC970358BB0A55DF067AE5677B619(L_233, L_234, L_235, L_236, L_237, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_238;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_238);
		// break;
		goto IL_07f1;
	}

IL_0715:
	{
		// tween = ((Camera)target).DOAspect(endValueFloat, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_239 = __this->___target_28;
		float L_240 = __this->___endValueFloat_31;
		float L_241 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_242;
		L_242 = ShortcutExtensions_DOAspect_m9259E372B05B663CEAF34FD052C7208B122F1B85(((Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184*)CastclassSealed((RuntimeObject*)L_239, Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_il2cpp_TypeInfo_var)), L_240, L_241, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_242;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_242);
		// break;
		goto IL_07f1;
	}

IL_073c:
	{
		// tween = ((Camera)target).DOColor(endValueColor, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_243 = __this->___target_28;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_244 = __this->___endValueColor_33;
		float L_245 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_246;
		L_246 = ShortcutExtensions_DOColor_m3F4236307CE5FFE06252C267B8C4A869DD6F8A84(((Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184*)CastclassSealed((RuntimeObject*)L_243, Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_il2cpp_TypeInfo_var)), L_244, L_245, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_246;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_246);
		// break;
		goto IL_07f1;
	}

IL_0763:
	{
		// tween = ((Camera)target).DOFieldOfView(endValueFloat, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_247 = __this->___target_28;
		float L_248 = __this->___endValueFloat_31;
		float L_249 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_250;
		L_250 = ShortcutExtensions_DOFieldOfView_m2BDF26AA4FB6FA6D8FF303820B6DEAE4A5825E62(((Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184*)CastclassSealed((RuntimeObject*)L_247, Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_il2cpp_TypeInfo_var)), L_248, L_249, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_250;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_250);
		// break;
		goto IL_07f1;
	}

IL_0787:
	{
		// tween = ((Camera)target).DOOrthoSize(endValueFloat, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_251 = __this->___target_28;
		float L_252 = __this->___endValueFloat_31;
		float L_253 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_254;
		L_254 = ShortcutExtensions_DOOrthoSize_m1264C986FBD05AA4E4EBEA48697ACCA451A18CFA(((Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184*)CastclassSealed((RuntimeObject*)L_251, Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_il2cpp_TypeInfo_var)), L_252, L_253, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_254;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_254);
		// break;
		goto IL_07f1;
	}

IL_07ab:
	{
		// tween = ((Camera)target).DOPixelRect(endValueRect, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_255 = __this->___target_28;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_256 = __this->___endValueRect_35;
		float L_257 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_258;
		L_258 = ShortcutExtensions_DOPixelRect_mA1A61FA657FFDA09A2BC26FE8F076940FB48DD17(((Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184*)CastclassSealed((RuntimeObject*)L_255, Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_il2cpp_TypeInfo_var)), L_256, L_257, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_258;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_258);
		// break;
		goto IL_07f1;
	}

IL_07cf:
	{
		// tween = ((Camera)target).DORect(endValueRect, duration);
		Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* L_259 = __this->___target_28;
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_260 = __this->___endValueRect_35;
		float L_261 = __this->___duration_16;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_262;
		L_262 = ShortcutExtensions_DORect_mB8CE84B918D661843A2C175D715BC10D3F59453D(((Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184*)CastclassSealed((RuntimeObject*)L_259, Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_il2cpp_TypeInfo_var)), L_260, L_261, NULL);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = L_262;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)L_262);
	}

IL_07f1:
	{
		// if (tween == null) return;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_263 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		if (L_263)
		{
			goto IL_07fa;
		}
	}
	{
		// if (tween == null) return;
		return;
	}

IL_07fa:
	{
		// if (isFrom) {
		bool L_264 = __this->___isFrom_23;
		if (!L_264)
		{
			goto IL_081b;
		}
	}
	{
		// ((Tweener)tween).From(isRelative);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_265 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		bool L_266 = __this->___isRelative_22;
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_267;
		L_267 = TweenSettingsExtensions_From_TisTweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_mBD5BB455040E882AE50EEAB6A2501BE795C1D799(((Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140*)CastclassClass((RuntimeObject*)L_265, Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_il2cpp_TypeInfo_var)), L_266, TweenSettingsExtensions_From_TisTweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_mBD5BB455040E882AE50EEAB6A2501BE795C1D799_RuntimeMethod_var);
		goto IL_082d;
	}

IL_081b:
	{
		// tween.SetRelative(isRelative);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_268 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		bool L_269 = __this->___isRelative_22;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_270;
		L_270 = TweenSettingsExtensions_SetRelative_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m39A70F3F6856D8F28E39EDE44E5A3E20053DA917(L_268, L_269, TweenSettingsExtensions_SetRelative_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m39A70F3F6856D8F28E39EDE44E5A3E20053DA917_RuntimeMethod_var);
	}

IL_082d:
	{
		// tween.SetTarget(this.gameObject).SetDelay(delay).SetLoops(loops, loopType).SetAutoKill(autoKill)
		//     .OnKill(()=> tween = null);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_271 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_272;
		L_272 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_273;
		L_273 = TweenSettingsExtensions_SetTarget_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m27A612ECE14371AB2BA5F411E9D7739F28208EC5(L_271, L_272, TweenSettingsExtensions_SetTarget_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m27A612ECE14371AB2BA5F411E9D7739F28208EC5_RuntimeMethod_var);
		float L_274 = __this->___delay_15;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_275;
		L_275 = TweenSettingsExtensions_SetDelay_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m2CEAE4E85D33463167ECC3B78A9F01FF36E41E43(L_273, L_274, TweenSettingsExtensions_SetDelay_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m2CEAE4E85D33463167ECC3B78A9F01FF36E41E43_RuntimeMethod_var);
		int32_t L_276 = __this->___loops_20;
		int32_t L_277 = __this->___loopType_19;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_278;
		L_278 = TweenSettingsExtensions_SetLoops_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mD6F6CE91C47CB2C78B0DC42F6F9452FEF789419C(L_275, L_276, L_277, TweenSettingsExtensions_SetLoops_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mD6F6CE91C47CB2C78B0DC42F6F9452FEF789419C_RuntimeMethod_var);
		bool L_279 = __this->___autoKill_25;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_280;
		L_280 = TweenSettingsExtensions_SetAutoKill_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCBB51799984C28B2039C1B35CB74368B6086A92B(L_278, L_279, TweenSettingsExtensions_SetAutoKill_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCBB51799984C28B2039C1B35CB74368B6086A92B_RuntimeMethod_var);
		TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* L_281 = (TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*)il2cpp_codegen_object_new(TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24_il2cpp_TypeInfo_var);
		NullCheck(L_281);
		TweenCallback__ctor_m68CC9304423CBDE43001F9B1413B5DAAF70DB621(L_281, __this, (intptr_t)((void*)DOTweenAnimation_U3CCreateTweenU3Eb__30_0_m755B57E81CDC2C38C648AC70205AB9799BE36F90_RuntimeMethod_var), NULL);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_282;
		L_282 = TweenSettingsExtensions_OnKill_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mBBA1302CE258A2BE2EDB4EAB0282A0F7E57A574F(L_280, L_281, TweenSettingsExtensions_OnKill_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mBBA1302CE258A2BE2EDB4EAB0282A0F7E57A574F_RuntimeMethod_var);
		// if (easeType == Ease.INTERNAL_Custom) tween.SetEase(easeCurve);
		int32_t L_283 = __this->___easeType_17;
		if ((!(((uint32_t)L_283) == ((uint32_t)((int32_t)33)))))
		{
			goto IL_0895;
		}
	}
	{
		// if (easeType == Ease.INTERNAL_Custom) tween.SetEase(easeCurve);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_284 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_285 = __this->___easeCurve_18;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_286;
		L_286 = TweenSettingsExtensions_SetEase_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mDA92D25D7C9B5461C21556F824B8615E54D4B102(L_284, L_285, TweenSettingsExtensions_SetEase_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mDA92D25D7C9B5461C21556F824B8615E54D4B102_RuntimeMethod_var);
		goto IL_08a7;
	}

IL_0895:
	{
		// else tween.SetEase(easeType);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_287 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		int32_t L_288 = __this->___easeType_17;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_289;
		L_289 = TweenSettingsExtensions_SetEase_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mEAB195CDAFF31E19188BBC670CFC250810B26F6F(L_287, L_288, TweenSettingsExtensions_SetEase_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mEAB195CDAFF31E19188BBC670CFC250810B26F6F_RuntimeMethod_var);
	}

IL_08a7:
	{
		// if (!string.IsNullOrEmpty(id)) tween.SetId(id);
		String_t* L_290 = __this->___id_21;
		bool L_291;
		L_291 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_290, NULL);
		if (L_291)
		{
			goto IL_08c6;
		}
	}
	{
		// if (!string.IsNullOrEmpty(id)) tween.SetId(id);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_292 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		String_t* L_293 = __this->___id_21;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_294;
		L_294 = TweenSettingsExtensions_SetId_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m29DE8BDBFA580F00E9FAE7DDC47937BCFCC30085(L_292, L_293, TweenSettingsExtensions_SetId_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m29DE8BDBFA580F00E9FAE7DDC47937BCFCC30085_RuntimeMethod_var);
	}

IL_08c6:
	{
		// tween.SetUpdate(isIndependentUpdate);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_295 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		bool L_296 = __this->___isIndependentUpdate_24;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_297;
		L_297 = TweenSettingsExtensions_SetUpdate_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mC3077CF17652F227E5720D80251A7B8238090CF8(L_295, L_296, TweenSettingsExtensions_SetUpdate_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mC3077CF17652F227E5720D80251A7B8238090CF8_RuntimeMethod_var);
		// if (hasOnStart) {
		bool L_298 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___hasOnStart_4;
		if (!L_298)
		{
			goto IL_0907;
		}
	}
	{
		// if (onStart != null) tween.OnStart(onStart.Invoke);
		UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* L_299 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onStart_9;
		if (!L_299)
		{
			goto IL_090e;
		}
	}
	{
		// if (onStart != null) tween.OnStart(onStart.Invoke);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_300 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* L_301 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onStart_9;
		TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* L_302 = (TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*)il2cpp_codegen_object_new(TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24_il2cpp_TypeInfo_var);
		NullCheck(L_302);
		TweenCallback__ctor_m68CC9304423CBDE43001F9B1413B5DAAF70DB621(L_302, L_301, (intptr_t)((void*)UnityEvent_Invoke_mFBF80D59B03C30C5FE6A06F897D954ACADE061D2_RuntimeMethod_var), NULL);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_303;
		L_303 = TweenSettingsExtensions_OnStart_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m745FAA93F7F77272847DE1A1E848E87E6D71DD85(L_300, L_302, TweenSettingsExtensions_OnStart_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m745FAA93F7F77272847DE1A1E848E87E6D71DD85_RuntimeMethod_var);
		goto IL_090e;
	}

IL_0907:
	{
		// } else onStart = null;
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onStart_9 = (UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onStart_9), (void*)(UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977*)NULL);
	}

IL_090e:
	{
		// if (hasOnPlay) {
		bool L_304 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___hasOnPlay_5;
		if (!L_304)
		{
			goto IL_093d;
		}
	}
	{
		// if (onPlay != null) tween.OnPlay(onPlay.Invoke);
		UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* L_305 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onPlay_10;
		if (!L_305)
		{
			goto IL_0944;
		}
	}
	{
		// if (onPlay != null) tween.OnPlay(onPlay.Invoke);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_306 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* L_307 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onPlay_10;
		TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* L_308 = (TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*)il2cpp_codegen_object_new(TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24_il2cpp_TypeInfo_var);
		NullCheck(L_308);
		TweenCallback__ctor_m68CC9304423CBDE43001F9B1413B5DAAF70DB621(L_308, L_307, (intptr_t)((void*)UnityEvent_Invoke_mFBF80D59B03C30C5FE6A06F897D954ACADE061D2_RuntimeMethod_var), NULL);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_309;
		L_309 = TweenSettingsExtensions_OnPlay_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m0FBA342A78026EAD99F1F4E3E4985D1872AEBF3B(L_306, L_308, TweenSettingsExtensions_OnPlay_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m0FBA342A78026EAD99F1F4E3E4985D1872AEBF3B_RuntimeMethod_var);
		goto IL_0944;
	}

IL_093d:
	{
		// } else onPlay = null;
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onPlay_10 = (UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onPlay_10), (void*)(UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977*)NULL);
	}

IL_0944:
	{
		// if (hasOnUpdate) {
		bool L_310 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___hasOnUpdate_6;
		if (!L_310)
		{
			goto IL_0973;
		}
	}
	{
		// if (onUpdate != null) tween.OnUpdate(onUpdate.Invoke);
		UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* L_311 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onUpdate_11;
		if (!L_311)
		{
			goto IL_097a;
		}
	}
	{
		// if (onUpdate != null) tween.OnUpdate(onUpdate.Invoke);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_312 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* L_313 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onUpdate_11;
		TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* L_314 = (TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*)il2cpp_codegen_object_new(TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24_il2cpp_TypeInfo_var);
		NullCheck(L_314);
		TweenCallback__ctor_m68CC9304423CBDE43001F9B1413B5DAAF70DB621(L_314, L_313, (intptr_t)((void*)UnityEvent_Invoke_mFBF80D59B03C30C5FE6A06F897D954ACADE061D2_RuntimeMethod_var), NULL);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_315;
		L_315 = TweenSettingsExtensions_OnUpdate_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m57E18275D826369CD94860A3F1C39309D94D7379(L_312, L_314, TweenSettingsExtensions_OnUpdate_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m57E18275D826369CD94860A3F1C39309D94D7379_RuntimeMethod_var);
		goto IL_097a;
	}

IL_0973:
	{
		// } else onUpdate = null;
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onUpdate_11 = (UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onUpdate_11), (void*)(UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977*)NULL);
	}

IL_097a:
	{
		// if (hasOnStepComplete) {
		bool L_316 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___hasOnStepComplete_7;
		if (!L_316)
		{
			goto IL_09a9;
		}
	}
	{
		// if (onStepComplete != null) tween.OnStepComplete(onStepComplete.Invoke);
		UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* L_317 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onStepComplete_12;
		if (!L_317)
		{
			goto IL_09b0;
		}
	}
	{
		// if (onStepComplete != null) tween.OnStepComplete(onStepComplete.Invoke);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_318 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* L_319 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onStepComplete_12;
		TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* L_320 = (TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*)il2cpp_codegen_object_new(TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24_il2cpp_TypeInfo_var);
		NullCheck(L_320);
		TweenCallback__ctor_m68CC9304423CBDE43001F9B1413B5DAAF70DB621(L_320, L_319, (intptr_t)((void*)UnityEvent_Invoke_mFBF80D59B03C30C5FE6A06F897D954ACADE061D2_RuntimeMethod_var), NULL);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_321;
		L_321 = TweenSettingsExtensions_OnStepComplete_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m792BB03889E21524E3344FA61E814C7584D3BE7C(L_318, L_320, TweenSettingsExtensions_OnStepComplete_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m792BB03889E21524E3344FA61E814C7584D3BE7C_RuntimeMethod_var);
		goto IL_09b0;
	}

IL_09a9:
	{
		// } else onStepComplete = null;
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onStepComplete_12 = (UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onStepComplete_12), (void*)(UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977*)NULL);
	}

IL_09b0:
	{
		// if (hasOnComplete) {
		bool L_322 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___hasOnComplete_8;
		if (!L_322)
		{
			goto IL_09df;
		}
	}
	{
		// if (onComplete != null) tween.OnComplete(onComplete.Invoke);
		UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* L_323 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onComplete_13;
		if (!L_323)
		{
			goto IL_09e6;
		}
	}
	{
		// if (onComplete != null) tween.OnComplete(onComplete.Invoke);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_324 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977* L_325 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onComplete_13;
		TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24* L_326 = (TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24*)il2cpp_codegen_object_new(TweenCallback_t7C8B8A38E7B30905FF1B83C943256EF23617BB24_il2cpp_TypeInfo_var);
		NullCheck(L_326);
		TweenCallback__ctor_m68CC9304423CBDE43001F9B1413B5DAAF70DB621(L_326, L_325, (intptr_t)((void*)UnityEvent_Invoke_mFBF80D59B03C30C5FE6A06F897D954ACADE061D2_RuntimeMethod_var), NULL);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_327;
		L_327 = TweenSettingsExtensions_OnComplete_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mBE711AE994C1480385AE49921B1DE8D773AC0F6F(L_324, L_326, TweenSettingsExtensions_OnComplete_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mBE711AE994C1480385AE49921B1DE8D773AC0F6F_RuntimeMethod_var);
		goto IL_09e6;
	}

IL_09df:
	{
		// } else onComplete = null;
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onComplete_13 = (UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___onComplete_13), (void*)(UnityEvent_tDC2C3548799DBC91D1E3F3DE60083A66F4751977*)NULL);
	}

IL_09e6:
	{
		// if (autoPlay) tween.Play();
		bool L_328 = __this->___autoPlay_30;
		if (!L_328)
		{
			goto IL_09fb;
		}
	}
	{
		// if (autoPlay) tween.Play();
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_329 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_330;
		L_330 = TweenExtensions_Play_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCD6CAE712476C0289135EE4E2113770DFB882C79(L_329, TweenExtensions_Play_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCD6CAE712476C0289135EE4E2113770DFB882C79_RuntimeMethod_var);
		return;
	}

IL_09fb:
	{
		// else tween.Pause();
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_331 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_332;
		L_332 = TweenExtensions_Pause_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m67DE92D56689877B5E346FE6239B6DEF7BB63685(L_331, TweenExtensions_Pause_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_m67DE92D56689877B5E346FE6239B6DEF7BB63685_RuntimeMethod_var);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DOPlay()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOPlay_m13FCD1B90C270CC6A4CDC37D45B9C7906759EB65 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DOTween.Play(this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = DOTween_Play_m466F46F9DF6585E17C595438BA15147319540DC4(L_0, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DOPlayBackwards()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOPlayBackwards_m7DAD71BF7390EE5BB26CEE5E002A9F61BBD790BB (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DOTween.PlayBackwards(this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = DOTween_PlayBackwards_m3709E26071CCE5CB368584477DF2FC9A8B9D052B(L_0, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DOPlayForward()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOPlayForward_m1C460584821358C681FFB2A3824D8F532B94A3D6 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DOTween.PlayForward(this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = DOTween_PlayForward_m4F27092024989DEB74466D9D9C370D5FA6621DCF(L_0, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DOPause()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOPause_m579FECCC254EDE65F38B0BB132FA796876409547 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DOTween.Pause(this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = DOTween_Pause_m498BECFBBC8FBD76425B8AE1F38E2ECC9AE296D4(L_0, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DOTogglePause()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOTogglePause_m3976C710434A81CEF46C8202D6D43A4F09FAE91E (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DOTween.TogglePause(this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = DOTween_TogglePause_m8CE7CA00FE30F3C926F34362E2DE67A161536598(L_0, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DORewind()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DORewind_m0ACC3EE9A69E368F08360B45500AF6417853AACF (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponents_TisDOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89_m95D9515665F9034EBE662B8B4835DB6B2817259B_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* V_0 = NULL;
	int32_t V_1 = 0;
	Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* V_2 = NULL;
	{
		// _playCount = -1;
		__this->____playCount_42 = (-1);
		// DOTweenAnimation[] anims = this.gameObject.GetComponents<DOTweenAnimation>();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		NullCheck(L_0);
		DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* L_1;
		L_1 = GameObject_GetComponents_TisDOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89_m95D9515665F9034EBE662B8B4835DB6B2817259B(L_0, GameObject_GetComponents_TisDOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89_m95D9515665F9034EBE662B8B4835DB6B2817259B_RuntimeMethod_var);
		V_0 = L_1;
		// for (int i = anims.Length - 1; i > -1; --i) {
		DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* L_2 = V_0;
		NullCheck(L_2);
		V_1 = ((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_2)->max_length)), 1));
		goto IL_0041;
	}

IL_001b:
	{
		// Tween t = anims[i].tween;
		DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* L_3 = V_0;
		int32_t L_4 = V_1;
		NullCheck(L_3);
		int32_t L_5 = L_4;
		DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* L_6 = (L_3)->GetAt(static_cast<il2cpp_array_size_t>(L_5));
		NullCheck(L_6);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_7 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)L_6)->___tween_14;
		V_2 = L_7;
		// if (t != null && t.IsInitialized()) anims[i].tween.Rewind();
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_8 = V_2;
		if (!L_8)
		{
			goto IL_003d;
		}
	}
	{
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_9 = V_2;
		bool L_10;
		L_10 = TweenExtensions_IsInitialized_m8C2B24B55147A6773849EB32D4D00E128CAB211B(L_9, NULL);
		if (!L_10)
		{
			goto IL_003d;
		}
	}
	{
		// if (t != null && t.IsInitialized()) anims[i].tween.Rewind();
		DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* L_11 = V_0;
		int32_t L_12 = V_1;
		NullCheck(L_11);
		int32_t L_13 = L_12;
		DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* L_14 = (L_11)->GetAt(static_cast<il2cpp_array_size_t>(L_13));
		NullCheck(L_14);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_15 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)L_14)->___tween_14;
		TweenExtensions_Rewind_m0ECE9F671C1A1BE35270FD24F9AC81DC5645DAF1(L_15, (bool)1, NULL);
	}

IL_003d:
	{
		// for (int i = anims.Length - 1; i > -1; --i) {
		int32_t L_16 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_subtract(L_16, 1));
	}

IL_0041:
	{
		// for (int i = anims.Length - 1; i > -1; --i) {
		int32_t L_17 = V_1;
		if ((((int32_t)L_17) > ((int32_t)(-1))))
		{
			goto IL_001b;
		}
	}
	{
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DORestart(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DORestart_m3991D3973BAB757263F5B7DF49236854F7CFFDD6 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, bool ___fromHere0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debugger_tCF42DBFBF81B46CDEE59CA397F2860F3427FE1F0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// _playCount = -1;
		__this->____playCount_42 = (-1);
		// if (tween == null) {
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_0 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		if (L_0)
		{
			goto IL_0023;
		}
	}
	{
		// if (Debugger.logPriority > 1) Debugger.LogNullTween(tween); return;
		int32_t L_1 = ((Debugger_tCF42DBFBF81B46CDEE59CA397F2860F3427FE1F0_StaticFields*)il2cpp_codegen_static_fields_for(Debugger_tCF42DBFBF81B46CDEE59CA397F2860F3427FE1F0_il2cpp_TypeInfo_var))->___logPriority_0;
		if ((((int32_t)L_1) <= ((int32_t)1)))
		{
			goto IL_0022;
		}
	}
	{
		// if (Debugger.logPriority > 1) Debugger.LogNullTween(tween); return;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_2 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		Debugger_LogNullTween_m9C6A433A68F2C3DFCDFF127434135F8BBC116740(L_2, NULL);
	}

IL_0022:
	{
		// if (Debugger.logPriority > 1) Debugger.LogNullTween(tween); return;
		return;
	}

IL_0023:
	{
		// if (fromHere && isRelative) ReEvaluateRelativeTween();
		bool L_3 = ___fromHere0;
		if (!L_3)
		{
			goto IL_0034;
		}
	}
	{
		bool L_4 = __this->___isRelative_22;
		if (!L_4)
		{
			goto IL_0034;
		}
	}
	{
		// if (fromHere && isRelative) ReEvaluateRelativeTween();
		DOTweenAnimation_ReEvaluateRelativeTween_mD0A5E517DC24E42DA505252FF14510A82AF3D884(__this, NULL);
	}

IL_0034:
	{
		// DOTween.Restart(this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_5;
		L_5 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_6;
		L_6 = DOTween_Restart_mC5BA3049922D5EA43F9E7A0B05735A21CADDBB64(L_5, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DOComplete()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOComplete_mA22769F47C0477E80CEFD1278B2400F6944B6111 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DOTween.Complete(this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = DOTween_Complete_mD95127D82A6D30613E788A90C9FA6E17BBDA634E(L_0, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DOKill()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOKill_m58766FE1B51A4ACB4AADF618088B24CA8BB558BE (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DOTween.Kill(this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = DOTween_Kill_mAB4C96CE1F1BCF25E5347AE0FC295D064EA53FB2(L_0, (bool)0, NULL);
		// tween = null;
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)(Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*)NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DOPlayById(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOPlayById_mB1AD544F5E83C3E5EE30EC09F55E3034625DD1FB (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, String_t* ___id0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DOTween.Play(this.gameObject, id);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		String_t* L_1 = ___id0;
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_2;
		L_2 = DOTween_Play_mEFD3A1E3CC218D3916032325F2E119C2004D9473(L_0, L_1, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DOPlayAllById(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOPlayAllById_m17BFE4D2AC992F441DA7DE57B06E1D8226F3422F (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, String_t* ___id0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// DOTween.Play(id);
		String_t* L_0 = ___id0;
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = DOTween_Play_m466F46F9DF6585E17C595438BA15147319540DC4(L_0, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DOPlayNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DOPlayNext_mB0A10A4963CBB56BC6AA79B312D7B8C00AADB1CA (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Component_GetComponents_TisDOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89_mBD8DF07C7D147339501B59183140B9EF098D3204_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TweenExtensions_Play_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCD6CAE712476C0289135EE4E2113770DFB882C79_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* V_0 = NULL;
	DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* V_1 = NULL;
	{
		// DOTweenAnimation[] anims = this.GetComponents<DOTweenAnimation>();
		DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* L_0;
		L_0 = Component_GetComponents_TisDOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89_mBD8DF07C7D147339501B59183140B9EF098D3204(__this, Component_GetComponents_TisDOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89_mBD8DF07C7D147339501B59183140B9EF098D3204_RuntimeMethod_var);
		V_0 = L_0;
		goto IL_0058;
	}

IL_0009:
	{
		// _playCount++;
		int32_t L_1 = __this->____playCount_42;
		__this->____playCount_42 = ((int32_t)il2cpp_codegen_add(L_1, 1));
		// DOTweenAnimation anim = anims[_playCount];
		DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* L_2 = V_0;
		int32_t L_3 = __this->____playCount_42;
		NullCheck(L_2);
		int32_t L_4 = L_3;
		DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* L_5 = (L_2)->GetAt(static_cast<il2cpp_array_size_t>(L_4));
		V_1 = L_5;
		// if (anim != null && anim.tween != null && !anim.tween.IsPlaying() && !anim.tween.IsComplete()) {
		DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* L_6 = V_1;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_7;
		L_7 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_6, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_7)
		{
			goto IL_0058;
		}
	}
	{
		DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* L_8 = V_1;
		NullCheck(L_8);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_9 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)L_8)->___tween_14;
		if (!L_9)
		{
			goto IL_0058;
		}
	}
	{
		DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* L_10 = V_1;
		NullCheck(L_10);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_11 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)L_10)->___tween_14;
		bool L_12;
		L_12 = TweenExtensions_IsPlaying_m32EF28DEB59B931FA4607BAC3BED0DE275A1D843(L_11, NULL);
		if (L_12)
		{
			goto IL_0058;
		}
	}
	{
		DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* L_13 = V_1;
		NullCheck(L_13);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_14 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)L_13)->___tween_14;
		bool L_15;
		L_15 = TweenExtensions_IsComplete_mBB619B64C19A85AB4EEEBB3D37D3E720A9E0AF4C(L_14, NULL);
		if (L_15)
		{
			goto IL_0058;
		}
	}
	{
		// anim.tween.Play();
		DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* L_16 = V_1;
		NullCheck(L_16);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_17 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)L_16)->___tween_14;
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_18;
		L_18 = TweenExtensions_Play_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCD6CAE712476C0289135EE4E2113770DFB882C79(L_17, TweenExtensions_Play_TisTween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C_mCD6CAE712476C0289135EE4E2113770DFB882C79_RuntimeMethod_var);
		// break;
		return;
	}

IL_0058:
	{
		// while (_playCount < anims.Length - 1) {
		int32_t L_19 = __this->____playCount_42;
		DOTweenAnimationU5BU5D_tF530B3C3860E2C494E291F938681DB0A9D98CB33* L_20 = V_0;
		NullCheck(L_20);
		if ((((int32_t)L_19) < ((int32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_20)->max_length)), 1)))))
		{
			goto IL_0009;
		}
	}
	{
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DORewindAndPlayNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DORewindAndPlayNext_m72276B3E5704C60C1F3662786656A0CAA4A63756 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// _playCount = -1;
		__this->____playCount_42 = (-1);
		// DOTween.Rewind(this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = DOTween_Rewind_m5C4020E9007FAAF719C1BE01CE440EBB39193619(L_0, (bool)1, NULL);
		// DOPlayNext();
		DOTweenAnimation_DOPlayNext_mB0A10A4963CBB56BC6AA79B312D7B8C00AADB1CA(__this, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DORestartById(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DORestartById_m79A437D8087A41B5B1DB998B2D95ACBC06C92F34 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, String_t* ___id0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// _playCount = -1;
		__this->____playCount_42 = (-1);
		// DOTween.Restart(this.gameObject, id);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		String_t* L_1 = ___id0;
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_2;
		L_2 = DOTween_Restart_m777E54A0343B1EC43975D4DEBBE7B1958B52A63F(L_0, L_1, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::DORestartAllById(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_DORestartAllById_mB4956E8A288B61CE7BFD1E091BE0F0E75B360E20 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, String_t* ___id0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// _playCount = -1;
		__this->____playCount_42 = (-1);
		// DOTween.Restart(id);
		String_t* L_0 = ___id0;
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		int32_t L_1;
		L_1 = DOTween_Restart_mC5BA3049922D5EA43F9E7A0B05735A21CADDBB64(L_0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Collections.Generic.List`1<DG.Tweening.Tween> DG.Tweening.DOTweenAnimation::GetTweens()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_tDA2C18E15C40590123A37DABB6D0D9AEB77A3BBD* DOTweenAnimation_GetTweens_mFA2D6C6863BE615A2D33B8D0E97C5FA40DF9B4EF (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return DOTween.TweensByTarget(this.gameObject);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(DOTween_t96369E1D40ABE93A56308F57DEA6B04219C66D13_il2cpp_TypeInfo_var);
		List_1_tDA2C18E15C40590123A37DABB6D0D9AEB77A3BBD* L_1;
		L_1 = DOTween_TweensByTarget_mA0B2273692BDA3C8658C4CD3FF177C74C2783B1A(L_0, (bool)0, NULL);
		return L_1;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::ReEvaluateRelativeTween()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_ReEvaluateRelativeTween_mD0A5E517DC24E42DA505252FF14510A82AF3D884 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (animationType == DOTweenAnimationType.Move) {
		int32_t L_0 = __this->___animationType_29;
		if ((!(((uint32_t)L_0) == ((uint32_t)1))))
		{
			goto IL_0037;
		}
	}
	{
		// ((Tweener)tween).ChangeEndValue(transform.position + endValueV3, true);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_1 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_2;
		L_2 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(__this, NULL);
		NullCheck(L_2);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3;
		L_3 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_2, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = __this->___endValueV3_32;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5;
		L_5 = Vector3_op_Addition_m78C0EC70CB66E8DCAC225743D82B268DAEE92067_inline(L_3, L_4, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = L_5;
		RuntimeObject* L_7 = Box(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var, &L_6);
		NullCheck(((Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140*)CastclassClass((RuntimeObject*)L_1, Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_il2cpp_TypeInfo_var)));
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_8;
		L_8 = VirtualFuncInvoker2< Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140*, RuntimeObject*, bool >::Invoke(11 /* DG.Tweening.Tweener DG.Tweening.Tweener::ChangeEndValue(System.Object,System.Boolean) */, ((Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140*)CastclassClass((RuntimeObject*)L_1, Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_il2cpp_TypeInfo_var)), L_7, (bool)1);
		return;
	}

IL_0037:
	{
		// } else if (animationType == DOTweenAnimationType.LocalMove) {
		int32_t L_9 = __this->___animationType_29;
		if ((!(((uint32_t)L_9) == ((uint32_t)2))))
		{
			goto IL_006d;
		}
	}
	{
		// ((Tweener)tween).ChangeEndValue(transform.localPosition + endValueV3, true);
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_10 = ((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_11;
		L_11 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(__this, NULL);
		NullCheck(L_11);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = Transform_get_localPosition_mA9C86B990DF0685EA1061A120218993FDCC60A95(L_11, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = __this->___endValueV3_32;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14;
		L_14 = Vector3_op_Addition_m78C0EC70CB66E8DCAC225743D82B268DAEE92067_inline(L_12, L_13, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_15 = L_14;
		RuntimeObject* L_16 = Box(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var, &L_15);
		NullCheck(((Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140*)CastclassClass((RuntimeObject*)L_10, Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_il2cpp_TypeInfo_var)));
		Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140* L_17;
		L_17 = VirtualFuncInvoker2< Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140*, RuntimeObject*, bool >::Invoke(11 /* DG.Tweening.Tweener DG.Tweening.Tweener::ChangeEndValue(System.Object,System.Boolean) */, ((Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140*)CastclassClass((RuntimeObject*)L_10, Tweener_tD38633F1A42EDF47A73CE3BF1894D946E830E140_il2cpp_TypeInfo_var)), L_16, (bool)1);
	}

IL_006d:
	{
		// }
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation__ctor_m250D5B591D9CDF8F9F165FF1F355597D2E615715 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float duration = 1;
		__this->___duration_16 = (1.0f);
		// public Ease easeType = Ease.OutQuad;
		__this->___easeType_17 = 6;
		// public AnimationCurve easeCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_0 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_1 = L_0;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_2;
		memset((&L_2), 0, sizeof(L_2));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_2), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_3 = L_1;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_4), (1.0f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_4);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_5);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_5, L_3, NULL);
		__this->___easeCurve_18 = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___easeCurve_18), (void*)L_5);
		// public int loops = 1;
		__this->___loops_20 = 1;
		// public string id = "";
		__this->___id_21 = _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___id_21), (void*)_stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709);
		// public bool autoKill = true;
		__this->___autoKill_25 = (bool)1;
		// public bool isActive = true;
		__this->___isActive_26 = (bool)1;
		// public bool autoPlay = true;
		__this->___autoPlay_30 = (bool)1;
		// public Color endValueColor = new Color(1, 1, 1, 1);
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_6;
		memset((&L_6), 0, sizeof(L_6));
		Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline((&L_6), (1.0f), (1.0f), (1.0f), (1.0f), /*hidden argument*/NULL);
		__this->___endValueColor_33 = L_6;
		// public string endValueString = "";
		__this->___endValueString_34 = _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___endValueString_34), (void*)_stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709);
		// public Rect endValueRect = new Rect(0, 0, 0, 0);
		Rect_tA04E0F8A1830E767F40FB27ECD8D309303571F0D L_7;
		memset((&L_7), 0, sizeof(L_7));
		Rect__ctor_m18C3033D135097BEE424AAA68D91C706D2647F23((&L_7), (0.0f), (0.0f), (0.0f), (0.0f), /*hidden argument*/NULL);
		__this->___endValueRect_35 = L_7;
		// int _playCount = -1; // Used when calling DOPlayNext
		__this->____playCount_42 = (-1);
		ABSAnimationComponent__ctor_mF2DC2EF90DDA4C57EC4858124EEEE03FE4CBB328(__this, NULL);
		return;
	}
}
// System.Void DG.Tweening.DOTweenAnimation::<CreateTween>b__30_0()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DOTweenAnimation_U3CCreateTweenU3Eb__30_0_m755B57E81CDC2C38C648AC70205AB9799BE36F90 (DOTweenAnimation_t941E0DA645657D923A54198B9BBEE27B9FE30F89* __this, const RuntimeMethod* method) 
{
	{
		// .OnKill(()=> tween = null);
		((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14 = (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((ABSAnimationComponent_t9F4FA691DC061D111BE0D991B3460910B31B6B7C*)__this)->___tween_14), (void*)(Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C*)NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Boolean DG.Tweening.DOTweenAnimationExtensions::IsSameOrSubclassOf(System.Type,System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool DOTweenAnimationExtensions_IsSameOrSubclassOf_mB272AD2BEFB7B6FA1E5C787998325407AF8FD6C8 (Type_t* ___t0, Type_t* ___tBase1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Type_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return t.IsSubclassOf(tBase) || t == tBase;
		Type_t* L_0 = ___t0;
		Type_t* L_1 = ___tBase1;
		NullCheck(L_0);
		bool L_2;
		L_2 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(26 /* System.Boolean System.Type::IsSubclassOf(System.Type) */, L_0, L_1);
		if (L_2)
		{
			goto IL_0011;
		}
	}
	{
		Type_t* L_3 = ___t0;
		Type_t* L_4 = ___tBase1;
		il2cpp_codegen_runtime_class_init_inline(Type_t_il2cpp_TypeInfo_var);
		bool L_5;
		L_5 = Type_op_Equality_m99930A0E44E420A685FABA60E60BA1CC5FA0EBDC(L_3, L_4, NULL);
		return L_5;
	}

IL_0011:
	{
		return (bool)1;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool TweenExtensions_IsActive_m7CB8E490D86B9E14B6B4B4004F1D199790397743_inline (Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* ___t0, const RuntimeMethod* method) 
{
	{
		Tween_t8CB06EBC48A5B6F5065C490E4F4909C18CE7983C* L_0 = ___t0;
		NullCheck(L_0);
		bool L_1 = L_0->___active_35;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Implicit_mE8EBEE9291F11BB02F062D6E000F4798968CBD96_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v0, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___v0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___v0;
		float L_3 = L_2.___y_3;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_4), L_1, L_3, /*hidden argument*/NULL);
		V_0 = L_4;
		goto IL_0015;
	}

IL_0015:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method) 
{
	{
		float L_0 = ___x0;
		__this->___x_2 = L_0;
		float L_1 = ___y1;
		__this->___y_3 = L_1;
		float L_2 = ___z2;
		__this->___z_4 = L_2;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Addition_m78C0EC70CB66E8DCAC225743D82B268DAEE92067_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___b1;
		float L_3 = L_2.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___a0;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___b1;
		float L_7 = L_6.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___a0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___b1;
		float L_11 = L_10.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_12), ((float)il2cpp_codegen_add(L_1, L_3)), ((float)il2cpp_codegen_add(L_5, L_7)), ((float)il2cpp_codegen_add(L_9, L_11)), /*hidden argument*/NULL);
		V_0 = L_12;
		goto IL_0030;
	}

IL_0030:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = V_0;
		return L_13;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* __this, float ___r0, float ___g1, float ___b2, float ___a3, const RuntimeMethod* method) 
{
	{
		float L_0 = ___r0;
		__this->___r_0 = L_0;
		float L_1 = ___g1;
		__this->___g_1 = L_1;
		float L_2 = ___b2;
		__this->___b_2 = L_2;
		float L_3 = ___a3;
		__this->___a_3 = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Add_mEBCF994CC3814631017F46A387B1A192ED6C85C7_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, RuntimeObject* ___item0, const RuntimeMethod* method) 
{
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* V_0 = NULL;
	int32_t V_1 = 0;
	{
		int32_t L_0 = (int32_t)__this->____version_3;
		__this->____version_3 = ((int32_t)il2cpp_codegen_add(L_0, 1));
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_1 = (ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)__this->____items_1;
		V_0 = L_1;
		int32_t L_2 = (int32_t)__this->____size_2;
		V_1 = L_2;
		int32_t L_3 = V_1;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_4 = V_0;
		NullCheck(L_4);
		if ((!(((uint32_t)L_3) < ((uint32_t)((int32_t)(((RuntimeArray*)L_4)->max_length))))))
		{
			goto IL_0034;
		}
	}
	{
		int32_t L_5 = V_1;
		__this->____size_2 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_6 = V_0;
		int32_t L_7 = V_1;
		RuntimeObject* L_8 = ___item0;
		NullCheck(L_6);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(L_7), (RuntimeObject*)L_8);
		return;
	}

IL_0034:
	{
		RuntimeObject* L_9 = ___item0;
		((  void (*) (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D*, RuntimeObject*, const RuntimeMethod*))il2cpp_codegen_get_method_pointer(il2cpp_rgctx_method(method->klass->rgctx_data, 11)))(__this, L_9, il2cpp_rgctx_method(method->klass->rgctx_data, 11));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* __this, float ___x0, float ___y1, const RuntimeMethod* method) 
{
	{
		float L_0 = ___x0;
		__this->___x_0 = L_0;
		float L_1 = ___y1;
		__this->___y_1 = L_1;
		return;
	}
}
