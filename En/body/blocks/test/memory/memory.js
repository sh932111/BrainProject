var memoryBk;
function memoryBlock(id) {
	this.bkID = id;
	this.wordList = [];
	this.index = 0;
	this.sound = function() {
		$("#speak").click();
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
		$("#learn-word").html("單字：" + word + "&nbsp;&nbsp;");
		$("#config-word").html("詞性：" + definition.enDefinition + "&nbsp;&nbsp;&nbsp;&nbsp;解釋：" + translate.enTranslate);
		$("#en-example").html(example.enExample);
		$("#zh-example").html(example.zhExample);
		$("#word-input").val(word);
		if (this.index == 0) {
			$("#left-controller").hide();
			$("#right-controller").show();
		}
		else if (this.index == this.wordList.length - 1) {
			$("#right-controller").hide();
			$("#left-controller").show();
		}
		else {
			$("#right-controller").show();
			$("#left-controller").show();
		}
		this.hideTest();
	};
	this.hideTest = function() {
		$("#word-box").show();
		$("#example-box").show();
		$("#do-test").hide();
		$("#self-test").show();
	};
	this.doTest = function() {
		$("#word-box").hide();
		$("#example-box").hide();
		$("#do-test").show();
		$("#write-input").val("");
	};
	this.confirm = function() {
		var item = this.wordList[this.index];
		var word = item.enWord;
		var input = $("#write-input").val();
		if (input == word) {
			$('#message').html("你答對了！");
			$('#message-modal').openModal();
			this.hideTest();
		}
		else {
			$('#message').html("你答錯了，請再試試！");
			$('#message-modal').openModal();
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

function memoryBlockMain(bkID) {
	memoryBk = new memoryBlock(bkID);
	var manager = ctrlManagerList[bkID];
	var api = manager.getAPI();
	memoryBk.init(api.list);
    meSpeak.loadConfig("/En/resource/lib/mespeak/mespeak_config.json");
    meSpeak.loadVoice("/En/resource/lib/mespeak/voices/en/en.json");
};

