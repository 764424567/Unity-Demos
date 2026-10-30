mergeInto(LibraryManager.library, {
GetVariable: function () {
	var parameters = Object();
	var query = window.location.search.substring(1);
	var vars = query.split("&");
	for (var i=0;i<vars.length;i++) 
	{
		var pair = vars[i].split("=");
		parameters[pair[0]] = pair[1];
	}
	var returnStr = JSON.stringify(parameters);
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
},
});