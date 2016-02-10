var chooseBk;
function chooseBlock(id) {
	this.bkID = id;
	this.call = true;
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
				alert(data.message);
			}
		});
	};
	this.removeWord = function(detailID , index) {
		if (!this.call) return;
		this.call = false;
		$("#btn-"+index).hide();
		$("#loader-"+index).show();
		var post = {
			detailID : detailID
		};
		httpPost(orderDeleteWord,post,function(data){
			chooseBk.call = true;
			if (data.result) {
				window.location.reload();
			}
			else {
				$("#btn-"+index).show();
				$("#loader-"+index).hide();
				alert(data.message);
			}
		});
	};
};

function chooseBlockMain(bkID) {
	chooseBk = new chooseBlock(bkID);
	var manager = ctrlManagerList[bkID];
	var api = manager.getAPI();
	if (api.data.error_code == 0) {
		var wordList = api.data.wordList;
		for (var i = 0; i < wordList.length; i++) {
			$("#loader-"+i).hide();
		}
	}
};