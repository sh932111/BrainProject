var chooseBk;
function chooseBlock(id) {
	this.bkID = id;
	this.call = true;
	this.wordNum = -1;
	this.addWord = function(orderID , enWordID , index) {
		if (!this.call) return;
		this.call = false;
		$("#btn-"+index).hide();
		$("#loader-"+index).show();
		var post = {
			orderID : orderID , 
			enWordID : enWordID
		};
		httpPost(orderCreateWord,post,function(data){
			chooseBk.call = true;
			if (data.result) {
				window.location.reload();
			}
			else {
				$("#loader-"+index).hide();
				$("#btn-"+index).show();
				$('#message').html(data.message);
				$('#message-modal').openModal();
			}
		});
	};
	this.removeWord = function(detailID , index) {
		if (!this.call) return;
		this.call = false;
		var post = {
			detailID : detailID
		};
		httpPost(orderDeleteWord,post,function(data){
			chooseBk.call = true;
			if (data.result) {
				chooseBk.wordNum = chooseBk.wordNum - 1;
				$("#word-num-text").html("已選擇："+chooseBk.wordNum+"個單字");
				$("#box-"+index).remove();
			}
			else {
				$('#message').html(data.message);
				$('#message-modal').openModal();
			}
		});
	};
	this.init = function(num) {
		this.wordNum = num;
	};
};

function chooseBlockMain(bkID) {
	chooseBk = new chooseBlock(bkID);
	var manager = ctrlManagerList[bkID];
	var api = manager.getAPI();
	if (api.data.error_code == 0) {
		var wordList = api.data.wordList;
		var list = api.order.list;
		for (var i = 0; i < wordList.length; i++) {
			$("#loader-"+i).hide();
		}
		chooseBk.init(list.length);
	}
};