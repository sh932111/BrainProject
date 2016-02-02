var ctrlManagerList = {};

function ctrlManager(ID , get , api) {
	this.bkID = ID;
	this.GET = get;
	this.API = api;
	ctrlManagerList[ID] = this;
	this.reload = function(blockName, aCb) {
		var content = $("#" + this.bkID)[0].parentNode;
		var loadID = content.id;
		var me = this;
		ctrlManager.embed(loadID ,blockName , function(){
			me.removeJS();
			me.removeCSS();
			me.removeThis();
			aCb();
		});
	};
	this.removeJS = function() {
		var headContent = document.getElementsByTagName('head')[0];
		var jsID = "js" + this.bkID;
		headContent.removeChild($("#" + jsID)[0]);
	};
	this.removeCSS = function() {
		var headContent = document.getElementsByTagName('head')[0];
		var cssID = "css" + this.bkID;
		headContent.removeChild($("#" + cssID)[0]);
	};
	this.removeThis = function() {
		delete ctrlManagerList[this.bkID];
	};
	this.getAPI = function() {
		return this.API;
	};
	this.getGET = function() {
		return this.GET;
	};
};
ctrlManager.embed = function (loadID ,blockName, aCb) {
	var content = $("#" + loadID);
	var pgTls = new pathTools();
	var url = pgTls.getAppPath() + pgTls.webViewerURL;
	var pdata = {
		block : blockName
	};
	$.post(url, pdata, function(html) {
		var code = html.split("loadHTML");
		if (code.length > 0) {
			var resource = code[0];
			var html_code = code[1];
			$('head').append( resource );
			content.html(html_code);
		}
		else {
			content.html(html);
		}
		aCb();
	});
};
ctrlManager.getIDForRoot = function(root) {
	var parent = document.getElementById(root);
	var child = parent.children[0];
	return child.id;
};

function pathTools() {
	this.webViewerURL = "/base/WebViewer.php";
	this.getAppPath = function() {
		var pathArray = location.pathname.split('/');
		var appPath = "/";
		for(var i=1; i<pathArray.length-1; i++) {
			appPath += pathArray[i] + "/";
		}
		var project = appPath.split("/body/pages");
		return project[0];
	};
};