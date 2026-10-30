
var GetLabInfo={
	
	/**
	 * 函数功能：获取实验用户信息及实验或预约实验唯一标识符
     * 参数输入：data 用户信息+实验id（或学生预约实验id）
	 */
	_GetUserInfo : function(objname,methodname) {
		
		var GameObjectName = Pointer_stringify(objname);
		var MethodName = Pointer_stringify(methodname)
		
		window.addEventListener('message',function(e){
			var data = e.data;

			if(window.gameInstance){
									
				var jsonStr=JSON.stringify(data);
				
				window.gameInstance.SendMessage(GameObjectName, MethodName,jsonStr);
				return;
			}
					  		 
        },false);
		
		window.parent.postMessage('getUserInfo','*');
	},
	
};
mergeInto(LibraryManager.library,GetLabInfo);





