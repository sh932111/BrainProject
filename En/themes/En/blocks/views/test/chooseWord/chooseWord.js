ctrl.startup = function() {
	ctrl.chooseBk = new ctrl.chooseBlock();
	var api = ctrl.getAPI();
	if (api.code == 0) {
		var value = api.value;
		var wordList = value.data.wordList;
		var list = value.order.list;
		for (var i = 0; i < wordList.length; i++) {
			ctrl.sel("#loader-"+i).hide();
		}
		ctrl.chooseBk.init(list.length);
	}
	var head = ctrl.getBlockBody("#pgHeader");
	head.sel("#head-title").html("單字選擇");
	head.sel("#head-card").hide();
};
ctrl.chooseBk;
ctrl.chooseBlock = function() {
	this.call = true;
	this.wordNum = -1;
	this.addWord = function(orderID , enWordID , index) {
		if (!this.call) return;
		this.call = false;
		ctrl.sel("#btn-"+index).hide();
		ctrl.sel("#loader-"+index).show();
		var post = {
			orderID : orderID , 
			enWordID : enWordID
		};
		var req = {
			url: "/order/createWord.php", 
			post: {
				data : JSON.stringify(post)
			} 
		}; 
		ctrl.api(req, function(response){ 
			ctrl.chooseBk.call = true;
			var data = response.data;
			if (data.result) {
				alert(data.message);
				window.location.reload();
			}
			else {
				ctrl.sel("#loader-"+index).hide();
				ctrl.sel("#btn-"+index).show();
				ctrl.sel('#message').html(data.message);
				ctrl.sel('#message-modal').openModal();
			}
		});
	};
	this.removeWord = function(detailID , index) {
		if (!this.call) return;
		this.call = false;
		var post = {
			detailID : detailID
		};
		var req = {
			url: "/order/deleteWord.php", 
			post: {
				data : JSON.stringify(post)
			} 
		}; 
		ctrl.api(req, function(response){ 
			ctrl.chooseBk.call = true;
			var data = response.data;
			if (data.result) {
				ctrl.chooseBk.wordNum = ctrl.chooseBk.wordNum - 1;
				ctrl.sel("#word-num-text").html("已選擇："+ctrl.chooseBk.wordNum+"個單字");
				ctrl.sel("#box-"+index).remove();
			}
			else {
				ctrl.sel('#message').html(data.message);
				ctrl.sel('#message-modal').openModal();
			}
		});
	};
	this.init = function(num) {
		this.wordNum = num;
	};
};