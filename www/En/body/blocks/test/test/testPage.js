var testPageBk;
function testPageBlock(id) {
	this.bkID = id;
	this.wordNum = 0;
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
			list : list
		};
		httpPost(orderUpdateWord,post,function(data){
			if (data.result) {
				alert("上傳成功！如確認無誤請點選交卷按鈕！");
			}
		});
	};
	this.init = function(word_num) {
		this.wordNum = word_num;
	};
};

function testPageBlockMain(bkID) {
	testPageBk = new testPageBlock(bkID);
	var manager = ctrlManagerList[bkID];
	var api = manager.getAPI();
	var value = api.value;
	testPageBk.init(value.wordNum);
};