var chooseBk;
function chooseBlock(id) {
	this.bkID = id;
	this.addWord = function(orderID , enWordID) {
		var post = {
			orderID : orderID , 
			enWordID : enWordID
		};
		httpPost(orderCreateWord,post,function(data){
			if (data.result) {
				window.location.reload();
			}
			else {
				alert(data.message);
			}
		});
	};
	this.removeWord = function(detailID) {
		var post = {
			detailID : detailID
		};
		httpPost(orderDeleteWord,post,function(data){
			if (data.result) {
				window.location.reload();
			}
			else {
				alert(data.message);
			}
		});
	};
};

function chooseBlockMain(bkID) {
	chooseBk = new chooseBlock(bkID);
	// var manager = ctrlManagerList[bkID];
	// var api = manager.getAPI();
};