ctrl.startup = function() {
	ctrl.memoryBk = new ctrl.memoryBlock();
	var api = ctrl.getAPI();
	var list = api.value.list;
	ctrl.memoryBk.init(list);
	var head = ctrl.getBlockBody("#pgHeader");
	head.sel("#head-title").html("單字記憶");
	head.sel("#head-card-text").html("請於時間內，背完選擇的單字！如果已經背完也可提早考試。");
    meSpeak.loadConfig("/YogaServ/sites/En/cont/js/lib/mespeak/mespeak_config.json");
    meSpeak.loadVoice("/YogaServ/sites/En/cont/js/lib/mespeak/voices/en/en.json");
};

ctrl.memoryBk;
ctrl.memoryBlock = function() {
	this.wordList = [];
	this.index = 0;
	this.sound = function() {
		ctrl.sel("#speak").click();
	};
	this.google = function() {
		var item = this.wordList[this.index];
		var word = item.enWord;
		var url = "https://translate.google.com.tw/?hl=zh-TW&tab=wT&authuser=0#en/zh-TW/" + word;
		window.open(url,"","toolbar=no,location=no,directories=no");
	};
	this.next = function() {
		this.index ++;
		this.setValue();
	};
	this.back = function() {
		this.index --;
		this.setValue();
	};
	this.setValue = function() {
		var item = this.wordList[this.index];
		var word = item.enWord;
		var definition 	= item.definitionList[0];
		var example 	= item.exampleList[0];
		var translate 	= item.translateList[0];
		ctrl.sel("#learn-word").html("單字：" + word + "&nbsp;&nbsp;");
		ctrl.sel("#config-word").html("詞性：" + definition.enDefinition + "&nbsp;&nbsp;&nbsp;&nbsp;解釋：" + translate.enTranslate);
		ctrl.sel("#en-example").html(example.enExample);
		ctrl.sel("#zh-example").html(example.zhExample);
		ctrl.sel("#word-input").val(word);
		if (this.index == 0) {
			ctrl.sel("#left-controller").hide();
			ctrl.sel("#right-controller").show();
		}
		else if (this.index == this.wordList.length - 1) {
			ctrl.sel("#right-controller").hide();
			ctrl.sel("#left-controller").show();
		}
		else {
			ctrl.sel("#right-controller").show();
			ctrl.sel("#left-controller").show();
		}
		this.hideTest();
	};
	this.hideTest = function() {
		ctrl.sel("#word-box").show();
		ctrl.sel("#example-box").show();
		ctrl.sel("#do-test").hide();
		ctrl.sel("#self-test").show();
	};
	this.doTest = function() {
		ctrl.sel("#word-box").hide();
		ctrl.sel("#example-box").hide();
		ctrl.sel("#do-test").show();
		ctrl.sel("#write-input").val("");
	};
	this.confirm = function() {
		var item = this.wordList[this.index];
		var word = item.enWord;
		var input = ctrl.sel("#write-input").val();
		if (input == word) {
			ctrl.sel('#message').html("你答對了！");
			ctrl.sel('#message-modal').openModal();
			this.hideTest();
		}
		else {
			ctrl.sel('#message').html("你答錯了，請再試試！");
			ctrl.sel('#message-modal').openModal();
		}
	};
	this.init = function(list) {
		this.wordList = list;
		if (list.length > 0) {
			this.index = 0;
			this.setValue();
		}
	};
};