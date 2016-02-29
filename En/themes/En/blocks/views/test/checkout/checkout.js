ctrl.startup = function() {
	ctrl.testPageBk = new ctrl.testPageBlock();
	var api = ctrl.getAPI();
	var orderID = ctrl.bi.query.orderID;
	var value = api.value.value;
	ctrl.testPageBk.init(value.wordNum,orderID);
	var head = ctrl.getBlockBody("#pgHeader");
	head.sel("#head-title").html("單字測驗");
	head.sel("#head-card-text").html("填寫完單字後，請先點選上傳按鈕，上傳成績後確認無誤即可點擊交卷！");
    meSpeak.loadConfig("/YogaServ/sites/En/cont/js/lib/mespeak/mespeak_config.json");
    meSpeak.loadVoice("/YogaServ/sites/En/cont/js/lib/mespeak/voices/en/en.json");
    ctrl.sel("#upload-loader").hide();
};

ctrl.testPageBk;
ctrl.testPageBlock = function() {
	this.wordNum = 0;
	this.orderID;
	this.upload = function() {
		var list = [];
		for (var i = 0; i < this.wordNum; i++) {
			var word = ctrl.sel("#word" + i);
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
    	ctrl.sel("#upload-loader").show();
    	ctrl.sel("#upload-btn").hide();
    	var req = {
			url: "/order/updateWord.php", 
			post: {
				data : JSON.stringify(post)
			} 
		}; 
		ctrl.api(req, function(response){ 
			var data = response.data;
			if (data.result) {
				ctrl.sel('#message-modal').openModal();
			}
    		ctrl.sel("#upload-loader").hide();
    		ctrl.sel("#upload-btn").show();
		});
	};
	this.init = function(word_num , order_id) {
		this.wordNum = word_num;
		this.orderID = order_id;
	};
	this.sound = function(index) {
		ctrl.sel("#speak" + index).click();
	};
};