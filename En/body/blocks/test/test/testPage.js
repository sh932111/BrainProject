var testPageBk;
function testPageBlock(id) {
	this.bkID = id;
	this.wordNum = 0;
	this.orderID;
	this.upload = function() {
		var list = [];
		for (var i = 0; i < this.wordNum; i++) {
			var word = $("#word" + i);
			var par = word.parent();
			var test = word.val();
			var detailID = par[0].id;
			var item = {
				test : test,
				detailID : detailID
			};
			list.push(item);
		}
		var post = {
			list : list,
			orderID : this.orderID
		};
    	$("#upload-loader").show();
    	$("#upload-btn").hide();
		httpPost(orderUpdateWord,post,function(data){
			if (data.result) {
				$('#message-modal').openModal();
			}
    		$("#upload-loader").hide();
    		$("#upload-btn").show();
		});
	};
	this.init = function(word_num , order_id) {
		this.wordNum = word_num;
		this.orderID = order_id;
	};
	this.sound = function(index) {
		$("#speak" + index).click();
	};
};

function testPageBlockMain(bkID) {
	testPageBk = new testPageBlock(bkID);
	var manager = ctrlManagerList[bkID];
	var api = manager.getAPI();
	var get = manager.getGET();
	var value = api.value;
	testPageBk.init(value.wordNum,get);
    meSpeak.loadConfig("/En/resource/lib/mespeak/mespeak_config.json");
    meSpeak.loadVoice("/En/resource/lib/mespeak/voices/en/en.json");
    $("#upload-loader").hide();
};